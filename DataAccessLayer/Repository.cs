using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    public Repository(DbContext context)
    {
        Context = context;
    }

    protected DbContext Context { get; private set; }


    /// <summary>
    /// Creates an entity that can be used to query and save instances of the entity type" />.
    /// </summary>
    protected virtual IQueryable<TEntity> All
    {
        get
        {
            return Context.Set<TEntity>();
        }
    }

    /// <summary>
    /// Adds an entity to the context and sets the entity state to <see cref="EntityState.Added" />.
    /// Entities with the added stste will be inserted in the database when SaveChanges() is called.
    /// </summary>
    /// <param name="instance"></param>
    public virtual void Add(TEntity instance)
    {
        if (instance != null)
        {
            Context.Set<TEntity>().Add(instance);
        }
    }

    /// <summary>
    /// Gets an entity
    /// </summary>
    /// <param name="id">The entity ID</param>
    /// <returns></returns>
    public abstract TEntity Get(int id);

    /// <summary>
    /// Changes the entity state to <see cref="EntityState.Deleted" />.
    /// Entities with the deleted state will be update in the database when Save() is called.
    /// </summary>
    /// <param name="id">The entity ID</param>
    public virtual void Delete(int id)
    {
        var entity = Get(id);
        if (entity != null)
        {
            Context.Entry(entity).State = EntityState.Deleted;
        }
    }

    /// <summary>
    /// Changes the entity state to  <see cref="EntityState.Modified" />.
    /// Entities with the modified stste will be updated in the database when Save() is called.
    /// </summary>
    /// <param name="instance"></param>

    public virtual void Update(TEntity instance)
    {
        if (instance != null)
        {
            Context.Entry(instance).State = EntityState.Modified;
        }
    }

    /// <summary>
    /// Lists the entities
    /// </summary>
    /// <returns></returns>
    public virtual IEnumerable<TEntity> List()
    {
        return All.ToList();
    }
}