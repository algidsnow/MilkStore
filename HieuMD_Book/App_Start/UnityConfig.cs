using BookStoreManagementCodeFirst;
using Repository;
using Services;
using System;

using Unity;

namespace HieuMD_Book
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            container.RegisterType<IBookStoreDbContext, BookStoreDbContext>();
            container.RegisterType<IRepository<Author>, AuthorRepository>();
            container.RegisterType<Iservices<Author>, AuthorServices>();
         
            container.RegisterType<IRepository<Book>, BookRepository>();
            container.RegisterType<Iservices<Book>, BookService>();

            container.RegisterType<IRepository<Category>, CategoryRepository>();
            container.RegisterType<Iservices<Category>, CategoryService>();


            container.RegisterType<IRepository<Publisher>,  PublisherRepository>();
            container.RegisterType<Iservices<Publisher>, PublisherService>();

            container.RegisterType<IRepository<Order>, OrderRepository>();
            container.RegisterType<Iservices<Order>, OrderService>();

            container.RegisterType < IRepository < OrderDetail>, OrderDetailRepository>();
            container.RegisterType<Iservices<OrderDetail>, OrderDetailService>();

            container.RegisterType<IBookRepository, BookRepository>();
            container.RegisterType<IBookService, BookService>();

            container.RegisterType<IRepository<Comment>, CommentRepository>();
            container.RegisterType<Iservices<Comment>, CommentService>();

            container.RegisterType<IUserLoginRepository, UserLoginRepository>();
            container.RegisterType<IUserServices, UserServices>();



        }
    }
}