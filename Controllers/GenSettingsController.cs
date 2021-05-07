using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebProject.Data;

namespace WebProject.Controllers
{
    public class GenSettingsController : Controller
    {
        private readonly ETURContext db;

        public GenSettingsController(ETURContext context)
        {
            db = context;
        }

        [HttpPost]

        public JsonResult GetSettings()
        {
            try
            {
                var settings = db.GenSetting;
                return Json(new { settingsData = settings, Result = true, Message = "Success!" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, Message = ex.Message });
            }
        }
    }



}