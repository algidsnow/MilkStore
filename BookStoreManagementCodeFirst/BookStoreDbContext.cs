using BookStoreManagementCodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BookStoreDbContext : DbContext, IBookStoreDbContext
    {
        public BookStoreDbContext() : base("BookStoreDb")
        {
            Database.SetInitializer(new DbInitializer());
        }
     
      
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }

       public DbSet<Order> Orders { get; set; }
   

        public DbSet<OrderDetail> OrderDetails { get; set; }

       public DbSet<Users> Users { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
