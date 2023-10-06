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

        //TODO: Identificado um bug que ao selecionar um último item da lista e depois na opção de inserir, ele está atualizando o último item selecionado ao invés de inlcuir um novo, devem ser verificado os 3 crud's        
        //TODO: Faltam ainda as opções de pesquisa para cada um dos 3. A venda tem duas opções de pesquisa.
        //TODO: Criação de método para realização de carga de dados via API.
        //TODO: aplicar sweet alert eventualmente
    }
}