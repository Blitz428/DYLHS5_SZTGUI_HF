using DYLHS5_HFT_2021221.Models;
using System.Collections.Generic;
using System.Linq;

namespace DYLHS5_HFT_2021221.Logic
{
    public interface IProductLogic
    {
        void Create(Product product);
        IQueryable<Product> ReadAll();
        void Update(Product product);
        void Delete(int? productId);
        IQueryable<Product> GetAll();
        Product GetOne(int? productId);

        IEnumerable<Product> ProductsWithThisCustomer(string customerName);
    }
}
