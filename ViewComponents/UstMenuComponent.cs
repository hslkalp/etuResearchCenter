using WebProject.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ETUDDO.ViewComponents
{
    public class UstMenuComponent : ViewComponent
    {

        private readonly ETURContext db;

        public UstMenuComponent(ETURContext context)
        {
            db = context;
        }

        public IViewComponentResult Invoke()
        {
            var menuler = db.UstMenu.Where(a => a.AktifMi && a.Language == "tr-TR").OrderBy(a => a.Sira);
            return View("UstMenu", menuler);
        }

    }
}
