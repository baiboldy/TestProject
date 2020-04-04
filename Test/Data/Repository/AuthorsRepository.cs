using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data.Interfaces;
using Test.Data.Models;

namespace Test.Data.Repository
{
    public class AuthorsRepository : IAllAuthor
    {
        private AppDBContent appDBContent;

        public AuthorsRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Author> getAllAuthor => appDBContent.Author;

        public void createAuthor(Author author)
        {
            appDBContent.Author.Add(author);
            appDBContent.SaveChanges();
        }

        public Author getAuthorById(int id)
        {
            return appDBContent.Author.Where(author => author.id == id).FirstOrDefault();
        }
    }
}
