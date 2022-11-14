using Autenticador.Api;
using Domain.Contracts;
using IntegrationTest.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTest.Controllers
{

    [Collection(nameof(IntegrationApiFixtureCollection))]
    public class SenhaControllerTest
    {

        private readonly IntegrationApiTestsFixture<StartupTest> _testsFixture;
        private readonly IValidarSenhaServices _validarSenhaServices;
        public SenhaControllerTest(IntegrationApiTestsFixture<StartupTest> testsFixture)
        {
            _testsFixture = testsFixture;
            _validarSenhaServices = (IValidarSenhaServices)_testsFixture.services.GetService(typeof(IValidarSenhaServices));
        }

        [Fact]
        public async void ValidarSenhaValida()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"autenticador/Senha/validar?senha=H@as1234567");
            var getResponse = await _testsFixture.HttpClient.SendAsync(request);

            Assert.True(getResponse.StatusCode == System.Net.HttpStatusCode.OK);
        }

        [Trait("senha", "Valida senha com falha")]
        [Theory(DisplayName = "Valida senha com falha")]
        [InlineData("H@as123a")]
        [InlineData("H@as")]
        [InlineData("H@AS123")]
        public async void ValidarSenhaInvalida(string senha)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"autenticador/Senha/validar?senha={senha}");
            var getResponse = await _testsFixture.HttpClient.SendAsync(request);

            Assert.True(getResponse.StatusCode == System.Net.HttpStatusCode.BadRequest);
        }
    }
}
