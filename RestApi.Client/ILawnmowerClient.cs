using Models;

namespace RestApi.Client;

public interface ILawnmowerClient
{
    Task<int> AddAsync(LawnmowerModel model);
    Task DeleteAsync(int id);
    Task<ILawnmowerModel> GetAsync(int id, string type);
    Task<IList<LawnmowerModel>> ListAsync(int brandId);
    Task<IList<BrandModel>> ListBrandsAsync();
    Task<int> UpdateAsync(LawnmowerModel model);
}