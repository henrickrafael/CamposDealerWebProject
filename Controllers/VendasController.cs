using CamposDealerWebProject.Context;
using CamposDealerWebProject.Enums;
using CamposDealerWebProject.Models;
using CamposDealerWebProject.Repositories;
using CamposDealerWebProject.Repositories.Interfaces;
using CamposDealerWebProject.ViewModel;
using MessagePack.Formatters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.Protocol;
using System.Diagnostics;

namespace CamposDealerWebProject.Controllers

{
    public class VendasController : Controller
    {
        
        private readonly IVendaRepository _vendaRepository;
        private readonly IProdutoRepository _produtoRepository;

        public VendasController(IVendaRepository vendaRepository, IProdutoRepository produtoRepository)
        {
            _vendaRepository = vendaRepository;
            _produtoRepository = produtoRepository;
        }

        public async Task<IActionResult> Index(string venda)
        {
            try
            {
                ModelState.Clear();

                var vendaEncoded = Convert.FromBase64String(venda);
                var vendaDecoded = System.Text.Encoding.UTF8.GetString(vendaEncoded);                
                var vendaResult = JsonConvert.DeserializeObject<List<Venda>>(vendaDecoded);

                if (vendaResult == null)
                {
                    return PartialView("_ConsultaNaoLocalizada");
                }

                return PartialView("../Vendas/_VendasPartial", vendaResult);
            }

            catch (Exception)
            {
                return PartialView("../Vendas/_VendasPartial", await _vendaRepository.GetAllVendas());
            }            
        }

        [HttpGet]
        public PartialViewResult GetUpdatedSaleIndex(string model)
        {            
            var modelDataEncoded = Convert.FromBase64String(model);
            var modelDataDecoded = System.Text.Encoding.UTF8.GetString(modelDataEncoded);

            var result = JsonConvert.DeserializeObject<ClienteProdutoViewModel>(modelDataDecoded);
            return PartialView("../Vendas/_ModalPartialVenda", result);
        }

        [HttpGet]
        public async Task<JsonResult> GetVendaById(int id)
        {
            if (ModelState.IsValid)
            { 
                var result = await _vendaRepository.GetVendaById(id, _produtoRepository);
                return Json(result);
            }

            return Json(ModelState);
        }

        [HttpPost]
        public async Task<JsonResult> AddSale(Venda venda)
        {
            if (ModelState.IsValid)
            {
                await _vendaRepository.AddSale(venda);
            }

            return Json(ModelState);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateSaleById(Venda venda)
        {
            if (ModelState.IsValid)
            { 
                await _vendaRepository.UpdateSaleById(venda);
            }

            return Json(ModelState);
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteSaleById(int id)
        {
            if (ModelState.IsValid)
            {
                await _vendaRepository.DeleteSaleById(id);
            }

            return Json(ModelState);
        }

        [HttpGet]
        public async Task<JsonResult> GetSaleByParameter(string param)
        {
            if (ModelState.IsValid && !string.IsNullOrWhiteSpace(param))
            {
                var paramResult = JObject.Parse(param);
                var tipoModel = paramResult.SelectToken("tipoModel").ToString();

                if (tipoModel.Equals(nameof(TipoModel.Clientes)))
                {
                   var venda = await _vendaRepository.GetVendaByNomeCliente(paramResult.SelectToken("valorConsulta").ToString());
                   return Json(venda);
                }

                if (tipoModel.Equals(nameof(TipoModel.Produtos)))
                {
                    var venda = await _vendaRepository.GetVendaByDscProduto(paramResult.SelectToken("valorConsulta").ToString());
                    return Json(venda);
                }
            }

            return Json(ModelState);
        }
    }
}
