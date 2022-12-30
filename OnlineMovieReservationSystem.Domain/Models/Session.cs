using OnlineMovieReservationSystem.Domain.Primitives;

namespace OnlineMovieReservationSystem.Domain.Models
{
    public class Session : IAggregateRoot
    {
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public Venue Venue { get; set; }
    }
}
