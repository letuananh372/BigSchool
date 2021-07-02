using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bigchool1.Startup))]
namespace Bigchool1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
