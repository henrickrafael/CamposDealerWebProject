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
            return View(new ClienteProdutoViewModel { Clientes = _clienteRepository.GetAllClientsResult(), 
                                                      Produtos = _produtoRepository.GetAllProductsResult(),
                                                      Vendas = _vendaRepository.GetAllVendasResult()});
        }

        [HttpGet]
        public Task<JsonResult> GetViewModel()
        {
            return Task.FromResult(Json(new ClienteProdutoViewModel
            {
                Clientes = _clienteRepository.GetAllClientsResult(),
                Produtos = _produtoRepository.GetAllProductsResult(),
                Vendas = _vendaRepository.GetAllVendasResult()
            }));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        
        //TODO 1: Criação de método para realização de carga de dados via API.
        //TODO 2: aplicar sweet alert eventualmente
    }
}