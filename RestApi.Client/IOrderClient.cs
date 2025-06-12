using Models;

namespace RestApi.Client;

public interface IOrderClient
{
    Task<int> AddAsync(OrderModel model);
    Task DeleteAsync(int id);
    Task<OrderModel> GetAsync(int id);
    Task<IList<OrderModel>> ListAsync();
    Task<int> UpdateAsync(OrderModel model);
}