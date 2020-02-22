using BookStoreManagementCodeFirst;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookService : Iservices<Book>, IBookService
    {
        private readonly IRepository<Book> _BookRepository;
        private readonly IBookRepository _Book;
        public BookService(IRepository<Book> BookRepository, IBookRepository Book)
        {
            _BookRepository = BookRepository;
            _Book = Book;
        }
        public IEnumerable<Book> ListPage(int page, int pageSize)
        {

            return _BookRepository.ListPage(page, pageSize);
        }
        public int Add(Book obj)
        {
            return _BookRepository.Add(obj);
        }

        public bool Delete(int id)
        {
            return _BookRepository.Delete(id);
        }

        public List<Book> GetAll()
        {
            return _BookRepository.GetAll();
        }

        public Book GetByID(int id)
        {
            return _BookRepository.GetByID(id);
        }

        public bool Update(Book obj)
        {
            return _BookRepository.Update(obj);
        }

        public IEnumerable<Book> Seach(string input, int page = 1, int pagesize = 4)
        {
            return _Book.Seach(input, page, pagesize);
        }
    }
}
