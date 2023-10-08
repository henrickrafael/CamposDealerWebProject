using CamposDealerWebProject.Models;

namespace CamposDealerWebProject.ViewModel
{
    public class ClienteProdutoViewModel
    {
        public List<Produto> Produtos { get; set; }

        public List<Cliente> Clientes { get; set; }

        public List<Venda> Vendas { get; set; }
    }
}
