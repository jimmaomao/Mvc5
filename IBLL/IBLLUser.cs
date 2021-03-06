﻿using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface IBLLUser : IBLLBase<T_User>
    {
        /// <summary>
        /// 用户是否存在
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>布尔值</returns>
        bool Exist(string userName);

        /// <summary>
        /// 查找用户
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <returns></returns>
        T_User Find(int UserID);

        /// <summary>
        /// 查找用户
        /// </summary>
        /// <param name="UserName">用户名称</param>
        /// <returns></returns>
        T_User Find(string UserName);

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <param name="pageIndex">当前页码数</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="totalCount">总记录数</param>
        /// <param name="order">排序：0-ID升序（默认），1ID降序，2注册时间升序，3注册时间降序，4登陆时间升序，5登陆时间降序</param>
        /// <returns></returns>
        IQueryable<T_User> FindPageList(int pageIndex, int pageSize, out int totalCount, int order);
    }
}
