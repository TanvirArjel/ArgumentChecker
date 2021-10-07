using System;
using System.Diagnostics;
using DemoApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TanvirArjel.ArgumentChecker;

namespace DemoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(Guid? input)
        {
            string myName = "Tanvir";
            myName.ThrowIfOutOfLength(7, 10, nameof(myName));

            input = Guid.Empty;
            input.ThrowIfNullOrEmpty(nameof(input));
            return View();
        }

        public static string[] GetArray(Span<string> value)
        {
            value.ThrowIfNull(nameof(value));

            return value.ToArray();
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
