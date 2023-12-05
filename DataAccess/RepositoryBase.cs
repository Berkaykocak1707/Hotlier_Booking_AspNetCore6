using DataAccess.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
    {
        protected readonly RepositoryContext _context;

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
        }

        public IEnumerable<T> FindAll()
        {
            return _context.Set<T>().ToList();
        }

        public IQueryable<T> FindInclude(bool trackChanges, params Expression<Func<T, object>>[] includes)
        {
            var query = trackChanges
                ? _context.Set<T>().AsQueryable()
                : _context.Set<T>().AsNoTracking();

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return query;
        }
        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).ToList();
        }


        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
            Save();
        }


        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            Save();
        }


        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            Save();
        }


        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
