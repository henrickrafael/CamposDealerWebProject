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
    private readonly UnityOfWork _unityOfWork;
    private readonly List<Venda> _vendas;

    public HomeController(IVendaRepository vendaRepository)
    {
        _unityOfWork = new UnityOfWork();        
        _vendas = vendaRepository.GetAllVendasResult();
    }
    
    public IActionResult Index()
    {            
        return View(new ClienteProdutoViewModel
        {
            Clientes = _unityOfWork.ClientRepository.GetAll(),
            Produtos = _unityOfWork.ProdutoRepository.GetAll(),
            Vendas = _vendas
        });

    }

    [HttpGet]
    public Task<JsonResult> GetViewModel()
    {            
        return Task.FromResult(Json(new ClienteProdutoViewModel
        {
            Clientes = _unityOfWork.ClientRepository.GetAll(),
            Produtos = _unityOfWork.ProdutoRepository.GetAll(),
            Vendas = _vendas
        }));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }    
}