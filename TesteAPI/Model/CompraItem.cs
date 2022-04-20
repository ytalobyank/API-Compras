using Dapper.Contrib.Extensions;
using System;

namespace Api_Compras.Model
{
    [Table("compraitem")]
    public class CompraItem : BaseModel
    {
        [Key]
        public int ID { get; set; }
        public int IDCompra { get; set; }
        public int IDProduto { get; set; }
        public int Quantidade { get; set; }



    }
}
