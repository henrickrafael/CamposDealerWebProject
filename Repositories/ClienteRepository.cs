using CamposDealerWebProject.Context;
using CamposDealerWebProject.Models;
using CamposDealerWebProject.Repositories.Interfaces;

namespace CamposDealerWebProject.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
           => _context = context;

        public IEnumerable<Cliente> Clientes => _context.Clientes;

        public IEnumerable<Cliente> GetClienteByNome(string nmCliente)
        {
            if(!string.IsNullOrWhiteSpace(nmCliente))
               return _context.Clientes.Where(cliente => cliente.NmCliente.ToLower().Equals(nmCliente.ToLower()));

            return _context.Clientes.OrderBy(cliente => cliente.IdCliente);
        }
            
    }
}
