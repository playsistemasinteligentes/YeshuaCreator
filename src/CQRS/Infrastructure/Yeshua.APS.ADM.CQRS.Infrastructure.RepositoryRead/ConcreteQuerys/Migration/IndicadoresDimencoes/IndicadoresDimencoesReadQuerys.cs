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
    public class IndicadoresDimencoesQueryRead : QueryBase, IIndicadoresDimencoesQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public IndicadoresDimencoesQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel IndicadoresDimencoesQuery(Command.Read.IndicadoresDimencoesReadCommand Command )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select [Id], [DIM_ID], [IND_ID], [DIM_DESCRICAO], [DIM_SQL], [DIM_CONEXAO], [OperationalEntityId], [TenantID], [Deleted], [Changed], [UserId] from [IndicadoresDimencoes] ";
if (Command.Id.HasValue) dict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"[Id] = @Id");
if (Command.DIM_ID.HasValue) dict["DIM_ID"] = Command.DIM_ID.Value;
if (Command.DIM_ID.HasValue) whereClauses.Add($"[DIM_ID] = @DIM_ID");
if (Command.IND_ID.HasValue) dict["IND_ID"] = Command.IND_ID.Value;
if (Command.IND_ID.HasValue) whereClauses.Add($"[IND_ID] = @IND_ID");
if (!string.IsNullOrEmpty(Command.DIM_DESCRICAO)) dict["DIM_DESCRICAO"] = $"%{Command.DIM_DESCRICAO}%";
if (!string.IsNullOrEmpty(Command.DIM_DESCRICAO)) whereClauses.Add($"[DIM_DESCRICAO] like @DIM_DESCRICAO");
if (!string.IsNullOrEmpty(Command.DIM_SQL)) dict["DIM_SQL"] = $"%{Command.DIM_SQL}%";
if (!string.IsNullOrEmpty(Command.DIM_SQL)) whereClauses.Add($"[DIM_SQL] like @DIM_SQL");
if (!string.IsNullOrEmpty(Command.DIM_CONEXAO)) dict["DIM_CONEXAO"] = $"%{Command.DIM_CONEXAO}%";
if (!string.IsNullOrEmpty(Command.DIM_CONEXAO)) whereClauses.Add($"[DIM_CONEXAO] like @DIM_CONEXAO");
if (!string.IsNullOrEmpty(Command.OperationalEntityId)) dict["OperationalEntityId"] = $"%{Command.OperationalEntityId}%";
if (!string.IsNullOrEmpty(Command.OperationalEntityId)) whereClauses.Add($"[OperationalEntityId] like @OperationalEntityId");
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
        public QueryModel IndicadoresDimencoesIND_IDQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select [IND_ID] from [T_Indicadores] ";
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["IND_ID"] = numero; //01
                      whereClauses.Add($" [IND_ID] = @IND_ID");//01 
                 }
                 else 
                 {
                      dict["IND_ID"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" [IND_ID] like @IND_ID ");//02
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
        public QueryModel IndicadoresDimencoesTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel IndicadoresDimencoesUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel ExistsByIdQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [IndicadoresDimencoes] ";
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
        public QueryModel ExistsByDIM_IDQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [IndicadoresDimencoes] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["DIM_ID"] = value; //04
                      whereClauses.Add($" [DIM_ID] = @DIM_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByIND_IDQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [IndicadoresDimencoes] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["IND_ID"] = value; //04
                      whereClauses.Add($" [IND_ID] = @IND_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByDIM_DESCRICAOQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [IndicadoresDimencoes] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["DIM_DESCRICAO"] = value; //04
                      whereClauses.Add($" [DIM_DESCRICAO] = @DIM_DESCRICAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByDIM_SQLQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [IndicadoresDimencoes] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["DIM_SQL"] = value; //04
                      whereClauses.Add($" [DIM_SQL] = @DIM_SQL ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByDIM_CONEXAOQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [IndicadoresDimencoes] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["DIM_CONEXAO"] = value; //04
                      whereClauses.Add($" [DIM_CONEXAO] = @DIM_CONEXAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByOperationalEntityIdQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [IndicadoresDimencoes] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["OperationalEntityId"] = value; //04
                      whereClauses.Add($" [OperationalEntityId] = @OperationalEntityId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTenantIDQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [IndicadoresDimencoes] ";
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
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [IndicadoresDimencoes] ";
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
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [IndicadoresDimencoes] ";
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
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [IndicadoresDimencoes] ";
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
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [DIM_ID], [IND_ID], [DIM_DESCRICAO], [DIM_SQL], [DIM_CONEXAO], [OperationalEntityId], [TenantID], [Deleted], [Changed], [UserId] FROM [IndicadoresDimencoes] ";
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
        public QueryModel FirstByDIM_IDQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [DIM_ID], [IND_ID], [DIM_DESCRICAO], [DIM_SQL], [DIM_CONEXAO], [OperationalEntityId], [TenantID], [Deleted], [Changed], [UserId] FROM [IndicadoresDimencoes] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["DIM_ID"] = value; //06
                      whereClauses.Add($" [DIM_ID] = @DIM_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByIND_IDQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [DIM_ID], [IND_ID], [DIM_DESCRICAO], [DIM_SQL], [DIM_CONEXAO], [OperationalEntityId], [TenantID], [Deleted], [Changed], [UserId] FROM [IndicadoresDimencoes] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["IND_ID"] = value; //06
                      whereClauses.Add($" [IND_ID] = @IND_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByDIM_DESCRICAOQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [DIM_ID], [IND_ID], [DIM_DESCRICAO], [DIM_SQL], [DIM_CONEXAO], [OperationalEntityId], [TenantID], [Deleted], [Changed], [UserId] FROM [IndicadoresDimencoes] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["DIM_DESCRICAO"] = value; //06
                      whereClauses.Add($" [DIM_DESCRICAO] = @DIM_DESCRICAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByDIM_SQLQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [DIM_ID], [IND_ID], [DIM_DESCRICAO], [DIM_SQL], [DIM_CONEXAO], [OperationalEntityId], [TenantID], [Deleted], [Changed], [UserId] FROM [IndicadoresDimencoes] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["DIM_SQL"] = value; //06
                      whereClauses.Add($" [DIM_SQL] = @DIM_SQL ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByDIM_CONEXAOQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [DIM_ID], [IND_ID], [DIM_DESCRICAO], [DIM_SQL], [DIM_CONEXAO], [OperationalEntityId], [TenantID], [Deleted], [Changed], [UserId] FROM [IndicadoresDimencoes] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["DIM_CONEXAO"] = value; //06
                      whereClauses.Add($" [DIM_CONEXAO] = @DIM_CONEXAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByOperationalEntityIdQuery(string value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [DIM_ID], [IND_ID], [DIM_DESCRICAO], [DIM_SQL], [DIM_CONEXAO], [OperationalEntityId], [TenantID], [Deleted], [Changed], [UserId] FROM [IndicadoresDimencoes] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["OperationalEntityId"] = value; //06
                      whereClauses.Add($" [OperationalEntityId] = @OperationalEntityId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTenantIDQuery(int value )
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [DIM_ID], [IND_ID], [DIM_DESCRICAO], [DIM_SQL], [DIM_CONEXAO], [OperationalEntityId], [TenantID], [Deleted], [Changed], [UserId] FROM [IndicadoresDimencoes] ";
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
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [DIM_ID], [IND_ID], [DIM_DESCRICAO], [DIM_SQL], [DIM_CONEXAO], [OperationalEntityId], [TenantID], [Deleted], [Changed], [UserId] FROM [IndicadoresDimencoes] ";
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
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [DIM_ID], [IND_ID], [DIM_DESCRICAO], [DIM_SQL], [DIM_CONEXAO], [OperationalEntityId], [TenantID], [Deleted], [Changed], [UserId] FROM [IndicadoresDimencoes] ";
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
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [DIM_ID], [IND_ID], [DIM_DESCRICAO], [DIM_SQL], [DIM_CONEXAO], [OperationalEntityId], [TenantID], [Deleted], [Changed], [UserId] FROM [IndicadoresDimencoes] ";
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