using CamposDealerWebProject.Models;
using CamposDealerWebProject.Repositories;
using CamposDealerWebProject.Repositories.Interfaces;
using CamposDealerWebProject.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CamposDealerWebProject.Controllers;

public class HomeController : Controller
{        
    private readonly UnityOfWork _unityOfWork;    

    public HomeController()
    {
        _unityOfWork = new UnityOfWork();                
    }
    
    public IActionResult Index()
    {            
        return View(new ClienteProdutoViewModel
        {
            Clientes = _unityOfWork.ClientRepository.GetAll().ToList(),
            Produtos = _unityOfWork.ProdutoRepository.GetAll().ToList(),
            Vendas = _unityOfWork.VendaRepository.GetAll().ToList()
        });

    }

    [HttpGet]
    public Task<JsonResult> GetViewModel()
    {            
        return Task.FromResult(Json(new ClienteProdutoViewModel
        {
            Clientes = _unityOfWork.ClientRepository.GetAll().ToList(),
            Produtos = _unityOfWork.ProdutoRepository.GetAll().ToList(),
            Vendas = _unityOfWork.VendaRepository.GetAll().ToList()
        }));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }    
}