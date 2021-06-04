using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Data;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ETURContext db;
        public HomeController(ILogger<HomeController> logger, ETURContext context)
        {
            _logger = logger;
            db = context;
        }

        public IActionResult Index()
        {
            ViewBag.news = db.News;
            ViewBag.announcements = db.Announcements;
            return View();
        }

        public IActionResult aboutUs()
        {
            return View();
        }

        public IActionResult contact()
        {
            var genSettings = db.GenSetting;
            return View(genSettings);
        }

        public IActionResult substructure()
        {
            var substructure = db.Substructure;
            return View(substructure);
        }
        public IActionResult substructureDetail(int id)
        {
            var substructures = db.Substructure.FirstOrDefault(a => a.Id == id);
            
            var labs = db.Labs.Where(labs => labs.SubstructureID == id);
            ViewBag.labs = labs;

            return View(substructures);
        }

        public IActionResult articles()
        {
            var article = db.Articles;
            return View(article);
        }

        public IActionResult notifications()
        {
            var notification = db.Notification;
            return View(notification);
        }

        public IActionResult projects()
        {
            var project = db.Projects;
            return View(project);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
