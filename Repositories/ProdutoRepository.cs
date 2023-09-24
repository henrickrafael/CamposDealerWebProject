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

        public List<Produto> GetAllProductsResult()
        {
            var produtos = _context.Produtos.ToList();
            return produtos;
        }

        public IEnumerable<Produto> GetProductByDescription(string dscProduto)
            => _context.Produtos.Where(produto => produto.DscProduto.ToLower().Equals(dscProduto.ToLower()));

        public async Task<Produto> GetProductById(int id)
        {
            var produto = await _context.Produtos.AsNoTracking()
                .SingleOrDefaultAsync(c => c.IdProduto.Equals(id));

            return produto;
        }

        public async Task UpdateProductById(Produto produto)
        {
            var consultaProduto = await GetProductById(produto.IdProduto);

            if (consultaProduto != null)
            { 
                _context.Produtos.Update(produto);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteProductById(int id)
        {
            var consultaProduto = await GetProductById(id);

            if (consultaProduto != null)
            {
                _context.Produtos.Remove(consultaProduto);
                await _context.SaveChangesAsync();
            }
        }
    }
}
