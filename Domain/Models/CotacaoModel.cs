using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CotacaoModel
    {
        public Guid? Id { get; set; }

        public decimal ValorTotal { get; set; }

        public decimal ValorParcela { get; set; }

        public int QuantidadeParcelas { get; set; }

        public DateTime? CriadoEm { get; set; }

        public string NomeItem { get; set; }
    }
}
