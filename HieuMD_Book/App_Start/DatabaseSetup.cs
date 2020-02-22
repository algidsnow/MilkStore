using BookStoreManagementCodeFirst;
using Repository;
using System.Data.Entity;

namespace HieuMD_Book
{
    internal class DatabaseSetup
    {
        public static void Initialize()
        {
            Database.SetInitializer(new DbInitializer());

            using (var db = new BookStoreDbContext())
            {
                db.Database.Initialize(true);
            }
        }
    }
}