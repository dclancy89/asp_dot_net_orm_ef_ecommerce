using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using eCommerce.Models;
using System.Linq;

namespace eCommerce.Controllers
{
    public class HomeController : Controller
    {

        private MyContext _context;
 
        public HomeController(MyContext context)
        {
            _context = context;
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Products = _context.Products.Take(5);
            return View();
        }

        
    }
}
