using OnlineMovieReservationSystem.Domain.Primitives;

namespace OnlineMovieReservationSystem.Domain.Models
{
    public class Movie : IAggregateRoot
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public string Cast { get; set; }
        //public List<Actor> Cast { get; set; }
        public string Type { get; set; }
        public int Duration { get; set; }
        public string ReleaseDate { get; set; }
    }
}
