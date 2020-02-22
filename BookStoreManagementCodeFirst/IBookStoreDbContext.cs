using System.Data.Entity;
using BookStoreManagementCodeFirst;

namespace Repository
{
    public interface IBookStoreDbContext
    {
        DbSet<Author> Authors { get; set; }
        DbSet<Book> Books { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<Publisher> Publishers { get; set; }
        DbSet<Users> Users { get; set; }

        DbSet<Order> Orders { get; set; }

    
        DbSet<OrderDetail> OrderDetails { get; set; }

        int SaveChanges();
    }
}