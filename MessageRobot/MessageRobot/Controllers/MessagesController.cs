using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MessageRobot.Models;

namespace MessageRobot.Controllers
{
    public class MessagesController : Controller
    {
        //
        // GET: /Messages/

        MessageRobotDb _db = new MessageRobotDb();

        public ActionResult Index( [Bind(Prefix="id")] int contactId)
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
            var model = _db.Messages.Find(id);
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var message = _db.Messages.Find(id);
            _db.Messages.Remove(message);
            _db.SaveChanges();
            return RedirectToAction("Index", new { id = message.ContactId });
        }

        [HttpPost]
        public ActionResult Create(Message message)
        {
            if (ModelState.IsValid)
            {
                _db.Messages.Add(message);
                _db.SaveChanges();
                return RedirectToAction("Index", new {id = message.ContactId});
            }
            return View(message);
        }

        [HttpPost]
        public ActionResult Edit(Message message)
        {
            if (ModelState.IsValid)
            {
                _db.Messages.Add(message);
                _db.Entry(message).State = System.Data.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = message.ContactId });
            }
            return View(message);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }

    }
}
