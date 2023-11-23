using OnlineShopManagement.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopManagement.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Product()
        {
            var db = new OnlineShopManagementEntities();
            var data = db.Products.ToList();

            return View(data);
        }

        public ActionResult Category()
        {
            var db = new OnlineShopManagementEntities(); ;
            var data = db.Catagorys.ToList();

            return View(data);
        }

        #region

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

        public ActionResult DeleteProduct(int ID)
        {
            var db = new OnlineShopManagementEntities();;
            var data = db.Products.Find(ID);
            db.Products.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Product");
        }




        [HttpGet]
        public ActionResult EditProduct(int ID)
        {
            var db = new OnlineShopManagementEntities(); ;
            ViewBag.Catagorys = db.Catagorys.ToList();
            var data = (from p in db.Products
                        where p.ID == ID
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
            db.SaveChanges();
            return RedirectToAction("Product");

        }
        #endregion

        [HttpGet]
        public ActionResult CreateCategory()
        {
            var db = new OnlineShopManagementEntities();
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(Catagory c)
        {

            var db = new OnlineShopManagementEntities();
            db.Catagorys.Add(c);
            db.SaveChanges();
            return RedirectToAction("Category");


        }

        public ActionResult DeleteCategory(int ID)
        {
            var db = new OnlineShopManagementEntities();
            var data = db.Catagorys.Find(ID);
            db.Catagorys.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Category");
        }

        public ActionResult EditCategory(int ID)
        {
            var db = new OnlineShopManagementEntities();
            var data = (from c in db.Catagorys where c.ID == ID select c).SingleOrDefault();
            return View(data);
        }

        [HttpPost]
        public ActionResult EditCategory(Catagory c)
        {
            var db = new OnlineShopManagementEntities();
            var data = db.Catagorys.Find(c.ID);
            data.Name = c.Name;
            db.SaveChanges();
            return RedirectToAction("Category");

        }
    }
}