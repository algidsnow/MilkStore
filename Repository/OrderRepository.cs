using BookStoreManagementCodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
  public  class OrderRepository : IRepository<Order>
    {
        IBookStoreDbContext _Context;
        public OrderRepository(IBookStoreDbContext Context)
        {
            _Context = Context;
        }
        public int Add(Order obj)
        {
           
            obj.OrderDate = DateTime.Now;
            obj.RequiredDate = DateTime.Now;
            obj.ShippedDate = DateTime.Now;
            _Context.Orders.Add(obj);
            _Context.SaveChanges();
            return obj.OrderId;
                
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
