using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data.Models;

namespace Test.Data.Interfaces
{
    public interface IAllBooks
    {
        void createBook(Book book);
        IEnumerable<Book> getAllBook { get; }
        Book getBook(int id);
    }
}
