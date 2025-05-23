using Models;

namespace BusinessLayer;

public interface ILawnmowerService
{
    int Add(LawnmowerModel model);
    Task Delete(int id);
    LawnmowerModel Get(int id);
    IList<LawnmowerModel> List();
    int Update(LawnmowerModel model);
    IList<BrandModel> Brands();
}