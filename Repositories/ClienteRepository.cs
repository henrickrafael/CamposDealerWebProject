using CamposDealerWebProject.Context;
using CamposDealerWebProject.Models;
using CamposDealerWebProject.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var buscaCliente = await GetClientByIdAsNoTracking(idCliente);            

            if (buscaCliente != null) {                
                _context.Clientes.Remove(buscaCliente);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Cliente>> GetAllClients()
        {
            return await _context.Clientes.ToListAsync();
        }

        public List<Cliente> GetAllClientsResult()
        {
            var result = _context.Clientes.ToList();
            return result;
        }

        public async Task<Cliente> GetClientById(int idCliente)
        {
            var cliente = await _context.Clientes.FindAsync(idCliente);            
            return cliente;
        }

        public async Task<Cliente> GetClientByIdAsNoTracking(int idCliente)
        {
            return await _context.Clientes.AsNoTracking()
                        .SingleOrDefaultAsync(c => c.IdCliente.Equals(idCliente));
        }

        public async Task<Cliente> GetClientByName(string nmCliente)
        {
            if (!string.IsNullOrWhiteSpace(nmCliente))
            {
                var cliente = await _context.Clientes
                                    .SingleOrDefaultAsync(c => c.NmCliente.ToLower().Equals(nmCliente.ToLower()));

                return cliente;
            }
            
            return null;
        }

        public async Task UpdateClientById(Cliente cliente)
        {
            var buscaCliente = await GetClientByIdAsNoTracking(cliente.IdCliente);            

            if (buscaCliente != null)
            {
                _context.Clientes.Update(cliente);
                await _context.SaveChangesAsync();
            }
           
        }
    }
}
