using Domain.Base;
using Infra.Data.Context;
using Infra.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ClientDbContext _context;

        public BaseRepository(ClientDbContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(TEntity obj)
        {
            await _context.Set<TEntity>().AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<TEntity>> SelectAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> SelectAsync(long id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
    }
}
