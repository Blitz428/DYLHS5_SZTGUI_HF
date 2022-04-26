using DYLHS5_HFT_2021221.Data;
using DYLHS5_HFT_2021221.Models;
using System.Linq;

namespace DYLHS5_HFT_2021221.Repository
{
    public class OrderRepository : IOrderRepository
    {
        XYZDbContext ctx;
        public OrderRepository(XYZDbContext ctx)
        {
            this.ctx = ctx;
        }
        public IQueryable<Order> GetAll()
        {
            return ctx.Set<Order>();
        }


        public void Create(Order order)
        {
            ctx.Orders.Add(order);
            ctx.SaveChanges();
        }

        public Order ReadOne(int? orderId)
        {
            return ctx.Orders.FirstOrDefault(x => x.OrderId == orderId);
        }

        public IQueryable<Order> ReadAll()
        {
            return ctx.Orders;
        }

        public void Update(Order order)
        {
            Order old = ReadOne(order.OrderId);


            old.IsPrePaid = order.IsPrePaid;
            old.IsTransportRequired = order.IsTransportRequired;


            ctx.SaveChanges();

        }

        public void Delete(int? orderId)
        {
            ctx.Orders.Remove(ReadOne(orderId));
            ctx.SaveChanges();
        }
    }
}
