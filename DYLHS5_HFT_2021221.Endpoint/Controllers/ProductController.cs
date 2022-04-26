using DYLHS5_HFT_2021221.Logic;
using DYLHS5_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DYLHS5_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductLogic logic;

        public ProductController(IProductLogic logic)
        {
            this.logic = logic;
        }

        [HttpPost] // /product
        public void CreateOne([FromBody] Product product)
        {
            logic.Create(product);
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
        }

        [HttpDelete("{productId}")] // /product/productId
        public void Delete([FromRoute] int productId)
        {
            logic.Delete(productId);
        }
    }
}
