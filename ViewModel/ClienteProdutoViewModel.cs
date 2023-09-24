using CamposDealerWebProject.Models;

namespace CamposDealerWebProject.ViewModel
{
    public class ClienteProdutoViewModel
    {
        public List<Produto> produtos { get; set; }

        public List<Cliente> clientes { get; set; }

        public List<Venda> vendas { get; set; }
    }
}
