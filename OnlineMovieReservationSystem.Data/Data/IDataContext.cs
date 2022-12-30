using Microsoft.EntityFrameworkCore;
using OnlineMovieReservationSystem.Domain.Models;

namespace OnlineMovieReservationSystem.Persistence.Data
{
    public interface IDataContext : IDisposable
    {
        DbSet<Movie> Movies { get; set; }
        DbSet<Venue> Venues { get; set; }
        DbSet<Session> Sessions { get; set; }
        //DbSet<T> Set<T>() where T : class;
    }
}
