using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebProject.Data;

namespace WebProject.Controllers
{
    public class AboutUsController : Controller
    {
        private readonly ETURContext db;

        public AboutUsController(ETURContext context)
        {
            db = context;
        }

        public IActionResult management()
        {
            var management = db.Management.Where(management => management.IsStaff == true).OrderBy(management => management.Queue);
            return View(management);
        }

        [Route("/aboutUs/misyon-ve-vizyon")]
        public IActionResult vision()
        {
            return View();
        }


    }
}