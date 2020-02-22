using BookStoreManagementCodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CommentRepository : IRepository<Comment>
    {
        IBookStoreDbContext _Context;
        public CommentRepository(IBookStoreDbContext Context)
        {
            _Context = Context;
        }
        public int Add(Comment obj)
        {
            var addComment = _Context.Comments.Add(obj);
            _Context.SaveChanges();
            return addComment.CommentId;
       }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetAll()
        {
            throw new NotImplementedException();
        }

        public Comment GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> ListPage(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public bool Update(Comment obj)
        {
            throw new NotImplementedException();
        }
    }
}
