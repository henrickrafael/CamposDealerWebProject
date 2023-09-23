using CamposDealerWebProject.Models;

namespace CamposDealerWebProject.Repositories.Interfaces
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> Produtos { get; }

        IEnumerable<Produto> GetProductByDescription(string dscProduto);

        public Task<Produto> GetProductById(int id);

        public Task UpdateProductById(Produto produto);

        public Task DeleteProductById(int id);

        public Task AddProduct(Produto produto);

        public Task<List<Produto>> GetAllProducts();
    }
}
