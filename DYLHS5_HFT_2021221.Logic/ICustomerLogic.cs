using DYLHS5_HFT_2021221.Models;
using System.Linq;

namespace DYLHS5_HFT_2021221.Logic
{
    public interface ICustomerLogic
    {
        void Create(Customer customer);
        IQueryable<Customer> ReadAll();
        void Update(Customer customer);
        void Delete(int? customerId);
        IQueryable<Customer> GetAll();
        Customer GetOne(int? customerId);
    }
}
