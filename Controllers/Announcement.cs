using Microsoft.AspNetCore.Mvc;
using WebProject.Data;

namespace WebProject.Controllers
{
    public class Announcement : Controller
    {
        private readonly ETURContext db;

        public Announcement(ETURContext context)
        {
            db = context;
        }
    }
}