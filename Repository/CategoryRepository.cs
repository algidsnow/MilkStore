using BookStoreManagementCodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoryRepository : IRepository<Category>
    {

        IBookStoreDbContext _CategoryContext;
        public CategoryRepository(IBookStoreDbContext CategoryContext)
        {
            _CategoryContext = CategoryContext;
        }

        public int Add(Category obj)
        {
            _CategoryContext.Categories.Add(obj);
            _CategoryContext.SaveChanges();
            return obj.CateId;
        }
        public bool Delete(int id)
        {
            var category = GetByID(id);
            if (category != null)
            {
                _CategoryContext.Categories.Remove(category);
                return _CategoryContext.SaveChanges() > 0;
            }
            return false;
        }
        public List<Category> GetAll()
        {
            var category = _CategoryContext.Categories.ToList();
            return category;
        }
        public Category GetByID(int id)
        {
            var CategoryId = _CategoryContext.Categories.FirstOrDefault(x => x.CateId == id);
            return CategoryId;
        }

        public IEnumerable<Category> ListPage(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public bool Update(Category obj)
        {
            var current = GetByID(obj.CateId);
            current.CateName = obj.CateName;
            current.Description = obj.Description;
            current.Books = obj.Books;
            return _CategoryContext.SaveChanges() > 0;
        }
    }
}
