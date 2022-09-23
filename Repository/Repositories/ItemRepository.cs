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
    public class ItemRepository : RepositoryBase<Item>, IItemRepository
    {
        private readonly DbSet<Item> _itens;

        public ItemRepository(AppDbContext easyChefContext) : base(easyChefContext)
        {
            _itens = easyChefContext.Itens;
        }

        public List<Item>? BuscarItens(string busca, int pagina, int quantidade)
        {
            return _itens.Where(item =>
                item.Nome.ToLower().Contains(busca.ToLower()) ||
                item.Tipo.ToLower().Contains(busca.ToLower())
            )
            .OrderBy(seguro => seguro.CriadoEm)
            .Skip(pagina * quantidade)
            .Take(quantidade)
            .ToList();
        }
    }
}
