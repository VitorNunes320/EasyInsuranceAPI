using CrossCutting.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class PerfilNaoExisteException : Exception
    {
        public PerfilNaoExisteException() : base(Mensagens.ErroPerfilNaoExiste)
        {

        }
    }
}
