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
    public class yTokenQueryRead : QueryBase, IyTokenQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public yTokenQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel yTokenQuery(Command.Read.yTokenReadCommand Command , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select [Id], [TokenHash], [Description], [ConnectorKey], [Active], [ValidUntil], [CreatedAt], [LastUsedAt], [TenantID], [UserId], [Deleted], [Changed] from [yToken] ";
if (Command.Id.HasValue) dict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"[Id] = @Id");
if (!string.IsNullOrEmpty(Command.TokenHash)) dict["TokenHash"] = $"%{Command.TokenHash}%";
if (!string.IsNullOrEmpty(Command.TokenHash)) whereClauses.Add($"[TokenHash] like @TokenHash");
if (!string.IsNullOrEmpty(Command.Description)) dict["Description"] = $"%{Command.Description}%";
if (!string.IsNullOrEmpty(Command.Description)) whereClauses.Add($"[Description] like @Description");
if (!string.IsNullOrEmpty(Command.ConnectorKey)) dict["ConnectorKey"] = $"%{Command.ConnectorKey}%";
if (!string.IsNullOrEmpty(Command.ConnectorKey)) whereClauses.Add($"[ConnectorKey] like @ConnectorKey");
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
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
        public QueryModel yTokenTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command , bool TakeOffTenantID = false)
        {
            this.Query = $@" select [Id], [Nome] from [yTenant] ";
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
        public QueryModel yTokenUserIdQuery(Command.Patterns.Command.SearchFKCommand Command , bool TakeOffTenantID = false)
        {
            this.Query = $@" select [Id], [Nome] from [yUser] ";
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
        public QueryModel ExistsByIdQuery(int value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [yToken] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Id"] = value; //04
                      whereClauses.Add($" [Id] = @Id ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTokenHashQuery(string value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [yToken] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TokenHash"] = value; //04
                      whereClauses.Add($" [TokenHash] = @TokenHash ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByDescriptionQuery(string value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [yToken] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Description"] = value; //04
                      whereClauses.Add($" [Description] = @Description ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByConnectorKeyQuery(string value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [yToken] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ConnectorKey"] = value; //04
                      whereClauses.Add($" [ConnectorKey] = @ConnectorKey ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByActiveQuery(bool value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [yToken] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Active"] = value; //04
                      whereClauses.Add($" [Active] = @Active ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByValidUntilQuery(DateTime value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [yToken] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ValidUntil"] = value; //04
                      whereClauses.Add($" [ValidUntil] = @ValidUntil ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCreatedAtQuery(DateTime value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [yToken] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CreatedAt"] = value; //04
                      whereClauses.Add($" [CreatedAt] = @CreatedAt ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByLastUsedAtQuery(DateTime value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [yToken] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["LastUsedAt"] = value; //04
                      whereClauses.Add($" [LastUsedAt] = @LastUsedAt ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTenantIDQuery(int value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [yToken] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TenantID"] = value; //04
                      whereClauses.Add($" [TenantID] = @TenantID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByUserIdQuery(int value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [yToken] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["UserId"] = value; //04
                      whereClauses.Add($" [UserId] = @UserId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByDeletedQuery(bool value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [yToken] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Deleted"] = value; //04
                      whereClauses.Add($" [Deleted] = @Deleted ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByChangedQuery(DateTime value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [yToken] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Changed"] = value; //04
                      whereClauses.Add($" [Changed] = @Changed ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByIdQuery(int value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TokenHash], [Description], [ConnectorKey], [Active], [ValidUntil], [CreatedAt], [LastUsedAt], [TenantID], [UserId], [Deleted], [Changed] FROM [yToken] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Id"] = value; //06
                      whereClauses.Add($" [Id] = @Id ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTokenHashQuery(string value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TokenHash], [Description], [ConnectorKey], [Active], [ValidUntil], [CreatedAt], [LastUsedAt], [TenantID], [UserId], [Deleted], [Changed] FROM [yToken] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TokenHash"] = value; //06
                      whereClauses.Add($" [TokenHash] = @TokenHash ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByDescriptionQuery(string value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TokenHash], [Description], [ConnectorKey], [Active], [ValidUntil], [CreatedAt], [LastUsedAt], [TenantID], [UserId], [Deleted], [Changed] FROM [yToken] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Description"] = value; //06
                      whereClauses.Add($" [Description] = @Description ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByConnectorKeyQuery(string value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TokenHash], [Description], [ConnectorKey], [Active], [ValidUntil], [CreatedAt], [LastUsedAt], [TenantID], [UserId], [Deleted], [Changed] FROM [yToken] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ConnectorKey"] = value; //06
                      whereClauses.Add($" [ConnectorKey] = @ConnectorKey ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByActiveQuery(bool value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TokenHash], [Description], [ConnectorKey], [Active], [ValidUntil], [CreatedAt], [LastUsedAt], [TenantID], [UserId], [Deleted], [Changed] FROM [yToken] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Active"] = value; //06
                      whereClauses.Add($" [Active] = @Active ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByValidUntilQuery(DateTime value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TokenHash], [Description], [ConnectorKey], [Active], [ValidUntil], [CreatedAt], [LastUsedAt], [TenantID], [UserId], [Deleted], [Changed] FROM [yToken] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ValidUntil"] = value; //06
                      whereClauses.Add($" [ValidUntil] = @ValidUntil ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCreatedAtQuery(DateTime value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TokenHash], [Description], [ConnectorKey], [Active], [ValidUntil], [CreatedAt], [LastUsedAt], [TenantID], [UserId], [Deleted], [Changed] FROM [yToken] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CreatedAt"] = value; //06
                      whereClauses.Add($" [CreatedAt] = @CreatedAt ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByLastUsedAtQuery(DateTime value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TokenHash], [Description], [ConnectorKey], [Active], [ValidUntil], [CreatedAt], [LastUsedAt], [TenantID], [UserId], [Deleted], [Changed] FROM [yToken] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["LastUsedAt"] = value; //06
                      whereClauses.Add($" [LastUsedAt] = @LastUsedAt ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTenantIDQuery(int value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TokenHash], [Description], [ConnectorKey], [Active], [ValidUntil], [CreatedAt], [LastUsedAt], [TenantID], [UserId], [Deleted], [Changed] FROM [yToken] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TenantID"] = value; //06
                      whereClauses.Add($" [TenantID] = @TenantID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByUserIdQuery(int value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TokenHash], [Description], [ConnectorKey], [Active], [ValidUntil], [CreatedAt], [LastUsedAt], [TenantID], [UserId], [Deleted], [Changed] FROM [yToken] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["UserId"] = value; //06
                      whereClauses.Add($" [UserId] = @UserId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByDeletedQuery(bool value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TokenHash], [Description], [ConnectorKey], [Active], [ValidUntil], [CreatedAt], [LastUsedAt], [TenantID], [UserId], [Deleted], [Changed] FROM [yToken] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Deleted"] = value; //06
                      whereClauses.Add($" [Deleted] = @Deleted ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByChangedQuery(DateTime value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [TokenHash], [Description], [ConnectorKey], [Active], [ValidUntil], [CreatedAt], [LastUsedAt], [TenantID], [UserId], [Deleted], [Changed] FROM [yToken] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
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