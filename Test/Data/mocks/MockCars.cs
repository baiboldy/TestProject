using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data.Interfaces;
using Test.Data.Models;

namespace Test.Data.mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _categoryCars = new MockCategory();
        public IEnumerable<Car> Cars {
            get
            {
                return new List<Car>
                {
                    new Car {name = "Tesla", shortDesc = "", longDesc = "", img = "/img/img.jpg", price = 45000, isFavorite = true, available = false, Category = _categoryCars.AllCategories.First()},
                    new Car {name = "BMW", shortDesc = "", longDesc = "", img = "/img/img1.jpg", price = 25000, isFavorite = true, available = true, Category = _categoryCars.AllCategories.Last()},
                    new Car {name = "Toyota", shortDesc = "", longDesc = "", img = "/img/img2.jpg", price = 18000, isFavorite = true, available = true, Category = _categoryCars.AllCategories.Last()},
                    new Car {name = "Mercedes-benz", shortDesc = "", longDesc = "", img = "/img/img3.jpg", price = 30000, isFavorite = false, available = false, Category = _categoryCars.AllCategories.Last()},
                    new Car {name = "Audi", shortDesc = "", longDesc = "", img = "/img/img4.jpg", price = 24000, isFavorite = true, available = true, Category = _categoryCars.AllCategories.Last()},
                    new Car {name = "Hyundai", shortDesc = "", longDesc = "", img = "/img/img5.jpg", price = 15000, isFavorite = false, available = true, Category = _categoryCars.AllCategories.Last()},
                };
            }
        }
        public IEnumerable<Car> getFavCars { get; set; }

        public Car getObjectCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
