using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MessageRobot.Models;
using Twilio;

namespace MessageRobot.Controllers
{
    public class NoticesController : Controller
    {
        //
        // GET: /Messages/

        MessageRobotDb _db = new MessageRobotDb();

        public ActionResult Index([Bind(Prefix = "id")] int contactId)
        {
            var contact = _db.Contacts.Find(contactId);
            if (contact != null)
            {
                return View(contact);
            }
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult Create(int contactId)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _db.Notices.Find(id);
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var message = _db.Notices.Find(id);
            _db.Notices.Remove(message);
            _db.SaveChanges();
            return RedirectToAction("Index", new { id = message.ContactId });
        }

        [HttpPost]
        public ActionResult Create(Notice notice)
        {
            if (ModelState.IsValid)
            {
                _db.Notices.Add(notice);
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = notice.ContactId });
            }
            return View(notice);
        }

        [HttpPost]
        public ActionResult Edit(Notice notice)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(notice).State = System.Data.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = notice.ContactId });
            }
            return View(notice);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }

        public void SendSms()
        {
            var smsNumber = "+19492099893";
            var smsText = "2nd notice from the new reminder application.";
            string twilioPhoneNumber = "+17144595176";

            string AccountSid = "AC36241612702f6674342ac88458c378c8";
            string AuthToken = "5c81d4a1aec022545daf8da956a6b729";

            var twilio = new TwilioRestClient(AccountSid, AuthToken);
            var notice = twilio.SendSmsMessage(twilioPhoneNumber, smsNumber, smsText, "");
        }

    }
}
