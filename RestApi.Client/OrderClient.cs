using Models;

namespace RestApi.Client;

public class OrderClient : ClientBase, IOrderClient
{
    public OrderClient(IApiConfiguration configuration, HttpClient httpClient) : base(configuration, httpClient)
    {

    }

    public async Task<OrderModel> GetAsync(int id)
    {
        return await GetAsync<OrderModel>($"/api/order/{id}");
    }

    public async Task<IList<OrderModel>> ListAsync()
    {
        return await GetAsync<IList<OrderModel>>("/api/order");
    }

    public async Task<int> AddAsync(OrderModel model)
    {
        return await AddAsync("/api/order", model);
    }

    public async Task<int> UpdateAsync(OrderModel model)
    {
        return await UpdateAsync("/api/order", model);
    }

    public async Task DeleteAsync(int id)
    {
        await DeleteAsync($"/api/order/{id}");
        return;
    }
}
