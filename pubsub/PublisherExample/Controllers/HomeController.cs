using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EasyNetQ;
using MessagesExample;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PublisherExample.Models;

namespace PublisherExample.Controllers {
    public class HomeController : Controller {

        private readonly ILogger<HomeController> _logger;
        private readonly IBus bus;

        public HomeController(ILogger<HomeController> logger, IBus bus) {
            _logger = logger;
            this.bus = bus;
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Publish(string content, int howManyCopies) {
            var message = new Message {
                Content = content
            };
            for (var i = 0; i < howManyCopies; i++) {
                bus.PublishAsync(message);
            }
            return Content($"Published {howManyCopies} messages!");
        }
    }
}
