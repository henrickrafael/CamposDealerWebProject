using Microsoft.AspNetCore.Mvc;
using CamposDealerWebProject.Models;
using CamposDealerWebProject.Repositories.Interfaces;
using CamposDealerWebProject.Repositories;

namespace CamposDealerWebProject.Controllers;

public class ClientesController : Controller
{
    //TODO: Refatorar métodos        
    private readonly IUnityOfWork _unityOfWork;

    public ClientesController()
    {
        _unityOfWork = new UnityOfWork();
    }

    public IActionResult Index()
    {
        //try
        //{
        //    ModelState.Clear();

        //    var clienteEncoded = Convert.FromBase64String(cliente);
        //    var clienteDecoded = System.Text.Encoding.UTF8.GetString(clienteEncoded);                
        //    var clienteResult = JsonConvert.DeserializeObject<List<Cliente>>(clienteDecoded);

        //    if (clienteResult is null || clienteResult.Count == 0)
        //    {
        //        return PartialView("_ConsultaNaoLocalizada");
        //    }

        //    return PartialView("../Clientes/_ClientesPartial", clienteResult);
        //}

        //catch (Exception)
        //{
        //    return PartialView("../Clientes/_ClientesPartial", await _clienteRepository.GetAllClients());
        //}

        return View();
                    
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync(Cliente cliente)
    {
        if (ModelState.IsValid)
        {            
            await _unityOfWork.ClientRepository.AddAsync(cliente);
            await _unityOfWork.CommitAsync();
        }
        
        return PartialView("_ClientesPartial", _unityOfWork.ClientRepository.GetAll());
    }

    //[HttpPost]
    //public async Task<JsonResult> UpdateClientById(Cliente cliente)
    //{

    //    if (ModelState.IsValid)
    //    {
    //        await _clienteRepository.UpdateClientById(cliente);
    //    }

    //    return Json(ModelState);
    //}

    //[HttpGet]
    //public async Task<JsonResult> GetClientById(int id)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        var cliente = await _clienteRepository.GetClientById(id);
    //        return Json(cliente);
    //    }

    //    return Json(ModelState);
    //}

    //[HttpGet]
    //public async Task<JsonResult> GetClientByName(string nmCliente)
    //{
    //    if (ModelState.IsValid && !string.IsNullOrWhiteSpace(nmCliente))
    //    {
    //        var cliente = await _clienteRepository.GetClientByName(nmCliente);
    //        return Json(cliente);
    //    }

    //    return Json(ModelState);
    //}

    //[HttpDelete]
    //public async Task<JsonResult> DeleteClientById(int id)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        await _clienteRepository.DeleteClientById(id);
    //    }

    //    return Json(ModelState);
    //}
}
