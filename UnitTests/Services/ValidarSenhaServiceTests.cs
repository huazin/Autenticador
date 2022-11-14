using Domain.Contracts;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Services
{
    public class ValidarSenhaServiceTests
    {
        private readonly IValidarSenhaServices _validarSenha;
        public ValidarSenhaServiceTests()
        {
            _validarSenha = new ValidarSenhaServices();
        }

        [Trait("Validacao", "Senha")]
        [Theory(DisplayName = "ContemCaracterEspecial")]
        [InlineData("Hash123", false)]
        [InlineData("H@as123", true)]
        public void Senha_ContemCaracterEspecial(string senha, bool valido)
        {
            var retorno = _validarSenha.ContemCaracterEspecial(senha);

            Assert.Equal(retorno, valido);
        }

        [Trait("Validacao", "Senha")]
        [Theory(DisplayName = "TamanoMinomo")]
        [InlineData("H@as123", false)]
        [InlineData("H@as1234567", true)]
        public void Senha_TamanhoMinimo(string senha, bool valido)
        {
            var retorno = _validarSenha.TamanhoMinimo(senha);

            Assert.Equal(retorno, valido);
        }

        [Trait("Validacao", "Senha")]
        [Theory(DisplayName = "ContemMinimoLowCase")]
        [InlineData("H@AS123", false)]
        [InlineData("H@as123", true)]
        public void Senha_ContemMinimoLowCase(string senha, bool valido)
        {
            var retorno = _validarSenha.ContemMinimoLowCase(senha);

            Assert.Equal(retorno, valido);
        }

        [Trait("Validacao", "Senha")]
        [Theory(DisplayName = "ContemMinimoUpperCase")]
        [InlineData("h@as123", false)]
        [InlineData("H@as123", true)]
        public void Senha_ContemMinimoUpperCase(string senha, bool valido)
        {
            var retorno = _validarSenha.ContemMinimoUpperCase(senha);

            Assert.Equal(retorno, valido);
        }

        [Trait("Validacao", "Senha")]
        [Theory(DisplayName = "ContemCaracteresUnicos")]
        [InlineData("H@as123a", false)]
        [InlineData("H@as123", true)]
        public void Senha_ContemCaracteresUnicos(string senha, bool valido)
        {
            var retorno = _validarSenha.ContemCaracteresUnicos(senha);

            Assert.Equal(retorno, valido);
        }

        [Trait("Validacao", "Senha")]
        [Theory(DisplayName = "Validar")]
        [InlineData("H@as123a", false)]
        [InlineData("H@as1234567", true)]
        public void Senha_Validar(string senha, bool valido)
        {
            var retorno = _validarSenha.Validar(senha);

            Assert.Equal(retorno, valido);
        }

        [Trait("Validacao", "Senha")]
        [Theory(DisplayName = "ContemDigitos")]
        [InlineData("H@as", false)]
        [InlineData("H@as123", true)]
        public void Senha_ContemDigitos(string senha, bool valido)
        {
            var retorno = _validarSenha.ContemDigitos(senha);

            Assert.Equal(retorno, valido);
        }
    }
}
