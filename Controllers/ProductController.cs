using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using eCommerce.Models;
using System.Linq;

namespace eCommerce.Controllers
{
    public class ProductController : Controller
    {


        private MyContext _context;
 
        public ProductController(MyContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("products")]
        public IActionResult Index()
        {
            ViewBag.Products = _context.Products.ToList();
            return View();
        }

        [HttpPost]
        [Route("/products/new")]
        public IActionResult New(ProductViewModel product)
        {
            if(ModelState.IsValid)
            {
                Product prod = new Product
                {
                    ProductName = product.ProductName,
                    ImageUrl = product.ImageUrl,
                    Description = product.Description,
                    Quantity = product.Quantity,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                _context.Products.Add(prod);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}