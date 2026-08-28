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
    public class T_MetasQueryRead : QueryBase, IT_MetasQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public T_MetasQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel T_MetasQuery(Command.Read.T_MetasReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select MET_ID, MET_DTINICIO, MET_DTFIM, MET_ALVO, MET_TIPOALVO, IND_ID, MET_RANGE01, MET_RANGE02, MET_RANGE03, DIM_ID, FAT_ID, DIM_SUBDIMENSAO_ID, PER_ID, DOM_EMPRESA, DOM_FILIAL, TenantID, Deleted, Changed, UserId from T_Metas ";
if (Command.MET_ID.HasValue) dict["MET_ID"] = Command.MET_ID.Value;
if (Command.MET_ID.HasValue) whereClauses.Add($"MET_ID = @MET_ID");
if (!string.IsNullOrEmpty(Command.MET_DTINICIO)) dict["MET_DTINICIO"] = $"%{Command.MET_DTINICIO}%";
if (!string.IsNullOrEmpty(Command.MET_DTINICIO)) whereClauses.Add($"MET_DTINICIO like @MET_DTINICIO");
if (!string.IsNullOrEmpty(Command.MET_DTFIM)) dict["MET_DTFIM"] = $"%{Command.MET_DTFIM}%";
if (!string.IsNullOrEmpty(Command.MET_DTFIM)) whereClauses.Add($"MET_DTFIM like @MET_DTFIM");
if (!string.IsNullOrEmpty(Command.MET_ALVO)) dict["MET_ALVO"] = $"%{Command.MET_ALVO}%";
if (!string.IsNullOrEmpty(Command.MET_ALVO)) whereClauses.Add($"MET_ALVO like @MET_ALVO");
if (Command.MET_TIPOALVO.HasValue) dict["MET_TIPOALVO"] = Command.MET_TIPOALVO.Value;
if (Command.MET_TIPOALVO.HasValue) whereClauses.Add($"MET_TIPOALVO = @MET_TIPOALVO");
if (Command.IND_ID.HasValue) dict["IND_ID"] = Command.IND_ID.Value;
if (Command.IND_ID.HasValue) whereClauses.Add($"IND_ID = @IND_ID");
if (Command.DIM_ID.HasValue) dict["DIM_ID"] = Command.DIM_ID.Value;
if (Command.DIM_ID.HasValue) whereClauses.Add($"DIM_ID = @DIM_ID");
if (!string.IsNullOrEmpty(Command.FAT_ID)) dict["FAT_ID"] = $"%{Command.FAT_ID}%";
if (!string.IsNullOrEmpty(Command.FAT_ID)) whereClauses.Add($"FAT_ID like @FAT_ID");
if (!string.IsNullOrEmpty(Command.DIM_SUBDIMENSAO_ID)) dict["DIM_SUBDIMENSAO_ID"] = $"%{Command.DIM_SUBDIMENSAO_ID}%";
if (!string.IsNullOrEmpty(Command.DIM_SUBDIMENSAO_ID)) whereClauses.Add($"DIM_SUBDIMENSAO_ID like @DIM_SUBDIMENSAO_ID");
if (!string.IsNullOrEmpty(Command.PER_ID)) dict["PER_ID"] = $"%{Command.PER_ID}%";
if (!string.IsNullOrEmpty(Command.PER_ID)) whereClauses.Add($"PER_ID like @PER_ID");
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
            Query += " ORDER BY MET_ID OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel T_MetasIND_IDQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select IND_ID from T_Indicadores ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["IND_ID"] = numero; //01
                      whereClauses.Add($" IND_ID = @IND_ID");//01 
                 }
                 else 
                 {
                      dict["IND_ID"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" IND_ID like @IND_ID ");//02
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
        public QueryModel T_MetasTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel T_MetasUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel ExistsByMET_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Metas ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MET_ID"] = value; //04
                      whereClauses.Add($" MET_ID = @MET_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMET_DTINICIOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Metas ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MET_DTINICIO"] = value; //04
                      whereClauses.Add($" MET_DTINICIO = @MET_DTINICIO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMET_DTFIMQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Metas ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MET_DTFIM"] = value; //04
                      whereClauses.Add($" MET_DTFIM = @MET_DTFIM ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMET_ALVOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Metas ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MET_ALVO"] = value; //04
                      whereClauses.Add($" MET_ALVO = @MET_ALVO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMET_TIPOALVOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Metas ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MET_TIPOALVO"] = value; //04
                      whereClauses.Add($" MET_TIPOALVO = @MET_TIPOALVO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByIND_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Metas ";
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
        public QueryModel ExistsByMET_RANGE01Query(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Metas ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MET_RANGE01"] = value; //04
                      whereClauses.Add($" MET_RANGE01 = @MET_RANGE01 ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMET_RANGE02Query(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Metas ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MET_RANGE02"] = value; //04
                      whereClauses.Add($" MET_RANGE02 = @MET_RANGE02 ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMET_RANGE03Query(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Metas ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MET_RANGE03"] = value; //04
                      whereClauses.Add($" MET_RANGE03 = @MET_RANGE03 ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByDIM_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Metas ";
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
        public QueryModel ExistsByFAT_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Metas ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FAT_ID"] = value; //04
                      whereClauses.Add($" FAT_ID = @FAT_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByDIM_SUBDIMENSAO_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Metas ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["DIM_SUBDIMENSAO_ID"] = value; //04
                      whereClauses.Add($" DIM_SUBDIMENSAO_ID = @DIM_SUBDIMENSAO_ID ");//04
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
            this.Query = $"SELECT 1 FROM T_Metas ";
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
        public QueryModel ExistsByDOM_EMPRESAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Metas ";
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
            this.Query = $"SELECT 1 FROM T_Metas ";
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
            this.Query = $"SELECT 1 FROM T_Metas ";
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
            this.Query = $"SELECT 1 FROM T_Metas ";
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
            this.Query = $"SELECT 1 FROM T_Metas ";
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
            this.Query = $"SELECT 1 FROM T_Metas ";
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
        public QueryModel FirstByMET_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT MET_ID, MET_DTINICIO, MET_DTFIM, MET_ALVO, MET_TIPOALVO, IND_ID, MET_RANGE01, MET_RANGE02, MET_RANGE03, DIM_ID, FAT_ID, DIM_SUBDIMENSAO_ID, PER_ID, DOM_EMPRESA, DOM_FILIAL, TenantID, Deleted, Changed, UserId FROM T_Metas ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MET_ID"] = value; //06
                      whereClauses.Add($" MET_ID = @MET_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMET_DTINICIOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT MET_ID, MET_DTINICIO, MET_DTFIM, MET_ALVO, MET_TIPOALVO, IND_ID, MET_RANGE01, MET_RANGE02, MET_RANGE03, DIM_ID, FAT_ID, DIM_SUBDIMENSAO_ID, PER_ID, DOM_EMPRESA, DOM_FILIAL, TenantID, Deleted, Changed, UserId FROM T_Metas ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MET_DTINICIO"] = value; //06
                      whereClauses.Add($" MET_DTINICIO = @MET_DTINICIO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMET_DTFIMQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT MET_ID, MET_DTINICIO, MET_DTFIM, MET_ALVO, MET_TIPOALVO, IND_ID, MET_RANGE01, MET_RANGE02, MET_RANGE03, DIM_ID, FAT_ID, DIM_SUBDIMENSAO_ID, PER_ID, DOM_EMPRESA, DOM_FILIAL, TenantID, Deleted, Changed, UserId FROM T_Metas ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MET_DTFIM"] = value; //06
                      whereClauses.Add($" MET_DTFIM = @MET_DTFIM ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMET_ALVOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT MET_ID, MET_DTINICIO, MET_DTFIM, MET_ALVO, MET_TIPOALVO, IND_ID, MET_RANGE01, MET_RANGE02, MET_RANGE03, DIM_ID, FAT_ID, DIM_SUBDIMENSAO_ID, PER_ID, DOM_EMPRESA, DOM_FILIAL, TenantID, Deleted, Changed, UserId FROM T_Metas ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MET_ALVO"] = value; //06
                      whereClauses.Add($" MET_ALVO = @MET_ALVO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMET_TIPOALVOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT MET_ID, MET_DTINICIO, MET_DTFIM, MET_ALVO, MET_TIPOALVO, IND_ID, MET_RANGE01, MET_RANGE02, MET_RANGE03, DIM_ID, FAT_ID, DIM_SUBDIMENSAO_ID, PER_ID, DOM_EMPRESA, DOM_FILIAL, TenantID, Deleted, Changed, UserId FROM T_Metas ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MET_TIPOALVO"] = value; //06
                      whereClauses.Add($" MET_TIPOALVO = @MET_TIPOALVO ");//06
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
            this.Query = $"SELECT MET_ID, MET_DTINICIO, MET_DTFIM, MET_ALVO, MET_TIPOALVO, IND_ID, MET_RANGE01, MET_RANGE02, MET_RANGE03, DIM_ID, FAT_ID, DIM_SUBDIMENSAO_ID, PER_ID, DOM_EMPRESA, DOM_FILIAL, TenantID, Deleted, Changed, UserId FROM T_Metas ";
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
        public QueryModel FirstByMET_RANGE01Query(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT MET_ID, MET_DTINICIO, MET_DTFIM, MET_ALVO, MET_TIPOALVO, IND_ID, MET_RANGE01, MET_RANGE02, MET_RANGE03, DIM_ID, FAT_ID, DIM_SUBDIMENSAO_ID, PER_ID, DOM_EMPRESA, DOM_FILIAL, TenantID, Deleted, Changed, UserId FROM T_Metas ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MET_RANGE01"] = value; //06
                      whereClauses.Add($" MET_RANGE01 = @MET_RANGE01 ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMET_RANGE02Query(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT MET_ID, MET_DTINICIO, MET_DTFIM, MET_ALVO, MET_TIPOALVO, IND_ID, MET_RANGE01, MET_RANGE02, MET_RANGE03, DIM_ID, FAT_ID, DIM_SUBDIMENSAO_ID, PER_ID, DOM_EMPRESA, DOM_FILIAL, TenantID, Deleted, Changed, UserId FROM T_Metas ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MET_RANGE02"] = value; //06
                      whereClauses.Add($" MET_RANGE02 = @MET_RANGE02 ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMET_RANGE03Query(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT MET_ID, MET_DTINICIO, MET_DTFIM, MET_ALVO, MET_TIPOALVO, IND_ID, MET_RANGE01, MET_RANGE02, MET_RANGE03, DIM_ID, FAT_ID, DIM_SUBDIMENSAO_ID, PER_ID, DOM_EMPRESA, DOM_FILIAL, TenantID, Deleted, Changed, UserId FROM T_Metas ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MET_RANGE03"] = value; //06
                      whereClauses.Add($" MET_RANGE03 = @MET_RANGE03 ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByDIM_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT MET_ID, MET_DTINICIO, MET_DTFIM, MET_ALVO, MET_TIPOALVO, IND_ID, MET_RANGE01, MET_RANGE02, MET_RANGE03, DIM_ID, FAT_ID, DIM_SUBDIMENSAO_ID, PER_ID, DOM_EMPRESA, DOM_FILIAL, TenantID, Deleted, Changed, UserId FROM T_Metas ";
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
        public QueryModel FirstByFAT_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT MET_ID, MET_DTINICIO, MET_DTFIM, MET_ALVO, MET_TIPOALVO, IND_ID, MET_RANGE01, MET_RANGE02, MET_RANGE03, DIM_ID, FAT_ID, DIM_SUBDIMENSAO_ID, PER_ID, DOM_EMPRESA, DOM_FILIAL, TenantID, Deleted, Changed, UserId FROM T_Metas ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FAT_ID"] = value; //06
                      whereClauses.Add($" FAT_ID = @FAT_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByDIM_SUBDIMENSAO_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT MET_ID, MET_DTINICIO, MET_DTFIM, MET_ALVO, MET_TIPOALVO, IND_ID, MET_RANGE01, MET_RANGE02, MET_RANGE03, DIM_ID, FAT_ID, DIM_SUBDIMENSAO_ID, PER_ID, DOM_EMPRESA, DOM_FILIAL, TenantID, Deleted, Changed, UserId FROM T_Metas ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["DIM_SUBDIMENSAO_ID"] = value; //06
                      whereClauses.Add($" DIM_SUBDIMENSAO_ID = @DIM_SUBDIMENSAO_ID ");//06
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
            this.Query = $"SELECT MET_ID, MET_DTINICIO, MET_DTFIM, MET_ALVO, MET_TIPOALVO, IND_ID, MET_RANGE01, MET_RANGE02, MET_RANGE03, DIM_ID, FAT_ID, DIM_SUBDIMENSAO_ID, PER_ID, DOM_EMPRESA, DOM_FILIAL, TenantID, Deleted, Changed, UserId FROM T_Metas ";
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
        public QueryModel FirstByDOM_EMPRESAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT MET_ID, MET_DTINICIO, MET_DTFIM, MET_ALVO, MET_TIPOALVO, IND_ID, MET_RANGE01, MET_RANGE02, MET_RANGE03, DIM_ID, FAT_ID, DIM_SUBDIMENSAO_ID, PER_ID, DOM_EMPRESA, DOM_FILIAL, TenantID, Deleted, Changed, UserId FROM T_Metas ";
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
            this.Query = $"SELECT MET_ID, MET_DTINICIO, MET_DTFIM, MET_ALVO, MET_TIPOALVO, IND_ID, MET_RANGE01, MET_RANGE02, MET_RANGE03, DIM_ID, FAT_ID, DIM_SUBDIMENSAO_ID, PER_ID, DOM_EMPRESA, DOM_FILIAL, TenantID, Deleted, Changed, UserId FROM T_Metas ";
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
            this.Query = $"SELECT MET_ID, MET_DTINICIO, MET_DTFIM, MET_ALVO, MET_TIPOALVO, IND_ID, MET_RANGE01, MET_RANGE02, MET_RANGE03, DIM_ID, FAT_ID, DIM_SUBDIMENSAO_ID, PER_ID, DOM_EMPRESA, DOM_FILIAL, TenantID, Deleted, Changed, UserId FROM T_Metas ";
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
            this.Query = $"SELECT MET_ID, MET_DTINICIO, MET_DTFIM, MET_ALVO, MET_TIPOALVO, IND_ID, MET_RANGE01, MET_RANGE02, MET_RANGE03, DIM_ID, FAT_ID, DIM_SUBDIMENSAO_ID, PER_ID, DOM_EMPRESA, DOM_FILIAL, TenantID, Deleted, Changed, UserId FROM T_Metas ";
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
            this.Query = $"SELECT MET_ID, MET_DTINICIO, MET_DTFIM, MET_ALVO, MET_TIPOALVO, IND_ID, MET_RANGE01, MET_RANGE02, MET_RANGE03, DIM_ID, FAT_ID, DIM_SUBDIMENSAO_ID, PER_ID, DOM_EMPRESA, DOM_FILIAL, TenantID, Deleted, Changed, UserId FROM T_Metas ";
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
            this.Query = $"SELECT MET_ID, MET_DTINICIO, MET_DTFIM, MET_ALVO, MET_TIPOALVO, IND_ID, MET_RANGE01, MET_RANGE02, MET_RANGE03, DIM_ID, FAT_ID, DIM_SUBDIMENSAO_ID, PER_ID, DOM_EMPRESA, DOM_FILIAL, TenantID, Deleted, Changed, UserId FROM T_Metas ";
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