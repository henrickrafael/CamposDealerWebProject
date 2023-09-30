using CamposDealerWebProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CamposDealerWebProject.Repositories.Interfaces
{
    public interface IVendaRepository
    {
        IEnumerable<Venda> Vendas { get; }

        public IEnumerable<Venda> GetVendaByNomeCliente(string nmCliente);

        public IEnumerable<Venda> GetVendaByDscProduto(string dscProduto);

        public Task<List<Venda>> GetAllVendas();

        public List<Venda> GetAllVendasResult();

        public Task AddSale(Venda venda);
    }
}
