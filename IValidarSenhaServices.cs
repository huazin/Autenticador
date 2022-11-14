using System;

namespace Autenticador.Domain.Contracts
{

	public interface IValidarSenhaServices
	{
		bool Validar(string senha);

		bool TamanhoMinimo(string senha);
		bool ContemCaracterEspecial(string senha);
		bool ContemMinimoLowCase(string senha);
		bool ContemMinimoUpperCase(string senha);
		bool ContemCaracteresUnicos(string senha);
	}
}
