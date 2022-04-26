using DYLHS5_HFT_2021221.Models;
using System.Linq;

namespace DYLHS5_HFT_2021221.Repository
{
    public interface ICustomerRepository
    {
        void Create(Customer customer);
        Customer ReadOne(int? customerId);
        IQueryable<Customer> ReadAll();
        void Update(Customer customer);
        void Delete(int? customerId);
        public IQueryable<Customer> GetAll();
    }
}
