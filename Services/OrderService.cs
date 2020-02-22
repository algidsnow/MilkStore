using BookStoreManagementCodeFirst;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderService : Iservices<Order>
    {
      private readonly  IRepository<Order> _OrderRepository;

        public OrderService(IRepository<Order> OrderRepository)
        {
            _OrderRepository = OrderRepository;
        }
        public int Add(Order obj)
        {
            return _OrderRepository.Add(obj);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Order GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> ListPage(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public bool Update(Order obj)
        {
            throw new NotImplementedException();
        }
    }
}
