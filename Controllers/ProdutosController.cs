using CamposDealerWebProject.Context;
using Microsoft.AspNetCore.Mvc;

namespace CamposDealerWebProject.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

    }
}
