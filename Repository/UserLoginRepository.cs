using BookStoreManagementCodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
   public class UserLoginRepository : IUserLoginRepository
    {
        IBookStoreDbContext _context;
        public UserLoginRepository(IBookStoreDbContext Context)
        {
            _context = Context;
        }
        public Users checkLogin(string userName,string Password)
        {
          
            var account = _context.Users.SingleOrDefault(x => x.UserName == userName && x.Password == Password);
            if (account != null)
            {
                return account;
            }
            else return null;
        }
       public bool CheckLogin1(string userName,string Password)
        {
            
            var account = _context.Users.First(x => x.UserName == userName && x.Password == Password);
            if (account != null)
            {
                return true;
            }
            else return false;
        
        }
       public string Add(Users obj)
        {
            obj.Role = "employee";
            var add = _context.Users.Add(obj);
            _context.SaveChanges();
            return add.UserName;
        }
       
    }
}
