using Microsoft.OpenApi.Models;

namespace Autenticador.Api.DepedencyMap
{
    public static class SwaggerConfig
    {
        public static void UseSwaggerConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            var basePath = env.IsDevelopment()
            ? $"/"
            : $"/{Environment.GetEnvironmentVariable("APPLICATION_NAME")}";

            app.UseSwagger(c =>
            {
                c.RouteTemplate = "swagger/{documentName}/swagger.json";
                c.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
                {
                    swaggerDoc.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"https://{httpReq.Host.Value}{basePath}" } };
                });
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"./{Environment.GetEnvironmentVariable("API_VERSION")}/swagger.json", $"{Environment.GetEnvironmentVariable("APPLICATION_NAME")}-{Environment.GetEnvironmentVariable("API_VERSION")}");
            });
        }
    }
}
