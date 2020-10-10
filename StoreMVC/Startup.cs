using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(StoreMVC.Startup))]
namespace StoreMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
