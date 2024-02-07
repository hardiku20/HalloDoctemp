using learning1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace learning1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult patientlogin()
        {
            return View();
        }

        public IActionResult patientforgotpass()
        {
            return View();
        }

        public IActionResult patientsite()
        {
            return View();
        }

        public IActionResult patientrequest()
        {
            return View();
        }
        
        public IActionResult familyrequest()
        {
            return View();
        }

        public IActionResult conciergerequest()
        {
            return View();
        }

        public IActionResult businessrequest()
        {
            return View();
        }

        public IActionResult patientsubmitrequest()
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