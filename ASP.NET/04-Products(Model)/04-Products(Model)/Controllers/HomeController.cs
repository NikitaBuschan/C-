using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using _04_Products_Model_.Models;

namespace _04_Products_Model_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public List<Product> Products = new List<Product>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            Products.Add(new Product(Products.Count + 1, "Apple", 1500));
            Products.Add(new Product(Products.Count + 1, "Samsung", 1000));
            Products.Add(new Product(Products.Count + 1, "Xiaomi", 950));
            Products.Add(new Product(Products.Count + 1, "Meizu", 850));
        }

        public IActionResult Index()
        {
            return View(Products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
