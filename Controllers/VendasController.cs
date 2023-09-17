using CamposDealerWebProject.Context;
using CamposDealerWebProject.Models;
using CamposDealerWebProject.Repositories;
using CamposDealerWebProject.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CamposDealerWebProject.Controllers

{
    public class VendasController : Controller
    {
        
        private readonly IVendaRepository _vendaRepository;

        public VendasController(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        public async Task<IActionResult> Index()
        {
            return PartialView("../Vendas/_VendasPartial", await _vendaRepository.GetAllVendas());
        }

    }
}
