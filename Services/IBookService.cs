using System.Collections.Generic;
using BookStoreManagementCodeFirst;

namespace Services
{
    public interface IBookService
    {
        IEnumerable<Book> Seach(string input, int page , int pagesize);
    }
}