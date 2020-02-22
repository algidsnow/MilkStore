using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HieuMD_Book.Startup))]
namespace HieuMD_Book
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
