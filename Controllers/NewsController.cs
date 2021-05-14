using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebProject.Data;

namespace WebProject.Controllers
{
    public class NewsController : Controller
    {
        private readonly ETURContext db;

        public NewsController(ETURContext context)
        {
            db = context;
        }

        [HttpPost]

        public JsonResult GetNews()
        {
            try
            {
                var news = db.News;
                return Json(new { newsData = news, Result = true, Message = "Success!" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, Message = ex.Message });
            }
        }

        public IActionResult NewsDetails(int id)
        {
            var news = db.News.FirstOrDefault(a => a.Id == id);
            return View(news);
        }
    }
}