using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Promo.UI.Startup))]
namespace Promo.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
