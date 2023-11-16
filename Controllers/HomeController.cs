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
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace CamposDealerWebProject.Controllers;

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
        return View(new ClienteProdutoViewModel
        {
            Clientes = _clienteRepository.GetAllClientsResult(),
            Produtos = _produtoRepository.GetAllProductsResult(),
            Vendas = _vendaRepository.GetAllVendasResult()
        });

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

    [HttpGet]
    public async Task PopulateDatabaseUsingApi() 
    {
        Api.ApiClient api = new();
        var enumArray = Enum.GetValues(typeof(TipoModel));

        foreach (var item in enumArray)
        {
            var resultType = (TipoModel) item;
            var apiResponse = await ApiClassHelper.GetObjects(resultType, api);            

            switch (resultType)
            {
                case TipoModel.Clientes:
                    foreach (var obj in apiResponse)
                    {
                        var cliente = (Cliente) obj;
                        cliente.IdCliente = 0;

                        await _clienteRepository.AddClient(cliente);
                    }
                    break;

                case TipoModel.Produtos:
                    foreach (var obj in apiResponse)
                    {
                        var produto = (Produto) obj;
                        produto.IdProduto = 0;

                        await _produtoRepository.AddProduct(produto);
                    }
                    break;

                case TipoModel.Vendas:
                    foreach (var obj in apiResponse)
                    {
                        var venda = (Venda) obj;
                        venda.IdVenda = 0;

                        await _vendaRepository.AddSale(venda);
                    }
                    break;
            }
            
        }        
    }    
}