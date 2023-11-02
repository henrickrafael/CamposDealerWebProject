using Azure.Core.Pipeline;
using CamposDealerWebProject.Api.Helpers;
using CamposDealerWebProject.Enums;
using CamposDealerWebProject.Models;
using CamposDealerWebProject.Repositories;
using CamposDealerWebProject.Repositories.Interfaces;
using CamposDealerWebProject.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.Protocol;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;

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
            TestarTipo();
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

        public Type GetClassTypeByEnumName(string name)
        {

            IDictionary<string, Type> dictionaryModel = new Dictionary<string, Type>
            {
                { nameof(Cliente), typeof(Cliente) },
                { nameof(Produto), typeof(Produto) },
                { nameof(Venda), typeof(Venda) }
            };

            var modelNameEnum = Enum.GetNames(typeof(TipoModel)).Where(t => t.Equals(name)).SingleOrDefault();
            var modelName = modelNameEnum.Remove(modelNameEnum.Length -1, 1);

            dictionaryModel.TryGetValue(modelName, out var classType);
            return classType;
        }

        public async void TestarTipo() 
        {

            var endPoint = "Cliente";
            Api.ApiClient api = new();
            var apiResponse = await api.GetData<Cliente>(nameof(Cliente), ApiClassHelper.GetHttpClient(
                                                                   ApiClassHelper.GetUrlFromConfigurationFile("UrlApi:CamposDealerBaseUrl"))
            );           
            
        }       

        //TODO 1 [Obrigatorio]: Criação de método para realização de carga de dados via API.        
        //TODO 2 [Melhoria]: Criar um método genérico para tratar os retornos de texto dos outros 3 controlers. (Remover código triplicado)    
        //TODO 3 [Melhoria]: aplicar sweet alert eventualmente
        //TODO 4 [Melhoria]: realizar validação de campos com javascript
    }
}