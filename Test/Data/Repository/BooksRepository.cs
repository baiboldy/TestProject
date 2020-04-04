using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data.Interfaces;
using Test.Data.Models;

namespace Test.Data.Repository
{
    public class BooksRepository : IAllBooks
    {
        private AppDBContent appDBContent;
        public BooksRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Book> getAllBook => appDBContent.Book;

        public void createBook(Book book)
        {
            appDBContent.Book.Add(book);
            appDBContent.SaveChanges();
        }

        public Book getBook(int id)
        {
            return appDBContent.Book.Where(book => book.id == id).FirstOrDefault();
        }
    }
}
