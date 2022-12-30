//using Microsoft.EntityFrameworkCore;
//using OnlineMovieReservationSystem.Domain.Primitives;
//using OnlineMovieReservationSystem.Domain.Repository;
//using OnlineMovieReservationSystem.Persistence.Data;

//namespace OnlineMovieReservationSystem.Persistence.Repository
//{
//    public class Repository<TEntity> : IRepository<TEntity> where TEntity : IAggregateRoot
//    {
//        protected readonly DataContext _context;
//        private readonly DbSet<TEntity> dbSet;

//        public Repository(DataContext context) 
//        {
//            _context = context;
//            dbSet = _context.Set<TEntity>();
//        }

//        public Repository()
//        {
//        }

//        public async Task<IEnumerable<TEntity>> Get()
//        {
//            return await dbSet.ToListAsync();
//        }

//        public async Task<TEntity> GetById(int id)
//        {
//            return await dbSet.FindAsync(id);
//        }

//        public async Task Add(TEntity entity)
//        {
//            await dbSet.AddAsync(entity);
//        }

//        public async Task AddRange(IEnumerable<TEntity> entities)
//        {
//            await dbSet.AddRangeAsync(entities);
//        }

//        public Task<TEntity> Update(TEntity entity)
//        {
//            throw new NotImplementedException();
//        }

//        public Task Remove(TEntity entity)
//        {
//            //if (_context.Entry(entity).State == EntityState.Detached)
//            //{
//            //    dbSet.Attach(entity);
//            //}
//            dbSet.Remove(entity);
//            return Task.FromResult(entity);
//        }
//    }
//}
