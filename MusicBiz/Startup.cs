using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(S2022A5SG.Startup))]

namespace S2022A5SG
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
