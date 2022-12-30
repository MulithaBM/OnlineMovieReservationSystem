using OnlineMovieReservationSystem.Domain.Repositories.MovieRepository;
using OnlineMovieReservationSystem.Domain.Repositories.VenueRepository;
using OnlineMovieReservationSystem.Persistence.Data;
using OnlineMovieReservationSystem.Persistence.Repositories.MovieRepository;
using OnlineMovieReservationSystem.Persistence.Repositories.VenueRepository;

namespace OnlineMovieReservationSystem.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private IMovieQueryRepository _movieQueryRepository;
        private IMovieCommandRepository _movieCommandRepository;
        private IVenueQueryRepository _venueQueryRepository;
        private IVenueCommandRepository _venueCommandRepository;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IMovieQueryRepository MovieQueryRepository
        {
            get { return _movieQueryRepository ??= new MovieQueryRepository(_context); }
        }

        public IMovieCommandRepository MovieCommandRepository
        {
            get { return _movieCommandRepository ??= new MovieCommandRepository(_context); }
        }

        public IVenueQueryRepository VenueQueryRepository
        {
            get { return _venueQueryRepository ??= new VenueQueryRepository(_context); }
        }

        public IVenueCommandRepository VenueCommandRepository
        {
            get { return _venueCommandRepository ??= new VenueCommandRepository(_context); }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        //public IMovieQueryRepository MovieQueryRepository
        //{
        //    get { return movieQueryRepository ??= new MovieQueryRepository(_context); }
        //}

        //public IMovieCommandRepository MovieCommandRepository
        //{
        //    get { return movieCommandRepository ??= new MovieCommandRepository(_context); }
        //}

        //private readonly IDataContext _context;
        //private readonly IRepository<Movie> _movieRepository;
        //private readonly IRepository<Venue> _venueRepository;
        //private readonly IRepository<Session> _sessionRepository;

        //public UnitOfWork(IDataContext context)
        //{
        //    _context = context;
        //}

        //public IRepository<Movie> MovieRepository
        //{
        //    get
        //    {
        //        _movieRepository ??= new Repository<Movie>();
        //        return _movieRepository;
        //    }
        //}

        //public IRepository<Venue> VenueRepository
        //{
        //    get
        //    {
        //        _venueRepository ??= new Repository<Venue>();
        //        return _venueRepository;
        //    }
        //}

        //public IRepository<Session> SessionRepository
        //{
        //    get
        //    {
        //        _sessionRepository ??= new Repository<Session>();
        //        return _sessionRepository;
        //    }
        //}

        //public void Save()
        //{
        //    SaveChanges();
        //}

        //private bool disposed = false;

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!this.disposed)
        //    {
        //        if (disposing)
        //        {
        //            _context.Dispose();
        //        }
        //    }
        //    this.disposed = true;
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}
    }
}

