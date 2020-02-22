using BookStoreManagementCodeFirst;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CommentService : Iservices<Comment>
    {
        IRepository<Comment> _CommentRepository;

        public CommentService(IRepository<Comment> CommentRepository)
        {
            _CommentRepository = CommentRepository;
        }
        public int Add(Comment obj)
        {
            return _CommentRepository.Add(obj);
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
