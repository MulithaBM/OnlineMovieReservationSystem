namespace OnlineMovieReservationSystem.Domain.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> Get();
        Task Add(TEntity entity);
        Task AddRange(IEnumerable<TEntity> entities);
        Task<TEntity> Update(TEntity entity);
        Task Remove(TEntity entity);
    }
}
