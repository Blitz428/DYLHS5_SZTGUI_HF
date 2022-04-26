using DYLHS5_HFT_2021221.Models;
using DYLHS5_HFT_2021221.Repository;
using System.Linq;

namespace DYLHS5_HFT_2021221.Logic
{
    public class CustomerLogic : ICustomerLogic
    {
        private ICustomerRepository customerRepo;

        public CustomerLogic(ICustomerRepository customerRepo)
        {
            this.customerRepo = customerRepo;
        }
        public void Create(Customer customer)
        {
            if (customer.CustomerName == null)
            {
                throw new ProductOrCustomerNameMissingException("Missing cutomer name");
            }
            customerRepo.Create(customer);
        }

        public void Delete(int? customerId)
        {
            customerRepo.Delete(customerId);
        }

        public IQueryable<Customer> GetAll()
        {
            return customerRepo.GetAll();
        }

        public Customer GetOne(int? customerId)
        {
            return customerRepo.ReadOne(customerId);
        }

        public IQueryable<Customer> ReadAll()
        {
            return customerRepo.ReadAll();
        }

        public void Update(Customer customer)
        {
            customerRepo.Update(customer);
        }

    }
}

