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
    public class ItensOrcamentoQueryRead : QueryBase, IItensOrcamentoQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public ItensOrcamentoQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel ItensOrcamentoQuery(Command.Read.ItensOrcamentoReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select [Id], [ITO_ID], [ORC_ID], [TIP_ID], [PRO_ID], [ITO_OBS], [ITO_QUANTIDADE], [ITO_CUSTO], [ITO_MARGEM], [ITO_VALOR_UNITARIO], [ITO_VERSSAO_CUSTO], [ITO_STATUS], [ITO_ERP_CUSTOS_FIXOS], [ITO_ERP_CUSTOS_VARIAVEIS], [ITO_ERP_DESPESAS_VAR_VENDA], [ITO_ERP_IMPOSTOS], [GRP_ID_COMPOSICAO], [ITO_LARGURA], [ITO_COMPRIMENTO], [TenantID], [Deleted], [Changed], [UserId] from [ItensOrcamento] ";
if (Command.Id.HasValue) dict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"[Id] = @Id");
if (Command.ITO_ID.HasValue) dict["ITO_ID"] = Command.ITO_ID.Value;
if (Command.ITO_ID.HasValue) whereClauses.Add($"[ITO_ID] = @ITO_ID");
if (Command.ORC_ID.HasValue) dict["ORC_ID"] = Command.ORC_ID.Value;
if (Command.ORC_ID.HasValue) whereClauses.Add($"[ORC_ID] = @ORC_ID");
if (Command.TIP_ID.HasValue) dict["TIP_ID"] = Command.TIP_ID.Value;
if (Command.TIP_ID.HasValue) whereClauses.Add($"[TIP_ID] = @TIP_ID");
if (!string.IsNullOrEmpty(Command.PRO_ID)) dict["PRO_ID"] = $"%{Command.PRO_ID}%";
if (!string.IsNullOrEmpty(Command.PRO_ID)) whereClauses.Add($"[PRO_ID] like @PRO_ID");
if (!string.IsNullOrEmpty(Command.ITO_OBS)) dict["ITO_OBS"] = $"%{Command.ITO_OBS}%";
if (!string.IsNullOrEmpty(Command.ITO_OBS)) whereClauses.Add($"[ITO_OBS] like @ITO_OBS");
if (!string.IsNullOrEmpty(Command.ITO_STATUS)) dict["ITO_STATUS"] = $"%{Command.ITO_STATUS}%";
if (!string.IsNullOrEmpty(Command.ITO_STATUS)) whereClauses.Add($"[ITO_STATUS] like @ITO_STATUS");
if (!string.IsNullOrEmpty(Command.GRP_ID_COMPOSICAO)) dict["GRP_ID_COMPOSICAO"] = $"%{Command.GRP_ID_COMPOSICAO}%";
if (!string.IsNullOrEmpty(Command.GRP_ID_COMPOSICAO)) whereClauses.Add($"[GRP_ID_COMPOSICAO] like @GRP_ID_COMPOSICAO");
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
if (Command.UserId.HasValue) dict["UserId"] = Command.UserId.Value;
if (Command.UserId.HasValue) whereClauses.Add($"[UserId] = @UserId");
            if (whereClauses.Any()) 
                 this.Query += $" WHERE {string.Join(" AND ", whereClauses)}"; 
            int page = Command.Paginacao?.Page ?? 1;
            int pageSize = Command.Paginacao?.PageSize ?? 20;
            int offset = (page - 1) * pageSize;
            dict["Offset"] = offset;
            dict["PageSize"] = pageSize;
            Query += " ORDER BY [Id] OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel ItensOrcamentoGRP_ID_COMPOSICAOQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select [GRP_ID] from [GrupoProdutoAbstrato] ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["GRP_ID"] = numero; //01
                      whereClauses.Add($" [GRP_ID] = @GRP_ID");//01 
                 }
                 else 
                 {
                      dict["GRP_ID"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" [GRP_ID] like @GRP_ID ");//02
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
        public QueryModel ItensOrcamentoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select [Id], [Nome] from [yTenant] ";
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
                      dict["Nome"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" [Nome] like @Nome ");//02
                 }
           }
 dict["Id"] = _executionContext.TenantID;
 whereClauses.Add($"[Id] = @Id");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel ItensOrcamentoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select [Id], [Nome] from [yUser] ";
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
                      dict["Nome"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" [Nome] like @Nome ");//02
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
        public QueryModel ExistsByIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Id"] = value; //04
                      whereClauses.Add($" [Id] = @Id ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByITO_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ITO_ID"] = value; //04
                      whereClauses.Add($" [ITO_ID] = @ITO_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORC_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ORC_ID"] = value; //04
                      whereClauses.Add($" [ORC_ID] = @ORC_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTIP_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TIP_ID"] = value; //04
                      whereClauses.Add($" [TIP_ID] = @TIP_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PRO_ID"] = value; //04
                      whereClauses.Add($" [PRO_ID] = @PRO_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByITO_OBSQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ITO_OBS"] = value; //04
                      whereClauses.Add($" [ITO_OBS] = @ITO_OBS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByITO_QUANTIDADEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ITO_QUANTIDADE"] = value; //04
                      whereClauses.Add($" [ITO_QUANTIDADE] = @ITO_QUANTIDADE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByITO_CUSTOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ITO_CUSTO"] = value; //04
                      whereClauses.Add($" [ITO_CUSTO] = @ITO_CUSTO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByITO_MARGEMQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ITO_MARGEM"] = value; //04
                      whereClauses.Add($" [ITO_MARGEM] = @ITO_MARGEM ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByITO_VALOR_UNITARIOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ITO_VALOR_UNITARIO"] = value; //04
                      whereClauses.Add($" [ITO_VALOR_UNITARIO] = @ITO_VALOR_UNITARIO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByITO_VERSSAO_CUSTOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ITO_VERSSAO_CUSTO"] = value; //04
                      whereClauses.Add($" [ITO_VERSSAO_CUSTO] = @ITO_VERSSAO_CUSTO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByITO_STATUSQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ITO_STATUS"] = value; //04
                      whereClauses.Add($" [ITO_STATUS] = @ITO_STATUS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByITO_ERP_CUSTOS_FIXOSQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ITO_ERP_CUSTOS_FIXOS"] = value; //04
                      whereClauses.Add($" [ITO_ERP_CUSTOS_FIXOS] = @ITO_ERP_CUSTOS_FIXOS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByITO_ERP_CUSTOS_VARIAVEISQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ITO_ERP_CUSTOS_VARIAVEIS"] = value; //04
                      whereClauses.Add($" [ITO_ERP_CUSTOS_VARIAVEIS] = @ITO_ERP_CUSTOS_VARIAVEIS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByITO_ERP_DESPESAS_VAR_VENDAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ITO_ERP_DESPESAS_VAR_VENDA"] = value; //04
                      whereClauses.Add($" [ITO_ERP_DESPESAS_VAR_VENDA] = @ITO_ERP_DESPESAS_VAR_VENDA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByITO_ERP_IMPOSTOSQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ITO_ERP_IMPOSTOS"] = value; //04
                      whereClauses.Add($" [ITO_ERP_IMPOSTOS] = @ITO_ERP_IMPOSTOS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_ID_COMPOSICAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["GRP_ID_COMPOSICAO"] = value; //04
                      whereClauses.Add($" [GRP_ID_COMPOSICAO] = @GRP_ID_COMPOSICAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByITO_LARGURAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ITO_LARGURA"] = value; //04
                      whereClauses.Add($" [ITO_LARGURA] = @ITO_LARGURA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByITO_COMPRIMENTOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ITO_COMPRIMENTO"] = value; //04
                      whereClauses.Add($" [ITO_COMPRIMENTO] = @ITO_COMPRIMENTO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTenantIDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TenantID"] = value; //04
                      whereClauses.Add($" [TenantID] = @TenantID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByDeletedQuery(bool value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Deleted"] = value; //04
                      whereClauses.Add($" [Deleted] = @Deleted ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByChangedQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Changed"] = value; //04
                      whereClauses.Add($" [Changed] = @Changed ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByUserIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["UserId"] = value; //04
                      whereClauses.Add($" [UserId] = @UserId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [ITO_ID], [ORC_ID], [TIP_ID], [PRO_ID], [ITO_OBS], [ITO_QUANTIDADE], [ITO_CUSTO], [ITO_MARGEM], [ITO_VALOR_UNITARIO], [ITO_VERSSAO_CUSTO], [ITO_STATUS], [ITO_ERP_CUSTOS_FIXOS], [ITO_ERP_CUSTOS_VARIAVEIS], [ITO_ERP_DESPESAS_VAR_VENDA], [ITO_ERP_IMPOSTOS], [GRP_ID_COMPOSICAO], [ITO_LARGURA], [ITO_COMPRIMENTO], [TenantID], [Deleted], [Changed], [UserId] FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Id"] = value; //06
                      whereClauses.Add($" [Id] = @Id ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByITO_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [ITO_ID], [ORC_ID], [TIP_ID], [PRO_ID], [ITO_OBS], [ITO_QUANTIDADE], [ITO_CUSTO], [ITO_MARGEM], [ITO_VALOR_UNITARIO], [ITO_VERSSAO_CUSTO], [ITO_STATUS], [ITO_ERP_CUSTOS_FIXOS], [ITO_ERP_CUSTOS_VARIAVEIS], [ITO_ERP_DESPESAS_VAR_VENDA], [ITO_ERP_IMPOSTOS], [GRP_ID_COMPOSICAO], [ITO_LARGURA], [ITO_COMPRIMENTO], [TenantID], [Deleted], [Changed], [UserId] FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ITO_ID"] = value; //06
                      whereClauses.Add($" [ITO_ID] = @ITO_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORC_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [ITO_ID], [ORC_ID], [TIP_ID], [PRO_ID], [ITO_OBS], [ITO_QUANTIDADE], [ITO_CUSTO], [ITO_MARGEM], [ITO_VALOR_UNITARIO], [ITO_VERSSAO_CUSTO], [ITO_STATUS], [ITO_ERP_CUSTOS_FIXOS], [ITO_ERP_CUSTOS_VARIAVEIS], [ITO_ERP_DESPESAS_VAR_VENDA], [ITO_ERP_IMPOSTOS], [GRP_ID_COMPOSICAO], [ITO_LARGURA], [ITO_COMPRIMENTO], [TenantID], [Deleted], [Changed], [UserId] FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ORC_ID"] = value; //06
                      whereClauses.Add($" [ORC_ID] = @ORC_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTIP_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [ITO_ID], [ORC_ID], [TIP_ID], [PRO_ID], [ITO_OBS], [ITO_QUANTIDADE], [ITO_CUSTO], [ITO_MARGEM], [ITO_VALOR_UNITARIO], [ITO_VERSSAO_CUSTO], [ITO_STATUS], [ITO_ERP_CUSTOS_FIXOS], [ITO_ERP_CUSTOS_VARIAVEIS], [ITO_ERP_DESPESAS_VAR_VENDA], [ITO_ERP_IMPOSTOS], [GRP_ID_COMPOSICAO], [ITO_LARGURA], [ITO_COMPRIMENTO], [TenantID], [Deleted], [Changed], [UserId] FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TIP_ID"] = value; //06
                      whereClauses.Add($" [TIP_ID] = @TIP_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [ITO_ID], [ORC_ID], [TIP_ID], [PRO_ID], [ITO_OBS], [ITO_QUANTIDADE], [ITO_CUSTO], [ITO_MARGEM], [ITO_VALOR_UNITARIO], [ITO_VERSSAO_CUSTO], [ITO_STATUS], [ITO_ERP_CUSTOS_FIXOS], [ITO_ERP_CUSTOS_VARIAVEIS], [ITO_ERP_DESPESAS_VAR_VENDA], [ITO_ERP_IMPOSTOS], [GRP_ID_COMPOSICAO], [ITO_LARGURA], [ITO_COMPRIMENTO], [TenantID], [Deleted], [Changed], [UserId] FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PRO_ID"] = value; //06
                      whereClauses.Add($" [PRO_ID] = @PRO_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByITO_OBSQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [ITO_ID], [ORC_ID], [TIP_ID], [PRO_ID], [ITO_OBS], [ITO_QUANTIDADE], [ITO_CUSTO], [ITO_MARGEM], [ITO_VALOR_UNITARIO], [ITO_VERSSAO_CUSTO], [ITO_STATUS], [ITO_ERP_CUSTOS_FIXOS], [ITO_ERP_CUSTOS_VARIAVEIS], [ITO_ERP_DESPESAS_VAR_VENDA], [ITO_ERP_IMPOSTOS], [GRP_ID_COMPOSICAO], [ITO_LARGURA], [ITO_COMPRIMENTO], [TenantID], [Deleted], [Changed], [UserId] FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ITO_OBS"] = value; //06
                      whereClauses.Add($" [ITO_OBS] = @ITO_OBS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByITO_QUANTIDADEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [ITO_ID], [ORC_ID], [TIP_ID], [PRO_ID], [ITO_OBS], [ITO_QUANTIDADE], [ITO_CUSTO], [ITO_MARGEM], [ITO_VALOR_UNITARIO], [ITO_VERSSAO_CUSTO], [ITO_STATUS], [ITO_ERP_CUSTOS_FIXOS], [ITO_ERP_CUSTOS_VARIAVEIS], [ITO_ERP_DESPESAS_VAR_VENDA], [ITO_ERP_IMPOSTOS], [GRP_ID_COMPOSICAO], [ITO_LARGURA], [ITO_COMPRIMENTO], [TenantID], [Deleted], [Changed], [UserId] FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ITO_QUANTIDADE"] = value; //06
                      whereClauses.Add($" [ITO_QUANTIDADE] = @ITO_QUANTIDADE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByITO_CUSTOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [ITO_ID], [ORC_ID], [TIP_ID], [PRO_ID], [ITO_OBS], [ITO_QUANTIDADE], [ITO_CUSTO], [ITO_MARGEM], [ITO_VALOR_UNITARIO], [ITO_VERSSAO_CUSTO], [ITO_STATUS], [ITO_ERP_CUSTOS_FIXOS], [ITO_ERP_CUSTOS_VARIAVEIS], [ITO_ERP_DESPESAS_VAR_VENDA], [ITO_ERP_IMPOSTOS], [GRP_ID_COMPOSICAO], [ITO_LARGURA], [ITO_COMPRIMENTO], [TenantID], [Deleted], [Changed], [UserId] FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ITO_CUSTO"] = value; //06
                      whereClauses.Add($" [ITO_CUSTO] = @ITO_CUSTO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByITO_MARGEMQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [ITO_ID], [ORC_ID], [TIP_ID], [PRO_ID], [ITO_OBS], [ITO_QUANTIDADE], [ITO_CUSTO], [ITO_MARGEM], [ITO_VALOR_UNITARIO], [ITO_VERSSAO_CUSTO], [ITO_STATUS], [ITO_ERP_CUSTOS_FIXOS], [ITO_ERP_CUSTOS_VARIAVEIS], [ITO_ERP_DESPESAS_VAR_VENDA], [ITO_ERP_IMPOSTOS], [GRP_ID_COMPOSICAO], [ITO_LARGURA], [ITO_COMPRIMENTO], [TenantID], [Deleted], [Changed], [UserId] FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ITO_MARGEM"] = value; //06
                      whereClauses.Add($" [ITO_MARGEM] = @ITO_MARGEM ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByITO_VALOR_UNITARIOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [ITO_ID], [ORC_ID], [TIP_ID], [PRO_ID], [ITO_OBS], [ITO_QUANTIDADE], [ITO_CUSTO], [ITO_MARGEM], [ITO_VALOR_UNITARIO], [ITO_VERSSAO_CUSTO], [ITO_STATUS], [ITO_ERP_CUSTOS_FIXOS], [ITO_ERP_CUSTOS_VARIAVEIS], [ITO_ERP_DESPESAS_VAR_VENDA], [ITO_ERP_IMPOSTOS], [GRP_ID_COMPOSICAO], [ITO_LARGURA], [ITO_COMPRIMENTO], [TenantID], [Deleted], [Changed], [UserId] FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ITO_VALOR_UNITARIO"] = value; //06
                      whereClauses.Add($" [ITO_VALOR_UNITARIO] = @ITO_VALOR_UNITARIO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByITO_VERSSAO_CUSTOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [ITO_ID], [ORC_ID], [TIP_ID], [PRO_ID], [ITO_OBS], [ITO_QUANTIDADE], [ITO_CUSTO], [ITO_MARGEM], [ITO_VALOR_UNITARIO], [ITO_VERSSAO_CUSTO], [ITO_STATUS], [ITO_ERP_CUSTOS_FIXOS], [ITO_ERP_CUSTOS_VARIAVEIS], [ITO_ERP_DESPESAS_VAR_VENDA], [ITO_ERP_IMPOSTOS], [GRP_ID_COMPOSICAO], [ITO_LARGURA], [ITO_COMPRIMENTO], [TenantID], [Deleted], [Changed], [UserId] FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ITO_VERSSAO_CUSTO"] = value; //06
                      whereClauses.Add($" [ITO_VERSSAO_CUSTO] = @ITO_VERSSAO_CUSTO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByITO_STATUSQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [ITO_ID], [ORC_ID], [TIP_ID], [PRO_ID], [ITO_OBS], [ITO_QUANTIDADE], [ITO_CUSTO], [ITO_MARGEM], [ITO_VALOR_UNITARIO], [ITO_VERSSAO_CUSTO], [ITO_STATUS], [ITO_ERP_CUSTOS_FIXOS], [ITO_ERP_CUSTOS_VARIAVEIS], [ITO_ERP_DESPESAS_VAR_VENDA], [ITO_ERP_IMPOSTOS], [GRP_ID_COMPOSICAO], [ITO_LARGURA], [ITO_COMPRIMENTO], [TenantID], [Deleted], [Changed], [UserId] FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ITO_STATUS"] = value; //06
                      whereClauses.Add($" [ITO_STATUS] = @ITO_STATUS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByITO_ERP_CUSTOS_FIXOSQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [ITO_ID], [ORC_ID], [TIP_ID], [PRO_ID], [ITO_OBS], [ITO_QUANTIDADE], [ITO_CUSTO], [ITO_MARGEM], [ITO_VALOR_UNITARIO], [ITO_VERSSAO_CUSTO], [ITO_STATUS], [ITO_ERP_CUSTOS_FIXOS], [ITO_ERP_CUSTOS_VARIAVEIS], [ITO_ERP_DESPESAS_VAR_VENDA], [ITO_ERP_IMPOSTOS], [GRP_ID_COMPOSICAO], [ITO_LARGURA], [ITO_COMPRIMENTO], [TenantID], [Deleted], [Changed], [UserId] FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ITO_ERP_CUSTOS_FIXOS"] = value; //06
                      whereClauses.Add($" [ITO_ERP_CUSTOS_FIXOS] = @ITO_ERP_CUSTOS_FIXOS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByITO_ERP_CUSTOS_VARIAVEISQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [ITO_ID], [ORC_ID], [TIP_ID], [PRO_ID], [ITO_OBS], [ITO_QUANTIDADE], [ITO_CUSTO], [ITO_MARGEM], [ITO_VALOR_UNITARIO], [ITO_VERSSAO_CUSTO], [ITO_STATUS], [ITO_ERP_CUSTOS_FIXOS], [ITO_ERP_CUSTOS_VARIAVEIS], [ITO_ERP_DESPESAS_VAR_VENDA], [ITO_ERP_IMPOSTOS], [GRP_ID_COMPOSICAO], [ITO_LARGURA], [ITO_COMPRIMENTO], [TenantID], [Deleted], [Changed], [UserId] FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ITO_ERP_CUSTOS_VARIAVEIS"] = value; //06
                      whereClauses.Add($" [ITO_ERP_CUSTOS_VARIAVEIS] = @ITO_ERP_CUSTOS_VARIAVEIS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByITO_ERP_DESPESAS_VAR_VENDAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [ITO_ID], [ORC_ID], [TIP_ID], [PRO_ID], [ITO_OBS], [ITO_QUANTIDADE], [ITO_CUSTO], [ITO_MARGEM], [ITO_VALOR_UNITARIO], [ITO_VERSSAO_CUSTO], [ITO_STATUS], [ITO_ERP_CUSTOS_FIXOS], [ITO_ERP_CUSTOS_VARIAVEIS], [ITO_ERP_DESPESAS_VAR_VENDA], [ITO_ERP_IMPOSTOS], [GRP_ID_COMPOSICAO], [ITO_LARGURA], [ITO_COMPRIMENTO], [TenantID], [Deleted], [Changed], [UserId] FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ITO_ERP_DESPESAS_VAR_VENDA"] = value; //06
                      whereClauses.Add($" [ITO_ERP_DESPESAS_VAR_VENDA] = @ITO_ERP_DESPESAS_VAR_VENDA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByITO_ERP_IMPOSTOSQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [ITO_ID], [ORC_ID], [TIP_ID], [PRO_ID], [ITO_OBS], [ITO_QUANTIDADE], [ITO_CUSTO], [ITO_MARGEM], [ITO_VALOR_UNITARIO], [ITO_VERSSAO_CUSTO], [ITO_STATUS], [ITO_ERP_CUSTOS_FIXOS], [ITO_ERP_CUSTOS_VARIAVEIS], [ITO_ERP_DESPESAS_VAR_VENDA], [ITO_ERP_IMPOSTOS], [GRP_ID_COMPOSICAO], [ITO_LARGURA], [ITO_COMPRIMENTO], [TenantID], [Deleted], [Changed], [UserId] FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ITO_ERP_IMPOSTOS"] = value; //06
                      whereClauses.Add($" [ITO_ERP_IMPOSTOS] = @ITO_ERP_IMPOSTOS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_ID_COMPOSICAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [ITO_ID], [ORC_ID], [TIP_ID], [PRO_ID], [ITO_OBS], [ITO_QUANTIDADE], [ITO_CUSTO], [ITO_MARGEM], [ITO_VALOR_UNITARIO], [ITO_VERSSAO_CUSTO], [ITO_STATUS], [ITO_ERP_CUSTOS_FIXOS], [ITO_ERP_CUSTOS_VARIAVEIS], [ITO_ERP_DESPESAS_VAR_VENDA], [ITO_ERP_IMPOSTOS], [GRP_ID_COMPOSICAO], [ITO_LARGURA], [ITO_COMPRIMENTO], [TenantID], [Deleted], [Changed], [UserId] FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["GRP_ID_COMPOSICAO"] = value; //06
                      whereClauses.Add($" [GRP_ID_COMPOSICAO] = @GRP_ID_COMPOSICAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByITO_LARGURAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [ITO_ID], [ORC_ID], [TIP_ID], [PRO_ID], [ITO_OBS], [ITO_QUANTIDADE], [ITO_CUSTO], [ITO_MARGEM], [ITO_VALOR_UNITARIO], [ITO_VERSSAO_CUSTO], [ITO_STATUS], [ITO_ERP_CUSTOS_FIXOS], [ITO_ERP_CUSTOS_VARIAVEIS], [ITO_ERP_DESPESAS_VAR_VENDA], [ITO_ERP_IMPOSTOS], [GRP_ID_COMPOSICAO], [ITO_LARGURA], [ITO_COMPRIMENTO], [TenantID], [Deleted], [Changed], [UserId] FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ITO_LARGURA"] = value; //06
                      whereClauses.Add($" [ITO_LARGURA] = @ITO_LARGURA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByITO_COMPRIMENTOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [ITO_ID], [ORC_ID], [TIP_ID], [PRO_ID], [ITO_OBS], [ITO_QUANTIDADE], [ITO_CUSTO], [ITO_MARGEM], [ITO_VALOR_UNITARIO], [ITO_VERSSAO_CUSTO], [ITO_STATUS], [ITO_ERP_CUSTOS_FIXOS], [ITO_ERP_CUSTOS_VARIAVEIS], [ITO_ERP_DESPESAS_VAR_VENDA], [ITO_ERP_IMPOSTOS], [GRP_ID_COMPOSICAO], [ITO_LARGURA], [ITO_COMPRIMENTO], [TenantID], [Deleted], [Changed], [UserId] FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ITO_COMPRIMENTO"] = value; //06
                      whereClauses.Add($" [ITO_COMPRIMENTO] = @ITO_COMPRIMENTO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTenantIDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [ITO_ID], [ORC_ID], [TIP_ID], [PRO_ID], [ITO_OBS], [ITO_QUANTIDADE], [ITO_CUSTO], [ITO_MARGEM], [ITO_VALOR_UNITARIO], [ITO_VERSSAO_CUSTO], [ITO_STATUS], [ITO_ERP_CUSTOS_FIXOS], [ITO_ERP_CUSTOS_VARIAVEIS], [ITO_ERP_DESPESAS_VAR_VENDA], [ITO_ERP_IMPOSTOS], [GRP_ID_COMPOSICAO], [ITO_LARGURA], [ITO_COMPRIMENTO], [TenantID], [Deleted], [Changed], [UserId] FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TenantID"] = value; //06
                      whereClauses.Add($" [TenantID] = @TenantID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByDeletedQuery(bool value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [ITO_ID], [ORC_ID], [TIP_ID], [PRO_ID], [ITO_OBS], [ITO_QUANTIDADE], [ITO_CUSTO], [ITO_MARGEM], [ITO_VALOR_UNITARIO], [ITO_VERSSAO_CUSTO], [ITO_STATUS], [ITO_ERP_CUSTOS_FIXOS], [ITO_ERP_CUSTOS_VARIAVEIS], [ITO_ERP_DESPESAS_VAR_VENDA], [ITO_ERP_IMPOSTOS], [GRP_ID_COMPOSICAO], [ITO_LARGURA], [ITO_COMPRIMENTO], [TenantID], [Deleted], [Changed], [UserId] FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Deleted"] = value; //06
                      whereClauses.Add($" [Deleted] = @Deleted ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByChangedQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [ITO_ID], [ORC_ID], [TIP_ID], [PRO_ID], [ITO_OBS], [ITO_QUANTIDADE], [ITO_CUSTO], [ITO_MARGEM], [ITO_VALOR_UNITARIO], [ITO_VERSSAO_CUSTO], [ITO_STATUS], [ITO_ERP_CUSTOS_FIXOS], [ITO_ERP_CUSTOS_VARIAVEIS], [ITO_ERP_DESPESAS_VAR_VENDA], [ITO_ERP_IMPOSTOS], [GRP_ID_COMPOSICAO], [ITO_LARGURA], [ITO_COMPRIMENTO], [TenantID], [Deleted], [Changed], [UserId] FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Changed"] = value; //06
                      whereClauses.Add($" [Changed] = @Changed ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByUserIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [ITO_ID], [ORC_ID], [TIP_ID], [PRO_ID], [ITO_OBS], [ITO_QUANTIDADE], [ITO_CUSTO], [ITO_MARGEM], [ITO_VALOR_UNITARIO], [ITO_VERSSAO_CUSTO], [ITO_STATUS], [ITO_ERP_CUSTOS_FIXOS], [ITO_ERP_CUSTOS_VARIAVEIS], [ITO_ERP_DESPESAS_VAR_VENDA], [ITO_ERP_IMPOSTOS], [GRP_ID_COMPOSICAO], [ITO_LARGURA], [ITO_COMPRIMENTO], [TenantID], [Deleted], [Changed], [UserId] FROM [ItensOrcamento] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["UserId"] = value; //06
                      whereClauses.Add($" [UserId] = @UserId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration