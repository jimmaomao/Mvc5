using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using IBLL;
using DAL;

namespace BLL
{
    public class BLLUser : BLLBase<T_User>, IBLLUser
    {
        public BLLUser() : base(DALFactory.User) { }

        public bool Exist(string userName)
        {
            return CurrentRepository.Exist(u => u.UserName == userName);
        }

        public T_User Find(string UserName)
        {
            return CurrentRepository.Find(u => u.UserName == UserName);
        }

        public T_User Find(int UserID)
        {
            return CurrentRepository.Find(u => u.UserId == UserID);
        }

        public IQueryable<T_User> FindPageList(int pageIndex, int pageSize, out int totalCount, int order)
        {
            bool _isAsc = true;
            string _orderName = string.Empty;
            switch (order)
            {
                case 0:
                    _isAsc = true;
                    _orderName = "UserID";
                    break;
                case 1:
                    _isAsc = false;
                    _orderName = "UserID";
                    break;
                case 2:
                    _isAsc = true;
                    _orderName = "RegistrationTime";
                    break;
                case 3:
                    _isAsc = false;
                    _orderName = "RegistrationTime";
                    break;
                case 4:
                    _isAsc = true;
                    _orderName = "LoginTime";
                    break;
                case 5:
                    _isAsc = false;
                    _orderName = "LoginTime";
                    break;
                default:
                    _isAsc = false;
                    _orderName = "UserID";
                    break;
            }
            return CurrentRepository.FindPageList(pageIndex, pageSize, out totalCount, u => true, _orderName, _isAsc);
        }
    }
}
