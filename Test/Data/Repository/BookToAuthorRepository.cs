using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data.Interfaces;
using Test.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Test.Data.Repository
{
    public class BookToAuthorRepository : IBookToAuthor
    {
        private AppDBContent appDBContent;
        public BookToAuthorRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public void create(BookToAuthor bookToAuthor)
        {
            appDBContent.bookToAuthors.Add(bookToAuthor);
            appDBContent.SaveChanges();
        }

        public IEnumerable<BookToAuthor> getData()
        {
            return appDBContent.bookToAuthors.Include(x => x.author).Include(y=>y.book).Include(x=>x.book.publisher);
        }

        public IEnumerable<BookToAuthor> getDataByAuthorCondition(string value)
        {
            return appDBContent.bookToAuthors.Where(bookAuthor => bookAuthor.author.name.Contains(value)).Include(i => i.book).Include(i => i.author).Include(x => x.book.publisher).ToList();
        }

        public IEnumerable<BookToAuthor> getDataByNameCondition(string value)
        {
            return appDBContent.bookToAuthors.Where(bookAuthor => bookAuthor.book.name.Contains(value)).Include(x => x.author).Include(x => x.book).Include(x => x.book.publisher).ToList();
        }

        public IEnumerable<BookToAuthor> getDataByPublisherCondition(string value)
        {
            return appDBContent.bookToAuthors.Where(bookToAuthor => bookToAuthor.book.publisher.name.Contains(value)).Include(x => x.author).Include(x => x.book).Include(x => x.book.publisher).ToList();
        }
    }
}
