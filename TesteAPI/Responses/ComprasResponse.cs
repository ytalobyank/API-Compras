using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace Api_Compras.Model
{
    public class ComprasResponse
    {
        public List<ClientResp> clientList { get; set; }
        
    }
    public class ClientResp
    {
        public int IDClient { get; set; }
        public string Nome { get; set; }
        public List<PurchasesByClient> purchasesClient { get; set; }

    }
    public class PurchasesByClient
    {
        public int IDCompra { get; set; }
        public List<ProductsBoughts> productsBoughts { get; set; }
    }
    public class ProductsBoughts
    {
        public int IDProduct { get; set; }
        public string Produto { get; set; }
    }
    public class ComprasDeClienteResponse
    {
        public List<PurchasesByClient> purchasesClient { get; set; }
    }

}
