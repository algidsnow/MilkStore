using BookStoreManagementCodeFirst;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderDetailService : Iservices<OrderDetail>
    {
        IRepository<OrderDetail> _OrderDetailRepository;
        public OrderDetailService(IRepository<OrderDetail> OrderDetailRepository)
        {

            _OrderDetailRepository = OrderDetailRepository;
        }
        public int Add(OrderDetail obj)
        {
          return _OrderDetailRepository.Add(obj);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<OrderDetail> GetAll()
        {
            throw new NotImplementedException();
        }

        public OrderDetail GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDetail> ListPage(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public bool Update(OrderDetail obj)
        {
            throw new NotImplementedException();
        }
    }

}
