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
    public class CustomerController : ControllerBase
    {
        private ICustomerLogic logic;

        IHubContext<SignalRHub> hub;

        public CustomerController(ICustomerLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpPost] // /customer
        public void CreateOne([FromBody] Customer customer)
        {
            logic.Create(customer);
            hub.Clients.All.SendAsync("CustomerCreated", customer);
        }

        [HttpGet] // /customer
        public IEnumerable<Customer> GetAll()
        {
            return logic.ReadAll();
        }

        [HttpPut]
        public void UpdateOne([FromBody] Customer customer)
        {
            logic.Update(customer);
            hub.Clients.All.SendAsync("CustomerUpdated", customer);
        }

        [HttpDelete("{customerId}")] // /customer/customerId
        public void Delete([FromRoute] int? customerId)
        {
            var itemToDelete = this.logic.GetOne(customerId);
            logic.Delete(customerId);
            hub.Clients.All.SendAsync("CustomerDeleted", itemToDelete);
        }

        [HttpGet("{customerId}")] // /customer/customerId
        public Customer GetOne([FromRoute] int? customerId)
        {
            return logic.GetOne(customerId);
        }
    }
}
