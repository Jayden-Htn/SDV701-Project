using DataAccessLayer;
using DataAccessLayer.Models;

public interface ILawnmowerRepository : IRepository<Lawnmower>
{
    new void Add(ILawnmower instance);
    IEnumerable<Brand> Brands();
    new void Delete(int id);
    new Lawnmower Get(int id);
    new IEnumerable<Lawnmower> List();
    new void Update(Lawnmower instance);
}