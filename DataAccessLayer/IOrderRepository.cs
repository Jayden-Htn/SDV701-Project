using DataAccessLayer;
using DataAccessLayer.Models;

public interface IOrderRepository : IRepository<Order>
{
    new void Add(Order instance);
    new void Delete(int id);
    new Order Get(int id);
    new IEnumerable<Order> List();
    new void Update(Order instance);
}