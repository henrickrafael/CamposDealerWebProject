using CamposDealerWebProject.Context;
using CamposDealerWebProject.Models;
using CamposDealerWebProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CamposDealerWebProject.Repositories
{
    public class VendaRepository : IVendaRepository
    {

        private readonly AppDbContext _context;

        public VendaRepository(AppDbContext context)
            => _context = context;

        public IEnumerable<Venda> Vendas => _context.Vendas
            .Include(venda => venda.Cliente.NmCliente)
            .Include(venda => venda.Produto.DscProduto);

        public Venda GetVendaByClienteName(string nmCliente) => _context.Vendas
            .Include(venda => venda.Cliente.NmCliente)
            .Include(venda => venda.Produto.DscProduto)
            .FirstOrDefault(venda => venda.Cliente.NmCliente.Equals(nmCliente));

        public Venda GetVendaByDscProduto(string dscProduto) => _context.Vendas
            .Include(venda => venda.Cliente.NmCliente)
            .Include(venda => venda.Produto.DscProduto)
            .FirstOrDefault(venda => venda.Produto.DscProduto.Equals(dscProduto));

    }
}
