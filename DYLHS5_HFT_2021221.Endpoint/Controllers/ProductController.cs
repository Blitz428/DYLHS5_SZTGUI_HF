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
    public class ProductController : ControllerBase
    {
        private IProductLogic logic;
        IHubContext<SignalRHub> hub;

        public ProductController(IProductLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpPost] // /product
        public void CreateOne([FromBody] Product product)
        {
            logic.Create(product);
            hub.Clients.All.SendAsync("ProductCreated", product);
        }

        [HttpGet] // /product
        public IEnumerable<Product> GetAll()
        {
            return logic.ReadAll();
        }
        [HttpGet("{productId}")] // /product
        public Product GetOne([FromRoute] int productId)
        {
            return logic.GetOne(productId);
        }

        [HttpPut]
        public void UpdateOne([FromBody] Product product)
        {
            logic.Update(product);
            hub.Clients.All.SendAsync("ProductUpdated", product);
        }

        [HttpDelete("{productId}")] // /product/productId
        public void Delete([FromRoute] int productId)
        {
            var itemToDelete = this.logic.GetOne(productId);
            logic.Delete(productId);
            hub.Clients.All.SendAsync("ProductDeleted", itemToDelete);
        }
    }
}
