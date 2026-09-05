// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration
// </yeshua>

using Shered.DB;
using System.Data.SqlTypes;
using Command.Read;
using IQuery.Read;
using Aplication.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Threading.Tasks;

namespace Query.Read 
{
    public class ConsultaPedidoQueryRead : QueryBase, IConsultaPedidoQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public ConsultaPedidoQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel ConsultaPedidoQuery(Command.Read.ConsultaPedidoReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select [ORD_ID] AS [PedidoId], [CLI_ID] AS [ClienteId], [CLIENTE] AS [ClienteNome], [RAZAO_SOCIAL] AS [RazaoSocial], [PRO_ID] AS [ProdutoId], [PRO_DESCRICAO] AS [ProdutoDescricao], [ORD_STATUS] AS [Status], [ESTAGIO] AS [Estagio], [ORD_DATA_ENTREGA_DE] AS [DataEntregaDe], [ORD_DATA_ENTREGA_ATE] AS [DataEntregaAte], [ORD_EMBARQUE_ALVO] AS [EmbarqueAlvo], [ORD_QUANTIDADE] AS [Quantidade], [SALDO_A_PRODUZIR_PA] AS [SaldoAProduzir], [SALDO_A_EXPEDIR] AS [SaldoAExpedir], [ORD_COR_FILA] AS [CorFila], [ORD_PED_CLI] AS [PedidoCliente] from [V_CONSULTA_PEDIDO] ";
if (!string.IsNullOrEmpty(Command.PedidoId)) dict["PedidoId"] = $"%{Command.PedidoId}%";
if (!string.IsNullOrEmpty(Command.PedidoId)) whereClauses.Add($"[ORD_ID] like @PedidoId");
if (!string.IsNullOrEmpty(Command.ClienteId)) dict["ClienteId"] = $"%{Command.ClienteId}%";
if (!string.IsNullOrEmpty(Command.ClienteId)) whereClauses.Add($"[CLI_ID] like @ClienteId");
if (!string.IsNullOrEmpty(Command.ClienteNome)) dict["ClienteNome"] = $"%{Command.ClienteNome}%";
if (!string.IsNullOrEmpty(Command.ClienteNome)) whereClauses.Add($"[CLIENTE] like @ClienteNome");
if (!string.IsNullOrEmpty(Command.RazaoSocial)) dict["RazaoSocial"] = $"%{Command.RazaoSocial}%";
if (!string.IsNullOrEmpty(Command.RazaoSocial)) whereClauses.Add($"[RAZAO_SOCIAL] like @RazaoSocial");
if (!string.IsNullOrEmpty(Command.ProdutoId)) dict["ProdutoId"] = $"%{Command.ProdutoId}%";
if (!string.IsNullOrEmpty(Command.ProdutoId)) whereClauses.Add($"[PRO_ID] like @ProdutoId");
if (!string.IsNullOrEmpty(Command.ProdutoDescricao)) dict["ProdutoDescricao"] = $"%{Command.ProdutoDescricao}%";
if (!string.IsNullOrEmpty(Command.ProdutoDescricao)) whereClauses.Add($"[PRO_DESCRICAO] like @ProdutoDescricao");
if (!string.IsNullOrEmpty(Command.Status)) dict["Status"] = $"%{Command.Status}%";
if (!string.IsNullOrEmpty(Command.Status)) whereClauses.Add($"[ORD_STATUS] like @Status");
if (!string.IsNullOrEmpty(Command.Estagio)) dict["Estagio"] = $"%{Command.Estagio}%";
if (!string.IsNullOrEmpty(Command.Estagio)) whereClauses.Add($"[ESTAGIO] like @Estagio");
if (!string.IsNullOrEmpty(Command.CorFila)) dict["CorFila"] = $"%{Command.CorFila}%";
if (!string.IsNullOrEmpty(Command.CorFila)) whereClauses.Add($"[ORD_COR_FILA] like @CorFila");
if (!string.IsNullOrEmpty(Command.PedidoCliente)) dict["PedidoCliente"] = $"%{Command.PedidoCliente}%";
if (!string.IsNullOrEmpty(Command.PedidoCliente)) whereClauses.Add($"[ORD_PED_CLI] like @PedidoCliente");
            if (whereClauses.Any()) 
                 this.Query += $" WHERE {string.Join(" AND ", whereClauses)}"; 
            int page = Command.Paginacao?.Page ?? 1;
            int pageSize = Command.Paginacao?.PageSize ?? 20;
            int offset = (page - 1) * pageSize;
            dict["Offset"] = offset;
            dict["PageSize"] = pageSize;
            Query += " ORDER BY [ORD_ID] OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel ConsultaPedidoProdutoIdQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select [Id], [Descricao] from [Produto] ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["Id"] = numero; //01
                      whereClauses.Add($" [Id] = @Id");//01 
                 }
                 else 
                 {
                      dict["Id"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" [Id] like @Id ");//02
                      dict["Descricao"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" [Descricao] like @Descricao ");//02
                 }
           }
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel ExistsByPedidoIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [V_CONSULTA_PEDIDO] ";
                      dict["PedidoId"] = value; //04
                      whereClauses.Add($" [ORD_ID] = @PedidoId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByClienteIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [V_CONSULTA_PEDIDO] ";
                      dict["ClienteId"] = value; //04
                      whereClauses.Add($" [CLI_ID] = @ClienteId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByClienteNomeQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [V_CONSULTA_PEDIDO] ";
                      dict["ClienteNome"] = value; //04
                      whereClauses.Add($" [CLIENTE] = @ClienteNome ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByRazaoSocialQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [V_CONSULTA_PEDIDO] ";
                      dict["RazaoSocial"] = value; //04
                      whereClauses.Add($" [RAZAO_SOCIAL] = @RazaoSocial ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByProdutoIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [V_CONSULTA_PEDIDO] ";
                      dict["ProdutoId"] = value; //04
                      whereClauses.Add($" [PRO_ID] = @ProdutoId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByProdutoDescricaoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [V_CONSULTA_PEDIDO] ";
                      dict["ProdutoDescricao"] = value; //04
                      whereClauses.Add($" [PRO_DESCRICAO] = @ProdutoDescricao ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByStatusQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [V_CONSULTA_PEDIDO] ";
                      dict["Status"] = value; //04
                      whereClauses.Add($" [ORD_STATUS] = @Status ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByEstagioQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [V_CONSULTA_PEDIDO] ";
                      dict["Estagio"] = value; //04
                      whereClauses.Add($" [ESTAGIO] = @Estagio ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByDataEntregaDeQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [V_CONSULTA_PEDIDO] ";
                      dict["DataEntregaDe"] = value; //04
                      whereClauses.Add($" [ORD_DATA_ENTREGA_DE] = @DataEntregaDe ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByDataEntregaAteQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [V_CONSULTA_PEDIDO] ";
                      dict["DataEntregaAte"] = value; //04
                      whereClauses.Add($" [ORD_DATA_ENTREGA_ATE] = @DataEntregaAte ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByEmbarqueAlvoQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [V_CONSULTA_PEDIDO] ";
                      dict["EmbarqueAlvo"] = value; //04
                      whereClauses.Add($" [ORD_EMBARQUE_ALVO] = @EmbarqueAlvo ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByQuantidadeQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [V_CONSULTA_PEDIDO] ";
                      dict["Quantidade"] = value; //04
                      whereClauses.Add($" [ORD_QUANTIDADE] = @Quantidade ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsBySaldoAProduzirQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [V_CONSULTA_PEDIDO] ";
                      dict["SaldoAProduzir"] = value; //04
                      whereClauses.Add($" [SALDO_A_PRODUZIR_PA] = @SaldoAProduzir ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsBySaldoAExpedirQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [V_CONSULTA_PEDIDO] ";
                      dict["SaldoAExpedir"] = value; //04
                      whereClauses.Add($" [SALDO_A_EXPEDIR] = @SaldoAExpedir ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCorFilaQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [V_CONSULTA_PEDIDO] ";
                      dict["CorFila"] = value; //04
                      whereClauses.Add($" [ORD_COR_FILA] = @CorFila ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPedidoClienteQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [V_CONSULTA_PEDIDO] ";
                      dict["PedidoCliente"] = value; //04
                      whereClauses.Add($" [ORD_PED_CLI] = @PedidoCliente ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPedidoIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [ORD_ID] AS [PedidoId], [CLI_ID] AS [ClienteId], [CLIENTE] AS [ClienteNome], [RAZAO_SOCIAL] AS [RazaoSocial], [PRO_ID] AS [ProdutoId], [PRO_DESCRICAO] AS [ProdutoDescricao], [ORD_STATUS] AS [Status], [ESTAGIO] AS [Estagio], [ORD_DATA_ENTREGA_DE] AS [DataEntregaDe], [ORD_DATA_ENTREGA_ATE] AS [DataEntregaAte], [ORD_EMBARQUE_ALVO] AS [EmbarqueAlvo], [ORD_QUANTIDADE] AS [Quantidade], [SALDO_A_PRODUZIR_PA] AS [SaldoAProduzir], [SALDO_A_EXPEDIR] AS [SaldoAExpedir], [ORD_COR_FILA] AS [CorFila], [ORD_PED_CLI] AS [PedidoCliente] FROM [V_CONSULTA_PEDIDO] ";
                      dict["PedidoId"] = value; //06
                      whereClauses.Add($" [ORD_ID] = @PedidoId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByClienteIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [ORD_ID] AS [PedidoId], [CLI_ID] AS [ClienteId], [CLIENTE] AS [ClienteNome], [RAZAO_SOCIAL] AS [RazaoSocial], [PRO_ID] AS [ProdutoId], [PRO_DESCRICAO] AS [ProdutoDescricao], [ORD_STATUS] AS [Status], [ESTAGIO] AS [Estagio], [ORD_DATA_ENTREGA_DE] AS [DataEntregaDe], [ORD_DATA_ENTREGA_ATE] AS [DataEntregaAte], [ORD_EMBARQUE_ALVO] AS [EmbarqueAlvo], [ORD_QUANTIDADE] AS [Quantidade], [SALDO_A_PRODUZIR_PA] AS [SaldoAProduzir], [SALDO_A_EXPEDIR] AS [SaldoAExpedir], [ORD_COR_FILA] AS [CorFila], [ORD_PED_CLI] AS [PedidoCliente] FROM [V_CONSULTA_PEDIDO] ";
                      dict["ClienteId"] = value; //06
                      whereClauses.Add($" [CLI_ID] = @ClienteId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByClienteNomeQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [ORD_ID] AS [PedidoId], [CLI_ID] AS [ClienteId], [CLIENTE] AS [ClienteNome], [RAZAO_SOCIAL] AS [RazaoSocial], [PRO_ID] AS [ProdutoId], [PRO_DESCRICAO] AS [ProdutoDescricao], [ORD_STATUS] AS [Status], [ESTAGIO] AS [Estagio], [ORD_DATA_ENTREGA_DE] AS [DataEntregaDe], [ORD_DATA_ENTREGA_ATE] AS [DataEntregaAte], [ORD_EMBARQUE_ALVO] AS [EmbarqueAlvo], [ORD_QUANTIDADE] AS [Quantidade], [SALDO_A_PRODUZIR_PA] AS [SaldoAProduzir], [SALDO_A_EXPEDIR] AS [SaldoAExpedir], [ORD_COR_FILA] AS [CorFila], [ORD_PED_CLI] AS [PedidoCliente] FROM [V_CONSULTA_PEDIDO] ";
                      dict["ClienteNome"] = value; //06
                      whereClauses.Add($" [CLIENTE] = @ClienteNome ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByRazaoSocialQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [ORD_ID] AS [PedidoId], [CLI_ID] AS [ClienteId], [CLIENTE] AS [ClienteNome], [RAZAO_SOCIAL] AS [RazaoSocial], [PRO_ID] AS [ProdutoId], [PRO_DESCRICAO] AS [ProdutoDescricao], [ORD_STATUS] AS [Status], [ESTAGIO] AS [Estagio], [ORD_DATA_ENTREGA_DE] AS [DataEntregaDe], [ORD_DATA_ENTREGA_ATE] AS [DataEntregaAte], [ORD_EMBARQUE_ALVO] AS [EmbarqueAlvo], [ORD_QUANTIDADE] AS [Quantidade], [SALDO_A_PRODUZIR_PA] AS [SaldoAProduzir], [SALDO_A_EXPEDIR] AS [SaldoAExpedir], [ORD_COR_FILA] AS [CorFila], [ORD_PED_CLI] AS [PedidoCliente] FROM [V_CONSULTA_PEDIDO] ";
                      dict["RazaoSocial"] = value; //06
                      whereClauses.Add($" [RAZAO_SOCIAL] = @RazaoSocial ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByProdutoIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [ORD_ID] AS [PedidoId], [CLI_ID] AS [ClienteId], [CLIENTE] AS [ClienteNome], [RAZAO_SOCIAL] AS [RazaoSocial], [PRO_ID] AS [ProdutoId], [PRO_DESCRICAO] AS [ProdutoDescricao], [ORD_STATUS] AS [Status], [ESTAGIO] AS [Estagio], [ORD_DATA_ENTREGA_DE] AS [DataEntregaDe], [ORD_DATA_ENTREGA_ATE] AS [DataEntregaAte], [ORD_EMBARQUE_ALVO] AS [EmbarqueAlvo], [ORD_QUANTIDADE] AS [Quantidade], [SALDO_A_PRODUZIR_PA] AS [SaldoAProduzir], [SALDO_A_EXPEDIR] AS [SaldoAExpedir], [ORD_COR_FILA] AS [CorFila], [ORD_PED_CLI] AS [PedidoCliente] FROM [V_CONSULTA_PEDIDO] ";
                      dict["ProdutoId"] = value; //06
                      whereClauses.Add($" [PRO_ID] = @ProdutoId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByProdutoDescricaoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [ORD_ID] AS [PedidoId], [CLI_ID] AS [ClienteId], [CLIENTE] AS [ClienteNome], [RAZAO_SOCIAL] AS [RazaoSocial], [PRO_ID] AS [ProdutoId], [PRO_DESCRICAO] AS [ProdutoDescricao], [ORD_STATUS] AS [Status], [ESTAGIO] AS [Estagio], [ORD_DATA_ENTREGA_DE] AS [DataEntregaDe], [ORD_DATA_ENTREGA_ATE] AS [DataEntregaAte], [ORD_EMBARQUE_ALVO] AS [EmbarqueAlvo], [ORD_QUANTIDADE] AS [Quantidade], [SALDO_A_PRODUZIR_PA] AS [SaldoAProduzir], [SALDO_A_EXPEDIR] AS [SaldoAExpedir], [ORD_COR_FILA] AS [CorFila], [ORD_PED_CLI] AS [PedidoCliente] FROM [V_CONSULTA_PEDIDO] ";
                      dict["ProdutoDescricao"] = value; //06
                      whereClauses.Add($" [PRO_DESCRICAO] = @ProdutoDescricao ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByStatusQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [ORD_ID] AS [PedidoId], [CLI_ID] AS [ClienteId], [CLIENTE] AS [ClienteNome], [RAZAO_SOCIAL] AS [RazaoSocial], [PRO_ID] AS [ProdutoId], [PRO_DESCRICAO] AS [ProdutoDescricao], [ORD_STATUS] AS [Status], [ESTAGIO] AS [Estagio], [ORD_DATA_ENTREGA_DE] AS [DataEntregaDe], [ORD_DATA_ENTREGA_ATE] AS [DataEntregaAte], [ORD_EMBARQUE_ALVO] AS [EmbarqueAlvo], [ORD_QUANTIDADE] AS [Quantidade], [SALDO_A_PRODUZIR_PA] AS [SaldoAProduzir], [SALDO_A_EXPEDIR] AS [SaldoAExpedir], [ORD_COR_FILA] AS [CorFila], [ORD_PED_CLI] AS [PedidoCliente] FROM [V_CONSULTA_PEDIDO] ";
                      dict["Status"] = value; //06
                      whereClauses.Add($" [ORD_STATUS] = @Status ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByEstagioQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [ORD_ID] AS [PedidoId], [CLI_ID] AS [ClienteId], [CLIENTE] AS [ClienteNome], [RAZAO_SOCIAL] AS [RazaoSocial], [PRO_ID] AS [ProdutoId], [PRO_DESCRICAO] AS [ProdutoDescricao], [ORD_STATUS] AS [Status], [ESTAGIO] AS [Estagio], [ORD_DATA_ENTREGA_DE] AS [DataEntregaDe], [ORD_DATA_ENTREGA_ATE] AS [DataEntregaAte], [ORD_EMBARQUE_ALVO] AS [EmbarqueAlvo], [ORD_QUANTIDADE] AS [Quantidade], [SALDO_A_PRODUZIR_PA] AS [SaldoAProduzir], [SALDO_A_EXPEDIR] AS [SaldoAExpedir], [ORD_COR_FILA] AS [CorFila], [ORD_PED_CLI] AS [PedidoCliente] FROM [V_CONSULTA_PEDIDO] ";
                      dict["Estagio"] = value; //06
                      whereClauses.Add($" [ESTAGIO] = @Estagio ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByDataEntregaDeQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [ORD_ID] AS [PedidoId], [CLI_ID] AS [ClienteId], [CLIENTE] AS [ClienteNome], [RAZAO_SOCIAL] AS [RazaoSocial], [PRO_ID] AS [ProdutoId], [PRO_DESCRICAO] AS [ProdutoDescricao], [ORD_STATUS] AS [Status], [ESTAGIO] AS [Estagio], [ORD_DATA_ENTREGA_DE] AS [DataEntregaDe], [ORD_DATA_ENTREGA_ATE] AS [DataEntregaAte], [ORD_EMBARQUE_ALVO] AS [EmbarqueAlvo], [ORD_QUANTIDADE] AS [Quantidade], [SALDO_A_PRODUZIR_PA] AS [SaldoAProduzir], [SALDO_A_EXPEDIR] AS [SaldoAExpedir], [ORD_COR_FILA] AS [CorFila], [ORD_PED_CLI] AS [PedidoCliente] FROM [V_CONSULTA_PEDIDO] ";
                      dict["DataEntregaDe"] = value; //06
                      whereClauses.Add($" [ORD_DATA_ENTREGA_DE] = @DataEntregaDe ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByDataEntregaAteQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [ORD_ID] AS [PedidoId], [CLI_ID] AS [ClienteId], [CLIENTE] AS [ClienteNome], [RAZAO_SOCIAL] AS [RazaoSocial], [PRO_ID] AS [ProdutoId], [PRO_DESCRICAO] AS [ProdutoDescricao], [ORD_STATUS] AS [Status], [ESTAGIO] AS [Estagio], [ORD_DATA_ENTREGA_DE] AS [DataEntregaDe], [ORD_DATA_ENTREGA_ATE] AS [DataEntregaAte], [ORD_EMBARQUE_ALVO] AS [EmbarqueAlvo], [ORD_QUANTIDADE] AS [Quantidade], [SALDO_A_PRODUZIR_PA] AS [SaldoAProduzir], [SALDO_A_EXPEDIR] AS [SaldoAExpedir], [ORD_COR_FILA] AS [CorFila], [ORD_PED_CLI] AS [PedidoCliente] FROM [V_CONSULTA_PEDIDO] ";
                      dict["DataEntregaAte"] = value; //06
                      whereClauses.Add($" [ORD_DATA_ENTREGA_ATE] = @DataEntregaAte ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByEmbarqueAlvoQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [ORD_ID] AS [PedidoId], [CLI_ID] AS [ClienteId], [CLIENTE] AS [ClienteNome], [RAZAO_SOCIAL] AS [RazaoSocial], [PRO_ID] AS [ProdutoId], [PRO_DESCRICAO] AS [ProdutoDescricao], [ORD_STATUS] AS [Status], [ESTAGIO] AS [Estagio], [ORD_DATA_ENTREGA_DE] AS [DataEntregaDe], [ORD_DATA_ENTREGA_ATE] AS [DataEntregaAte], [ORD_EMBARQUE_ALVO] AS [EmbarqueAlvo], [ORD_QUANTIDADE] AS [Quantidade], [SALDO_A_PRODUZIR_PA] AS [SaldoAProduzir], [SALDO_A_EXPEDIR] AS [SaldoAExpedir], [ORD_COR_FILA] AS [CorFila], [ORD_PED_CLI] AS [PedidoCliente] FROM [V_CONSULTA_PEDIDO] ";
                      dict["EmbarqueAlvo"] = value; //06
                      whereClauses.Add($" [ORD_EMBARQUE_ALVO] = @EmbarqueAlvo ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByQuantidadeQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [ORD_ID] AS [PedidoId], [CLI_ID] AS [ClienteId], [CLIENTE] AS [ClienteNome], [RAZAO_SOCIAL] AS [RazaoSocial], [PRO_ID] AS [ProdutoId], [PRO_DESCRICAO] AS [ProdutoDescricao], [ORD_STATUS] AS [Status], [ESTAGIO] AS [Estagio], [ORD_DATA_ENTREGA_DE] AS [DataEntregaDe], [ORD_DATA_ENTREGA_ATE] AS [DataEntregaAte], [ORD_EMBARQUE_ALVO] AS [EmbarqueAlvo], [ORD_QUANTIDADE] AS [Quantidade], [SALDO_A_PRODUZIR_PA] AS [SaldoAProduzir], [SALDO_A_EXPEDIR] AS [SaldoAExpedir], [ORD_COR_FILA] AS [CorFila], [ORD_PED_CLI] AS [PedidoCliente] FROM [V_CONSULTA_PEDIDO] ";
                      dict["Quantidade"] = value; //06
                      whereClauses.Add($" [ORD_QUANTIDADE] = @Quantidade ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstBySaldoAProduzirQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [ORD_ID] AS [PedidoId], [CLI_ID] AS [ClienteId], [CLIENTE] AS [ClienteNome], [RAZAO_SOCIAL] AS [RazaoSocial], [PRO_ID] AS [ProdutoId], [PRO_DESCRICAO] AS [ProdutoDescricao], [ORD_STATUS] AS [Status], [ESTAGIO] AS [Estagio], [ORD_DATA_ENTREGA_DE] AS [DataEntregaDe], [ORD_DATA_ENTREGA_ATE] AS [DataEntregaAte], [ORD_EMBARQUE_ALVO] AS [EmbarqueAlvo], [ORD_QUANTIDADE] AS [Quantidade], [SALDO_A_PRODUZIR_PA] AS [SaldoAProduzir], [SALDO_A_EXPEDIR] AS [SaldoAExpedir], [ORD_COR_FILA] AS [CorFila], [ORD_PED_CLI] AS [PedidoCliente] FROM [V_CONSULTA_PEDIDO] ";
                      dict["SaldoAProduzir"] = value; //06
                      whereClauses.Add($" [SALDO_A_PRODUZIR_PA] = @SaldoAProduzir ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstBySaldoAExpedirQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [ORD_ID] AS [PedidoId], [CLI_ID] AS [ClienteId], [CLIENTE] AS [ClienteNome], [RAZAO_SOCIAL] AS [RazaoSocial], [PRO_ID] AS [ProdutoId], [PRO_DESCRICAO] AS [ProdutoDescricao], [ORD_STATUS] AS [Status], [ESTAGIO] AS [Estagio], [ORD_DATA_ENTREGA_DE] AS [DataEntregaDe], [ORD_DATA_ENTREGA_ATE] AS [DataEntregaAte], [ORD_EMBARQUE_ALVO] AS [EmbarqueAlvo], [ORD_QUANTIDADE] AS [Quantidade], [SALDO_A_PRODUZIR_PA] AS [SaldoAProduzir], [SALDO_A_EXPEDIR] AS [SaldoAExpedir], [ORD_COR_FILA] AS [CorFila], [ORD_PED_CLI] AS [PedidoCliente] FROM [V_CONSULTA_PEDIDO] ";
                      dict["SaldoAExpedir"] = value; //06
                      whereClauses.Add($" [SALDO_A_EXPEDIR] = @SaldoAExpedir ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCorFilaQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [ORD_ID] AS [PedidoId], [CLI_ID] AS [ClienteId], [CLIENTE] AS [ClienteNome], [RAZAO_SOCIAL] AS [RazaoSocial], [PRO_ID] AS [ProdutoId], [PRO_DESCRICAO] AS [ProdutoDescricao], [ORD_STATUS] AS [Status], [ESTAGIO] AS [Estagio], [ORD_DATA_ENTREGA_DE] AS [DataEntregaDe], [ORD_DATA_ENTREGA_ATE] AS [DataEntregaAte], [ORD_EMBARQUE_ALVO] AS [EmbarqueAlvo], [ORD_QUANTIDADE] AS [Quantidade], [SALDO_A_PRODUZIR_PA] AS [SaldoAProduzir], [SALDO_A_EXPEDIR] AS [SaldoAExpedir], [ORD_COR_FILA] AS [CorFila], [ORD_PED_CLI] AS [PedidoCliente] FROM [V_CONSULTA_PEDIDO] ";
                      dict["CorFila"] = value; //06
                      whereClauses.Add($" [ORD_COR_FILA] = @CorFila ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPedidoClienteQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [ORD_ID] AS [PedidoId], [CLI_ID] AS [ClienteId], [CLIENTE] AS [ClienteNome], [RAZAO_SOCIAL] AS [RazaoSocial], [PRO_ID] AS [ProdutoId], [PRO_DESCRICAO] AS [ProdutoDescricao], [ORD_STATUS] AS [Status], [ESTAGIO] AS [Estagio], [ORD_DATA_ENTREGA_DE] AS [DataEntregaDe], [ORD_DATA_ENTREGA_ATE] AS [DataEntregaAte], [ORD_EMBARQUE_ALVO] AS [EmbarqueAlvo], [ORD_QUANTIDADE] AS [Quantidade], [SALDO_A_PRODUZIR_PA] AS [SaldoAProduzir], [SALDO_A_EXPEDIR] AS [SaldoAExpedir], [ORD_COR_FILA] AS [CorFila], [ORD_PED_CLI] AS [PedidoCliente] FROM [V_CONSULTA_PEDIDO] ";
                      dict["PedidoCliente"] = value; //06
                      whereClauses.Add($" [ORD_PED_CLI] = @PedidoCliente ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration