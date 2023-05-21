using CamposDealerWebProject.Models;

namespace CamposDealerWebProject.ViewModels
{
    public class RepositoryViewModel
    {
        public IEnumerable<Cliente> Clientes { get; set; }
        
        public IEnumerable<Produto> Produtos { get; set; }
        
        public IEnumerable<Venda> Vendas { get; set; }
    }
}
