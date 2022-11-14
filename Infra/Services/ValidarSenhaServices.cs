using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ValidarSenhaServices : IValidarSenhaServices
    {
        public bool ContemCaracterEspecial(string senha) => Regex.IsMatch(senha, @"[!@#$%^&*()-+]");

        public bool ContemCaracteresUnicos(string senha) => !Regex.IsMatch(senha, @"(\w)*.*\1");

        public bool ContemDigitos(string senha) => Regex.IsMatch(senha, @"[0-9]");

        public bool ContemMinimoLowCase(string senha) => Regex.IsMatch(senha, @"[a-z]");

        public bool ContemMinimoUpperCase(string senha) => Regex.IsMatch(senha, @"[A-Z]");

        public bool TamanhoMinimo(string senha) => senha.Length >= 9;

        public bool Validar(string senha) => ContemCaracterEspecial(senha) && ContemCaracteresUnicos(senha) && ContemMinimoLowCase(senha) && ContemMinimoUpperCase(senha) && TamanhoMinimo(senha) && ContemDigitos(senha);
    }
}
