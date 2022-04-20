using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Compras.Requests
{
    public class CompraRequest
    {
        public int IdClient { get; set; }
    }

    public class CompraUpdateRequest
    {
        public int Id { get; set; }
        public int IdClient { get; set; }

    }
    public class PurchaseProductsRequest
    {
        public int idClient { get; set; }
        public List<ProductList> pList { get; set; }
        public class ProductList 
        {
            public int idProduct { get; set; }

            public int Quantidade { get; set; }
        }

    }
}
