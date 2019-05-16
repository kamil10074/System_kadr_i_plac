using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(System_kadr.Startup))]
namespace System_kadr
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
