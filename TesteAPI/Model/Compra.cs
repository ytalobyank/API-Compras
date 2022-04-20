using Dapper.Contrib.Extensions;
using System;

namespace Api_Compras.Model
{
    [Table("compra")]
    public class Compra : BaseModel
    {
        [Key]
        public int ID { get; set; }

        public int IDClient { get; set; }

    }
}
