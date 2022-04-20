using Api_Compras.Model;
using Api_Compras.Repository;
using Api_Compras.Requests;
using Api_Compras.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteAPI.Controllers
{
    
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {

        [HttpGet]
        [Route("BuscarClientes")]
        [AllowAnonymous]

        public async Task<ActionResult<dynamic>> Get()
        {
            return Ok(ClienteRepository.GetClients());
        }
        [HttpGet]
        [Route("BuscarCliente/{id}")]
        [AllowAnonymous]

        public async Task<ActionResult<dynamic>> GetById(int id)
        {
            return Ok(ClienteRepository.GetClients(id));
        }
        [HttpPost]
        [Route("InserirCliente")]
        [AllowAnonymous]

        public async Task<ActionResult<dynamic>> Post([FromBody] ClienteRequest c)
        {
            return Ok(ClienteRepository.AddClient(c));
        }
        [HttpPut]
        [Route("AtualizarCliente")]
        [AllowAnonymous]

        public async Task<ActionResult<dynamic>> Put([FromBody] ClienteUpdateRequest c)
        {
            return Ok(ClienteRepository.UpdateClient(c));
            
        }
        [HttpDelete]
        [Route("DeletarCliente/{id}")]
        [AllowAnonymous]

        public async Task<ActionResult<dynamic>> Delete(int id)
        {
            return Ok(ClienteRepository.DeleteClient(id));

        }
    }
}
