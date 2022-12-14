using Microsoft.EntityFrameworkCore;
using OnlineMovieReservationSystem.Models;

namespace OnlineMovieReservationSystem.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) 
        {
            
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Session> Sessions { get; set; }
    }
}
