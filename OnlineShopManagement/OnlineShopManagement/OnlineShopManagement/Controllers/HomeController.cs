using OnlineShopManagement.DTO;
using OnlineShopManagement.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace OnlineShopManagement.Controllers
{
    public class HomeController : Controller
    {
        //-----User to UserDTO-----//
        UserDTO convertUser(User s)
        {
            return new UserDTO()
            {
                ID = s.ID,
                Name = s.Name,
                Email = s.Email,
                Password = s.Password,
                Address = s.Address,
                Phone = s.Phone,
                Role= s.Role,
            };
        }
        //-----UserDTO to User-----//
        User convertUser(UserDTO s)
        {
            return new User()
            {
                ID = s.ID,
                Name = s.Name,
                Email = s.Email,
                Password = s.Password,
                Role = s.Role,
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
        public ActionResult SignIn(User u)
        {
            var db = new OnlineShopManagementEntities();
            var data = (from us in db.Users
                        where us.Email == u.Email && us.Password == u.Password
                        select us).SingleOrDefault();
            if (data != null)
            {
                Session["UserID"] = data.ID;
                Session["UserEmail"] = data.Email;
                Session["UserPassword"] = data.Password;
                Session["UserName"] = data.Name;
                Session["UserRole"] = data.Role;
                Session["UserAddress"] = data.Address;
                Session["UserPhone"] = data.Phone;

                if (Session["UserRole"] != null && Session["UserRole"].ToString() == "admin") { return RedirectToAction("Dashboard", "Admin"); }
                else if (Session["UserRole"] != null && Session["UserRole"].ToString() == "customer") { return RedirectToAction("Dashboard", "Customer"); }
            }
            return View();
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(UserDTO x)
        {
            if (ModelState.IsValid)
            {
                var db = new OnlineShopManagementEntities();
                db.Users.Add(convertUser(x));
                db.SaveChanges();
                return RedirectToAction("SignIn", "Home");
            }
            return View(x);
        }
    }
}