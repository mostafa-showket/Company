using Company.PL.ViewModels;
using Company.PL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;

namespace Company.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly IScopedService scope01;
        //private readonly IScopedService scope02;
        //private readonly ITransientService transient01;
        //private readonly ITransientService transient02;
        //private readonly ISingletonService singleton01;
        //private readonly ISingletonService singleton02;

        public HomeController(ILogger<HomeController> logger
        )
        {
            _logger = logger;
        }

        //public string TestLifeTime() 
        //{
        //    StringBuilder builder = new StringBuilder();
        //    builder.Append($"scope01: {scope01.GetGuid()}\n");
        //    builder.Append($"scope02: {scope02.GetGuid()}\n\n");
        //    builder.Append($"transient01: {transient01.GetGuid()}\n");
        //    builder.Append($"transient02: {transient02.GetGuid()}\n\n");
        //    builder.Append($"singleton01: {singleton01.GetGuid()}\n");
        //    builder.Append($"singleton02: {singleton02.GetGuid()}\n");

        //    return builder.ToString();
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
