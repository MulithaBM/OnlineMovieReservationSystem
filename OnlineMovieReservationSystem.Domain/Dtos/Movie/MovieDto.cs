namespace OnlineMovieReservationSystem.Domain.Dtos.Movie
{
    public class MovieDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public string Cast { get; set; }
        public string Type { get; set; }
        public int Duration { get; set; }
        public string ReleaseDate { get; set; }
    }
}
