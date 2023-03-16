using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Mission09_ckearl2.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private BookstoreContext context;
        public EFOrderRepository(BookstoreContext temp) => context = temp;
        public IQueryable<Order> Orders => context.Orders.Include(o => o.Lines)
            .ThenInclude(li => li.Book);
        
        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(li => li.Book));

            if (order.OrderId == 0)
            {
                context.Orders.Add(order);
            }

            context.SaveChanges();
        }
    }
}