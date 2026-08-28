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
    public class GrupoSegmentoQueryRead : QueryBase, IGrupoSegmentoQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public GrupoSegmentoQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel GrupoSegmentoQuery(Command.Read.GrupoSegmentoReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select Id, GRS_ID, GRS_DESCRICAO, GRS_INTEGRACAO_ERP, TenantID, Deleted, Changed, UserId from GrupoSegmento ";
if (Command.Id.HasValue) dict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"Id = @Id");
if (!string.IsNullOrEmpty(Command.GRS_ID)) dict["GRS_ID"] = $"%{Command.GRS_ID}%";
if (!string.IsNullOrEmpty(Command.GRS_ID)) whereClauses.Add($"GRS_ID like @GRS_ID");
if (!string.IsNullOrEmpty(Command.GRS_DESCRICAO)) dict["GRS_DESCRICAO"] = $"%{Command.GRS_DESCRICAO}%";
if (!string.IsNullOrEmpty(Command.GRS_DESCRICAO)) whereClauses.Add($"GRS_DESCRICAO like @GRS_DESCRICAO");
if (!string.IsNullOrEmpty(Command.GRS_INTEGRACAO_ERP)) dict["GRS_INTEGRACAO_ERP"] = $"%{Command.GRS_INTEGRACAO_ERP}%";
if (!string.IsNullOrEmpty(Command.GRS_INTEGRACAO_ERP)) whereClauses.Add($"GRS_INTEGRACAO_ERP like @GRS_INTEGRACAO_ERP");
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
        public QueryModel GrupoSegmentoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel GrupoSegmentoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
            this.Query = $"SELECT 1 FROM GrupoSegmento ";
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
        public QueryModel ExistsByGRS_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoSegmento ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRS_ID"] = value; //04
                      whereClauses.Add($" GRS_ID = @GRS_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRS_DESCRICAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoSegmento ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRS_DESCRICAO"] = value; //04
                      whereClauses.Add($" GRS_DESCRICAO = @GRS_DESCRICAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRS_INTEGRACAO_ERPQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoSegmento ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRS_INTEGRACAO_ERP"] = value; //04
                      whereClauses.Add($" GRS_INTEGRACAO_ERP = @GRS_INTEGRACAO_ERP ");//04
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
            this.Query = $"SELECT 1 FROM GrupoSegmento ";
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
            this.Query = $"SELECT 1 FROM GrupoSegmento ";
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
            this.Query = $"SELECT 1 FROM GrupoSegmento ";
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
            this.Query = $"SELECT 1 FROM GrupoSegmento ";
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
            this.Query = $"SELECT Id, GRS_ID, GRS_DESCRICAO, GRS_INTEGRACAO_ERP, TenantID, Deleted, Changed, UserId FROM GrupoSegmento ";
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
        public QueryModel FirstByGRS_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, GRS_ID, GRS_DESCRICAO, GRS_INTEGRACAO_ERP, TenantID, Deleted, Changed, UserId FROM GrupoSegmento ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRS_ID"] = value; //06
                      whereClauses.Add($" GRS_ID = @GRS_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRS_DESCRICAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, GRS_ID, GRS_DESCRICAO, GRS_INTEGRACAO_ERP, TenantID, Deleted, Changed, UserId FROM GrupoSegmento ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRS_DESCRICAO"] = value; //06
                      whereClauses.Add($" GRS_DESCRICAO = @GRS_DESCRICAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRS_INTEGRACAO_ERPQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, GRS_ID, GRS_DESCRICAO, GRS_INTEGRACAO_ERP, TenantID, Deleted, Changed, UserId FROM GrupoSegmento ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRS_INTEGRACAO_ERP"] = value; //06
                      whereClauses.Add($" GRS_INTEGRACAO_ERP = @GRS_INTEGRACAO_ERP ");//06
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
            this.Query = $"SELECT Id, GRS_ID, GRS_DESCRICAO, GRS_INTEGRACAO_ERP, TenantID, Deleted, Changed, UserId FROM GrupoSegmento ";
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
            this.Query = $"SELECT Id, GRS_ID, GRS_DESCRICAO, GRS_INTEGRACAO_ERP, TenantID, Deleted, Changed, UserId FROM GrupoSegmento ";
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
            this.Query = $"SELECT Id, GRS_ID, GRS_DESCRICAO, GRS_INTEGRACAO_ERP, TenantID, Deleted, Changed, UserId FROM GrupoSegmento ";
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
            this.Query = $"SELECT Id, GRS_ID, GRS_DESCRICAO, GRS_INTEGRACAO_ERP, TenantID, Deleted, Changed, UserId FROM GrupoSegmento ";
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