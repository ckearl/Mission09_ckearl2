using System.Linq;

namespace Mission09_ckearl2.Models
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get;}
        void SaveOrder(Order order);
    }
}