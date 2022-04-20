using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Compras.Model
{
    [Table("produto")]
    public class ProdutoForList : BaseModel
    {
        [Key]
        public int ID { get; set; }

        public string Produto { get; set; }
        
        public double Preco { get; set; }
        public int Quantidade { get; set; }

    }
}
