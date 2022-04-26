using DYLHS5_HFT_2021221.Models;
using DYLHS5_HFT_2021221.Repository;
using System.Collections.Generic;
using System.Linq;

namespace DYLHS5_HFT_2021221.Logic
{
    public class ShopLogic : IShopLogic
    {
        private IOrderRepository orderRepo;
        private IProductRepository productRepo;
        private ICustomerRepository customerRepo;

        public ShopLogic(ICustomerRepository customerRepo, IOrderRepository orderRepo, IProductRepository productRepo)
        {
            this.productRepo = productRepo;
            this.orderRepo = orderRepo;
            this.customerRepo = customerRepo;
        }

        public IEnumerable<Order> GetOrdersByCustomername(string customername) //returns the orders of the specified customer
        {

            return from order in orderRepo.ReadAll()
                   join customer in customerRepo.ReadAll()
                   on order.CustomerId equals customer.CustomerId
                   where customer.CustomerName == customername
                   select order;



        }
        public IEnumerable<KeyValuePair<Order, string>> GetAddressesOfOrders() //returns the orders with the addresses (if there is any)
        {
            return from order in orderRepo.ReadAll()
                   join customer in customerRepo.ReadAll()
                   on order.CustomerId equals customer.CustomerId
                   where customer.Address != null
                   select new KeyValuePair<Order, string>(order, customer.Address);

        }

        public IEnumerable<Product> GetProductsWeNeedToTransport() //returns the products which we have to deliver
        {
            return from product in productRepo.ReadAll()
                   join order in orderRepo.ReadAll()
                   on product.ProductId equals order.ProductId
                   where order.IsTransportRequired == true
                   select product;
        }

        public IEnumerable<Customer> GetCustomersWithThisSize(int size) //returns the customers with the given size
        {
            return from customer in customerRepo.ReadAll()
                   join order in orderRepo.ReadAll()
                   on customer.CustomerId equals order.CustomerId
                   join product in productRepo.ReadAll()
                   on order.ProductId equals product.ProductId
                   where product.Size == size
                   select customer;

        }

        public IEnumerable<KeyValuePair<Customer, Order>> GetPrePaidOrdersByCustomers() //returns prepaid orders with their customers
        {
            return from customer in customerRepo.ReadAll()
                   join order in orderRepo.ReadAll()
                   on customer.CustomerId equals order.CustomerId
                   where order.IsPrePaid == true
                   select new KeyValuePair<Customer, Order>(customer, order);



        }




    }
}
