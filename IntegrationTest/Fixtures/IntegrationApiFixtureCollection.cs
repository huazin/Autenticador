using Autenticador.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IntegrationTest.Fixtures
{
    [CollectionDefinition(nameof(IntegrationApiFixtureCollection))]
    public class IntegrationApiFixtureCollection : ICollectionFixture<IntegrationApiTestsFixture<StartupTest>>
    {
    }

    public class IntegrationApiTestsFixture<TStartup> : IDisposable where TStartup : class
    {
        public const string BaseUrl = "http://localhost:54321";
        public HttpClient HttpClient;
        public JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        public IServiceProvider services;

        public IntegrationApiTestsFixture()
        {
            var server = new TestServer(new WebHostBuilder()
                                            .UseEnvironment("Testing")
                                            .UseStartup<TStartup>()
                                            );
            HttpClient = server.CreateClient();
            HttpClient.BaseAddress = new Uri($"{BaseUrl}/");
            services = server.Services;
        }

        public void Dispose()
        {
            HttpClient.Dispose();
        }
    }
}
