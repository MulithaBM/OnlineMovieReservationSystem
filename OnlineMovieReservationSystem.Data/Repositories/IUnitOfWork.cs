using OnlineMovieReservationSystem.Domain.Repositories.MovieRepository;
using OnlineMovieReservationSystem.Domain.Repositories.VenueRepository;

namespace OnlineMovieReservationSystem.Persistence.Repositories
{
    public interface IUnitOfWork
    {
        IMovieQueryRepository MovieQueryRepository { get; }
        IMovieCommandRepository MovieCommandRepository { get; }
        IVenueQueryRepository VenueQueryRepository { get; }
        IVenueCommandRepository VenueCommandRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
