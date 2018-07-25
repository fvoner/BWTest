using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BurganWallet.Startup))]
namespace BurganWallet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
