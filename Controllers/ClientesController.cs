﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CamposDealerWebProject.Context;
using CamposDealerWebProject.Models;
using CamposDealerWebProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace CamposDealerWebProject.Controllers
{
    public class ClientesController : Controller
    {
        //TODO: Refatorar métodos
        private readonly IClienteRepository _clienteRepository;     

        public IActionResult Index()
        {
            //try
            //{
            //    ModelState.Clear();

            //    var clienteEncoded = Convert.FromBase64String(cliente);
            //    var clienteDecoded = System.Text.Encoding.UTF8.GetString(clienteEncoded);                
            //    var clienteResult = JsonConvert.DeserializeObject<List<Cliente>>(clienteDecoded);

            //    if (clienteResult is null || clienteResult.Count == 0)
            //    {
            //        return PartialView("_ConsultaNaoLocalizada");
            //    }

            //    return PartialView("../Clientes/_ClientesPartial", clienteResult);
            //}

            //catch (Exception)
            //{
            //    return PartialView("../Clientes/_ClientesPartial", await _clienteRepository.GetAllClients());
            //}

            return View();
                        
        }

        [HttpPost]
        public async Task<JsonResult> AddClient(Cliente cliente)
        {
            if (ModelState.IsValid)
            { 
                await _clienteRepository.AddClient(cliente);                
            }

            return Json(ModelState);
        }

        //[HttpPost]
        //public async Task<JsonResult> UpdateClientById(Cliente cliente)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        await _clienteRepository.UpdateClientById(cliente);
        //    }

        //    return Json(ModelState);
        //}

        //[HttpGet]
        //public async Task<JsonResult> GetClientById(int id)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var cliente = await _clienteRepository.GetClientById(id);
        //        return Json(cliente);
        //    }

        //    return Json(ModelState);
        //}

        //[HttpGet]
        //public async Task<JsonResult> GetClientByName(string nmCliente)
        //{
        //    if (ModelState.IsValid && !string.IsNullOrWhiteSpace(nmCliente))
        //    {
        //        var cliente = await _clienteRepository.GetClientByName(nmCliente);
        //        return Json(cliente);
        //    }

        //    return Json(ModelState);
        //}

        //[HttpDelete]
        //public async Task<JsonResult> DeleteClientById(int id)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _clienteRepository.DeleteClientById(id);
        //    }

        //    return Json(ModelState);
        //}
    }
}
