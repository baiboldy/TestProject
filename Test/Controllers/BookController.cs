using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Test.Data.Interfaces;
using Test.Data.Models;
using Test.ViewModels;

namespace Test.Controllers
{
    public class BookController : Controller
    {
        private readonly IAllBooks allBooks;
        private readonly IAllPublisher allPublisher;
        public BookController(IAllBooks allBooks, IAllPublisher allPublisher)
        {
            this.allBooks = allBooks;
            this.allPublisher = allPublisher;
        }
        
        public IActionResult Index()
        {
            var publishers = allPublisher.getAllPublisher.ToList();
            SelectList list = new SelectList(publishers, "id", "name");
            ViewBag.allPublisher = list;
            return View();
        }

        [HttpPost]
        public IActionResult Index(Book book)
        {
            if (ModelState.IsValid)
            {
                allBooks.createBook(book);
                return RedirectToAction("Complete");
            }

            return View(book);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Book added";
            return View();
        }
    }
}
