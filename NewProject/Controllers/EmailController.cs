 using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace NewProject.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult SendEmail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendEmail(string userMail)
        {
            string subject = "Online Food Order";
            string body = "Thank you for choosing our restuarant";

            WebMail.Send(userMail, subject, body, null, null, null, true, null, null, null, null, null, null);
            ViewBag.success = "Email was sent successfully";

            return View();
        }

    }
}
