using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository<T>
    {
        List<T> GetAll();

        T GetByID(int id);

        bool Update(T obj);

        IEnumerable<T> ListPage(int page,int pageSize);

        bool Delete(int id);

        int Add(T obj);

    }
}
