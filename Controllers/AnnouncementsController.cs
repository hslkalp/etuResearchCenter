using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebProject.Data;

namespace WebProject.Controllers
{
    public class Announcements : Controller
    {
        private readonly ETURContext db;

        public Announcements(ETURContext context)
        {
            db = context;
        }
        public IActionResult AnnouncementsDetail(int id)
        {
            var announcement = db.Announcements.FirstOrDefault(a => a.Id == id);
            return View(announcement);
        }
    }
}