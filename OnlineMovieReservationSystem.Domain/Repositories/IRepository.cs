using OnlineMovieReservationSystem.Domain.Primitives;

namespace OnlineMovieReservationSystem.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : IAggregateRoot
    {
        //Task<TEntity> GetById(int id);
        //Task<IEnumerable<TEntity>> Get();
        //Task Add(TEntity entity);
        //Task AddRange(IEnumerable<TEntity> entities);
        //Task Remove(TEntity entity);
    }
}
