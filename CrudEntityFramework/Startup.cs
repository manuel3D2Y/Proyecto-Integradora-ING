using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CrudEntityFramework.Startup))]
namespace CrudEntityFramework
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
