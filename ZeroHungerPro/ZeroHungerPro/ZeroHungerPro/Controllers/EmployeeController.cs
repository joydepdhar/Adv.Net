using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using ZeroHungerPro.EF;

namespace ZeroHungerPro.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewRequest()
        {
            var email = Session["Email"];
            var db = new ZeroHungerProEntities();
            ViewBag.FoodList=db.FoodCollections.ToList();
           // var data = db.Employees.First(e=>e.Email == email);
            var data = db.Employees.Where(Email => Email.Email == email).First();
            //var data = db.Employees.FirstOrDefault(Email => Email.Email == email);
            return View(data);
        }
        public ActionResult Actions(int ID, string Status, int employeeID)
        {
            var db = new ZeroHungerProEntities();
            var data = db.FoodCollections.SingleOrDefault(p => p.ID == ID);
            if (data != null && Status == "Pending")
            {
                data.EmployeeID = employeeID;
                data.Status = "Accepted";
                db.SaveChanges();
                return RedirectToAction("FoodDistributionlist", "Employee");
            }

            return RedirectToAction("ViewRequest", "Employee");
        }

        public ActionResult FoodDistributionlist()
        {
            var email = Session["Email"];
            var db = new ZeroHungerProEntities();
            var data = db.FoodCollections.ToList();
            return View(data);
        }
        //DistributedActions
        public ActionResult DistributedActions(int ID, string Status)
        {
            var db = new ZeroHungerProEntities();
            var data = (from p in db.FoodCollections where p.ID == ID select p).SingleOrDefault();
           // var data = db.FoodCollections.SingleOrDefault(p => p.ID == ID);

            if (data != null && Status == "Accepted")
            {
                data.Status = "Distributed";
                db.SaveChanges();
                return RedirectToAction("FoodDistributionlist", "Employee");
            }

            return RedirectToAction("FoodDistributionlist", "Employee");
        }
        
        

    }
}