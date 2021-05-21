using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebProject.Data;

namespace WebProject.ViewComponents
{
    public class FooterMenuComponent : ViewComponent
    {
        private readonly ETURContext db;

        public FooterMenuComponent(ETURContext context)
        {
            db = context;
        }

        public IViewComponentResult Invoke()
        {
            var menus = db.FooterMenu.Where(a => a.IsActive && a.Language == "tr-TR").OrderBy(a => a.Queue);
            return View("FooterMenu", menus);
        }
    }
}