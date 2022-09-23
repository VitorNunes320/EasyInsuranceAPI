using CrossCutting.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// Dados do seguro
    /// </summary>
    public class Seguro
    {
        public Seguro()
        {
            Id = Guid.NewGuid();
            CriadoEm = DataUtils.GetDateTimeBrasil();
        }

        /// <summary>
        /// Id do seguro
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Valor total do seguro
        /// </summary>
        public decimal ValorTotal { get; set; }

        /// <summary>
        /// Valor da parcela do seguro
        /// </summary>
        public decimal ValorParcela { get; set; }

        /// <summary>
        /// Quantidade de parcelas do seguro
        /// </summary>
        public int QuantidadeParcelas { get; set; }

        /// <summary>
        /// Id do usuário que realizou a simulação de seguro
        /// </summary>
        public Guid UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        /// <summary>
        /// Id do item do seguro
        /// </summary>
        public Guid ItemId { get; set; }

        public Item Item { get; set; }

        public DateTime? CriadoEm { get; set; }

        public DateTime? AtualizadoEm { get; set; }

        public string? UsuarioCriou { get; set; }

        public string? UsuarioAtualizou { get; set; }
    }
}
