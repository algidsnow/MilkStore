using BookStoreManagementCodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
  public  class OrderDetailRepository:IRepository<OrderDetail>
    {
        IBookStoreDbContext _context;
        public OrderDetailRepository(IBookStoreDbContext context)
        {

            _context = context;
        }
        public int Add(OrderDetail obj)
        {
            _context.OrderDetails.Add(obj);
            _context.SaveChanges();
            return obj.OrderID;

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
