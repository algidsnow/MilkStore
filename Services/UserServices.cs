using BookStoreManagementCodeFirst;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public  class UserServices : IUserServices
    {
        IUserLoginRepository _UserLogin;
        public UserServices(IUserLoginRepository UserLogin)
        {
            _UserLogin = UserLogin;
        }
        public Users checkLogin(string userName, string Password)
        {
            return _UserLogin.checkLogin(userName, Password);
        }
        public string Add(Users obj)
        {
            return _UserLogin.Add(obj);
        }
    }
}
