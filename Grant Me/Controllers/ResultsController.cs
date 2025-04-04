using Microsoft.AspNetCore.Mvc;
using Grant_Me.Data;
using Grant_Me.Models;
using Grant_Me.Services;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Grant_Me.Controllers
{
    public class ResultsController : Controller
    {
        private readonly GrantDbContext _context;
        private readonly GrantMatcher _grantMatcher;
        private readonly UserManager<User> _userManager;


        public ResultsController(GrantDbContext context)
        {
            _context = context;
            _grantMatcher = new GrantMatcher(context);
        }

        [HttpGet]
        public async Task<IActionResult> History()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Auth");
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            var responses = _context.UserResponses
                .Where(r => r.UserId == user.Id)
                .OrderByDescending(r => r.Id)
                .ToList();

            var model = new HistoryViewModel
            {
                Responses = responses
            };

            return View(model);
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
