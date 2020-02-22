using System.Collections.Generic;
using BookStoreManagementCodeFirst;

namespace Repository
{
    public interface IBookRepository
    {
        IEnumerable<Book> Seach(string input, int page , int pagesize);
    }
}