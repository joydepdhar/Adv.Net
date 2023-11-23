using OnlineShopManagement.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopManagement.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Product()
        {
            var db = new OnlineShopManagementEntities();
            var data = db.Products.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult CreateProduct()
        {
            var db = new OnlineShopManagementEntities(); ;
            ViewBag.Catagorys = db.Catagorys.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(Product p)
        {
            var db = new OnlineShopManagementEntities(); ;
            db.Products.Add(p);
            db.SaveChanges();
            return RedirectToAction("Product");
        }
        public ActionResult DeleteProduct(int id)
        {
            var db = new OnlineShopManagementEntities();
            var data = db.Products.Find(id);
            db.Products.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Product");
        }
        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            var db = new OnlineShopManagementEntities(); ;
            ViewBag.Catagorys = db.Catagorys.ToList();
            var data = (from p in db.Products
                        where p.ID == id
                        select p).SingleOrDefault();
            return View(data);
        }

        [HttpPost]
        public ActionResult EditProduct(Product p)
        {
            var db = new OnlineShopManagementEntities(); 
            var data = db.Products.Find(p.ID);
            data.Name = p.Name;
            data.Price = p.Price;
            data.Catagory_ID = p.Catagory_ID;
            data.Quantity = p.Quantity;
            db.SaveChanges();
            return RedirectToAction("Product");

        }
    }
}