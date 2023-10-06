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

        public IEnumerable<Venda> GetVendaByDscProduto(string dscProduto)
        {
            if (!string.IsNullOrWhiteSpace(dscProduto))
                return _context.Vendas.Include(venda => venda.Cliente)
                                      .Include(venda => venda.Produto)
                                      .Where(venda => venda.Produto.DscProduto.ToLower().Equals(dscProduto.ToLower()));

            return _context.Vendas.Include(venda => venda.Cliente)
                                  .Include(venda => venda.Produto).OrderBy(venda => venda.IdVenda);
        }

        public async Task<List<Venda>> GetAllVendas() 
        {
            return await _context.Vendas
                                 .Include(venda => venda.Cliente)
                                 .Include(venda => venda.Produto).ToListAsync();
        }

        public List<Venda> GetAllVendasResult()
        {
            return _context.Vendas
                           .Include(venda => venda.Cliente)
                           .Include(venda => venda.Produto).ToList();
        }

        public async Task AddSale(Venda venda)
        {
            await _context.Vendas.AddAsync(venda);
            await _context.SaveChangesAsync();
        }

        public async Task<Venda> GetVendaById(int idVenda, IProdutoRepository produtoRepository)
        {
           var vendaResult = await _context.Vendas.FindAsync(idVenda);
           vendaResult.Produto = await produtoRepository.GetProductById(vendaResult.ProdutoId);

           return vendaResult;
        }

        public async Task<Venda> GetVendaAsyncWithNoTracking(int id)
        {
            return await _context.Vendas.AsNoTracking()
                                        .SingleOrDefaultAsync(c => c.IdVenda.Equals(id));
        }

        public async Task UpdateSaleById(Venda venda)
        {
            var consultaVenda = await GetVendaAsyncWithNoTracking(venda.IdVenda);

            if (consultaVenda != null)
            {
                _context.Vendas.Update(venda);
                await _context.SaveChangesAsync();
            }
        }

        public IEnumerable<Venda> GetVendaByNomeCliente(string nmCliente)
        {
            if (!string.IsNullOrWhiteSpace(nmCliente))
                return _context.Vendas.Include(venda => venda.Cliente)
                                      .Include(venda => venda.Produto)
                                      .Where(venda => venda.Cliente.NmCliente.ToLower().Equals(nmCliente.ToLower()));

            return _context.Vendas.Include(venda => venda.Cliente)
                                  .Include(venda => venda.Produto).OrderBy(venda => venda.IdVenda);
        }

        public async Task DeleteSaleById(int id)
        {
            var consultaVenda = await GetVendaAsyncWithNoTracking(id);

            if (consultaVenda != null)
            {
                _context.Vendas.Remove(consultaVenda);
                await _context.SaveChangesAsync();
            }

        }
    }
}
