using BookStoreManagementCodeFirst;

namespace Repository
{
    public interface IUserLoginRepository
    {
        string Add(Users obj);
        Users checkLogin(string userName, string Password);
    }
}