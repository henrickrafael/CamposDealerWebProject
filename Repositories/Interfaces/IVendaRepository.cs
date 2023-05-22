﻿using CamposDealerWebProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CamposDealerWebProject.Repositories.Interfaces
{
    public interface IVendaRepository
    {
        IEnumerable<Venda> Vendas { get; }

        Venda GetVendaByClienteName(string nmCliente);
        
        Venda GetVendaByDscProduto(string dscProduto);
    }
}
