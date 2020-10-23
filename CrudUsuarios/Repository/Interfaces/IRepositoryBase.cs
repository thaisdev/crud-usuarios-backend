using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CrudUsuarios.Repository.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<IQueryable<T>> FindAsync(Expression<Func<T, bool>> exp);
        Task<IQueryable<T>> FindAsync();

        EntityEntry<T> Attach(T entity);
        IQueryable<T> Find(Expression<Func<T, bool>> exp);

        void Delete(T entity);
        void Insert(T entity);
        void Update(T entity);
        Task<T> GetAsync(Guid id);
        int SaveChanges();
    }
}
