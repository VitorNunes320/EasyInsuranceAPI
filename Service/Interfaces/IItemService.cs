using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IItemService
    {
        public List<Item>? BuscarItens(string busca = "", int pagina = 0, int quantidade = 15);
        
        public Item? BuscarItem(Guid id);
    }
}
