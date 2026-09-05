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
    public class LogsDatabaseQueryRead : QueryBase, ILogsDatabaseQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public LogsDatabaseQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel LogsDatabaseQuery(Command.Read.LogsDatabaseReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select [LOGS_ID], [LOGS_TABLE], [LOGS_KEY], [LOGS_KEY1], [LOGS_KEY2], [LOGS_KEY3], [LOGS_KEY4], [LOGS_COLUMN], [LOGS_BEFORE], [LOGS_AFTER], [LOGS_ACTION], [LOGS_DATE], [USE_ID], [LOGS_ORIGEM], [TenantID], [Deleted], [Changed], [UserId] from [LogsDatabase] ";
if (Command.LOGS_ID.HasValue) dict["LOGS_ID"] = Command.LOGS_ID.Value;
if (Command.LOGS_ID.HasValue) whereClauses.Add($"[LOGS_ID] = @LOGS_ID");
if (!string.IsNullOrEmpty(Command.LOGS_TABLE)) dict["LOGS_TABLE"] = $"%{Command.LOGS_TABLE}%";
if (!string.IsNullOrEmpty(Command.LOGS_TABLE)) whereClauses.Add($"[LOGS_TABLE] like @LOGS_TABLE");
if (!string.IsNullOrEmpty(Command.LOGS_KEY)) dict["LOGS_KEY"] = $"%{Command.LOGS_KEY}%";
if (!string.IsNullOrEmpty(Command.LOGS_KEY)) whereClauses.Add($"[LOGS_KEY] like @LOGS_KEY");
if (!string.IsNullOrEmpty(Command.LOGS_KEY1)) dict["LOGS_KEY1"] = $"%{Command.LOGS_KEY1}%";
if (!string.IsNullOrEmpty(Command.LOGS_KEY1)) whereClauses.Add($"[LOGS_KEY1] like @LOGS_KEY1");
if (!string.IsNullOrEmpty(Command.LOGS_KEY2)) dict["LOGS_KEY2"] = $"%{Command.LOGS_KEY2}%";
if (!string.IsNullOrEmpty(Command.LOGS_KEY2)) whereClauses.Add($"[LOGS_KEY2] like @LOGS_KEY2");
if (!string.IsNullOrEmpty(Command.LOGS_KEY3)) dict["LOGS_KEY3"] = $"%{Command.LOGS_KEY3}%";
if (!string.IsNullOrEmpty(Command.LOGS_KEY3)) whereClauses.Add($"[LOGS_KEY3] like @LOGS_KEY3");
if (!string.IsNullOrEmpty(Command.LOGS_KEY4)) dict["LOGS_KEY4"] = $"%{Command.LOGS_KEY4}%";
if (!string.IsNullOrEmpty(Command.LOGS_KEY4)) whereClauses.Add($"[LOGS_KEY4] like @LOGS_KEY4");
if (!string.IsNullOrEmpty(Command.LOGS_COLUMN)) dict["LOGS_COLUMN"] = $"%{Command.LOGS_COLUMN}%";
if (!string.IsNullOrEmpty(Command.LOGS_COLUMN)) whereClauses.Add($"[LOGS_COLUMN] like @LOGS_COLUMN");
if (!string.IsNullOrEmpty(Command.LOGS_BEFORE)) dict["LOGS_BEFORE"] = $"%{Command.LOGS_BEFORE}%";
if (!string.IsNullOrEmpty(Command.LOGS_BEFORE)) whereClauses.Add($"[LOGS_BEFORE] like @LOGS_BEFORE");
if (!string.IsNullOrEmpty(Command.LOGS_AFTER)) dict["LOGS_AFTER"] = $"%{Command.LOGS_AFTER}%";
if (!string.IsNullOrEmpty(Command.LOGS_AFTER)) whereClauses.Add($"[LOGS_AFTER] like @LOGS_AFTER");
if (!string.IsNullOrEmpty(Command.LOGS_ACTION)) dict["LOGS_ACTION"] = $"%{Command.LOGS_ACTION}%";
if (!string.IsNullOrEmpty(Command.LOGS_ACTION)) whereClauses.Add($"[LOGS_ACTION] like @LOGS_ACTION");
if (Command.USE_ID.HasValue) dict["USE_ID"] = Command.USE_ID.Value;
if (Command.USE_ID.HasValue) whereClauses.Add($"[USE_ID] = @USE_ID");
if (!string.IsNullOrEmpty(Command.LOGS_ORIGEM)) dict["LOGS_ORIGEM"] = $"%{Command.LOGS_ORIGEM}%";
if (!string.IsNullOrEmpty(Command.LOGS_ORIGEM)) whereClauses.Add($"[LOGS_ORIGEM] like @LOGS_ORIGEM");
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
            Query += " ORDER BY [LOGS_ID] OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel LogsDatabaseUSE_IDQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select [USE_ID] from [Usuario] ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["USE_ID"] = numero; //01
                      whereClauses.Add($" [USE_ID] = @USE_ID");//01 
                 }
                 else 
                 {
                      dict["USE_ID"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" [USE_ID] like @USE_ID ");//02
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
        public QueryModel LogsDatabaseTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel LogsDatabaseUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel ExistsByLOGS_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [LogsDatabase] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["LOGS_ID"] = value; //04
                      whereClauses.Add($" [LOGS_ID] = @LOGS_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByLOGS_TABLEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [LogsDatabase] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["LOGS_TABLE"] = value; //04
                      whereClauses.Add($" [LOGS_TABLE] = @LOGS_TABLE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByLOGS_KEYQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [LogsDatabase] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["LOGS_KEY"] = value; //04
                      whereClauses.Add($" [LOGS_KEY] = @LOGS_KEY ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByLOGS_KEY1Query(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [LogsDatabase] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["LOGS_KEY1"] = value; //04
                      whereClauses.Add($" [LOGS_KEY1] = @LOGS_KEY1 ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByLOGS_KEY2Query(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [LogsDatabase] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["LOGS_KEY2"] = value; //04
                      whereClauses.Add($" [LOGS_KEY2] = @LOGS_KEY2 ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByLOGS_KEY3Query(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [LogsDatabase] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["LOGS_KEY3"] = value; //04
                      whereClauses.Add($" [LOGS_KEY3] = @LOGS_KEY3 ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByLOGS_KEY4Query(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [LogsDatabase] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["LOGS_KEY4"] = value; //04
                      whereClauses.Add($" [LOGS_KEY4] = @LOGS_KEY4 ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByLOGS_COLUMNQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [LogsDatabase] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["LOGS_COLUMN"] = value; //04
                      whereClauses.Add($" [LOGS_COLUMN] = @LOGS_COLUMN ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByLOGS_BEFOREQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [LogsDatabase] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["LOGS_BEFORE"] = value; //04
                      whereClauses.Add($" [LOGS_BEFORE] = @LOGS_BEFORE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByLOGS_AFTERQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [LogsDatabase] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["LOGS_AFTER"] = value; //04
                      whereClauses.Add($" [LOGS_AFTER] = @LOGS_AFTER ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByLOGS_ACTIONQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [LogsDatabase] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["LOGS_ACTION"] = value; //04
                      whereClauses.Add($" [LOGS_ACTION] = @LOGS_ACTION ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByLOGS_DATEQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [LogsDatabase] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["LOGS_DATE"] = value; //04
                      whereClauses.Add($" [LOGS_DATE] = @LOGS_DATE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByUSE_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [LogsDatabase] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["USE_ID"] = value; //04
                      whereClauses.Add($" [USE_ID] = @USE_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByLOGS_ORIGEMQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [LogsDatabase] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["LOGS_ORIGEM"] = value; //04
                      whereClauses.Add($" [LOGS_ORIGEM] = @LOGS_ORIGEM ");//04
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
            this.Query = $"SELECT 1 FROM [LogsDatabase] ";
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
            this.Query = $"SELECT 1 FROM [LogsDatabase] ";
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
            this.Query = $"SELECT 1 FROM [LogsDatabase] ";
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
            this.Query = $"SELECT 1 FROM [LogsDatabase] ";
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
        public QueryModel FirstByLOGS_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [LOGS_ID], [LOGS_TABLE], [LOGS_KEY], [LOGS_KEY1], [LOGS_KEY2], [LOGS_KEY3], [LOGS_KEY4], [LOGS_COLUMN], [LOGS_BEFORE], [LOGS_AFTER], [LOGS_ACTION], [LOGS_DATE], [USE_ID], [LOGS_ORIGEM], [TenantID], [Deleted], [Changed], [UserId] FROM [LogsDatabase] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["LOGS_ID"] = value; //06
                      whereClauses.Add($" [LOGS_ID] = @LOGS_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByLOGS_TABLEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [LOGS_ID], [LOGS_TABLE], [LOGS_KEY], [LOGS_KEY1], [LOGS_KEY2], [LOGS_KEY3], [LOGS_KEY4], [LOGS_COLUMN], [LOGS_BEFORE], [LOGS_AFTER], [LOGS_ACTION], [LOGS_DATE], [USE_ID], [LOGS_ORIGEM], [TenantID], [Deleted], [Changed], [UserId] FROM [LogsDatabase] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["LOGS_TABLE"] = value; //06
                      whereClauses.Add($" [LOGS_TABLE] = @LOGS_TABLE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByLOGS_KEYQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [LOGS_ID], [LOGS_TABLE], [LOGS_KEY], [LOGS_KEY1], [LOGS_KEY2], [LOGS_KEY3], [LOGS_KEY4], [LOGS_COLUMN], [LOGS_BEFORE], [LOGS_AFTER], [LOGS_ACTION], [LOGS_DATE], [USE_ID], [LOGS_ORIGEM], [TenantID], [Deleted], [Changed], [UserId] FROM [LogsDatabase] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["LOGS_KEY"] = value; //06
                      whereClauses.Add($" [LOGS_KEY] = @LOGS_KEY ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByLOGS_KEY1Query(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [LOGS_ID], [LOGS_TABLE], [LOGS_KEY], [LOGS_KEY1], [LOGS_KEY2], [LOGS_KEY3], [LOGS_KEY4], [LOGS_COLUMN], [LOGS_BEFORE], [LOGS_AFTER], [LOGS_ACTION], [LOGS_DATE], [USE_ID], [LOGS_ORIGEM], [TenantID], [Deleted], [Changed], [UserId] FROM [LogsDatabase] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["LOGS_KEY1"] = value; //06
                      whereClauses.Add($" [LOGS_KEY1] = @LOGS_KEY1 ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByLOGS_KEY2Query(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [LOGS_ID], [LOGS_TABLE], [LOGS_KEY], [LOGS_KEY1], [LOGS_KEY2], [LOGS_KEY3], [LOGS_KEY4], [LOGS_COLUMN], [LOGS_BEFORE], [LOGS_AFTER], [LOGS_ACTION], [LOGS_DATE], [USE_ID], [LOGS_ORIGEM], [TenantID], [Deleted], [Changed], [UserId] FROM [LogsDatabase] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["LOGS_KEY2"] = value; //06
                      whereClauses.Add($" [LOGS_KEY2] = @LOGS_KEY2 ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByLOGS_KEY3Query(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [LOGS_ID], [LOGS_TABLE], [LOGS_KEY], [LOGS_KEY1], [LOGS_KEY2], [LOGS_KEY3], [LOGS_KEY4], [LOGS_COLUMN], [LOGS_BEFORE], [LOGS_AFTER], [LOGS_ACTION], [LOGS_DATE], [USE_ID], [LOGS_ORIGEM], [TenantID], [Deleted], [Changed], [UserId] FROM [LogsDatabase] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["LOGS_KEY3"] = value; //06
                      whereClauses.Add($" [LOGS_KEY3] = @LOGS_KEY3 ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByLOGS_KEY4Query(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [LOGS_ID], [LOGS_TABLE], [LOGS_KEY], [LOGS_KEY1], [LOGS_KEY2], [LOGS_KEY3], [LOGS_KEY4], [LOGS_COLUMN], [LOGS_BEFORE], [LOGS_AFTER], [LOGS_ACTION], [LOGS_DATE], [USE_ID], [LOGS_ORIGEM], [TenantID], [Deleted], [Changed], [UserId] FROM [LogsDatabase] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["LOGS_KEY4"] = value; //06
                      whereClauses.Add($" [LOGS_KEY4] = @LOGS_KEY4 ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByLOGS_COLUMNQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [LOGS_ID], [LOGS_TABLE], [LOGS_KEY], [LOGS_KEY1], [LOGS_KEY2], [LOGS_KEY3], [LOGS_KEY4], [LOGS_COLUMN], [LOGS_BEFORE], [LOGS_AFTER], [LOGS_ACTION], [LOGS_DATE], [USE_ID], [LOGS_ORIGEM], [TenantID], [Deleted], [Changed], [UserId] FROM [LogsDatabase] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["LOGS_COLUMN"] = value; //06
                      whereClauses.Add($" [LOGS_COLUMN] = @LOGS_COLUMN ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByLOGS_BEFOREQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [LOGS_ID], [LOGS_TABLE], [LOGS_KEY], [LOGS_KEY1], [LOGS_KEY2], [LOGS_KEY3], [LOGS_KEY4], [LOGS_COLUMN], [LOGS_BEFORE], [LOGS_AFTER], [LOGS_ACTION], [LOGS_DATE], [USE_ID], [LOGS_ORIGEM], [TenantID], [Deleted], [Changed], [UserId] FROM [LogsDatabase] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["LOGS_BEFORE"] = value; //06
                      whereClauses.Add($" [LOGS_BEFORE] = @LOGS_BEFORE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByLOGS_AFTERQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [LOGS_ID], [LOGS_TABLE], [LOGS_KEY], [LOGS_KEY1], [LOGS_KEY2], [LOGS_KEY3], [LOGS_KEY4], [LOGS_COLUMN], [LOGS_BEFORE], [LOGS_AFTER], [LOGS_ACTION], [LOGS_DATE], [USE_ID], [LOGS_ORIGEM], [TenantID], [Deleted], [Changed], [UserId] FROM [LogsDatabase] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["LOGS_AFTER"] = value; //06
                      whereClauses.Add($" [LOGS_AFTER] = @LOGS_AFTER ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByLOGS_ACTIONQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [LOGS_ID], [LOGS_TABLE], [LOGS_KEY], [LOGS_KEY1], [LOGS_KEY2], [LOGS_KEY3], [LOGS_KEY4], [LOGS_COLUMN], [LOGS_BEFORE], [LOGS_AFTER], [LOGS_ACTION], [LOGS_DATE], [USE_ID], [LOGS_ORIGEM], [TenantID], [Deleted], [Changed], [UserId] FROM [LogsDatabase] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["LOGS_ACTION"] = value; //06
                      whereClauses.Add($" [LOGS_ACTION] = @LOGS_ACTION ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByLOGS_DATEQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [LOGS_ID], [LOGS_TABLE], [LOGS_KEY], [LOGS_KEY1], [LOGS_KEY2], [LOGS_KEY3], [LOGS_KEY4], [LOGS_COLUMN], [LOGS_BEFORE], [LOGS_AFTER], [LOGS_ACTION], [LOGS_DATE], [USE_ID], [LOGS_ORIGEM], [TenantID], [Deleted], [Changed], [UserId] FROM [LogsDatabase] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["LOGS_DATE"] = value; //06
                      whereClauses.Add($" [LOGS_DATE] = @LOGS_DATE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByUSE_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [LOGS_ID], [LOGS_TABLE], [LOGS_KEY], [LOGS_KEY1], [LOGS_KEY2], [LOGS_KEY3], [LOGS_KEY4], [LOGS_COLUMN], [LOGS_BEFORE], [LOGS_AFTER], [LOGS_ACTION], [LOGS_DATE], [USE_ID], [LOGS_ORIGEM], [TenantID], [Deleted], [Changed], [UserId] FROM [LogsDatabase] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["USE_ID"] = value; //06
                      whereClauses.Add($" [USE_ID] = @USE_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByLOGS_ORIGEMQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [LOGS_ID], [LOGS_TABLE], [LOGS_KEY], [LOGS_KEY1], [LOGS_KEY2], [LOGS_KEY3], [LOGS_KEY4], [LOGS_COLUMN], [LOGS_BEFORE], [LOGS_AFTER], [LOGS_ACTION], [LOGS_DATE], [USE_ID], [LOGS_ORIGEM], [TenantID], [Deleted], [Changed], [UserId] FROM [LogsDatabase] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["LOGS_ORIGEM"] = value; //06
                      whereClauses.Add($" [LOGS_ORIGEM] = @LOGS_ORIGEM ");//06
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
            this.Query = $"SELECT [LOGS_ID], [LOGS_TABLE], [LOGS_KEY], [LOGS_KEY1], [LOGS_KEY2], [LOGS_KEY3], [LOGS_KEY4], [LOGS_COLUMN], [LOGS_BEFORE], [LOGS_AFTER], [LOGS_ACTION], [LOGS_DATE], [USE_ID], [LOGS_ORIGEM], [TenantID], [Deleted], [Changed], [UserId] FROM [LogsDatabase] ";
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
            this.Query = $"SELECT [LOGS_ID], [LOGS_TABLE], [LOGS_KEY], [LOGS_KEY1], [LOGS_KEY2], [LOGS_KEY3], [LOGS_KEY4], [LOGS_COLUMN], [LOGS_BEFORE], [LOGS_AFTER], [LOGS_ACTION], [LOGS_DATE], [USE_ID], [LOGS_ORIGEM], [TenantID], [Deleted], [Changed], [UserId] FROM [LogsDatabase] ";
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
            this.Query = $"SELECT [LOGS_ID], [LOGS_TABLE], [LOGS_KEY], [LOGS_KEY1], [LOGS_KEY2], [LOGS_KEY3], [LOGS_KEY4], [LOGS_COLUMN], [LOGS_BEFORE], [LOGS_AFTER], [LOGS_ACTION], [LOGS_DATE], [USE_ID], [LOGS_ORIGEM], [TenantID], [Deleted], [Changed], [UserId] FROM [LogsDatabase] ";
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
            this.Query = $"SELECT [LOGS_ID], [LOGS_TABLE], [LOGS_KEY], [LOGS_KEY1], [LOGS_KEY2], [LOGS_KEY3], [LOGS_KEY4], [LOGS_COLUMN], [LOGS_BEFORE], [LOGS_AFTER], [LOGS_ACTION], [LOGS_DATE], [USE_ID], [LOGS_ORIGEM], [TenantID], [Deleted], [Changed], [UserId] FROM [LogsDatabase] ";
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