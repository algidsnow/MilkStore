using BookStoreManagementCodeFirst;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
   public class CategoryService : Iservices<Category>
    {
        IRepository<Category> _CategoryRepository;
        public CategoryService(IRepository<Category> CategoryRepository)
        {
            _CategoryRepository = CategoryRepository;
        }
        public int Add(Category obj)
        {
            return _CategoryRepository.Add(obj);
        }

        public bool Delete(int id)
        {
            return _CategoryRepository.Delete(id);
        }

        public List<Category> GetAll()
        {
            return _CategoryRepository.GetAll();
        }

        public Category GetByID(int id)
        {
            return _CategoryRepository.GetByID(id);
        }

        public IEnumerable<Category> ListPage(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public bool Update(Category obj)
        {
           return _CategoryRepository.Update(obj);
        }
    }
}
