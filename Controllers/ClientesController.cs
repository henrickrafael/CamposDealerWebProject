using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CamposDealerWebProject.Context;
using CamposDealerWebProject.Models;
using CamposDealerWebProject.Repositories.Interfaces;

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
    }
}
