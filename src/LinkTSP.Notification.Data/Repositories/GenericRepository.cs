using LinkTSP.Notification.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace LinkTSP.Notification.Data.Repositories;

    public abstract class GenericRepository<T> where T : class
    {
        protected readonly DbContext context;
        public GenericRepository(DbContext context)
        {
            this.context = context;
        }

        protected IQueryable<T> AsQueryable()
        {
            return context.Set<T>();
        }

        protected T Insert(T entity)
        {
            context.Set<T>().Add(entity);
            return entity;
        }

        protected virtual void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.Set<T>().Update(entity);
        }

        protected void UpdateRange(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
                context.Entry(entity).State = EntityState.Modified;
        }

        protected void AddRange(IEnumerable<T> entities)
        {
            context.Set<T>().AddRange(entities);
        }

        protected IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().Where(expression);
        }

        protected IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        protected void Delete(T entity)
        {
            if (entity is IStatus status)
                status.StatusId = 0;
            Update(entity);
        }

        protected void Delete(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                if (entity is IStatus status)
                    status.StatusId = 0;
                Update(entity);
            }
        }
    }

