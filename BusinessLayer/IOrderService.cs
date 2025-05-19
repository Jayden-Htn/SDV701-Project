using Models;

namespace BusinessLayer;

public interface IOrderService
{
    int Add(OrderModel model);
    Task Delete(int id);
    OrderModel Get(int id);
    IList<OrderModel> List(int artistId);
    int Update(OrderModel model);
}