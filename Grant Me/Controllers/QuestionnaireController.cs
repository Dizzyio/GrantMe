using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Grant_Me.Data;
using Grant_Me.Models;
using System.Threading.Tasks;

namespace Grant_Me.Controllers
{
    public class QuestionnaireController : Controller
    {
        private readonly GrantDbContext _context;
        private readonly UserManager<User> _userManager;

        public QuestionnaireController(GrantDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit(UserResponse userResponse)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", userResponse);
            }

            _context.UserResponses.Add(userResponse);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Results", new { id = userResponse.Id });
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new UserResponse();

            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    model.FullName = user.FullName;
                    model.DateOfBirth = user.DateOfBirth;
                    model.Citizenship = user.Citizenship;
                    model.AnnualIncome = user.AnnualIncome;
                    model.HasDisability = user.HasDisability;
                    model.BusinessName = user.BusinessName;
                    model.BusinessStructure = user.BusinessStructure;
                    model.BusinessRevenue = user.BusinessRevenue ?? 0;
                    model.IsNonProfit = user.IsNonProfit;
                    model.CharityNumber = user.CharityNumber;
                }
            }

            return View(model);
        }
    }
}
