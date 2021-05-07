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
        public JsonResult GetirSlider()
        {
            try
            {
                var sliders = db.Slider.Where(a => a.AktifMi).OrderBy(a => a.Sira);
                return Json(new { gelendata = sliders, Result = true, Message = "Başarılı" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, Message = ex.Message });
            }


        }

    }
}