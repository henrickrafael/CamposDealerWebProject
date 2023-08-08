using CamposDealerWebProject.Context;
using CamposDealerWebProject.Models;
using CamposDealerWebProject.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CamposDealerWebProject.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
           => _context = context;

        public IEnumerable<Cliente> Clientes => _context.Clientes;
        
        public async Task AddClient(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClientById(int idCliente)
        {
            var cliente = await _context.Clientes.FindAsync(idCliente);

            if (cliente != null) {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Cliente> GetClientById(int idCliente)
        {
            var cliente = await _context.Clientes.FindAsync(idCliente);            
            return cliente;
        }

        public IEnumerable<Cliente> GetClientByName(string nmCliente)
        {
            if(!string.IsNullOrWhiteSpace(nmCliente))
               return _context.Clientes.Where(cliente => cliente.NmCliente.Equals(nmCliente, StringComparison.InvariantCultureIgnoreCase));

            return _context.Clientes.OrderBy(cliente => cliente.IdCliente);
        }

        public async Task UpdateClientById(int idCliente)
        {
            var cliente = await _context.Clientes.FindAsync(idCliente);

            if (cliente != null) {
                _context.Clientes.Update(cliente);
                await _context.SaveChangesAsync();
            }
        }
    }
}
