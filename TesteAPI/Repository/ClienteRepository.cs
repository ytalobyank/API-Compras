using Api_Compras.Model;
using Api_Compras.Requests;
using Api_Compras.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Compras.Repository
{
    public static class ClienteRepository
    {
        public static List<Cliente> GetClients(int id = 0 )
        {

            string sql = id > 0 ? "select * from cliente where id = @idClient" : "select * from cliente";
            
            return BaseRepository.QuerySql<Cliente>(sql, new { idClient = id });
        }
        public static Result AddClient(ClienteRequest clientRequest)
        {
            Cliente client = new Cliente();
            client.Nome = clientRequest.Nome;
            client.Telefone = clientRequest.Telefone;
            client.Endereco = clientRequest.Endereco;
            BaseRepository.InsertOrUpdateSql(client);
            Result res = new Result();
            res.sucess = true;
            res.message = "Cliente adicionado com sucesso.";
            return res;

        }
        public static Result UpdateClient(ClienteUpdateRequest clientRequest)
        {
            Cliente client = new Cliente();
            client.ID = clientRequest.Id;
            client.Nome = clientRequest.Nome;
            client.Telefone = clientRequest.Telefone;
            client.Endereco = clientRequest.Endereco;
            BaseRepository.InsertOrUpdateSql(client, true);
            Result res = new Result();
            res.sucess = true;
            res.message = "Cliente Atualizado com sucesso.";
            return res;

        }
        public static Result DeleteClient(int id)
        {
            
            BaseRepository.DeleteSql<Cliente>(id);
            Result res = new Result();
            res.sucess = true;
            res.message = "Cliente apagado com sucesso.";
            return res;

        }
    }
}
