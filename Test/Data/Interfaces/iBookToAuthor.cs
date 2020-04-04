using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data.Models;

namespace Test.Data.Interfaces
{
    public interface IBookToAuthor
    {
        void create(BookToAuthor bookToAuthor);
        IEnumerable<BookToAuthor> getData();
        IEnumerable<BookToAuthor> getDataByNameCondition(string value);
        IEnumerable<BookToAuthor> getDataByPublisherCondition(string value);
        IEnumerable<BookToAuthor> getDataByAuthorCondition(string value);
    }
}
