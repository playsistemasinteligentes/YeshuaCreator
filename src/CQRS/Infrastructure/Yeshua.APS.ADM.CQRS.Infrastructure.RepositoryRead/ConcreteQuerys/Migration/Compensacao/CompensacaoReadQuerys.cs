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
    public class CompensacaoQueryRead : QueryBase, ICompensacaoQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public CompensacaoQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel CompensacaoQuery(Command.Read.CompensacaoReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select [Id], [COM_ID], [GRP_ID], [OND_ID], [COM_VINCO1_OND], [COM_VINCO2_OND], [COM_VINCO3_OND], [COM_VINCO4_OND], [COM_VINCO5_OND], [COM_VINCO6_OND], [COM_VINCO7_OND], [COM_VINCO8_OND], [COM_VINCO9_OND], [COM_VINCO10_OND], [COM_VINCO1_CONVERSAO], [COM_VINCO2_CONVERSAO], [COM_VINCO3_CONVERSAO], [COM_VINCO4_CONVERSAO], [COM_VINCO5_CONVERSAO], [COM_VINCO6_CONVERSAO], [COM_VINCO7_CONVERSAO], [COM_VINCO8_CONVERSAO], [COM_VINCO9_CONVERSAO], [COM_VINCO10_CONVERSAO], [TenantID], [Deleted], [Changed], [UserId] from [Compensacao] ";
if (Command.Id.HasValue) dict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"[Id] = @Id");
if (Command.COM_ID.HasValue) dict["COM_ID"] = Command.COM_ID.Value;
if (Command.COM_ID.HasValue) whereClauses.Add($"[COM_ID] = @COM_ID");
if (!string.IsNullOrEmpty(Command.GRP_ID)) dict["GRP_ID"] = $"%{Command.GRP_ID}%";
if (!string.IsNullOrEmpty(Command.GRP_ID)) whereClauses.Add($"[GRP_ID] like @GRP_ID");
if (!string.IsNullOrEmpty(Command.OND_ID)) dict["OND_ID"] = $"%{Command.OND_ID}%";
if (!string.IsNullOrEmpty(Command.OND_ID)) whereClauses.Add($"[OND_ID] like @OND_ID");
if (Command.COM_VINCO1_OND.HasValue) dict["COM_VINCO1_OND"] = Command.COM_VINCO1_OND.Value;
if (Command.COM_VINCO1_OND.HasValue) whereClauses.Add($"[COM_VINCO1_OND] = @COM_VINCO1_OND");
if (Command.COM_VINCO2_OND.HasValue) dict["COM_VINCO2_OND"] = Command.COM_VINCO2_OND.Value;
if (Command.COM_VINCO2_OND.HasValue) whereClauses.Add($"[COM_VINCO2_OND] = @COM_VINCO2_OND");
if (Command.COM_VINCO3_OND.HasValue) dict["COM_VINCO3_OND"] = Command.COM_VINCO3_OND.Value;
if (Command.COM_VINCO3_OND.HasValue) whereClauses.Add($"[COM_VINCO3_OND] = @COM_VINCO3_OND");
if (Command.COM_VINCO4_OND.HasValue) dict["COM_VINCO4_OND"] = Command.COM_VINCO4_OND.Value;
if (Command.COM_VINCO4_OND.HasValue) whereClauses.Add($"[COM_VINCO4_OND] = @COM_VINCO4_OND");
if (Command.COM_VINCO5_OND.HasValue) dict["COM_VINCO5_OND"] = Command.COM_VINCO5_OND.Value;
if (Command.COM_VINCO5_OND.HasValue) whereClauses.Add($"[COM_VINCO5_OND] = @COM_VINCO5_OND");
if (Command.COM_VINCO6_OND.HasValue) dict["COM_VINCO6_OND"] = Command.COM_VINCO6_OND.Value;
if (Command.COM_VINCO6_OND.HasValue) whereClauses.Add($"[COM_VINCO6_OND] = @COM_VINCO6_OND");
if (Command.COM_VINCO7_OND.HasValue) dict["COM_VINCO7_OND"] = Command.COM_VINCO7_OND.Value;
if (Command.COM_VINCO7_OND.HasValue) whereClauses.Add($"[COM_VINCO7_OND] = @COM_VINCO7_OND");
if (Command.COM_VINCO8_OND.HasValue) dict["COM_VINCO8_OND"] = Command.COM_VINCO8_OND.Value;
if (Command.COM_VINCO8_OND.HasValue) whereClauses.Add($"[COM_VINCO8_OND] = @COM_VINCO8_OND");
if (Command.COM_VINCO9_OND.HasValue) dict["COM_VINCO9_OND"] = Command.COM_VINCO9_OND.Value;
if (Command.COM_VINCO9_OND.HasValue) whereClauses.Add($"[COM_VINCO9_OND] = @COM_VINCO9_OND");
if (Command.COM_VINCO10_OND.HasValue) dict["COM_VINCO10_OND"] = Command.COM_VINCO10_OND.Value;
if (Command.COM_VINCO10_OND.HasValue) whereClauses.Add($"[COM_VINCO10_OND] = @COM_VINCO10_OND");
if (Command.COM_VINCO1_CONVERSAO.HasValue) dict["COM_VINCO1_CONVERSAO"] = Command.COM_VINCO1_CONVERSAO.Value;
if (Command.COM_VINCO1_CONVERSAO.HasValue) whereClauses.Add($"[COM_VINCO1_CONVERSAO] = @COM_VINCO1_CONVERSAO");
if (Command.COM_VINCO2_CONVERSAO.HasValue) dict["COM_VINCO2_CONVERSAO"] = Command.COM_VINCO2_CONVERSAO.Value;
if (Command.COM_VINCO2_CONVERSAO.HasValue) whereClauses.Add($"[COM_VINCO2_CONVERSAO] = @COM_VINCO2_CONVERSAO");
if (Command.COM_VINCO3_CONVERSAO.HasValue) dict["COM_VINCO3_CONVERSAO"] = Command.COM_VINCO3_CONVERSAO.Value;
if (Command.COM_VINCO3_CONVERSAO.HasValue) whereClauses.Add($"[COM_VINCO3_CONVERSAO] = @COM_VINCO3_CONVERSAO");
if (Command.COM_VINCO4_CONVERSAO.HasValue) dict["COM_VINCO4_CONVERSAO"] = Command.COM_VINCO4_CONVERSAO.Value;
if (Command.COM_VINCO4_CONVERSAO.HasValue) whereClauses.Add($"[COM_VINCO4_CONVERSAO] = @COM_VINCO4_CONVERSAO");
if (Command.COM_VINCO5_CONVERSAO.HasValue) dict["COM_VINCO5_CONVERSAO"] = Command.COM_VINCO5_CONVERSAO.Value;
if (Command.COM_VINCO5_CONVERSAO.HasValue) whereClauses.Add($"[COM_VINCO5_CONVERSAO] = @COM_VINCO5_CONVERSAO");
if (Command.COM_VINCO6_CONVERSAO.HasValue) dict["COM_VINCO6_CONVERSAO"] = Command.COM_VINCO6_CONVERSAO.Value;
if (Command.COM_VINCO6_CONVERSAO.HasValue) whereClauses.Add($"[COM_VINCO6_CONVERSAO] = @COM_VINCO6_CONVERSAO");
if (Command.COM_VINCO7_CONVERSAO.HasValue) dict["COM_VINCO7_CONVERSAO"] = Command.COM_VINCO7_CONVERSAO.Value;
if (Command.COM_VINCO7_CONVERSAO.HasValue) whereClauses.Add($"[COM_VINCO7_CONVERSAO] = @COM_VINCO7_CONVERSAO");
if (Command.COM_VINCO8_CONVERSAO.HasValue) dict["COM_VINCO8_CONVERSAO"] = Command.COM_VINCO8_CONVERSAO.Value;
if (Command.COM_VINCO8_CONVERSAO.HasValue) whereClauses.Add($"[COM_VINCO8_CONVERSAO] = @COM_VINCO8_CONVERSAO");
if (Command.COM_VINCO9_CONVERSAO.HasValue) dict["COM_VINCO9_CONVERSAO"] = Command.COM_VINCO9_CONVERSAO.Value;
if (Command.COM_VINCO9_CONVERSAO.HasValue) whereClauses.Add($"[COM_VINCO9_CONVERSAO] = @COM_VINCO9_CONVERSAO");
if (Command.COM_VINCO10_CONVERSAO.HasValue) dict["COM_VINCO10_CONVERSAO"] = Command.COM_VINCO10_CONVERSAO.Value;
if (Command.COM_VINCO10_CONVERSAO.HasValue) whereClauses.Add($"[COM_VINCO10_CONVERSAO] = @COM_VINCO10_CONVERSAO");
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
        public QueryModel CompensacaoGRP_IDQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel CompensacaoOND_IDQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select [OND_ID] from [Onda] ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["OND_ID"] = numero; //01
                      whereClauses.Add($" [OND_ID] = @OND_ID");//01 
                 }
                 else 
                 {
                      dict["OND_ID"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" [OND_ID] like @OND_ID ");//02
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
        public QueryModel CompensacaoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel CompensacaoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
            this.Query = $"SELECT 1 FROM [Compensacao] ";
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
        public QueryModel ExistsByCOM_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COM_ID"] = value; //04
                      whereClauses.Add($" [COM_ID] = @COM_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["GRP_ID"] = value; //04
                      whereClauses.Add($" [GRP_ID] = @GRP_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByOND_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["OND_ID"] = value; //04
                      whereClauses.Add($" [OND_ID] = @OND_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOM_VINCO1_ONDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COM_VINCO1_OND"] = value; //04
                      whereClauses.Add($" [COM_VINCO1_OND] = @COM_VINCO1_OND ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOM_VINCO2_ONDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COM_VINCO2_OND"] = value; //04
                      whereClauses.Add($" [COM_VINCO2_OND] = @COM_VINCO2_OND ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOM_VINCO3_ONDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COM_VINCO3_OND"] = value; //04
                      whereClauses.Add($" [COM_VINCO3_OND] = @COM_VINCO3_OND ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOM_VINCO4_ONDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COM_VINCO4_OND"] = value; //04
                      whereClauses.Add($" [COM_VINCO4_OND] = @COM_VINCO4_OND ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOM_VINCO5_ONDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COM_VINCO5_OND"] = value; //04
                      whereClauses.Add($" [COM_VINCO5_OND] = @COM_VINCO5_OND ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOM_VINCO6_ONDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COM_VINCO6_OND"] = value; //04
                      whereClauses.Add($" [COM_VINCO6_OND] = @COM_VINCO6_OND ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOM_VINCO7_ONDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COM_VINCO7_OND"] = value; //04
                      whereClauses.Add($" [COM_VINCO7_OND] = @COM_VINCO7_OND ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOM_VINCO8_ONDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COM_VINCO8_OND"] = value; //04
                      whereClauses.Add($" [COM_VINCO8_OND] = @COM_VINCO8_OND ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOM_VINCO9_ONDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COM_VINCO9_OND"] = value; //04
                      whereClauses.Add($" [COM_VINCO9_OND] = @COM_VINCO9_OND ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOM_VINCO10_ONDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COM_VINCO10_OND"] = value; //04
                      whereClauses.Add($" [COM_VINCO10_OND] = @COM_VINCO10_OND ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOM_VINCO1_CONVERSAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COM_VINCO1_CONVERSAO"] = value; //04
                      whereClauses.Add($" [COM_VINCO1_CONVERSAO] = @COM_VINCO1_CONVERSAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOM_VINCO2_CONVERSAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COM_VINCO2_CONVERSAO"] = value; //04
                      whereClauses.Add($" [COM_VINCO2_CONVERSAO] = @COM_VINCO2_CONVERSAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOM_VINCO3_CONVERSAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COM_VINCO3_CONVERSAO"] = value; //04
                      whereClauses.Add($" [COM_VINCO3_CONVERSAO] = @COM_VINCO3_CONVERSAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOM_VINCO4_CONVERSAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COM_VINCO4_CONVERSAO"] = value; //04
                      whereClauses.Add($" [COM_VINCO4_CONVERSAO] = @COM_VINCO4_CONVERSAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOM_VINCO5_CONVERSAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COM_VINCO5_CONVERSAO"] = value; //04
                      whereClauses.Add($" [COM_VINCO5_CONVERSAO] = @COM_VINCO5_CONVERSAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOM_VINCO6_CONVERSAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COM_VINCO6_CONVERSAO"] = value; //04
                      whereClauses.Add($" [COM_VINCO6_CONVERSAO] = @COM_VINCO6_CONVERSAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOM_VINCO7_CONVERSAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COM_VINCO7_CONVERSAO"] = value; //04
                      whereClauses.Add($" [COM_VINCO7_CONVERSAO] = @COM_VINCO7_CONVERSAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOM_VINCO8_CONVERSAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COM_VINCO8_CONVERSAO"] = value; //04
                      whereClauses.Add($" [COM_VINCO8_CONVERSAO] = @COM_VINCO8_CONVERSAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOM_VINCO9_CONVERSAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COM_VINCO9_CONVERSAO"] = value; //04
                      whereClauses.Add($" [COM_VINCO9_CONVERSAO] = @COM_VINCO9_CONVERSAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOM_VINCO10_CONVERSAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COM_VINCO10_CONVERSAO"] = value; //04
                      whereClauses.Add($" [COM_VINCO10_CONVERSAO] = @COM_VINCO10_CONVERSAO ");//04
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
            this.Query = $"SELECT 1 FROM [Compensacao] ";
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
            this.Query = $"SELECT 1 FROM [Compensacao] ";
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
            this.Query = $"SELECT 1 FROM [Compensacao] ";
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
            this.Query = $"SELECT 1 FROM [Compensacao] ";
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
            this.Query = $"SELECT [Id], [COM_ID], [GRP_ID], [OND_ID], [COM_VINCO1_OND], [COM_VINCO2_OND], [COM_VINCO3_OND], [COM_VINCO4_OND], [COM_VINCO5_OND], [COM_VINCO6_OND], [COM_VINCO7_OND], [COM_VINCO8_OND], [COM_VINCO9_OND], [COM_VINCO10_OND], [COM_VINCO1_CONVERSAO], [COM_VINCO2_CONVERSAO], [COM_VINCO3_CONVERSAO], [COM_VINCO4_CONVERSAO], [COM_VINCO5_CONVERSAO], [COM_VINCO6_CONVERSAO], [COM_VINCO7_CONVERSAO], [COM_VINCO8_CONVERSAO], [COM_VINCO9_CONVERSAO], [COM_VINCO10_CONVERSAO], [TenantID], [Deleted], [Changed], [UserId] FROM [Compensacao] ";
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
        public QueryModel FirstByCOM_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [COM_ID], [GRP_ID], [OND_ID], [COM_VINCO1_OND], [COM_VINCO2_OND], [COM_VINCO3_OND], [COM_VINCO4_OND], [COM_VINCO5_OND], [COM_VINCO6_OND], [COM_VINCO7_OND], [COM_VINCO8_OND], [COM_VINCO9_OND], [COM_VINCO10_OND], [COM_VINCO1_CONVERSAO], [COM_VINCO2_CONVERSAO], [COM_VINCO3_CONVERSAO], [COM_VINCO4_CONVERSAO], [COM_VINCO5_CONVERSAO], [COM_VINCO6_CONVERSAO], [COM_VINCO7_CONVERSAO], [COM_VINCO8_CONVERSAO], [COM_VINCO9_CONVERSAO], [COM_VINCO10_CONVERSAO], [TenantID], [Deleted], [Changed], [UserId] FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COM_ID"] = value; //06
                      whereClauses.Add($" [COM_ID] = @COM_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [COM_ID], [GRP_ID], [OND_ID], [COM_VINCO1_OND], [COM_VINCO2_OND], [COM_VINCO3_OND], [COM_VINCO4_OND], [COM_VINCO5_OND], [COM_VINCO6_OND], [COM_VINCO7_OND], [COM_VINCO8_OND], [COM_VINCO9_OND], [COM_VINCO10_OND], [COM_VINCO1_CONVERSAO], [COM_VINCO2_CONVERSAO], [COM_VINCO3_CONVERSAO], [COM_VINCO4_CONVERSAO], [COM_VINCO5_CONVERSAO], [COM_VINCO6_CONVERSAO], [COM_VINCO7_CONVERSAO], [COM_VINCO8_CONVERSAO], [COM_VINCO9_CONVERSAO], [COM_VINCO10_CONVERSAO], [TenantID], [Deleted], [Changed], [UserId] FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["GRP_ID"] = value; //06
                      whereClauses.Add($" [GRP_ID] = @GRP_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByOND_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [COM_ID], [GRP_ID], [OND_ID], [COM_VINCO1_OND], [COM_VINCO2_OND], [COM_VINCO3_OND], [COM_VINCO4_OND], [COM_VINCO5_OND], [COM_VINCO6_OND], [COM_VINCO7_OND], [COM_VINCO8_OND], [COM_VINCO9_OND], [COM_VINCO10_OND], [COM_VINCO1_CONVERSAO], [COM_VINCO2_CONVERSAO], [COM_VINCO3_CONVERSAO], [COM_VINCO4_CONVERSAO], [COM_VINCO5_CONVERSAO], [COM_VINCO6_CONVERSAO], [COM_VINCO7_CONVERSAO], [COM_VINCO8_CONVERSAO], [COM_VINCO9_CONVERSAO], [COM_VINCO10_CONVERSAO], [TenantID], [Deleted], [Changed], [UserId] FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["OND_ID"] = value; //06
                      whereClauses.Add($" [OND_ID] = @OND_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOM_VINCO1_ONDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [COM_ID], [GRP_ID], [OND_ID], [COM_VINCO1_OND], [COM_VINCO2_OND], [COM_VINCO3_OND], [COM_VINCO4_OND], [COM_VINCO5_OND], [COM_VINCO6_OND], [COM_VINCO7_OND], [COM_VINCO8_OND], [COM_VINCO9_OND], [COM_VINCO10_OND], [COM_VINCO1_CONVERSAO], [COM_VINCO2_CONVERSAO], [COM_VINCO3_CONVERSAO], [COM_VINCO4_CONVERSAO], [COM_VINCO5_CONVERSAO], [COM_VINCO6_CONVERSAO], [COM_VINCO7_CONVERSAO], [COM_VINCO8_CONVERSAO], [COM_VINCO9_CONVERSAO], [COM_VINCO10_CONVERSAO], [TenantID], [Deleted], [Changed], [UserId] FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COM_VINCO1_OND"] = value; //06
                      whereClauses.Add($" [COM_VINCO1_OND] = @COM_VINCO1_OND ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOM_VINCO2_ONDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [COM_ID], [GRP_ID], [OND_ID], [COM_VINCO1_OND], [COM_VINCO2_OND], [COM_VINCO3_OND], [COM_VINCO4_OND], [COM_VINCO5_OND], [COM_VINCO6_OND], [COM_VINCO7_OND], [COM_VINCO8_OND], [COM_VINCO9_OND], [COM_VINCO10_OND], [COM_VINCO1_CONVERSAO], [COM_VINCO2_CONVERSAO], [COM_VINCO3_CONVERSAO], [COM_VINCO4_CONVERSAO], [COM_VINCO5_CONVERSAO], [COM_VINCO6_CONVERSAO], [COM_VINCO7_CONVERSAO], [COM_VINCO8_CONVERSAO], [COM_VINCO9_CONVERSAO], [COM_VINCO10_CONVERSAO], [TenantID], [Deleted], [Changed], [UserId] FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COM_VINCO2_OND"] = value; //06
                      whereClauses.Add($" [COM_VINCO2_OND] = @COM_VINCO2_OND ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOM_VINCO3_ONDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [COM_ID], [GRP_ID], [OND_ID], [COM_VINCO1_OND], [COM_VINCO2_OND], [COM_VINCO3_OND], [COM_VINCO4_OND], [COM_VINCO5_OND], [COM_VINCO6_OND], [COM_VINCO7_OND], [COM_VINCO8_OND], [COM_VINCO9_OND], [COM_VINCO10_OND], [COM_VINCO1_CONVERSAO], [COM_VINCO2_CONVERSAO], [COM_VINCO3_CONVERSAO], [COM_VINCO4_CONVERSAO], [COM_VINCO5_CONVERSAO], [COM_VINCO6_CONVERSAO], [COM_VINCO7_CONVERSAO], [COM_VINCO8_CONVERSAO], [COM_VINCO9_CONVERSAO], [COM_VINCO10_CONVERSAO], [TenantID], [Deleted], [Changed], [UserId] FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COM_VINCO3_OND"] = value; //06
                      whereClauses.Add($" [COM_VINCO3_OND] = @COM_VINCO3_OND ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOM_VINCO4_ONDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [COM_ID], [GRP_ID], [OND_ID], [COM_VINCO1_OND], [COM_VINCO2_OND], [COM_VINCO3_OND], [COM_VINCO4_OND], [COM_VINCO5_OND], [COM_VINCO6_OND], [COM_VINCO7_OND], [COM_VINCO8_OND], [COM_VINCO9_OND], [COM_VINCO10_OND], [COM_VINCO1_CONVERSAO], [COM_VINCO2_CONVERSAO], [COM_VINCO3_CONVERSAO], [COM_VINCO4_CONVERSAO], [COM_VINCO5_CONVERSAO], [COM_VINCO6_CONVERSAO], [COM_VINCO7_CONVERSAO], [COM_VINCO8_CONVERSAO], [COM_VINCO9_CONVERSAO], [COM_VINCO10_CONVERSAO], [TenantID], [Deleted], [Changed], [UserId] FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COM_VINCO4_OND"] = value; //06
                      whereClauses.Add($" [COM_VINCO4_OND] = @COM_VINCO4_OND ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOM_VINCO5_ONDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [COM_ID], [GRP_ID], [OND_ID], [COM_VINCO1_OND], [COM_VINCO2_OND], [COM_VINCO3_OND], [COM_VINCO4_OND], [COM_VINCO5_OND], [COM_VINCO6_OND], [COM_VINCO7_OND], [COM_VINCO8_OND], [COM_VINCO9_OND], [COM_VINCO10_OND], [COM_VINCO1_CONVERSAO], [COM_VINCO2_CONVERSAO], [COM_VINCO3_CONVERSAO], [COM_VINCO4_CONVERSAO], [COM_VINCO5_CONVERSAO], [COM_VINCO6_CONVERSAO], [COM_VINCO7_CONVERSAO], [COM_VINCO8_CONVERSAO], [COM_VINCO9_CONVERSAO], [COM_VINCO10_CONVERSAO], [TenantID], [Deleted], [Changed], [UserId] FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COM_VINCO5_OND"] = value; //06
                      whereClauses.Add($" [COM_VINCO5_OND] = @COM_VINCO5_OND ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOM_VINCO6_ONDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [COM_ID], [GRP_ID], [OND_ID], [COM_VINCO1_OND], [COM_VINCO2_OND], [COM_VINCO3_OND], [COM_VINCO4_OND], [COM_VINCO5_OND], [COM_VINCO6_OND], [COM_VINCO7_OND], [COM_VINCO8_OND], [COM_VINCO9_OND], [COM_VINCO10_OND], [COM_VINCO1_CONVERSAO], [COM_VINCO2_CONVERSAO], [COM_VINCO3_CONVERSAO], [COM_VINCO4_CONVERSAO], [COM_VINCO5_CONVERSAO], [COM_VINCO6_CONVERSAO], [COM_VINCO7_CONVERSAO], [COM_VINCO8_CONVERSAO], [COM_VINCO9_CONVERSAO], [COM_VINCO10_CONVERSAO], [TenantID], [Deleted], [Changed], [UserId] FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COM_VINCO6_OND"] = value; //06
                      whereClauses.Add($" [COM_VINCO6_OND] = @COM_VINCO6_OND ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOM_VINCO7_ONDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [COM_ID], [GRP_ID], [OND_ID], [COM_VINCO1_OND], [COM_VINCO2_OND], [COM_VINCO3_OND], [COM_VINCO4_OND], [COM_VINCO5_OND], [COM_VINCO6_OND], [COM_VINCO7_OND], [COM_VINCO8_OND], [COM_VINCO9_OND], [COM_VINCO10_OND], [COM_VINCO1_CONVERSAO], [COM_VINCO2_CONVERSAO], [COM_VINCO3_CONVERSAO], [COM_VINCO4_CONVERSAO], [COM_VINCO5_CONVERSAO], [COM_VINCO6_CONVERSAO], [COM_VINCO7_CONVERSAO], [COM_VINCO8_CONVERSAO], [COM_VINCO9_CONVERSAO], [COM_VINCO10_CONVERSAO], [TenantID], [Deleted], [Changed], [UserId] FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COM_VINCO7_OND"] = value; //06
                      whereClauses.Add($" [COM_VINCO7_OND] = @COM_VINCO7_OND ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOM_VINCO8_ONDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [COM_ID], [GRP_ID], [OND_ID], [COM_VINCO1_OND], [COM_VINCO2_OND], [COM_VINCO3_OND], [COM_VINCO4_OND], [COM_VINCO5_OND], [COM_VINCO6_OND], [COM_VINCO7_OND], [COM_VINCO8_OND], [COM_VINCO9_OND], [COM_VINCO10_OND], [COM_VINCO1_CONVERSAO], [COM_VINCO2_CONVERSAO], [COM_VINCO3_CONVERSAO], [COM_VINCO4_CONVERSAO], [COM_VINCO5_CONVERSAO], [COM_VINCO6_CONVERSAO], [COM_VINCO7_CONVERSAO], [COM_VINCO8_CONVERSAO], [COM_VINCO9_CONVERSAO], [COM_VINCO10_CONVERSAO], [TenantID], [Deleted], [Changed], [UserId] FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COM_VINCO8_OND"] = value; //06
                      whereClauses.Add($" [COM_VINCO8_OND] = @COM_VINCO8_OND ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOM_VINCO9_ONDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [COM_ID], [GRP_ID], [OND_ID], [COM_VINCO1_OND], [COM_VINCO2_OND], [COM_VINCO3_OND], [COM_VINCO4_OND], [COM_VINCO5_OND], [COM_VINCO6_OND], [COM_VINCO7_OND], [COM_VINCO8_OND], [COM_VINCO9_OND], [COM_VINCO10_OND], [COM_VINCO1_CONVERSAO], [COM_VINCO2_CONVERSAO], [COM_VINCO3_CONVERSAO], [COM_VINCO4_CONVERSAO], [COM_VINCO5_CONVERSAO], [COM_VINCO6_CONVERSAO], [COM_VINCO7_CONVERSAO], [COM_VINCO8_CONVERSAO], [COM_VINCO9_CONVERSAO], [COM_VINCO10_CONVERSAO], [TenantID], [Deleted], [Changed], [UserId] FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COM_VINCO9_OND"] = value; //06
                      whereClauses.Add($" [COM_VINCO9_OND] = @COM_VINCO9_OND ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOM_VINCO10_ONDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [COM_ID], [GRP_ID], [OND_ID], [COM_VINCO1_OND], [COM_VINCO2_OND], [COM_VINCO3_OND], [COM_VINCO4_OND], [COM_VINCO5_OND], [COM_VINCO6_OND], [COM_VINCO7_OND], [COM_VINCO8_OND], [COM_VINCO9_OND], [COM_VINCO10_OND], [COM_VINCO1_CONVERSAO], [COM_VINCO2_CONVERSAO], [COM_VINCO3_CONVERSAO], [COM_VINCO4_CONVERSAO], [COM_VINCO5_CONVERSAO], [COM_VINCO6_CONVERSAO], [COM_VINCO7_CONVERSAO], [COM_VINCO8_CONVERSAO], [COM_VINCO9_CONVERSAO], [COM_VINCO10_CONVERSAO], [TenantID], [Deleted], [Changed], [UserId] FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COM_VINCO10_OND"] = value; //06
                      whereClauses.Add($" [COM_VINCO10_OND] = @COM_VINCO10_OND ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOM_VINCO1_CONVERSAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [COM_ID], [GRP_ID], [OND_ID], [COM_VINCO1_OND], [COM_VINCO2_OND], [COM_VINCO3_OND], [COM_VINCO4_OND], [COM_VINCO5_OND], [COM_VINCO6_OND], [COM_VINCO7_OND], [COM_VINCO8_OND], [COM_VINCO9_OND], [COM_VINCO10_OND], [COM_VINCO1_CONVERSAO], [COM_VINCO2_CONVERSAO], [COM_VINCO3_CONVERSAO], [COM_VINCO4_CONVERSAO], [COM_VINCO5_CONVERSAO], [COM_VINCO6_CONVERSAO], [COM_VINCO7_CONVERSAO], [COM_VINCO8_CONVERSAO], [COM_VINCO9_CONVERSAO], [COM_VINCO10_CONVERSAO], [TenantID], [Deleted], [Changed], [UserId] FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COM_VINCO1_CONVERSAO"] = value; //06
                      whereClauses.Add($" [COM_VINCO1_CONVERSAO] = @COM_VINCO1_CONVERSAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOM_VINCO2_CONVERSAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [COM_ID], [GRP_ID], [OND_ID], [COM_VINCO1_OND], [COM_VINCO2_OND], [COM_VINCO3_OND], [COM_VINCO4_OND], [COM_VINCO5_OND], [COM_VINCO6_OND], [COM_VINCO7_OND], [COM_VINCO8_OND], [COM_VINCO9_OND], [COM_VINCO10_OND], [COM_VINCO1_CONVERSAO], [COM_VINCO2_CONVERSAO], [COM_VINCO3_CONVERSAO], [COM_VINCO4_CONVERSAO], [COM_VINCO5_CONVERSAO], [COM_VINCO6_CONVERSAO], [COM_VINCO7_CONVERSAO], [COM_VINCO8_CONVERSAO], [COM_VINCO9_CONVERSAO], [COM_VINCO10_CONVERSAO], [TenantID], [Deleted], [Changed], [UserId] FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COM_VINCO2_CONVERSAO"] = value; //06
                      whereClauses.Add($" [COM_VINCO2_CONVERSAO] = @COM_VINCO2_CONVERSAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOM_VINCO3_CONVERSAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [COM_ID], [GRP_ID], [OND_ID], [COM_VINCO1_OND], [COM_VINCO2_OND], [COM_VINCO3_OND], [COM_VINCO4_OND], [COM_VINCO5_OND], [COM_VINCO6_OND], [COM_VINCO7_OND], [COM_VINCO8_OND], [COM_VINCO9_OND], [COM_VINCO10_OND], [COM_VINCO1_CONVERSAO], [COM_VINCO2_CONVERSAO], [COM_VINCO3_CONVERSAO], [COM_VINCO4_CONVERSAO], [COM_VINCO5_CONVERSAO], [COM_VINCO6_CONVERSAO], [COM_VINCO7_CONVERSAO], [COM_VINCO8_CONVERSAO], [COM_VINCO9_CONVERSAO], [COM_VINCO10_CONVERSAO], [TenantID], [Deleted], [Changed], [UserId] FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COM_VINCO3_CONVERSAO"] = value; //06
                      whereClauses.Add($" [COM_VINCO3_CONVERSAO] = @COM_VINCO3_CONVERSAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOM_VINCO4_CONVERSAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [COM_ID], [GRP_ID], [OND_ID], [COM_VINCO1_OND], [COM_VINCO2_OND], [COM_VINCO3_OND], [COM_VINCO4_OND], [COM_VINCO5_OND], [COM_VINCO6_OND], [COM_VINCO7_OND], [COM_VINCO8_OND], [COM_VINCO9_OND], [COM_VINCO10_OND], [COM_VINCO1_CONVERSAO], [COM_VINCO2_CONVERSAO], [COM_VINCO3_CONVERSAO], [COM_VINCO4_CONVERSAO], [COM_VINCO5_CONVERSAO], [COM_VINCO6_CONVERSAO], [COM_VINCO7_CONVERSAO], [COM_VINCO8_CONVERSAO], [COM_VINCO9_CONVERSAO], [COM_VINCO10_CONVERSAO], [TenantID], [Deleted], [Changed], [UserId] FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COM_VINCO4_CONVERSAO"] = value; //06
                      whereClauses.Add($" [COM_VINCO4_CONVERSAO] = @COM_VINCO4_CONVERSAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOM_VINCO5_CONVERSAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [COM_ID], [GRP_ID], [OND_ID], [COM_VINCO1_OND], [COM_VINCO2_OND], [COM_VINCO3_OND], [COM_VINCO4_OND], [COM_VINCO5_OND], [COM_VINCO6_OND], [COM_VINCO7_OND], [COM_VINCO8_OND], [COM_VINCO9_OND], [COM_VINCO10_OND], [COM_VINCO1_CONVERSAO], [COM_VINCO2_CONVERSAO], [COM_VINCO3_CONVERSAO], [COM_VINCO4_CONVERSAO], [COM_VINCO5_CONVERSAO], [COM_VINCO6_CONVERSAO], [COM_VINCO7_CONVERSAO], [COM_VINCO8_CONVERSAO], [COM_VINCO9_CONVERSAO], [COM_VINCO10_CONVERSAO], [TenantID], [Deleted], [Changed], [UserId] FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COM_VINCO5_CONVERSAO"] = value; //06
                      whereClauses.Add($" [COM_VINCO5_CONVERSAO] = @COM_VINCO5_CONVERSAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOM_VINCO6_CONVERSAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [COM_ID], [GRP_ID], [OND_ID], [COM_VINCO1_OND], [COM_VINCO2_OND], [COM_VINCO3_OND], [COM_VINCO4_OND], [COM_VINCO5_OND], [COM_VINCO6_OND], [COM_VINCO7_OND], [COM_VINCO8_OND], [COM_VINCO9_OND], [COM_VINCO10_OND], [COM_VINCO1_CONVERSAO], [COM_VINCO2_CONVERSAO], [COM_VINCO3_CONVERSAO], [COM_VINCO4_CONVERSAO], [COM_VINCO5_CONVERSAO], [COM_VINCO6_CONVERSAO], [COM_VINCO7_CONVERSAO], [COM_VINCO8_CONVERSAO], [COM_VINCO9_CONVERSAO], [COM_VINCO10_CONVERSAO], [TenantID], [Deleted], [Changed], [UserId] FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COM_VINCO6_CONVERSAO"] = value; //06
                      whereClauses.Add($" [COM_VINCO6_CONVERSAO] = @COM_VINCO6_CONVERSAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOM_VINCO7_CONVERSAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [COM_ID], [GRP_ID], [OND_ID], [COM_VINCO1_OND], [COM_VINCO2_OND], [COM_VINCO3_OND], [COM_VINCO4_OND], [COM_VINCO5_OND], [COM_VINCO6_OND], [COM_VINCO7_OND], [COM_VINCO8_OND], [COM_VINCO9_OND], [COM_VINCO10_OND], [COM_VINCO1_CONVERSAO], [COM_VINCO2_CONVERSAO], [COM_VINCO3_CONVERSAO], [COM_VINCO4_CONVERSAO], [COM_VINCO5_CONVERSAO], [COM_VINCO6_CONVERSAO], [COM_VINCO7_CONVERSAO], [COM_VINCO8_CONVERSAO], [COM_VINCO9_CONVERSAO], [COM_VINCO10_CONVERSAO], [TenantID], [Deleted], [Changed], [UserId] FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COM_VINCO7_CONVERSAO"] = value; //06
                      whereClauses.Add($" [COM_VINCO7_CONVERSAO] = @COM_VINCO7_CONVERSAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOM_VINCO8_CONVERSAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [COM_ID], [GRP_ID], [OND_ID], [COM_VINCO1_OND], [COM_VINCO2_OND], [COM_VINCO3_OND], [COM_VINCO4_OND], [COM_VINCO5_OND], [COM_VINCO6_OND], [COM_VINCO7_OND], [COM_VINCO8_OND], [COM_VINCO9_OND], [COM_VINCO10_OND], [COM_VINCO1_CONVERSAO], [COM_VINCO2_CONVERSAO], [COM_VINCO3_CONVERSAO], [COM_VINCO4_CONVERSAO], [COM_VINCO5_CONVERSAO], [COM_VINCO6_CONVERSAO], [COM_VINCO7_CONVERSAO], [COM_VINCO8_CONVERSAO], [COM_VINCO9_CONVERSAO], [COM_VINCO10_CONVERSAO], [TenantID], [Deleted], [Changed], [UserId] FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COM_VINCO8_CONVERSAO"] = value; //06
                      whereClauses.Add($" [COM_VINCO8_CONVERSAO] = @COM_VINCO8_CONVERSAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOM_VINCO9_CONVERSAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [COM_ID], [GRP_ID], [OND_ID], [COM_VINCO1_OND], [COM_VINCO2_OND], [COM_VINCO3_OND], [COM_VINCO4_OND], [COM_VINCO5_OND], [COM_VINCO6_OND], [COM_VINCO7_OND], [COM_VINCO8_OND], [COM_VINCO9_OND], [COM_VINCO10_OND], [COM_VINCO1_CONVERSAO], [COM_VINCO2_CONVERSAO], [COM_VINCO3_CONVERSAO], [COM_VINCO4_CONVERSAO], [COM_VINCO5_CONVERSAO], [COM_VINCO6_CONVERSAO], [COM_VINCO7_CONVERSAO], [COM_VINCO8_CONVERSAO], [COM_VINCO9_CONVERSAO], [COM_VINCO10_CONVERSAO], [TenantID], [Deleted], [Changed], [UserId] FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COM_VINCO9_CONVERSAO"] = value; //06
                      whereClauses.Add($" [COM_VINCO9_CONVERSAO] = @COM_VINCO9_CONVERSAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOM_VINCO10_CONVERSAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [COM_ID], [GRP_ID], [OND_ID], [COM_VINCO1_OND], [COM_VINCO2_OND], [COM_VINCO3_OND], [COM_VINCO4_OND], [COM_VINCO5_OND], [COM_VINCO6_OND], [COM_VINCO7_OND], [COM_VINCO8_OND], [COM_VINCO9_OND], [COM_VINCO10_OND], [COM_VINCO1_CONVERSAO], [COM_VINCO2_CONVERSAO], [COM_VINCO3_CONVERSAO], [COM_VINCO4_CONVERSAO], [COM_VINCO5_CONVERSAO], [COM_VINCO6_CONVERSAO], [COM_VINCO7_CONVERSAO], [COM_VINCO8_CONVERSAO], [COM_VINCO9_CONVERSAO], [COM_VINCO10_CONVERSAO], [TenantID], [Deleted], [Changed], [UserId] FROM [Compensacao] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COM_VINCO10_CONVERSAO"] = value; //06
                      whereClauses.Add($" [COM_VINCO10_CONVERSAO] = @COM_VINCO10_CONVERSAO ");//06
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
            this.Query = $"SELECT [Id], [COM_ID], [GRP_ID], [OND_ID], [COM_VINCO1_OND], [COM_VINCO2_OND], [COM_VINCO3_OND], [COM_VINCO4_OND], [COM_VINCO5_OND], [COM_VINCO6_OND], [COM_VINCO7_OND], [COM_VINCO8_OND], [COM_VINCO9_OND], [COM_VINCO10_OND], [COM_VINCO1_CONVERSAO], [COM_VINCO2_CONVERSAO], [COM_VINCO3_CONVERSAO], [COM_VINCO4_CONVERSAO], [COM_VINCO5_CONVERSAO], [COM_VINCO6_CONVERSAO], [COM_VINCO7_CONVERSAO], [COM_VINCO8_CONVERSAO], [COM_VINCO9_CONVERSAO], [COM_VINCO10_CONVERSAO], [TenantID], [Deleted], [Changed], [UserId] FROM [Compensacao] ";
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
            this.Query = $"SELECT [Id], [COM_ID], [GRP_ID], [OND_ID], [COM_VINCO1_OND], [COM_VINCO2_OND], [COM_VINCO3_OND], [COM_VINCO4_OND], [COM_VINCO5_OND], [COM_VINCO6_OND], [COM_VINCO7_OND], [COM_VINCO8_OND], [COM_VINCO9_OND], [COM_VINCO10_OND], [COM_VINCO1_CONVERSAO], [COM_VINCO2_CONVERSAO], [COM_VINCO3_CONVERSAO], [COM_VINCO4_CONVERSAO], [COM_VINCO5_CONVERSAO], [COM_VINCO6_CONVERSAO], [COM_VINCO7_CONVERSAO], [COM_VINCO8_CONVERSAO], [COM_VINCO9_CONVERSAO], [COM_VINCO10_CONVERSAO], [TenantID], [Deleted], [Changed], [UserId] FROM [Compensacao] ";
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
            this.Query = $"SELECT [Id], [COM_ID], [GRP_ID], [OND_ID], [COM_VINCO1_OND], [COM_VINCO2_OND], [COM_VINCO3_OND], [COM_VINCO4_OND], [COM_VINCO5_OND], [COM_VINCO6_OND], [COM_VINCO7_OND], [COM_VINCO8_OND], [COM_VINCO9_OND], [COM_VINCO10_OND], [COM_VINCO1_CONVERSAO], [COM_VINCO2_CONVERSAO], [COM_VINCO3_CONVERSAO], [COM_VINCO4_CONVERSAO], [COM_VINCO5_CONVERSAO], [COM_VINCO6_CONVERSAO], [COM_VINCO7_CONVERSAO], [COM_VINCO8_CONVERSAO], [COM_VINCO9_CONVERSAO], [COM_VINCO10_CONVERSAO], [TenantID], [Deleted], [Changed], [UserId] FROM [Compensacao] ";
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
            this.Query = $"SELECT [Id], [COM_ID], [GRP_ID], [OND_ID], [COM_VINCO1_OND], [COM_VINCO2_OND], [COM_VINCO3_OND], [COM_VINCO4_OND], [COM_VINCO5_OND], [COM_VINCO6_OND], [COM_VINCO7_OND], [COM_VINCO8_OND], [COM_VINCO9_OND], [COM_VINCO10_OND], [COM_VINCO1_CONVERSAO], [COM_VINCO2_CONVERSAO], [COM_VINCO3_CONVERSAO], [COM_VINCO4_CONVERSAO], [COM_VINCO5_CONVERSAO], [COM_VINCO6_CONVERSAO], [COM_VINCO7_CONVERSAO], [COM_VINCO8_CONVERSAO], [COM_VINCO9_CONVERSAO], [COM_VINCO10_CONVERSAO], [TenantID], [Deleted], [Changed], [UserId] FROM [Compensacao] ";
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