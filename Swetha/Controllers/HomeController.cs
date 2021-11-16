using DataLibrary.BuisnessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Swetha.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Swetha.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private IConfiguration Configuration;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

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

        public ActionResult SignUp()
        {
            ViewBag.Message = "Player Sign Up.";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(Player model)
        {
            string conString = this.Configuration.GetConnectionString("MVCDemoDB");

            if (ModelState.IsValid)
            {
                int recordCreated = PlayerProcessor.CreatePlayer(model.PlayerId,
                         model.FirstName, model.LastName, model.EmailAddress, conString);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult ViewPlayers()
        {
            string conString = this.Configuration.GetConnectionString("MVCDemoDB");
            ViewBag.Message = "Players List ...";

            var data = PlayerProcessor.LoadPayers(conString);

            List<Player> players = new List<Player>();

            foreach (var row in data)
            {
                players.Add(new Player
                {
                    PlayerId = row.PlayerId,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    EmailAddress = row.EmailAddress
                });
            }
            return View(players);
           
        }
    }
}
