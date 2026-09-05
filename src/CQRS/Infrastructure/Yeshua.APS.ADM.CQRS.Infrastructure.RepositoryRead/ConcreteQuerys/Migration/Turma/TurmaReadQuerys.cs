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
    public class TurmaQueryRead : QueryBase, ITurmaQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public TurmaQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel TurmaQuery(Command.Read.TurmaReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select [Id], [Descricao], [TURM_HORA_INI_DIA1], [TURM_HORA_FIM_DIA1], [TURM_HORA_INI_DIA2], [TURM_HORA_FIM_DIA2], [TURM_HORA_INI_DIA3], [TURM_HORA_FIM_DIA3], [TURM_HORA_INI_DIA4], [TURM_HORA_FIM_DIA4], [TURM_HORA_INI_DIA5], [TURM_HORA_FIM_DIA5], [TURM_HORA_INI_DIA6], [TURM_HORA_FIM_DIA6], [TURM_HORA_INI_DIA7], [TURM_HORA_FIM_DIA7], [TenantID], [Deleted], [Changed], [UserId] from [Turma] ";
if (!string.IsNullOrEmpty(Command.Id)) dict["Id"] = $"%{Command.Id}%";
if (!string.IsNullOrEmpty(Command.Id)) whereClauses.Add($"[Id] like @Id");
if (!string.IsNullOrEmpty(Command.Descricao)) dict["Descricao"] = $"%{Command.Descricao}%";
if (!string.IsNullOrEmpty(Command.Descricao)) whereClauses.Add($"[Descricao] like @Descricao");
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
        public QueryModel TurmaTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel TurmaUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel ExistsByIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Turma] ";
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
        public QueryModel ExistsByDescricaoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Turma] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Descricao"] = value; //04
                      whereClauses.Add($" [Descricao] = @Descricao ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTURM_HORA_INI_DIA1Query(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Turma] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TURM_HORA_INI_DIA1"] = value; //04
                      whereClauses.Add($" [TURM_HORA_INI_DIA1] = @TURM_HORA_INI_DIA1 ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTURM_HORA_FIM_DIA1Query(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Turma] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TURM_HORA_FIM_DIA1"] = value; //04
                      whereClauses.Add($" [TURM_HORA_FIM_DIA1] = @TURM_HORA_FIM_DIA1 ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTURM_HORA_INI_DIA2Query(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Turma] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TURM_HORA_INI_DIA2"] = value; //04
                      whereClauses.Add($" [TURM_HORA_INI_DIA2] = @TURM_HORA_INI_DIA2 ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTURM_HORA_FIM_DIA2Query(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Turma] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TURM_HORA_FIM_DIA2"] = value; //04
                      whereClauses.Add($" [TURM_HORA_FIM_DIA2] = @TURM_HORA_FIM_DIA2 ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTURM_HORA_INI_DIA3Query(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Turma] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TURM_HORA_INI_DIA3"] = value; //04
                      whereClauses.Add($" [TURM_HORA_INI_DIA3] = @TURM_HORA_INI_DIA3 ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTURM_HORA_FIM_DIA3Query(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Turma] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TURM_HORA_FIM_DIA3"] = value; //04
                      whereClauses.Add($" [TURM_HORA_FIM_DIA3] = @TURM_HORA_FIM_DIA3 ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTURM_HORA_INI_DIA4Query(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Turma] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TURM_HORA_INI_DIA4"] = value; //04
                      whereClauses.Add($" [TURM_HORA_INI_DIA4] = @TURM_HORA_INI_DIA4 ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTURM_HORA_FIM_DIA4Query(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Turma] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TURM_HORA_FIM_DIA4"] = value; //04
                      whereClauses.Add($" [TURM_HORA_FIM_DIA4] = @TURM_HORA_FIM_DIA4 ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTURM_HORA_INI_DIA5Query(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Turma] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TURM_HORA_INI_DIA5"] = value; //04
                      whereClauses.Add($" [TURM_HORA_INI_DIA5] = @TURM_HORA_INI_DIA5 ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTURM_HORA_FIM_DIA5Query(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Turma] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TURM_HORA_FIM_DIA5"] = value; //04
                      whereClauses.Add($" [TURM_HORA_FIM_DIA5] = @TURM_HORA_FIM_DIA5 ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTURM_HORA_INI_DIA6Query(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Turma] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TURM_HORA_INI_DIA6"] = value; //04
                      whereClauses.Add($" [TURM_HORA_INI_DIA6] = @TURM_HORA_INI_DIA6 ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTURM_HORA_FIM_DIA6Query(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Turma] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TURM_HORA_FIM_DIA6"] = value; //04
                      whereClauses.Add($" [TURM_HORA_FIM_DIA6] = @TURM_HORA_FIM_DIA6 ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTURM_HORA_INI_DIA7Query(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Turma] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TURM_HORA_INI_DIA7"] = value; //04
                      whereClauses.Add($" [TURM_HORA_INI_DIA7] = @TURM_HORA_INI_DIA7 ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTURM_HORA_FIM_DIA7Query(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Turma] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TURM_HORA_FIM_DIA7"] = value; //04
                      whereClauses.Add($" [TURM_HORA_FIM_DIA7] = @TURM_HORA_FIM_DIA7 ");//04
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
            this.Query = $"SELECT 1 FROM [Turma] ";
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
            this.Query = $"SELECT 1 FROM [Turma] ";
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
            this.Query = $"SELECT 1 FROM [Turma] ";
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
            this.Query = $"SELECT 1 FROM [Turma] ";
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
        public QueryModel FirstByIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [TURM_HORA_INI_DIA1], [TURM_HORA_FIM_DIA1], [TURM_HORA_INI_DIA2], [TURM_HORA_FIM_DIA2], [TURM_HORA_INI_DIA3], [TURM_HORA_FIM_DIA3], [TURM_HORA_INI_DIA4], [TURM_HORA_FIM_DIA4], [TURM_HORA_INI_DIA5], [TURM_HORA_FIM_DIA5], [TURM_HORA_INI_DIA6], [TURM_HORA_FIM_DIA6], [TURM_HORA_INI_DIA7], [TURM_HORA_FIM_DIA7], [TenantID], [Deleted], [Changed], [UserId] FROM [Turma] ";
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
        public QueryModel FirstByDescricaoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [TURM_HORA_INI_DIA1], [TURM_HORA_FIM_DIA1], [TURM_HORA_INI_DIA2], [TURM_HORA_FIM_DIA2], [TURM_HORA_INI_DIA3], [TURM_HORA_FIM_DIA3], [TURM_HORA_INI_DIA4], [TURM_HORA_FIM_DIA4], [TURM_HORA_INI_DIA5], [TURM_HORA_FIM_DIA5], [TURM_HORA_INI_DIA6], [TURM_HORA_FIM_DIA6], [TURM_HORA_INI_DIA7], [TURM_HORA_FIM_DIA7], [TenantID], [Deleted], [Changed], [UserId] FROM [Turma] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Descricao"] = value; //06
                      whereClauses.Add($" [Descricao] = @Descricao ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTURM_HORA_INI_DIA1Query(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [TURM_HORA_INI_DIA1], [TURM_HORA_FIM_DIA1], [TURM_HORA_INI_DIA2], [TURM_HORA_FIM_DIA2], [TURM_HORA_INI_DIA3], [TURM_HORA_FIM_DIA3], [TURM_HORA_INI_DIA4], [TURM_HORA_FIM_DIA4], [TURM_HORA_INI_DIA5], [TURM_HORA_FIM_DIA5], [TURM_HORA_INI_DIA6], [TURM_HORA_FIM_DIA6], [TURM_HORA_INI_DIA7], [TURM_HORA_FIM_DIA7], [TenantID], [Deleted], [Changed], [UserId] FROM [Turma] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TURM_HORA_INI_DIA1"] = value; //06
                      whereClauses.Add($" [TURM_HORA_INI_DIA1] = @TURM_HORA_INI_DIA1 ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTURM_HORA_FIM_DIA1Query(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [TURM_HORA_INI_DIA1], [TURM_HORA_FIM_DIA1], [TURM_HORA_INI_DIA2], [TURM_HORA_FIM_DIA2], [TURM_HORA_INI_DIA3], [TURM_HORA_FIM_DIA3], [TURM_HORA_INI_DIA4], [TURM_HORA_FIM_DIA4], [TURM_HORA_INI_DIA5], [TURM_HORA_FIM_DIA5], [TURM_HORA_INI_DIA6], [TURM_HORA_FIM_DIA6], [TURM_HORA_INI_DIA7], [TURM_HORA_FIM_DIA7], [TenantID], [Deleted], [Changed], [UserId] FROM [Turma] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TURM_HORA_FIM_DIA1"] = value; //06
                      whereClauses.Add($" [TURM_HORA_FIM_DIA1] = @TURM_HORA_FIM_DIA1 ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTURM_HORA_INI_DIA2Query(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [TURM_HORA_INI_DIA1], [TURM_HORA_FIM_DIA1], [TURM_HORA_INI_DIA2], [TURM_HORA_FIM_DIA2], [TURM_HORA_INI_DIA3], [TURM_HORA_FIM_DIA3], [TURM_HORA_INI_DIA4], [TURM_HORA_FIM_DIA4], [TURM_HORA_INI_DIA5], [TURM_HORA_FIM_DIA5], [TURM_HORA_INI_DIA6], [TURM_HORA_FIM_DIA6], [TURM_HORA_INI_DIA7], [TURM_HORA_FIM_DIA7], [TenantID], [Deleted], [Changed], [UserId] FROM [Turma] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TURM_HORA_INI_DIA2"] = value; //06
                      whereClauses.Add($" [TURM_HORA_INI_DIA2] = @TURM_HORA_INI_DIA2 ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTURM_HORA_FIM_DIA2Query(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [TURM_HORA_INI_DIA1], [TURM_HORA_FIM_DIA1], [TURM_HORA_INI_DIA2], [TURM_HORA_FIM_DIA2], [TURM_HORA_INI_DIA3], [TURM_HORA_FIM_DIA3], [TURM_HORA_INI_DIA4], [TURM_HORA_FIM_DIA4], [TURM_HORA_INI_DIA5], [TURM_HORA_FIM_DIA5], [TURM_HORA_INI_DIA6], [TURM_HORA_FIM_DIA6], [TURM_HORA_INI_DIA7], [TURM_HORA_FIM_DIA7], [TenantID], [Deleted], [Changed], [UserId] FROM [Turma] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TURM_HORA_FIM_DIA2"] = value; //06
                      whereClauses.Add($" [TURM_HORA_FIM_DIA2] = @TURM_HORA_FIM_DIA2 ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTURM_HORA_INI_DIA3Query(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [TURM_HORA_INI_DIA1], [TURM_HORA_FIM_DIA1], [TURM_HORA_INI_DIA2], [TURM_HORA_FIM_DIA2], [TURM_HORA_INI_DIA3], [TURM_HORA_FIM_DIA3], [TURM_HORA_INI_DIA4], [TURM_HORA_FIM_DIA4], [TURM_HORA_INI_DIA5], [TURM_HORA_FIM_DIA5], [TURM_HORA_INI_DIA6], [TURM_HORA_FIM_DIA6], [TURM_HORA_INI_DIA7], [TURM_HORA_FIM_DIA7], [TenantID], [Deleted], [Changed], [UserId] FROM [Turma] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TURM_HORA_INI_DIA3"] = value; //06
                      whereClauses.Add($" [TURM_HORA_INI_DIA3] = @TURM_HORA_INI_DIA3 ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTURM_HORA_FIM_DIA3Query(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [TURM_HORA_INI_DIA1], [TURM_HORA_FIM_DIA1], [TURM_HORA_INI_DIA2], [TURM_HORA_FIM_DIA2], [TURM_HORA_INI_DIA3], [TURM_HORA_FIM_DIA3], [TURM_HORA_INI_DIA4], [TURM_HORA_FIM_DIA4], [TURM_HORA_INI_DIA5], [TURM_HORA_FIM_DIA5], [TURM_HORA_INI_DIA6], [TURM_HORA_FIM_DIA6], [TURM_HORA_INI_DIA7], [TURM_HORA_FIM_DIA7], [TenantID], [Deleted], [Changed], [UserId] FROM [Turma] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TURM_HORA_FIM_DIA3"] = value; //06
                      whereClauses.Add($" [TURM_HORA_FIM_DIA3] = @TURM_HORA_FIM_DIA3 ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTURM_HORA_INI_DIA4Query(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [TURM_HORA_INI_DIA1], [TURM_HORA_FIM_DIA1], [TURM_HORA_INI_DIA2], [TURM_HORA_FIM_DIA2], [TURM_HORA_INI_DIA3], [TURM_HORA_FIM_DIA3], [TURM_HORA_INI_DIA4], [TURM_HORA_FIM_DIA4], [TURM_HORA_INI_DIA5], [TURM_HORA_FIM_DIA5], [TURM_HORA_INI_DIA6], [TURM_HORA_FIM_DIA6], [TURM_HORA_INI_DIA7], [TURM_HORA_FIM_DIA7], [TenantID], [Deleted], [Changed], [UserId] FROM [Turma] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TURM_HORA_INI_DIA4"] = value; //06
                      whereClauses.Add($" [TURM_HORA_INI_DIA4] = @TURM_HORA_INI_DIA4 ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTURM_HORA_FIM_DIA4Query(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [TURM_HORA_INI_DIA1], [TURM_HORA_FIM_DIA1], [TURM_HORA_INI_DIA2], [TURM_HORA_FIM_DIA2], [TURM_HORA_INI_DIA3], [TURM_HORA_FIM_DIA3], [TURM_HORA_INI_DIA4], [TURM_HORA_FIM_DIA4], [TURM_HORA_INI_DIA5], [TURM_HORA_FIM_DIA5], [TURM_HORA_INI_DIA6], [TURM_HORA_FIM_DIA6], [TURM_HORA_INI_DIA7], [TURM_HORA_FIM_DIA7], [TenantID], [Deleted], [Changed], [UserId] FROM [Turma] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TURM_HORA_FIM_DIA4"] = value; //06
                      whereClauses.Add($" [TURM_HORA_FIM_DIA4] = @TURM_HORA_FIM_DIA4 ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTURM_HORA_INI_DIA5Query(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [TURM_HORA_INI_DIA1], [TURM_HORA_FIM_DIA1], [TURM_HORA_INI_DIA2], [TURM_HORA_FIM_DIA2], [TURM_HORA_INI_DIA3], [TURM_HORA_FIM_DIA3], [TURM_HORA_INI_DIA4], [TURM_HORA_FIM_DIA4], [TURM_HORA_INI_DIA5], [TURM_HORA_FIM_DIA5], [TURM_HORA_INI_DIA6], [TURM_HORA_FIM_DIA6], [TURM_HORA_INI_DIA7], [TURM_HORA_FIM_DIA7], [TenantID], [Deleted], [Changed], [UserId] FROM [Turma] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TURM_HORA_INI_DIA5"] = value; //06
                      whereClauses.Add($" [TURM_HORA_INI_DIA5] = @TURM_HORA_INI_DIA5 ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTURM_HORA_FIM_DIA5Query(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [TURM_HORA_INI_DIA1], [TURM_HORA_FIM_DIA1], [TURM_HORA_INI_DIA2], [TURM_HORA_FIM_DIA2], [TURM_HORA_INI_DIA3], [TURM_HORA_FIM_DIA3], [TURM_HORA_INI_DIA4], [TURM_HORA_FIM_DIA4], [TURM_HORA_INI_DIA5], [TURM_HORA_FIM_DIA5], [TURM_HORA_INI_DIA6], [TURM_HORA_FIM_DIA6], [TURM_HORA_INI_DIA7], [TURM_HORA_FIM_DIA7], [TenantID], [Deleted], [Changed], [UserId] FROM [Turma] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TURM_HORA_FIM_DIA5"] = value; //06
                      whereClauses.Add($" [TURM_HORA_FIM_DIA5] = @TURM_HORA_FIM_DIA5 ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTURM_HORA_INI_DIA6Query(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [TURM_HORA_INI_DIA1], [TURM_HORA_FIM_DIA1], [TURM_HORA_INI_DIA2], [TURM_HORA_FIM_DIA2], [TURM_HORA_INI_DIA3], [TURM_HORA_FIM_DIA3], [TURM_HORA_INI_DIA4], [TURM_HORA_FIM_DIA4], [TURM_HORA_INI_DIA5], [TURM_HORA_FIM_DIA5], [TURM_HORA_INI_DIA6], [TURM_HORA_FIM_DIA6], [TURM_HORA_INI_DIA7], [TURM_HORA_FIM_DIA7], [TenantID], [Deleted], [Changed], [UserId] FROM [Turma] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TURM_HORA_INI_DIA6"] = value; //06
                      whereClauses.Add($" [TURM_HORA_INI_DIA6] = @TURM_HORA_INI_DIA6 ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTURM_HORA_FIM_DIA6Query(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [TURM_HORA_INI_DIA1], [TURM_HORA_FIM_DIA1], [TURM_HORA_INI_DIA2], [TURM_HORA_FIM_DIA2], [TURM_HORA_INI_DIA3], [TURM_HORA_FIM_DIA3], [TURM_HORA_INI_DIA4], [TURM_HORA_FIM_DIA4], [TURM_HORA_INI_DIA5], [TURM_HORA_FIM_DIA5], [TURM_HORA_INI_DIA6], [TURM_HORA_FIM_DIA6], [TURM_HORA_INI_DIA7], [TURM_HORA_FIM_DIA7], [TenantID], [Deleted], [Changed], [UserId] FROM [Turma] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TURM_HORA_FIM_DIA6"] = value; //06
                      whereClauses.Add($" [TURM_HORA_FIM_DIA6] = @TURM_HORA_FIM_DIA6 ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTURM_HORA_INI_DIA7Query(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [TURM_HORA_INI_DIA1], [TURM_HORA_FIM_DIA1], [TURM_HORA_INI_DIA2], [TURM_HORA_FIM_DIA2], [TURM_HORA_INI_DIA3], [TURM_HORA_FIM_DIA3], [TURM_HORA_INI_DIA4], [TURM_HORA_FIM_DIA4], [TURM_HORA_INI_DIA5], [TURM_HORA_FIM_DIA5], [TURM_HORA_INI_DIA6], [TURM_HORA_FIM_DIA6], [TURM_HORA_INI_DIA7], [TURM_HORA_FIM_DIA7], [TenantID], [Deleted], [Changed], [UserId] FROM [Turma] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TURM_HORA_INI_DIA7"] = value; //06
                      whereClauses.Add($" [TURM_HORA_INI_DIA7] = @TURM_HORA_INI_DIA7 ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTURM_HORA_FIM_DIA7Query(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [TURM_HORA_INI_DIA1], [TURM_HORA_FIM_DIA1], [TURM_HORA_INI_DIA2], [TURM_HORA_FIM_DIA2], [TURM_HORA_INI_DIA3], [TURM_HORA_FIM_DIA3], [TURM_HORA_INI_DIA4], [TURM_HORA_FIM_DIA4], [TURM_HORA_INI_DIA5], [TURM_HORA_FIM_DIA5], [TURM_HORA_INI_DIA6], [TURM_HORA_FIM_DIA6], [TURM_HORA_INI_DIA7], [TURM_HORA_FIM_DIA7], [TenantID], [Deleted], [Changed], [UserId] FROM [Turma] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TURM_HORA_FIM_DIA7"] = value; //06
                      whereClauses.Add($" [TURM_HORA_FIM_DIA7] = @TURM_HORA_FIM_DIA7 ");//06
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
            this.Query = $"SELECT [Id], [Descricao], [TURM_HORA_INI_DIA1], [TURM_HORA_FIM_DIA1], [TURM_HORA_INI_DIA2], [TURM_HORA_FIM_DIA2], [TURM_HORA_INI_DIA3], [TURM_HORA_FIM_DIA3], [TURM_HORA_INI_DIA4], [TURM_HORA_FIM_DIA4], [TURM_HORA_INI_DIA5], [TURM_HORA_FIM_DIA5], [TURM_HORA_INI_DIA6], [TURM_HORA_FIM_DIA6], [TURM_HORA_INI_DIA7], [TURM_HORA_FIM_DIA7], [TenantID], [Deleted], [Changed], [UserId] FROM [Turma] ";
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
            this.Query = $"SELECT [Id], [Descricao], [TURM_HORA_INI_DIA1], [TURM_HORA_FIM_DIA1], [TURM_HORA_INI_DIA2], [TURM_HORA_FIM_DIA2], [TURM_HORA_INI_DIA3], [TURM_HORA_FIM_DIA3], [TURM_HORA_INI_DIA4], [TURM_HORA_FIM_DIA4], [TURM_HORA_INI_DIA5], [TURM_HORA_FIM_DIA5], [TURM_HORA_INI_DIA6], [TURM_HORA_FIM_DIA6], [TURM_HORA_INI_DIA7], [TURM_HORA_FIM_DIA7], [TenantID], [Deleted], [Changed], [UserId] FROM [Turma] ";
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
            this.Query = $"SELECT [Id], [Descricao], [TURM_HORA_INI_DIA1], [TURM_HORA_FIM_DIA1], [TURM_HORA_INI_DIA2], [TURM_HORA_FIM_DIA2], [TURM_HORA_INI_DIA3], [TURM_HORA_FIM_DIA3], [TURM_HORA_INI_DIA4], [TURM_HORA_FIM_DIA4], [TURM_HORA_INI_DIA5], [TURM_HORA_FIM_DIA5], [TURM_HORA_INI_DIA6], [TURM_HORA_FIM_DIA6], [TURM_HORA_INI_DIA7], [TURM_HORA_FIM_DIA7], [TenantID], [Deleted], [Changed], [UserId] FROM [Turma] ";
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
            this.Query = $"SELECT [Id], [Descricao], [TURM_HORA_INI_DIA1], [TURM_HORA_FIM_DIA1], [TURM_HORA_INI_DIA2], [TURM_HORA_FIM_DIA2], [TURM_HORA_INI_DIA3], [TURM_HORA_FIM_DIA3], [TURM_HORA_INI_DIA4], [TURM_HORA_FIM_DIA4], [TURM_HORA_INI_DIA5], [TURM_HORA_FIM_DIA5], [TURM_HORA_INI_DIA6], [TURM_HORA_FIM_DIA6], [TURM_HORA_INI_DIA7], [TURM_HORA_FIM_DIA7], [TenantID], [Deleted], [Changed], [UserId] FROM [Turma] ";
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