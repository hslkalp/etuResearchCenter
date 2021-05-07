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
            var menuler = db.TopMenu.Where(a => a.AktifMi && a.Language == "tr-TR").OrderBy(a => a.Sira);
            return View("TopMenu", menuler);
        }

    }
}
