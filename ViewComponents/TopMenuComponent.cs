using WebProject.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ETUDDO.ViewComponents
{
    public class TopMenuComponent : ViewComponent
    {

        private readonly ETURContext db;

        public TopMenuComponent(ETURContext context)
        {
            db = context;
        }

        public IViewComponentResult Invoke()
        {
            var menus = db.TopMenu.Where(a => a.IsActive && a.Language == "tr-TR").OrderBy(a => a.Queue);
            return View("TopMenu", menus);
        }

    }
}
