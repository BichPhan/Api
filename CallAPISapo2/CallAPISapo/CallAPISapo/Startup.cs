using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CallAPISapo.Startup))]
namespace CallAPISapo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
