using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Compras.Requests
{
    public class CompraItemRequest
    {
        public int IdCompra { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
    }

    public class CompraItemUpdateRequest
    {
        public int Id { get; set; }
        public int IdCompra { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
        
    }
}
