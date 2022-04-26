using DYLHS5_HFT_2021221.Models;
using DYLHS5_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DYLHS5_HFT_2021221.Logic
{
    public class ProductLogic : IProductLogic
    {
        private IProductRepository productRepo;
        public ProductLogic(IProductRepository repo)
        {
            this.productRepo = repo;
        }
        public IQueryable<Product> GetAll()
        {
            return productRepo.GetAll();
        }

        public void Create(Product product)
        {
            if (product.ProductName == null)
            {
                throw new ProductOrCustomerNameMissingException("Product name missing!");
            }
            productRepo.Create(product);
        }

        public void Delete(int? productId)
        {
            productRepo.Delete(productId);
        }

        public IQueryable<Product> ReadAll()
        {
            return productRepo.ReadAll();
        }

        public void Update(Product product)
        {
            productRepo.Update(product);
        }

        public Product GetOne(int? productId)
        {
            return productRepo.ReadOne(productId);
        }

        public IEnumerable<Product> ProductsWithThisCustomer(string customerName)
        {
            throw new NotImplementedException();
        }
    }
}
