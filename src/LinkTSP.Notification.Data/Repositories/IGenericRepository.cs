using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LinkTSP.Notification.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LinkTSP.Notification.Data.Repositories
{
    public interface IGenericRepository<T> where T : class
    {

        IQueryable<T> AsQueryable();

        T Insert(T entity);

        void Update(T entity);

        void UpdateRange(IEnumerable<T> entities);

        void AddRange(IEnumerable<T> entities);

        IEnumerable<T> Find(Expression<Func<T, bool>> expression);

        IEnumerable<T> GetAll();

        void Delete(T entity);

        void Delete(IEnumerable<T> entities);
    }
}
