namespace OnlineMovieReservationSystem.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
        public List<string> Cast { get; set; } = new List<string>();
        public string Type { get; set; } = string.Empty;
        public int Duration { get; set; }
        public string ReleaseDate { get; set; } = string.Empty;
    }
}
