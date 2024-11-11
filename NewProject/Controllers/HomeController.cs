using Newtonsoft.Json;
using NewProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Validation;

namespace NewProject.Controllers
{
    public class HomeController : Controller
    {
        OnlineRestuarantContext ctx = new OnlineRestuarantContext();

        public ActionResult Index() {
            ViewBag.ListOfProducts = ctx.Products.ToList();
            return View(ViewBag.ListOfProducts);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult MyCart()
        {
            return View();
        }

        public ActionResult CheckoutDetails()
        {
            return View();
        }
        public ActionResult DecreaseQty(int productId)
        {
            if (Session["cart"] != null)
            {
                List<Cart> cart = (List<Cart>)Session["cart"];
                var product = ctx.Products.Find(productId);
                foreach (var item in cart)
                {
                    if (item.Product.ProductId == productId)
                    {
                        int prevQty = item.Quantity;
                        if (prevQty > 0)
                        {
                            cart.Remove(item);
                            cart.Add(new Cart()
                            {
                                Product = product,
                                Quantity = prevQty - 1
                            });
                        }
                        break;
                    }
                }
                Session["cart"] = cart;
            }
            return Redirect("MyCart");
        }
        public ActionResult AddToCart(int productId, string url)
        {
            if (Session["cart"] == null)
            {
                List<Cart> cart = new List<Cart>();
                var product = ctx.Products.Find(productId);
                cart.Add(new Cart()
                {
                    Product = product,
                    Quantity = 1,
                    numOfItems = 1
                });
                Session["cart"] = cart;


                Tbl_Product increment_product = ctx.Products.SingleOrDefault(p => p.ProductId == productId);
                increment_product.numOfPurchase++;
                ctx.SaveChanges();
            }
            else
            {
                List<Cart> cart = (List<Cart>)Session["cart"];
                var count = cart.Count();
                var product = ctx.Products.Find(productId);
                for (int i = 0; i < count; i++)
                {
                    if (cart[i].Product.ProductId == productId)
                    {
                        int prevQty = cart[i].Quantity;

                        cart.Remove(cart[i]);
                        cart.Add(new Cart()
                        {
                            Product = product,
                            Quantity = prevQty + 1,

                        });
                        break;
                    }
                    else
                    {
                        var prd = cart.Where(x => x.Product.ProductId == productId).SingleOrDefault();
                        if (prd == null)
                        {

                            cart.Add(new Cart()
                            {
                                Product = product,
                                Quantity = 1,

                            });
                        }
                    }
                }

                Session["cart"] = cart;


                Tbl_Product increment_product = ctx.Products.SingleOrDefault(p => p.ProductId == productId);
                increment_product.numOfPurchase++;

                try
                {
                    ctx.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    Console.WriteLine(e);
                }
            }

            return Redirect(url);
        }
        public ActionResult RemoveFromCart(int productId)
        {
            List<Cart> cart = (List<Cart>)Session["cart"];
            foreach (var item in cart)
            {
                if (item.Product.ProductId == productId)
                {
                    cart.Remove(item);
                    break;
                }
            }
            Session["cart"] = cart;
            return Redirect("Index");
        }

        public ActionResult RemoveCart(int productId)
        {
            List<Cart> cart = (List<Cart>)Session["cart"];
            var count = cart.Count();            
            for (int i = 0; i < count; i++)
            {
                if (cart[i].Product.ProductId == productId)
                {
                    cart.Remove(cart[i]);
                    break;
                }
            }

            Session["cart"] = cart;
            return RedirectToAction("MyCart", "Home");
        }
    }
}