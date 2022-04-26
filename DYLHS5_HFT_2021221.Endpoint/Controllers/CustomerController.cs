using DYLHS5_HFT_2021221.Logic;
using DYLHS5_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DYLHS5_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerLogic logic;

        public CustomerController(ICustomerLogic logic)
        {
            this.logic = logic;
        }

        [HttpPost] // /customer
        public void CreateOne([FromBody] Customer customer)
        {
            logic.Create(customer);
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
        }

        [HttpDelete("{customerId}")] // /customer/customerId
        public void Delete([FromRoute] int? customerId)
        {
            logic.Delete(customerId);
        }

        [HttpGet("{customerId}")] // /customer/customerId
        public Customer GetOne([FromRoute] int? customerId)
        {
            return logic.GetOne(customerId);
        }
    }
}
