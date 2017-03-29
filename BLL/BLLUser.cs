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
       // public BLLUser():base(DALFactory.User) { }

        public bool Exist(string userName)
        {
            return false;
        }

        public T_User Find(int UserID)
        {
           
        }

        public IQueryable<T_User> FindPageList(int pageIndex, int pageSize, out int totalCount, int order)
        {
            throw new NotImplementedException();
        }

        public UserService() : base(RepositoryFactory.UserRepository) { }

        public bool Exist(string userName) { return CurrentRepository.Exist(u => u.UserName == userName); }

        public User Find(int userID) { return CurrentRepository.Find(u => u.UserID == userID); }

        public User Find(string userName) { return CurrentRepository.Find(u => u.UserName == userName); }

        public IQueryable<User> FindPageList(int pageIndex, int pageSize, out int totalRecord, int order)
        {
            switch (order)
            {
                case 0: return CurrentRepository.FindPageList(pageIndex, pageSize, out totalRecord, u => true, true, u => u.UserID);
                case 1: return CurrentRepository.FindPageList(pageIndex, pageSize, out totalRecord, u => true, false, u => u.UserID);
                case 2: return CurrentRepository.FindPageList(pageIndex, pageSize, out totalRecord, u => true, true, u => u.RegistrationTime);
                case 3: return CurrentRepository.FindPageList(pageIndex, pageSize, out totalRecord, u => true, false, u => u.RegistrationTime);
                case 4: return CurrentRepository.FindPageList(pageIndex, pageSize, out totalRecord, u => true, true, u => u.LoginTime);
                case 5: return CurrentRepository.FindPageList(pageIndex, pageSize, out totalRecord, u => true, false, u => u.LoginTime);
                default: return CurrentRepository.FindPageList(pageIndex, pageSize, out totalRecord, u => true, true, u => u.UserID);
            }
        }
}
