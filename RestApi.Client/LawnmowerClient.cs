using Models;

namespace RestApi.Client;

public class LawnmowerClient : ClientBase, ILawnmowerClient
{
    public LawnmowerClient(IApiConfiguration configuration, HttpClient httpClient) : base(configuration, httpClient)
    {

    }

    public async Task<LawnmowerModel> GetAsync(int id)
    {
        return await GetAsync<LawnmowerModel>($"/api/lawnmower/{id}");
    }

    public async Task<IList<LawnmowerModel>> ListAsync(int brandId)
    {
        return await GetAsync<IList<LawnmowerModel>>($"/api/lawnmower/list/{brandId}");
    }

    public async Task<int> AddAsync(LawnmowerModel model)
    {
        return await AddAsync("/api/lawnmower", model);
    }

    public async Task<int> UpdateAsync(LawnmowerModel model)
    {
        return await UpdateAsync("/api/lawnmower", model);
    }

    public async Task DeleteAsync(int id)
    {
        await DeleteAsync($"/api/lawnmower/{id}");
        return;
    }

    public async Task<IList<BrandModel>> ListBrandsAsync()
    {
        return await GetAsync<IList<BrandModel>>($"/api/lawnmower/brands");
    }
}
