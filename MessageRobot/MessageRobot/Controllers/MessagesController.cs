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

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }

    }
}
