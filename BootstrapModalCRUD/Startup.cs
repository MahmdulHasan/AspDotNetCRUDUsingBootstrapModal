using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BootstrapModalCRUD.Startup))]
namespace BootstrapModalCRUD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
