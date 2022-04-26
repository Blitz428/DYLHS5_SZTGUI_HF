using DYLHS5_HFT_2021221.Logic;
using DYLHS5_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DYLHS5_HFT_2021221.Endpoint.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        IShopLogic logic;

        public ShopController(IShopLogic logic)
        {
            this.logic = logic;

        }
        [HttpGet("order-customer/{customername}")] // /shop/order-customer
        public IEnumerable<Order> GetOrdersByCustomername([FromRoute] string customername)
        {
            return logic.GetOrdersByCustomername(customername);
        }
        [HttpGet("address-order")] // /shop/address-order
        public IEnumerable<KeyValuePair<Order, string>> GetAddressesOfOrders()
        {
            return logic.GetAddressesOfOrders();
        }
        [HttpGet("product-transport")] // /shop/product-transport
        public IEnumerable<Product> GetProductsWeNeedToTransport()
        {
            return logic.GetProductsWeNeedToTransport();
        }

        [HttpGet("customer-size/{size}")]  // /shop/customer-size/
        public IEnumerable<Customer> GetCustomersWithThisSize([FromRoute] int size)
        {
            return logic.GetCustomersWithThisSize(size);
        }

        [HttpGet("prepaid-customer")] // /shop/prepaid-customer
        public IEnumerable<KeyValuePair<Customer, Order>> GetPrePaidOrdersByCustomers()
        {
            return logic.GetPrePaidOrdersByCustomers();
        }

    }
}
