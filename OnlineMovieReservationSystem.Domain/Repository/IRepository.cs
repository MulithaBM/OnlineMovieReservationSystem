namespace OnlineMovieReservationSystem.Domain.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> Get();
        Task<IEnumerable<TEntity>> Add(TEntity entity);
        Task<IEnumerable<TEntity>> AddRange(IEnumerable<TEntity> entities);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Remove(TEntity entity);
    }
}
