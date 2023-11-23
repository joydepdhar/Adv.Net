using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHungerPro.DTO;
using ZeroHungerPro.EF;

namespace ZeroHungerPro.Controllers
{
    public class RestaurantController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpGet]
        public ActionResult AddFoodRequest()
        {
            var email = Session["Email"];
            var db = new ZeroHungerProEntities();
            var data = db.Restaurants.Where(Email=>Email.Email==email).First();
            return View(data);
        }
        [HttpPost]
        public ActionResult AddFoodRequest(FoodCollection x)
        {
            var db = new ZeroHungerProEntities();
            db.FoodCollections.Add(x);
            db.SaveChanges();
            return RedirectToAction("ViewRequest", "Restaurant");
        }
        public ActionResult ViewRequest()
        {
            var db = new ZeroHungerProEntities();
            var data =db.FoodCollections.ToList();
            ViewBag.Employeelist = db.Employees.ToList();
            return View(data);
        }
        public ActionResult DeleteRequest(int ID)
        {
            var db = new ZeroHungerProEntities();
            var data = db.FoodCollections.SingleOrDefault(p => p.ID == ID);

            if (data != null && data.EmployeeID == null)
            {
                db.FoodCollections.Remove(data);
                db.SaveChanges();
                return RedirectToAction("FoodDistributionlist", "Employee");
            }

            return RedirectToAction("FoodDistributionlist", "Employee");
        }

    }
}