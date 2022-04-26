using DYLHS5_HFT_2021221.Data;
using DYLHS5_HFT_2021221.Models;
using System.Linq;

namespace DYLHS5_HFT_2021221.Repository
{
    public class ProductRepository : IProductRepository
    {
        XYZDbContext ctx;
        public ProductRepository(XYZDbContext ctx)
        {
            this.ctx = ctx;
        }


        public void Create(Product product)
        {
            ctx.Products.Add(product);
            ctx.SaveChanges();
        }

        public Product ReadOne(int? productId)
        {
            return ctx.Products.FirstOrDefault(x => x.ProductId == productId);
        }

        public IQueryable<Product> ReadAll()
        {
            return ctx.Products;
        }
        public IQueryable<Product> GetAll()
        {
            return ctx.Set<Product>();
        }
        public void Update(Product product)
        {
            Product old = ReadOne(product.ProductId);

            old.Price = product.Price;
            old.Size = product.Size;
            old.Color = product.Color;
            old.ProductName = product.ProductName;


            ctx.SaveChanges();

        }

        public void Delete(int? productId)
        {
            ctx.Products.Remove(ReadOne(productId));
            ctx.SaveChanges();
        }
    }
}
