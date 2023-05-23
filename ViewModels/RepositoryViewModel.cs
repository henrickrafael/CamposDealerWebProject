using CamposDealerWebProject.Models;

namespace CamposDealerWebProject.ViewModels
{

    public class RepositoryViewModel
    {
        public RepositoryViewModel() { }       

        public RepositoryViewModel(IEnumerable<Cliente> clientes, IEnumerable<Produto> produtos, IEnumerable<Venda> vendas)
        {
            Clientes = clientes;
            Produtos = produtos;
            Vendas = vendas;
        }
        public IEnumerable<Cliente> Clientes { get; set; }
        
        public IEnumerable<Produto> Produtos { get; set; }
        
        public IEnumerable<Venda> Vendas { get; set; }

        public Cliente cliente;
    }
}
