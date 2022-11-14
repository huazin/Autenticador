using Domain.Contracts;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.OpenApi.Models;
using Services.Services;


namespace Autenticador.Api.DepedencyMap
{
    public static class Dependencias
    {
        public static void AddDependency(this IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();

            services.AddScoped<IValidarSenhaServices, ValidarSenhaServices>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = Environment.GetEnvironmentVariable("API_VERSION"),
                    Title = Environment.GetEnvironmentVariable("APPLICATION_TITLE"),
                    Description = Environment.GetEnvironmentVariable("APPLICATION_DESCRIPTION")
                });
            });

            services.AddSwaggerGenNewtonsoftSupport();
        }

        public static void AddConfigure(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwaggerConfiguration(env);
            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features.Get<IExceptionHandlerPathFeature>().Error;
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(exception.Message);
            }));

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
