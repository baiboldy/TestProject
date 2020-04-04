using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data.Models;

namespace Test.Data.Interfaces
{
    public interface IAllPublisher
    {
        void createPublisher(Publisher publisher);
        IEnumerable<Publisher> getAllPublisher { get; }
        Publisher getPublisherById(int id);
        IEnumerable<Publisher> getByNameCondition(string value);
    }
}
