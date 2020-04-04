using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Data.Models
{
    public class TestCart
    {
        private readonly AppDBContent appDBContent;
        public TestCart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public string TestCardId { get; set; }
        public List<TestCartItem> listTestItems { get; set; }

        public static TestCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string testCartId = session.GetString("CardId") ?? Guid.NewGuid().ToString();

            session.SetString("CardId", testCartId);

            return new TestCart(context)
            {
                TestCardId = testCartId
            };
        }

        public void AddToCart(Car car)
        {
            appDBContent.testCartItems.Add(new TestCartItem {
                TestCartId = TestCardId,
                car = car,
                price = car.price,
            });
            appDBContent.SaveChanges();
        }

        public List<TestCartItem> getTestItems()
        {
            return appDBContent.testCartItems.Where(c => c.TestCartId == TestCardId).Include(s => s.car).ToList();
        }
    }
}
