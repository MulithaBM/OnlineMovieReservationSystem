using Microsoft.EntityFrameworkCore;
using OnlineMovieReservationSystem.Domain.Repository;
using OnlineMovieReservationSystem.Persistence.Data;

namespace OnlineMovieReservationSystem.Persistence.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DataContext _context;
        private readonly DbSet<TEntity> dbSet;

        public Repository(DataContext context) 
        {
            _context = context;
            dbSet = _context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Get()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> Add(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            return await dbSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> AddRange(IEnumerable<TEntity> entities)
        {
            await dbSet.AddRangeAsync(entities);
            return await dbSet.ToListAsync();
        }

        public Task<TEntity> Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Remove(TEntity entity)
        {
            //if (_context.Entry(entity).State == EntityState.Detached)
            //{
            //    dbSet.Attach(entity);
            //}
            dbSet.Remove(entity);
            return Task.FromResult(entity);
        }
    }
}
