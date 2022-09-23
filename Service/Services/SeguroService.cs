using Domain.Entities;
using Domain.Models;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class SeguroService: ISeguroService
    {
        private readonly ISeguroRepository _seguroRepository;

        public SeguroService(ISeguroRepository seguroRepository)
        {
            _seguroRepository = seguroRepository;
        }

        public void CriarSeguro(CriarItemModel modelo, Usuario usuario)
        {
            var cotacao = ProcessarSeguro(modelo);
            var item = new Item
            {
                Nome = modelo.Nome,
                Tipo = modelo.Tipo,
                ValorEstimado = modelo.ValorEstimado,
                DataAquisicaoItem = modelo.DataAquisicaoItem,
                UsuarioId = usuario.Id,
                UsuarioCriou = usuario.Email
            };

            var seguro = new Seguro
            {
                ValorTotal = cotacao.ValorTotal,
                ValorParcela = cotacao.ValorParcela,
                QuantidadeParcelas = cotacao.QuantidadeParcelas,
                UsuarioId = usuario.Id,
                ItemId = item.Id,
                Item = item,
                UsuarioCriou = usuario.Email
            };

            _seguroRepository.Add(seguro);
        }

        public CotacaoModel ProcessarSeguro(CriarItemModel modelo)
        {
            // 10% Valor Estimado + 10 reais por ano de uso
            var valorTotal = (modelo.ValorEstimado * 0.1m) + ((DateTime.Now.Year - modelo.DataAquisicaoItem.Year) * 10);

            var cotacao = new CotacaoModel
            {
                ValorTotal = valorTotal,
                ValorParcela = valorTotal / 12,
                QuantidadeParcelas = 12,
                NomeItem = modelo.Nome,
            };

            return cotacao;
        }

        public List<CotacaoModel>? BuscarSeguros(Guid usuarioId, string busca = "", int pagina = 0, int quantidade = 15)
        {
            return _seguroRepository.BuscarSeguros(usuarioId, busca, pagina, quantidade);
        }

        public Seguro? BuscarSeguroPorId(Guid id)
        {
            return _seguroRepository.BuscarSeguroPorId(id);
        }
    }
}
