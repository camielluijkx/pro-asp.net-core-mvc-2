using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SportsStore.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private ApplicationDbContext context;

        public EFOrderRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Order> Orders => context.Orders
            .Include(o => o.Lines) // load related data from order
            .ThenInclude(l => l.Product); // load related data from cartline

        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(l => l.Product)); // do not save products attached to line

            if (order.OrderID == 0) // only new orders and lines are saved
            {
                context.Orders.Add(order);
            }

            context.SaveChanges();
        }
    }
}