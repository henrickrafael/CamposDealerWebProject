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
            .Include(venda => venda.Cliente)
            .Include(venda => venda.Produto);

        public Venda GetVendaByClienteName(string nmCliente) => _context.Vendas
            .Include(venda => venda.Cliente)
            .Include(venda => venda.Produto)
            .FirstOrDefault(venda => venda.Cliente.NmCliente.Equals(nmCliente));

        public Venda GetVendaByDscProduto(string dscProduto) => _context.Vendas
            .Include(venda => venda.Cliente)
            .Include(venda => venda.Produto)
            .FirstOrDefault(venda => venda.Produto.DscProduto.Equals(dscProduto));

    }
}
