using CamposDealerWebProject.Context;
using CamposDealerWebProject.Models;
using CamposDealerWebProject.Repositories;
using CamposDealerWebProject.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;

namespace CamposDealerWebProject.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController(IProdutoRepository produto)
        {
            _produtoRepository = produto;
        }

        public async Task<IActionResult> Index(string produto)
        {
            try
            {

                ModelState.Clear();

                var produtoEncoded = Convert.FromBase64String(produto);
                var produtoDecoded = System.Text.Encoding.UTF8.GetString(produtoEncoded);                
                var produtoResult = JsonConvert.DeserializeObject<Produto>(produtoDecoded);

                if (produtoResult == null)
                {
                    return PartialView("_ConsultaNaoLocalizada");
                }

                return PartialView("../Produtos/_ProdutosPartial", new List<Produto> { produtoResult });
            }
            catch (Exception)
            {
                return PartialView("../Produtos/_ProdutosPartial", await _produtoRepository.GetAllProducts());
            }            
        }

        [HttpPost]
        public async Task<JsonResult> AddProduct(Produto produto)
        {
            if (ModelState.IsValid)
            {
                await _produtoRepository.AddProduct(produto);
            }

            return Json(ModelState);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateProductById(Produto produto)
        {
            if (ModelState.IsValid)
            {
                await _produtoRepository.UpdateProductById(produto);
            }

            return Json(ModelState);
        }

        [HttpGet]
        public async Task<JsonResult> GetProductById(int id)
        {
            if (ModelState.IsValid)
            {
                var produto = await _produtoRepository.GetProductById(id);
                return Json(produto);
            }

            return Json(ModelState);
        }

        [HttpGet]
        public async Task<JsonResult> GetProductByDescription(string dscProduto)
        {
            if (ModelState.IsValid && !string.IsNullOrWhiteSpace(dscProduto))
            {
                var produto = await _produtoRepository.GetProductByDescription(dscProduto);
                return Json(produto);
            }

            return Json(ModelState);
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteProductById(int id)
        {
            if (ModelState.IsValid)
            { 
                await _produtoRepository.DeleteProductById(id);
            }

            return Json(ModelState);
        }

    }
}
