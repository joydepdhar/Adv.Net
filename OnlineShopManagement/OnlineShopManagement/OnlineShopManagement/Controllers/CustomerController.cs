using OnlineShopManagement.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopManagement.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult ProductList()
        {

            var db = new OnlineShopManagementEntities();
            var data = db.Products.ToList();
            return View(data);
        }

        public ActionResult AddToCart(int ID)
        {
            var db = new OnlineShopManagementEntities();
            var data = (from p in db.Products
                        where p.ID == ID
                        select p).SingleOrDefault();
            Cart cart = new Cart
            {
                CustomerID = Convert.ToInt32(Session["userid"]),
                ProductID = data.ID,
                Quantity = 1,
                Price = data.Price,


            };
            db.Carts.Add(cart);
            db.SaveChanges();
            return RedirectToAction("ProductList");
            // return View(cart);
        }
        public ActionResult Cart()
        {
            var id = Convert.ToInt32(Session["userid"]);
            var db = new OnlineShopManagementEntities();
            var data = (from c in db.Carts
                        where c.CustomerID == id
                        select c).ToList();
            return View(data);
        }

        public ActionResult ClearCart()
        {
            var id = Convert.ToInt32(Session["userid"]);
            var db = new OnlineShopManagementEntities();
            var data = (from c in db.Carts
                        where c.CustomerID == id
                        select c).ToList();
            db.Carts.RemoveRange(data);
            db.SaveChanges();
            return RedirectToAction("Cart");
        }

        public ActionResult DeleteCart(int id)
        {
            var db = new OnlineShopManagementEntities();
            var data = db.Carts.Find(id);
            db.Carts.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Cart");
        }

        public ActionResult PlaceOrder()
        {
            var id = Convert.ToInt32(Session["userid"]);
            var db = new OnlineShopManagementEntities();
            var data = (from c in db.Carts
                        where c.CustomerID == id
                        select c).ToList();
            foreach (var c in data)
            {
                Order order = new Order
                {
                    CustomerID = Convert.ToInt32(Session["userid"]),
                    ProductID = c.ProductID,
                    Quantity = 1,
                    Price = c.Price,
                    Status = "Ordered"
                };
                db.Orders.Add(order);
            }
            db.SaveChanges();
            ClearCart();

            return RedirectToAction("MyOrder");
            // return View(cart);
        }

        public ActionResult MyOrder()
        {
            var id = Convert.ToInt32(Session["userid"]);
            var db = new OnlineShopManagementEntities();
            var data = (from c in db.Orders
                        where c.CustomerID == id
                        select c).ToList();
            return View(data);
        }

        public ActionResult CancelOrder()
        {
            var id = Convert.ToInt32(Session["userid"]);
            var db = new OnlineShopManagementEntities();
            var data = (from c in db.Orders
                        where c.CustomerID == id
                        select c).ToList();
            db.Orders.RemoveRange(data);
            db.SaveChanges();
            return RedirectToAction("MyOrder");
        }



    }
}