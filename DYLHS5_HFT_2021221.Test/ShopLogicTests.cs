using DYLHS5_HFT_2021221.Logic;
using DYLHS5_HFT_2021221.Models;
using DYLHS5_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DYLHS5_HFT_2021221.Test
{
    [TestFixture]
    public class ShopLogicTests
    {
        private ShopLogic ShopLogic { get; set; }

        private Mock<IProductRepository> ProductRepositoryMock { get; set; }
        private Mock<ICustomerRepository> CustomersRepositoryMock { get; set; }
        private Mock<IOrderRepository> OrderRepositoryMock { get; set; }




        [SetUp]
        public void Setup()
        {
            this.CustomersRepositoryMock = new Mock<ICustomerRepository>();
            this.ProductRepositoryMock = new Mock<IProductRepository>();
            this.OrderRepositoryMock = new Mock<IOrderRepository>();


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

            ProductRepositoryMock.Setup(x => x.ReadAll())
                .Returns(new List<Product>()
                {dorko1,dorko2,adidas1,adidas2,nike1,nike2,converse1,converse2,vans1,vans2}.AsQueryable());
            OrderRepositoryMock.Setup(x => x.ReadAll())
                .Returns(new List<Order>()
                {order1,order2,order3,order4,order5,order6,order7,order8,order9,order10}.AsQueryable());
            CustomersRepositoryMock.Setup(x => x.ReadAll())
                .Returns(new List<Customer>() { customer1, customer2, customer3, customer4, customer5 }.AsQueryable());


            this.ShopLogic = new ShopLogic(this.CustomersRepositoryMock.Object, this.OrderRepositoryMock.Object, this.ProductRepositoryMock.Object);

        }

        [Test]
        public void GetOrdersByCustomerNameTest() //returns the orders of the specified customer
        {
            Customer customer1 = new Customer() { CustomerId = 1, CustomerName = "A.Aladár", Address = "Randomcím1", PhoneNumber = 06701234567 };
            Product dorko1 = new Product() { ProductId = 1, ProductName = "BOUNCE", Color = "BROWN", Size = 41, Price = 24999 };
            Product adidas1 = new Product() { ProductId = 3, ProductName = "ORIGINALS CONTINENTAL 80 STRIPES", Color = "BLACK", Size = 42, Price = 29999 };
            Order order1 = new Order() { OrderId = 1, ProductId = 1, CustomerId = 1, IsPrePaid = true, IsTransportRequired = false, Product = dorko1, Customer = customer1 };
            Order order3 = new Order() { OrderId = 3, ProductId = 3, CustomerId = 1, IsPrePaid = true, IsTransportRequired = false, Product = adidas1, Customer = customer1 };

            IEnumerable<Order> expected = new List<Order>() { order1, order3 };

            IEnumerable<Order> actual = ShopLogic.GetOrdersByCustomername("A.Aladár").ToList();


            Assert.AreEqual(expected.Last().Customer.CustomerName, actual.Last().Customer.CustomerName);

        }
        [Test]
        public void GetAddressesOfOrdersTest() //returns the orders with the addresses (if there is any)
        {
            Customer customer1 = new Customer() { CustomerId = 1, CustomerName = "A.Aladár", Address = "Randomcím1", PhoneNumber = 06701234567 };
            Customer customer3 = new Customer() { CustomerId = 3, CustomerName = "C.Cecília", PhoneNumber = 06701234569, Address = "Randomcim2" };
            Product dorko1 = new Product() { ProductId = 1, ProductName = "BOUNCE", Color = "BROWN", Size = 41, Price = 24999 };
            Product adidas1 = new Product() { ProductId = 3, ProductName = "ORIGINALS CONTINENTAL 80 STRIPES", Color = "BLACK", Size = 42, Price = 29999 };
            Product nike1 = new Product() { ProductId = 5, ProductName = "AIR PRESTO", Color = "ORANGE", Size = 40, Price = 44999 };
            Product converse1 = new Product() { ProductId = 7, ProductName = "RIVAL", Color = "GREY", Size = 41, Price = 24999 };
            Order order1 = new Order() { OrderId = 1, ProductId = dorko1.ProductId, CustomerId = customer1.CustomerId, IsPrePaid = true, IsTransportRequired = false, Product = dorko1, Customer = customer1 };
            Order order3 = new Order() { OrderId = 3, ProductId = adidas1.ProductId, CustomerId = customer1.CustomerId, IsPrePaid = true, IsTransportRequired = false, Product = adidas1, Customer = customer1 };
            Order order5 = new Order() { OrderId = 5, ProductId = nike1.ProductId, CustomerId = customer3.CustomerId, IsPrePaid = false, IsTransportRequired = false, Product = nike1, Customer = customer3 };
            Order order7 = new Order() { OrderId = 7, ProductId = converse1.ProductId, CustomerId = customer3.CustomerId, IsPrePaid = false, IsTransportRequired = false, Product = converse1, Customer = customer3 };


            IEnumerable<KeyValuePair<Order, string>> expected = new List<KeyValuePair<Order, string>>()
            {
                new KeyValuePair<Order, string>(order1,"Randomcím1"),
                new KeyValuePair<Order, string>(order3,"Randomcím1"),
                new KeyValuePair<Order, string>(order5,"Randomcim2"),
                new KeyValuePair<Order, string>(order3,"Randomcim2"),

            };
            Assert.AreEqual(expected.Last().Value, ShopLogic.GetAddressesOfOrders().Last().Value);

        }

        [Test]
        public void GetProductsWeNeedToTransportTest() //returns the products which we have to deliver
        {
            Product vans1 = new Product() { ProductId = 9, ProductName = "OLD SKOOL", Color = "BLUE", Size = 41, Price = 29999 };
            Product vans2 = new Product() { ProductId = 10, ProductName = "ULTRARANGE EXO", Color = "BLACK", Size = 40, Price = 39999 };
            Product dorko2 = new Product() { ProductId = 2, ProductName = "CARBONITE", Color = "BLACK", Size = 42, Price = 24999 };
            Product converse2 = new Product() { ProductId = 8, ProductName = "COURTLANDT", Color = "GREY", Size = 44, Price = 9999 };
            Product adidas2 = new Product() { ProductId = 4, ProductName = "PERFORMANCE HOOPS MID 2.0 K", Color = "BLACK", Size = 40, Price = 14999 };
            Customer customer2 = new Customer() { CustomerId = 2, CustomerName = "B.Bence", PhoneNumber = 06701234568 };
            Customer customer4 = new Customer() { CustomerId = 4, CustomerName = "D.Dávid", PhoneNumber = 06701234570 };
            Customer customer5 = new Customer() { CustomerId = 5, CustomerName = "E.Elvira", PhoneNumber = 06701234571 };
            Order order4 = new Order() { OrderId = 4, ProductId = adidas2.ProductId, CustomerId = customer2.CustomerId, IsPrePaid = true, IsTransportRequired = true, Product = adidas2, Customer = customer2 };
            Order order2 = new Order() { OrderId = 2, ProductId = dorko2.ProductId, CustomerId = customer2.CustomerId, IsPrePaid = false, IsTransportRequired = true, Product = dorko2, Customer = customer2 };
            Order order8 = new Order() { OrderId = 8, ProductId = converse2.ProductId, CustomerId = customer4.CustomerId, IsPrePaid = true, IsTransportRequired = true, Product = converse2, Customer = customer4 };
            Order order9 = new Order() { OrderId = 9, ProductId = vans1.ProductId, CustomerId = customer5.CustomerId, IsPrePaid = true, IsTransportRequired = true, Product = vans1, Customer = customer5 };
            Order order10 = new Order() { OrderId = 10, ProductId = vans2.ProductId, CustomerId = customer5.CustomerId, IsPrePaid = true, IsTransportRequired = true, Product = vans2, Customer = customer5 };


            IEnumerable<Product> expected = new List<Product>() { dorko2, adidas2, converse2, vans1, vans2 };
            Assert.AreEqual(expected.Last().ProductId, ShopLogic.GetProductsWeNeedToTransport().Last().ProductId);
        }

        [Test]
        public void GetCustomersWithThisSizeTest() //returns the customers with the given size
        {
            Customer customer1 = new Customer() { CustomerId = 1, CustomerName = "A.Aladár", Address = "Randomcím1", PhoneNumber = 06701234567 };
            Customer customer3 = new Customer() { CustomerId = 3, CustomerName = "C.Cecília", PhoneNumber = 06701234569, Address = "Randomcim2" };
            Customer customer5 = new Customer() { CustomerId = 5, CustomerName = "E.Elvira", PhoneNumber = 06701234571 };

            IEnumerable<Customer> expexted = new List<Customer>() { customer1, customer3, customer5 };


            Assert.AreEqual(expexted.Last().CustomerName, ShopLogic.GetCustomersWithThisSize(41).Last().CustomerName);
        }

        [Test]
        public void GetPrePaidOrdersByCustomers() //returns prepaid orders with their customers
        {
            Product dorko1 = new Product() { ProductId = 1, ProductName = "BOUNCE", Color = "BROWN", Size = 41, Price = 24999 };
            Product adidas1 = new Product() { ProductId = 3, ProductName = "ORIGINALS CONTINENTAL 80 STRIPES", Color = "BLACK", Size = 42, Price = 29999 };
            Product adidas2 = new Product() { ProductId = 4, ProductName = "PERFORMANCE HOOPS MID 2.0 K", Color = "BLACK", Size = 40, Price = 14999 };
            Product nike2 = new Product() { ProductId = 6, ProductName = "REVOLUTION 5", Color = "GREY", Size = 45, Price = 19999 };
            Product converse2 = new Product() { ProductId = 8, ProductName = "COURTLANDT", Color = "GREY", Size = 44, Price = 9999 };
            Product vans1 = new Product() { ProductId = 9, ProductName = "OLD SKOOL", Color = "BLUE", Size = 41, Price = 29999 };
            Product vans2 = new Product() { ProductId = 10, ProductName = "ULTRARANGE EXO", Color = "BLACK", Size = 40, Price = 39999 };
            Customer customer1 = new Customer() { CustomerId = 1, CustomerName = "A.Aladár", Address = "Randomcím1", PhoneNumber = 06701234567 };
            Customer customer2 = new Customer() { CustomerId = 2, CustomerName = "B.Bence", PhoneNumber = 06701234568 };
            Customer customer4 = new Customer() { CustomerId = 4, CustomerName = "D.Dávid", PhoneNumber = 06701234570 };
            Customer customer5 = new Customer() { CustomerId = 5, CustomerName = "E.Elvira", PhoneNumber = 06701234571 };
            Order order1 = new Order() { OrderId = 1, ProductId = dorko1.ProductId, CustomerId = customer1.CustomerId, IsPrePaid = true, IsTransportRequired = false, Product = dorko1, Customer = customer1 };
            Order order3 = new Order() { OrderId = 3, ProductId = adidas1.ProductId, CustomerId = customer1.CustomerId, IsPrePaid = true, IsTransportRequired = false, Product = adidas1, Customer = customer1 };
            Order order4 = new Order() { OrderId = 4, ProductId = adidas2.ProductId, CustomerId = customer2.CustomerId, IsPrePaid = true, IsTransportRequired = true, Product = adidas2, Customer = customer2 };
            Order order6 = new Order() { OrderId = 6, ProductId = nike2.ProductId, CustomerId = customer4.CustomerId, IsPrePaid = true, IsTransportRequired = false, Product = nike2, Customer = customer4 };
            Order order8 = new Order() { OrderId = 8, ProductId = converse2.ProductId, CustomerId = customer4.CustomerId, IsPrePaid = true, IsTransportRequired = true, Product = converse2, Customer = customer4 };
            Order order9 = new Order() { OrderId = 9, ProductId = vans1.ProductId, CustomerId = customer5.CustomerId, IsPrePaid = true, IsTransportRequired = true, Product = vans1, Customer = customer5 };
            Order order10 = new Order() { OrderId = 10, ProductId = vans2.ProductId, CustomerId = customer5.CustomerId, IsPrePaid = true, IsTransportRequired = true, Product = vans2, Customer = customer5 };

            IEnumerable<KeyValuePair<Customer, Order>> expected = new List<KeyValuePair<Customer, Order>>()
            {
                new KeyValuePair<Customer, Order>(customer1,order1),
                new KeyValuePair<Customer, Order>(customer1,order3),
                new KeyValuePair<Customer, Order>(customer2,order4),
                new KeyValuePair<Customer, Order>(customer4,order6),
                new KeyValuePair<Customer, Order>(customer4,order8),
                new KeyValuePair<Customer, Order>(customer5,order9),
                new KeyValuePair<Customer, Order>(customer5,order10),

            };


            Assert.AreEqual(expected.Last().Value.CustomerId, ShopLogic.GetPrePaidOrdersByCustomers().Last().Value.CustomerId);

        }

    }





}

