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
    public class ProdutoController : ControllerBase
    {

        [HttpGet]
        [Route("BuscarProdutos")]
        [AllowAnonymous]

        public async Task<ActionResult<dynamic>> Get()
        {
            return Ok(ProdutoRepository.GetProducts());
        }
        
        [HttpGet]
        [Route("BuscarProduto/{id}")]
        [AllowAnonymous]

        public async Task<ActionResult<dynamic>> GetById(int id)
        {
            return Ok(ProdutoRepository.GetProducts(id));
        }
        
        [HttpGet]
        [Route("BuscarComprasPorProduto")]
        [AllowAnonymous]

        public async Task<ActionResult<dynamic>> GetByAllProducts()
        {
            return Ok(ProdutoRepository.GetPurchasesByProduct());
        }

        [HttpGet]
        [Route("BuscarComprasPeloProduto/{id}")]
        [AllowAnonymous]

        public async Task<ActionResult<dynamic>> GetProductById(int id)
        {
            return Ok(ProdutoRepository.GetPurchaseByProduct(id));
        }

        [HttpPost]
        [Route("InserirProduto")]
        [AllowAnonymous]

        public async Task<ActionResult<dynamic>> Post([FromBody] ProdutoRequest p)
        {
            return Ok(ProdutoRepository.AddProduct(p));
        }
        [HttpPut]
        [Route("AtualizarProduto")]
        [AllowAnonymous]

        public async Task<ActionResult<dynamic>> Put([FromBody] ProdutoUpdateRequest p)
        {
            return Ok(ProdutoRepository.UpdateProduct(p));
            
        }
        [HttpDelete]
        [Route("DeletarProduto/{id}")]
        [AllowAnonymous]

        public async Task<ActionResult<dynamic>> Delete(int id)
        {
            return Ok(ProdutoRepository.DeleteProduct(id));

        }
    }
}
