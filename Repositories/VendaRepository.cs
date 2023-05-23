﻿using CamposDealerWebProject.Context;
using CamposDealerWebProject.Models;
using CamposDealerWebProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CamposDealerWebProject.Repositories
{
    public class VendaRepository : IVendaRepository
    {

        private readonly AppDbContext _context;

        public VendaRepository(AppDbContext context)
            => _context = context;

        public IEnumerable<Venda> Vendas => _context.Vendas
            .Include(venda => venda.Cliente)
            .Include(venda => venda.Produto);

        public IEnumerable<Venda> GetVendaByDscProduto(string dscProduto)
        {
            if (!string.IsNullOrWhiteSpace(dscProduto))
                return _context.Vendas.Include(venda => venda.Cliente).Include(venda => venda.Produto).Where(venda => venda.Produto.DscProduto.ToLower().Equals(dscProduto.ToLower()));

            return _context.Vendas.Include(venda => venda.Cliente).Include(venda => venda.Produto).OrderBy(venda => venda.IdVenda);
        }

        public IEnumerable<Venda> GetVendaByNomeCliente(string nmCliente)
        {
            if (!string.IsNullOrWhiteSpace(nmCliente))
                return _context.Vendas.Include(venda => venda.Cliente).Include(venda => venda.Produto).Where(venda => venda.Cliente.NmCliente.ToLower().Equals(nmCliente.ToLower()));

            return _context.Vendas.Include(venda => venda.Cliente).Include(venda => venda.Produto).OrderBy(venda => venda.IdVenda);
        }
    }
}
