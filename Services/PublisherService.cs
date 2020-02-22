using BookStoreManagementCodeFirst;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PublisherService : Iservices<Publisher>
    {
        IRepository<Publisher> _publisherRepository;
        public PublisherService(IRepository<Publisher> publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }
        public int Add(Publisher obj)
        {
          return  _publisherRepository.Add(obj);

        }

        public bool Delete(int id)
        {
            return _publisherRepository.Delete(id);
        }

        public List<Publisher> GetAll()
        {
           return _publisherRepository.GetAll();
        }

        public Publisher GetByID(int id)
        {
            return _publisherRepository.GetByID(id);
        }

        public IEnumerable<Publisher> ListPage(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public bool Update(Publisher obj)
        {
            return _publisherRepository.Update(obj);
        }
    }
}
