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
    public class TipoInspecaoVisualQueryRead : QueryBase, ITipoInspecaoVisualQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public TipoInspecaoVisualQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel TipoInspecaoVisualQuery(Command.Read.TipoInspecaoVisualReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select Id, TIV_ID, TenantID, Deleted, Changed, UserId, TIV_NOME, TIV_DESCRICAO, TIV_FECHAMENTO, TIV_AMOSTRA_ALEATORIA, TIV_N_AMOSTRAS, TIV_MEDIDA, TIV_ESPECIFICACAO, TIV_TOL_MAIS, TIV_TOL_MENOS from TipoInspecaoVisual ";
if (Command.Id.HasValue) dict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"Id = @Id");
if (Command.TIV_ID.HasValue) dict["TIV_ID"] = Command.TIV_ID.Value;
if (Command.TIV_ID.HasValue) whereClauses.Add($"TIV_ID = @TIV_ID");
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
if (Command.UserId.HasValue) dict["UserId"] = Command.UserId.Value;
if (Command.UserId.HasValue) whereClauses.Add($"UserId = @UserId");
if (!string.IsNullOrEmpty(Command.TIV_NOME)) dict["TIV_NOME"] = $"%{Command.TIV_NOME}%";
if (!string.IsNullOrEmpty(Command.TIV_NOME)) whereClauses.Add($"TIV_NOME like @TIV_NOME");
if (!string.IsNullOrEmpty(Command.TIV_DESCRICAO)) dict["TIV_DESCRICAO"] = $"%{Command.TIV_DESCRICAO}%";
if (!string.IsNullOrEmpty(Command.TIV_DESCRICAO)) whereClauses.Add($"TIV_DESCRICAO like @TIV_DESCRICAO");
if (!string.IsNullOrEmpty(Command.TIV_FECHAMENTO)) dict["TIV_FECHAMENTO"] = $"%{Command.TIV_FECHAMENTO}%";
if (!string.IsNullOrEmpty(Command.TIV_FECHAMENTO)) whereClauses.Add($"TIV_FECHAMENTO like @TIV_FECHAMENTO");
if (!string.IsNullOrEmpty(Command.TIV_AMOSTRA_ALEATORIA)) dict["TIV_AMOSTRA_ALEATORIA"] = $"%{Command.TIV_AMOSTRA_ALEATORIA}%";
if (!string.IsNullOrEmpty(Command.TIV_AMOSTRA_ALEATORIA)) whereClauses.Add($"TIV_AMOSTRA_ALEATORIA like @TIV_AMOSTRA_ALEATORIA");
if (Command.TIV_N_AMOSTRAS.HasValue) dict["TIV_N_AMOSTRAS"] = Command.TIV_N_AMOSTRAS.Value;
if (Command.TIV_N_AMOSTRAS.HasValue) whereClauses.Add($"TIV_N_AMOSTRAS = @TIV_N_AMOSTRAS");
if (!string.IsNullOrEmpty(Command.TIV_MEDIDA)) dict["TIV_MEDIDA"] = $"%{Command.TIV_MEDIDA}%";
if (!string.IsNullOrEmpty(Command.TIV_MEDIDA)) whereClauses.Add($"TIV_MEDIDA like @TIV_MEDIDA");
            if (whereClauses.Any()) 
                 this.Query += $" WHERE {string.Join(" AND ", whereClauses)}"; 
            int page = Command.Paginacao?.Page ?? 1;
            int pageSize = Command.Paginacao?.PageSize ?? 20;
            int offset = (page - 1) * pageSize;
            dict["Offset"] = offset;
            dict["PageSize"] = pageSize;
            Query += " ORDER BY Id OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel TipoInspecaoVisualTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select Id, Nome from yTenant ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["Id"] = numero; //01
                      whereClauses.Add($" Id = @Id");//01 
                 }
                 else 
                 {
                      dict["Id"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" Id like @Id ");//02
                      dict["Nome"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" Nome like @Nome ");//02
                 }
           }
 dict["Id"] = _executionContext.TenantID;
 whereClauses.Add($"Id = @Id");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel TipoInspecaoVisualUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select Id, Nome from yUser ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["Id"] = numero; //01
                      whereClauses.Add($" Id = @Id");//01 
                 }
                 else 
                 {
                      dict["Id"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" Id like @Id ");//02
                      dict["Nome"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" Nome like @Nome ");//02
                 }
           }
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
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
            this.Query = $"SELECT 1 FROM TipoInspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Id"] = value; //04
                      whereClauses.Add($" Id = @Id ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTIV_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM TipoInspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TIV_ID"] = value; //04
                      whereClauses.Add($" TIV_ID = @TIV_ID ");//04
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
            this.Query = $"SELECT 1 FROM TipoInspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TenantID"] = value; //04
                      whereClauses.Add($" TenantID = @TenantID ");//04
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
            this.Query = $"SELECT 1 FROM TipoInspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Deleted"] = value; //04
                      whereClauses.Add($" Deleted = @Deleted ");//04
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
            this.Query = $"SELECT 1 FROM TipoInspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Changed"] = value; //04
                      whereClauses.Add($" Changed = @Changed ");//04
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
            this.Query = $"SELECT 1 FROM TipoInspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["UserId"] = value; //04
                      whereClauses.Add($" UserId = @UserId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTIV_NOMEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM TipoInspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TIV_NOME"] = value; //04
                      whereClauses.Add($" TIV_NOME = @TIV_NOME ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTIV_DESCRICAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM TipoInspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TIV_DESCRICAO"] = value; //04
                      whereClauses.Add($" TIV_DESCRICAO = @TIV_DESCRICAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTIV_FECHAMENTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM TipoInspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TIV_FECHAMENTO"] = value; //04
                      whereClauses.Add($" TIV_FECHAMENTO = @TIV_FECHAMENTO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTIV_AMOSTRA_ALEATORIAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM TipoInspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TIV_AMOSTRA_ALEATORIA"] = value; //04
                      whereClauses.Add($" TIV_AMOSTRA_ALEATORIA = @TIV_AMOSTRA_ALEATORIA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTIV_N_AMOSTRASQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM TipoInspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TIV_N_AMOSTRAS"] = value; //04
                      whereClauses.Add($" TIV_N_AMOSTRAS = @TIV_N_AMOSTRAS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTIV_MEDIDAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM TipoInspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TIV_MEDIDA"] = value; //04
                      whereClauses.Add($" TIV_MEDIDA = @TIV_MEDIDA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTIV_ESPECIFICACAOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM TipoInspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TIV_ESPECIFICACAO"] = value; //04
                      whereClauses.Add($" TIV_ESPECIFICACAO = @TIV_ESPECIFICACAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTIV_TOL_MAISQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM TipoInspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TIV_TOL_MAIS"] = value; //04
                      whereClauses.Add($" TIV_TOL_MAIS = @TIV_TOL_MAIS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTIV_TOL_MENOSQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM TipoInspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TIV_TOL_MENOS"] = value; //04
                      whereClauses.Add($" TIV_TOL_MENOS = @TIV_TOL_MENOS ");//04
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
            this.Query = $"SELECT Id, TIV_ID, TenantID, Deleted, Changed, UserId, TIV_NOME, TIV_DESCRICAO, TIV_FECHAMENTO, TIV_AMOSTRA_ALEATORIA, TIV_N_AMOSTRAS, TIV_MEDIDA, TIV_ESPECIFICACAO, TIV_TOL_MAIS, TIV_TOL_MENOS FROM TipoInspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Id"] = value; //06
                      whereClauses.Add($" Id = @Id ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTIV_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, TIV_ID, TenantID, Deleted, Changed, UserId, TIV_NOME, TIV_DESCRICAO, TIV_FECHAMENTO, TIV_AMOSTRA_ALEATORIA, TIV_N_AMOSTRAS, TIV_MEDIDA, TIV_ESPECIFICACAO, TIV_TOL_MAIS, TIV_TOL_MENOS FROM TipoInspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TIV_ID"] = value; //06
                      whereClauses.Add($" TIV_ID = @TIV_ID ");//06
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
            this.Query = $"SELECT Id, TIV_ID, TenantID, Deleted, Changed, UserId, TIV_NOME, TIV_DESCRICAO, TIV_FECHAMENTO, TIV_AMOSTRA_ALEATORIA, TIV_N_AMOSTRAS, TIV_MEDIDA, TIV_ESPECIFICACAO, TIV_TOL_MAIS, TIV_TOL_MENOS FROM TipoInspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TenantID"] = value; //06
                      whereClauses.Add($" TenantID = @TenantID ");//06
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
            this.Query = $"SELECT Id, TIV_ID, TenantID, Deleted, Changed, UserId, TIV_NOME, TIV_DESCRICAO, TIV_FECHAMENTO, TIV_AMOSTRA_ALEATORIA, TIV_N_AMOSTRAS, TIV_MEDIDA, TIV_ESPECIFICACAO, TIV_TOL_MAIS, TIV_TOL_MENOS FROM TipoInspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Deleted"] = value; //06
                      whereClauses.Add($" Deleted = @Deleted ");//06
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
            this.Query = $"SELECT Id, TIV_ID, TenantID, Deleted, Changed, UserId, TIV_NOME, TIV_DESCRICAO, TIV_FECHAMENTO, TIV_AMOSTRA_ALEATORIA, TIV_N_AMOSTRAS, TIV_MEDIDA, TIV_ESPECIFICACAO, TIV_TOL_MAIS, TIV_TOL_MENOS FROM TipoInspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Changed"] = value; //06
                      whereClauses.Add($" Changed = @Changed ");//06
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
            this.Query = $"SELECT Id, TIV_ID, TenantID, Deleted, Changed, UserId, TIV_NOME, TIV_DESCRICAO, TIV_FECHAMENTO, TIV_AMOSTRA_ALEATORIA, TIV_N_AMOSTRAS, TIV_MEDIDA, TIV_ESPECIFICACAO, TIV_TOL_MAIS, TIV_TOL_MENOS FROM TipoInspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["UserId"] = value; //06
                      whereClauses.Add($" UserId = @UserId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTIV_NOMEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, TIV_ID, TenantID, Deleted, Changed, UserId, TIV_NOME, TIV_DESCRICAO, TIV_FECHAMENTO, TIV_AMOSTRA_ALEATORIA, TIV_N_AMOSTRAS, TIV_MEDIDA, TIV_ESPECIFICACAO, TIV_TOL_MAIS, TIV_TOL_MENOS FROM TipoInspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TIV_NOME"] = value; //06
                      whereClauses.Add($" TIV_NOME = @TIV_NOME ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTIV_DESCRICAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, TIV_ID, TenantID, Deleted, Changed, UserId, TIV_NOME, TIV_DESCRICAO, TIV_FECHAMENTO, TIV_AMOSTRA_ALEATORIA, TIV_N_AMOSTRAS, TIV_MEDIDA, TIV_ESPECIFICACAO, TIV_TOL_MAIS, TIV_TOL_MENOS FROM TipoInspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TIV_DESCRICAO"] = value; //06
                      whereClauses.Add($" TIV_DESCRICAO = @TIV_DESCRICAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTIV_FECHAMENTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, TIV_ID, TenantID, Deleted, Changed, UserId, TIV_NOME, TIV_DESCRICAO, TIV_FECHAMENTO, TIV_AMOSTRA_ALEATORIA, TIV_N_AMOSTRAS, TIV_MEDIDA, TIV_ESPECIFICACAO, TIV_TOL_MAIS, TIV_TOL_MENOS FROM TipoInspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TIV_FECHAMENTO"] = value; //06
                      whereClauses.Add($" TIV_FECHAMENTO = @TIV_FECHAMENTO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTIV_AMOSTRA_ALEATORIAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, TIV_ID, TenantID, Deleted, Changed, UserId, TIV_NOME, TIV_DESCRICAO, TIV_FECHAMENTO, TIV_AMOSTRA_ALEATORIA, TIV_N_AMOSTRAS, TIV_MEDIDA, TIV_ESPECIFICACAO, TIV_TOL_MAIS, TIV_TOL_MENOS FROM TipoInspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TIV_AMOSTRA_ALEATORIA"] = value; //06
                      whereClauses.Add($" TIV_AMOSTRA_ALEATORIA = @TIV_AMOSTRA_ALEATORIA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTIV_N_AMOSTRASQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, TIV_ID, TenantID, Deleted, Changed, UserId, TIV_NOME, TIV_DESCRICAO, TIV_FECHAMENTO, TIV_AMOSTRA_ALEATORIA, TIV_N_AMOSTRAS, TIV_MEDIDA, TIV_ESPECIFICACAO, TIV_TOL_MAIS, TIV_TOL_MENOS FROM TipoInspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TIV_N_AMOSTRAS"] = value; //06
                      whereClauses.Add($" TIV_N_AMOSTRAS = @TIV_N_AMOSTRAS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTIV_MEDIDAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, TIV_ID, TenantID, Deleted, Changed, UserId, TIV_NOME, TIV_DESCRICAO, TIV_FECHAMENTO, TIV_AMOSTRA_ALEATORIA, TIV_N_AMOSTRAS, TIV_MEDIDA, TIV_ESPECIFICACAO, TIV_TOL_MAIS, TIV_TOL_MENOS FROM TipoInspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TIV_MEDIDA"] = value; //06
                      whereClauses.Add($" TIV_MEDIDA = @TIV_MEDIDA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTIV_ESPECIFICACAOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, TIV_ID, TenantID, Deleted, Changed, UserId, TIV_NOME, TIV_DESCRICAO, TIV_FECHAMENTO, TIV_AMOSTRA_ALEATORIA, TIV_N_AMOSTRAS, TIV_MEDIDA, TIV_ESPECIFICACAO, TIV_TOL_MAIS, TIV_TOL_MENOS FROM TipoInspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TIV_ESPECIFICACAO"] = value; //06
                      whereClauses.Add($" TIV_ESPECIFICACAO = @TIV_ESPECIFICACAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTIV_TOL_MAISQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, TIV_ID, TenantID, Deleted, Changed, UserId, TIV_NOME, TIV_DESCRICAO, TIV_FECHAMENTO, TIV_AMOSTRA_ALEATORIA, TIV_N_AMOSTRAS, TIV_MEDIDA, TIV_ESPECIFICACAO, TIV_TOL_MAIS, TIV_TOL_MENOS FROM TipoInspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TIV_TOL_MAIS"] = value; //06
                      whereClauses.Add($" TIV_TOL_MAIS = @TIV_TOL_MAIS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTIV_TOL_MENOSQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, TIV_ID, TenantID, Deleted, Changed, UserId, TIV_NOME, TIV_DESCRICAO, TIV_FECHAMENTO, TIV_AMOSTRA_ALEATORIA, TIV_N_AMOSTRAS, TIV_MEDIDA, TIV_ESPECIFICACAO, TIV_TOL_MAIS, TIV_TOL_MENOS FROM TipoInspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TIV_TOL_MENOS"] = value; //06
                      whereClauses.Add($" TIV_TOL_MENOS = @TIV_TOL_MENOS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration