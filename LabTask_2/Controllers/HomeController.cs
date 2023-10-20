using LabTask_2.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabTask_2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Catagroy()
        {
            //ViewBag.Message = "Your application description page.";
            var db = new OnlineShopEntities();
            var data =db.Catagories.ToList();
            return View(data);
        }
        [HttpPost]
        public ActionResult Catagroy(Catagory c)
        {
            //ViewBag.Message = "Your application description page.";
            var db = new OnlineShopEntities();
           // var data = db.Catagories;
           db.Catagories.Add(c);
            db.SaveChanges();
            return RedirectToAction("Catagroy");
        }
        [HttpGet]
        public ActionResult Product()
        {
            //ViewBag.Message = "Your application description page.";
            var db = new OnlineShopEntities();
            var data = db.Products.ToList();
            ViewBag.Catagories = db.Catagories.ToList();
            return View(data);
        }
        [HttpPost]
        public ActionResult Product(Product c)
        {
            //ViewBag.Message = "Your application description page.";
            var db = new OnlineShopEntities();
            // var data = db.Catagories;
            db.Products.Add(c);
            db.SaveChanges();
            return RedirectToAction("Product");
        }
        //[HttpGet]
        //public ActionResult Customer()
        //{
        //    ViewBag.Message = "Your application description page.";
        //    var db = new OnlineShopEntities();
        //    var data = db.Customers.ToList();
        //    ViewBag.Catagories = db.Catagories.ToList();
        //    return View(data);
        //}
        //[HttpPost]
        //public ActionResult Cusotmer(Customer c)
        //{
        //    ViewBag.Message = "Your application description page.";
        //    var db = new OnlineShopEntities();
        //    var data = db.Catagories;
        //    db.Customers.Add(c);
        //    db.SaveChanges();
        //    return RedirectToAction("Customer");
        //}
        public ActionResult Delete(Catagory i)
        {
            var db = new OnlineShopEntities();
            var ex = db.Catagories.Find(i.ID);
            db.Catagories.Remove(ex);
            db.SaveChanges();
            return RedirectToAction("Catagroy");
        }
        //PDelete
        public ActionResult PDelete(Product a)
        {
            var db = new OnlineShopEntities();
            var ex = db.Products.Find(a.ID);
            db.Products.Remove(ex);
            db.SaveChanges();
            return RedirectToAction("Product");
        }


    }
}