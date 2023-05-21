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

        public Cliente GetClienteByName(string nmCliente)
            => _context.Clientes.FirstOrDefault(cliente => cliente.NmCliente.Equals(nmCliente));
    }
}
