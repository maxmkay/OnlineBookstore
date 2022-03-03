using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OnlineBookstore.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private BookstoreContext context; 

        public EFOrderRepository (BookstoreContext temp)
        {
            context = temp;
        }



        public IQueryable<Order> Orders =>  context.Orders.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(x => x.Book));

            if (order.OrderId == 0)

            {
                context.Orders.Add(order);
            }
            
            context.SaveChanges();
        }
    }
}
