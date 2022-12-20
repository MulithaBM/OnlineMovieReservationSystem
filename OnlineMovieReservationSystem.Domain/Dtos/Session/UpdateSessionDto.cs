namespace OnlineMovieReservationSystem.Domain.Dtos.Session
{
    public class UpdateSessionDto
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int VenueId { get; set; }
    }
}
