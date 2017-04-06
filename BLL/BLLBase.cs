using IBLL;
using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// 服务基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BLLBase<T> : IBLLBase<T> where T : class, new()
    {
        protected IDALBase<T> CurrentRepository { get; set; }
        public BLLBase(IDALBase<T> currentRepository) { CurrentRepository = currentRepository; }
        public T Add(T entity)
        {
            return CurrentRepository.Add(entity);
        }

        public bool Delete(T entity)
        {
            return CurrentRepository.Delete(entity);
        }

        public bool Update(T entity)
        {
            return CurrentRepository.Update(entity);
        }
    }
}
