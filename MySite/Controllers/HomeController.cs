using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySite.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MySite.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MySite.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace MySite.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductionContext _context;

        public HomeController(ProductionContext context, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Manager()
        {
            return View();
        }
        public IActionResult Admin()
        {
            return View();
        }
        public IActionResult Technologist()
        {
            return View();
        }
        public IActionResult Accountant()
        {
            return View();
        }
        public IActionResult PurAgent()
        {
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
