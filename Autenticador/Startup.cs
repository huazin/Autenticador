using Autenticador.Api.DepedencyMap;
namespace Autenticador.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection servies)
        {
            servies.AddDependency();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.AddConfigure(env);
        }
    }
}
