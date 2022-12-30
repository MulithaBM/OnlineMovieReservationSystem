using OnlineMovieReservationSystem.Domain.Models;

namespace OnlineMovieReservationSystem.Domain.Repositories.VenueRepository
{
    public interface IVenueQueryRepository : IRepository<Venue>
    {
        Task<IEnumerable<Venue>> Get();
        Task<Venue> GetById(int id);
    }
}
