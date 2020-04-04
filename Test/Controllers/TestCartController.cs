using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data.Interfaces;
using Test.Data.Models;
using Test.Data.Repository;
using Test.ViewModels;

namespace Test.Controllers
{
    public class TestCartController : Controller
    {
        private readonly IAllCars _carRep;
        private readonly TestCart _testCart;

        public TestCartController(IAllCars carRep, TestCart testCart)
        {
            _carRep = carRep;
            _testCart = testCart;
        }

        public ViewResult Index()
        {
            var items = _testCart.getTestItems();
            _testCart.listTestItems = items;
            var obj = new TestCartViewModel
            {
                testCart = _testCart
            };

            return View(obj);
        }

        public RedirectToActionResult addToCart(int id)
        {
            var item = _carRep.Cars.FirstOrDefault(i => i.id == id);
            if (item != null)
            {
                _testCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }
    }
}
