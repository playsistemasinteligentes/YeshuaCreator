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
    public class T_MedicoesQueryRead : QueryBase, IT_MedicoesQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public T_MedicoesQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel T_MedicoesQuery(Command.Read.T_MedicoesReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select Id, MED_ID, IND_ID, MET_ID, UNI_ID, MED_DATA, MED_VALOR, MED_AC_ANO, MED_DATAMEDICAO, MED_PONDERACAO, DIM_ID, DIM_DESCRICAO, DIM_SUBDIMENSAO_ID, DIM_SUB_DESCRICAO, PER_ID, PER_DESCRICAO, FAT_ID, FAT_DESCRICAO, MED_SQL, DOM_EMPRESA, DOM_FILIAL, MED_VALOR_DISPER, TenantID, Deleted, Changed, UserId from T_Medicoes ";
if (Command.Id.HasValue) dict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"Id = @Id");
if (Command.MED_ID.HasValue) dict["MED_ID"] = Command.MED_ID.Value;
if (Command.MED_ID.HasValue) whereClauses.Add($"MED_ID = @MED_ID");
if (Command.IND_ID.HasValue) dict["IND_ID"] = Command.IND_ID.Value;
if (Command.IND_ID.HasValue) whereClauses.Add($"IND_ID = @IND_ID");
if (Command.MET_ID.HasValue) dict["MET_ID"] = Command.MET_ID.Value;
if (Command.MET_ID.HasValue) whereClauses.Add($"MET_ID = @MET_ID");
if (Command.UNI_ID.HasValue) dict["UNI_ID"] = Command.UNI_ID.Value;
if (Command.UNI_ID.HasValue) whereClauses.Add($"UNI_ID = @UNI_ID");
if (!string.IsNullOrEmpty(Command.MED_VALOR)) dict["MED_VALOR"] = $"%{Command.MED_VALOR}%";
if (!string.IsNullOrEmpty(Command.MED_VALOR)) whereClauses.Add($"MED_VALOR like @MED_VALOR");
if (!string.IsNullOrEmpty(Command.MED_AC_ANO)) dict["MED_AC_ANO"] = $"%{Command.MED_AC_ANO}%";
if (!string.IsNullOrEmpty(Command.MED_AC_ANO)) whereClauses.Add($"MED_AC_ANO like @MED_AC_ANO");
if (!string.IsNullOrEmpty(Command.MED_DATAMEDICAO)) dict["MED_DATAMEDICAO"] = $"%{Command.MED_DATAMEDICAO}%";
if (!string.IsNullOrEmpty(Command.MED_DATAMEDICAO)) whereClauses.Add($"MED_DATAMEDICAO like @MED_DATAMEDICAO");
if (!string.IsNullOrEmpty(Command.DIM_ID)) dict["DIM_ID"] = $"%{Command.DIM_ID}%";
if (!string.IsNullOrEmpty(Command.DIM_ID)) whereClauses.Add($"DIM_ID like @DIM_ID");
if (!string.IsNullOrEmpty(Command.DIM_DESCRICAO)) dict["DIM_DESCRICAO"] = $"%{Command.DIM_DESCRICAO}%";
if (!string.IsNullOrEmpty(Command.DIM_DESCRICAO)) whereClauses.Add($"DIM_DESCRICAO like @DIM_DESCRICAO");
if (!string.IsNullOrEmpty(Command.DIM_SUBDIMENSAO_ID)) dict["DIM_SUBDIMENSAO_ID"] = $"%{Command.DIM_SUBDIMENSAO_ID}%";
if (!string.IsNullOrEmpty(Command.DIM_SUBDIMENSAO_ID)) whereClauses.Add($"DIM_SUBDIMENSAO_ID like @DIM_SUBDIMENSAO_ID");
if (!string.IsNullOrEmpty(Command.DIM_SUB_DESCRICAO)) dict["DIM_SUB_DESCRICAO"] = $"%{Command.DIM_SUB_DESCRICAO}%";
if (!string.IsNullOrEmpty(Command.DIM_SUB_DESCRICAO)) whereClauses.Add($"DIM_SUB_DESCRICAO like @DIM_SUB_DESCRICAO");
if (!string.IsNullOrEmpty(Command.PER_ID)) dict["PER_ID"] = $"%{Command.PER_ID}%";
if (!string.IsNullOrEmpty(Command.PER_ID)) whereClauses.Add($"PER_ID like @PER_ID");
if (!string.IsNullOrEmpty(Command.PER_DESCRICAO)) dict["PER_DESCRICAO"] = $"%{Command.PER_DESCRICAO}%";
if (!string.IsNullOrEmpty(Command.PER_DESCRICAO)) whereClauses.Add($"PER_DESCRICAO like @PER_DESCRICAO");
if (!string.IsNullOrEmpty(Command.FAT_ID)) dict["FAT_ID"] = $"%{Command.FAT_ID}%";
if (!string.IsNullOrEmpty(Command.FAT_ID)) whereClauses.Add($"FAT_ID like @FAT_ID");
if (!string.IsNullOrEmpty(Command.FAT_DESCRICAO)) dict["FAT_DESCRICAO"] = $"%{Command.FAT_DESCRICAO}%";
if (!string.IsNullOrEmpty(Command.FAT_DESCRICAO)) whereClauses.Add($"FAT_DESCRICAO like @FAT_DESCRICAO");
if (!string.IsNullOrEmpty(Command.MED_SQL)) dict["MED_SQL"] = $"%{Command.MED_SQL}%";
if (!string.IsNullOrEmpty(Command.MED_SQL)) whereClauses.Add($"MED_SQL like @MED_SQL");
if (!string.IsNullOrEmpty(Command.DOM_EMPRESA)) dict["DOM_EMPRESA"] = $"%{Command.DOM_EMPRESA}%";
if (!string.IsNullOrEmpty(Command.DOM_EMPRESA)) whereClauses.Add($"DOM_EMPRESA like @DOM_EMPRESA");
if (!string.IsNullOrEmpty(Command.DOM_FILIAL)) dict["DOM_FILIAL"] = $"%{Command.DOM_FILIAL}%";
if (!string.IsNullOrEmpty(Command.DOM_FILIAL)) whereClauses.Add($"DOM_FILIAL like @DOM_FILIAL");
if (!string.IsNullOrEmpty(Command.MED_VALOR_DISPER)) dict["MED_VALOR_DISPER"] = $"%{Command.MED_VALOR_DISPER}%";
if (!string.IsNullOrEmpty(Command.MED_VALOR_DISPER)) whereClauses.Add($"MED_VALOR_DISPER like @MED_VALOR_DISPER");
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
            Query += " ORDER BY Id OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel T_MedicoesTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel T_MedicoesUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel ExistsByIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Medicoes ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Id"] = value; //04
                      whereClauses.Add($" Id = @Id ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMED_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Medicoes ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MED_ID"] = value; //04
                      whereClauses.Add($" MED_ID = @MED_ID ");//04
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
            this.Query = $"SELECT 1 FROM T_Medicoes ";
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
        public QueryModel ExistsByMET_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Medicoes ";
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
        public QueryModel ExistsByUNI_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Medicoes ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["UNI_ID"] = value; //04
                      whereClauses.Add($" UNI_ID = @UNI_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMED_DATAQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Medicoes ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MED_DATA"] = value; //04
                      whereClauses.Add($" MED_DATA = @MED_DATA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMED_VALORQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Medicoes ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MED_VALOR"] = value; //04
                      whereClauses.Add($" MED_VALOR = @MED_VALOR ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMED_AC_ANOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Medicoes ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MED_AC_ANO"] = value; //04
                      whereClauses.Add($" MED_AC_ANO = @MED_AC_ANO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMED_DATAMEDICAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Medicoes ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MED_DATAMEDICAO"] = value; //04
                      whereClauses.Add($" MED_DATAMEDICAO = @MED_DATAMEDICAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMED_PONDERACAOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Medicoes ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MED_PONDERACAO"] = value; //04
                      whereClauses.Add($" MED_PONDERACAO = @MED_PONDERACAO ");//04
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
            this.Query = $"SELECT 1 FROM T_Medicoes ";
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
        public QueryModel ExistsByDIM_DESCRICAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Medicoes ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["DIM_DESCRICAO"] = value; //04
                      whereClauses.Add($" DIM_DESCRICAO = @DIM_DESCRICAO ");//04
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
            this.Query = $"SELECT 1 FROM T_Medicoes ";
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
        public QueryModel ExistsByDIM_SUB_DESCRICAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Medicoes ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["DIM_SUB_DESCRICAO"] = value; //04
                      whereClauses.Add($" DIM_SUB_DESCRICAO = @DIM_SUB_DESCRICAO ");//04
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
            this.Query = $"SELECT 1 FROM T_Medicoes ";
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
        public QueryModel ExistsByPER_DESCRICAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Medicoes ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PER_DESCRICAO"] = value; //04
                      whereClauses.Add($" PER_DESCRICAO = @PER_DESCRICAO ");//04
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
            this.Query = $"SELECT 1 FROM T_Medicoes ";
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
        public QueryModel ExistsByFAT_DESCRICAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Medicoes ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FAT_DESCRICAO"] = value; //04
                      whereClauses.Add($" FAT_DESCRICAO = @FAT_DESCRICAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMED_SQLQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Medicoes ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MED_SQL"] = value; //04
                      whereClauses.Add($" MED_SQL = @MED_SQL ");//04
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
            this.Query = $"SELECT 1 FROM T_Medicoes ";
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
            this.Query = $"SELECT 1 FROM T_Medicoes ";
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
        public QueryModel ExistsByMED_VALOR_DISPERQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM T_Medicoes ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MED_VALOR_DISPER"] = value; //04
                      whereClauses.Add($" MED_VALOR_DISPER = @MED_VALOR_DISPER ");//04
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
            this.Query = $"SELECT 1 FROM T_Medicoes ";
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
            this.Query = $"SELECT 1 FROM T_Medicoes ";
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
            this.Query = $"SELECT 1 FROM T_Medicoes ";
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
            this.Query = $"SELECT 1 FROM T_Medicoes ";
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
        public QueryModel FirstByIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, MED_ID, IND_ID, MET_ID, UNI_ID, MED_DATA, MED_VALOR, MED_AC_ANO, MED_DATAMEDICAO, MED_PONDERACAO, DIM_ID, DIM_DESCRICAO, DIM_SUBDIMENSAO_ID, DIM_SUB_DESCRICAO, PER_ID, PER_DESCRICAO, FAT_ID, FAT_DESCRICAO, MED_SQL, DOM_EMPRESA, DOM_FILIAL, MED_VALOR_DISPER, TenantID, Deleted, Changed, UserId FROM T_Medicoes ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Id"] = value; //06
                      whereClauses.Add($" Id = @Id ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMED_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, MED_ID, IND_ID, MET_ID, UNI_ID, MED_DATA, MED_VALOR, MED_AC_ANO, MED_DATAMEDICAO, MED_PONDERACAO, DIM_ID, DIM_DESCRICAO, DIM_SUBDIMENSAO_ID, DIM_SUB_DESCRICAO, PER_ID, PER_DESCRICAO, FAT_ID, FAT_DESCRICAO, MED_SQL, DOM_EMPRESA, DOM_FILIAL, MED_VALOR_DISPER, TenantID, Deleted, Changed, UserId FROM T_Medicoes ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MED_ID"] = value; //06
                      whereClauses.Add($" MED_ID = @MED_ID ");//06
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
            this.Query = $"SELECT Id, MED_ID, IND_ID, MET_ID, UNI_ID, MED_DATA, MED_VALOR, MED_AC_ANO, MED_DATAMEDICAO, MED_PONDERACAO, DIM_ID, DIM_DESCRICAO, DIM_SUBDIMENSAO_ID, DIM_SUB_DESCRICAO, PER_ID, PER_DESCRICAO, FAT_ID, FAT_DESCRICAO, MED_SQL, DOM_EMPRESA, DOM_FILIAL, MED_VALOR_DISPER, TenantID, Deleted, Changed, UserId FROM T_Medicoes ";
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
        public QueryModel FirstByMET_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, MED_ID, IND_ID, MET_ID, UNI_ID, MED_DATA, MED_VALOR, MED_AC_ANO, MED_DATAMEDICAO, MED_PONDERACAO, DIM_ID, DIM_DESCRICAO, DIM_SUBDIMENSAO_ID, DIM_SUB_DESCRICAO, PER_ID, PER_DESCRICAO, FAT_ID, FAT_DESCRICAO, MED_SQL, DOM_EMPRESA, DOM_FILIAL, MED_VALOR_DISPER, TenantID, Deleted, Changed, UserId FROM T_Medicoes ";
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
        public QueryModel FirstByUNI_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, MED_ID, IND_ID, MET_ID, UNI_ID, MED_DATA, MED_VALOR, MED_AC_ANO, MED_DATAMEDICAO, MED_PONDERACAO, DIM_ID, DIM_DESCRICAO, DIM_SUBDIMENSAO_ID, DIM_SUB_DESCRICAO, PER_ID, PER_DESCRICAO, FAT_ID, FAT_DESCRICAO, MED_SQL, DOM_EMPRESA, DOM_FILIAL, MED_VALOR_DISPER, TenantID, Deleted, Changed, UserId FROM T_Medicoes ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["UNI_ID"] = value; //06
                      whereClauses.Add($" UNI_ID = @UNI_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMED_DATAQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, MED_ID, IND_ID, MET_ID, UNI_ID, MED_DATA, MED_VALOR, MED_AC_ANO, MED_DATAMEDICAO, MED_PONDERACAO, DIM_ID, DIM_DESCRICAO, DIM_SUBDIMENSAO_ID, DIM_SUB_DESCRICAO, PER_ID, PER_DESCRICAO, FAT_ID, FAT_DESCRICAO, MED_SQL, DOM_EMPRESA, DOM_FILIAL, MED_VALOR_DISPER, TenantID, Deleted, Changed, UserId FROM T_Medicoes ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MED_DATA"] = value; //06
                      whereClauses.Add($" MED_DATA = @MED_DATA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMED_VALORQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, MED_ID, IND_ID, MET_ID, UNI_ID, MED_DATA, MED_VALOR, MED_AC_ANO, MED_DATAMEDICAO, MED_PONDERACAO, DIM_ID, DIM_DESCRICAO, DIM_SUBDIMENSAO_ID, DIM_SUB_DESCRICAO, PER_ID, PER_DESCRICAO, FAT_ID, FAT_DESCRICAO, MED_SQL, DOM_EMPRESA, DOM_FILIAL, MED_VALOR_DISPER, TenantID, Deleted, Changed, UserId FROM T_Medicoes ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MED_VALOR"] = value; //06
                      whereClauses.Add($" MED_VALOR = @MED_VALOR ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMED_AC_ANOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, MED_ID, IND_ID, MET_ID, UNI_ID, MED_DATA, MED_VALOR, MED_AC_ANO, MED_DATAMEDICAO, MED_PONDERACAO, DIM_ID, DIM_DESCRICAO, DIM_SUBDIMENSAO_ID, DIM_SUB_DESCRICAO, PER_ID, PER_DESCRICAO, FAT_ID, FAT_DESCRICAO, MED_SQL, DOM_EMPRESA, DOM_FILIAL, MED_VALOR_DISPER, TenantID, Deleted, Changed, UserId FROM T_Medicoes ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MED_AC_ANO"] = value; //06
                      whereClauses.Add($" MED_AC_ANO = @MED_AC_ANO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMED_DATAMEDICAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, MED_ID, IND_ID, MET_ID, UNI_ID, MED_DATA, MED_VALOR, MED_AC_ANO, MED_DATAMEDICAO, MED_PONDERACAO, DIM_ID, DIM_DESCRICAO, DIM_SUBDIMENSAO_ID, DIM_SUB_DESCRICAO, PER_ID, PER_DESCRICAO, FAT_ID, FAT_DESCRICAO, MED_SQL, DOM_EMPRESA, DOM_FILIAL, MED_VALOR_DISPER, TenantID, Deleted, Changed, UserId FROM T_Medicoes ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MED_DATAMEDICAO"] = value; //06
                      whereClauses.Add($" MED_DATAMEDICAO = @MED_DATAMEDICAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMED_PONDERACAOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, MED_ID, IND_ID, MET_ID, UNI_ID, MED_DATA, MED_VALOR, MED_AC_ANO, MED_DATAMEDICAO, MED_PONDERACAO, DIM_ID, DIM_DESCRICAO, DIM_SUBDIMENSAO_ID, DIM_SUB_DESCRICAO, PER_ID, PER_DESCRICAO, FAT_ID, FAT_DESCRICAO, MED_SQL, DOM_EMPRESA, DOM_FILIAL, MED_VALOR_DISPER, TenantID, Deleted, Changed, UserId FROM T_Medicoes ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MED_PONDERACAO"] = value; //06
                      whereClauses.Add($" MED_PONDERACAO = @MED_PONDERACAO ");//06
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
            this.Query = $"SELECT Id, MED_ID, IND_ID, MET_ID, UNI_ID, MED_DATA, MED_VALOR, MED_AC_ANO, MED_DATAMEDICAO, MED_PONDERACAO, DIM_ID, DIM_DESCRICAO, DIM_SUBDIMENSAO_ID, DIM_SUB_DESCRICAO, PER_ID, PER_DESCRICAO, FAT_ID, FAT_DESCRICAO, MED_SQL, DOM_EMPRESA, DOM_FILIAL, MED_VALOR_DISPER, TenantID, Deleted, Changed, UserId FROM T_Medicoes ";
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
        public QueryModel FirstByDIM_DESCRICAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, MED_ID, IND_ID, MET_ID, UNI_ID, MED_DATA, MED_VALOR, MED_AC_ANO, MED_DATAMEDICAO, MED_PONDERACAO, DIM_ID, DIM_DESCRICAO, DIM_SUBDIMENSAO_ID, DIM_SUB_DESCRICAO, PER_ID, PER_DESCRICAO, FAT_ID, FAT_DESCRICAO, MED_SQL, DOM_EMPRESA, DOM_FILIAL, MED_VALOR_DISPER, TenantID, Deleted, Changed, UserId FROM T_Medicoes ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["DIM_DESCRICAO"] = value; //06
                      whereClauses.Add($" DIM_DESCRICAO = @DIM_DESCRICAO ");//06
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
            this.Query = $"SELECT Id, MED_ID, IND_ID, MET_ID, UNI_ID, MED_DATA, MED_VALOR, MED_AC_ANO, MED_DATAMEDICAO, MED_PONDERACAO, DIM_ID, DIM_DESCRICAO, DIM_SUBDIMENSAO_ID, DIM_SUB_DESCRICAO, PER_ID, PER_DESCRICAO, FAT_ID, FAT_DESCRICAO, MED_SQL, DOM_EMPRESA, DOM_FILIAL, MED_VALOR_DISPER, TenantID, Deleted, Changed, UserId FROM T_Medicoes ";
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
        public QueryModel FirstByDIM_SUB_DESCRICAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, MED_ID, IND_ID, MET_ID, UNI_ID, MED_DATA, MED_VALOR, MED_AC_ANO, MED_DATAMEDICAO, MED_PONDERACAO, DIM_ID, DIM_DESCRICAO, DIM_SUBDIMENSAO_ID, DIM_SUB_DESCRICAO, PER_ID, PER_DESCRICAO, FAT_ID, FAT_DESCRICAO, MED_SQL, DOM_EMPRESA, DOM_FILIAL, MED_VALOR_DISPER, TenantID, Deleted, Changed, UserId FROM T_Medicoes ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["DIM_SUB_DESCRICAO"] = value; //06
                      whereClauses.Add($" DIM_SUB_DESCRICAO = @DIM_SUB_DESCRICAO ");//06
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
            this.Query = $"SELECT Id, MED_ID, IND_ID, MET_ID, UNI_ID, MED_DATA, MED_VALOR, MED_AC_ANO, MED_DATAMEDICAO, MED_PONDERACAO, DIM_ID, DIM_DESCRICAO, DIM_SUBDIMENSAO_ID, DIM_SUB_DESCRICAO, PER_ID, PER_DESCRICAO, FAT_ID, FAT_DESCRICAO, MED_SQL, DOM_EMPRESA, DOM_FILIAL, MED_VALOR_DISPER, TenantID, Deleted, Changed, UserId FROM T_Medicoes ";
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
        public QueryModel FirstByPER_DESCRICAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, MED_ID, IND_ID, MET_ID, UNI_ID, MED_DATA, MED_VALOR, MED_AC_ANO, MED_DATAMEDICAO, MED_PONDERACAO, DIM_ID, DIM_DESCRICAO, DIM_SUBDIMENSAO_ID, DIM_SUB_DESCRICAO, PER_ID, PER_DESCRICAO, FAT_ID, FAT_DESCRICAO, MED_SQL, DOM_EMPRESA, DOM_FILIAL, MED_VALOR_DISPER, TenantID, Deleted, Changed, UserId FROM T_Medicoes ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PER_DESCRICAO"] = value; //06
                      whereClauses.Add($" PER_DESCRICAO = @PER_DESCRICAO ");//06
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
            this.Query = $"SELECT Id, MED_ID, IND_ID, MET_ID, UNI_ID, MED_DATA, MED_VALOR, MED_AC_ANO, MED_DATAMEDICAO, MED_PONDERACAO, DIM_ID, DIM_DESCRICAO, DIM_SUBDIMENSAO_ID, DIM_SUB_DESCRICAO, PER_ID, PER_DESCRICAO, FAT_ID, FAT_DESCRICAO, MED_SQL, DOM_EMPRESA, DOM_FILIAL, MED_VALOR_DISPER, TenantID, Deleted, Changed, UserId FROM T_Medicoes ";
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
        public QueryModel FirstByFAT_DESCRICAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, MED_ID, IND_ID, MET_ID, UNI_ID, MED_DATA, MED_VALOR, MED_AC_ANO, MED_DATAMEDICAO, MED_PONDERACAO, DIM_ID, DIM_DESCRICAO, DIM_SUBDIMENSAO_ID, DIM_SUB_DESCRICAO, PER_ID, PER_DESCRICAO, FAT_ID, FAT_DESCRICAO, MED_SQL, DOM_EMPRESA, DOM_FILIAL, MED_VALOR_DISPER, TenantID, Deleted, Changed, UserId FROM T_Medicoes ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FAT_DESCRICAO"] = value; //06
                      whereClauses.Add($" FAT_DESCRICAO = @FAT_DESCRICAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMED_SQLQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, MED_ID, IND_ID, MET_ID, UNI_ID, MED_DATA, MED_VALOR, MED_AC_ANO, MED_DATAMEDICAO, MED_PONDERACAO, DIM_ID, DIM_DESCRICAO, DIM_SUBDIMENSAO_ID, DIM_SUB_DESCRICAO, PER_ID, PER_DESCRICAO, FAT_ID, FAT_DESCRICAO, MED_SQL, DOM_EMPRESA, DOM_FILIAL, MED_VALOR_DISPER, TenantID, Deleted, Changed, UserId FROM T_Medicoes ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MED_SQL"] = value; //06
                      whereClauses.Add($" MED_SQL = @MED_SQL ");//06
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
            this.Query = $"SELECT Id, MED_ID, IND_ID, MET_ID, UNI_ID, MED_DATA, MED_VALOR, MED_AC_ANO, MED_DATAMEDICAO, MED_PONDERACAO, DIM_ID, DIM_DESCRICAO, DIM_SUBDIMENSAO_ID, DIM_SUB_DESCRICAO, PER_ID, PER_DESCRICAO, FAT_ID, FAT_DESCRICAO, MED_SQL, DOM_EMPRESA, DOM_FILIAL, MED_VALOR_DISPER, TenantID, Deleted, Changed, UserId FROM T_Medicoes ";
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
            this.Query = $"SELECT Id, MED_ID, IND_ID, MET_ID, UNI_ID, MED_DATA, MED_VALOR, MED_AC_ANO, MED_DATAMEDICAO, MED_PONDERACAO, DIM_ID, DIM_DESCRICAO, DIM_SUBDIMENSAO_ID, DIM_SUB_DESCRICAO, PER_ID, PER_DESCRICAO, FAT_ID, FAT_DESCRICAO, MED_SQL, DOM_EMPRESA, DOM_FILIAL, MED_VALOR_DISPER, TenantID, Deleted, Changed, UserId FROM T_Medicoes ";
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
        public QueryModel FirstByMED_VALOR_DISPERQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, MED_ID, IND_ID, MET_ID, UNI_ID, MED_DATA, MED_VALOR, MED_AC_ANO, MED_DATAMEDICAO, MED_PONDERACAO, DIM_ID, DIM_DESCRICAO, DIM_SUBDIMENSAO_ID, DIM_SUB_DESCRICAO, PER_ID, PER_DESCRICAO, FAT_ID, FAT_DESCRICAO, MED_SQL, DOM_EMPRESA, DOM_FILIAL, MED_VALOR_DISPER, TenantID, Deleted, Changed, UserId FROM T_Medicoes ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MED_VALOR_DISPER"] = value; //06
                      whereClauses.Add($" MED_VALOR_DISPER = @MED_VALOR_DISPER ");//06
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
            this.Query = $"SELECT Id, MED_ID, IND_ID, MET_ID, UNI_ID, MED_DATA, MED_VALOR, MED_AC_ANO, MED_DATAMEDICAO, MED_PONDERACAO, DIM_ID, DIM_DESCRICAO, DIM_SUBDIMENSAO_ID, DIM_SUB_DESCRICAO, PER_ID, PER_DESCRICAO, FAT_ID, FAT_DESCRICAO, MED_SQL, DOM_EMPRESA, DOM_FILIAL, MED_VALOR_DISPER, TenantID, Deleted, Changed, UserId FROM T_Medicoes ";
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
            this.Query = $"SELECT Id, MED_ID, IND_ID, MET_ID, UNI_ID, MED_DATA, MED_VALOR, MED_AC_ANO, MED_DATAMEDICAO, MED_PONDERACAO, DIM_ID, DIM_DESCRICAO, DIM_SUBDIMENSAO_ID, DIM_SUB_DESCRICAO, PER_ID, PER_DESCRICAO, FAT_ID, FAT_DESCRICAO, MED_SQL, DOM_EMPRESA, DOM_FILIAL, MED_VALOR_DISPER, TenantID, Deleted, Changed, UserId FROM T_Medicoes ";
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
            this.Query = $"SELECT Id, MED_ID, IND_ID, MET_ID, UNI_ID, MED_DATA, MED_VALOR, MED_AC_ANO, MED_DATAMEDICAO, MED_PONDERACAO, DIM_ID, DIM_DESCRICAO, DIM_SUBDIMENSAO_ID, DIM_SUB_DESCRICAO, PER_ID, PER_DESCRICAO, FAT_ID, FAT_DESCRICAO, MED_SQL, DOM_EMPRESA, DOM_FILIAL, MED_VALOR_DISPER, TenantID, Deleted, Changed, UserId FROM T_Medicoes ";
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
            this.Query = $"SELECT Id, MED_ID, IND_ID, MET_ID, UNI_ID, MED_DATA, MED_VALOR, MED_AC_ANO, MED_DATAMEDICAO, MED_PONDERACAO, DIM_ID, DIM_DESCRICAO, DIM_SUBDIMENSAO_ID, DIM_SUB_DESCRICAO, PER_ID, PER_DESCRICAO, FAT_ID, FAT_DESCRICAO, MED_SQL, DOM_EMPRESA, DOM_FILIAL, MED_VALOR_DISPER, TenantID, Deleted, Changed, UserId FROM T_Medicoes ";
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