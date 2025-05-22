using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer;

public class LawnmowerRepository : Repository<Lawnmower>, ILawnmowerRepository
{
    public LawnmowerRepository(ModelContext context) : base(context)
    {
    }

    /// <summary>
    /// Gets a lawnmower
    /// </summary>
    /// <param name="id">The lawnmower ID</param>
    /// <returns></returns>
    public override Lawnmower Get(int id)
    {
        return All.FirstOrDefault(a => a.Id == id);
    }

    /// <summary>
    /// Lists the lawnmowers
    /// </summary>
    /// <returns></returns>
    public override IEnumerable<Lawnmower> List()
    {
        return All.Include(l=>l.Brand).ToList();
    }
}