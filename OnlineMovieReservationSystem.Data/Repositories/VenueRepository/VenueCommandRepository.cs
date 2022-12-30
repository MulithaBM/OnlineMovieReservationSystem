using Microsoft.EntityFrameworkCore;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Domain.Repositories.VenueRepository;
using OnlineMovieReservationSystem.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMovieReservationSystem.Persistence.Repositories.VenueRepository
{
    public class VenueCommandRepository : IVenueCommandRepository
    {
        private readonly IDataContext _context;
        private readonly DbSet<Venue> dbSet;

        public VenueCommandRepository(IDataContext context)
        {
            _context = context;
            dbSet = _context.Venues;
        }

        public async Task Add(Venue venue)
        {
            await dbSet.AddAsync(venue);
        }

        public async Task AddRange(IEnumerable<Venue> venues)
        {
            await dbSet.AddRangeAsync(venues);
        }

        public Task Remove(Venue venue)
        {
            dbSet.Remove(venue);
            return Task.CompletedTask;
        }
    }
}
