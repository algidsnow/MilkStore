using BookStoreManagementCodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PublisherRepository : IRepository<Publisher>
    {
        IBookStoreDbContext _Context;
        public PublisherRepository(IBookStoreDbContext Context)
        {
            _Context = Context;
        }

        public int Add(Publisher obj)
        {
            _Context.Publishers.Add(obj);
            _Context.SaveChanges();
            return obj.PubId;
        }

        public bool Delete(int id)
        {
            var dele = GetByID(id);
            if(dele != null)
            {
                _Context.Publishers.Remove(dele);
                return _Context.SaveChanges() > 0;

            }
            return false;
        }

        public List<Publisher> GetAll()
        {
            var Publisher = _Context.Publishers.ToList();
            return Publisher;
        }

        public Publisher GetByID(int id)
        {
          var getById = _Context.Publishers.First(x => x.PubId == id);
            return getById;
        }

        public IEnumerable<Publisher> ListPage(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public bool Update(Publisher obj)
        {
            var update = GetByID(obj.PubId);
            update.Name = obj.Name;
            update.Description = obj.Description;
            return _Context.SaveChanges() > 0;
        }
    }
}
