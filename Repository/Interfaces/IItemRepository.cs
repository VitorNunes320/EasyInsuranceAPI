using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Repository.Interfaces
{
    public interface IItemRepository : IRepositoryBase<Item>
    {
        List<Item>? BuscarItens(string busca, int pagina, int quantidade);
    }
}
