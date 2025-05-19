
namespace DataAccessLayer
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity instance);
        void Delete(int id);
        TEntity Get(int id);
        IEnumerable<TEntity> List();
        void Update(TEntity instance);
    }
}