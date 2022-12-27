using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMovieReservationSystem.Persistence.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        public Repository(DbContext context) 
        {
            _context = context;
        }
        public void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
}
