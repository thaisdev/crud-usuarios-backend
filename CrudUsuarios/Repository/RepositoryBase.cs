using CrudUsuarios.Context;
using CrudUsuarios.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CrudUsuarios.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected CrudUserContext Context { get; set; }

        public RepositoryBase(CrudUserContext context) => Context = context;

        public IQueryable<T> Find(Expression<Func<T, bool>> exp)
        {
            var iquery = Context.Set<T>().Where(exp).ToList();
            return iquery.AsQueryable();
        }

        public async Task<IQueryable<T>> FindAsync(Expression<Func<T, bool>> exp)
        {
            var iQueryableResult = await Context.Set<T>().Where(exp).ToListAsync();
            return iQueryableResult.AsQueryable();
        }

        public EntityEntry<T> Attach(T entity)
        {
            return Context.Attach(entity);
        }

        public async Task<IQueryable<T>> FindAsync()
        {
            var iQueryableResult = await Context.Set<T>().ToListAsync();
            return iQueryableResult.AsQueryable();
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public void Insert(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }

        public int SaveChanges()
        {
            try
            {
                return Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual async Task<T> GetAsync(Guid id)
        {
            return await Context.Set<T>().FindAsync(id);
        }
    }
}
