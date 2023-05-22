using CamposDealerWebProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CamposDealerWebProject.Repositories.Interfaces
{
    public interface IVendaRepository
    {
        IEnumerable<Venda> Vendas { get; }
    }
}
