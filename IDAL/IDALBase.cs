using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IDALBase<T>
    {

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>新增后的数据实体</returns>
        T Add(T entity);

        /// <summary>
        /// 查询记录数
        /// </summary>
        /// <param name="whereLambda">lamada表达式</param>
        /// <returns>记录数</returns>
        int Count(Expression<Func<T, bool>> whereLambda);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>是否成功</returns>
        bool Update(T entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>是否成功</returns>
        bool Delete(T entity);

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="whereLambda">查询表达式</param>
        /// <returns>布尔值</returns>
        bool Exist(Expression<Func<T, bool>> whereLambda);

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="whereLambda">查询表达式</param>
        /// <returns>实体</returns>
        T Find(Expression<Func<T, bool>> whereLambda);

        /// <summary>
        /// 查询数据列表
        /// </summary>
        /// <typeparam name="S">排序类型</typeparam>
        /// <param name="whereLambda">查询表达式</param>
        /// <param name="isAsc">是否升序</param>
        /// <param name="orderLambda">排序表达式</param>
        /// <returns></returns>
        IQueryable<T> FindList<S>(Expression<Func<T, bool>> whereLambda, bool isAsc, Expression<Func<T, S>> orderLambda);

        /// <summary>
        /// 查询分页数据列表
        /// </summary>
        /// <typeparam name="S">排序类型</typeparam>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageCount">总记录数</param>
        /// <param name="whereLambda">查询条件</param>
        /// <param name="isAsc">是否升序</param>
        /// <param name="orderLambda">排序表达式</param>
        /// <returns></returns>
        IQueryable<T> FindPageList<S>(int pageIndex, int pageSize, out int pageCount, Expression<Func<T, bool>> whereLambda, bool isAsc, Expression<Func<T, S>> orderLambda);

    }
}
