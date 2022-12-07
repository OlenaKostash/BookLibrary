
using BookLibrary.Entities;

namespace BookLibrary.DataAccess
{
    public interface IRepository<TEntity>
    {
        IList<TEntity> GetAll();
        TEntity Get(int id);
        void Insert(TEntity entity);

    }
}
