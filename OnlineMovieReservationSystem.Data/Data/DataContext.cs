using Microsoft.EntityFrameworkCore;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Persistence.Configurations;
using OnlineMovieReservationSystem.Persistence.Repositories;

namespace OnlineMovieReservationSystem.Persistence.Data
{
    public class DataContext : DbContext, IDataContext, IUnitOfWork
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Session> Sessions { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
        }

        //public DataContext()
        //{
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieEntityTypeConfiguration).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public async Task<int> SaveChangesAsync()
        {
            Console.WriteLine("SaveChangesAsync called");
            return await base.SaveChangesAsync();
        }
    }
}
