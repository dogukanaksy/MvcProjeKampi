using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var headingvalues=hm.GetList();
            return View(headingvalues);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList() 
                                                  select new SelectListItem
                                                  {
                                                        Text=x.CategoryName,
                                                        Value=x.CategoryID.ToString()
                                                  }).ToList();

            List<SelectListItem> valueWriter = (from x in wm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName,
                                                    Value = x.WriterID.ToString()
                                                }).ToList();

            ViewBag.vlc = valueCategory;
            ViewBag.vlw = valueWriter;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate =DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAdd(p);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();

            ViewBag.vlc = valueCategory;
            var HeadingValue = hm.GetByID(id);
            return View(HeadingValue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            //p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingUpdate(p);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteHeading(int id)
        {
            var headingValue = hm.GetByID(id);
            hm.HeadingDelete(headingValue);

            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HeadingActive(int id)
        {
            var headingValue = hm.GetByID(id);
            headingValue.HeadingStatus = false;
            hm.HeadingActive(headingValue);

            return RedirectToAction("Index");
        }

    }
}