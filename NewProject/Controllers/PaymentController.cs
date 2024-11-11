using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using PayPal.Api;
using NewProject.Models;

namespace NewProject.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult PaymentWithPapal()
        {

            APIContext apicontext = PaypalConfiguration.GetAPIContext();
            try
            {

                string PayerId = Request.Params["PayerID"];
                if (string.IsNullOrEmpty(PayerId) && PayerId!=null)
                {
                    string baseURi = Request.Url.Scheme + "://" + Request.Url.Authority +
                                     "Payment/PaymentWithPapal?";

                    var Guid = Convert.ToString((new Random()).Next(100000000));
                    var createPayment = CreatePayment(apicontext, baseURi + "guid=" + Guid);

                    var links = createPayment.links.GetEnumerator();
                    string paypalRedirectURL = string.Empty;

                    while (links.MoveNext())
                    {
                        Links lnk = links.Current;

                        if (lnk.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            paypalRedirectURL = lnk.href;
                        }
                        Session.Add(Guid, createPayment.id);
                        return Redirect(paypalRedirectURL);

                    }
                }
                else
                {
                    var guid = Request.Params["guid"];
                    var executedPayment = ExecutePayment(apicontext, PayerId, Session[guid] as string);


                    if (executedPayment.ToString().ToLower()!="approved")
                    {
                        return View("FailureView");
                    }

                }
            }
            catch (Exception)
            {
                return View("FailureView");


                //throw;
            }
            sendEmail();
            return View("SuccessView");

        }

        private void sendEmail()
        {
            OnlineRestuarantContext db = new OnlineRestuarantContext();

            //string userMail = db.Customers.Find(c);
            string subject = "Online Food Order";
            string body = "Thank you for choosing our restuarant";

            //WebMail.Send(/*userMail*/, subject, body, null, null, null, true, null, null, null, null, null, null);
        }

        private object ExecutePayment(APIContext apicontext, string payerId, string PaymentId)
        {
           var  paymentExecution= new PaymentExecution() {payer_id = payerId };
            this.payment= new Payment() {id = PaymentId };
            return this.payment.Execute(apicontext, paymentExecution);
        }

        private PayPal.Api.Payment payment;

        private Payment CreatePayment(APIContext apicontext, string redirectURl)
        {

            var ItemLIst = new ItemList() {items = new List<Item>()};

            if (Session["cart"]!="")
            {
                List<Cart> cart = (List<Cart>) (Session["cart"]);
                foreach (var item in cart)
                {
                    ItemLIst.items.Add(new Item()
                    {
                        name = item.Product.ProductName.ToString(),
                        currency = "ZAR",
                        price = item.Product.Price.ToString(),
                        //quantity = item.Product.Quantity.ToString(),
                        sku = "sku"
                    } );
                   

                }


                var payer = new Payer() { payment_method = "paypal" };

                var redirUrl = new RedirectUrls()
                {
                    cancel_url = redirectURl + "&Cancel=true",
                    return_url = redirectURl
                };

                var details = new Details()
                {
                    tax = "1",
                    shipping = "1",
                    subtotal = "1"
                };

                var amount = new Amount()
                {
                    currency = "USD",

                    total = Session["SesTotal"].ToString(),
                    details = details
                };

                var transactionList = new List<Transaction>();
                transactionList.Add(new Transaction()
                {
                    description = "Transaction Description",
                    invoice_number = "#100000",
                    amount = amount,
                    item_list = ItemLIst

                });

                this.payment = new Payment()
                {
                    intent = "sale",
                    payer = payer,
                    transactions = transactionList,
                    redirect_urls = redirUrl
                };
            }



            return this.payment.Create(apicontext);

        }
    }
}