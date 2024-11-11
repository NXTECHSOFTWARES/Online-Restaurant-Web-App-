using Newtonsoft.Json;
using NewProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace NewProject.Controllers
{
   
    public class AdminController : Controller
    {
        // GET: Admin

        private OnlineRestuarantContext db = new OnlineRestuarantContext();

        public List<SelectListItem> GetCategory()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var cat = db.Categories.ToList();
            foreach (var item in cat)
            {
                list.Add(new SelectListItem { Value = item.CategoryId.ToString(), Text = item.CategoryName });
            }
            return list;
        }
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Categories(Tbl_Category category)
        {
            var allcategories = db.Categories.ToList();

            return View(allcategories);
        }
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Tbl_Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("Categories");
        }

        public ActionResult UpdateCategory(int categoryId)
        {
            Tbl_Category cd;
            if (categoryId != null)
            {
                cd = JsonConvert.DeserializeObject<Tbl_Category>(JsonConvert.SerializeObject(db.Categories.Find(categoryId)));
            }
            else
            {
                cd = new Tbl_Category();
            }

            return View("UpdateCategory", cd);

        }

        [HttpPost]
        public ActionResult UpdateCategory(Tbl_Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        public ActionResult RemoveCategory(int catId)
        {
            var cat = db.Categories.Find(catId);
            db.Categories.Remove(cat);
            db.SaveChanges();
            return RedirectToAction("Categories");
        }

        public ActionResult CategoryEdit(int catId)
        {
            var cat = db.Categories.Find(catId);

            return View(cat);
        }

        [HttpPost]
        public ActionResult CategoryEdit(Tbl_Category tbl)
        {
            db.Categories.Add(tbl);
            db.SaveChanges();
            return RedirectToAction("Categories");
        }
        public ActionResult Product()
        {
            return View(db.Products.ToList());
        }

        public ActionResult ProductEdit(int productId)
        {
            ViewBag.CategoryList = GetCategory();
            return View(db.Products.Find(productId));
        }

        [HttpPost]
        public ActionResult ProductEdit(Tbl_Product tbl, HttpPostedFileBase file)
        {
            string pic = null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/Uploaded_Images/"), pic);
                // file is uploaded
                file.SaveAs(path);
            }
            tbl.ProductImage = file != null ? pic : tbl.ProductImage;

            db.Products.Add(tbl);
            db.SaveChanges();
            return RedirectToAction("Product");
        }

        public ActionResult ProductAdd()
        {
            ViewBag.CategoryList = GetCategory();
            return View();
        }
        [HttpPost]
        public ActionResult ProductAdd(Tbl_Product tbl, HttpPostedFileBase file)
        {
            string pic = null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/Uploaded_Images/"), pic);
                // file is uploaded
                file.SaveAs(path);
            }
            tbl.ProductImage = pic;
            db.Products.Add(tbl);
            db.SaveChanges();
            return RedirectToAction("Product");
        }

        public ActionResult ProductRemove(int productId)
        {

            var item = db.Products.Find(productId);
            db.Products.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Product");
        }
    }
}