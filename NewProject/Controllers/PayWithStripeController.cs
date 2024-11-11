using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewProject.Controllers
{
    public class PayWithStripeController : Controller
    {
        // GET: PayWithStripe
        public ActionResult CheckoutDetails()
        {
            return View();
        }
    }
}