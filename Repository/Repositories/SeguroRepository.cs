using Domain.Entities;
using Data.Contexts;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Repository.Repositories
{
    public class SeguroRepository : RepositoryBase<Seguro>, ISeguroRepository
    {
        private readonly DbSet<Seguro> _seguros;

        public SeguroRepository(AppDbContext easyChefContext) : base(easyChefContext)
        {
            _seguros = easyChefContext.Seguros;
        }

        public List<CotacaoModel>? BuscarSeguros(Guid usuarioId, string busca, int pagina, int quantidade)
        {
            return _seguros.Where(seguro => 
                seguro.UsuarioId == usuarioId && (
                    seguro.Item.Nome.ToLower().Contains(busca.ToLower()) ||
                    seguro.Item.Tipo.ToLower().Contains(busca.ToLower())
                )
            )
            .Include(seguro => seguro.Item)
            .OrderBy(seguro => seguro.CriadoEm)
            .Skip(pagina * quantidade)
            .Take(quantidade)
            .Select(seguro => new CotacaoModel
            {
                Id = seguro.Id,
                ValorTotal = seguro.ValorTotal,
                ValorParcela = seguro.ValorParcela,
                QuantidadeParcelas = seguro.QuantidadeParcelas,
                CriadoEm = seguro.CriadoEm,
                NomeItem = _context.Itens.Where(item => item.Id == seguro.ItemId)
                .Select(item => new Item
                {
                    Nome = item.Nome
                })
                .FirstOrDefault().Nome
            })
            .ToList();
        }

        public Seguro? BuscarSeguroPorId(Guid id)
        {
            return _seguros.Where(seguro => seguro.Id == id)
                .Include(seguro => seguro.Item)
                .FirstOrDefault();
        }
    }
}
