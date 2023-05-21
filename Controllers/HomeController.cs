﻿using CamposDealerWebProject.Models;
using CamposDealerWebProject.Repositories.Interfaces;
using CamposDealerWebProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CamposDealerWebProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IVendaRepository _vendaRepository;

        public HomeController(IClienteRepository cliente, IProdutoRepository produto, IVendaRepository venda)
        {
            _clienteRepository = cliente;
            _produtoRepository = produto;
            _vendaRepository = venda;
        }

        public IActionResult Index()
        {
            var repositoryViewModel = new RepositoryViewModel
            {
                Clientes = _clienteRepository.Clientes,
                Produtos = _produtoRepository.Produtos,
                Vendas = _vendaRepository.Vendas
            };

            return View(repositoryViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}