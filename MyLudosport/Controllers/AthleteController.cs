using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyLudosport.Data;
using MyLudosport.Models;

namespace MyLudosport.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class AthleteController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger _logger;

        public AthleteController(
            UserManager<ApplicationUser> userManager,
            ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        [TempData]
        public string ErrorMessage { get; set; }

        //GET
        public IActionResult Index()
        {
            MyLudosportContext context = HttpContext.RequestServices.GetService(typeof(MyLudosport.Data.MyLudosportContext)) as MyLudosportContext;
            return View(context.Athletes.ToList());
        }
        
        public IActionResult Self()
        {
            MyLudosportContext context = HttpContext.RequestServices.GetService(typeof(MyLudosport.Data.MyLudosportContext)) as MyLudosportContext;
            return View(context.Athletes.Where(a => a.AccountId == User.Identity.Name).First());
        }
    }
}