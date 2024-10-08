﻿using MvcCv.DAL.Context;
using MvcCv.DAL.Entities;
using System.Linq.Expressions;

namespace MvcCv.Repositories
{
    public class GenericRepository<T> where T : class, new()
    {
        MvcCvContext db = new MvcCvContext();

        public List<T> List()
        {
            return db.Set<T>().ToList();
        }
        public void TAdd(T p)
        {
            db.Set<T>().Add(p);
            db.SaveChanges();
        }

        public void TRemove(T p)
        {
            db.Set<T>().Remove(p);
            db.SaveChanges();
        }
        public T TGet(int id)
        {
            return db.Set<T>().Find(id);
        }
        public void TUpdate(T p) 
        {
            db.SaveChanges();
        }
        public T Find(Expression<Func<T, bool>> where)
        { 
            return db.Set<T>().FirstOrDefault(where);
        }
    }
}
