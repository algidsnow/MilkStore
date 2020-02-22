using BookStoreManagementCodeFirst;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repository
{
    public class BookRepository : IRepository<Book>, IBookRepository
    {
       
        IBookStoreDbContext _context;
        public BookRepository(IBookStoreDbContext context)
        {
            _context = context;
        }
        public int Add(Book obj)
        {
            obj.CreateDate = DateTime.Now;
            obj.ModifiedDate = DateTime.Now;
            _context.Books.Add(obj);
            _context.SaveChanges();
            return obj.BookId;
        }
        public IEnumerable<Book> ListPage(int page,int pageSize)
        {
            return _context.Books.OrderByDescending(x=>x.CreateDate).ToPagedList(page, pageSize);
        }

        public bool Delete(int id)
        {
            var book = GetByID(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public List<Book> GetAll()
        {
            var book = _context.Books;
            return book.ToList() ;
        }

        public Book GetByID(int id)
        {
            var book = _context.Books.First(x => x.BookId == id);
            return book;
        }

        public bool Update(Book obj)
        {
            var current = GetByID(obj.BookId);
            current.BookName = obj.BookName;
            current.AuthorId = obj.AuthorId;
            current.PubId = obj.PubId;
            current.CateId = obj.CateId;
            current.Summary = obj.Summary;
            current.ImgUrl = obj.ImgUrl;
            current.Price = obj.Price;
            current.Quantity = obj.Quantity;
            current.IsActive = obj.IsActive;
         
            return _context.SaveChanges() > 0;
        }
        public IEnumerable<Book> Seach(string input,int page,int pagesize)
        {
            return  _context.Books.OrderByDescending(x => x.CreateDate).Where(x => x.BookName.ToUpper().Contains(input.ToUpper()) || x.Author.AuthorName.ToUpper().Contains(input.ToUpper()) || x.Publisher.Name.ToUpper().Contains(input.ToUpper())).ToPagedList(page,pagesize) ;
            
        } 
    }
}
