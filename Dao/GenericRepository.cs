﻿using System;
using System.Linq.Expressions;
using AzureAPI.Dao.IRepository;
using AzureAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace AzureAPI.Dao
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        private DbSet<T> dbSet = null;

        public GenericRepository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public async Task<T> GetById(object id)
        {
            return await dbSet.FindAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var query = dbSet.AsQueryable();
            return await query.ToListAsync(); 
        }

        public async Task<IEnumerable<T>> GetEntities(Expression<Func<T, bool>> filter,
                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
                string includeProperties)
        {
            IQueryable<T> query = dbSet;

            if(filter != null)
            {
                query.Where(filter);
            }
            

            if(includeProperties != null && includeProperties != "")
            {
                string[] splitedIncludeProperties =
                   includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var property in splitedIncludeProperties)
                {
                    query = query.Include(property);
                }
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }
 
            return await query.ToListAsync();


        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            dbSet.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public void DeleteById(object id)
        {
            T entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

    }
}
