using Api_Compras.Model;
using Api_Compras.Requests;
using Api_Compras.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Compras.Repository
{
    public static class CompraRepository
    {
        public static ComprasResponse GetPurchases(int id = 0 )
        {
            List<Cliente> cliList = new List<Cliente>();
            List<Compra> comList = new List<Compra>();
            List<ProdutoForList> proList = new List<ProdutoForList>();
            ComprasResponse cResponse = new ComprasResponse();
            List<ClientResp> LClientList = new List<ClientResp>();

            cliList = BaseRepository.QuerySql<Cliente>($"select distinct cli.ID, cli.Nome FROM cliente as cli INNER JOIN compra as com ON cli.ID = com.IDClient", new { idProduct = id });
            foreach (var cli in cliList)
            {
                List<PurchasesByClient> LClientPurList = new List<PurchasesByClient>();
                ClientResp cCliResp = new ClientResp();
                cCliResp.IDClient = cli.ID;
                cCliResp.Nome = cli.Nome;
                
                comList = BaseRepository.QuerySql<Compra>($"select distinct com.ID FROM compra as com INNER JOIN cliente as cli ON cli.ID = com.IDClient INNER JOIN compraitem as comit ON comit.IDCompra = com.ID WHERE com.IDClient = {cCliResp.IDClient}");
                foreach (var com in comList)
                {
                    PurchasesByClient cCliPurResp = new PurchasesByClient();
                    List<ProductsBoughts> LClientPurProList = new List<ProductsBoughts>();
                    cCliPurResp.IDCompra = com.ID;
                    proList = BaseRepository.QuerySql<ProdutoForList>($"select distinct pro.Nome as Produto, pro.ID FROM produto as pro INNER JOIN compraitem as comit ON pro.ID = comit.IDProduto INNER JOIN compra as com ON comit.IDCompra = com.ID INNER JOIN cliente as cli ON cli.ID = com.IDClient WHERE comit.IDCompra = {cCliPurResp.IDCompra}");
                    foreach (var pro in proList)
                    {
                        ProductsBoughts cCliPurProResp = new ProductsBoughts();
                        cCliPurProResp.IDProduct = pro.ID;
                        cCliPurProResp.Produto = pro.Produto;
                        LClientPurProList.Add(cCliPurProResp);
                    }
                    cCliPurResp.productsBoughts = LClientPurProList;
                    LClientPurList.Add(cCliPurResp);
                }
                cCliResp.purchasesClient = LClientPurList;
                LClientList.Add(cCliResp);
            }
            cResponse.clientList = LClientList;
            return cResponse;
        }
        public static CompraDeClienteResponse GetPurchase(int id)
        {
            Cliente client = new Cliente();
            List<Compra> listPurchase = new List<Compra>();
            List<ProdutoForList> listProduct = new List<ProdutoForList>();
            CompraDeClienteResponse cResponse = new CompraDeClienteResponse();

            client = BaseRepository.QueryOneSql<Cliente>($"select cli.Nome FROM cliente as cli INNER JOIN compra as com ON cli.ID = com.IDClient WHERE cli.ID = @idCliente", new { idCliente = id });
            cResponse.Nome = client.Nome;
            List<ListaCompras> lCompResp = new List<ListaCompras>();
            listPurchase = BaseRepository.QuerySql<Compra>($"select distinct com.ID FROM compra as com INNER JOIN cliente as cli ON cli.ID = com.IDClient INNER JOIN compraitem as comit ON comit.IDCompra = com.ID WHERE com.IDClient = {id}");
            foreach (var lpur in listPurchase)
            {
                List<ListaProdutos> lProResp = new List<ListaProdutos>();
                ListaCompras cResp = new ListaCompras();
                cResp.IDCompra = lpur.ID;
                SomaTotal st = new SomaTotal();
                st = BaseRepository.QueryOneSql<SomaTotal>($"select sum(comit.quantidade*(pro.Preco)) as Total FROM cliente as cli INNER JOIN compra as com ON cli.ID = com.IDClient INNER JOIN compraitem as comit on comit.IDCompra = com.ID INNER JOIN produto as pro on comit.IDProduto = pro.ID WHERE com.ID ={lpur.ID};");
                cResp.PreçoTotal = st.Total;
                listProduct = BaseRepository.QuerySql<ProdutoForList>($"select  pro.Nome as Produto, pro.ID, pro.Preco, comit.Quantidade FROM produto as pro INNER JOIN compraitem as comit ON pro.ID = comit.IDProduto INNER JOIN compra as com ON comit.IDCompra = com.ID INNER JOIN cliente as cli ON cli.ID = com.IDClient WHERE comit.IDCompra ={lpur.ID}");
                foreach (var lpro in listProduct)
                {
                    ListaProdutos listPro = new ListaProdutos();
                    listPro.IDProduto = lpro.ID;
                    listPro.NomeProduto = lpro.Produto;
                    listPro.PrecoProduto = lpro.Preco;
                    listPro.QuantidadeComprada = lpro.Quantidade;
                    lProResp.Add(listPro);
                }
                cResp.ListProducts = lProResp;
                lCompResp.Add(cResp);
            }
            cResponse.ListPurchase = lCompResp;
            return cResponse;
        }
        public static List<MaisComprados> GetMorePurchaseProduct(int id)
        {

            return BaseRepository.QuerySql<MaisComprados>($@"SELECT pro.Nome, sum(comit.Quantidade) as Total 
                                             FROM produto as pro
                                             INNER JOIN compraitem as comit
                                             ON comit.IDProduto = pro.ID
                                             INNER JOIN compra as com
                                             ON com.ID = comit.IDCompra
                                             WHERE com.IDClient = {id} 
                                             GROUP BY comit.IDProduto
                                             ORDER BY Total desc
                                             limit 5;");
        }
        public static Result PurchaseProducts(PurchaseProductsRequest ppRequest)
        {
            Compra cmp = new Compra();
            cmp.IDClient = ppRequest.idClient;
            long test = BaseRepository.InsertOrUpdateSql(cmp);

            List<CompraItem> listCI = new List<CompraItem>();
            foreach (var p in ppRequest.pList)
            {
                CompraItem cmpItm = new CompraItem();
                cmpItm.IDCompra = Convert.ToInt32(test);
                cmpItm.IDProduto = p.idProduct;
                cmpItm.Quantidade = p.Quantidade;
                listCI.Add(cmpItm);
            }
            BaseRepository.InsertListSql(listCI);
            Result res = new Result();
            res.sucess = true;
            res.message = "Compra efetuada com sucesso.";
            return res;

        }
    }
}
