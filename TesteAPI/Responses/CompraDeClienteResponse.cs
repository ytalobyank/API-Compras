using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace Api_Compras.Model
{
    public class CompraDeClienteResponse
    {
        public string Nome { get; set; }
        public List<ListaCompras> ListPurchase { get; set; }
    }
    public class ListaCompras
    {
        public int IDCompra { get; set; }
        public double PreçoTotal { get; set; }
        public List<ListaProdutos> ListProducts { get; set; }
    }
    public class ListaProdutos
    {
        public int IDProduto { get; set; }
        public string NomeProduto { get; set; }
        public double PrecoProduto { get; set; }
        public int QuantidadeComprada { get; set; }
    }
    
    public class SomaTotal
    {
        public double Total { get; set; }
    }
    public class MaisComprados
    {
        public string Nome { get; set; }
        public double Total { get; set; }
    }

}
