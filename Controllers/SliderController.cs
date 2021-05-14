using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebProject.Data;

namespace WebProject.Controllers
{
    public class SliderController : Controller
    {
        private readonly ETURContext db;

        public SliderController(ETURContext context)
        {
            db = context;
        }

        [HttpPost]
        public JsonResult GetSlider()
        {
            try
            {
                var sliders = db.Slider.Where(a => a.IsActive).OrderBy(a => a.Queue);
                return Json(new { sliderData = sliders, Result = true, Message = "Success!" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, Message = ex.Message });
            }


        }

    }
}