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
    public class EstruturaCustoQueryRead : QueryBase, IEstruturaCustoQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public EstruturaCustoQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel EstruturaCustoQuery(Command.Read.EstruturaCustoReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select [EST_ID], [ITO_ID], [ORD_ID], [PRO_ID], [PRO_ID_PRODUTO], [PRO_ID_COMPONENTE], [PRO_TIPO_CUSTO], [PRO_GRUPO_CONTABIL], [EST_ORDEM], [EST_GRUPO], [EST_QUANT], [EST_VALOR_TOTAL], [EST_DATA_BASE], [EST_BASE_PRODUCAO], [EST_NIVEL], [FPR_SEQ_REPETICAO], [TenantID], [Deleted], [Changed], [UserId] from [EstruturaCusto] ";
if (Command.EST_ID.HasValue) dict["EST_ID"] = Command.EST_ID.Value;
if (Command.EST_ID.HasValue) whereClauses.Add($"[EST_ID] = @EST_ID");
if (Command.ITO_ID.HasValue) dict["ITO_ID"] = Command.ITO_ID.Value;
if (Command.ITO_ID.HasValue) whereClauses.Add($"[ITO_ID] = @ITO_ID");
if (!string.IsNullOrEmpty(Command.ORD_ID)) dict["ORD_ID"] = $"%{Command.ORD_ID}%";
if (!string.IsNullOrEmpty(Command.ORD_ID)) whereClauses.Add($"[ORD_ID] like @ORD_ID");
if (!string.IsNullOrEmpty(Command.PRO_ID)) dict["PRO_ID"] = $"%{Command.PRO_ID}%";
if (!string.IsNullOrEmpty(Command.PRO_ID)) whereClauses.Add($"[PRO_ID] like @PRO_ID");
if (!string.IsNullOrEmpty(Command.PRO_ID_PRODUTO)) dict["PRO_ID_PRODUTO"] = $"%{Command.PRO_ID_PRODUTO}%";
if (!string.IsNullOrEmpty(Command.PRO_ID_PRODUTO)) whereClauses.Add($"[PRO_ID_PRODUTO] like @PRO_ID_PRODUTO");
if (!string.IsNullOrEmpty(Command.PRO_ID_COMPONENTE)) dict["PRO_ID_COMPONENTE"] = $"%{Command.PRO_ID_COMPONENTE}%";
if (!string.IsNullOrEmpty(Command.PRO_ID_COMPONENTE)) whereClauses.Add($"[PRO_ID_COMPONENTE] like @PRO_ID_COMPONENTE");
if (!string.IsNullOrEmpty(Command.PRO_TIPO_CUSTO)) dict["PRO_TIPO_CUSTO"] = $"%{Command.PRO_TIPO_CUSTO}%";
if (!string.IsNullOrEmpty(Command.PRO_TIPO_CUSTO)) whereClauses.Add($"[PRO_TIPO_CUSTO] like @PRO_TIPO_CUSTO");
if (!string.IsNullOrEmpty(Command.PRO_GRUPO_CONTABIL)) dict["PRO_GRUPO_CONTABIL"] = $"%{Command.PRO_GRUPO_CONTABIL}%";
if (!string.IsNullOrEmpty(Command.PRO_GRUPO_CONTABIL)) whereClauses.Add($"[PRO_GRUPO_CONTABIL] like @PRO_GRUPO_CONTABIL");
if (Command.EST_ORDEM.HasValue) dict["EST_ORDEM"] = Command.EST_ORDEM.Value;
if (Command.EST_ORDEM.HasValue) whereClauses.Add($"[EST_ORDEM] = @EST_ORDEM");
if (!string.IsNullOrEmpty(Command.EST_GRUPO)) dict["EST_GRUPO"] = $"%{Command.EST_GRUPO}%";
if (!string.IsNullOrEmpty(Command.EST_GRUPO)) whereClauses.Add($"[EST_GRUPO] like @EST_GRUPO");
if (!string.IsNullOrEmpty(Command.EST_DATA_BASE)) dict["EST_DATA_BASE"] = $"%{Command.EST_DATA_BASE}%";
if (!string.IsNullOrEmpty(Command.EST_DATA_BASE)) whereClauses.Add($"[EST_DATA_BASE] like @EST_DATA_BASE");
if (Command.FPR_SEQ_REPETICAO.HasValue) dict["FPR_SEQ_REPETICAO"] = Command.FPR_SEQ_REPETICAO.Value;
if (Command.FPR_SEQ_REPETICAO.HasValue) whereClauses.Add($"[FPR_SEQ_REPETICAO] = @FPR_SEQ_REPETICAO");
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
            Query += " ORDER BY [EST_ID] OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel EstruturaCustoORD_IDQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select [ORD_ID] from [Order] ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["ORD_ID"] = numero; //01
                      whereClauses.Add($" [ORD_ID] = @ORD_ID");//01 
                 }
                 else 
                 {
                      dict["ORD_ID"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" [ORD_ID] like @ORD_ID ");//02
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
        public QueryModel EstruturaCustoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel EstruturaCustoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel ExistsByEST_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EstruturaCusto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["EST_ID"] = value; //04
                      whereClauses.Add($" [EST_ID] = @EST_ID ");//04
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
            this.Query = $"SELECT 1 FROM [EstruturaCusto] ";
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
        public QueryModel ExistsByORD_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EstruturaCusto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ORD_ID"] = value; //04
                      whereClauses.Add($" [ORD_ID] = @ORD_ID ");//04
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
            this.Query = $"SELECT 1 FROM [EstruturaCusto] ";
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
        public QueryModel ExistsByPRO_ID_PRODUTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EstruturaCusto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PRO_ID_PRODUTO"] = value; //04
                      whereClauses.Add($" [PRO_ID_PRODUTO] = @PRO_ID_PRODUTO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_ID_COMPONENTEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EstruturaCusto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PRO_ID_COMPONENTE"] = value; //04
                      whereClauses.Add($" [PRO_ID_COMPONENTE] = @PRO_ID_COMPONENTE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_TIPO_CUSTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EstruturaCusto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PRO_TIPO_CUSTO"] = value; //04
                      whereClauses.Add($" [PRO_TIPO_CUSTO] = @PRO_TIPO_CUSTO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_GRUPO_CONTABILQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EstruturaCusto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PRO_GRUPO_CONTABIL"] = value; //04
                      whereClauses.Add($" [PRO_GRUPO_CONTABIL] = @PRO_GRUPO_CONTABIL ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByEST_ORDEMQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EstruturaCusto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["EST_ORDEM"] = value; //04
                      whereClauses.Add($" [EST_ORDEM] = @EST_ORDEM ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByEST_GRUPOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EstruturaCusto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["EST_GRUPO"] = value; //04
                      whereClauses.Add($" [EST_GRUPO] = @EST_GRUPO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByEST_QUANTQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EstruturaCusto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["EST_QUANT"] = value; //04
                      whereClauses.Add($" [EST_QUANT] = @EST_QUANT ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByEST_VALOR_TOTALQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EstruturaCusto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["EST_VALOR_TOTAL"] = value; //04
                      whereClauses.Add($" [EST_VALOR_TOTAL] = @EST_VALOR_TOTAL ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByEST_DATA_BASEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EstruturaCusto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["EST_DATA_BASE"] = value; //04
                      whereClauses.Add($" [EST_DATA_BASE] = @EST_DATA_BASE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByEST_BASE_PRODUCAOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EstruturaCusto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["EST_BASE_PRODUCAO"] = value; //04
                      whereClauses.Add($" [EST_BASE_PRODUCAO] = @EST_BASE_PRODUCAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByEST_NIVELQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EstruturaCusto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["EST_NIVEL"] = value; //04
                      whereClauses.Add($" [EST_NIVEL] = @EST_NIVEL ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_SEQ_REPETICAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [EstruturaCusto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["FPR_SEQ_REPETICAO"] = value; //04
                      whereClauses.Add($" [FPR_SEQ_REPETICAO] = @FPR_SEQ_REPETICAO ");//04
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
            this.Query = $"SELECT 1 FROM [EstruturaCusto] ";
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
            this.Query = $"SELECT 1 FROM [EstruturaCusto] ";
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
            this.Query = $"SELECT 1 FROM [EstruturaCusto] ";
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
            this.Query = $"SELECT 1 FROM [EstruturaCusto] ";
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
        public QueryModel FirstByEST_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [EST_ID], [ITO_ID], [ORD_ID], [PRO_ID], [PRO_ID_PRODUTO], [PRO_ID_COMPONENTE], [PRO_TIPO_CUSTO], [PRO_GRUPO_CONTABIL], [EST_ORDEM], [EST_GRUPO], [EST_QUANT], [EST_VALOR_TOTAL], [EST_DATA_BASE], [EST_BASE_PRODUCAO], [EST_NIVEL], [FPR_SEQ_REPETICAO], [TenantID], [Deleted], [Changed], [UserId] FROM [EstruturaCusto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["EST_ID"] = value; //06
                      whereClauses.Add($" [EST_ID] = @EST_ID ");//06
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
            this.Query = $"SELECT [EST_ID], [ITO_ID], [ORD_ID], [PRO_ID], [PRO_ID_PRODUTO], [PRO_ID_COMPONENTE], [PRO_TIPO_CUSTO], [PRO_GRUPO_CONTABIL], [EST_ORDEM], [EST_GRUPO], [EST_QUANT], [EST_VALOR_TOTAL], [EST_DATA_BASE], [EST_BASE_PRODUCAO], [EST_NIVEL], [FPR_SEQ_REPETICAO], [TenantID], [Deleted], [Changed], [UserId] FROM [EstruturaCusto] ";
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
        public QueryModel FirstByORD_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [EST_ID], [ITO_ID], [ORD_ID], [PRO_ID], [PRO_ID_PRODUTO], [PRO_ID_COMPONENTE], [PRO_TIPO_CUSTO], [PRO_GRUPO_CONTABIL], [EST_ORDEM], [EST_GRUPO], [EST_QUANT], [EST_VALOR_TOTAL], [EST_DATA_BASE], [EST_BASE_PRODUCAO], [EST_NIVEL], [FPR_SEQ_REPETICAO], [TenantID], [Deleted], [Changed], [UserId] FROM [EstruturaCusto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ORD_ID"] = value; //06
                      whereClauses.Add($" [ORD_ID] = @ORD_ID ");//06
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
            this.Query = $"SELECT [EST_ID], [ITO_ID], [ORD_ID], [PRO_ID], [PRO_ID_PRODUTO], [PRO_ID_COMPONENTE], [PRO_TIPO_CUSTO], [PRO_GRUPO_CONTABIL], [EST_ORDEM], [EST_GRUPO], [EST_QUANT], [EST_VALOR_TOTAL], [EST_DATA_BASE], [EST_BASE_PRODUCAO], [EST_NIVEL], [FPR_SEQ_REPETICAO], [TenantID], [Deleted], [Changed], [UserId] FROM [EstruturaCusto] ";
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
        public QueryModel FirstByPRO_ID_PRODUTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [EST_ID], [ITO_ID], [ORD_ID], [PRO_ID], [PRO_ID_PRODUTO], [PRO_ID_COMPONENTE], [PRO_TIPO_CUSTO], [PRO_GRUPO_CONTABIL], [EST_ORDEM], [EST_GRUPO], [EST_QUANT], [EST_VALOR_TOTAL], [EST_DATA_BASE], [EST_BASE_PRODUCAO], [EST_NIVEL], [FPR_SEQ_REPETICAO], [TenantID], [Deleted], [Changed], [UserId] FROM [EstruturaCusto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PRO_ID_PRODUTO"] = value; //06
                      whereClauses.Add($" [PRO_ID_PRODUTO] = @PRO_ID_PRODUTO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_ID_COMPONENTEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [EST_ID], [ITO_ID], [ORD_ID], [PRO_ID], [PRO_ID_PRODUTO], [PRO_ID_COMPONENTE], [PRO_TIPO_CUSTO], [PRO_GRUPO_CONTABIL], [EST_ORDEM], [EST_GRUPO], [EST_QUANT], [EST_VALOR_TOTAL], [EST_DATA_BASE], [EST_BASE_PRODUCAO], [EST_NIVEL], [FPR_SEQ_REPETICAO], [TenantID], [Deleted], [Changed], [UserId] FROM [EstruturaCusto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PRO_ID_COMPONENTE"] = value; //06
                      whereClauses.Add($" [PRO_ID_COMPONENTE] = @PRO_ID_COMPONENTE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_TIPO_CUSTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [EST_ID], [ITO_ID], [ORD_ID], [PRO_ID], [PRO_ID_PRODUTO], [PRO_ID_COMPONENTE], [PRO_TIPO_CUSTO], [PRO_GRUPO_CONTABIL], [EST_ORDEM], [EST_GRUPO], [EST_QUANT], [EST_VALOR_TOTAL], [EST_DATA_BASE], [EST_BASE_PRODUCAO], [EST_NIVEL], [FPR_SEQ_REPETICAO], [TenantID], [Deleted], [Changed], [UserId] FROM [EstruturaCusto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PRO_TIPO_CUSTO"] = value; //06
                      whereClauses.Add($" [PRO_TIPO_CUSTO] = @PRO_TIPO_CUSTO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_GRUPO_CONTABILQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [EST_ID], [ITO_ID], [ORD_ID], [PRO_ID], [PRO_ID_PRODUTO], [PRO_ID_COMPONENTE], [PRO_TIPO_CUSTO], [PRO_GRUPO_CONTABIL], [EST_ORDEM], [EST_GRUPO], [EST_QUANT], [EST_VALOR_TOTAL], [EST_DATA_BASE], [EST_BASE_PRODUCAO], [EST_NIVEL], [FPR_SEQ_REPETICAO], [TenantID], [Deleted], [Changed], [UserId] FROM [EstruturaCusto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PRO_GRUPO_CONTABIL"] = value; //06
                      whereClauses.Add($" [PRO_GRUPO_CONTABIL] = @PRO_GRUPO_CONTABIL ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByEST_ORDEMQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [EST_ID], [ITO_ID], [ORD_ID], [PRO_ID], [PRO_ID_PRODUTO], [PRO_ID_COMPONENTE], [PRO_TIPO_CUSTO], [PRO_GRUPO_CONTABIL], [EST_ORDEM], [EST_GRUPO], [EST_QUANT], [EST_VALOR_TOTAL], [EST_DATA_BASE], [EST_BASE_PRODUCAO], [EST_NIVEL], [FPR_SEQ_REPETICAO], [TenantID], [Deleted], [Changed], [UserId] FROM [EstruturaCusto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["EST_ORDEM"] = value; //06
                      whereClauses.Add($" [EST_ORDEM] = @EST_ORDEM ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByEST_GRUPOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [EST_ID], [ITO_ID], [ORD_ID], [PRO_ID], [PRO_ID_PRODUTO], [PRO_ID_COMPONENTE], [PRO_TIPO_CUSTO], [PRO_GRUPO_CONTABIL], [EST_ORDEM], [EST_GRUPO], [EST_QUANT], [EST_VALOR_TOTAL], [EST_DATA_BASE], [EST_BASE_PRODUCAO], [EST_NIVEL], [FPR_SEQ_REPETICAO], [TenantID], [Deleted], [Changed], [UserId] FROM [EstruturaCusto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["EST_GRUPO"] = value; //06
                      whereClauses.Add($" [EST_GRUPO] = @EST_GRUPO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByEST_QUANTQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [EST_ID], [ITO_ID], [ORD_ID], [PRO_ID], [PRO_ID_PRODUTO], [PRO_ID_COMPONENTE], [PRO_TIPO_CUSTO], [PRO_GRUPO_CONTABIL], [EST_ORDEM], [EST_GRUPO], [EST_QUANT], [EST_VALOR_TOTAL], [EST_DATA_BASE], [EST_BASE_PRODUCAO], [EST_NIVEL], [FPR_SEQ_REPETICAO], [TenantID], [Deleted], [Changed], [UserId] FROM [EstruturaCusto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["EST_QUANT"] = value; //06
                      whereClauses.Add($" [EST_QUANT] = @EST_QUANT ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByEST_VALOR_TOTALQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [EST_ID], [ITO_ID], [ORD_ID], [PRO_ID], [PRO_ID_PRODUTO], [PRO_ID_COMPONENTE], [PRO_TIPO_CUSTO], [PRO_GRUPO_CONTABIL], [EST_ORDEM], [EST_GRUPO], [EST_QUANT], [EST_VALOR_TOTAL], [EST_DATA_BASE], [EST_BASE_PRODUCAO], [EST_NIVEL], [FPR_SEQ_REPETICAO], [TenantID], [Deleted], [Changed], [UserId] FROM [EstruturaCusto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["EST_VALOR_TOTAL"] = value; //06
                      whereClauses.Add($" [EST_VALOR_TOTAL] = @EST_VALOR_TOTAL ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByEST_DATA_BASEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [EST_ID], [ITO_ID], [ORD_ID], [PRO_ID], [PRO_ID_PRODUTO], [PRO_ID_COMPONENTE], [PRO_TIPO_CUSTO], [PRO_GRUPO_CONTABIL], [EST_ORDEM], [EST_GRUPO], [EST_QUANT], [EST_VALOR_TOTAL], [EST_DATA_BASE], [EST_BASE_PRODUCAO], [EST_NIVEL], [FPR_SEQ_REPETICAO], [TenantID], [Deleted], [Changed], [UserId] FROM [EstruturaCusto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["EST_DATA_BASE"] = value; //06
                      whereClauses.Add($" [EST_DATA_BASE] = @EST_DATA_BASE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByEST_BASE_PRODUCAOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [EST_ID], [ITO_ID], [ORD_ID], [PRO_ID], [PRO_ID_PRODUTO], [PRO_ID_COMPONENTE], [PRO_TIPO_CUSTO], [PRO_GRUPO_CONTABIL], [EST_ORDEM], [EST_GRUPO], [EST_QUANT], [EST_VALOR_TOTAL], [EST_DATA_BASE], [EST_BASE_PRODUCAO], [EST_NIVEL], [FPR_SEQ_REPETICAO], [TenantID], [Deleted], [Changed], [UserId] FROM [EstruturaCusto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["EST_BASE_PRODUCAO"] = value; //06
                      whereClauses.Add($" [EST_BASE_PRODUCAO] = @EST_BASE_PRODUCAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByEST_NIVELQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [EST_ID], [ITO_ID], [ORD_ID], [PRO_ID], [PRO_ID_PRODUTO], [PRO_ID_COMPONENTE], [PRO_TIPO_CUSTO], [PRO_GRUPO_CONTABIL], [EST_ORDEM], [EST_GRUPO], [EST_QUANT], [EST_VALOR_TOTAL], [EST_DATA_BASE], [EST_BASE_PRODUCAO], [EST_NIVEL], [FPR_SEQ_REPETICAO], [TenantID], [Deleted], [Changed], [UserId] FROM [EstruturaCusto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["EST_NIVEL"] = value; //06
                      whereClauses.Add($" [EST_NIVEL] = @EST_NIVEL ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_SEQ_REPETICAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [EST_ID], [ITO_ID], [ORD_ID], [PRO_ID], [PRO_ID_PRODUTO], [PRO_ID_COMPONENTE], [PRO_TIPO_CUSTO], [PRO_GRUPO_CONTABIL], [EST_ORDEM], [EST_GRUPO], [EST_QUANT], [EST_VALOR_TOTAL], [EST_DATA_BASE], [EST_BASE_PRODUCAO], [EST_NIVEL], [FPR_SEQ_REPETICAO], [TenantID], [Deleted], [Changed], [UserId] FROM [EstruturaCusto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["FPR_SEQ_REPETICAO"] = value; //06
                      whereClauses.Add($" [FPR_SEQ_REPETICAO] = @FPR_SEQ_REPETICAO ");//06
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
            this.Query = $"SELECT [EST_ID], [ITO_ID], [ORD_ID], [PRO_ID], [PRO_ID_PRODUTO], [PRO_ID_COMPONENTE], [PRO_TIPO_CUSTO], [PRO_GRUPO_CONTABIL], [EST_ORDEM], [EST_GRUPO], [EST_QUANT], [EST_VALOR_TOTAL], [EST_DATA_BASE], [EST_BASE_PRODUCAO], [EST_NIVEL], [FPR_SEQ_REPETICAO], [TenantID], [Deleted], [Changed], [UserId] FROM [EstruturaCusto] ";
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
            this.Query = $"SELECT [EST_ID], [ITO_ID], [ORD_ID], [PRO_ID], [PRO_ID_PRODUTO], [PRO_ID_COMPONENTE], [PRO_TIPO_CUSTO], [PRO_GRUPO_CONTABIL], [EST_ORDEM], [EST_GRUPO], [EST_QUANT], [EST_VALOR_TOTAL], [EST_DATA_BASE], [EST_BASE_PRODUCAO], [EST_NIVEL], [FPR_SEQ_REPETICAO], [TenantID], [Deleted], [Changed], [UserId] FROM [EstruturaCusto] ";
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
            this.Query = $"SELECT [EST_ID], [ITO_ID], [ORD_ID], [PRO_ID], [PRO_ID_PRODUTO], [PRO_ID_COMPONENTE], [PRO_TIPO_CUSTO], [PRO_GRUPO_CONTABIL], [EST_ORDEM], [EST_GRUPO], [EST_QUANT], [EST_VALOR_TOTAL], [EST_DATA_BASE], [EST_BASE_PRODUCAO], [EST_NIVEL], [FPR_SEQ_REPETICAO], [TenantID], [Deleted], [Changed], [UserId] FROM [EstruturaCusto] ";
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
            this.Query = $"SELECT [EST_ID], [ITO_ID], [ORD_ID], [PRO_ID], [PRO_ID_PRODUTO], [PRO_ID_COMPONENTE], [PRO_TIPO_CUSTO], [PRO_GRUPO_CONTABIL], [EST_ORDEM], [EST_GRUPO], [EST_QUANT], [EST_VALOR_TOTAL], [EST_DATA_BASE], [EST_BASE_PRODUCAO], [EST_NIVEL], [FPR_SEQ_REPETICAO], [TenantID], [Deleted], [Changed], [UserId] FROM [EstruturaCusto] ";
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