namespace OnlineMovieReservationSystem.Persistence.Repositories
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
