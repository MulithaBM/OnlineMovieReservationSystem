using OnlineMovieReservationSystem.Models;

namespace OnlineMovieReservationSystem.Data
{
    public class MovieDB
    {
        private static List<Movie>? Movies = new();

        public Movie GetSingleMovie(int id)
        {
            return Movies.FirstOrDefault(x => x.Id == id);
        }

        public List<Movie> GetAllMovies()
        {
            return Movies;
        }
        public List<Movie> AddMovie(Movie movie)
        {
            Movies.Add(movie);
            Console.WriteLine(Movies.Count);
            return Movies;
        }

        // Update movie

        public List<Movie> DeleteMovie(int id)
        {
            Movie movie = Movies.First(x => x.Id == id);
            Movies.Remove(movie);
            return Movies;
        }
    }
}
