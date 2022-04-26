using DYLHS5_HFT_2021221.Models;
using System.Collections.Generic;

namespace DYLHS5_HFT_2021221.Logic
{
    public interface IShopLogic
    {
        IEnumerable<Order> GetOrdersByCustomername(string customername);

        IEnumerable<KeyValuePair<Order, string>> GetAddressesOfOrders();

        IEnumerable<Product> GetProductsWeNeedToTransport();

        IEnumerable<Customer> GetCustomersWithThisSize(int size);
        IEnumerable<KeyValuePair<Customer, Order>> GetPrePaidOrdersByCustomers();


    }
}
