using Microsoft.AspNetCore.Mvc;

namespace Company.PL.Controllers
{
    public class AccountController : Controller
    {
        // SignUp

        [HttpGet] // /Account/SignUp
        public IActionResult SignUp()
        {
            return View();
        }
    }
}
