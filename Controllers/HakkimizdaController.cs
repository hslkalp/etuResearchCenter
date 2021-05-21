using Microsoft.AspNetCore.Mvc;

namespace WebProject.Controllers
{
    public class HakkimizdaController : Controller
    {
        public IActionResult yonetim()
        {
            return View();
        }

        public IActionResult misyonVeVizyon()
        {
            return View();
        }
    }
}