using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{

    /// <summary>
    /// 上下文仓库（看CallContext，MSDN中讲CallContext提供对每个逻辑
    /// 执行线程都唯一的数据槽，而在WEB程序里，每一个请求恰巧
    /// 就是一个逻辑线程所以可以使用CallContext来实现
    /// 单个请求之内的DbContext单例。）
    /// </summary>
    public class ContextFactory
    {
        public static MVCDb GetDb()
        {
            MVCDb _db = CallContext.GetData("MVCDb") as MVCDb;
            if (_db == null)
            {
                _db = new MVCDb();
                CallContext.SetData("MVCDb", _db);
            }
            return _db;
        }
    }
}
