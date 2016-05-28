using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HeartView.Startup))]
namespace HeartView
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
