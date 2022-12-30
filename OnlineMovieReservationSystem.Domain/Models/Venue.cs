using OnlineMovieReservationSystem.Domain.Primitives;

namespace OnlineMovieReservationSystem.Domain.Models
{
    public class Venue : IAggregateRoot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
