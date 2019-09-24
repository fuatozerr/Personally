﻿using Microsoft.EntityFrameworkCore;
using Personally.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Personally.DataAccess.Concrete
{
    public class EfCoreGenericRepository<T, TContext> : IRepository<T>
        where T : class
        where TContext : DbContext, new()
    {
        public void Create(T entity)
        {
            using (var context=new TContext())
            {
                context.Entry(entity).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (var context = new TContext())
            {
                context.Entry(entity).State = EntityState.Deleted;
                context.SaveChanges();
            }

        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? context.Set<T>().ToList()
                    : context.Set<T>().Where(filter).ToList();

            }
        }

        public T GetById(int id)
        {
           using(var context =new TContext())
            {
                return context.Set<T>().Find(id);
            }

        }

        public T GetOne(Expression<Func<T, bool>> filter)
        {
            using(var context=new TContext())
            {
                return context.Set<T>().Where(filter).SingleOrDefault();
            }


        }

        public void Update(T entity)
        {
            using (var context=new TContext())
            {
                 context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }

        }
    }
}