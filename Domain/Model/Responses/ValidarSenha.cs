using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Responses
{
    public record ValidarSenha
    {
        public string Mensagem { get; set; }
    }
}
