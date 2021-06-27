using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using _05_Registration.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using System;

namespace _05_Registration.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void TryTo(string command)
        {
            string path = $"{AppDomain.CurrentDomain.BaseDirectory}logs.txt";

            try
            {
                using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine($"User try to {command} {DateTime.Now}");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            Response.Redirect("/");
        }

        public IActionResult Login()
        {
            ViewBag.form = "<form method=\"post\" action=\"/Home/TryTo?command=login\" >" +
                "<div class=\"mb - 3\">" +
                    "<label for=\"login\" class=\"form-label\">Login</label>" +
                    "<input type=\"text\" class=\"form-control\" id=\"login\" aria-describedby=\"emailHelp\">" +
                "</div>" +
                "<div class=\"mb - 3\">" +
                    "<label for=\"exampleInputPassword1\" class=\"form-label\">Password</label>" +
                    "<input type =\"password\" class=\"form-control\" id=\"exampleInputPassword1\"> " +
                "</div>" +
                   "<div class=\"mb-3 form-check\">" +
                    "<input type =\"checkbox\" class=\"form-check-input\" id=\"exampleCheck1\"> " +
                    "<label class=\"form-check-label\" for=\"exampleCheck1\">Check me out</label>" +
                "</div>" +
                "<button type=\"submit\" class=\"btn btn-primary\">Submit</button>" +
            "</form>";

            return View("Index");
        }

        public IActionResult Registration()
        {
            ViewBag.form = "<form method =\"post\" action=\"/Home/TryTo?command=registration\" >" +
                 "<div class=\"mb - 3\">" +
                     "<label for=\"login\" class=\"form-label\">Login</label>" +
                     "<input type=\"text\" class=\"form-control\" id=\"login\" aria-describedby=\"emailHelp\">" +
                 "</div>" +
                 "<div class=\"mb - 3\">" +
                     "<label for=\"exampleInputEmail1\" class=\"form-label\">Email address</label>" +
                     "<input type=\"email\" class=\"form-control\" id=\"exampleInputEmail1\" aria-describedby=\"emailHelp\">" +
                     "<div style=\"margin-bottom: 10px;\" id=\"emailHelp\" class=\"form-text\">We'll never share your email with anyone else.</div>" +
                 "</div>" +
                 "<div class=\"mb - 3\">" +
                     "<label for=\"exampleInputPassword1\" class=\"form-label\">Password</label>" +
                     "<input type =\"password\" class=\"form-control\" id=\"exampleInputPassword1\"> " +
                 "</div>" +
                 "<div class=\"mb - 3\">" +
                     "<label for=\"exampleInputConfirmPassword1\" class=\"form-label\">Confirm password</label>" +
                     "<input type =\"password\" class=\"form-control\" id=\"exampleInputConfirmPassword1\"> " +
                 "</div>" +
                     "<div class=\"mb-3 form-check\">" +
                     "<input type =\"checkbox\" class=\"form-check-input\" id=\"exampleCheck1\"> " +
                     "<label class=\"form-check-label\" for=\"exampleCheck1\">Check me out</label>" +
                 "</div>" +
                 "<button type = \"submit\" class=\"btn btn-primary\">Submit</button>" +
             "</form>";

            return View("Index");
        }

        public IActionResult News()
        {
            return View();
        }

        public IActionResult About()
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
