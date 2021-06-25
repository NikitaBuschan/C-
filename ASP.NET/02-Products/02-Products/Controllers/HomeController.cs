using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using _02_Products.Models;

namespace _02_Products.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public List<Product> products = new List<Product>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            products.Add(new Product(products.Count + 1, "Банан", "/img/banan.jpg", "Супер спелый и вкусный продукт, без добавления ГМО", "Полное описание", 20));
            products.Add(new Product(products.Count + 1, "Грейпфрут", "/img/grapefruit.jpg", "Очень вкусный", "Полное описание", 22));
            products.Add(new Product(products.Count + 1, "Дыня", "/img/melone.jpg", "Супер спелый и вкусный продукт, без добавления ГМО", "Полное описание", 27.6));
            products.Add(new Product(products.Count + 1, "Апельсин", "/img/orange.jpg", "Очень вкусный", "Полное описание", 35));
            products.Add(new Product(products.Count + 1, "Груша", "/img/pear.jpeg", "Спелая, сочная!", "Полное описание", 40));
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }

        public IActionResult Products()
        {
            ViewBag.products = products;
            return View();
        }

        public IActionResult Product(int id)
        {
            ViewBag.product = products.Find((item) => item.Id == id);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
