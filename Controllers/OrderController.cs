using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using eCommerce.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Controllers
{
    public class OrderController : Controller
    {


        private MyContext _context;
 
        public OrderController(MyContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("orders")]
        public IActionResult Index()
        {
            ViewBag.Customers = _context.Customers.ToList();
            ViewBag.Products = _context.Products.ToList();
            ViewBag.Orders = _context.Orders.Include(order => order.Customer)
                                            .Include(order => order.Product).ToList();
            
            return View();
        }

        [HttpPost]
        [Route("orders/new")]
        public IActionResult New(OrderViewModel order)
        {
            if(ModelState.IsValid)
            {
                Order NewOrder = new Order
                {
                    CustomerId = order.CustomerId,
                    ProductId = order.ProductId,
                    Quantity = order.Quantity,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                _context.Orders.Add(NewOrder);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    

    }
}