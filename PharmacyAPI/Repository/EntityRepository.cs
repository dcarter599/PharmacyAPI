using Microsoft.EntityFrameworkCore;

namespace PharmacyAPI.Repository
{
    public class EntityRepository<T> : IEntityRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public EntityRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T?> GetAsync(int Id)
        {
            return await _dbSet.FindAsync(Id);
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public async Task UpdateAsync(T oldEntity, T entity)
        {
            _context.Entry(oldEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }
    }
}
