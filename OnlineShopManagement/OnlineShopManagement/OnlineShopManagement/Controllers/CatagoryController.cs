using OnlineShopManagement.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopManagement.Controllers
{
    public class CatagoryController : Controller
    {
        // GET: Catagory
        public ActionResult Catagory()
        {
            var db = new OnlineShopManagementEntities();
            var data= db.Catagorys.ToList();
            return View(data);
        }
        public ActionResult EditCatagory(int ID)
        {
            var db = new OnlineShopManagementEntities();
            var data = (from c in db.Catagorys where c.ID == ID select c).SingleOrDefault();
            return View(data);
        }
        public ActionResult DeleteCategory(int ID)
        {
            var db = new OnlineShopManagementEntities();
            var ex = db.Catagorys.Find(ID);
            db.Catagorys.Remove(ex);
            db.SaveChanges();
            return RedirectToAction("Category");
        }
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
            return RedirectToAction("Catagory");
        }


    }
}