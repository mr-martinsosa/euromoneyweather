using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(euromoneyweather.Startup))]
namespace euromoneyweather
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
