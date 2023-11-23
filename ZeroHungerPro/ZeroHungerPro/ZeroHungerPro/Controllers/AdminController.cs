using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHungerPro.DTO;
using ZeroHungerPro.EF;

namespace ZeroHungerPro.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        //-----Restaurant to RestaurantDTO-----//
        EmployeeDTO convertUser(Employee s)
        {
            return new EmployeeDTO()
            {
                ID = s.ID,
                Name = s.Name,
                Email = s.Email,
                Password = s.Password,
                DOB=s.DOB,
                Phone = s.Phone,
                Address = s.Address,

            };
        }
        //-----StudentDTO to Student-----//
        Employee convertUser(EmployeeDTO s)
        {
            return new Employee()
            {
                ID = s.ID,
                Name = s.Name,
                Email = s.Email,
                Password = s.Password,
                DOB = s.DOB,
                Phone = s.Phone,
                Address = s.Address,
            };
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(EmployeeDTO k)
        {
            if (ModelState.IsValid)
            {
                var db = new ZeroHungerProEntities();
                db.Employees.Add(convertUser(k));
                db.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }
            return View(k);
        }

        public ActionResult ViewEmployee()
        {
            var db = new ZeroHungerProEntities(); 
            var data = db.Employees.ToList();
            return View(data);
        }
        public ActionResult EmployeeDelete(Employee i)
        {
            var db = new ZeroHungerProEntities();
            var ex = db.Employees.Find(i.ID);
            db.Employees.Remove(ex);
            db.SaveChanges();
            return RedirectToAction("ViewEmployee", "Admin");
        }
        public ActionResult ViewRestaurant()
        {
            var db = new ZeroHungerProEntities();
            var data = db.Restaurants.ToList();
            return View(data);
        }
        public ActionResult RestaurantDelete(Restaurant i)
        {
            var db = new ZeroHungerProEntities();
            var exx = db.Restaurants.Find(i.ID);
            db.Restaurants.Remove(exx);
            db.SaveChanges();
            return RedirectToAction("ViewRestaurant", "Admin");
        }
        public ActionResult ViewRequest()
        { 
            var db = new ZeroHungerProEntities();
            var data = db.FoodCollections.ToList();
            ViewBag.FoodDonation = db.Employees.ToList();
            return View(data); 
        }
    }
}