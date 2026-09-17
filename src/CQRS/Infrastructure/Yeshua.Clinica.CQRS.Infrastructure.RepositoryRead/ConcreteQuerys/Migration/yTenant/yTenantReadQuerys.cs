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
    public class yTenantQueryRead : QueryBase, IyTenantQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public yTenantQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel yTenantQuery(Command.Read.yTenantReadCommand Command , bool TakeOffId = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select [Id], [CnpjCpf], [Nome], [UserId], [Deleted], [Changed] from [yTenant] ";
if (!TakeOffId)  dict["Id"] = _executionContext.TenantID;
if (!TakeOffId)  whereClauses.Add($"[Id] = @Id");
if (!string.IsNullOrEmpty(Command.CnpjCpf)) dict["CnpjCpf"] = $"%{Command.CnpjCpf}%";
if (!string.IsNullOrEmpty(Command.CnpjCpf)) whereClauses.Add($"[CnpjCpf] like @CnpjCpf");
if (!string.IsNullOrEmpty(Command.Nome)) dict["Nome"] = $"%{Command.Nome}%";
if (!string.IsNullOrEmpty(Command.Nome)) whereClauses.Add($"[Nome] like @Nome");
if (Command.UserId.HasValue) dict["UserId"] = Command.UserId.Value;
if (Command.UserId.HasValue) whereClauses.Add($"[UserId] = @UserId");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
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
        public QueryModel ExistsByIdQuery(int value , bool TakeOffId = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [yTenant] ";
if (!TakeOffId)  dict["Id"] = _executionContext.TenantID;
if (!TakeOffId)  whereClauses.Add($"[Id] = @Id");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Id"] = value; //04
                      whereClauses.Add($" [Id] = @Id ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCnpjCpfQuery(string value , bool TakeOffId = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [yTenant] ";
if (!TakeOffId)  dict["Id"] = _executionContext.TenantID;
if (!TakeOffId)  whereClauses.Add($"[Id] = @Id");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CnpjCpf"] = value; //04
                      whereClauses.Add($" [CnpjCpf] = @CnpjCpf ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByNomeQuery(string value , bool TakeOffId = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [yTenant] ";
if (!TakeOffId)  dict["Id"] = _executionContext.TenantID;
if (!TakeOffId)  whereClauses.Add($"[Id] = @Id");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Nome"] = value; //04
                      whereClauses.Add($" [Nome] = @Nome ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByUserIdQuery(int value , bool TakeOffId = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [yTenant] ";
if (!TakeOffId)  dict["Id"] = _executionContext.TenantID;
if (!TakeOffId)  whereClauses.Add($"[Id] = @Id");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["UserId"] = value; //04
                      whereClauses.Add($" [UserId] = @UserId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByDeletedQuery(bool value , bool TakeOffId = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [yTenant] ";
if (!TakeOffId)  dict["Id"] = _executionContext.TenantID;
if (!TakeOffId)  whereClauses.Add($"[Id] = @Id");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Deleted"] = value; //04
                      whereClauses.Add($" [Deleted] = @Deleted ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByChangedQuery(DateTime value , bool TakeOffId = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [yTenant] ";
if (!TakeOffId)  dict["Id"] = _executionContext.TenantID;
if (!TakeOffId)  whereClauses.Add($"[Id] = @Id");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Changed"] = value; //04
                      whereClauses.Add($" [Changed] = @Changed ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByIdQuery(int value , bool TakeOffId = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CnpjCpf], [Nome], [UserId], [Deleted], [Changed] FROM [yTenant] ";
if (!TakeOffId)  dict["Id"] = _executionContext.TenantID;
if (!TakeOffId)  whereClauses.Add($"[Id] = @Id");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Id"] = value; //06
                      whereClauses.Add($" [Id] = @Id ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCnpjCpfQuery(string value , bool TakeOffId = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CnpjCpf], [Nome], [UserId], [Deleted], [Changed] FROM [yTenant] ";
if (!TakeOffId)  dict["Id"] = _executionContext.TenantID;
if (!TakeOffId)  whereClauses.Add($"[Id] = @Id");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CnpjCpf"] = value; //06
                      whereClauses.Add($" [CnpjCpf] = @CnpjCpf ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByNomeQuery(string value , bool TakeOffId = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CnpjCpf], [Nome], [UserId], [Deleted], [Changed] FROM [yTenant] ";
if (!TakeOffId)  dict["Id"] = _executionContext.TenantID;
if (!TakeOffId)  whereClauses.Add($"[Id] = @Id");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Nome"] = value; //06
                      whereClauses.Add($" [Nome] = @Nome ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByUserIdQuery(int value , bool TakeOffId = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CnpjCpf], [Nome], [UserId], [Deleted], [Changed] FROM [yTenant] ";
if (!TakeOffId)  dict["Id"] = _executionContext.TenantID;
if (!TakeOffId)  whereClauses.Add($"[Id] = @Id");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["UserId"] = value; //06
                      whereClauses.Add($" [UserId] = @UserId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByDeletedQuery(bool value , bool TakeOffId = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CnpjCpf], [Nome], [UserId], [Deleted], [Changed] FROM [yTenant] ";
if (!TakeOffId)  dict["Id"] = _executionContext.TenantID;
if (!TakeOffId)  whereClauses.Add($"[Id] = @Id");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Deleted"] = value; //06
                      whereClauses.Add($" [Deleted] = @Deleted ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByChangedQuery(DateTime value , bool TakeOffId = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [CnpjCpf], [Nome], [UserId], [Deleted], [Changed] FROM [yTenant] ";
if (!TakeOffId)  dict["Id"] = _executionContext.TenantID;
if (!TakeOffId)  whereClauses.Add($"[Id] = @Id");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Changed"] = value; //06
                      whereClauses.Add($" [Changed] = @Changed ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration