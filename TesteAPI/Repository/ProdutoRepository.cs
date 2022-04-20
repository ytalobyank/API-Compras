using Api_Compras.Model;
using Api_Compras.Requests;
using Api_Compras.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Compras.Repository
{
    public static class ProdutoRepository
    {
        public static List<Produto> GetProducts(int id = 0 )
        {

            string sql = id > 0 ? "select * from produto where id = @idProduct" : "select * from produto";
            
            return BaseRepository.QuerySql<Produto>(sql, new { idProduct = id });
        }
        public static Result AddProduct(ProdutoRequest productRequest)
        {
            Produto product = new Produto();
            product.Nome = productRequest.Nome;
            product.Preco = productRequest.Preco;
            BaseRepository.InsertOrUpdateSql(product);
            Result res = new Result();
            res.sucess = true;
            res.message = "Produto adicionado com sucesso.";
            return res;

        }
        public static List<ProdutoComprasResponse> GetPurchasesByProduct()
        {
            string sql =$@"SELECT pro.Nome as Produto, Count(comit.IDCompra) as TotalCompras, Sum(comit.Quantidade*(pro.Preco)) as TotalArrecadado
                         FROM produto as pro
                         INNER JOIN compraitem as comit
                         ON comit.IDProduto = pro.ID
                         INNER JOIN compra as com
                         ON com.ID = comit.IDCompra
                         GROUP BY comit.IDProduto;";

            return BaseRepository.QuerySql<ProdutoComprasResponse>(sql);
        }
        public static ProdutoComprasResponse GetPurchaseByProduct(int id)
        {
            string sql = $@"SELECT pro.Nome as Produto, Count(comit.IDCompra) as TotalCompras, Sum(comit.Quantidade*(pro.Preco)) as TotalArrecadado
                         FROM produto as pro
                         INNER JOIN compraitem as comit
                         ON comit.IDProduto = pro.ID
                         INNER JOIN compra as com
                         ON com.ID = comit.IDCompra
                         WHERE comit.IDProduto = {id}
                         GROUP BY comit.IDProduto;";

            return BaseRepository.QueryOneSql<ProdutoComprasResponse>(sql);
        }
        public static Result UpdateProduct(ProdutoUpdateRequest productRequest)
        {
            Produto product = new Produto();
            product.ID = productRequest.Id;
            product.Nome = productRequest.Nome;
            product.Preco = productRequest.Preco;
            BaseRepository.InsertOrUpdateSql(product, true);
            Result res = new Result();
            res.sucess = true;
            res.message = "Produto atualizado com sucesso.";
            return res;

        }
        public static Result DeleteProduct(int id)
        {
            
            BaseRepository.DeleteSql<Produto>(id);
            Result res = new Result();
            res.sucess = true;
            res.message = "Produto apagado com sucesso.";
            return res;

        }
    }
}
