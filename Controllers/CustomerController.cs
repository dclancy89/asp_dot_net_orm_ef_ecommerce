using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using eCommerce.Models;
using System.Linq;

namespace eCommerce.Controllers
{
    public class CustomerController : Controller
    {


        private MyContext _context;
 
        public CustomerController(MyContext context)
        {
            _context = context;
        }


        
        [HttpGet]
        [Route("/customers")]
        public IActionResult Index()
        {
            ViewBag.Customers = _context.Customers.ToList();
            return View();
        }

        [HttpPost]
        [Route("/customers/new")]
        public IActionResult New(CustomerViewModel customer)
        {

            if(ModelState.IsValid)
            {
                if(_context.Customers.SingleOrDefault(Customer => Customer.CustomerName == customer.CustomerName) == null)
                {
                    Customer cust = new Customer
                    {
                        CustomerName = customer.CustomerName,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    };

                    _context.Customers.Add(cust);
                    _context.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("customers/{id}/remove")]
        public IActionResult Remove(int id)
        {
            ViewBag.Customer = _context.Customers.SingleOrDefault(Customers => Customers.Id == id);
            return View();
        }

        [HttpGet]
        [Route("customers/{id}/destroy")]
        public IActionResult Destroy(int id)
        {
            Customer customer = _context.Customers.SingleOrDefault(Customers => Customers.Id == id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        
    }
}
