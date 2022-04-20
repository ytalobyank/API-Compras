using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Compras.Requests
{
    public class ProdutoRequest
    {
        public string Nome { get; set; }
        public double Preco { get; set; }
    }

    public class ProdutoUpdateRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
    }
}
