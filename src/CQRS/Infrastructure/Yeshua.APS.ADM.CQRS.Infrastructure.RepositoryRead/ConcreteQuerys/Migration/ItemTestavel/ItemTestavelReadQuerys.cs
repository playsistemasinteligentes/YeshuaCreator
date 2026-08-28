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
    public class ItemTestavelQueryRead : QueryBase, IItemTestavelQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public ItemTestavelQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel ItemTestavelQuery(Command.Read.ItemTestavelReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select Id, ITE_ID, ITE_DESCRICAO, ITE_OBS, ITE_NUMERO_DE_TESTES, ITE_CONDICIONAL_DE_AVALIACAO, ITE_VALOR_DA_CONDICIONAL, ITE_VALOR_CALCULADO_DA_CONDICIONAL, ITE_TIPO_AVALIACAO_FINAL, TenantID, Deleted, Changed, UserId from ItemTestavel ";
if (Command.Id.HasValue) dict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"Id = @Id");
if (Command.ITE_ID.HasValue) dict["ITE_ID"] = Command.ITE_ID.Value;
if (Command.ITE_ID.HasValue) whereClauses.Add($"ITE_ID = @ITE_ID");
if (!string.IsNullOrEmpty(Command.ITE_DESCRICAO)) dict["ITE_DESCRICAO"] = $"%{Command.ITE_DESCRICAO}%";
if (!string.IsNullOrEmpty(Command.ITE_DESCRICAO)) whereClauses.Add($"ITE_DESCRICAO like @ITE_DESCRICAO");
if (!string.IsNullOrEmpty(Command.ITE_OBS)) dict["ITE_OBS"] = $"%{Command.ITE_OBS}%";
if (!string.IsNullOrEmpty(Command.ITE_OBS)) whereClauses.Add($"ITE_OBS like @ITE_OBS");
if (Command.ITE_NUMERO_DE_TESTES.HasValue) dict["ITE_NUMERO_DE_TESTES"] = Command.ITE_NUMERO_DE_TESTES.Value;
if (Command.ITE_NUMERO_DE_TESTES.HasValue) whereClauses.Add($"ITE_NUMERO_DE_TESTES = @ITE_NUMERO_DE_TESTES");
if (!string.IsNullOrEmpty(Command.ITE_CONDICIONAL_DE_AVALIACAO)) dict["ITE_CONDICIONAL_DE_AVALIACAO"] = $"%{Command.ITE_CONDICIONAL_DE_AVALIACAO}%";
if (!string.IsNullOrEmpty(Command.ITE_CONDICIONAL_DE_AVALIACAO)) whereClauses.Add($"ITE_CONDICIONAL_DE_AVALIACAO like @ITE_CONDICIONAL_DE_AVALIACAO");
if (!string.IsNullOrEmpty(Command.ITE_VALOR_CALCULADO_DA_CONDICIONAL)) dict["ITE_VALOR_CALCULADO_DA_CONDICIONAL"] = $"%{Command.ITE_VALOR_CALCULADO_DA_CONDICIONAL}%";
if (!string.IsNullOrEmpty(Command.ITE_VALOR_CALCULADO_DA_CONDICIONAL)) whereClauses.Add($"ITE_VALOR_CALCULADO_DA_CONDICIONAL like @ITE_VALOR_CALCULADO_DA_CONDICIONAL");
if (!string.IsNullOrEmpty(Command.ITE_TIPO_AVALIACAO_FINAL)) dict["ITE_TIPO_AVALIACAO_FINAL"] = $"%{Command.ITE_TIPO_AVALIACAO_FINAL}%";
if (!string.IsNullOrEmpty(Command.ITE_TIPO_AVALIACAO_FINAL)) whereClauses.Add($"ITE_TIPO_AVALIACAO_FINAL like @ITE_TIPO_AVALIACAO_FINAL");
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
if (Command.UserId.HasValue) dict["UserId"] = Command.UserId.Value;
if (Command.UserId.HasValue) whereClauses.Add($"UserId = @UserId");
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
        public QueryModel ItemTestavelTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel ItemTestavelUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
            this.Query = $"SELECT 1 FROM ItemTestavel ";
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
        public QueryModel ExistsByITE_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM ItemTestavel ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ITE_ID"] = value; //04
                      whereClauses.Add($" ITE_ID = @ITE_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByITE_DESCRICAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM ItemTestavel ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ITE_DESCRICAO"] = value; //04
                      whereClauses.Add($" ITE_DESCRICAO = @ITE_DESCRICAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByITE_OBSQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM ItemTestavel ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ITE_OBS"] = value; //04
                      whereClauses.Add($" ITE_OBS = @ITE_OBS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByITE_NUMERO_DE_TESTESQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM ItemTestavel ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ITE_NUMERO_DE_TESTES"] = value; //04
                      whereClauses.Add($" ITE_NUMERO_DE_TESTES = @ITE_NUMERO_DE_TESTES ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByITE_CONDICIONAL_DE_AVALIACAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM ItemTestavel ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ITE_CONDICIONAL_DE_AVALIACAO"] = value; //04
                      whereClauses.Add($" ITE_CONDICIONAL_DE_AVALIACAO = @ITE_CONDICIONAL_DE_AVALIACAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByITE_VALOR_DA_CONDICIONALQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM ItemTestavel ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ITE_VALOR_DA_CONDICIONAL"] = value; //04
                      whereClauses.Add($" ITE_VALOR_DA_CONDICIONAL = @ITE_VALOR_DA_CONDICIONAL ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByITE_VALOR_CALCULADO_DA_CONDICIONALQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM ItemTestavel ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ITE_VALOR_CALCULADO_DA_CONDICIONAL"] = value; //04
                      whereClauses.Add($" ITE_VALOR_CALCULADO_DA_CONDICIONAL = @ITE_VALOR_CALCULADO_DA_CONDICIONAL ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByITE_TIPO_AVALIACAO_FINALQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM ItemTestavel ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ITE_TIPO_AVALIACAO_FINAL"] = value; //04
                      whereClauses.Add($" ITE_TIPO_AVALIACAO_FINAL = @ITE_TIPO_AVALIACAO_FINAL ");//04
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
            this.Query = $"SELECT 1 FROM ItemTestavel ";
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
            this.Query = $"SELECT 1 FROM ItemTestavel ";
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
            this.Query = $"SELECT 1 FROM ItemTestavel ";
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
            this.Query = $"SELECT 1 FROM ItemTestavel ";
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
        public QueryModel FirstByIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ITE_ID, ITE_DESCRICAO, ITE_OBS, ITE_NUMERO_DE_TESTES, ITE_CONDICIONAL_DE_AVALIACAO, ITE_VALOR_DA_CONDICIONAL, ITE_VALOR_CALCULADO_DA_CONDICIONAL, ITE_TIPO_AVALIACAO_FINAL, TenantID, Deleted, Changed, UserId FROM ItemTestavel ";
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
        public QueryModel FirstByITE_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ITE_ID, ITE_DESCRICAO, ITE_OBS, ITE_NUMERO_DE_TESTES, ITE_CONDICIONAL_DE_AVALIACAO, ITE_VALOR_DA_CONDICIONAL, ITE_VALOR_CALCULADO_DA_CONDICIONAL, ITE_TIPO_AVALIACAO_FINAL, TenantID, Deleted, Changed, UserId FROM ItemTestavel ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ITE_ID"] = value; //06
                      whereClauses.Add($" ITE_ID = @ITE_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByITE_DESCRICAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ITE_ID, ITE_DESCRICAO, ITE_OBS, ITE_NUMERO_DE_TESTES, ITE_CONDICIONAL_DE_AVALIACAO, ITE_VALOR_DA_CONDICIONAL, ITE_VALOR_CALCULADO_DA_CONDICIONAL, ITE_TIPO_AVALIACAO_FINAL, TenantID, Deleted, Changed, UserId FROM ItemTestavel ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ITE_DESCRICAO"] = value; //06
                      whereClauses.Add($" ITE_DESCRICAO = @ITE_DESCRICAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByITE_OBSQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ITE_ID, ITE_DESCRICAO, ITE_OBS, ITE_NUMERO_DE_TESTES, ITE_CONDICIONAL_DE_AVALIACAO, ITE_VALOR_DA_CONDICIONAL, ITE_VALOR_CALCULADO_DA_CONDICIONAL, ITE_TIPO_AVALIACAO_FINAL, TenantID, Deleted, Changed, UserId FROM ItemTestavel ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ITE_OBS"] = value; //06
                      whereClauses.Add($" ITE_OBS = @ITE_OBS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByITE_NUMERO_DE_TESTESQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ITE_ID, ITE_DESCRICAO, ITE_OBS, ITE_NUMERO_DE_TESTES, ITE_CONDICIONAL_DE_AVALIACAO, ITE_VALOR_DA_CONDICIONAL, ITE_VALOR_CALCULADO_DA_CONDICIONAL, ITE_TIPO_AVALIACAO_FINAL, TenantID, Deleted, Changed, UserId FROM ItemTestavel ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ITE_NUMERO_DE_TESTES"] = value; //06
                      whereClauses.Add($" ITE_NUMERO_DE_TESTES = @ITE_NUMERO_DE_TESTES ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByITE_CONDICIONAL_DE_AVALIACAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ITE_ID, ITE_DESCRICAO, ITE_OBS, ITE_NUMERO_DE_TESTES, ITE_CONDICIONAL_DE_AVALIACAO, ITE_VALOR_DA_CONDICIONAL, ITE_VALOR_CALCULADO_DA_CONDICIONAL, ITE_TIPO_AVALIACAO_FINAL, TenantID, Deleted, Changed, UserId FROM ItemTestavel ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ITE_CONDICIONAL_DE_AVALIACAO"] = value; //06
                      whereClauses.Add($" ITE_CONDICIONAL_DE_AVALIACAO = @ITE_CONDICIONAL_DE_AVALIACAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByITE_VALOR_DA_CONDICIONALQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ITE_ID, ITE_DESCRICAO, ITE_OBS, ITE_NUMERO_DE_TESTES, ITE_CONDICIONAL_DE_AVALIACAO, ITE_VALOR_DA_CONDICIONAL, ITE_VALOR_CALCULADO_DA_CONDICIONAL, ITE_TIPO_AVALIACAO_FINAL, TenantID, Deleted, Changed, UserId FROM ItemTestavel ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ITE_VALOR_DA_CONDICIONAL"] = value; //06
                      whereClauses.Add($" ITE_VALOR_DA_CONDICIONAL = @ITE_VALOR_DA_CONDICIONAL ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByITE_VALOR_CALCULADO_DA_CONDICIONALQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ITE_ID, ITE_DESCRICAO, ITE_OBS, ITE_NUMERO_DE_TESTES, ITE_CONDICIONAL_DE_AVALIACAO, ITE_VALOR_DA_CONDICIONAL, ITE_VALOR_CALCULADO_DA_CONDICIONAL, ITE_TIPO_AVALIACAO_FINAL, TenantID, Deleted, Changed, UserId FROM ItemTestavel ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ITE_VALOR_CALCULADO_DA_CONDICIONAL"] = value; //06
                      whereClauses.Add($" ITE_VALOR_CALCULADO_DA_CONDICIONAL = @ITE_VALOR_CALCULADO_DA_CONDICIONAL ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByITE_TIPO_AVALIACAO_FINALQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ITE_ID, ITE_DESCRICAO, ITE_OBS, ITE_NUMERO_DE_TESTES, ITE_CONDICIONAL_DE_AVALIACAO, ITE_VALOR_DA_CONDICIONAL, ITE_VALOR_CALCULADO_DA_CONDICIONAL, ITE_TIPO_AVALIACAO_FINAL, TenantID, Deleted, Changed, UserId FROM ItemTestavel ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ITE_TIPO_AVALIACAO_FINAL"] = value; //06
                      whereClauses.Add($" ITE_TIPO_AVALIACAO_FINAL = @ITE_TIPO_AVALIACAO_FINAL ");//06
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
            this.Query = $"SELECT Id, ITE_ID, ITE_DESCRICAO, ITE_OBS, ITE_NUMERO_DE_TESTES, ITE_CONDICIONAL_DE_AVALIACAO, ITE_VALOR_DA_CONDICIONAL, ITE_VALOR_CALCULADO_DA_CONDICIONAL, ITE_TIPO_AVALIACAO_FINAL, TenantID, Deleted, Changed, UserId FROM ItemTestavel ";
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
            this.Query = $"SELECT Id, ITE_ID, ITE_DESCRICAO, ITE_OBS, ITE_NUMERO_DE_TESTES, ITE_CONDICIONAL_DE_AVALIACAO, ITE_VALOR_DA_CONDICIONAL, ITE_VALOR_CALCULADO_DA_CONDICIONAL, ITE_TIPO_AVALIACAO_FINAL, TenantID, Deleted, Changed, UserId FROM ItemTestavel ";
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
            this.Query = $"SELECT Id, ITE_ID, ITE_DESCRICAO, ITE_OBS, ITE_NUMERO_DE_TESTES, ITE_CONDICIONAL_DE_AVALIACAO, ITE_VALOR_DA_CONDICIONAL, ITE_VALOR_CALCULADO_DA_CONDICIONAL, ITE_TIPO_AVALIACAO_FINAL, TenantID, Deleted, Changed, UserId FROM ItemTestavel ";
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
            this.Query = $"SELECT Id, ITE_ID, ITE_DESCRICAO, ITE_OBS, ITE_NUMERO_DE_TESTES, ITE_CONDICIONAL_DE_AVALIACAO, ITE_VALOR_DA_CONDICIONAL, ITE_VALOR_CALCULADO_DA_CONDICIONAL, ITE_TIPO_AVALIACAO_FINAL, TenantID, Deleted, Changed, UserId FROM ItemTestavel ";
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
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration