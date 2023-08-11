﻿using Microsoft.AspNetCore.Mvc;
using MSIT150Site.Models;
using System.Diagnostics;

namespace MSIT150Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult JQuery() 
        {
        return View();
        }
        public IActionResult History() 
        {
            
            return View(); 
        
        }
        public IActionResult Index()
        {
          
            return View();
        }

        public IActionResult First()
        {
            return View();
        }
        public IActionResult Travel()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult GetDemo()
        {

            return View();
        }
        public IActionResult Regestier()
        {

            return View();
        }

        public IActionResult CITY()
        {

            return View();
        }

        public IActionResult Adress() 
        {
        return View( );
        }

        public IActionResult Promise()
        {
            return View();
        }

        public IActionResult Fetch()
        {
            return View();
        }

        public IActionResult Partial() 
        {
            return PartialView();
        }

        public IActionResult Partial2()
        {
            ViewBag.MESSAGE = "來自action";
            return PartialView();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}