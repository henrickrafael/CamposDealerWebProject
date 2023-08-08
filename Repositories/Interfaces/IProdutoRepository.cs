﻿using CamposDealerWebProject.Models;

namespace CamposDealerWebProject.Repositories.Interfaces
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> Produtos { get; }

        IEnumerable<Produto> GetProductByDescription(string dscProduto);        
    }
}
