using CamposDealerWebProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CamposDealerWebProject.Repositories.Interfaces
{
    public interface IVendaRepository
    {
        IEnumerable<Venda> Vendas { get; }

        public Task<List<Venda>> GetVendaByNomeCliente(string nmCliente);

        public Task<List<Venda>> GetVendaByDscProduto(string dscProduto);

        public Task<Venda> GetVendaById(int idVenda, IProdutoRepository produtoRepository);

        public Task<List<Venda>> GetAllVendas();

        public List<Venda> GetAllVendasResult();

        public Task AddSale(Venda venda);

        public Task UpdateSaleById(Venda venda);

        public Task DeleteSaleById(int id);
    }
}
