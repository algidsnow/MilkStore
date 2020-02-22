using BookStoreManagementCodeFirst;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    
  public   interface Iservices<T>
    {
        IEnumerable<T> ListPage(int page, int pageSize);
        List<T> GetAll();

        T GetByID(int id);

        bool Update(T obj);

        bool Delete(int id);

        int Add(T obj);
    }
}
