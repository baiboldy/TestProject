using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data.Interfaces;
using Test.Data.Models;

namespace Test.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAllAuthor allauthors;

        public AuthorController(IAllAuthor allauthors)
        {
            this.allauthors = allauthors;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Author author)
        {
            if (ModelState.IsValid)
            {
                allauthors.createAuthor(author);
                return RedirectToAction("Complete");
            }

            return View(author);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Author added";
            return View();
        }
        
    }
}
