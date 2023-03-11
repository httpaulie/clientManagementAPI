using Domain.Base;

namespace Infra.Data.Repository.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(long id);
        Task<IList<TEntity>> SelectAsync();
        Task<TEntity> SelectAsync(long id);
    }
}
