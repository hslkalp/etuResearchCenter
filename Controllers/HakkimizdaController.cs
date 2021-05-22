using Microsoft.AspNetCore.Mvc;
using WebProject.Data;

namespace WebProject.Controllers
{
    public class HakkimizdaController : Controller
    {
        private readonly ETURContext db;

        public HakkimizdaController(ETURContext context)
        {
            db = context;
        }

        public IActionResult yonetim()
        {
            var management = db.Management;
            return View(management);
        }


    }
}