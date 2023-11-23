using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHungerPro.DTO;
using ZeroHungerPro.EF;

namespace ZeroHungerPro.Controllers
{
    public class HomeController : Controller
    {
        //-----Restaurant to RestaurantDTO-----//
        RestaurantDTO convertUser(Restaurant s)
        {
            return new RestaurantDTO()
            {
                ID = s.ID,
                Name = s.Name,
                Email = s.Email,
                Password = s.Password,
                Address = s.Address,
                Phone = s.Phone,
            };
        }
        //-----StudentDTO to Student-----//
        Restaurant convertUser(RestaurantDTO s)
        {
            return new Restaurant()
            {
                ID = s.ID,
                Name = s.Name,
                Email = s.Email,
                Password = s.Password,
                Address = s.Address,
                Phone = s.Phone,
            };
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(Restaurant x)
        {
            var db = new ZeroHungerProEntities();
            var email = db.Restaurants.FirstOrDefault(Email => Email.Email == x.Email && Email.Password == x.Password);
            var email1 = db.Employees.FirstOrDefault(Email => Email.Email == x.Email && Email.Password == x.Password);
            var email2 = db.Admins.FirstOrDefault(Email => Email.Email == x.Email && Email.Password == x.Password);

            if (email != null)
            {
                Session["Email"] = x.Email;
                return RedirectToAction("Index", "Restaurant");
            }
            else if (email1 != null)
            {
                Session["Email"] = x.Email;
                return RedirectToAction("Index", "Employee");
            }
            else if (email2 != null)
            {
                Session["Email"] = x.Email;
                return RedirectToAction("Index", "Admin");

            }
            return RedirectToAction("SignIn", "Home");
        }
        [HttpGet]
        public ActionResult SignUp()
        {

            return View();
        }
        [HttpPost]
        public ActionResult SignUp(RestaurantDTO k)
        {
            if (ModelState.IsValid)
            {
                var db = new ZeroHungerProEntities(); 
                db.Restaurants.Add(convertUser(k));
                db.SaveChanges();
                return RedirectToAction("SignIn");
            }
            return View(k);
        }

    }
    
}