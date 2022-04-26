using DYLHS5_HFT_2021221.Data;
using DYLHS5_HFT_2021221.Models;
using System.Linq;

namespace DYLHS5_HFT_2021221.Repository
{
    public class CustomerRepository :  ICustomerRepository
    {
        XYZDbContext ctx;
        public CustomerRepository(XYZDbContext ctx)
        {
            this.ctx = ctx;
        }
        public IQueryable<Customer> GetAll()
        {
            return ctx.Set<Customer>();
        }
        public void Create(Customer customer) //C
        {
            ctx.Customers.Add(customer);
            ctx.SaveChanges();
        }

        public void Delete(int? customerId) //D
        {ctx.Customers.Remove(ReadOne(customerId));
            ctx.SaveChanges();
        }

        public IQueryable<Customer> ReadAll() //R1
        {
            return ctx.Customers;
        }

        public Customer ReadOne(int? customerId) //R2
        {
            return ctx.Customers.FirstOrDefault(x => x.CustomerId == customerId);
        }

        public void Update(Customer customer) //U
        {
            Customer old = ReadOne(customer.CustomerId);

            old.CustomerName=customer.CustomerName;
            old.Address=customer.Address;
            old.PhoneNumber=customer.PhoneNumber;

            ctx.SaveChanges();
        }
    }
}
