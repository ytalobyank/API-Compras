using Api_Compras.Model;
using Dapper;
using Dapper.Contrib.Extensions;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Compras.Repository
{
    public class BaseRepository
    {
       
        public static List<T> QuerySql<T>(string sql, object parameter = null)
        {
            List<T> orderDetail;
            using (var connection = new MySqlConnection("Server=localhost;Database=mydb;Uid=root;Pwd=Programandomysql123-;"))
            {
                orderDetail = connection.Query<T>(sql, parameter).ToList();
            }
            return orderDetail;
        }
        public static T QueryOneSql<T>(string sql, object parameter = null)
        {
            T orderDetail;
            using (var connection = new MySqlConnection("Server=localhost;Database=mydb;Uid=root;Pwd=Programandomysql123-;"))
            {
                orderDetail = connection.QueryFirstOrDefault<T>(sql, parameter);
            }
            return orderDetail;
        }
        public static long InsertOrUpdateSql<T>(T obj, bool edit = false, object parameter = null) where T : BaseModel
        { 
            using (var connection = new MySqlConnection("Server=localhost;Database=mydb;Uid=root;Pwd=Programandomysql123-;"))
            {
                if (edit)
                {
                    connection.Update(obj);
                    return 0;
                }
                else
                {
                    return connection.Insert(obj);
                } 
            }
        }
        public static void InsertListSql<T>(List<T> obj, bool edit = false, object parameter = null) where T : BaseModel
        {
            using (var connection = new MySqlConnection("Server=localhost;Database=mydb;Uid=root;Pwd=Programandomysql123-;"))
            {  
                    connection.Insert(obj);
            }
        }
        public static void DeleteSql<T>(int id) where T : BaseModel
        {
            using (var connection = new MySqlConnection("Server=localhost;Database=mydb;Uid=root;Pwd=Programandomysql123-;"))
            {
                string query = $"select * from {typeof(T).Name} where ID = @id";
                var obj = connection.Query<T>(query, new { id });

                connection.Delete(obj);
            }
        }

    }

}
