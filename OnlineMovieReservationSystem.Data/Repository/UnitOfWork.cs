using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Persistence.Data;

namespace OnlineMovieReservationSystem.Persistence.Repository
{
    public class UnitOfWork : IDisposable
    {
        private readonly DataContext _context;
        private Repository<Movie> _movieRepository;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }
        public Repository<Movie> MovieRepository
        {
            get
            {
                _movieRepository ??= new Repository<Movie>(_context);

                return _movieRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
