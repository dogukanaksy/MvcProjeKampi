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
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager mm = new MessageManager(new EfMessageDal());
        public ActionResult Inbox()
        {
            var messagelist= mm.GetListInbox();
            return View(messagelist);
        }
        public ActionResult Sendbox()
        {
            var messagelist = mm.GetListSendbox();
            return View(messagelist);
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveDraft(Message p)
        {
            p.SenderMail = "admin@gmail.com";
            p.MessageDate = DateTime.Now;
            p.IsDraft = true;

            mm.MessageAdd(p);

            return RedirectToAction("NewMessage");
        }
        [HttpGet]
        public ActionResult Drafts()
        {
            var taslaklar = mm.GetListDrafts();
            return View(taslaklar);
        }

    }
}