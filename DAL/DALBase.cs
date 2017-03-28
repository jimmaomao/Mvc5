using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using System.Data.Entity;

namespace DAL
{
    public class DALBase<T> : IDALBase<T> where T : class, new()
    {
        protected MVCDb _db = ContextFactory.GetDb();

        public T Add(T entity)
        {
            _db.Entry<T>(entity).State = EntityState.Added;
            _db.SaveChanges();
            return entity;
        }

        public int Count(Expression<Func<T, bool>> whereLambda)
        {
            return _db.Set<T>().Count(whereLambda);
        }

        public bool Delete(T entity)
        {
            _db.Set<T>().Attach(entity);
            _db.Entry<T>(entity).State = EntityState.Deleted;
            return _db.SaveChanges() > 0;
        }

        public bool Exist(Expression<Func<T, bool>> whereLambda)
        {
            return _db.Set<T>().Any(whereLambda);
        }

        public T Find(Expression<Func<T, bool>> whereLambda)
        {
            T _entity = _db.Set<T>().FirstOrDefault<T>(whereLambda);
            return _entity;
        }

        public IQueryable<T> FindList<S>(Expression<Func<T, bool>> whereLambda, bool isAsc, Expression<Func<T, S>> orderLambda)
        {
            var _list = _db.Set<T>().Where<T>(whereLambda);
            if (isAsc)
            {
                _list.OrderBy<T, S>(orderLambda);
            }
            else
            {
                _list.OrderByDescending<T, S>(orderLambda);
            }
            return _list;
        }

        public IQueryable<T> FindPageList<S>(int pageIndex, int pageSize, out int pageCount, Expression<Func<T, bool>> whereLambda, bool isAsc, Expression<Func<T, S>> orderLambda)
        {
            var _list = _db.Set<T>().Where<T>(whereLambda);
            pageCount = _list.Count();
            if (isAsc)
            {
                _list.OrderBy<T, S>(orderLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            else
            {
                _list.OrderByDescending<T, S>(orderLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            return _list;
        }

        public bool Update(T entity)
        {
            _db.Set<T>().Attach(entity);
            _db.Entry<T>(entity).State = EntityState.Modified;
            return _db.SaveChanges() > 0;
        }
    }
}
