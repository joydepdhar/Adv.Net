using OnlineShopManagement.DTO;
using OnlineShopManagement.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopManagement.Controllers
{
    public class AdminController : Controller
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
                Role = s.Role,
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
        // GET: Admin
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(UserDTO x)
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
        
    public ActionResult DashBoard()
        {
            return View();
        }
        public ActionResult Order()
        {
            var db = new OnlineShopManagementEntities();
            var data = db.Orders.ToList();
            return View(data);
        }
        public ActionResult ManageOrder(int id, string status)
        {
            var db = new OnlineShopManagementEntities();
            var data = (from p in db.Orders
                        where p.ID == id
                        select p).SingleOrDefault();
            if (status == "Process")
            {
                data.Status = "Processing";
            }
            else if (status == "Decline")
            {
                data.Status = "Declined";
            }

            db.SaveChanges();

            return RedirectToAction("Orders");
        }
    }
}