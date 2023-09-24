using Azure.Core.Pipeline;
using CamposDealerWebProject.Models;
using CamposDealerWebProject.Repositories;
using CamposDealerWebProject.Repositories.Interfaces;
using CamposDealerWebProject.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CamposDealerWebProject.Controllers
{
    public class HomeController : Controller
    {
        /*TODO: Avaliar a atualização dinâmica dos inputs="select" ou dropdonwlist, uma vez que pour utilizar os valores recebidos da model 
         * não atualiza em tempo real ao adicionar um novo produto ou cliente, por exemplo*/

        private readonly IProdutoRepository _produtoRepository;

        private readonly IClienteRepository _clienteRepository;        

        private readonly IVendaRepository _vendaRepository;        

        public HomeController(IProdutoRepository produtoRepository, IClienteRepository clienteRepository, IVendaRepository vendaRepository)
        {
            _produtoRepository = produtoRepository;
            _clienteRepository = clienteRepository;            
            _vendaRepository = vendaRepository;
        }       

        public IActionResult Index()
        {            
            return View(new ClienteProdutoViewModel { clientes = _clienteRepository.GetAllClientsResult(), 
                                                      produtos = _produtoRepository.GetAllProductsResult(),
                                                      vendas = _vendaRepository.GetAllVendasResult()});
        }      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}