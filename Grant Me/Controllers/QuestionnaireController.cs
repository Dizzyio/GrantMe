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
            Console.WriteLine("Submit method was called!");

            if (!ModelState.IsValid)
            {
                Console.WriteLine("ModelState is invalid!");
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        Console.WriteLine(" - " + error.ErrorMessage);
                    }
                }
                return View("Index", userResponse);
            }

            // If the user is logged in, attach their UserId to the response
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    userResponse.UserId = user.Id;
                }
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
                    var existingResponse = _context.UserResponses.FirstOrDefault(r => r.UserId == user.Id);
                    if (existingResponse != null)
                    {
                        // Update user's stored response (if needed)
                        existingResponse.FullName = model.FullName;
                        existingResponse.DateOfBirth = model.DateOfBirth;
                        existingResponse.Citizenship = model.Citizenship;
                        existingResponse.AnnualIncome = model.AnnualIncome;
                        existingResponse.HasDisability = model.HasDisability;
                        existingResponse.IsBusiness = model.IsBusiness;
                        existingResponse.BusinessName = model.BusinessName;
                        existingResponse.BusinessStructure = model.BusinessStructure;
                        existingResponse.BusinessRevenue = model.BusinessRevenue ?? 0;
                        existingResponse.IsNonProfit = model.IsNonProfit;
                        existingResponse.CharityNumber = model.CharityNumber;

                        await _context.SaveChangesAsync();
                        return RedirectToAction("Index", "Results", new { id = existingResponse.Id });
                    }

                    model.UserId = user.Id;
                    _context.UserResponses.Add(model);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Results", new { id = model.Id });
                }
            }

            //  This return handles unauthenticated users
            return View(model);
        }

    }
}
