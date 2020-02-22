using Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BookStoreManagementCodeFirst
{
    public class DbInitializer: DropCreateDatabaseIfModelChanges<BookStoreDbContext>
    {
        protected override void Seed(BookStoreDbContext context)
        {
            var publishers = new List<Publisher>()
            {
                new Publisher()
                {
                    Name = "NXBHieu",
                    Description = "aaaaaaaaaaaaaaa"
                }
           
            };
            publishers.ForEach(x => context.Publishers.Add(x));
            context.SaveChanges();

            var users = new List<Users>()
            {
                new Users()
                {
                    UserName="admin",
                    Password="admin",
                    Email="admin@gmail.com",
                    IsActive=true,
                    Role="admin"
                },
                new Users()
                {
                    UserName="employee",
                    Password="employee",
                    Email="employee@gmail.com",
                    IsActive=true,
                    Role="employee"
                }
                   
            };
            users.ForEach(x => context.Users.Add(x));
            context.SaveChanges();

            var authors = new List<Author>()
            {
                new Author()
                {
                    AuthorName = "Hieu",
                    History = "aaaaaaaaaaaaaaaaa"
                },
            };
            authors.ForEach(x => context.Authors.Add(x));
            context.SaveChanges();

            var categories = new List<Category>()
            {
                new Category()
                {
                    CateName = "Kinh dị",
                    Description = "aaaaaaaaaaaaaaaaa"
                }
            };
            categories.ForEach(x => context.Categories.Add(x));
            context.SaveChanges();

            var books = new List<Book>()
            {
                new Book()
                {
                    BookName = "How To Win Friends And Influence People",
                    Summary = "Tại sao Đắc Nhân Tâm luôn trong Top sách bán chạy nhất thế giới? Bởi vì đó là cuốn sách mọi người đều nên đọc. Hiện nay có một sự hiểu nhầm đã xảy ra. Tuy Đắc Nhân Tâm là tựa sách hầu hết mọi người đều biết đến, vì những danh tiếng và mức độ phổ biến, nhưng một số người lại “ngại” đọc. Lý do vì họ tưởng đây là cuốn sách “dạy làm người” nên có tâm lý e ngại. Có lẽ là do khi giới thiệu về cuốn sách, người ta luôn gắn với miêu tả đây là “nghệ thuật đối nhân xử thế”, “nghệ thuật thu phục lòng người”… Những cụm từ này đã không còn hợp với hiện nay nữa, gây cảm giác xa lạ và không thực tế.",
                    ImgUrl = "book-0001.jpg",
                    Price = 169000M,
                    CreateDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    Quantity = 52,
                    Category = categories.Single(c=>c.CateName==("Kinh dị")),
                    Author = authors.Single(a=>a.AuthorName==("Hieu")),
                    Publisher = publishers.Single(p=>p.Name==("NXBHieu"))
                },
                new Book()
                {
                    BookName = "How To Win Friends And Influence People",
                    Summary = "Tại sao Đắc Nhân Tâm luôn trong Top sách bán chạy nhất thế giới? Bởi vì đó là cuốn sách mọi người đều nên đọc. Hiện nay có một sự hiểu nhầm đã xảy ra. Tuy Đắc Nhân Tâm là tựa sách hầu hết mọi người đều biết đến, vì những danh tiếng và mức độ phổ biến, nhưng một số người lại “ngại” đọc. Lý do vì họ tưởng đây là cuốn sách “dạy làm người” nên có tâm lý e ngại. Có lẽ là do khi giới thiệu về cuốn sách, người ta luôn gắn với miêu tả đây là “nghệ thuật đối nhân xử thế”, “nghệ thuật thu phục lòng người”… Những cụm từ này đã không còn hợp với hiện nay nữa, gây cảm giác xa lạ và không thực tế.",
                    ImgUrl = "book-0001.jpg",
                    Price = 169000M,
                    CreateDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    Quantity = 52,
                    Category = categories.Single(c=>c.CateName==("Kinh dị")),
                    Author = authors.Single(a=>a.AuthorName==("Hieu")),
                    Publisher = publishers.Single(p=>p.Name==("NXBHieu"))
                },
                new Book()
                {
                    BookName = "How To Win Friends And Influence People",
                    Summary = "Tại sao Đắc Nhân Tâm luôn trong Top sách bán chạy nhất thế giới? Bởi vì đó là cuốn sách mọi người đều nên đọc. Hiện nay có một sự hiểu nhầm đã xảy ra. Tuy Đắc Nhân Tâm là tựa sách hầu hết mọi người đều biết đến, vì những danh tiếng và mức độ phổ biến, nhưng một số người lại “ngại” đọc. Lý do vì họ tưởng đây là cuốn sách “dạy làm người” nên có tâm lý e ngại. Có lẽ là do khi giới thiệu về cuốn sách, người ta luôn gắn với miêu tả đây là “nghệ thuật đối nhân xử thế”, “nghệ thuật thu phục lòng người”… Những cụm từ này đã không còn hợp với hiện nay nữa, gây cảm giác xa lạ và không thực tế.",
                    ImgUrl = "book-0001.jpg",
                    Price = 169000M,
                    CreateDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    Quantity = 52,
                    Category = categories.Single(c=>c.CateName==("Kinh dị")),
                    Author = authors.Single(a=>a.AuthorName==("Hieu")),
                    Publisher = publishers.Single(p=>p.Name==("NXBHieu"))
                },
                new Book()
                {
                    BookName = "How To Win Friends And Influence People",
                    Summary = "Tại sao Đắc Nhân Tâm luôn trong Top sách bán chạy nhất thế giới? Bởi vì đó là cuốn sách mọi người đều nên đọc. Hiện nay có một sự hiểu nhầm đã xảy ra. Tuy Đắc Nhân Tâm là tựa sách hầu hết mọi người đều biết đến, vì những danh tiếng và mức độ phổ biến, nhưng một số người lại “ngại” đọc. Lý do vì họ tưởng đây là cuốn sách “dạy làm người” nên có tâm lý e ngại. Có lẽ là do khi giới thiệu về cuốn sách, người ta luôn gắn với miêu tả đây là “nghệ thuật đối nhân xử thế”, “nghệ thuật thu phục lòng người”… Những cụm từ này đã không còn hợp với hiện nay nữa, gây cảm giác xa lạ và không thực tế.",
                    ImgUrl = "book-0001.jpg",
                    Price = 169000M,
                    CreateDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    Quantity = 52,
                    Category = categories.Single(c=>c.CateName==("Kinh dị")),
                    Author = authors.Single(a=>a.AuthorName==("Hieu")),
                    Publisher = publishers.Single(p=>p.Name==("NXBHieu"))
                },
                new Book()
                {
                    BookName = "How To Win Friends And Influence People",
                    Summary = "Tại sao Đắc Nhân Tâm luôn trong Top sách bán chạy nhất thế giới? Bởi vì đó là cuốn sách mọi người đều nên đọc. Hiện nay có một sự hiểu nhầm đã xảy ra. Tuy Đắc Nhân Tâm là tựa sách hầu hết mọi người đều biết đến, vì những danh tiếng và mức độ phổ biến, nhưng một số người lại “ngại” đọc. Lý do vì họ tưởng đây là cuốn sách “dạy làm người” nên có tâm lý e ngại. Có lẽ là do khi giới thiệu về cuốn sách, người ta luôn gắn với miêu tả đây là “nghệ thuật đối nhân xử thế”, “nghệ thuật thu phục lòng người”… Những cụm từ này đã không còn hợp với hiện nay nữa, gây cảm giác xa lạ và không thực tế.",
                    ImgUrl = "book-0001.jpg",
                    Price = 169000M,
                    CreateDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    Quantity = 52,
                    Category = categories.Single(c=>c.CateName==("Kinh dị")),
                    Author = authors.Single(a=>a.AuthorName==("Hieu")),
                    Publisher = publishers.Single(p=>p.Name==("NXBHieu"))
                }
            };
            books.ForEach(x => context.Books.Add(x));
            context.SaveChanges();
        }
    }
}
