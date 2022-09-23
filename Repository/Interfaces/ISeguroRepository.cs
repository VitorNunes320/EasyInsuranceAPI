using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Repository.Interfaces
{
    public interface ISeguroRepository : IRepositoryBase<Seguro>
    {
        public List<CotacaoModel>? BuscarSeguros(Guid usuarioId, string busca, int pagina, int quantidade);
        
        public Seguro? BuscarSeguroPorId(Guid id);
    }
}
