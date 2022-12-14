namespace OnlineMovieReservationSystem.Models
{
    public class Session
    {
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public Venue Venue { get; set; }
    }
}
