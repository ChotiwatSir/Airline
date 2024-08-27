using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToToAirline.Context;
using ToToAirline.IRepository;

namespace ToToAirline.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ContextDb _context;

        public Repository(ContextDb context)
        {
            _context = context;
        }
        public IQueryable<TEntity> Table => _context.Set<TEntity>();

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
        }

        public void Insert(TEntity entity)
        {
            _context.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);
        }
    }
}