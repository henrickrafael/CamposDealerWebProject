using CamposDealerWebProject.Models;

namespace CamposDealerWebProject.ViewModel
{
    public class ClienteProdutoViewModel
    {
        public IEnumerable<Produto> Produtos { get; set; }

        public IEnumerable<Cliente> Clientes { get; set; }

        public IEnumerable<Venda> Vendas { get; set; }
    }
}
