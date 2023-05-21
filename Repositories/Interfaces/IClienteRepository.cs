using CamposDealerWebProject.Models;

namespace CamposDealerWebProject.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> Clientes { get; }

        Cliente GetClienteByName(string nmCliente);
    }
}
