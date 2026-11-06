using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class IstatistikController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        Context context = new Context();
        public ActionResult Istatistik()
        {
            var categoryCount = cm.GetList().Count();
            ViewBag.CategoryCount = categoryCount;
            var yazilimBaslikSayisi = context.Headings.Count(x => x.Category.CategoryName == "Yazılım");
            ViewBag.YazilimBaslikSayisi = yazilimBaslikSayisi; 
            
            var yazarAdindaA = context.Writers.Count(x => x.WriterName.Contains("a"));
            ViewBag.YazarAdindaA = yazarAdindaA;

            var enFazlaBaslikKategori = context.Headings.GroupBy(x => x.CategoryID)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();
            ViewBag.EnFazlaBaslikKategori = context.Categories.FirstOrDefault(c => c.CategoryID == enFazlaBaslikKategori)?.CategoryName;

            var aktifKategoriSayisi = context.Categories.Count(x => x.CategoryStatus == true);
            var pasifKategoriSayisi = context.Categories.Count(x => x.CategoryStatus == false);
            var kategoriDurumFarki = aktifKategoriSayisi - pasifKategoriSayisi;
            ViewBag.kategoriDurumFarki = kategoriDurumFarki;

            return View();
        }
    }
}