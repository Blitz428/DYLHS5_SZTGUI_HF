using DYLHS5_HFT_2021221.Models;
using System.Linq;

namespace DYLHS5_HFT_2021221.Repository
{
    public interface IProductRepository
    {
        void Create(Product product);
        Product ReadOne(int? productId);
        IQueryable<Product> ReadAll();
        void Update(Product product);
        void Delete(int? productId);
        public IQueryable<Product> GetAll();
    }
}
