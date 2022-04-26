using ConsoleTools;
using DYLHS5_HFT_2021221.Data;
using DYLHS5_HFT_2021221.Models;
using System;
using System.Collections.Generic;

namespace DYLHS5_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            XYZDbContext dbContext = new XYZDbContext();
            RestService restService = new RestService("http://localhost:27588/");
            List<Order> orders;
            List<Product> products;
            List<Customer> customers;
            Order order = new Order();
            Product product = new Product();
            Customer customer = new Customer();

            Console.WriteLine("Client started successfully.");

            //API CALL MENU
            var menu = new ConsoleMenu()

                //READALL
                .Add("Get all...", () => new ConsoleMenu()
                .Add("Orders", () =>
                {
                    orders = restService.Get<Order>("/order");
                    foreach (Order order in orders)
                    {
                        Console.WriteLine("Order Id: " + order.OrderId + "\t Order time: " + order.OrderTime + "\t Prepaid: " + order.IsPrePaid + "\t Transport needed: " + order.IsTransportRequired);
                    }
                    Console.ReadLine();
                })
                .Add("Products", () =>
                {
                    products = restService.Get<Product>("/product");
                    foreach (Product product in products)
                    {
                        Console.WriteLine("Product Id:" + product.ProductId + "\t Name: " + product.ProductName + "\t Color: " + product.Color + "\t Size: " + product.Size + "\t Price: " + product.Price + "FT");
                    }
                    Console.ReadLine();
                })
                .Add("Customers", () =>
                {
                    customers = restService.Get<Customer>("/customer");
                    foreach (Customer customer in customers)
                    {
                        Console.WriteLine("Customer Id: " + customer.CustomerId + "\t Name: " + customer.CustomerName + "\t Phone: " + customer.PhoneNumber + "\t Address: " + customer.Address);
                    }
                    Console.ReadLine();
                })
                .Add("Back", ConsoleMenu.Close).Show())

                //READ
                .Add("Get one...", () => new ConsoleMenu()
                .Add("Order", () =>
                {
                    Console.WriteLine("Enter an id!");
                    int id = int.Parse(Console.ReadLine());
                    order = restService.GetSingle<Order>("/order/" + id);
                    Console.WriteLine("Order Id: " + order.OrderId + "\t Order time: " + order.OrderTime + "\t Prepaid: " + order.IsPrePaid + "\t Transport needed: " + order.IsTransportRequired);
                    Console.ReadLine();
                })
                .Add("Product", () =>
                {
                    Console.WriteLine("Enter an id!");
                    int id = int.Parse(Console.ReadLine());
                    product = restService.GetSingle<Product>("/product/" + id);
                    Console.WriteLine("Product Id: " + product.ProductId + "\t Name: " + product.ProductName + "\t Color: " + product.Color + "\t Size: " + product.Size + "\t Price: " + product.Price + "FT");
                    Console.ReadLine();
                })
                .Add("Customer", () =>
                {
                    Console.WriteLine("Enter an id!");
                    int id = int.Parse(Console.ReadLine());
                    customer = restService.GetSingle<Customer>("/customer/" + id);
                    Console.WriteLine("Customer Id: " + customer.CustomerId + "\t Name: " + customer.CustomerName + "\t Phone: " + customer.PhoneNumber + "\t Address: " + customer.Address);
                    Console.ReadLine();
                })
                .Add("Back", ConsoleMenu.Close).Show())

                //CREATE
                .Add("Create new...", () => new ConsoleMenu()
                 .Add("Order", () =>
                 {
                     Console.WriteLine("Is the order prepaid? y/n");
                     bool prepaid;
                     if (Console.ReadLine().Equals('y'))
                     {
                         prepaid = true;
                     }
                     else
                     {
                         prepaid = false;
                     }

                     Console.WriteLine("Does the order require transport? y/n");
                     bool isTransportRequired;
                     if (Console.ReadLine().Equals('y'))
                     {
                         isTransportRequired = true;
                     }
                     else
                     {
                         isTransportRequired = false;
                     }
                     restService.Post<Order>(new Order { IsPrePaid = prepaid, IsTransportRequired = isTransportRequired }, "/order");
                     Console.WriteLine("Order added!");
                     Console.ReadLine();
                 })
                 .Add("Product", () =>
                 {
                     Console.WriteLine("Add product name!");
                     string name = Console.ReadLine();
                     Console.WriteLine("Add product color!");
                     string color = Console.ReadLine();
                     Console.WriteLine("Add product size!");
                     int size = int.Parse(Console.ReadLine());
                     Console.WriteLine("Add product price!");
                     double price = double.Parse(Console.ReadLine());

                     restService.Post<Product>(new Product { ProductName = name, Color = color, Price = price, Size = size }, "/product");
                     Console.WriteLine("Product added!");
                     Console.ReadLine();
                 })
                 .Add("Customer", () =>
                 {
                     Console.WriteLine("Add customer name!");
                     string name = Console.ReadLine();
                     Console.WriteLine("Add customer phone number!");
                     long number = long.Parse(Console.ReadLine());
                     Console.WriteLine("Add customer address!");
                     string address = Console.ReadLine();

                     restService.Post<Customer>(new Customer { Address = address, CustomerName = name, PhoneNumber = number }, "/customer");
                     Console.WriteLine("Customer added!");
                     Console.ReadLine();

                 })
                 .Add("Back", ConsoleMenu.Close).Show())

                 //UPDATE
                 .Add("Update...", () => new ConsoleMenu()
                 .Add("Order", () =>
                 {
                     Console.WriteLine("Which order do you want to update? /ID/ ");
                     int id = int.Parse(Console.ReadLine());

                     Console.WriteLine("Is the order prepaid? y/n");
                     bool prepaid;
                     if (Console.ReadLine().Equals('y'))
                     {
                         prepaid = true;
                     }
                     else
                     {
                         prepaid = false;
                     }

                     Console.WriteLine("Does the order require transport? y/n");
                     bool isTransportRequired;
                     if (Console.ReadLine().Equals('y'))
                     {
                         isTransportRequired = true;
                     }
                     else
                     {
                         isTransportRequired = false;
                     }
                     restService.Put<Order>(new Order { OrderId = id, IsPrePaid = prepaid, IsTransportRequired = isTransportRequired, }, "/order");
                     Console.WriteLine("Order updated!");
                     Console.ReadLine();
                 }) //Id: 1-10
                 .Add("Product", () =>
                 {
                     Console.WriteLine("Which product do you want to upgrade?  /ID/ ");
                     int id = int.Parse(Console.ReadLine());
                     Console.WriteLine("Add product name!");
                     string name = Console.ReadLine();
                     Console.WriteLine("Add product color!");
                     string color = Console.ReadLine();
                     Console.WriteLine("Add product size!");
                     int size = int.Parse(Console.ReadLine());
                     Console.WriteLine("Add product price!");
                     double price = double.Parse(Console.ReadLine());

                     restService.Put<Product>(new Product { ProductName = name, Color = color, Price = price, Size = size }, "/product");
                     Console.WriteLine("Product updated!");
                     Console.ReadLine();

                 }) //Id:1-10
                 .Add("Customer", () =>
                 {
                     Console.WriteLine("Which customer do you want to update?");
                     int id = int.Parse(Console.ReadLine());
                     Console.WriteLine("Add customer name!");
                     string name = Console.ReadLine();
                     Console.WriteLine("Add customer phone number!");
                     long number = long.Parse(Console.ReadLine());
                     Console.WriteLine("Add customer address!");
                     string address = Console.ReadLine();

                     restService.Put<Customer>(new Customer { CustomerId = id, Address = address, CustomerName = name, PhoneNumber = number }, "/customer");
                     Console.WriteLine("Customer updated!");
                     Console.ReadLine();

                 }) //Id: 1-5
                 .Add("Back", ConsoleMenu.Close).Show())

                 //DELETE
                 .Add("Delete...", () => new ConsoleMenu()
                 .Add("Order", () =>
                 {
                     Console.WriteLine("Please enter the order's Id");
                     int id = int.Parse(Console.ReadLine());
                     foreach (Order order in restService.Get<Order>("/order"))
                     {
                         if (id == order.OrderId)
                         {
                             restService.Delete(id, "/order");
                         }


                     }
                     Console.WriteLine("Order deleted!");
                     Console.ReadLine();
                 }) //Id: 1-10
                 .Add("Product", () =>
                 {
                     Console.WriteLine("Please enter the product's Id");
                     int id = int.Parse(Console.ReadLine());
                     foreach (Product product in restService.Get<Product>("/product"))
                     {
                         if (id == product.ProductId)
                         {
                             restService.Delete(id, "/product");
                         }


                     }
                     Console.WriteLine("Product deleted!");
                     Console.ReadLine();
                 }) //Id:1-10
                 .Add("Customer", () =>
                 {
                     Console.WriteLine("Please enter the customer's Id");
                     int id = int.Parse(Console.ReadLine());
                     foreach (Customer customer in restService.Get<Customer>("/customer"))
                     {
                         if (id == customer.CustomerId)
                         {
                             restService.Delete(id, "/customer");
                         }


                     }
                     Console.WriteLine("Customer deleted!");
                     Console.ReadLine();
                 }) //Id: 1-5
                 .Add("Back", ConsoleMenu.Close).Show())

                 //NON-CRUDS
                 .Add("NON-CRUDS...", () => new ConsoleMenu()
                 .Add("GetOrdersByCustomername - returns the orders of the specified customer", () =>
                 {
                     Console.WriteLine("Please enter the customer's name");
                     string customername = Console.ReadLine();
                     Console.WriteLine();
                     orders = restService.Get<Order>("/shop/order-customer/" + customername);
                     foreach (Order order in orders)
                     {
                         Console.WriteLine("Order Id: " + order.OrderId + "\t Order time: " + order.OrderTime + "\t Prepaid: " + order.IsPrePaid + "\t Transport needed: " + order.IsTransportRequired);
                     }
                     Console.ReadLine();


                 }) //TESTED WITH: A.Aladár 
                 .Add("GetAddressesOfOrders - returns the orders with the addresses (if there is any)", () =>
                 {
                     IEnumerable<KeyValuePair<Order, string>> keyValuePairs = restService.Get<KeyValuePair<Order, string>>("/shop/address-order");

                     foreach (KeyValuePair<Order, string> keyValuePair in keyValuePairs)
                     {

                         Console.WriteLine("\t Order id: " + keyValuePair.Key.OrderId + "\t Address: " + keyValuePair.Value);

                     }
                     Console.ReadLine();

                 })
                 .Add("GetProductsWeNeedToTransport - returns the products which we have to deliver", () =>
                 {
                     products = restService.Get<Product>("/shop/product-transport");
                     foreach (Product product in products)
                     {
                         Console.WriteLine("Id:" + product.ProductId + "\t Name: " + product.ProductName + "\t Color: " + product.Color + "\t Size: " + product.Size + "\t Price: " + product.Price + "FT");
                     }
                     Console.ReadLine();
                 })
                 .Add("GetCustomersWithThisSize - returns the customers with the given size", () =>
                 {

                     Console.WriteLine("What is the size?");
                     int size = int.Parse(Console.ReadLine());
                     customers = restService.Get<Customer>("/shop/customer-size/" + size);
                     foreach (Customer customer in customers)
                     {
                         Console.WriteLine("Id: " + customer.CustomerId + "\t Name: " + customer.CustomerName + "\t Phone: " + customer.PhoneNumber + "\t Address: " + customer.Address);
                     }
                     Console.ReadLine();
                 }) //TESTED WITH :42
                 .Add("GetPrePaidOrdersByCustomers - returns prepaid orders with their customers", () =>
                 {
                     IEnumerable<KeyValuePair<Customer, Order>> keyValuePairs = restService.Get<KeyValuePair<Customer, Order>>("/shop/prepaid-customer");
                     foreach (KeyValuePair<Customer, Order> keyValuePair in keyValuePairs)
                     {
                         Console.WriteLine("Prepaid orders id: " + keyValuePair.Value.OrderId + "\t Customer: " + keyValuePair.Key.CustomerName);

                     }
                     Console.ReadLine();
                 })


                 .Add("Back", ConsoleMenu.Close).Show())
                 .Add("EXIT", ConsoleMenu.Close);

            menu.Show();
        }

    }
}
