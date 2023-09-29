using CamposDealerWebProject.Context;
using CamposDealerWebProject.Models;
using CamposDealerWebProject.Repositories;
using CamposDealerWebProject.Repositories.Interfaces;
using CamposDealerWebProject.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        [HttpGet]
        public PartialViewResult GetUpdatedSaleIndex(string model)
        {            
            var modelDataEncoded = Convert.FromBase64String(model);
            var modelDataDecoded = System.Text.Encoding.UTF8.GetString(modelDataEncoded);

            var result = JsonConvert.DeserializeObject<ClienteProdutoViewModel>(modelDataDecoded);
            return PartialView("../Vendas/_ModalPartialVenda", result);
        }

    }
}
