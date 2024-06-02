﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VendasWebAplication.Models;
using VendasWebAplication.Models.ViewModels;

namespace VendasWebAplication.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult About() {
            ViewData["Message"] = "Salles Web MVC App from C# Course";
            

            return View();
        }

        

        public IActionResult Contact() {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}