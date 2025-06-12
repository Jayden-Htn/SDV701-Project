using Models;

namespace BusinessLayer;

public interface ILawnmowerService
{
    int Add(ILawnmowerModel model);
    Task Delete(int id);
    LawnmowerModel Get(int id);
    IList<LawnmowerModel> List(int brandId);
    int Update(ILawnmowerModel model);
    IList<BrandModel> Brands();
}