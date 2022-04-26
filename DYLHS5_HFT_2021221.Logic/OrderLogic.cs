using DYLHS5_HFT_2021221.Models;
using DYLHS5_HFT_2021221.Repository;
using System.Linq;

namespace DYLHS5_HFT_2021221.Logic
{
    public class OrderLogic : IOrderLogic
    {
        private IOrderRepository orderRepo;

        public OrderLogic(IOrderRepository orderRepo)
        {
            this.orderRepo = orderRepo;
        }
        public IQueryable<Order> GetAll()
        {
            return orderRepo.GetAll();
        }

        public void Create(Order order)
        {

            if (order.IsTransportRequired == null || order.IsPrePaid == null)
            {
                throw new BooleanExpressionsAreNullException("One of the boolean expressions are missing.");
            }
            orderRepo.Create(order);

        }

        public void Delete(int? orderId)
        {
            orderRepo.Delete(orderId);
        }

        public IQueryable<Order> ReadAll()
        {
            return orderRepo.ReadAll();
        }

        public void Update(Order order)
        {
            orderRepo.Update(order);
        }
        public Order GetOne(int? orderId)
        {
            return orderRepo.ReadOne(orderId);
        }

    }
}
