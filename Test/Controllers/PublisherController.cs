using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data;
using Test.Data.Interfaces;
using Test.Data.Models;

namespace Test.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IAllPublisher publishers;

        public PublisherController(IAllPublisher publishers)
        {
            this.publishers = publishers;
        }
        [HttpGet]
        [Route("Publisher/Index")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                publishers.createPublisher(publisher);
                return RedirectToAction("Complete");
            }
            return View(publisher);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Издательство добавлено";
            return View();
        }
    }
}
