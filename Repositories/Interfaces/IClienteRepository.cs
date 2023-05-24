using CamposDealerWebProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CamposDealerWebProject.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> Clientes { get; }

        public IEnumerable<Cliente> GetClienteByNome(string nmCliente);

        public Task AddCliente(Cliente cliente);

        public Task DeleteCliente(int idCliente);

        public Task UpdateCliete(int idCliente);

        public Task<Cliente> GetClienteById(int idCliente);
    }

}
