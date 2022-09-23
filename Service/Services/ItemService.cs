using Domain.Entities;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public List<Item>? BuscarItens(string busca = "", int pagina = 0, int quantidade = 15)
        {
            return _itemRepository.BuscarItens(busca, pagina, quantidade);
        }

        public Item? BuscarItem(Guid id)
        {
            return _itemRepository.GetById(id);
        }
    }
}
