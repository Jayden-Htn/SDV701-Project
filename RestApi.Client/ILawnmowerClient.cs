using Models;

namespace RestApi.Client;

public interface ILawnmowerClient
{
    Task<int> AddAsync(LawnmowerModel model);
    Task DeleteAsync(int id);
    Task<LawnmowerModel> GetAsync(int id);
    Task<IList<LawnmowerModel>> ListAsync();
    Task<IList<BrandModel>> ListBrandsAsync();
    Task<int> UpdateAsync(LawnmowerModel model);
}