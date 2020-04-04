using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data.Interfaces;
using Test.Data.Models;

namespace Test.Data.mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category{categoryName = "Электромобили", desc = "Современный вид транспорта"},
                    new Category{categoryName = "Классический автомобиль", desc = "Машина с двигательем внутренного сгорания"}
                };
            }
        }
    }
}
