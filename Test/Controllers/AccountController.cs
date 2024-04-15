using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Test.Models;

namespace Test.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IConfiguration _configuration;

        public AccountController(ILogger<AccountController> logger,IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
       
        public IActionResult Login()
        {
            return View();
        }

       

        // POST: Account/Login
        [HttpPost("login")]
        public ActionResult Login(string username, string password)
        {
            // Retrieve the expected username and password from configuration
            string expectedUsername = _configuration["Authentication:Username"];
            string expectedPassword = _configuration["Authentication:Password"];

            // Check if the provided username and password match the expected values
            if (username == expectedUsername && password == expectedPassword)
            {
                // Authentication successful
                return RedirectToAction("Index", "Home"); // Redirect to the dashboard page
            }
            else
            {
                // Authentication failed
                ViewBag.Error = "Invalid credentials";
                return View();
            }
        }
    }
}
