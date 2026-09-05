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
    public class TipoTesteQueryRead : QueryBase, ITipoTesteQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public TipoTesteQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel TipoTesteQuery(Command.Read.TipoTesteReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select [TT_ESPECIFICACAO], [TT_ORIGEM_ESPECIFICACAO], [TT_IMPRIME_NO_LAUDO], [TenantID], [Deleted], [Changed], [UserId], [TT_ID], [TT_NOME], [TT_DESC], [TT_TOL_MAIS], [TT_TOL_MENOS], [TT_NORMA], [TT_INICIO_PROCESSO], [TA_ID], [UNI_ID], [TT_N_AMOSTRAS_P_TESTE], [TT_MAX_DEF_CRITICO], [TT_MAX_DEF_GRAVE] from [TipoTeste] ";
if (!string.IsNullOrEmpty(Command.TT_ORIGEM_ESPECIFICACAO)) dict["TT_ORIGEM_ESPECIFICACAO"] = $"%{Command.TT_ORIGEM_ESPECIFICACAO}%";
if (!string.IsNullOrEmpty(Command.TT_ORIGEM_ESPECIFICACAO)) whereClauses.Add($"[TT_ORIGEM_ESPECIFICACAO] like @TT_ORIGEM_ESPECIFICACAO");
if (!string.IsNullOrEmpty(Command.TT_IMPRIME_NO_LAUDO)) dict["TT_IMPRIME_NO_LAUDO"] = $"%{Command.TT_IMPRIME_NO_LAUDO}%";
if (!string.IsNullOrEmpty(Command.TT_IMPRIME_NO_LAUDO)) whereClauses.Add($"[TT_IMPRIME_NO_LAUDO] like @TT_IMPRIME_NO_LAUDO");
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
if (Command.UserId.HasValue) dict["UserId"] = Command.UserId.Value;
if (Command.UserId.HasValue) whereClauses.Add($"[UserId] = @UserId");
if (Command.TT_ID.HasValue) dict["TT_ID"] = Command.TT_ID.Value;
if (Command.TT_ID.HasValue) whereClauses.Add($"[TT_ID] = @TT_ID");
if (!string.IsNullOrEmpty(Command.TT_NOME)) dict["TT_NOME"] = $"%{Command.TT_NOME}%";
if (!string.IsNullOrEmpty(Command.TT_NOME)) whereClauses.Add($"[TT_NOME] like @TT_NOME");
if (!string.IsNullOrEmpty(Command.TT_DESC)) dict["TT_DESC"] = $"%{Command.TT_DESC}%";
if (!string.IsNullOrEmpty(Command.TT_DESC)) whereClauses.Add($"[TT_DESC] like @TT_DESC");
if (!string.IsNullOrEmpty(Command.TT_NORMA)) dict["TT_NORMA"] = $"%{Command.TT_NORMA}%";
if (!string.IsNullOrEmpty(Command.TT_NORMA)) whereClauses.Add($"[TT_NORMA] like @TT_NORMA");
if (!string.IsNullOrEmpty(Command.TT_INICIO_PROCESSO)) dict["TT_INICIO_PROCESSO"] = $"%{Command.TT_INICIO_PROCESSO}%";
if (!string.IsNullOrEmpty(Command.TT_INICIO_PROCESSO)) whereClauses.Add($"[TT_INICIO_PROCESSO] like @TT_INICIO_PROCESSO");
if (Command.TA_ID.HasValue) dict["TA_ID"] = Command.TA_ID.Value;
if (Command.TA_ID.HasValue) whereClauses.Add($"[TA_ID] = @TA_ID");
if (!string.IsNullOrEmpty(Command.UNI_ID)) dict["UNI_ID"] = $"%{Command.UNI_ID}%";
if (!string.IsNullOrEmpty(Command.UNI_ID)) whereClauses.Add($"[UNI_ID] like @UNI_ID");
if (Command.TT_N_AMOSTRAS_P_TESTE.HasValue) dict["TT_N_AMOSTRAS_P_TESTE"] = Command.TT_N_AMOSTRAS_P_TESTE.Value;
if (Command.TT_N_AMOSTRAS_P_TESTE.HasValue) whereClauses.Add($"[TT_N_AMOSTRAS_P_TESTE] = @TT_N_AMOSTRAS_P_TESTE");
if (Command.TT_MAX_DEF_CRITICO.HasValue) dict["TT_MAX_DEF_CRITICO"] = Command.TT_MAX_DEF_CRITICO.Value;
if (Command.TT_MAX_DEF_CRITICO.HasValue) whereClauses.Add($"[TT_MAX_DEF_CRITICO] = @TT_MAX_DEF_CRITICO");
if (Command.TT_MAX_DEF_GRAVE.HasValue) dict["TT_MAX_DEF_GRAVE"] = Command.TT_MAX_DEF_GRAVE.Value;
if (Command.TT_MAX_DEF_GRAVE.HasValue) whereClauses.Add($"[TT_MAX_DEF_GRAVE] = @TT_MAX_DEF_GRAVE");
            if (whereClauses.Any()) 
                 this.Query += $" WHERE {string.Join(" AND ", whereClauses)}"; 
            int page = Command.Paginacao?.Page ?? 1;
            int pageSize = Command.Paginacao?.PageSize ?? 20;
            int offset = (page - 1) * pageSize;
            dict["Offset"] = offset;
            dict["PageSize"] = pageSize;
            Query += " ORDER BY [TT_ID] OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel TipoTesteTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel TipoTesteUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel TipoTesteTA_IDQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select [TA_ID] from [TipoAvaliacao] ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["TA_ID"] = numero; //01
                      whereClauses.Add($" [TA_ID] = @TA_ID");//01 
                 }
                 else 
                 {
                      dict["TA_ID"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" [TA_ID] like @TA_ID ");//02
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
        public QueryModel ExistsByTT_ESPECIFICACAOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TipoTeste] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TT_ESPECIFICACAO"] = value; //04
                      whereClauses.Add($" [TT_ESPECIFICACAO] = @TT_ESPECIFICACAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTT_ORIGEM_ESPECIFICACAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TipoTeste] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TT_ORIGEM_ESPECIFICACAO"] = value; //04
                      whereClauses.Add($" [TT_ORIGEM_ESPECIFICACAO] = @TT_ORIGEM_ESPECIFICACAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTT_IMPRIME_NO_LAUDOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TipoTeste] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TT_IMPRIME_NO_LAUDO"] = value; //04
                      whereClauses.Add($" [TT_IMPRIME_NO_LAUDO] = @TT_IMPRIME_NO_LAUDO ");//04
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
            this.Query = $"SELECT 1 FROM [TipoTeste] ";
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
            this.Query = $"SELECT 1 FROM [TipoTeste] ";
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
            this.Query = $"SELECT 1 FROM [TipoTeste] ";
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
            this.Query = $"SELECT 1 FROM [TipoTeste] ";
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
        public QueryModel ExistsByTT_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TipoTeste] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TT_ID"] = value; //04
                      whereClauses.Add($" [TT_ID] = @TT_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTT_NOMEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TipoTeste] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TT_NOME"] = value; //04
                      whereClauses.Add($" [TT_NOME] = @TT_NOME ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTT_DESCQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TipoTeste] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TT_DESC"] = value; //04
                      whereClauses.Add($" [TT_DESC] = @TT_DESC ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTT_TOL_MAISQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TipoTeste] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TT_TOL_MAIS"] = value; //04
                      whereClauses.Add($" [TT_TOL_MAIS] = @TT_TOL_MAIS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTT_TOL_MENOSQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TipoTeste] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TT_TOL_MENOS"] = value; //04
                      whereClauses.Add($" [TT_TOL_MENOS] = @TT_TOL_MENOS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTT_NORMAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TipoTeste] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TT_NORMA"] = value; //04
                      whereClauses.Add($" [TT_NORMA] = @TT_NORMA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTT_INICIO_PROCESSOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TipoTeste] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TT_INICIO_PROCESSO"] = value; //04
                      whereClauses.Add($" [TT_INICIO_PROCESSO] = @TT_INICIO_PROCESSO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTA_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TipoTeste] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TA_ID"] = value; //04
                      whereClauses.Add($" [TA_ID] = @TA_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByUNI_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TipoTeste] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["UNI_ID"] = value; //04
                      whereClauses.Add($" [UNI_ID] = @UNI_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTT_N_AMOSTRAS_P_TESTEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TipoTeste] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TT_N_AMOSTRAS_P_TESTE"] = value; //04
                      whereClauses.Add($" [TT_N_AMOSTRAS_P_TESTE] = @TT_N_AMOSTRAS_P_TESTE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTT_MAX_DEF_CRITICOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TipoTeste] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TT_MAX_DEF_CRITICO"] = value; //04
                      whereClauses.Add($" [TT_MAX_DEF_CRITICO] = @TT_MAX_DEF_CRITICO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTT_MAX_DEF_GRAVEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TipoTeste] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TT_MAX_DEF_GRAVE"] = value; //04
                      whereClauses.Add($" [TT_MAX_DEF_GRAVE] = @TT_MAX_DEF_GRAVE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTT_ESPECIFICACAOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TT_ESPECIFICACAO], [TT_ORIGEM_ESPECIFICACAO], [TT_IMPRIME_NO_LAUDO], [TenantID], [Deleted], [Changed], [UserId], [TT_ID], [TT_NOME], [TT_DESC], [TT_TOL_MAIS], [TT_TOL_MENOS], [TT_NORMA], [TT_INICIO_PROCESSO], [TA_ID], [UNI_ID], [TT_N_AMOSTRAS_P_TESTE], [TT_MAX_DEF_CRITICO], [TT_MAX_DEF_GRAVE] FROM [TipoTeste] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TT_ESPECIFICACAO"] = value; //06
                      whereClauses.Add($" [TT_ESPECIFICACAO] = @TT_ESPECIFICACAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTT_ORIGEM_ESPECIFICACAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TT_ESPECIFICACAO], [TT_ORIGEM_ESPECIFICACAO], [TT_IMPRIME_NO_LAUDO], [TenantID], [Deleted], [Changed], [UserId], [TT_ID], [TT_NOME], [TT_DESC], [TT_TOL_MAIS], [TT_TOL_MENOS], [TT_NORMA], [TT_INICIO_PROCESSO], [TA_ID], [UNI_ID], [TT_N_AMOSTRAS_P_TESTE], [TT_MAX_DEF_CRITICO], [TT_MAX_DEF_GRAVE] FROM [TipoTeste] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TT_ORIGEM_ESPECIFICACAO"] = value; //06
                      whereClauses.Add($" [TT_ORIGEM_ESPECIFICACAO] = @TT_ORIGEM_ESPECIFICACAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTT_IMPRIME_NO_LAUDOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TT_ESPECIFICACAO], [TT_ORIGEM_ESPECIFICACAO], [TT_IMPRIME_NO_LAUDO], [TenantID], [Deleted], [Changed], [UserId], [TT_ID], [TT_NOME], [TT_DESC], [TT_TOL_MAIS], [TT_TOL_MENOS], [TT_NORMA], [TT_INICIO_PROCESSO], [TA_ID], [UNI_ID], [TT_N_AMOSTRAS_P_TESTE], [TT_MAX_DEF_CRITICO], [TT_MAX_DEF_GRAVE] FROM [TipoTeste] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TT_IMPRIME_NO_LAUDO"] = value; //06
                      whereClauses.Add($" [TT_IMPRIME_NO_LAUDO] = @TT_IMPRIME_NO_LAUDO ");//06
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
            this.Query = $"SELECT [TT_ESPECIFICACAO], [TT_ORIGEM_ESPECIFICACAO], [TT_IMPRIME_NO_LAUDO], [TenantID], [Deleted], [Changed], [UserId], [TT_ID], [TT_NOME], [TT_DESC], [TT_TOL_MAIS], [TT_TOL_MENOS], [TT_NORMA], [TT_INICIO_PROCESSO], [TA_ID], [UNI_ID], [TT_N_AMOSTRAS_P_TESTE], [TT_MAX_DEF_CRITICO], [TT_MAX_DEF_GRAVE] FROM [TipoTeste] ";
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
            this.Query = $"SELECT [TT_ESPECIFICACAO], [TT_ORIGEM_ESPECIFICACAO], [TT_IMPRIME_NO_LAUDO], [TenantID], [Deleted], [Changed], [UserId], [TT_ID], [TT_NOME], [TT_DESC], [TT_TOL_MAIS], [TT_TOL_MENOS], [TT_NORMA], [TT_INICIO_PROCESSO], [TA_ID], [UNI_ID], [TT_N_AMOSTRAS_P_TESTE], [TT_MAX_DEF_CRITICO], [TT_MAX_DEF_GRAVE] FROM [TipoTeste] ";
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
            this.Query = $"SELECT [TT_ESPECIFICACAO], [TT_ORIGEM_ESPECIFICACAO], [TT_IMPRIME_NO_LAUDO], [TenantID], [Deleted], [Changed], [UserId], [TT_ID], [TT_NOME], [TT_DESC], [TT_TOL_MAIS], [TT_TOL_MENOS], [TT_NORMA], [TT_INICIO_PROCESSO], [TA_ID], [UNI_ID], [TT_N_AMOSTRAS_P_TESTE], [TT_MAX_DEF_CRITICO], [TT_MAX_DEF_GRAVE] FROM [TipoTeste] ";
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
            this.Query = $"SELECT [TT_ESPECIFICACAO], [TT_ORIGEM_ESPECIFICACAO], [TT_IMPRIME_NO_LAUDO], [TenantID], [Deleted], [Changed], [UserId], [TT_ID], [TT_NOME], [TT_DESC], [TT_TOL_MAIS], [TT_TOL_MENOS], [TT_NORMA], [TT_INICIO_PROCESSO], [TA_ID], [UNI_ID], [TT_N_AMOSTRAS_P_TESTE], [TT_MAX_DEF_CRITICO], [TT_MAX_DEF_GRAVE] FROM [TipoTeste] ";
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
        public QueryModel FirstByTT_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TT_ESPECIFICACAO], [TT_ORIGEM_ESPECIFICACAO], [TT_IMPRIME_NO_LAUDO], [TenantID], [Deleted], [Changed], [UserId], [TT_ID], [TT_NOME], [TT_DESC], [TT_TOL_MAIS], [TT_TOL_MENOS], [TT_NORMA], [TT_INICIO_PROCESSO], [TA_ID], [UNI_ID], [TT_N_AMOSTRAS_P_TESTE], [TT_MAX_DEF_CRITICO], [TT_MAX_DEF_GRAVE] FROM [TipoTeste] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TT_ID"] = value; //06
                      whereClauses.Add($" [TT_ID] = @TT_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTT_NOMEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TT_ESPECIFICACAO], [TT_ORIGEM_ESPECIFICACAO], [TT_IMPRIME_NO_LAUDO], [TenantID], [Deleted], [Changed], [UserId], [TT_ID], [TT_NOME], [TT_DESC], [TT_TOL_MAIS], [TT_TOL_MENOS], [TT_NORMA], [TT_INICIO_PROCESSO], [TA_ID], [UNI_ID], [TT_N_AMOSTRAS_P_TESTE], [TT_MAX_DEF_CRITICO], [TT_MAX_DEF_GRAVE] FROM [TipoTeste] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TT_NOME"] = value; //06
                      whereClauses.Add($" [TT_NOME] = @TT_NOME ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTT_DESCQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TT_ESPECIFICACAO], [TT_ORIGEM_ESPECIFICACAO], [TT_IMPRIME_NO_LAUDO], [TenantID], [Deleted], [Changed], [UserId], [TT_ID], [TT_NOME], [TT_DESC], [TT_TOL_MAIS], [TT_TOL_MENOS], [TT_NORMA], [TT_INICIO_PROCESSO], [TA_ID], [UNI_ID], [TT_N_AMOSTRAS_P_TESTE], [TT_MAX_DEF_CRITICO], [TT_MAX_DEF_GRAVE] FROM [TipoTeste] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TT_DESC"] = value; //06
                      whereClauses.Add($" [TT_DESC] = @TT_DESC ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTT_TOL_MAISQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TT_ESPECIFICACAO], [TT_ORIGEM_ESPECIFICACAO], [TT_IMPRIME_NO_LAUDO], [TenantID], [Deleted], [Changed], [UserId], [TT_ID], [TT_NOME], [TT_DESC], [TT_TOL_MAIS], [TT_TOL_MENOS], [TT_NORMA], [TT_INICIO_PROCESSO], [TA_ID], [UNI_ID], [TT_N_AMOSTRAS_P_TESTE], [TT_MAX_DEF_CRITICO], [TT_MAX_DEF_GRAVE] FROM [TipoTeste] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TT_TOL_MAIS"] = value; //06
                      whereClauses.Add($" [TT_TOL_MAIS] = @TT_TOL_MAIS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTT_TOL_MENOSQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TT_ESPECIFICACAO], [TT_ORIGEM_ESPECIFICACAO], [TT_IMPRIME_NO_LAUDO], [TenantID], [Deleted], [Changed], [UserId], [TT_ID], [TT_NOME], [TT_DESC], [TT_TOL_MAIS], [TT_TOL_MENOS], [TT_NORMA], [TT_INICIO_PROCESSO], [TA_ID], [UNI_ID], [TT_N_AMOSTRAS_P_TESTE], [TT_MAX_DEF_CRITICO], [TT_MAX_DEF_GRAVE] FROM [TipoTeste] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TT_TOL_MENOS"] = value; //06
                      whereClauses.Add($" [TT_TOL_MENOS] = @TT_TOL_MENOS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTT_NORMAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TT_ESPECIFICACAO], [TT_ORIGEM_ESPECIFICACAO], [TT_IMPRIME_NO_LAUDO], [TenantID], [Deleted], [Changed], [UserId], [TT_ID], [TT_NOME], [TT_DESC], [TT_TOL_MAIS], [TT_TOL_MENOS], [TT_NORMA], [TT_INICIO_PROCESSO], [TA_ID], [UNI_ID], [TT_N_AMOSTRAS_P_TESTE], [TT_MAX_DEF_CRITICO], [TT_MAX_DEF_GRAVE] FROM [TipoTeste] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TT_NORMA"] = value; //06
                      whereClauses.Add($" [TT_NORMA] = @TT_NORMA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTT_INICIO_PROCESSOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TT_ESPECIFICACAO], [TT_ORIGEM_ESPECIFICACAO], [TT_IMPRIME_NO_LAUDO], [TenantID], [Deleted], [Changed], [UserId], [TT_ID], [TT_NOME], [TT_DESC], [TT_TOL_MAIS], [TT_TOL_MENOS], [TT_NORMA], [TT_INICIO_PROCESSO], [TA_ID], [UNI_ID], [TT_N_AMOSTRAS_P_TESTE], [TT_MAX_DEF_CRITICO], [TT_MAX_DEF_GRAVE] FROM [TipoTeste] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TT_INICIO_PROCESSO"] = value; //06
                      whereClauses.Add($" [TT_INICIO_PROCESSO] = @TT_INICIO_PROCESSO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTA_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TT_ESPECIFICACAO], [TT_ORIGEM_ESPECIFICACAO], [TT_IMPRIME_NO_LAUDO], [TenantID], [Deleted], [Changed], [UserId], [TT_ID], [TT_NOME], [TT_DESC], [TT_TOL_MAIS], [TT_TOL_MENOS], [TT_NORMA], [TT_INICIO_PROCESSO], [TA_ID], [UNI_ID], [TT_N_AMOSTRAS_P_TESTE], [TT_MAX_DEF_CRITICO], [TT_MAX_DEF_GRAVE] FROM [TipoTeste] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TA_ID"] = value; //06
                      whereClauses.Add($" [TA_ID] = @TA_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByUNI_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TT_ESPECIFICACAO], [TT_ORIGEM_ESPECIFICACAO], [TT_IMPRIME_NO_LAUDO], [TenantID], [Deleted], [Changed], [UserId], [TT_ID], [TT_NOME], [TT_DESC], [TT_TOL_MAIS], [TT_TOL_MENOS], [TT_NORMA], [TT_INICIO_PROCESSO], [TA_ID], [UNI_ID], [TT_N_AMOSTRAS_P_TESTE], [TT_MAX_DEF_CRITICO], [TT_MAX_DEF_GRAVE] FROM [TipoTeste] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["UNI_ID"] = value; //06
                      whereClauses.Add($" [UNI_ID] = @UNI_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTT_N_AMOSTRAS_P_TESTEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TT_ESPECIFICACAO], [TT_ORIGEM_ESPECIFICACAO], [TT_IMPRIME_NO_LAUDO], [TenantID], [Deleted], [Changed], [UserId], [TT_ID], [TT_NOME], [TT_DESC], [TT_TOL_MAIS], [TT_TOL_MENOS], [TT_NORMA], [TT_INICIO_PROCESSO], [TA_ID], [UNI_ID], [TT_N_AMOSTRAS_P_TESTE], [TT_MAX_DEF_CRITICO], [TT_MAX_DEF_GRAVE] FROM [TipoTeste] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TT_N_AMOSTRAS_P_TESTE"] = value; //06
                      whereClauses.Add($" [TT_N_AMOSTRAS_P_TESTE] = @TT_N_AMOSTRAS_P_TESTE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTT_MAX_DEF_CRITICOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TT_ESPECIFICACAO], [TT_ORIGEM_ESPECIFICACAO], [TT_IMPRIME_NO_LAUDO], [TenantID], [Deleted], [Changed], [UserId], [TT_ID], [TT_NOME], [TT_DESC], [TT_TOL_MAIS], [TT_TOL_MENOS], [TT_NORMA], [TT_INICIO_PROCESSO], [TA_ID], [UNI_ID], [TT_N_AMOSTRAS_P_TESTE], [TT_MAX_DEF_CRITICO], [TT_MAX_DEF_GRAVE] FROM [TipoTeste] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TT_MAX_DEF_CRITICO"] = value; //06
                      whereClauses.Add($" [TT_MAX_DEF_CRITICO] = @TT_MAX_DEF_CRITICO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTT_MAX_DEF_GRAVEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TT_ESPECIFICACAO], [TT_ORIGEM_ESPECIFICACAO], [TT_IMPRIME_NO_LAUDO], [TenantID], [Deleted], [Changed], [UserId], [TT_ID], [TT_NOME], [TT_DESC], [TT_TOL_MAIS], [TT_TOL_MENOS], [TT_NORMA], [TT_INICIO_PROCESSO], [TA_ID], [UNI_ID], [TT_N_AMOSTRAS_P_TESTE], [TT_MAX_DEF_CRITICO], [TT_MAX_DEF_GRAVE] FROM [TipoTeste] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TT_MAX_DEF_GRAVE"] = value; //06
                      whereClauses.Add($" [TT_MAX_DEF_GRAVE] = @TT_MAX_DEF_GRAVE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration