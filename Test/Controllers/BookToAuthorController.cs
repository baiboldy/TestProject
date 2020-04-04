using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data.Interfaces;
using Test.Data.Models;
using Test.ViewModels;

namespace Test.Controllers
{
    public class BookToAuthorController : Controller
    {
        private readonly IBookToAuthor iBookToAuthor;
        private readonly IAllAuthor allAuthor;
        private readonly IAllBooks allBooks;
        private readonly IAllPublisher allPublisher;

        public BookToAuthorController(IBookToAuthor ibookToAuthor, IAllAuthor allAuthor, IAllBooks allBooks, IAllPublisher allPublisher)
        {
            this.iBookToAuthor = ibookToAuthor;
            this.allBooks = allBooks;
            this.allAuthor = allAuthor;
            this.allPublisher = allPublisher;
        }

        public IActionResult Index()
        {
            var authors = allAuthor.getAllAuthor.ToList();
            SelectList list = new SelectList(authors, "id", "name");
            ViewBag.allAuthor = list;

            var books = allBooks.getAllBook.ToList();
            SelectList listBooks = new SelectList(books, "id", "name");
            ViewBag.allBook = listBooks;
            return View();
        }

        [HttpPost]
        public IActionResult Index(BookToAuthor bookToAuthor)
        {
            if (ModelState.IsValid)
            {
                iBookToAuthor.create(bookToAuthor);
                return RedirectToAction("Complete");
            }

            return View(bookToAuthor);
        }
        [HttpGet]
        public IActionResult ShowTable()
        {
            List<BookToAuthor> bookToAuthors = iBookToAuthor.getData().ToList();
            BookToAuthorViewModel viewModel = new BookToAuthorViewModel();
            viewModel.allBookToAuthor = bookToAuthors;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult ShowTable(BookToAuthorViewModel bookViewModel)
        {
            if (bookViewModel.selectedValue == 1)
            {
                bookViewModel.allBookToAuthor = iBookToAuthor.getDataByNameCondition(bookViewModel.searchValue);
            }else if(bookViewModel.selectedValue == 2)
            {
                bookViewModel.allBookToAuthor = iBookToAuthor.getDataByPublisherCondition(bookViewModel.searchValue);
            }else if (bookViewModel.selectedValue == 3)
            {
                bookViewModel.allBookToAuthor = iBookToAuthor.getDataByAuthorCondition(bookViewModel.searchValue);
            }
            return View(bookViewModel);
        }


        public IActionResult Complete()
        {
            ViewBag.Message = "BookToAuthor added";
            return View();
        }
    }
}
