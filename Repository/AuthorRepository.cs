using BookStoreManagementCodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AuthorRepository : IRepository<Author>
    {
        IBookStoreDbContext _context;
        public AuthorRepository(IBookStoreDbContext context)
        {
            _context = context;
        }    
        public int Add(Author obj)
        {
            _context.Authors.Add(obj);
            _context.SaveChanges();
            return obj.AuthorId;
        }

        public bool Delete(int id)
        {
            var dele = GetByID(id);
            if (dele != null)
            {
                _context.Authors.Remove(dele);
                return _context.SaveChanges() > 0;
            }
            return false;

        }

        public List<Author> GetAll()
        {
           var auther= _context.Authors.ToList();
            return auther;
           
        }

        public Author GetByID(int id)
        {
          var getById = _context.Authors.First(x => x.AuthorId == id);
            return getById;
            
        }

        public IEnumerable<Author> ListPage(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public bool Update(Author obj)
        {
            var update = GetByID(obj.AuthorId);
            update.AuthorName = obj.AuthorName;
            update.History = obj.History;
            return _context.SaveChanges() > 0;
        }
    }
}
