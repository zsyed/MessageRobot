using System;
using System.Collections.Generic;
using System.Configuration;
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

        public void SendNotice()
        {
            SendSms("+19492099893", "5th notice from the new reminder application.");
        }

        private void SendSms(string smsNumber, string smsText)
        {
            string twilioPhoneNumber = ConfigurationManager.AppSettings["FromPhoneNumber"];

            string AccountSid = ConfigurationManager.AppSettings["AccountSID"];
            string AuthToken = ConfigurationManager.AppSettings["AuthToken"];

            var twilio = new TwilioRestClient(AccountSid, AuthToken);
            var notice = twilio.SendSmsMessage(twilioPhoneNumber, smsNumber, smsText, "");
        }

    }
}
