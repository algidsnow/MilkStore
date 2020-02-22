using BookStoreManagementCodeFirst;

namespace Services
{
    public interface IUserServices
    {
        string Add(Users obj);
        Users checkLogin(string userName, string Password);
    }
}