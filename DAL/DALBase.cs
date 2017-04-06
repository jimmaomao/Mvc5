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

        public IQueryable<T> FindLis(Expression<Func<T, bool>> whereLambda, string orderName, bool isAsc)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> FindList(Expression<Func<T, bool>> whereLambda, string orderName, bool isAsc, Expression<Func<T>> orderLambda)
        {
            var _list = _db.Set<T>().Where<T>(whereLambda);
            //if (isAsc)
            //{
            //    _list.OrderBy<T, S>(orderLambda);
            //}
            //else
            //{
            //    _list.OrderByDescending<T, S>(orderLambda);
            //}
            _list = OrderBy(_list, orderName, isAsc);
            return _list;
        }

        public IQueryable<T> FindPageList(int pageIndex, int pageSize, out int pageCount, Expression<Func<T, bool>> whereLambda, string orderName, bool isAsc)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> FindPageList(int pageIndex, int pageSize, out int pageCount, Expression<Func<T, bool>> whereLambda, string orderName, bool isAsc, Expression<Func<T>> orderLambda)
        {
            var _list = _db.Set<T>().Where<T>(whereLambda);
            pageCount = _list.Count();
            //if (isAsc)
            //{
            //    _list.OrderBy<T, S>(orderLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            //}
            //else
            //{
            //    _list.OrderByDescending<T, S>(orderLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            //}
            _list = OrderBy(_list, orderName, isAsc).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            return _list;
        }

        public bool Update(T entity)
        {
            _db.Set<T>().Attach(entity);
            _db.Entry<T>(entity).State = EntityState.Modified;
            return _db.SaveChanges() > 0;
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="source">原IQueryable</param>
        /// <param name="propertyName">排序属性名</param>
        /// <param name="isAsc">是否正序</param>
        /// <returns>排序后的IQueryable<T></returns>
        private IQueryable<T> OrderBy(IQueryable<T> source, string propertyName, bool isAsc)
        {
            if (source == null) throw new ArgumentNullException("source", "不能为空");
            if (string.IsNullOrEmpty(propertyName)) return source;
            var _parameter = Expression.Parameter(source.ElementType);
            var _property = Expression.Property(_parameter, propertyName);
            if (_property == null) throw new ArgumentNullException("propertyName", "属性不存在");
            var _lambda = Expression.Lambda(_property, _parameter);
            var _methodName = isAsc ? "OrderBy" : "OrderByDescending";
            var _resultExpression = Expression.Call(typeof(Queryable), _methodName, new Type[] { source.ElementType, _property.Type }, source.Expression, Expression.Quote(_lambda));
            return source.Provider.CreateQuery<T>(_resultExpression);
        }
    }
}
