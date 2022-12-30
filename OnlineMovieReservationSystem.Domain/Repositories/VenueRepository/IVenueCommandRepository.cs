using OnlineMovieReservationSystem.Domain.Models;

namespace OnlineMovieReservationSystem.Domain.Repositories.VenueRepository
{
    public interface IVenueCommandRepository : IRepository<Venue>
    {
        Task Add(Venue venue);
        Task AddRange(IEnumerable<Venue> venues);
        Task Remove(Venue venue);
    }
}
