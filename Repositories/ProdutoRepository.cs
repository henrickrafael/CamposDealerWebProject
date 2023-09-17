using CamposDealerWebProject.Context;
using CamposDealerWebProject.Models;
using CamposDealerWebProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CamposDealerWebProject.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
            => _context = context;

        public IEnumerable<Produto> Produtos => _context.Produtos;

        public async Task AddProduct(Produto produto)
        {
            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Produto>> GetAllProducts()
        {            
            return await _context.Produtos.ToListAsync();
        }

        public IEnumerable<Produto> GetProductByDescription(string dscProduto)
            => _context.Produtos.Where(produto => produto.DscProduto.ToLower().Equals(dscProduto.ToLower()));
    }
}
