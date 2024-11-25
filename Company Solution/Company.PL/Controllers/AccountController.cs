using Company.DAL.Models;
using Company.PL.ViewModels.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Company.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        // SignUp

        [HttpGet] // /Account/SignUp
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUpAsync(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.FindByNameAsync(model.UserName);
                    if (user is null)
                    {
                        user = await _userManager.FindByEmailAsync(model.Email);
                        if (user is null)
                        {
                            user = new ApplicationUser()
                            {
                                UserName = model.UserName,
                                FirstName = model.FirstName,
                                LastName = model.LastName,
                                Email = model.Email,
                                IsAgree = model.IsAgree,
                            };
                            var result = await _userManager.CreateAsync(user, model.Password);

                            if (result.Succeeded)
                            {
                                return RedirectToAction("SignIn");
                            }

                            var errorMapping = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
                            {
                                { "username", "UserName" },
                                { "firstname", "FirstName" },
                                { "lastname", "LastName" },
                                { "password", "Password" },
                                { "confirmpassword", "ConfirmPassword" }
                            };

                            foreach (var error in result.Errors)
                            {
                                var key = errorMapping.FirstOrDefault(m => error.Code.ToLower().Contains(m.Key)).Value;
                                if (key != null)
                                {
                                    ModelState.AddModelError(key, error.Description);
                                }
                                else
                                {
                                    ModelState.AddModelError(string.Empty, error.Description);
                                }
                            }
                        }
                        else ModelState.AddModelError("Email", "Email is already in use !!");
                    }
                    else ModelState.AddModelError("UserName", "UserName is already used !!");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(model);
        }
    }
}
