using CrossCutting.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// Dados do Item
    /// </summary>
    public class Item
    {
        public Item()
        {
            Id = Guid.NewGuid();
            CriadoEm = DataUtils.GetDateTimeBrasil();
        }

        /// <summary>
        /// Código de identificação do item
        /// </summary>
        public Guid Id { get; set; }

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

        /// <summary>
        /// Id do usuário proprietário do item
        /// </summary>
        public Guid UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        /// <summary>
        /// Lista de simulações de seguros do item
        /// </summary>
        public List<Seguro> Seguros { get; set; }

        public DateTime? CriadoEm { get; set; }

        public DateTime? AtualizadoEm { get; set; }

        public string? UsuarioCriou { get; set; }

        public string? UsuarioAtualizou { get; set; }
    }
}
