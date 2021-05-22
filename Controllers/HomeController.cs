﻿using Microsoft.AspNetCore.Mvc;
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

        public IActionResult hakkimizda()
        {
            return View();
        }

        public IActionResult iletisim()
        {
            return View();
        }

        public IActionResult altyapi()
        {
            var substructure = db.Substructure;
            return View(substructure);
        }
        public IActionResult altyapiDetay(int id)
        {
            var substructures = db.Substructure.FirstOrDefault(a => a.Id == id);
            return View(substructures);
        }

        public IActionResult makaleler()
        {
            return View();
        }

        public IActionResult bildiriler()
        {
            return View();
        }

        public IActionResult projeler()
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
