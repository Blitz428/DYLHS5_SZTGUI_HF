using DYLHS5_HFT_2021221.Endpoint.Services;
using DYLHS5_HFT_2021221.Logic;
using DYLHS5_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace DYLHS5_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderLogic logic;
        IHubContext<SignalRHub> hub;

        public OrderController(IOrderLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpPost] // /order
        public void CreateOne([FromBody] Order order)
        {
            logic.Create(order);
            hub.Clients.All.SendAsync("OrderCreated", order);
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
            hub.Clients.All.SendAsync("OrderUpdated", order);

        }

        [HttpDelete("{orderId}")] // /order/orderId
        public void Delete([FromRoute] int orderId)
        {
            var itemToDelete = this.logic.GetOne(orderId);
            logic.Delete(orderId);
            hub.Clients.All.SendAsync("OrderDeleted", itemToDelete);
        }

        [HttpGet("{orderId}")] // /order/orderId
        public Order GetOne([FromRoute] int orderId)
        {
            return logic.GetOne(orderId);
        }
    }
}
