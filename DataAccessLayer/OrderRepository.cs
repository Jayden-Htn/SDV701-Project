using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(ModelContext context) : base(context)
    {
    }

    /// <summary>
    /// Gets an order
    /// </summary>
    /// <param name="id">The order ID</param>
    /// <returns></returns>
    public override Order Get(int id)
    {
        return All.FirstOrDefault(a => a.Id == id);
    }

    /// <summary>
    /// Lists the orders
    /// </summary>
    /// <returns></returns>
    public virtual IEnumerable<Order> List()
    {
        return All.ToList();
    }
}