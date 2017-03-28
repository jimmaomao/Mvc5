using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface IBLLBase<T> where T : class, new()
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        T Add(T entity);

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

    }
}
