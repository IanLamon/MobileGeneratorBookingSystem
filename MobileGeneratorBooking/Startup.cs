using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MobileGeneratorBooking.Startup))]
namespace MobileGeneratorBooking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
