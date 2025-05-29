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

    /// <summary>
    /// Lists the product brands
    /// </summary>
    /// <returns></returns>
    public virtual IEnumerable<Brand> Brands()
    {
        return All.Select(l => l.Brand).Distinct().ToList();
    }

    /// <summary>
    /// Adds an entity to the context and sets the entity state to <see cref="EntityState.Added" />.
    /// Entities with the added stste will be inserted in the database when SaveChanges() is called.
    /// </summary>
    /// <param name="instance"></param>
    public virtual void Add(ILawnmower instance)
    {
        if (instance != null)
        {
            if (instance is PushLawnmower)
            {
                Context.Set<PushLawnmower>().Add((PushLawnmower)instance);
            }
            else if (instance is RideOnLawnmower)
            {
                Context.Set<RideOnLawnmower>().Add((RideOnLawnmower)instance);
            }
            else
            {
                Context.Set<Lawnmower>().Add((Lawnmower)instance);
            }
        }
    }
}