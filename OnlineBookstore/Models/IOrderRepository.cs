using System;
using System.Linq;

namespace OnlineBookstore.Models
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }

        public void SaveOrder(Order order);
    }
}
