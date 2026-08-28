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
    public class T_IndicadoresQueryRead : QueryBase, IT_IndicadoresQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public T_IndicadoresQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel T_IndicadoresQuery(Command.Read.T_IndicadoresReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select IND_ID, IND_DESCRICAO, NEG_ID, DESC_CALCULO, IND_TIPOCOMPARADOR, IND_GRAFICO, IND_CONEXAO, IND_DTCRIACAO, RESPOSAVELIND, RESPOSAVELCARGA, PROCEXTRACAO, PER_ID, DIM_ID, DOM_EMPRESA, DOM_FILIAL, TenantID, Deleted, Changed, UserId from T_Indicadores ";
if (Command.IND_ID.HasValue) dict["IND_ID"] = Command.IND_ID.Value;
if (Command.IND_ID.HasValue) whereClauses.Add($"IND_ID = @IND_ID");
if (!string.IsNullOrEmpty(Command.IND_DESCRICAO)) dict["IND_DESCRICAO"] = $"%{Command.IND_DESCRICAO}%";
if (!string.IsNullOrEmpty(Command.IND_DESCRICAO)) whereClauses.Add($"IND_DESCRICAO like @IND_DESCRICAO");
if (Command.NEG_ID.HasValue) dict["NEG_ID"] = Command.NEG_ID.Value;
if (Command.NEG_ID.HasValue) whereClauses.Add($"NEG_ID = @NEG_ID");
if (!string.IsNullOrEmpty(Command.DESC_CALCULO)) dict["DESC_CALCULO"] = $"%{Command.DESC_CALCULO}%";
if (!string.IsNullOrEmpty(Command.DESC_CALCULO)) whereClauses.Add($"DESC_CALCULO like @DESC_CALCULO");
if (Command.IND_TIPOCOMPARADOR.HasValue) dict["IND_TIPOCOMPARADOR"] = Command.IND_TIPOCOMPARADOR.Value;
if (Command.IND_TIPOCOMPARADOR.HasValue) whereClauses.Add($"IND_TIPOCOMPARADOR = @IND_TIPOCOMPARADOR");
if (Command.IND_GRAFICO.HasValue) dict["IND_GRAFICO"] = Command.IND_GRAFICO.Value;
if (Command.IND_GRAFICO.HasValue) whereClauses.Add($"IND_GRAFICO = @IND_GRAFICO");
if (!string.IsNullOrEmpty(Command.IND_CONEXAO)) dict["IND_CONEXAO"] = $"%{Command.IND_CONEXAO}%";
if (!string.IsNullOrEmpty(Command.IND_CONEXAO)) whereClauses.Add($"IND_CONEXAO like @IND_CONEXAO");
if (!string.IsNullOrEmpty(Command.RESPOSAVELIND)) dict["RESPOSAVELIND"] = $"%{Command.RESPOSAVELIND}%";
if (!string.IsNullOrEmpty(Command.RESPOSAVELIND)) whereClauses.Add($"RESPOSAVELIND like @RESPOSAVELIND");
if (!string.IsNullOrEmpty(Command.RESPOSAVELCARGA)) dict["RESPOSAVELCARGA"] = $"%{Command.RESPOSAVELCARGA}%";
if (!string.IsNullOrEmpty(Command.RESPOSAVELCARGA)) whereClauses.Add($"RESPOSAVELCARGA like @RESPOSAVELCARGA");
if (!string.IsNullOrEmpty(Command.PROCEXTRACAO)) dict["PROCEXTRACAO"] = $"%{Command.PROCEXTRACAO}%";
if (!string.IsNullOrEmpty(Command.PROCEXTRACAO)) whereClauses.Add($"PROCEXTRACAO like @PROCEXTRACAO");
if (!string.IsNullOrEmpty(Command.PER_ID)) dict["PER_ID"] = $"%{Command.PER_ID}%";
if (!string.IsNullOrEmpty(Command.PER_ID)) whereClauses.Add($"PER_ID like @PER_ID");
if (!string.IsNullOrEmpty(Command.DIM_ID)) dict["DIM_ID"] = $"%{Command.DIM_ID}%";
if (!string.IsNullOrEmpty(Command.DIM_ID)) whereClauses.Add($"DIM_ID like @DIM_ID");
if (!string.IsNullOrEmpty(Command.DOM_EMPRESA)) dict["DOM_EMPRESA"] = $"%{Command.DOM_EMPRESA}%";
if (!string.IsNullOrEmpty(Command.DOM_EMPRESA)) whereClauses.Add($"DOM_EMPRESA like @DOM_EMPRESA");
if (!string.IsNullOrEmpty(Command.DOM_FILIAL)) dict["DOM_FILIAL"] = $"%{Command.DOM_FILIAL}%";
if (!string.IsNullOrEmpty(Command.DOM_FILIAL)) whereClauses.Add($"DOM_FILIAL like @DOM_FILIAL");
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
            Query += " ORDER BY IND_ID OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel T_IndicadoresNEG_IDQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select NEG_ID from T_Negocio ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["NEG_ID"] = numero; //01
                      whereClauses.Add($" NEG_ID = @NEG_ID");//01 
                 }
                 else 
                 {
                      dict["NEG_ID"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" NEG_ID like @NEG_ID ");//02
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
        public QueryModel T_IndicadoresTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel T_IndicadoresUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel ExistsByIND_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Indicadores ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["IND_ID"] = value; //04
                      whereClauses.Add($" IND_ID = @IND_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByIND_DESCRICAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Indicadores ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["IND_DESCRICAO"] = value; //04
                      whereClauses.Add($" IND_DESCRICAO = @IND_DESCRICAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByNEG_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Indicadores ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["NEG_ID"] = value; //04
                      whereClauses.Add($" NEG_ID = @NEG_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByDESC_CALCULOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Indicadores ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["DESC_CALCULO"] = value; //04
                      whereClauses.Add($" DESC_CALCULO = @DESC_CALCULO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByIND_TIPOCOMPARADORQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Indicadores ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["IND_TIPOCOMPARADOR"] = value; //04
                      whereClauses.Add($" IND_TIPOCOMPARADOR = @IND_TIPOCOMPARADOR ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByIND_GRAFICOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Indicadores ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["IND_GRAFICO"] = value; //04
                      whereClauses.Add($" IND_GRAFICO = @IND_GRAFICO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByIND_CONEXAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Indicadores ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["IND_CONEXAO"] = value; //04
                      whereClauses.Add($" IND_CONEXAO = @IND_CONEXAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByIND_DTCRIACAOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Indicadores ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["IND_DTCRIACAO"] = value; //04
                      whereClauses.Add($" IND_DTCRIACAO = @IND_DTCRIACAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByRESPOSAVELINDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Indicadores ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["RESPOSAVELIND"] = value; //04
                      whereClauses.Add($" RESPOSAVELIND = @RESPOSAVELIND ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByRESPOSAVELCARGAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Indicadores ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["RESPOSAVELCARGA"] = value; //04
                      whereClauses.Add($" RESPOSAVELCARGA = @RESPOSAVELCARGA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPROCEXTRACAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Indicadores ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PROCEXTRACAO"] = value; //04
                      whereClauses.Add($" PROCEXTRACAO = @PROCEXTRACAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPER_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Indicadores ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PER_ID"] = value; //04
                      whereClauses.Add($" PER_ID = @PER_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByDIM_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Indicadores ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["DIM_ID"] = value; //04
                      whereClauses.Add($" DIM_ID = @DIM_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByDOM_EMPRESAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Indicadores ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["DOM_EMPRESA"] = value; //04
                      whereClauses.Add($" DOM_EMPRESA = @DOM_EMPRESA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByDOM_FILIALQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Indicadores ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["DOM_FILIAL"] = value; //04
                      whereClauses.Add($" DOM_FILIAL = @DOM_FILIAL ");//04
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
            this.Query = $"SELECT 1 FROM T_Indicadores ";
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
            this.Query = $"SELECT 1 FROM T_Indicadores ";
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
            this.Query = $"SELECT 1 FROM T_Indicadores ";
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
            this.Query = $"SELECT 1 FROM T_Indicadores ";
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
        public QueryModel FirstByIND_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT IND_ID, IND_DESCRICAO, NEG_ID, DESC_CALCULO, IND_TIPOCOMPARADOR, IND_GRAFICO, IND_CONEXAO, IND_DTCRIACAO, RESPOSAVELIND, RESPOSAVELCARGA, PROCEXTRACAO, PER_ID, DIM_ID, DOM_EMPRESA, DOM_FILIAL, TenantID, Deleted, Changed, UserId FROM T_Indicadores ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["IND_ID"] = value; //06
                      whereClauses.Add($" IND_ID = @IND_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByIND_DESCRICAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT IND_ID, IND_DESCRICAO, NEG_ID, DESC_CALCULO, IND_TIPOCOMPARADOR, IND_GRAFICO, IND_CONEXAO, IND_DTCRIACAO, RESPOSAVELIND, RESPOSAVELCARGA, PROCEXTRACAO, PER_ID, DIM_ID, DOM_EMPRESA, DOM_FILIAL, TenantID, Deleted, Changed, UserId FROM T_Indicadores ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["IND_DESCRICAO"] = value; //06
                      whereClauses.Add($" IND_DESCRICAO = @IND_DESCRICAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByNEG_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT IND_ID, IND_DESCRICAO, NEG_ID, DESC_CALCULO, IND_TIPOCOMPARADOR, IND_GRAFICO, IND_CONEXAO, IND_DTCRIACAO, RESPOSAVELIND, RESPOSAVELCARGA, PROCEXTRACAO, PER_ID, DIM_ID, DOM_EMPRESA, DOM_FILIAL, TenantID, Deleted, Changed, UserId FROM T_Indicadores ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["NEG_ID"] = value; //06
                      whereClauses.Add($" NEG_ID = @NEG_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByDESC_CALCULOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT IND_ID, IND_DESCRICAO, NEG_ID, DESC_CALCULO, IND_TIPOCOMPARADOR, IND_GRAFICO, IND_CONEXAO, IND_DTCRIACAO, RESPOSAVELIND, RESPOSAVELCARGA, PROCEXTRACAO, PER_ID, DIM_ID, DOM_EMPRESA, DOM_FILIAL, TenantID, Deleted, Changed, UserId FROM T_Indicadores ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["DESC_CALCULO"] = value; //06
                      whereClauses.Add($" DESC_CALCULO = @DESC_CALCULO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByIND_TIPOCOMPARADORQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT IND_ID, IND_DESCRICAO, NEG_ID, DESC_CALCULO, IND_TIPOCOMPARADOR, IND_GRAFICO, IND_CONEXAO, IND_DTCRIACAO, RESPOSAVELIND, RESPOSAVELCARGA, PROCEXTRACAO, PER_ID, DIM_ID, DOM_EMPRESA, DOM_FILIAL, TenantID, Deleted, Changed, UserId FROM T_Indicadores ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["IND_TIPOCOMPARADOR"] = value; //06
                      whereClauses.Add($" IND_TIPOCOMPARADOR = @IND_TIPOCOMPARADOR ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByIND_GRAFICOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT IND_ID, IND_DESCRICAO, NEG_ID, DESC_CALCULO, IND_TIPOCOMPARADOR, IND_GRAFICO, IND_CONEXAO, IND_DTCRIACAO, RESPOSAVELIND, RESPOSAVELCARGA, PROCEXTRACAO, PER_ID, DIM_ID, DOM_EMPRESA, DOM_FILIAL, TenantID, Deleted, Changed, UserId FROM T_Indicadores ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["IND_GRAFICO"] = value; //06
                      whereClauses.Add($" IND_GRAFICO = @IND_GRAFICO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByIND_CONEXAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT IND_ID, IND_DESCRICAO, NEG_ID, DESC_CALCULO, IND_TIPOCOMPARADOR, IND_GRAFICO, IND_CONEXAO, IND_DTCRIACAO, RESPOSAVELIND, RESPOSAVELCARGA, PROCEXTRACAO, PER_ID, DIM_ID, DOM_EMPRESA, DOM_FILIAL, TenantID, Deleted, Changed, UserId FROM T_Indicadores ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["IND_CONEXAO"] = value; //06
                      whereClauses.Add($" IND_CONEXAO = @IND_CONEXAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByIND_DTCRIACAOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT IND_ID, IND_DESCRICAO, NEG_ID, DESC_CALCULO, IND_TIPOCOMPARADOR, IND_GRAFICO, IND_CONEXAO, IND_DTCRIACAO, RESPOSAVELIND, RESPOSAVELCARGA, PROCEXTRACAO, PER_ID, DIM_ID, DOM_EMPRESA, DOM_FILIAL, TenantID, Deleted, Changed, UserId FROM T_Indicadores ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["IND_DTCRIACAO"] = value; //06
                      whereClauses.Add($" IND_DTCRIACAO = @IND_DTCRIACAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByRESPOSAVELINDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT IND_ID, IND_DESCRICAO, NEG_ID, DESC_CALCULO, IND_TIPOCOMPARADOR, IND_GRAFICO, IND_CONEXAO, IND_DTCRIACAO, RESPOSAVELIND, RESPOSAVELCARGA, PROCEXTRACAO, PER_ID, DIM_ID, DOM_EMPRESA, DOM_FILIAL, TenantID, Deleted, Changed, UserId FROM T_Indicadores ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["RESPOSAVELIND"] = value; //06
                      whereClauses.Add($" RESPOSAVELIND = @RESPOSAVELIND ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByRESPOSAVELCARGAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT IND_ID, IND_DESCRICAO, NEG_ID, DESC_CALCULO, IND_TIPOCOMPARADOR, IND_GRAFICO, IND_CONEXAO, IND_DTCRIACAO, RESPOSAVELIND, RESPOSAVELCARGA, PROCEXTRACAO, PER_ID, DIM_ID, DOM_EMPRESA, DOM_FILIAL, TenantID, Deleted, Changed, UserId FROM T_Indicadores ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["RESPOSAVELCARGA"] = value; //06
                      whereClauses.Add($" RESPOSAVELCARGA = @RESPOSAVELCARGA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPROCEXTRACAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT IND_ID, IND_DESCRICAO, NEG_ID, DESC_CALCULO, IND_TIPOCOMPARADOR, IND_GRAFICO, IND_CONEXAO, IND_DTCRIACAO, RESPOSAVELIND, RESPOSAVELCARGA, PROCEXTRACAO, PER_ID, DIM_ID, DOM_EMPRESA, DOM_FILIAL, TenantID, Deleted, Changed, UserId FROM T_Indicadores ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PROCEXTRACAO"] = value; //06
                      whereClauses.Add($" PROCEXTRACAO = @PROCEXTRACAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPER_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT IND_ID, IND_DESCRICAO, NEG_ID, DESC_CALCULO, IND_TIPOCOMPARADOR, IND_GRAFICO, IND_CONEXAO, IND_DTCRIACAO, RESPOSAVELIND, RESPOSAVELCARGA, PROCEXTRACAO, PER_ID, DIM_ID, DOM_EMPRESA, DOM_FILIAL, TenantID, Deleted, Changed, UserId FROM T_Indicadores ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PER_ID"] = value; //06
                      whereClauses.Add($" PER_ID = @PER_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByDIM_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT IND_ID, IND_DESCRICAO, NEG_ID, DESC_CALCULO, IND_TIPOCOMPARADOR, IND_GRAFICO, IND_CONEXAO, IND_DTCRIACAO, RESPOSAVELIND, RESPOSAVELCARGA, PROCEXTRACAO, PER_ID, DIM_ID, DOM_EMPRESA, DOM_FILIAL, TenantID, Deleted, Changed, UserId FROM T_Indicadores ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["DIM_ID"] = value; //06
                      whereClauses.Add($" DIM_ID = @DIM_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByDOM_EMPRESAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT IND_ID, IND_DESCRICAO, NEG_ID, DESC_CALCULO, IND_TIPOCOMPARADOR, IND_GRAFICO, IND_CONEXAO, IND_DTCRIACAO, RESPOSAVELIND, RESPOSAVELCARGA, PROCEXTRACAO, PER_ID, DIM_ID, DOM_EMPRESA, DOM_FILIAL, TenantID, Deleted, Changed, UserId FROM T_Indicadores ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["DOM_EMPRESA"] = value; //06
                      whereClauses.Add($" DOM_EMPRESA = @DOM_EMPRESA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByDOM_FILIALQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT IND_ID, IND_DESCRICAO, NEG_ID, DESC_CALCULO, IND_TIPOCOMPARADOR, IND_GRAFICO, IND_CONEXAO, IND_DTCRIACAO, RESPOSAVELIND, RESPOSAVELCARGA, PROCEXTRACAO, PER_ID, DIM_ID, DOM_EMPRESA, DOM_FILIAL, TenantID, Deleted, Changed, UserId FROM T_Indicadores ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["DOM_FILIAL"] = value; //06
                      whereClauses.Add($" DOM_FILIAL = @DOM_FILIAL ");//06
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
            this.Query = $"SELECT IND_ID, IND_DESCRICAO, NEG_ID, DESC_CALCULO, IND_TIPOCOMPARADOR, IND_GRAFICO, IND_CONEXAO, IND_DTCRIACAO, RESPOSAVELIND, RESPOSAVELCARGA, PROCEXTRACAO, PER_ID, DIM_ID, DOM_EMPRESA, DOM_FILIAL, TenantID, Deleted, Changed, UserId FROM T_Indicadores ";
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
            this.Query = $"SELECT IND_ID, IND_DESCRICAO, NEG_ID, DESC_CALCULO, IND_TIPOCOMPARADOR, IND_GRAFICO, IND_CONEXAO, IND_DTCRIACAO, RESPOSAVELIND, RESPOSAVELCARGA, PROCEXTRACAO, PER_ID, DIM_ID, DOM_EMPRESA, DOM_FILIAL, TenantID, Deleted, Changed, UserId FROM T_Indicadores ";
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
            this.Query = $"SELECT IND_ID, IND_DESCRICAO, NEG_ID, DESC_CALCULO, IND_TIPOCOMPARADOR, IND_GRAFICO, IND_CONEXAO, IND_DTCRIACAO, RESPOSAVELIND, RESPOSAVELCARGA, PROCEXTRACAO, PER_ID, DIM_ID, DOM_EMPRESA, DOM_FILIAL, TenantID, Deleted, Changed, UserId FROM T_Indicadores ";
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
            this.Query = $"SELECT IND_ID, IND_DESCRICAO, NEG_ID, DESC_CALCULO, IND_TIPOCOMPARADOR, IND_GRAFICO, IND_CONEXAO, IND_DTCRIACAO, RESPOSAVELIND, RESPOSAVELCARGA, PROCEXTRACAO, PER_ID, DIM_ID, DOM_EMPRESA, DOM_FILIAL, TenantID, Deleted, Changed, UserId FROM T_Indicadores ";
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