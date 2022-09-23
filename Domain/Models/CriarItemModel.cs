using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    /// <summary>
    /// Dados do item
    /// </summary>
    public class CriarItemModel
    {
        /// <summary>
        /// Id do item
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Nome do item
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Tipo do item
        /// </summary>
        public string Tipo { get; set; }

        /// <summary>
        /// Valor estimado do item
        /// </summary>
        public decimal ValorEstimado { get; set; }

        /// <summary>
        /// Data em que o item foi adiquirido
        /// </summary>
        public DateTime DataAquisicaoItem { get; set; }
    }
}
