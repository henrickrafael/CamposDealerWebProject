using CamposDealerWebProject.Context;
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
    }
}
