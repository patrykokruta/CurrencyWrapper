using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrencyWrapper.Common.UnitOfWork.Repository
{
    public class Repository<T> : IDisposable, IRepository<T> where T : class
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Add<T>(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.AddRange(entities);
        }

        public void Delete(T entity)
        {
            _context.Remove<T>(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _context.RemoveRange(entities);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public T Get(int id)
        {
            return _context.Find<T>(id);
        }

        public IQueryable<T> GetAll(params System.Linq.Expressions.Expression<Func<T, object>>[] includes)
        {
            return includes.Aggregate(_context.Set<T>().AsQueryable(), (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
