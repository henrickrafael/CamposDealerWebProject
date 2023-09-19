using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CamposDealerWebProject.Context;
using CamposDealerWebProject.Models;
using CamposDealerWebProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CamposDealerWebProject.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteRepository _clienteRepository;

        public ClientesController(IClienteRepository cliente)
        {
            _clienteRepository = cliente;
        }
        
        public async Task<IActionResult> Index()
        {
            return PartialView("../Clientes/_ClientesPartial", await _clienteRepository.GetAllClients());
        }

        [HttpPost]
        public async Task<JsonResult> AddClient(Cliente cliente)
        {
            if (ModelState.IsValid)
            { 
                await _clienteRepository.AddClient(cliente);                
            }

            return Json(ModelState);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateClientById(Cliente cliente)
        {

            if (ModelState.IsValid)
            {
                await _clienteRepository.UpdateClientById(cliente);
            }

            return Json(ModelState);
        }

        [HttpGet]
        public async Task<JsonResult> GetClientById(int id)
        {
            if (ModelState.IsValid)
            {
                var cliente = await _clienteRepository.GetClientById(id);
                return Json(cliente);
            }

            return Json(ModelState);
        }
    }
}
