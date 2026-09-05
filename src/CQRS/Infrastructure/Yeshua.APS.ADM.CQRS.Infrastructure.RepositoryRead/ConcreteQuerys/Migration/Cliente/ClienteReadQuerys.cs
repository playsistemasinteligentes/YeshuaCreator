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
    public class ClienteQueryRead : QueryBase, IClienteQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public ClienteQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel ClienteQuery(Command.Read.ClienteReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select [CLI_ID], [CLI_NOME], [CLI_FONE], [CLI_OBS], [CLI_ENDERECO_ENTREGA], [CLI_CPF_CNPJ], [CLI_BAIRRO_ENTREGA], [CLI_CEP_ENTREGA], [CLI_EMAIL], [CLI_INTEGRACAO], [MUN_ID_ENTREGA], [CLI_TRANSLADO], [CLI_REGIAO_ENTREGA], [CLI_EXIGENTE_NA_IMPRESSAO], [CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO], [CLI_TEMPO_DESCARREGAMENTO_UNITARIO], [CLI_PERCENTUAL_JANELA_EMBARQUE], [REP_ID], [CLI_RAZAO_SOCIAL], [CLI_EMAIL_MONITORAMENTO_TRANSPORTE], [CLI_CONTATO], [CLI_SETOR], [SEG_ID], [CLI_TIPO], [CLI_INTEGRACAO_ERP], [CLI_LATITUDE_ENTREGA], [CLI_LONGITUDE_ENTREGA], [TenantID], [Deleted], [Changed], [UserId] from [Cliente] ";
if (!string.IsNullOrEmpty(Command.CLI_ID)) dict["CLI_ID"] = $"%{Command.CLI_ID}%";
if (!string.IsNullOrEmpty(Command.CLI_ID)) whereClauses.Add($"[CLI_ID] like @CLI_ID");
if (!string.IsNullOrEmpty(Command.CLI_NOME)) dict["CLI_NOME"] = $"%{Command.CLI_NOME}%";
if (!string.IsNullOrEmpty(Command.CLI_NOME)) whereClauses.Add($"[CLI_NOME] like @CLI_NOME");
if (!string.IsNullOrEmpty(Command.CLI_FONE)) dict["CLI_FONE"] = $"%{Command.CLI_FONE}%";
if (!string.IsNullOrEmpty(Command.CLI_FONE)) whereClauses.Add($"[CLI_FONE] like @CLI_FONE");
if (!string.IsNullOrEmpty(Command.CLI_OBS)) dict["CLI_OBS"] = $"%{Command.CLI_OBS}%";
if (!string.IsNullOrEmpty(Command.CLI_OBS)) whereClauses.Add($"[CLI_OBS] like @CLI_OBS");
if (!string.IsNullOrEmpty(Command.CLI_ENDERECO_ENTREGA)) dict["CLI_ENDERECO_ENTREGA"] = $"%{Command.CLI_ENDERECO_ENTREGA}%";
if (!string.IsNullOrEmpty(Command.CLI_ENDERECO_ENTREGA)) whereClauses.Add($"[CLI_ENDERECO_ENTREGA] like @CLI_ENDERECO_ENTREGA");
if (!string.IsNullOrEmpty(Command.CLI_CPF_CNPJ)) dict["CLI_CPF_CNPJ"] = $"%{Command.CLI_CPF_CNPJ}%";
if (!string.IsNullOrEmpty(Command.CLI_CPF_CNPJ)) whereClauses.Add($"[CLI_CPF_CNPJ] like @CLI_CPF_CNPJ");
if (!string.IsNullOrEmpty(Command.CLI_BAIRRO_ENTREGA)) dict["CLI_BAIRRO_ENTREGA"] = $"%{Command.CLI_BAIRRO_ENTREGA}%";
if (!string.IsNullOrEmpty(Command.CLI_BAIRRO_ENTREGA)) whereClauses.Add($"[CLI_BAIRRO_ENTREGA] like @CLI_BAIRRO_ENTREGA");
if (!string.IsNullOrEmpty(Command.CLI_CEP_ENTREGA)) dict["CLI_CEP_ENTREGA"] = $"%{Command.CLI_CEP_ENTREGA}%";
if (!string.IsNullOrEmpty(Command.CLI_CEP_ENTREGA)) whereClauses.Add($"[CLI_CEP_ENTREGA] like @CLI_CEP_ENTREGA");
if (!string.IsNullOrEmpty(Command.CLI_EMAIL)) dict["CLI_EMAIL"] = $"%{Command.CLI_EMAIL}%";
if (!string.IsNullOrEmpty(Command.CLI_EMAIL)) whereClauses.Add($"[CLI_EMAIL] like @CLI_EMAIL");
if (!string.IsNullOrEmpty(Command.CLI_INTEGRACAO)) dict["CLI_INTEGRACAO"] = $"%{Command.CLI_INTEGRACAO}%";
if (!string.IsNullOrEmpty(Command.CLI_INTEGRACAO)) whereClauses.Add($"[CLI_INTEGRACAO] like @CLI_INTEGRACAO");
if (!string.IsNullOrEmpty(Command.MUN_ID_ENTREGA)) dict["MUN_ID_ENTREGA"] = $"%{Command.MUN_ID_ENTREGA}%";
if (!string.IsNullOrEmpty(Command.MUN_ID_ENTREGA)) whereClauses.Add($"[MUN_ID_ENTREGA] like @MUN_ID_ENTREGA");
if (!string.IsNullOrEmpty(Command.CLI_REGIAO_ENTREGA)) dict["CLI_REGIAO_ENTREGA"] = $"%{Command.CLI_REGIAO_ENTREGA}%";
if (!string.IsNullOrEmpty(Command.CLI_REGIAO_ENTREGA)) whereClauses.Add($"[CLI_REGIAO_ENTREGA] like @CLI_REGIAO_ENTREGA");
if (Command.CLI_EXIGENTE_NA_IMPRESSAO.HasValue) dict["CLI_EXIGENTE_NA_IMPRESSAO"] = Command.CLI_EXIGENTE_NA_IMPRESSAO.Value;
if (Command.CLI_EXIGENTE_NA_IMPRESSAO.HasValue) whereClauses.Add($"[CLI_EXIGENTE_NA_IMPRESSAO] = @CLI_EXIGENTE_NA_IMPRESSAO");
if (!string.IsNullOrEmpty(Command.REP_ID)) dict["REP_ID"] = $"%{Command.REP_ID}%";
if (!string.IsNullOrEmpty(Command.REP_ID)) whereClauses.Add($"[REP_ID] like @REP_ID");
if (!string.IsNullOrEmpty(Command.CLI_RAZAO_SOCIAL)) dict["CLI_RAZAO_SOCIAL"] = $"%{Command.CLI_RAZAO_SOCIAL}%";
if (!string.IsNullOrEmpty(Command.CLI_RAZAO_SOCIAL)) whereClauses.Add($"[CLI_RAZAO_SOCIAL] like @CLI_RAZAO_SOCIAL");
if (!string.IsNullOrEmpty(Command.CLI_EMAIL_MONITORAMENTO_TRANSPORTE)) dict["CLI_EMAIL_MONITORAMENTO_TRANSPORTE"] = $"%{Command.CLI_EMAIL_MONITORAMENTO_TRANSPORTE}%";
if (!string.IsNullOrEmpty(Command.CLI_EMAIL_MONITORAMENTO_TRANSPORTE)) whereClauses.Add($"[CLI_EMAIL_MONITORAMENTO_TRANSPORTE] like @CLI_EMAIL_MONITORAMENTO_TRANSPORTE");
if (!string.IsNullOrEmpty(Command.CLI_CONTATO)) dict["CLI_CONTATO"] = $"%{Command.CLI_CONTATO}%";
if (!string.IsNullOrEmpty(Command.CLI_CONTATO)) whereClauses.Add($"[CLI_CONTATO] like @CLI_CONTATO");
if (!string.IsNullOrEmpty(Command.CLI_SETOR)) dict["CLI_SETOR"] = $"%{Command.CLI_SETOR}%";
if (!string.IsNullOrEmpty(Command.CLI_SETOR)) whereClauses.Add($"[CLI_SETOR] like @CLI_SETOR");
if (!string.IsNullOrEmpty(Command.SEG_ID)) dict["SEG_ID"] = $"%{Command.SEG_ID}%";
if (!string.IsNullOrEmpty(Command.SEG_ID)) whereClauses.Add($"[SEG_ID] like @SEG_ID");
if (!string.IsNullOrEmpty(Command.CLI_TIPO)) dict["CLI_TIPO"] = $"%{Command.CLI_TIPO}%";
if (!string.IsNullOrEmpty(Command.CLI_TIPO)) whereClauses.Add($"[CLI_TIPO] like @CLI_TIPO");
if (!string.IsNullOrEmpty(Command.CLI_INTEGRACAO_ERP)) dict["CLI_INTEGRACAO_ERP"] = $"%{Command.CLI_INTEGRACAO_ERP}%";
if (!string.IsNullOrEmpty(Command.CLI_INTEGRACAO_ERP)) whereClauses.Add($"[CLI_INTEGRACAO_ERP] like @CLI_INTEGRACAO_ERP");
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
            Query += " ORDER BY [CLI_ID] OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel ClienteMUN_ID_ENTREGAQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select [MUN_ID] from [Municipio] ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["MUN_ID"] = numero; //01
                      whereClauses.Add($" [MUN_ID] = @MUN_ID");//01 
                 }
                 else 
                 {
                      dict["MUN_ID"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" [MUN_ID] like @MUN_ID ");//02
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
        public QueryModel ClienteTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel ClienteUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel ExistsByCLI_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_ID"] = value; //04
                      whereClauses.Add($" [CLI_ID] = @CLI_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCLI_NOMEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_NOME"] = value; //04
                      whereClauses.Add($" [CLI_NOME] = @CLI_NOME ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCLI_FONEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_FONE"] = value; //04
                      whereClauses.Add($" [CLI_FONE] = @CLI_FONE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCLI_OBSQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_OBS"] = value; //04
                      whereClauses.Add($" [CLI_OBS] = @CLI_OBS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCLI_ENDERECO_ENTREGAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_ENDERECO_ENTREGA"] = value; //04
                      whereClauses.Add($" [CLI_ENDERECO_ENTREGA] = @CLI_ENDERECO_ENTREGA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCLI_CPF_CNPJQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_CPF_CNPJ"] = value; //04
                      whereClauses.Add($" [CLI_CPF_CNPJ] = @CLI_CPF_CNPJ ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCLI_BAIRRO_ENTREGAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_BAIRRO_ENTREGA"] = value; //04
                      whereClauses.Add($" [CLI_BAIRRO_ENTREGA] = @CLI_BAIRRO_ENTREGA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCLI_CEP_ENTREGAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_CEP_ENTREGA"] = value; //04
                      whereClauses.Add($" [CLI_CEP_ENTREGA] = @CLI_CEP_ENTREGA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCLI_EMAILQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_EMAIL"] = value; //04
                      whereClauses.Add($" [CLI_EMAIL] = @CLI_EMAIL ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCLI_INTEGRACAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_INTEGRACAO"] = value; //04
                      whereClauses.Add($" [CLI_INTEGRACAO] = @CLI_INTEGRACAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMUN_ID_ENTREGAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MUN_ID_ENTREGA"] = value; //04
                      whereClauses.Add($" [MUN_ID_ENTREGA] = @MUN_ID_ENTREGA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCLI_TRANSLADOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_TRANSLADO"] = value; //04
                      whereClauses.Add($" [CLI_TRANSLADO] = @CLI_TRANSLADO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCLI_REGIAO_ENTREGAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_REGIAO_ENTREGA"] = value; //04
                      whereClauses.Add($" [CLI_REGIAO_ENTREGA] = @CLI_REGIAO_ENTREGA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCLI_EXIGENTE_NA_IMPRESSAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_EXIGENTE_NA_IMPRESSAO"] = value; //04
                      whereClauses.Add($" [CLI_EXIGENTE_NA_IMPRESSAO] = @CLI_EXIGENTE_NA_IMPRESSAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO"] = value; //04
                      whereClauses.Add($" [CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO] = @CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCLI_TEMPO_DESCARREGAMENTO_UNITARIOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_TEMPO_DESCARREGAMENTO_UNITARIO"] = value; //04
                      whereClauses.Add($" [CLI_TEMPO_DESCARREGAMENTO_UNITARIO] = @CLI_TEMPO_DESCARREGAMENTO_UNITARIO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCLI_PERCENTUAL_JANELA_EMBARQUEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_PERCENTUAL_JANELA_EMBARQUE"] = value; //04
                      whereClauses.Add($" [CLI_PERCENTUAL_JANELA_EMBARQUE] = @CLI_PERCENTUAL_JANELA_EMBARQUE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByREP_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["REP_ID"] = value; //04
                      whereClauses.Add($" [REP_ID] = @REP_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCLI_RAZAO_SOCIALQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_RAZAO_SOCIAL"] = value; //04
                      whereClauses.Add($" [CLI_RAZAO_SOCIAL] = @CLI_RAZAO_SOCIAL ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCLI_EMAIL_MONITORAMENTO_TRANSPORTEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_EMAIL_MONITORAMENTO_TRANSPORTE"] = value; //04
                      whereClauses.Add($" [CLI_EMAIL_MONITORAMENTO_TRANSPORTE] = @CLI_EMAIL_MONITORAMENTO_TRANSPORTE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCLI_CONTATOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_CONTATO"] = value; //04
                      whereClauses.Add($" [CLI_CONTATO] = @CLI_CONTATO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCLI_SETORQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_SETOR"] = value; //04
                      whereClauses.Add($" [CLI_SETOR] = @CLI_SETOR ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsBySEG_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["SEG_ID"] = value; //04
                      whereClauses.Add($" [SEG_ID] = @SEG_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCLI_TIPOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_TIPO"] = value; //04
                      whereClauses.Add($" [CLI_TIPO] = @CLI_TIPO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCLI_INTEGRACAO_ERPQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_INTEGRACAO_ERP"] = value; //04
                      whereClauses.Add($" [CLI_INTEGRACAO_ERP] = @CLI_INTEGRACAO_ERP ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCLI_LATITUDE_ENTREGAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_LATITUDE_ENTREGA"] = value; //04
                      whereClauses.Add($" [CLI_LATITUDE_ENTREGA] = @CLI_LATITUDE_ENTREGA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCLI_LONGITUDE_ENTREGAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_LONGITUDE_ENTREGA"] = value; //04
                      whereClauses.Add($" [CLI_LONGITUDE_ENTREGA] = @CLI_LONGITUDE_ENTREGA ");//04
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
            this.Query = $"SELECT 1 FROM [Cliente] ";
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
            this.Query = $"SELECT 1 FROM [Cliente] ";
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
            this.Query = $"SELECT 1 FROM [Cliente] ";
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
            this.Query = $"SELECT 1 FROM [Cliente] ";
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
        public QueryModel FirstByCLI_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [CLI_ID], [CLI_NOME], [CLI_FONE], [CLI_OBS], [CLI_ENDERECO_ENTREGA], [CLI_CPF_CNPJ], [CLI_BAIRRO_ENTREGA], [CLI_CEP_ENTREGA], [CLI_EMAIL], [CLI_INTEGRACAO], [MUN_ID_ENTREGA], [CLI_TRANSLADO], [CLI_REGIAO_ENTREGA], [CLI_EXIGENTE_NA_IMPRESSAO], [CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO], [CLI_TEMPO_DESCARREGAMENTO_UNITARIO], [CLI_PERCENTUAL_JANELA_EMBARQUE], [REP_ID], [CLI_RAZAO_SOCIAL], [CLI_EMAIL_MONITORAMENTO_TRANSPORTE], [CLI_CONTATO], [CLI_SETOR], [SEG_ID], [CLI_TIPO], [CLI_INTEGRACAO_ERP], [CLI_LATITUDE_ENTREGA], [CLI_LONGITUDE_ENTREGA], [TenantID], [Deleted], [Changed], [UserId] FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_ID"] = value; //06
                      whereClauses.Add($" [CLI_ID] = @CLI_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCLI_NOMEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [CLI_ID], [CLI_NOME], [CLI_FONE], [CLI_OBS], [CLI_ENDERECO_ENTREGA], [CLI_CPF_CNPJ], [CLI_BAIRRO_ENTREGA], [CLI_CEP_ENTREGA], [CLI_EMAIL], [CLI_INTEGRACAO], [MUN_ID_ENTREGA], [CLI_TRANSLADO], [CLI_REGIAO_ENTREGA], [CLI_EXIGENTE_NA_IMPRESSAO], [CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO], [CLI_TEMPO_DESCARREGAMENTO_UNITARIO], [CLI_PERCENTUAL_JANELA_EMBARQUE], [REP_ID], [CLI_RAZAO_SOCIAL], [CLI_EMAIL_MONITORAMENTO_TRANSPORTE], [CLI_CONTATO], [CLI_SETOR], [SEG_ID], [CLI_TIPO], [CLI_INTEGRACAO_ERP], [CLI_LATITUDE_ENTREGA], [CLI_LONGITUDE_ENTREGA], [TenantID], [Deleted], [Changed], [UserId] FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_NOME"] = value; //06
                      whereClauses.Add($" [CLI_NOME] = @CLI_NOME ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCLI_FONEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [CLI_ID], [CLI_NOME], [CLI_FONE], [CLI_OBS], [CLI_ENDERECO_ENTREGA], [CLI_CPF_CNPJ], [CLI_BAIRRO_ENTREGA], [CLI_CEP_ENTREGA], [CLI_EMAIL], [CLI_INTEGRACAO], [MUN_ID_ENTREGA], [CLI_TRANSLADO], [CLI_REGIAO_ENTREGA], [CLI_EXIGENTE_NA_IMPRESSAO], [CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO], [CLI_TEMPO_DESCARREGAMENTO_UNITARIO], [CLI_PERCENTUAL_JANELA_EMBARQUE], [REP_ID], [CLI_RAZAO_SOCIAL], [CLI_EMAIL_MONITORAMENTO_TRANSPORTE], [CLI_CONTATO], [CLI_SETOR], [SEG_ID], [CLI_TIPO], [CLI_INTEGRACAO_ERP], [CLI_LATITUDE_ENTREGA], [CLI_LONGITUDE_ENTREGA], [TenantID], [Deleted], [Changed], [UserId] FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_FONE"] = value; //06
                      whereClauses.Add($" [CLI_FONE] = @CLI_FONE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCLI_OBSQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [CLI_ID], [CLI_NOME], [CLI_FONE], [CLI_OBS], [CLI_ENDERECO_ENTREGA], [CLI_CPF_CNPJ], [CLI_BAIRRO_ENTREGA], [CLI_CEP_ENTREGA], [CLI_EMAIL], [CLI_INTEGRACAO], [MUN_ID_ENTREGA], [CLI_TRANSLADO], [CLI_REGIAO_ENTREGA], [CLI_EXIGENTE_NA_IMPRESSAO], [CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO], [CLI_TEMPO_DESCARREGAMENTO_UNITARIO], [CLI_PERCENTUAL_JANELA_EMBARQUE], [REP_ID], [CLI_RAZAO_SOCIAL], [CLI_EMAIL_MONITORAMENTO_TRANSPORTE], [CLI_CONTATO], [CLI_SETOR], [SEG_ID], [CLI_TIPO], [CLI_INTEGRACAO_ERP], [CLI_LATITUDE_ENTREGA], [CLI_LONGITUDE_ENTREGA], [TenantID], [Deleted], [Changed], [UserId] FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_OBS"] = value; //06
                      whereClauses.Add($" [CLI_OBS] = @CLI_OBS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCLI_ENDERECO_ENTREGAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [CLI_ID], [CLI_NOME], [CLI_FONE], [CLI_OBS], [CLI_ENDERECO_ENTREGA], [CLI_CPF_CNPJ], [CLI_BAIRRO_ENTREGA], [CLI_CEP_ENTREGA], [CLI_EMAIL], [CLI_INTEGRACAO], [MUN_ID_ENTREGA], [CLI_TRANSLADO], [CLI_REGIAO_ENTREGA], [CLI_EXIGENTE_NA_IMPRESSAO], [CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO], [CLI_TEMPO_DESCARREGAMENTO_UNITARIO], [CLI_PERCENTUAL_JANELA_EMBARQUE], [REP_ID], [CLI_RAZAO_SOCIAL], [CLI_EMAIL_MONITORAMENTO_TRANSPORTE], [CLI_CONTATO], [CLI_SETOR], [SEG_ID], [CLI_TIPO], [CLI_INTEGRACAO_ERP], [CLI_LATITUDE_ENTREGA], [CLI_LONGITUDE_ENTREGA], [TenantID], [Deleted], [Changed], [UserId] FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_ENDERECO_ENTREGA"] = value; //06
                      whereClauses.Add($" [CLI_ENDERECO_ENTREGA] = @CLI_ENDERECO_ENTREGA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCLI_CPF_CNPJQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [CLI_ID], [CLI_NOME], [CLI_FONE], [CLI_OBS], [CLI_ENDERECO_ENTREGA], [CLI_CPF_CNPJ], [CLI_BAIRRO_ENTREGA], [CLI_CEP_ENTREGA], [CLI_EMAIL], [CLI_INTEGRACAO], [MUN_ID_ENTREGA], [CLI_TRANSLADO], [CLI_REGIAO_ENTREGA], [CLI_EXIGENTE_NA_IMPRESSAO], [CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO], [CLI_TEMPO_DESCARREGAMENTO_UNITARIO], [CLI_PERCENTUAL_JANELA_EMBARQUE], [REP_ID], [CLI_RAZAO_SOCIAL], [CLI_EMAIL_MONITORAMENTO_TRANSPORTE], [CLI_CONTATO], [CLI_SETOR], [SEG_ID], [CLI_TIPO], [CLI_INTEGRACAO_ERP], [CLI_LATITUDE_ENTREGA], [CLI_LONGITUDE_ENTREGA], [TenantID], [Deleted], [Changed], [UserId] FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_CPF_CNPJ"] = value; //06
                      whereClauses.Add($" [CLI_CPF_CNPJ] = @CLI_CPF_CNPJ ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCLI_BAIRRO_ENTREGAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [CLI_ID], [CLI_NOME], [CLI_FONE], [CLI_OBS], [CLI_ENDERECO_ENTREGA], [CLI_CPF_CNPJ], [CLI_BAIRRO_ENTREGA], [CLI_CEP_ENTREGA], [CLI_EMAIL], [CLI_INTEGRACAO], [MUN_ID_ENTREGA], [CLI_TRANSLADO], [CLI_REGIAO_ENTREGA], [CLI_EXIGENTE_NA_IMPRESSAO], [CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO], [CLI_TEMPO_DESCARREGAMENTO_UNITARIO], [CLI_PERCENTUAL_JANELA_EMBARQUE], [REP_ID], [CLI_RAZAO_SOCIAL], [CLI_EMAIL_MONITORAMENTO_TRANSPORTE], [CLI_CONTATO], [CLI_SETOR], [SEG_ID], [CLI_TIPO], [CLI_INTEGRACAO_ERP], [CLI_LATITUDE_ENTREGA], [CLI_LONGITUDE_ENTREGA], [TenantID], [Deleted], [Changed], [UserId] FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_BAIRRO_ENTREGA"] = value; //06
                      whereClauses.Add($" [CLI_BAIRRO_ENTREGA] = @CLI_BAIRRO_ENTREGA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCLI_CEP_ENTREGAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [CLI_ID], [CLI_NOME], [CLI_FONE], [CLI_OBS], [CLI_ENDERECO_ENTREGA], [CLI_CPF_CNPJ], [CLI_BAIRRO_ENTREGA], [CLI_CEP_ENTREGA], [CLI_EMAIL], [CLI_INTEGRACAO], [MUN_ID_ENTREGA], [CLI_TRANSLADO], [CLI_REGIAO_ENTREGA], [CLI_EXIGENTE_NA_IMPRESSAO], [CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO], [CLI_TEMPO_DESCARREGAMENTO_UNITARIO], [CLI_PERCENTUAL_JANELA_EMBARQUE], [REP_ID], [CLI_RAZAO_SOCIAL], [CLI_EMAIL_MONITORAMENTO_TRANSPORTE], [CLI_CONTATO], [CLI_SETOR], [SEG_ID], [CLI_TIPO], [CLI_INTEGRACAO_ERP], [CLI_LATITUDE_ENTREGA], [CLI_LONGITUDE_ENTREGA], [TenantID], [Deleted], [Changed], [UserId] FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_CEP_ENTREGA"] = value; //06
                      whereClauses.Add($" [CLI_CEP_ENTREGA] = @CLI_CEP_ENTREGA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCLI_EMAILQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [CLI_ID], [CLI_NOME], [CLI_FONE], [CLI_OBS], [CLI_ENDERECO_ENTREGA], [CLI_CPF_CNPJ], [CLI_BAIRRO_ENTREGA], [CLI_CEP_ENTREGA], [CLI_EMAIL], [CLI_INTEGRACAO], [MUN_ID_ENTREGA], [CLI_TRANSLADO], [CLI_REGIAO_ENTREGA], [CLI_EXIGENTE_NA_IMPRESSAO], [CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO], [CLI_TEMPO_DESCARREGAMENTO_UNITARIO], [CLI_PERCENTUAL_JANELA_EMBARQUE], [REP_ID], [CLI_RAZAO_SOCIAL], [CLI_EMAIL_MONITORAMENTO_TRANSPORTE], [CLI_CONTATO], [CLI_SETOR], [SEG_ID], [CLI_TIPO], [CLI_INTEGRACAO_ERP], [CLI_LATITUDE_ENTREGA], [CLI_LONGITUDE_ENTREGA], [TenantID], [Deleted], [Changed], [UserId] FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_EMAIL"] = value; //06
                      whereClauses.Add($" [CLI_EMAIL] = @CLI_EMAIL ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCLI_INTEGRACAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [CLI_ID], [CLI_NOME], [CLI_FONE], [CLI_OBS], [CLI_ENDERECO_ENTREGA], [CLI_CPF_CNPJ], [CLI_BAIRRO_ENTREGA], [CLI_CEP_ENTREGA], [CLI_EMAIL], [CLI_INTEGRACAO], [MUN_ID_ENTREGA], [CLI_TRANSLADO], [CLI_REGIAO_ENTREGA], [CLI_EXIGENTE_NA_IMPRESSAO], [CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO], [CLI_TEMPO_DESCARREGAMENTO_UNITARIO], [CLI_PERCENTUAL_JANELA_EMBARQUE], [REP_ID], [CLI_RAZAO_SOCIAL], [CLI_EMAIL_MONITORAMENTO_TRANSPORTE], [CLI_CONTATO], [CLI_SETOR], [SEG_ID], [CLI_TIPO], [CLI_INTEGRACAO_ERP], [CLI_LATITUDE_ENTREGA], [CLI_LONGITUDE_ENTREGA], [TenantID], [Deleted], [Changed], [UserId] FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_INTEGRACAO"] = value; //06
                      whereClauses.Add($" [CLI_INTEGRACAO] = @CLI_INTEGRACAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMUN_ID_ENTREGAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [CLI_ID], [CLI_NOME], [CLI_FONE], [CLI_OBS], [CLI_ENDERECO_ENTREGA], [CLI_CPF_CNPJ], [CLI_BAIRRO_ENTREGA], [CLI_CEP_ENTREGA], [CLI_EMAIL], [CLI_INTEGRACAO], [MUN_ID_ENTREGA], [CLI_TRANSLADO], [CLI_REGIAO_ENTREGA], [CLI_EXIGENTE_NA_IMPRESSAO], [CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO], [CLI_TEMPO_DESCARREGAMENTO_UNITARIO], [CLI_PERCENTUAL_JANELA_EMBARQUE], [REP_ID], [CLI_RAZAO_SOCIAL], [CLI_EMAIL_MONITORAMENTO_TRANSPORTE], [CLI_CONTATO], [CLI_SETOR], [SEG_ID], [CLI_TIPO], [CLI_INTEGRACAO_ERP], [CLI_LATITUDE_ENTREGA], [CLI_LONGITUDE_ENTREGA], [TenantID], [Deleted], [Changed], [UserId] FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MUN_ID_ENTREGA"] = value; //06
                      whereClauses.Add($" [MUN_ID_ENTREGA] = @MUN_ID_ENTREGA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCLI_TRANSLADOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [CLI_ID], [CLI_NOME], [CLI_FONE], [CLI_OBS], [CLI_ENDERECO_ENTREGA], [CLI_CPF_CNPJ], [CLI_BAIRRO_ENTREGA], [CLI_CEP_ENTREGA], [CLI_EMAIL], [CLI_INTEGRACAO], [MUN_ID_ENTREGA], [CLI_TRANSLADO], [CLI_REGIAO_ENTREGA], [CLI_EXIGENTE_NA_IMPRESSAO], [CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO], [CLI_TEMPO_DESCARREGAMENTO_UNITARIO], [CLI_PERCENTUAL_JANELA_EMBARQUE], [REP_ID], [CLI_RAZAO_SOCIAL], [CLI_EMAIL_MONITORAMENTO_TRANSPORTE], [CLI_CONTATO], [CLI_SETOR], [SEG_ID], [CLI_TIPO], [CLI_INTEGRACAO_ERP], [CLI_LATITUDE_ENTREGA], [CLI_LONGITUDE_ENTREGA], [TenantID], [Deleted], [Changed], [UserId] FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_TRANSLADO"] = value; //06
                      whereClauses.Add($" [CLI_TRANSLADO] = @CLI_TRANSLADO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCLI_REGIAO_ENTREGAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [CLI_ID], [CLI_NOME], [CLI_FONE], [CLI_OBS], [CLI_ENDERECO_ENTREGA], [CLI_CPF_CNPJ], [CLI_BAIRRO_ENTREGA], [CLI_CEP_ENTREGA], [CLI_EMAIL], [CLI_INTEGRACAO], [MUN_ID_ENTREGA], [CLI_TRANSLADO], [CLI_REGIAO_ENTREGA], [CLI_EXIGENTE_NA_IMPRESSAO], [CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO], [CLI_TEMPO_DESCARREGAMENTO_UNITARIO], [CLI_PERCENTUAL_JANELA_EMBARQUE], [REP_ID], [CLI_RAZAO_SOCIAL], [CLI_EMAIL_MONITORAMENTO_TRANSPORTE], [CLI_CONTATO], [CLI_SETOR], [SEG_ID], [CLI_TIPO], [CLI_INTEGRACAO_ERP], [CLI_LATITUDE_ENTREGA], [CLI_LONGITUDE_ENTREGA], [TenantID], [Deleted], [Changed], [UserId] FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_REGIAO_ENTREGA"] = value; //06
                      whereClauses.Add($" [CLI_REGIAO_ENTREGA] = @CLI_REGIAO_ENTREGA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCLI_EXIGENTE_NA_IMPRESSAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [CLI_ID], [CLI_NOME], [CLI_FONE], [CLI_OBS], [CLI_ENDERECO_ENTREGA], [CLI_CPF_CNPJ], [CLI_BAIRRO_ENTREGA], [CLI_CEP_ENTREGA], [CLI_EMAIL], [CLI_INTEGRACAO], [MUN_ID_ENTREGA], [CLI_TRANSLADO], [CLI_REGIAO_ENTREGA], [CLI_EXIGENTE_NA_IMPRESSAO], [CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO], [CLI_TEMPO_DESCARREGAMENTO_UNITARIO], [CLI_PERCENTUAL_JANELA_EMBARQUE], [REP_ID], [CLI_RAZAO_SOCIAL], [CLI_EMAIL_MONITORAMENTO_TRANSPORTE], [CLI_CONTATO], [CLI_SETOR], [SEG_ID], [CLI_TIPO], [CLI_INTEGRACAO_ERP], [CLI_LATITUDE_ENTREGA], [CLI_LONGITUDE_ENTREGA], [TenantID], [Deleted], [Changed], [UserId] FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_EXIGENTE_NA_IMPRESSAO"] = value; //06
                      whereClauses.Add($" [CLI_EXIGENTE_NA_IMPRESSAO] = @CLI_EXIGENTE_NA_IMPRESSAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [CLI_ID], [CLI_NOME], [CLI_FONE], [CLI_OBS], [CLI_ENDERECO_ENTREGA], [CLI_CPF_CNPJ], [CLI_BAIRRO_ENTREGA], [CLI_CEP_ENTREGA], [CLI_EMAIL], [CLI_INTEGRACAO], [MUN_ID_ENTREGA], [CLI_TRANSLADO], [CLI_REGIAO_ENTREGA], [CLI_EXIGENTE_NA_IMPRESSAO], [CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO], [CLI_TEMPO_DESCARREGAMENTO_UNITARIO], [CLI_PERCENTUAL_JANELA_EMBARQUE], [REP_ID], [CLI_RAZAO_SOCIAL], [CLI_EMAIL_MONITORAMENTO_TRANSPORTE], [CLI_CONTATO], [CLI_SETOR], [SEG_ID], [CLI_TIPO], [CLI_INTEGRACAO_ERP], [CLI_LATITUDE_ENTREGA], [CLI_LONGITUDE_ENTREGA], [TenantID], [Deleted], [Changed], [UserId] FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO"] = value; //06
                      whereClauses.Add($" [CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO] = @CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCLI_TEMPO_DESCARREGAMENTO_UNITARIOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [CLI_ID], [CLI_NOME], [CLI_FONE], [CLI_OBS], [CLI_ENDERECO_ENTREGA], [CLI_CPF_CNPJ], [CLI_BAIRRO_ENTREGA], [CLI_CEP_ENTREGA], [CLI_EMAIL], [CLI_INTEGRACAO], [MUN_ID_ENTREGA], [CLI_TRANSLADO], [CLI_REGIAO_ENTREGA], [CLI_EXIGENTE_NA_IMPRESSAO], [CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO], [CLI_TEMPO_DESCARREGAMENTO_UNITARIO], [CLI_PERCENTUAL_JANELA_EMBARQUE], [REP_ID], [CLI_RAZAO_SOCIAL], [CLI_EMAIL_MONITORAMENTO_TRANSPORTE], [CLI_CONTATO], [CLI_SETOR], [SEG_ID], [CLI_TIPO], [CLI_INTEGRACAO_ERP], [CLI_LATITUDE_ENTREGA], [CLI_LONGITUDE_ENTREGA], [TenantID], [Deleted], [Changed], [UserId] FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_TEMPO_DESCARREGAMENTO_UNITARIO"] = value; //06
                      whereClauses.Add($" [CLI_TEMPO_DESCARREGAMENTO_UNITARIO] = @CLI_TEMPO_DESCARREGAMENTO_UNITARIO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCLI_PERCENTUAL_JANELA_EMBARQUEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [CLI_ID], [CLI_NOME], [CLI_FONE], [CLI_OBS], [CLI_ENDERECO_ENTREGA], [CLI_CPF_CNPJ], [CLI_BAIRRO_ENTREGA], [CLI_CEP_ENTREGA], [CLI_EMAIL], [CLI_INTEGRACAO], [MUN_ID_ENTREGA], [CLI_TRANSLADO], [CLI_REGIAO_ENTREGA], [CLI_EXIGENTE_NA_IMPRESSAO], [CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO], [CLI_TEMPO_DESCARREGAMENTO_UNITARIO], [CLI_PERCENTUAL_JANELA_EMBARQUE], [REP_ID], [CLI_RAZAO_SOCIAL], [CLI_EMAIL_MONITORAMENTO_TRANSPORTE], [CLI_CONTATO], [CLI_SETOR], [SEG_ID], [CLI_TIPO], [CLI_INTEGRACAO_ERP], [CLI_LATITUDE_ENTREGA], [CLI_LONGITUDE_ENTREGA], [TenantID], [Deleted], [Changed], [UserId] FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_PERCENTUAL_JANELA_EMBARQUE"] = value; //06
                      whereClauses.Add($" [CLI_PERCENTUAL_JANELA_EMBARQUE] = @CLI_PERCENTUAL_JANELA_EMBARQUE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByREP_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [CLI_ID], [CLI_NOME], [CLI_FONE], [CLI_OBS], [CLI_ENDERECO_ENTREGA], [CLI_CPF_CNPJ], [CLI_BAIRRO_ENTREGA], [CLI_CEP_ENTREGA], [CLI_EMAIL], [CLI_INTEGRACAO], [MUN_ID_ENTREGA], [CLI_TRANSLADO], [CLI_REGIAO_ENTREGA], [CLI_EXIGENTE_NA_IMPRESSAO], [CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO], [CLI_TEMPO_DESCARREGAMENTO_UNITARIO], [CLI_PERCENTUAL_JANELA_EMBARQUE], [REP_ID], [CLI_RAZAO_SOCIAL], [CLI_EMAIL_MONITORAMENTO_TRANSPORTE], [CLI_CONTATO], [CLI_SETOR], [SEG_ID], [CLI_TIPO], [CLI_INTEGRACAO_ERP], [CLI_LATITUDE_ENTREGA], [CLI_LONGITUDE_ENTREGA], [TenantID], [Deleted], [Changed], [UserId] FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["REP_ID"] = value; //06
                      whereClauses.Add($" [REP_ID] = @REP_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCLI_RAZAO_SOCIALQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [CLI_ID], [CLI_NOME], [CLI_FONE], [CLI_OBS], [CLI_ENDERECO_ENTREGA], [CLI_CPF_CNPJ], [CLI_BAIRRO_ENTREGA], [CLI_CEP_ENTREGA], [CLI_EMAIL], [CLI_INTEGRACAO], [MUN_ID_ENTREGA], [CLI_TRANSLADO], [CLI_REGIAO_ENTREGA], [CLI_EXIGENTE_NA_IMPRESSAO], [CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO], [CLI_TEMPO_DESCARREGAMENTO_UNITARIO], [CLI_PERCENTUAL_JANELA_EMBARQUE], [REP_ID], [CLI_RAZAO_SOCIAL], [CLI_EMAIL_MONITORAMENTO_TRANSPORTE], [CLI_CONTATO], [CLI_SETOR], [SEG_ID], [CLI_TIPO], [CLI_INTEGRACAO_ERP], [CLI_LATITUDE_ENTREGA], [CLI_LONGITUDE_ENTREGA], [TenantID], [Deleted], [Changed], [UserId] FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_RAZAO_SOCIAL"] = value; //06
                      whereClauses.Add($" [CLI_RAZAO_SOCIAL] = @CLI_RAZAO_SOCIAL ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCLI_EMAIL_MONITORAMENTO_TRANSPORTEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [CLI_ID], [CLI_NOME], [CLI_FONE], [CLI_OBS], [CLI_ENDERECO_ENTREGA], [CLI_CPF_CNPJ], [CLI_BAIRRO_ENTREGA], [CLI_CEP_ENTREGA], [CLI_EMAIL], [CLI_INTEGRACAO], [MUN_ID_ENTREGA], [CLI_TRANSLADO], [CLI_REGIAO_ENTREGA], [CLI_EXIGENTE_NA_IMPRESSAO], [CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO], [CLI_TEMPO_DESCARREGAMENTO_UNITARIO], [CLI_PERCENTUAL_JANELA_EMBARQUE], [REP_ID], [CLI_RAZAO_SOCIAL], [CLI_EMAIL_MONITORAMENTO_TRANSPORTE], [CLI_CONTATO], [CLI_SETOR], [SEG_ID], [CLI_TIPO], [CLI_INTEGRACAO_ERP], [CLI_LATITUDE_ENTREGA], [CLI_LONGITUDE_ENTREGA], [TenantID], [Deleted], [Changed], [UserId] FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_EMAIL_MONITORAMENTO_TRANSPORTE"] = value; //06
                      whereClauses.Add($" [CLI_EMAIL_MONITORAMENTO_TRANSPORTE] = @CLI_EMAIL_MONITORAMENTO_TRANSPORTE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCLI_CONTATOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [CLI_ID], [CLI_NOME], [CLI_FONE], [CLI_OBS], [CLI_ENDERECO_ENTREGA], [CLI_CPF_CNPJ], [CLI_BAIRRO_ENTREGA], [CLI_CEP_ENTREGA], [CLI_EMAIL], [CLI_INTEGRACAO], [MUN_ID_ENTREGA], [CLI_TRANSLADO], [CLI_REGIAO_ENTREGA], [CLI_EXIGENTE_NA_IMPRESSAO], [CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO], [CLI_TEMPO_DESCARREGAMENTO_UNITARIO], [CLI_PERCENTUAL_JANELA_EMBARQUE], [REP_ID], [CLI_RAZAO_SOCIAL], [CLI_EMAIL_MONITORAMENTO_TRANSPORTE], [CLI_CONTATO], [CLI_SETOR], [SEG_ID], [CLI_TIPO], [CLI_INTEGRACAO_ERP], [CLI_LATITUDE_ENTREGA], [CLI_LONGITUDE_ENTREGA], [TenantID], [Deleted], [Changed], [UserId] FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_CONTATO"] = value; //06
                      whereClauses.Add($" [CLI_CONTATO] = @CLI_CONTATO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCLI_SETORQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [CLI_ID], [CLI_NOME], [CLI_FONE], [CLI_OBS], [CLI_ENDERECO_ENTREGA], [CLI_CPF_CNPJ], [CLI_BAIRRO_ENTREGA], [CLI_CEP_ENTREGA], [CLI_EMAIL], [CLI_INTEGRACAO], [MUN_ID_ENTREGA], [CLI_TRANSLADO], [CLI_REGIAO_ENTREGA], [CLI_EXIGENTE_NA_IMPRESSAO], [CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO], [CLI_TEMPO_DESCARREGAMENTO_UNITARIO], [CLI_PERCENTUAL_JANELA_EMBARQUE], [REP_ID], [CLI_RAZAO_SOCIAL], [CLI_EMAIL_MONITORAMENTO_TRANSPORTE], [CLI_CONTATO], [CLI_SETOR], [SEG_ID], [CLI_TIPO], [CLI_INTEGRACAO_ERP], [CLI_LATITUDE_ENTREGA], [CLI_LONGITUDE_ENTREGA], [TenantID], [Deleted], [Changed], [UserId] FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_SETOR"] = value; //06
                      whereClauses.Add($" [CLI_SETOR] = @CLI_SETOR ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstBySEG_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [CLI_ID], [CLI_NOME], [CLI_FONE], [CLI_OBS], [CLI_ENDERECO_ENTREGA], [CLI_CPF_CNPJ], [CLI_BAIRRO_ENTREGA], [CLI_CEP_ENTREGA], [CLI_EMAIL], [CLI_INTEGRACAO], [MUN_ID_ENTREGA], [CLI_TRANSLADO], [CLI_REGIAO_ENTREGA], [CLI_EXIGENTE_NA_IMPRESSAO], [CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO], [CLI_TEMPO_DESCARREGAMENTO_UNITARIO], [CLI_PERCENTUAL_JANELA_EMBARQUE], [REP_ID], [CLI_RAZAO_SOCIAL], [CLI_EMAIL_MONITORAMENTO_TRANSPORTE], [CLI_CONTATO], [CLI_SETOR], [SEG_ID], [CLI_TIPO], [CLI_INTEGRACAO_ERP], [CLI_LATITUDE_ENTREGA], [CLI_LONGITUDE_ENTREGA], [TenantID], [Deleted], [Changed], [UserId] FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["SEG_ID"] = value; //06
                      whereClauses.Add($" [SEG_ID] = @SEG_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCLI_TIPOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [CLI_ID], [CLI_NOME], [CLI_FONE], [CLI_OBS], [CLI_ENDERECO_ENTREGA], [CLI_CPF_CNPJ], [CLI_BAIRRO_ENTREGA], [CLI_CEP_ENTREGA], [CLI_EMAIL], [CLI_INTEGRACAO], [MUN_ID_ENTREGA], [CLI_TRANSLADO], [CLI_REGIAO_ENTREGA], [CLI_EXIGENTE_NA_IMPRESSAO], [CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO], [CLI_TEMPO_DESCARREGAMENTO_UNITARIO], [CLI_PERCENTUAL_JANELA_EMBARQUE], [REP_ID], [CLI_RAZAO_SOCIAL], [CLI_EMAIL_MONITORAMENTO_TRANSPORTE], [CLI_CONTATO], [CLI_SETOR], [SEG_ID], [CLI_TIPO], [CLI_INTEGRACAO_ERP], [CLI_LATITUDE_ENTREGA], [CLI_LONGITUDE_ENTREGA], [TenantID], [Deleted], [Changed], [UserId] FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_TIPO"] = value; //06
                      whereClauses.Add($" [CLI_TIPO] = @CLI_TIPO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCLI_INTEGRACAO_ERPQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [CLI_ID], [CLI_NOME], [CLI_FONE], [CLI_OBS], [CLI_ENDERECO_ENTREGA], [CLI_CPF_CNPJ], [CLI_BAIRRO_ENTREGA], [CLI_CEP_ENTREGA], [CLI_EMAIL], [CLI_INTEGRACAO], [MUN_ID_ENTREGA], [CLI_TRANSLADO], [CLI_REGIAO_ENTREGA], [CLI_EXIGENTE_NA_IMPRESSAO], [CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO], [CLI_TEMPO_DESCARREGAMENTO_UNITARIO], [CLI_PERCENTUAL_JANELA_EMBARQUE], [REP_ID], [CLI_RAZAO_SOCIAL], [CLI_EMAIL_MONITORAMENTO_TRANSPORTE], [CLI_CONTATO], [CLI_SETOR], [SEG_ID], [CLI_TIPO], [CLI_INTEGRACAO_ERP], [CLI_LATITUDE_ENTREGA], [CLI_LONGITUDE_ENTREGA], [TenantID], [Deleted], [Changed], [UserId] FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_INTEGRACAO_ERP"] = value; //06
                      whereClauses.Add($" [CLI_INTEGRACAO_ERP] = @CLI_INTEGRACAO_ERP ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCLI_LATITUDE_ENTREGAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [CLI_ID], [CLI_NOME], [CLI_FONE], [CLI_OBS], [CLI_ENDERECO_ENTREGA], [CLI_CPF_CNPJ], [CLI_BAIRRO_ENTREGA], [CLI_CEP_ENTREGA], [CLI_EMAIL], [CLI_INTEGRACAO], [MUN_ID_ENTREGA], [CLI_TRANSLADO], [CLI_REGIAO_ENTREGA], [CLI_EXIGENTE_NA_IMPRESSAO], [CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO], [CLI_TEMPO_DESCARREGAMENTO_UNITARIO], [CLI_PERCENTUAL_JANELA_EMBARQUE], [REP_ID], [CLI_RAZAO_SOCIAL], [CLI_EMAIL_MONITORAMENTO_TRANSPORTE], [CLI_CONTATO], [CLI_SETOR], [SEG_ID], [CLI_TIPO], [CLI_INTEGRACAO_ERP], [CLI_LATITUDE_ENTREGA], [CLI_LONGITUDE_ENTREGA], [TenantID], [Deleted], [Changed], [UserId] FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_LATITUDE_ENTREGA"] = value; //06
                      whereClauses.Add($" [CLI_LATITUDE_ENTREGA] = @CLI_LATITUDE_ENTREGA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCLI_LONGITUDE_ENTREGAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [CLI_ID], [CLI_NOME], [CLI_FONE], [CLI_OBS], [CLI_ENDERECO_ENTREGA], [CLI_CPF_CNPJ], [CLI_BAIRRO_ENTREGA], [CLI_CEP_ENTREGA], [CLI_EMAIL], [CLI_INTEGRACAO], [MUN_ID_ENTREGA], [CLI_TRANSLADO], [CLI_REGIAO_ENTREGA], [CLI_EXIGENTE_NA_IMPRESSAO], [CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO], [CLI_TEMPO_DESCARREGAMENTO_UNITARIO], [CLI_PERCENTUAL_JANELA_EMBARQUE], [REP_ID], [CLI_RAZAO_SOCIAL], [CLI_EMAIL_MONITORAMENTO_TRANSPORTE], [CLI_CONTATO], [CLI_SETOR], [SEG_ID], [CLI_TIPO], [CLI_INTEGRACAO_ERP], [CLI_LATITUDE_ENTREGA], [CLI_LONGITUDE_ENTREGA], [TenantID], [Deleted], [Changed], [UserId] FROM [Cliente] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CLI_LONGITUDE_ENTREGA"] = value; //06
                      whereClauses.Add($" [CLI_LONGITUDE_ENTREGA] = @CLI_LONGITUDE_ENTREGA ");//06
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
            this.Query = $"SELECT [CLI_ID], [CLI_NOME], [CLI_FONE], [CLI_OBS], [CLI_ENDERECO_ENTREGA], [CLI_CPF_CNPJ], [CLI_BAIRRO_ENTREGA], [CLI_CEP_ENTREGA], [CLI_EMAIL], [CLI_INTEGRACAO], [MUN_ID_ENTREGA], [CLI_TRANSLADO], [CLI_REGIAO_ENTREGA], [CLI_EXIGENTE_NA_IMPRESSAO], [CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO], [CLI_TEMPO_DESCARREGAMENTO_UNITARIO], [CLI_PERCENTUAL_JANELA_EMBARQUE], [REP_ID], [CLI_RAZAO_SOCIAL], [CLI_EMAIL_MONITORAMENTO_TRANSPORTE], [CLI_CONTATO], [CLI_SETOR], [SEG_ID], [CLI_TIPO], [CLI_INTEGRACAO_ERP], [CLI_LATITUDE_ENTREGA], [CLI_LONGITUDE_ENTREGA], [TenantID], [Deleted], [Changed], [UserId] FROM [Cliente] ";
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
            this.Query = $"SELECT [CLI_ID], [CLI_NOME], [CLI_FONE], [CLI_OBS], [CLI_ENDERECO_ENTREGA], [CLI_CPF_CNPJ], [CLI_BAIRRO_ENTREGA], [CLI_CEP_ENTREGA], [CLI_EMAIL], [CLI_INTEGRACAO], [MUN_ID_ENTREGA], [CLI_TRANSLADO], [CLI_REGIAO_ENTREGA], [CLI_EXIGENTE_NA_IMPRESSAO], [CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO], [CLI_TEMPO_DESCARREGAMENTO_UNITARIO], [CLI_PERCENTUAL_JANELA_EMBARQUE], [REP_ID], [CLI_RAZAO_SOCIAL], [CLI_EMAIL_MONITORAMENTO_TRANSPORTE], [CLI_CONTATO], [CLI_SETOR], [SEG_ID], [CLI_TIPO], [CLI_INTEGRACAO_ERP], [CLI_LATITUDE_ENTREGA], [CLI_LONGITUDE_ENTREGA], [TenantID], [Deleted], [Changed], [UserId] FROM [Cliente] ";
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
            this.Query = $"SELECT [CLI_ID], [CLI_NOME], [CLI_FONE], [CLI_OBS], [CLI_ENDERECO_ENTREGA], [CLI_CPF_CNPJ], [CLI_BAIRRO_ENTREGA], [CLI_CEP_ENTREGA], [CLI_EMAIL], [CLI_INTEGRACAO], [MUN_ID_ENTREGA], [CLI_TRANSLADO], [CLI_REGIAO_ENTREGA], [CLI_EXIGENTE_NA_IMPRESSAO], [CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO], [CLI_TEMPO_DESCARREGAMENTO_UNITARIO], [CLI_PERCENTUAL_JANELA_EMBARQUE], [REP_ID], [CLI_RAZAO_SOCIAL], [CLI_EMAIL_MONITORAMENTO_TRANSPORTE], [CLI_CONTATO], [CLI_SETOR], [SEG_ID], [CLI_TIPO], [CLI_INTEGRACAO_ERP], [CLI_LATITUDE_ENTREGA], [CLI_LONGITUDE_ENTREGA], [TenantID], [Deleted], [Changed], [UserId] FROM [Cliente] ";
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
            this.Query = $"SELECT [CLI_ID], [CLI_NOME], [CLI_FONE], [CLI_OBS], [CLI_ENDERECO_ENTREGA], [CLI_CPF_CNPJ], [CLI_BAIRRO_ENTREGA], [CLI_CEP_ENTREGA], [CLI_EMAIL], [CLI_INTEGRACAO], [MUN_ID_ENTREGA], [CLI_TRANSLADO], [CLI_REGIAO_ENTREGA], [CLI_EXIGENTE_NA_IMPRESSAO], [CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO], [CLI_TEMPO_DESCARREGAMENTO_UNITARIO], [CLI_PERCENTUAL_JANELA_EMBARQUE], [REP_ID], [CLI_RAZAO_SOCIAL], [CLI_EMAIL_MONITORAMENTO_TRANSPORTE], [CLI_CONTATO], [CLI_SETOR], [SEG_ID], [CLI_TIPO], [CLI_INTEGRACAO_ERP], [CLI_LATITUDE_ENTREGA], [CLI_LONGITUDE_ENTREGA], [TenantID], [Deleted], [Changed], [UserId] FROM [Cliente] ";
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