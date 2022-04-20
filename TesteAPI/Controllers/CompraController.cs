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
    public class CompraController : ControllerBase
    {

        [HttpGet]
        [Route("BuscarCompras")]
        [AllowAnonymous]

        public async Task<ActionResult<dynamic>> Get()
        {
            return Ok(CompraRepository.GetPurchases());
        }
        [HttpGet]
        [Route("BuscarCompraDeUmCliente/{id}")]
        [AllowAnonymous]

        public async Task<ActionResult<dynamic>> GetById(int id)
        {
            return Ok(CompraRepository.GetPurchase(id));
        }
         [HttpGet]
         [Route("BuscarProdutosMaisCompradosCliente/{id}")]
         [AllowAnonymous]

         public async Task<ActionResult<dynamic>> GetProductByClientId(int id)
         {
             return Ok(CompraRepository.GetMorePurchaseProduct(id));
         }
         
        [HttpPost]
        [Route("ComprarProdutos")]
        [AllowAnonymous]

        public async Task<ActionResult<dynamic>> PurchaseProducts([FromBody] PurchaseProductsRequest p)
        {
            return Ok(CompraRepository.PurchaseProducts(p));
        }
    }
}
