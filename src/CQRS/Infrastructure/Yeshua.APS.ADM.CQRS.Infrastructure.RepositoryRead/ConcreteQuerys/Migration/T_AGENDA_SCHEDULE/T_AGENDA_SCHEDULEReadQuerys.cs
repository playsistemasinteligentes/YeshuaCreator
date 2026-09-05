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
    public class T_AGENDA_SCHEDULEQueryRead : QueryBase, IT_AGENDA_SCHEDULEQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public T_AGENDA_SCHEDULEQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel T_AGENDA_SCHEDULEQuery(Command.Read.T_AGENDA_SCHEDULEReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select [Id], [AGE_ID], [AGE_DATA_ESPECIFICA], [AGE_HORARIO_INICIO], [AGE_HORARIO_FIM], [AGE_SEGUNDA], [AGE_TERCA], [AGE_QUARTA], [AGE_QUINTA], [AGE_SEXTA], [AGE_SABADO], [AGE_DOMINGO], [AGE_INTERVALO], [AGE_ORDEM_EXECUCAO], [AGE_PARAMETROS], [AGE_EXCECAO], [AGE_DESCRICAO], [TenantID], [Deleted], [Changed], [UserId] from [T_AGENDA_SCHEDULE] ";
if (Command.Id.HasValue) dict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"[Id] = @Id");
if (Command.AGE_ID.HasValue) dict["AGE_ID"] = Command.AGE_ID.Value;
if (Command.AGE_ID.HasValue) whereClauses.Add($"[AGE_ID] = @AGE_ID");
if (!string.IsNullOrEmpty(Command.AGE_HORARIO_INICIO)) dict["AGE_HORARIO_INICIO"] = $"%{Command.AGE_HORARIO_INICIO}%";
if (!string.IsNullOrEmpty(Command.AGE_HORARIO_INICIO)) whereClauses.Add($"[AGE_HORARIO_INICIO] like @AGE_HORARIO_INICIO");
if (!string.IsNullOrEmpty(Command.AGE_HORARIO_FIM)) dict["AGE_HORARIO_FIM"] = $"%{Command.AGE_HORARIO_FIM}%";
if (!string.IsNullOrEmpty(Command.AGE_HORARIO_FIM)) whereClauses.Add($"[AGE_HORARIO_FIM] like @AGE_HORARIO_FIM");
if (!string.IsNullOrEmpty(Command.AGE_SEGUNDA)) dict["AGE_SEGUNDA"] = $"%{Command.AGE_SEGUNDA}%";
if (!string.IsNullOrEmpty(Command.AGE_SEGUNDA)) whereClauses.Add($"[AGE_SEGUNDA] like @AGE_SEGUNDA");
if (!string.IsNullOrEmpty(Command.AGE_TERCA)) dict["AGE_TERCA"] = $"%{Command.AGE_TERCA}%";
if (!string.IsNullOrEmpty(Command.AGE_TERCA)) whereClauses.Add($"[AGE_TERCA] like @AGE_TERCA");
if (!string.IsNullOrEmpty(Command.AGE_QUARTA)) dict["AGE_QUARTA"] = $"%{Command.AGE_QUARTA}%";
if (!string.IsNullOrEmpty(Command.AGE_QUARTA)) whereClauses.Add($"[AGE_QUARTA] like @AGE_QUARTA");
if (!string.IsNullOrEmpty(Command.AGE_QUINTA)) dict["AGE_QUINTA"] = $"%{Command.AGE_QUINTA}%";
if (!string.IsNullOrEmpty(Command.AGE_QUINTA)) whereClauses.Add($"[AGE_QUINTA] like @AGE_QUINTA");
if (!string.IsNullOrEmpty(Command.AGE_SEXTA)) dict["AGE_SEXTA"] = $"%{Command.AGE_SEXTA}%";
if (!string.IsNullOrEmpty(Command.AGE_SEXTA)) whereClauses.Add($"[AGE_SEXTA] like @AGE_SEXTA");
if (!string.IsNullOrEmpty(Command.AGE_SABADO)) dict["AGE_SABADO"] = $"%{Command.AGE_SABADO}%";
if (!string.IsNullOrEmpty(Command.AGE_SABADO)) whereClauses.Add($"[AGE_SABADO] like @AGE_SABADO");
if (!string.IsNullOrEmpty(Command.AGE_DOMINGO)) dict["AGE_DOMINGO"] = $"%{Command.AGE_DOMINGO}%";
if (!string.IsNullOrEmpty(Command.AGE_DOMINGO)) whereClauses.Add($"[AGE_DOMINGO] like @AGE_DOMINGO");
if (!string.IsNullOrEmpty(Command.AGE_ORDEM_EXECUCAO)) dict["AGE_ORDEM_EXECUCAO"] = $"%{Command.AGE_ORDEM_EXECUCAO}%";
if (!string.IsNullOrEmpty(Command.AGE_ORDEM_EXECUCAO)) whereClauses.Add($"[AGE_ORDEM_EXECUCAO] like @AGE_ORDEM_EXECUCAO");
if (!string.IsNullOrEmpty(Command.AGE_PARAMETROS)) dict["AGE_PARAMETROS"] = $"%{Command.AGE_PARAMETROS}%";
if (!string.IsNullOrEmpty(Command.AGE_PARAMETROS)) whereClauses.Add($"[AGE_PARAMETROS] like @AGE_PARAMETROS");
if (!string.IsNullOrEmpty(Command.AGE_EXCECAO)) dict["AGE_EXCECAO"] = $"%{Command.AGE_EXCECAO}%";
if (!string.IsNullOrEmpty(Command.AGE_EXCECAO)) whereClauses.Add($"[AGE_EXCECAO] like @AGE_EXCECAO");
if (!string.IsNullOrEmpty(Command.AGE_DESCRICAO)) dict["AGE_DESCRICAO"] = $"%{Command.AGE_DESCRICAO}%";
if (!string.IsNullOrEmpty(Command.AGE_DESCRICAO)) whereClauses.Add($"[AGE_DESCRICAO] like @AGE_DESCRICAO");
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
        public QueryModel T_AGENDA_SCHEDULETenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel T_AGENDA_SCHEDULEUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
            this.Query = $"SELECT 1 FROM [T_AGENDA_SCHEDULE] ";
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
        public QueryModel ExistsByAGE_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [T_AGENDA_SCHEDULE] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["AGE_ID"] = value; //04
                      whereClauses.Add($" [AGE_ID] = @AGE_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByAGE_DATA_ESPECIFICAQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [T_AGENDA_SCHEDULE] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["AGE_DATA_ESPECIFICA"] = value; //04
                      whereClauses.Add($" [AGE_DATA_ESPECIFICA] = @AGE_DATA_ESPECIFICA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByAGE_HORARIO_INICIOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [T_AGENDA_SCHEDULE] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["AGE_HORARIO_INICIO"] = value; //04
                      whereClauses.Add($" [AGE_HORARIO_INICIO] = @AGE_HORARIO_INICIO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByAGE_HORARIO_FIMQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [T_AGENDA_SCHEDULE] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["AGE_HORARIO_FIM"] = value; //04
                      whereClauses.Add($" [AGE_HORARIO_FIM] = @AGE_HORARIO_FIM ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByAGE_SEGUNDAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [T_AGENDA_SCHEDULE] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["AGE_SEGUNDA"] = value; //04
                      whereClauses.Add($" [AGE_SEGUNDA] = @AGE_SEGUNDA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByAGE_TERCAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [T_AGENDA_SCHEDULE] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["AGE_TERCA"] = value; //04
                      whereClauses.Add($" [AGE_TERCA] = @AGE_TERCA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByAGE_QUARTAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [T_AGENDA_SCHEDULE] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["AGE_QUARTA"] = value; //04
                      whereClauses.Add($" [AGE_QUARTA] = @AGE_QUARTA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByAGE_QUINTAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [T_AGENDA_SCHEDULE] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["AGE_QUINTA"] = value; //04
                      whereClauses.Add($" [AGE_QUINTA] = @AGE_QUINTA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByAGE_SEXTAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [T_AGENDA_SCHEDULE] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["AGE_SEXTA"] = value; //04
                      whereClauses.Add($" [AGE_SEXTA] = @AGE_SEXTA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByAGE_SABADOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [T_AGENDA_SCHEDULE] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["AGE_SABADO"] = value; //04
                      whereClauses.Add($" [AGE_SABADO] = @AGE_SABADO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByAGE_DOMINGOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [T_AGENDA_SCHEDULE] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["AGE_DOMINGO"] = value; //04
                      whereClauses.Add($" [AGE_DOMINGO] = @AGE_DOMINGO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByAGE_INTERVALOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [T_AGENDA_SCHEDULE] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["AGE_INTERVALO"] = value; //04
                      whereClauses.Add($" [AGE_INTERVALO] = @AGE_INTERVALO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByAGE_ORDEM_EXECUCAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [T_AGENDA_SCHEDULE] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["AGE_ORDEM_EXECUCAO"] = value; //04
                      whereClauses.Add($" [AGE_ORDEM_EXECUCAO] = @AGE_ORDEM_EXECUCAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByAGE_PARAMETROSQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [T_AGENDA_SCHEDULE] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["AGE_PARAMETROS"] = value; //04
                      whereClauses.Add($" [AGE_PARAMETROS] = @AGE_PARAMETROS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByAGE_EXCECAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [T_AGENDA_SCHEDULE] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["AGE_EXCECAO"] = value; //04
                      whereClauses.Add($" [AGE_EXCECAO] = @AGE_EXCECAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByAGE_DESCRICAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [T_AGENDA_SCHEDULE] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["AGE_DESCRICAO"] = value; //04
                      whereClauses.Add($" [AGE_DESCRICAO] = @AGE_DESCRICAO ");//04
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
            this.Query = $"SELECT 1 FROM [T_AGENDA_SCHEDULE] ";
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
            this.Query = $"SELECT 1 FROM [T_AGENDA_SCHEDULE] ";
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
            this.Query = $"SELECT 1 FROM [T_AGENDA_SCHEDULE] ";
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
            this.Query = $"SELECT 1 FROM [T_AGENDA_SCHEDULE] ";
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
            this.Query = $"SELECT [Id], [AGE_ID], [AGE_DATA_ESPECIFICA], [AGE_HORARIO_INICIO], [AGE_HORARIO_FIM], [AGE_SEGUNDA], [AGE_TERCA], [AGE_QUARTA], [AGE_QUINTA], [AGE_SEXTA], [AGE_SABADO], [AGE_DOMINGO], [AGE_INTERVALO], [AGE_ORDEM_EXECUCAO], [AGE_PARAMETROS], [AGE_EXCECAO], [AGE_DESCRICAO], [TenantID], [Deleted], [Changed], [UserId] FROM [T_AGENDA_SCHEDULE] ";
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
        public QueryModel FirstByAGE_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [AGE_ID], [AGE_DATA_ESPECIFICA], [AGE_HORARIO_INICIO], [AGE_HORARIO_FIM], [AGE_SEGUNDA], [AGE_TERCA], [AGE_QUARTA], [AGE_QUINTA], [AGE_SEXTA], [AGE_SABADO], [AGE_DOMINGO], [AGE_INTERVALO], [AGE_ORDEM_EXECUCAO], [AGE_PARAMETROS], [AGE_EXCECAO], [AGE_DESCRICAO], [TenantID], [Deleted], [Changed], [UserId] FROM [T_AGENDA_SCHEDULE] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["AGE_ID"] = value; //06
                      whereClauses.Add($" [AGE_ID] = @AGE_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByAGE_DATA_ESPECIFICAQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [AGE_ID], [AGE_DATA_ESPECIFICA], [AGE_HORARIO_INICIO], [AGE_HORARIO_FIM], [AGE_SEGUNDA], [AGE_TERCA], [AGE_QUARTA], [AGE_QUINTA], [AGE_SEXTA], [AGE_SABADO], [AGE_DOMINGO], [AGE_INTERVALO], [AGE_ORDEM_EXECUCAO], [AGE_PARAMETROS], [AGE_EXCECAO], [AGE_DESCRICAO], [TenantID], [Deleted], [Changed], [UserId] FROM [T_AGENDA_SCHEDULE] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["AGE_DATA_ESPECIFICA"] = value; //06
                      whereClauses.Add($" [AGE_DATA_ESPECIFICA] = @AGE_DATA_ESPECIFICA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByAGE_HORARIO_INICIOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [AGE_ID], [AGE_DATA_ESPECIFICA], [AGE_HORARIO_INICIO], [AGE_HORARIO_FIM], [AGE_SEGUNDA], [AGE_TERCA], [AGE_QUARTA], [AGE_QUINTA], [AGE_SEXTA], [AGE_SABADO], [AGE_DOMINGO], [AGE_INTERVALO], [AGE_ORDEM_EXECUCAO], [AGE_PARAMETROS], [AGE_EXCECAO], [AGE_DESCRICAO], [TenantID], [Deleted], [Changed], [UserId] FROM [T_AGENDA_SCHEDULE] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["AGE_HORARIO_INICIO"] = value; //06
                      whereClauses.Add($" [AGE_HORARIO_INICIO] = @AGE_HORARIO_INICIO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByAGE_HORARIO_FIMQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [AGE_ID], [AGE_DATA_ESPECIFICA], [AGE_HORARIO_INICIO], [AGE_HORARIO_FIM], [AGE_SEGUNDA], [AGE_TERCA], [AGE_QUARTA], [AGE_QUINTA], [AGE_SEXTA], [AGE_SABADO], [AGE_DOMINGO], [AGE_INTERVALO], [AGE_ORDEM_EXECUCAO], [AGE_PARAMETROS], [AGE_EXCECAO], [AGE_DESCRICAO], [TenantID], [Deleted], [Changed], [UserId] FROM [T_AGENDA_SCHEDULE] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["AGE_HORARIO_FIM"] = value; //06
                      whereClauses.Add($" [AGE_HORARIO_FIM] = @AGE_HORARIO_FIM ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByAGE_SEGUNDAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [AGE_ID], [AGE_DATA_ESPECIFICA], [AGE_HORARIO_INICIO], [AGE_HORARIO_FIM], [AGE_SEGUNDA], [AGE_TERCA], [AGE_QUARTA], [AGE_QUINTA], [AGE_SEXTA], [AGE_SABADO], [AGE_DOMINGO], [AGE_INTERVALO], [AGE_ORDEM_EXECUCAO], [AGE_PARAMETROS], [AGE_EXCECAO], [AGE_DESCRICAO], [TenantID], [Deleted], [Changed], [UserId] FROM [T_AGENDA_SCHEDULE] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["AGE_SEGUNDA"] = value; //06
                      whereClauses.Add($" [AGE_SEGUNDA] = @AGE_SEGUNDA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByAGE_TERCAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [AGE_ID], [AGE_DATA_ESPECIFICA], [AGE_HORARIO_INICIO], [AGE_HORARIO_FIM], [AGE_SEGUNDA], [AGE_TERCA], [AGE_QUARTA], [AGE_QUINTA], [AGE_SEXTA], [AGE_SABADO], [AGE_DOMINGO], [AGE_INTERVALO], [AGE_ORDEM_EXECUCAO], [AGE_PARAMETROS], [AGE_EXCECAO], [AGE_DESCRICAO], [TenantID], [Deleted], [Changed], [UserId] FROM [T_AGENDA_SCHEDULE] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["AGE_TERCA"] = value; //06
                      whereClauses.Add($" [AGE_TERCA] = @AGE_TERCA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByAGE_QUARTAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [AGE_ID], [AGE_DATA_ESPECIFICA], [AGE_HORARIO_INICIO], [AGE_HORARIO_FIM], [AGE_SEGUNDA], [AGE_TERCA], [AGE_QUARTA], [AGE_QUINTA], [AGE_SEXTA], [AGE_SABADO], [AGE_DOMINGO], [AGE_INTERVALO], [AGE_ORDEM_EXECUCAO], [AGE_PARAMETROS], [AGE_EXCECAO], [AGE_DESCRICAO], [TenantID], [Deleted], [Changed], [UserId] FROM [T_AGENDA_SCHEDULE] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["AGE_QUARTA"] = value; //06
                      whereClauses.Add($" [AGE_QUARTA] = @AGE_QUARTA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByAGE_QUINTAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [AGE_ID], [AGE_DATA_ESPECIFICA], [AGE_HORARIO_INICIO], [AGE_HORARIO_FIM], [AGE_SEGUNDA], [AGE_TERCA], [AGE_QUARTA], [AGE_QUINTA], [AGE_SEXTA], [AGE_SABADO], [AGE_DOMINGO], [AGE_INTERVALO], [AGE_ORDEM_EXECUCAO], [AGE_PARAMETROS], [AGE_EXCECAO], [AGE_DESCRICAO], [TenantID], [Deleted], [Changed], [UserId] FROM [T_AGENDA_SCHEDULE] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["AGE_QUINTA"] = value; //06
                      whereClauses.Add($" [AGE_QUINTA] = @AGE_QUINTA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByAGE_SEXTAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [AGE_ID], [AGE_DATA_ESPECIFICA], [AGE_HORARIO_INICIO], [AGE_HORARIO_FIM], [AGE_SEGUNDA], [AGE_TERCA], [AGE_QUARTA], [AGE_QUINTA], [AGE_SEXTA], [AGE_SABADO], [AGE_DOMINGO], [AGE_INTERVALO], [AGE_ORDEM_EXECUCAO], [AGE_PARAMETROS], [AGE_EXCECAO], [AGE_DESCRICAO], [TenantID], [Deleted], [Changed], [UserId] FROM [T_AGENDA_SCHEDULE] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["AGE_SEXTA"] = value; //06
                      whereClauses.Add($" [AGE_SEXTA] = @AGE_SEXTA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByAGE_SABADOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [AGE_ID], [AGE_DATA_ESPECIFICA], [AGE_HORARIO_INICIO], [AGE_HORARIO_FIM], [AGE_SEGUNDA], [AGE_TERCA], [AGE_QUARTA], [AGE_QUINTA], [AGE_SEXTA], [AGE_SABADO], [AGE_DOMINGO], [AGE_INTERVALO], [AGE_ORDEM_EXECUCAO], [AGE_PARAMETROS], [AGE_EXCECAO], [AGE_DESCRICAO], [TenantID], [Deleted], [Changed], [UserId] FROM [T_AGENDA_SCHEDULE] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["AGE_SABADO"] = value; //06
                      whereClauses.Add($" [AGE_SABADO] = @AGE_SABADO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByAGE_DOMINGOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [AGE_ID], [AGE_DATA_ESPECIFICA], [AGE_HORARIO_INICIO], [AGE_HORARIO_FIM], [AGE_SEGUNDA], [AGE_TERCA], [AGE_QUARTA], [AGE_QUINTA], [AGE_SEXTA], [AGE_SABADO], [AGE_DOMINGO], [AGE_INTERVALO], [AGE_ORDEM_EXECUCAO], [AGE_PARAMETROS], [AGE_EXCECAO], [AGE_DESCRICAO], [TenantID], [Deleted], [Changed], [UserId] FROM [T_AGENDA_SCHEDULE] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["AGE_DOMINGO"] = value; //06
                      whereClauses.Add($" [AGE_DOMINGO] = @AGE_DOMINGO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByAGE_INTERVALOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [AGE_ID], [AGE_DATA_ESPECIFICA], [AGE_HORARIO_INICIO], [AGE_HORARIO_FIM], [AGE_SEGUNDA], [AGE_TERCA], [AGE_QUARTA], [AGE_QUINTA], [AGE_SEXTA], [AGE_SABADO], [AGE_DOMINGO], [AGE_INTERVALO], [AGE_ORDEM_EXECUCAO], [AGE_PARAMETROS], [AGE_EXCECAO], [AGE_DESCRICAO], [TenantID], [Deleted], [Changed], [UserId] FROM [T_AGENDA_SCHEDULE] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["AGE_INTERVALO"] = value; //06
                      whereClauses.Add($" [AGE_INTERVALO] = @AGE_INTERVALO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByAGE_ORDEM_EXECUCAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [AGE_ID], [AGE_DATA_ESPECIFICA], [AGE_HORARIO_INICIO], [AGE_HORARIO_FIM], [AGE_SEGUNDA], [AGE_TERCA], [AGE_QUARTA], [AGE_QUINTA], [AGE_SEXTA], [AGE_SABADO], [AGE_DOMINGO], [AGE_INTERVALO], [AGE_ORDEM_EXECUCAO], [AGE_PARAMETROS], [AGE_EXCECAO], [AGE_DESCRICAO], [TenantID], [Deleted], [Changed], [UserId] FROM [T_AGENDA_SCHEDULE] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["AGE_ORDEM_EXECUCAO"] = value; //06
                      whereClauses.Add($" [AGE_ORDEM_EXECUCAO] = @AGE_ORDEM_EXECUCAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByAGE_PARAMETROSQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [AGE_ID], [AGE_DATA_ESPECIFICA], [AGE_HORARIO_INICIO], [AGE_HORARIO_FIM], [AGE_SEGUNDA], [AGE_TERCA], [AGE_QUARTA], [AGE_QUINTA], [AGE_SEXTA], [AGE_SABADO], [AGE_DOMINGO], [AGE_INTERVALO], [AGE_ORDEM_EXECUCAO], [AGE_PARAMETROS], [AGE_EXCECAO], [AGE_DESCRICAO], [TenantID], [Deleted], [Changed], [UserId] FROM [T_AGENDA_SCHEDULE] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["AGE_PARAMETROS"] = value; //06
                      whereClauses.Add($" [AGE_PARAMETROS] = @AGE_PARAMETROS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByAGE_EXCECAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [AGE_ID], [AGE_DATA_ESPECIFICA], [AGE_HORARIO_INICIO], [AGE_HORARIO_FIM], [AGE_SEGUNDA], [AGE_TERCA], [AGE_QUARTA], [AGE_QUINTA], [AGE_SEXTA], [AGE_SABADO], [AGE_DOMINGO], [AGE_INTERVALO], [AGE_ORDEM_EXECUCAO], [AGE_PARAMETROS], [AGE_EXCECAO], [AGE_DESCRICAO], [TenantID], [Deleted], [Changed], [UserId] FROM [T_AGENDA_SCHEDULE] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["AGE_EXCECAO"] = value; //06
                      whereClauses.Add($" [AGE_EXCECAO] = @AGE_EXCECAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByAGE_DESCRICAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [AGE_ID], [AGE_DATA_ESPECIFICA], [AGE_HORARIO_INICIO], [AGE_HORARIO_FIM], [AGE_SEGUNDA], [AGE_TERCA], [AGE_QUARTA], [AGE_QUINTA], [AGE_SEXTA], [AGE_SABADO], [AGE_DOMINGO], [AGE_INTERVALO], [AGE_ORDEM_EXECUCAO], [AGE_PARAMETROS], [AGE_EXCECAO], [AGE_DESCRICAO], [TenantID], [Deleted], [Changed], [UserId] FROM [T_AGENDA_SCHEDULE] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["AGE_DESCRICAO"] = value; //06
                      whereClauses.Add($" [AGE_DESCRICAO] = @AGE_DESCRICAO ");//06
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
            this.Query = $"SELECT [Id], [AGE_ID], [AGE_DATA_ESPECIFICA], [AGE_HORARIO_INICIO], [AGE_HORARIO_FIM], [AGE_SEGUNDA], [AGE_TERCA], [AGE_QUARTA], [AGE_QUINTA], [AGE_SEXTA], [AGE_SABADO], [AGE_DOMINGO], [AGE_INTERVALO], [AGE_ORDEM_EXECUCAO], [AGE_PARAMETROS], [AGE_EXCECAO], [AGE_DESCRICAO], [TenantID], [Deleted], [Changed], [UserId] FROM [T_AGENDA_SCHEDULE] ";
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
            this.Query = $"SELECT [Id], [AGE_ID], [AGE_DATA_ESPECIFICA], [AGE_HORARIO_INICIO], [AGE_HORARIO_FIM], [AGE_SEGUNDA], [AGE_TERCA], [AGE_QUARTA], [AGE_QUINTA], [AGE_SEXTA], [AGE_SABADO], [AGE_DOMINGO], [AGE_INTERVALO], [AGE_ORDEM_EXECUCAO], [AGE_PARAMETROS], [AGE_EXCECAO], [AGE_DESCRICAO], [TenantID], [Deleted], [Changed], [UserId] FROM [T_AGENDA_SCHEDULE] ";
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
            this.Query = $"SELECT [Id], [AGE_ID], [AGE_DATA_ESPECIFICA], [AGE_HORARIO_INICIO], [AGE_HORARIO_FIM], [AGE_SEGUNDA], [AGE_TERCA], [AGE_QUARTA], [AGE_QUINTA], [AGE_SEXTA], [AGE_SABADO], [AGE_DOMINGO], [AGE_INTERVALO], [AGE_ORDEM_EXECUCAO], [AGE_PARAMETROS], [AGE_EXCECAO], [AGE_DESCRICAO], [TenantID], [Deleted], [Changed], [UserId] FROM [T_AGENDA_SCHEDULE] ";
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
            this.Query = $"SELECT [Id], [AGE_ID], [AGE_DATA_ESPECIFICA], [AGE_HORARIO_INICIO], [AGE_HORARIO_FIM], [AGE_SEGUNDA], [AGE_TERCA], [AGE_QUARTA], [AGE_QUINTA], [AGE_SEXTA], [AGE_SABADO], [AGE_DOMINGO], [AGE_INTERVALO], [AGE_ORDEM_EXECUCAO], [AGE_PARAMETROS], [AGE_EXCECAO], [AGE_DESCRICAO], [TenantID], [Deleted], [Changed], [UserId] FROM [T_AGENDA_SCHEDULE] ";
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