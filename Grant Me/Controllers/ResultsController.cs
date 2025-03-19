using Microsoft.AspNetCore.Mvc;
using Grant_Me.Data;
using Grant_Me.Models;
using Grant_Me.Services;
using System.Linq;
using System.Threading.Tasks;

namespace Grant_Me.Controllers
{
    public class ResultsController : Controller
    {
        private readonly GrantDbContext _context;
        private readonly GrantMatcher _grantMatcher;

        public ResultsController(GrantDbContext context)
        {
            _context = context;
            _grantMatcher = new GrantMatcher(context);
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home"); // Redirect to Home if no ID is provided
            }

            var userResponse = await _context.UserResponses.FindAsync(id);
            if (userResponse == null)
            {
                return NotFound();
            }

            var (eligibleGrants, nearMissGrants) = _grantMatcher.MatchUserToGrants(userResponse);

            var viewModel = new ResultsViewModel
            {
                EligibleGrants = eligibleGrants,
                NearMissGrants = nearMissGrants.Select(nm => new NearMissGrant
                {
                    Name = nm.grant.Name,
                    Description = nm.grant.Description,
                    Amount = nm.grant.Amount.ToString("C"), // Converts decimal to a formatted currency string
                    NearMissReason = nm.reason
                }).ToList()
            };

            return View(viewModel);
        }

    }
}
