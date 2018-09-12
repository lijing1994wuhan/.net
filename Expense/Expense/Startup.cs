using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Expense.Startup))]
namespace Expense
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
