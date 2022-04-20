using Dapper.Contrib.Extensions;
using System;

namespace Api_Compras.Model
{
    [Table("cliente")]
    public class Cliente : BaseModel
    {
        [Key]
        public int ID { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }
        public string Endereco { get; set; }

    }
}
