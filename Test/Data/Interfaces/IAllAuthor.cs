using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data.Models;

namespace Test.Data.Interfaces
{
    public interface IAllAuthor
    {
        void createAuthor(Author author);
        IEnumerable<Author> getAllAuthor { get; }
        Author getAuthorById(int id);
    }
}
