using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ISeguroService
    {
        public Seguro? BuscarSeguroPorId(Guid id);

        public List<CotacaoModel>? BuscarSeguros(Guid usuarioId, string busca = "", int pagina = 0, int quantidade = 15);
        
        public void CriarSeguro(CriarItemModel modelo, Usuario usuario);

        public CotacaoModel ProcessarSeguro(CriarItemModel modelo);
    }
}
