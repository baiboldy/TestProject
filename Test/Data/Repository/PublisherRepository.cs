using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data.Interfaces;
using Test.Data.Models;

namespace Test.Data.Repository
{
    public class PublisherRepository : IAllPublisher
    {
        private AppDBContent appDBContent;

        public PublisherRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Publisher> getAllPublisher => appDBContent.Publisher;

        public void createPublisher(Publisher publisher)
        {
            appDBContent.Publisher.Add(publisher);
            appDBContent.SaveChanges();
        }

        public IEnumerable<Publisher> getByNameCondition(string value)
        {
            return appDBContent.Publisher.Where(publisher => publisher.name.Contains(value)).ToList();
        }

        public Publisher getPublisherById(int id)
        {
            return appDBContent.Publisher.Where(publisher => publisher.id == id).FirstOrDefault();
        }
    }
}
