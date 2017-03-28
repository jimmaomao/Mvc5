using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
namespace DAL
{
    public static class DALFactory
    {
        /// <summary>
        /// 用户类
        /// </summary>
        public static IDALUser User { get { return new DALUser(); } }
    }
}
