using CamposDealerWebProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CamposDealerWebProject.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> Clientes { get; }

        public Task<Cliente> GetClientByName(string nmCliente);

        public Task AddClient(Cliente cliente);

        public Task DeleteClientById(int idCliente);

        public Task UpdateClientById(Cliente cliente);

        public Task<Cliente> GetClientById(int idCliente);

        public Task<Cliente> GetClientByIdAsNoTracking(int idCliente);

        public Task<List<Cliente>> GetAllClients();

        public List<Cliente> GetAllClientsResult();
    }

}
