using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using _03_FlowersShop.Models;

namespace _03_FlowersShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public List<Flower> Flowers = new List<Flower>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            Flowers.Add(new Flower("Роза", 5, new Address("Пушкинская 30", "29", 2), "Как можно быстрее", "Олег", new DateTime(2021, 06, 25, 12, 00, 00)));
            Flowers.Add(new Flower("Роза", 101, new Address("Генуезская 2а", "29", 3, 15), "Вообще не важно во сколько вы будете, я вам просто не заплачу", "Алевтин", new DateTime(2021, 06, 25, 16, 00, 00)));
            Flowers.Add(new Flower("Гладиолус", 15, new Address("Деребасовская 1", "1", 1), "", "Вася", new DateTime(2021, 06, 26, 22, 10, 00)));
            Flowers.Add(new Flower("Роза", 5, new Address("Канатная 10", "11", 2), "Как можно быстрее", "Петя", new DateTime(2021, 06, 26, 10, 15, 00)));
        }

        public IActionResult Index()
        {
            ViewBag.Flowers = Flowers;

            return View();
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
