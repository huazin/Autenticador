using Autenticador.Api.DepedencyMap;

namespace Autenticador.Api
{
    public class StartupTest
    {
        public static IConfiguration Configuration { get; private set; }
        public StartupTest(IWebHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();

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
