using CamposDealerWebProject.Models;
using CamposDealerWebProject.Repositories.Interfaces;
using CamposDealerWebProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CamposDealerWebProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IVendaRepository _vendaRepository;

        public HomeController(IClienteRepository cliente, IProdutoRepository produto, IVendaRepository venda)
        {
            _clienteRepository = cliente;
            _produtoRepository = produto;
            _vendaRepository = venda;
        }

        public IActionResult Index()
        {
            var repositoryViewModel = new RepositoryViewModel
            {
                Clientes = _clienteRepository.Clientes,
                Produtos = _produtoRepository.Produtos,
                Vendas = _vendaRepository.Vendas
            };

            return View(repositoryViewModel);
        }

        public ViewResult SearchClient(string nmCliente)
        {
            IEnumerable<Cliente> clientes;

            if (string.IsNullOrWhiteSpace(nmCliente))
                clientes = _clienteRepository.Clientes.OrderBy(c => c.IdCliente);
            else
                clientes = _clienteRepository.Clientes.Where(c => c.NmCliente.ToLower().Equals(nmCliente.ToLower()));

            return View("~/Views/Home/Index.cshtml", new RepositoryViewModel
            { 
                Clientes = clientes,
                Produtos = _produtoRepository.Produtos,
                Vendas = _vendaRepository.Vendas
            });
        }

        public ViewResult SearchProduct(string dscProduto)
        {
            IEnumerable<Produto> produtos;

            if (string.IsNullOrWhiteSpace(dscProduto))
                produtos = _produtoRepository.Produtos.OrderBy(p => p.IdProduto);
            else
                produtos = _produtoRepository.Produtos.Where(p => p.DscProduto.ToLower().Equals(dscProduto.ToLower()));

            return View("~/Views/Home/Index.cshtml", new RepositoryViewModel
            {
                Clientes = _clienteRepository.Clientes,
                Produtos = produtos,
                Vendas = _vendaRepository.Vendas
            });
        }

        public ViewResult SearchSaleClient(string nmClient)
        {
            IEnumerable<Venda> vendas;

            if (string.IsNullOrWhiteSpace(nmClient))
                vendas = _vendaRepository.Vendas.OrderBy(v => v.IdVenda);
            else
                vendas = _vendaRepository.Vendas.Where(v => v.Cliente.NmCliente.ToLower().Equals(nmClient.ToLower()));

            return View("~/Views/Home/Index.cshtml", new RepositoryViewModel
            {
                Clientes = _clienteRepository.Clientes,
                Produtos = _produtoRepository.Produtos,
                Vendas = vendas
            });
        }

        public ViewResult SearchSaleProduct(string dscProduct)
        {
            IEnumerable<Venda> vendas;

            if (string.IsNullOrWhiteSpace(dscProduct))
                vendas = _vendaRepository.Vendas.OrderBy(v => v.IdVenda);
            else
                vendas = _vendaRepository.Vendas.Where(v => v.Produto.DscProduto.ToLower().Equals(dscProduct.ToLower()));

            return View("~/Views/Home/Index.cshtml", new RepositoryViewModel
            {
                Clientes = _clienteRepository.Clientes,
                Produtos = _produtoRepository.Produtos,
                Vendas = vendas
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}