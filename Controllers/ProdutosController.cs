using CamposDealerWebProject.Context;
using CamposDealerWebProject.Models;
using CamposDealerWebProject.Repositories;
using CamposDealerWebProject.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CamposDealerWebProject.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController(IProdutoRepository produto)
        {
            _produtoRepository = produto;
        }

        public async Task<IActionResult> Index()
        {
            return PartialView("../Produtos/_ProdutosPartial", await _produtoRepository.GetAllProducts());
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
    }
}
