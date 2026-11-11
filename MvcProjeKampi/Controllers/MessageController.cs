using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
        MessageValidator messagevalidator = new MessageValidator();
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
        public ActionResult GetSendboxMessageDetails(int id)
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
        [ValidateAntiForgeryToken]
        public ActionResult MessageAdd(
            [Bind(Include = "ReceiverMail,Subject")] Message p)
        {
            p.MessageContent = Request.Unvalidated.Form["MessageContent"];

            var results = messagevalidator.Validate(p);
            foreach (var error in results.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            if (!ModelState.IsValid)
            {
                return View("NewMessage", p);
            }

            p.SenderMail = "admin@gmail.com";
            p.MessageDate = DateTime.Now;
            p.IsDraft = false;

            mm.MessageAdd(p);
            return RedirectToAction("Sendbox");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveDraft(
            [Bind(Include = "ReceiverMail,Subject")] Message p)
        {
            p.MessageContent = Request.Unvalidated.Form["MessageContent"];

            if (!ModelState.IsValid)
            {
                return View("NewMessage", p);
            }

            p.SenderMail = "admin@gmail.com";
            p.MessageDate = DateTime.Now;
            p.IsDraft = true;

            mm.MessageAdd(p);
            return RedirectToAction("Drafts");
        }

        [HttpGet]
        public ActionResult Drafts()
        {
            var taslaklar = mm.GetListDrafts();
            return View(taslaklar);
        }

    }
}