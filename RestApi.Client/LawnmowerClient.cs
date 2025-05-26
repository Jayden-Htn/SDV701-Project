using Models;
using System.Text.Json;

namespace RestApi.Client;

public class LawnmowerClient : ClientBase, ILawnmowerClient
{
    public LawnmowerClient(IApiConfiguration configuration, HttpClient httpClient) : base(configuration, httpClient)
    {

    }

    public async Task<ILawnmowerModel> GetAsync(int id, string type)
    {
        if (type == "RideOn")
        {
            return await GetAsync<RideOnLawnmowerModel>($"/api/lawnmower/{id}");
        }
        else if (type == "Push")
        {
            return await GetAsync<PushLawnmowerModel>($"/api/lawnmower/{id}");
        }
        else
        {
            return await GetAsync<LawnmowerModel>($"/api/lawnmower/{id}");
        }
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
