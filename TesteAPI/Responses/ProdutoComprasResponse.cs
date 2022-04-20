using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Compras.Responses
{
    public class ProdutoComprasResponse
    {
        public string Produto { get; set; }
        public int TotalCompras { get; set; }
        public int TotalArrecadado { get; set; }
    }
}
