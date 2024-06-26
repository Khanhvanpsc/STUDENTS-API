﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace lib.data
{
    public abstract class RepositoryBase<T> where T : class
    {
        protected readonly ApplicationDbContext _dbcontext;
        protected readonly DbSet<T> dbset;

        protected RepositoryBase(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
            _dbcontext.ChangeTracker.Clear();
            dbset = _dbcontext.Set<T>();
        }

        public virtual void Add(T entity)
        {
            dbset.Add(entity);
        }

        public virtual async Task AddAsync(T entity)
        {
          await  dbset.AddAsync(entity);
        }

        public virtual void Update(T entity)
        {
            dbset.Attach(entity);
            _dbcontext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            dbset.Remove(entity);
        }

        public virtual void DeleteL(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbset.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbset.Remove(obj);
        }

        public virtual int Count(Expression<Func<T, bool>> where)
        {
            return dbset.Count<T>(where);
        }

        public virtual IEnumerable<T> GetList(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "",
            int skip = 0,
            int take = 0)
        {
            IQueryable<T> query = dbset;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip > 0)
            {
                query = query.Skip(skip);
            }

            if (take > 0)
            {
                query = query.Take(take);
            }

            return query.ToList();
        }

        public virtual T GetById(object id)
        {
            return dbset.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).ToList();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).FirstOrDefault<T>();
        }

        public virtual bool Any(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).Any<T>();
        }

        public int Complete()
        {
            return _dbcontext.SaveChanges();
        }
    }
}
