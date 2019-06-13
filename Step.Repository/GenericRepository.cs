﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Step.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        DbContext context;
        IDbSet<T> dbSet;
        public GenericRepository(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return dbSet;
        }
        public T Get(int id)
        {
            return dbSet.Find(id);
        }
        public void AddOrUpdate(T obj)
        {
            try
            {
                dbSet.AddOrUpdate(obj);
            }
            catch(Exception exc)
            {

            }
        }

        public void Delete(T obj)
        {
            try
            {
                dbSet.Remove(obj);
            }
            catch (Exception exc)
            { }
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public int Save()
        {
            try
            {
                return context.SaveChanges();
            }
            catch(Exception exc)
            {
                return -1;
            }
        }
    }
}
