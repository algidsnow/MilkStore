using BookStoreManagementCodeFirst;
using Repository;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AuthorServices : Iservices<Author>
    {
        private readonly IRepository<Author> _authorRepository;
        public AuthorServices(IRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public int Add(Author obj)
        {
            return _authorRepository.Add(obj);
        }

        public bool Delete(int id)
        {
            return _authorRepository.Delete(id);
        }

        public List<Author> GetAll()
        {
            return _authorRepository.GetAll();
        }

        public Author GetByID(int id)
        {
            return _authorRepository.GetByID(id);
        }

        public IEnumerable<Author> ListPage(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public bool Update(Author obj)
        {

            return _authorRepository.Update(obj);
        }
    }
}
