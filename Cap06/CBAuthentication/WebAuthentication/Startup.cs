using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAuthentication.Startup))]
namespace WebAuthentication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
