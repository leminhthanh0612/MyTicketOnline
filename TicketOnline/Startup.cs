using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TicketOnline.Startup))]
namespace TicketOnline
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
