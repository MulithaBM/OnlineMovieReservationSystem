using Microsoft.EntityFrameworkCore;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Persistence.Configurations;

namespace OnlineMovieReservationSystem.Persistence.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) 
        {
            
        }

        public DataContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieEntityTypeConfiguration).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Session> Sessions { get; set; }
    }
}
