using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UpskillWebApp.Models;

namespace UpskillWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        SignInManager<IdentityUser> _SignInManager;
        UserManager<IdentityUser> _UserManager;
        public HomeController(ILogger<HomeController> logger,
            SignInManager<IdentityUser> SignInManager,
            UserManager<IdentityUser> UserManager
            )
        {
            _logger = logger;
            _SignInManager = SignInManager;
            _UserManager = UserManager;
        }
        
        public IActionResult Index()
        {
          var userId =  _UserManager.GetUserId(User);
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
