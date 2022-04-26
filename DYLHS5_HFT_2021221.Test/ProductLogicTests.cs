using System.Collections.Generic;
using System.Linq;
using DYLHS5_HFT_2021221.Logic;
using DYLHS5_HFT_2021221.Models;
using DYLHS5_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;

namespace DYLHS5_HFT_2021221.Test
{
    [TestFixture]
    class ProductLogicTests
    {
        IProductLogic logic;

        [SetUp]
        public void Setup()
        {
            Mock<IProductRepository> mockedRepo = new Mock<IProductRepository>();

            //PRODUCTS
            Product dorko1 = new Product() { ProductId = 1, ProductName = "BOUNCE", Color = "BROWN", Size = 41, Price = 24999 };
            Product dorko2 = new Product() { ProductId = 2, ProductName = "CARBONITE", Color = "BLACK", Size = 42, Price = 24999 };

            Product adidas1 = new Product() { ProductId = 3, ProductName = "ORIGINALS CONTINENTAL 80 STRIPES", Color = "BLACK", Size = 42, Price = 29999 };
            Product adidas2 = new Product() { ProductId = 4, ProductName = "PERFORMANCE HOOPS MID 2.0 K", Color = "BLACK", Size = 40, Price = 14999 };

            Product nike1 = new Product() { ProductId = 5, ProductName = "AIR PRESTO", Color = "ORANGE", Size = 40, Price = 44999 };
            Product nike2 = new Product() { ProductId = 6, ProductName = "REVOLUTION 5", Color = "GREY", Size = 45, Price = 19999 };

            Product converse1 = new Product() { ProductId = 7, ProductName = "RIVAL", Color = "GREY", Size = 41, Price = 24999 };
            Product converse2 = new Product() { ProductId = 8, ProductName = "COURTLANDT", Color = "GREY", Size = 44, Price = 9999 };

            Product vans1 = new Product() { ProductId = 9, ProductName = "OLD SKOOL", Color = "BLUE", Size = 41, Price = 29999 };
            Product vans2 = new Product() { ProductId = 10, ProductName = "ULTRARANGE EXO", Color = "BLACK", Size = 40, Price = 39999 };

            //CUSTOMERS
            Customer customer1 = new Customer() { CustomerId = 1, CustomerName = "A.Aladár", Address = "Randomcím1", PhoneNumber = 06701234567 };
            Customer customer2 = new Customer() { CustomerId = 2, CustomerName = "B.Bence", PhoneNumber = 06701234568 };
            Customer customer3 = new Customer() { CustomerId = 3, CustomerName = "C.Cecília", PhoneNumber = 06701234569, Address = "Randomcim2" };
            Customer customer4 = new Customer() { CustomerId = 4, CustomerName = "D.Dávid", PhoneNumber = 06701234570 };
            Customer customer5 = new Customer() { CustomerId = 5, CustomerName = "E.Elvira", PhoneNumber = 06701234571 };

            //ORDERS
            Order order1 = new Order() { OrderId = 1, ProductId = dorko1.ProductId, CustomerId = customer1.CustomerId, IsPrePaid = true, IsTransportRequired = false, Product = dorko1, Customer = customer1 };
            Order order2 = new Order() { OrderId = 2, ProductId = dorko2.ProductId, CustomerId = customer2.CustomerId, IsPrePaid = false, IsTransportRequired = true, Product = dorko2, Customer = customer2 };
            Order order3 = new Order() { OrderId = 3, ProductId = adidas1.ProductId, CustomerId = customer1.CustomerId, IsPrePaid = true, IsTransportRequired = false, Product = adidas1, Customer = customer1 };
            Order order4 = new Order() { OrderId = 4, ProductId = adidas2.ProductId, CustomerId = customer2.CustomerId, IsPrePaid = true, IsTransportRequired = true, Product = adidas2, Customer = customer2 };
            Order order5 = new Order() { OrderId = 5, ProductId = nike1.ProductId, CustomerId = customer3.CustomerId, IsPrePaid = false, IsTransportRequired = false, Product = nike1, Customer = customer3 };
            Order order6 = new Order() { OrderId = 6, ProductId = nike2.ProductId, CustomerId = customer4.CustomerId, IsPrePaid = true, IsTransportRequired = false, Product = nike2, Customer = customer4 };
            Order order7 = new Order() { OrderId = 7, ProductId = converse1.ProductId, CustomerId = customer3.CustomerId, IsPrePaid = false, IsTransportRequired = false, Product = converse1, Customer = customer3 };
            Order order8 = new Order() { OrderId = 8, ProductId = converse2.ProductId, CustomerId = customer4.CustomerId, IsPrePaid = true, IsTransportRequired = true, Product = converse2, Customer = customer4 };
            Order order9 = new Order() { OrderId = 9, ProductId = vans1.ProductId, CustomerId = customer5.CustomerId, IsPrePaid = true, IsTransportRequired = true, Product = vans1, Customer = customer5 };
            Order order10 = new Order() { OrderId = 10, ProductId = vans2.ProductId, CustomerId = customer5.CustomerId, IsPrePaid = true, IsTransportRequired = true, Product = vans2, Customer = customer5 };

            dorko1.Orders.Add(order1);
            dorko2.Orders.Add(order2);
            adidas1.Orders.Add(order3);
            adidas2.Orders.Add(order4);
            nike1.Orders.Add(order5);
            nike2.Orders.Add(order6);
            converse1.Orders.Add(order7);
            converse2.Orders.Add(order8);
            vans1.Orders.Add(order9);
            vans2.Orders.Add(order10);

            customer1.Orders.Add(order1);
            customer1.Orders.Add(order3);
            customer2.Orders.Add(order2);
            customer2.Orders.Add(order4);
            customer3.Orders.Add(order5);
            customer3.Orders.Add(order7);
            customer4.Orders.Add(order6);
            customer4.Orders.Add(order8);
            customer5.Orders.Add(order9);
            customer5.Orders.Add(order10);



            mockedRepo.Setup(x => x.ReadAll())
                .Returns(new List<Product>()
                {dorko1,dorko2,adidas1,adidas2,nike1,nike2,converse1,converse2,vans1,vans2}.AsQueryable());


            logic = new ProductLogic(mockedRepo.Object);

        }
        [Test] //Create Exception #3
        public void CreateCustomerNameMissingTest()
        {
            Product dorko3 = new Product() { Color = "GREEN", Size = 42, Price = 20099 };


            Assert.Throws<ProductOrCustomerNameMissingException>(() => logic.Create(dorko3));

        }

    }
}
