using DYLHS5_HFT_2021221.Logic;
using DYLHS5_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DYLHS5_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderLogic logic;

        public OrderController(IOrderLogic logic)
        {
            this.logic = logic;
        }

        [HttpPost] // /order
        public void CreateOne([FromBody] Order order)
        {
            logic.Create(order);
        }

        [HttpGet] // /order
        public IEnumerable<Order> GetAll()
        {
            return logic.ReadAll();
        }

        [HttpPut]
        public void UpdateOne([FromBody] Order order)
        {
            logic.Update(order);
        }

        [HttpDelete("{orderId}")] // /order/orderId
        public void Delete([FromRoute] int orderId)
        {
            logic.Delete(orderId);
        }

        [HttpGet("{orderId}")] // /order/orderId
        public Order GetOne([FromRoute] int orderId)
        {
            return logic.GetOne(orderId);
        }
    }
}
