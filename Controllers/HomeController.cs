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

        [HttpGet]
        public Task<JsonResult> GetViewModel()
        {
            return Task.FromResult(Json(new ClienteProdutoViewModel
            {
                clientes = _clienteRepository.GetAllClientsResult(),
                produtos = _produtoRepository.GetAllProductsResult(),
                vendas = _vendaRepository.GetAllVendasResult()
            }));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        //TODO 1: Faltam ainda as opções de pesquisa para cada um dos 3. A venda tem duas opções de pesquisa.
            //TODO 1.1: Busca de cliente por nome do cliente (NOK)
            //TODO 1.2: Busca de produto por descrição do produto (NOK)
            //TODO 1.3: Busca de venda por nome do cliente (NOK)
            //TODO 1.4: Busca de venda por descrição do produto (NOK)

        //TODO 2: Criação de método para realização de carga de dados via API.
        //TODO 3: aplicar sweet alert eventualmente
    }
}