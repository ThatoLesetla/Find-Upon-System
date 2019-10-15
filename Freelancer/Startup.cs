using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Freelancer.Startup))]
namespace Freelancer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
