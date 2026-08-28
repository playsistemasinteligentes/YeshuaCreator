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
    public class ClpMedicoesHQueryRead : QueryBase, IClpMedicoesHQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public ClpMedicoesHQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel ClpMedicoesHQuery(Command.Read.ClpMedicoesHReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select ID, MAQUINA_ID, DATA_INI, DATA_FIM, CLP_EMISSAO, QTD, GRUPO, STATUS, URN_ID, URM_ID, ID_LOTE_CLP, OCO_ID, FASE, CLP_ORIGEM, CLP_LOTE, COMPACTA, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId from ClpMedicoesH ";
if (Command.ID.HasValue) dict["ID"] = Command.ID.Value;
if (Command.ID.HasValue) whereClauses.Add($"ID = @ID");
if (!string.IsNullOrEmpty(Command.MAQUINA_ID)) dict["MAQUINA_ID"] = $"%{Command.MAQUINA_ID}%";
if (!string.IsNullOrEmpty(Command.MAQUINA_ID)) whereClauses.Add($"MAQUINA_ID like @MAQUINA_ID");
if (Command.STATUS.HasValue) dict["STATUS"] = Command.STATUS.Value;
if (Command.STATUS.HasValue) whereClauses.Add($"STATUS = @STATUS");
if (!string.IsNullOrEmpty(Command.URN_ID)) dict["URN_ID"] = $"%{Command.URN_ID}%";
if (!string.IsNullOrEmpty(Command.URN_ID)) whereClauses.Add($"URN_ID like @URN_ID");
if (!string.IsNullOrEmpty(Command.URM_ID)) dict["URM_ID"] = $"%{Command.URM_ID}%";
if (!string.IsNullOrEmpty(Command.URM_ID)) whereClauses.Add($"URM_ID like @URM_ID");
if (Command.ID_LOTE_CLP.HasValue) dict["ID_LOTE_CLP"] = Command.ID_LOTE_CLP.Value;
if (Command.ID_LOTE_CLP.HasValue) whereClauses.Add($"ID_LOTE_CLP = @ID_LOTE_CLP");
if (!string.IsNullOrEmpty(Command.OCO_ID)) dict["OCO_ID"] = $"%{Command.OCO_ID}%";
if (!string.IsNullOrEmpty(Command.OCO_ID)) whereClauses.Add($"OCO_ID like @OCO_ID");
if (Command.FASE.HasValue) dict["FASE"] = Command.FASE.Value;
if (Command.FASE.HasValue) whereClauses.Add($"FASE = @FASE");
if (!string.IsNullOrEmpty(Command.CLP_ORIGEM)) dict["CLP_ORIGEM"] = $"%{Command.CLP_ORIGEM}%";
if (!string.IsNullOrEmpty(Command.CLP_ORIGEM)) whereClauses.Add($"CLP_ORIGEM like @CLP_ORIGEM");
if (Command.CLP_LOTE.HasValue) dict["CLP_LOTE"] = Command.CLP_LOTE.Value;
if (Command.CLP_LOTE.HasValue) whereClauses.Add($"CLP_LOTE = @CLP_LOTE");
if (Command.COMPACTA.HasValue) dict["COMPACTA"] = Command.COMPACTA.Value;
if (Command.COMPACTA.HasValue) whereClauses.Add($"COMPACTA = @COMPACTA");
if (!string.IsNullOrEmpty(Command.BOL_ID)) dict["BOL_ID"] = $"%{Command.BOL_ID}%";
if (!string.IsNullOrEmpty(Command.BOL_ID)) whereClauses.Add($"BOL_ID like @BOL_ID");
if (Command.COR_SEQUENCIA.HasValue) dict["COR_SEQUENCIA"] = Command.COR_SEQUENCIA.Value;
if (Command.COR_SEQUENCIA.HasValue) whereClauses.Add($"COR_SEQUENCIA = @COR_SEQUENCIA");
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
            Query += " ORDER BY ID OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel ClpMedicoesHTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel ClpMedicoesHUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel ExistsByIDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM ClpMedicoesH ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ID"] = value; //04
                      whereClauses.Add($" ID = @ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQUINA_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM ClpMedicoesH ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MAQUINA_ID"] = value; //04
                      whereClauses.Add($" MAQUINA_ID = @MAQUINA_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByDATA_INIQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM ClpMedicoesH ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["DATA_INI"] = value; //04
                      whereClauses.Add($" DATA_INI = @DATA_INI ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByDATA_FIMQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM ClpMedicoesH ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["DATA_FIM"] = value; //04
                      whereClauses.Add($" DATA_FIM = @DATA_FIM ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCLP_EMISSAOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM ClpMedicoesH ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CLP_EMISSAO"] = value; //04
                      whereClauses.Add($" CLP_EMISSAO = @CLP_EMISSAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByQTDQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM ClpMedicoesH ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["QTD"] = value; //04
                      whereClauses.Add($" QTD = @QTD ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRUPOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM ClpMedicoesH ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRUPO"] = value; //04
                      whereClauses.Add($" GRUPO = @GRUPO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsBySTATUSQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM ClpMedicoesH ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["STATUS"] = value; //04
                      whereClauses.Add($" STATUS = @STATUS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByURN_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM ClpMedicoesH ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["URN_ID"] = value; //04
                      whereClauses.Add($" URN_ID = @URN_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByURM_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM ClpMedicoesH ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["URM_ID"] = value; //04
                      whereClauses.Add($" URM_ID = @URM_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByID_LOTE_CLPQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM ClpMedicoesH ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ID_LOTE_CLP"] = value; //04
                      whereClauses.Add($" ID_LOTE_CLP = @ID_LOTE_CLP ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByOCO_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM ClpMedicoesH ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["OCO_ID"] = value; //04
                      whereClauses.Add($" OCO_ID = @OCO_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFASEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM ClpMedicoesH ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FASE"] = value; //04
                      whereClauses.Add($" FASE = @FASE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCLP_ORIGEMQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM ClpMedicoesH ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CLP_ORIGEM"] = value; //04
                      whereClauses.Add($" CLP_ORIGEM = @CLP_ORIGEM ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCLP_LOTEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM ClpMedicoesH ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CLP_LOTE"] = value; //04
                      whereClauses.Add($" CLP_LOTE = @CLP_LOTE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOMPACTAQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM ClpMedicoesH ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["COMPACTA"] = value; //04
                      whereClauses.Add($" COMPACTA = @COMPACTA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByBOL_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM ClpMedicoesH ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["BOL_ID"] = value; //04
                      whereClauses.Add($" BOL_ID = @BOL_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOR_SEQUENCIAQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM ClpMedicoesH ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["COR_SEQUENCIA"] = value; //04
                      whereClauses.Add($" COR_SEQUENCIA = @COR_SEQUENCIA ");//04
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
            this.Query = $"SELECT 1 FROM ClpMedicoesH ";
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
            this.Query = $"SELECT 1 FROM ClpMedicoesH ";
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
            this.Query = $"SELECT 1 FROM ClpMedicoesH ";
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
            this.Query = $"SELECT 1 FROM ClpMedicoesH ";
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
        public QueryModel FirstByIDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ID, MAQUINA_ID, DATA_INI, DATA_FIM, CLP_EMISSAO, QTD, GRUPO, STATUS, URN_ID, URM_ID, ID_LOTE_CLP, OCO_ID, FASE, CLP_ORIGEM, CLP_LOTE, COMPACTA, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM ClpMedicoesH ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ID"] = value; //06
                      whereClauses.Add($" ID = @ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQUINA_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ID, MAQUINA_ID, DATA_INI, DATA_FIM, CLP_EMISSAO, QTD, GRUPO, STATUS, URN_ID, URM_ID, ID_LOTE_CLP, OCO_ID, FASE, CLP_ORIGEM, CLP_LOTE, COMPACTA, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM ClpMedicoesH ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MAQUINA_ID"] = value; //06
                      whereClauses.Add($" MAQUINA_ID = @MAQUINA_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByDATA_INIQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ID, MAQUINA_ID, DATA_INI, DATA_FIM, CLP_EMISSAO, QTD, GRUPO, STATUS, URN_ID, URM_ID, ID_LOTE_CLP, OCO_ID, FASE, CLP_ORIGEM, CLP_LOTE, COMPACTA, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM ClpMedicoesH ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["DATA_INI"] = value; //06
                      whereClauses.Add($" DATA_INI = @DATA_INI ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByDATA_FIMQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ID, MAQUINA_ID, DATA_INI, DATA_FIM, CLP_EMISSAO, QTD, GRUPO, STATUS, URN_ID, URM_ID, ID_LOTE_CLP, OCO_ID, FASE, CLP_ORIGEM, CLP_LOTE, COMPACTA, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM ClpMedicoesH ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["DATA_FIM"] = value; //06
                      whereClauses.Add($" DATA_FIM = @DATA_FIM ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCLP_EMISSAOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ID, MAQUINA_ID, DATA_INI, DATA_FIM, CLP_EMISSAO, QTD, GRUPO, STATUS, URN_ID, URM_ID, ID_LOTE_CLP, OCO_ID, FASE, CLP_ORIGEM, CLP_LOTE, COMPACTA, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM ClpMedicoesH ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CLP_EMISSAO"] = value; //06
                      whereClauses.Add($" CLP_EMISSAO = @CLP_EMISSAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByQTDQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ID, MAQUINA_ID, DATA_INI, DATA_FIM, CLP_EMISSAO, QTD, GRUPO, STATUS, URN_ID, URM_ID, ID_LOTE_CLP, OCO_ID, FASE, CLP_ORIGEM, CLP_LOTE, COMPACTA, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM ClpMedicoesH ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["QTD"] = value; //06
                      whereClauses.Add($" QTD = @QTD ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRUPOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ID, MAQUINA_ID, DATA_INI, DATA_FIM, CLP_EMISSAO, QTD, GRUPO, STATUS, URN_ID, URM_ID, ID_LOTE_CLP, OCO_ID, FASE, CLP_ORIGEM, CLP_LOTE, COMPACTA, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM ClpMedicoesH ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRUPO"] = value; //06
                      whereClauses.Add($" GRUPO = @GRUPO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstBySTATUSQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ID, MAQUINA_ID, DATA_INI, DATA_FIM, CLP_EMISSAO, QTD, GRUPO, STATUS, URN_ID, URM_ID, ID_LOTE_CLP, OCO_ID, FASE, CLP_ORIGEM, CLP_LOTE, COMPACTA, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM ClpMedicoesH ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["STATUS"] = value; //06
                      whereClauses.Add($" STATUS = @STATUS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByURN_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ID, MAQUINA_ID, DATA_INI, DATA_FIM, CLP_EMISSAO, QTD, GRUPO, STATUS, URN_ID, URM_ID, ID_LOTE_CLP, OCO_ID, FASE, CLP_ORIGEM, CLP_LOTE, COMPACTA, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM ClpMedicoesH ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["URN_ID"] = value; //06
                      whereClauses.Add($" URN_ID = @URN_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByURM_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ID, MAQUINA_ID, DATA_INI, DATA_FIM, CLP_EMISSAO, QTD, GRUPO, STATUS, URN_ID, URM_ID, ID_LOTE_CLP, OCO_ID, FASE, CLP_ORIGEM, CLP_LOTE, COMPACTA, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM ClpMedicoesH ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["URM_ID"] = value; //06
                      whereClauses.Add($" URM_ID = @URM_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByID_LOTE_CLPQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ID, MAQUINA_ID, DATA_INI, DATA_FIM, CLP_EMISSAO, QTD, GRUPO, STATUS, URN_ID, URM_ID, ID_LOTE_CLP, OCO_ID, FASE, CLP_ORIGEM, CLP_LOTE, COMPACTA, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM ClpMedicoesH ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ID_LOTE_CLP"] = value; //06
                      whereClauses.Add($" ID_LOTE_CLP = @ID_LOTE_CLP ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByOCO_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ID, MAQUINA_ID, DATA_INI, DATA_FIM, CLP_EMISSAO, QTD, GRUPO, STATUS, URN_ID, URM_ID, ID_LOTE_CLP, OCO_ID, FASE, CLP_ORIGEM, CLP_LOTE, COMPACTA, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM ClpMedicoesH ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["OCO_ID"] = value; //06
                      whereClauses.Add($" OCO_ID = @OCO_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFASEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ID, MAQUINA_ID, DATA_INI, DATA_FIM, CLP_EMISSAO, QTD, GRUPO, STATUS, URN_ID, URM_ID, ID_LOTE_CLP, OCO_ID, FASE, CLP_ORIGEM, CLP_LOTE, COMPACTA, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM ClpMedicoesH ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FASE"] = value; //06
                      whereClauses.Add($" FASE = @FASE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCLP_ORIGEMQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ID, MAQUINA_ID, DATA_INI, DATA_FIM, CLP_EMISSAO, QTD, GRUPO, STATUS, URN_ID, URM_ID, ID_LOTE_CLP, OCO_ID, FASE, CLP_ORIGEM, CLP_LOTE, COMPACTA, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM ClpMedicoesH ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CLP_ORIGEM"] = value; //06
                      whereClauses.Add($" CLP_ORIGEM = @CLP_ORIGEM ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCLP_LOTEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ID, MAQUINA_ID, DATA_INI, DATA_FIM, CLP_EMISSAO, QTD, GRUPO, STATUS, URN_ID, URM_ID, ID_LOTE_CLP, OCO_ID, FASE, CLP_ORIGEM, CLP_LOTE, COMPACTA, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM ClpMedicoesH ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CLP_LOTE"] = value; //06
                      whereClauses.Add($" CLP_LOTE = @CLP_LOTE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOMPACTAQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ID, MAQUINA_ID, DATA_INI, DATA_FIM, CLP_EMISSAO, QTD, GRUPO, STATUS, URN_ID, URM_ID, ID_LOTE_CLP, OCO_ID, FASE, CLP_ORIGEM, CLP_LOTE, COMPACTA, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM ClpMedicoesH ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["COMPACTA"] = value; //06
                      whereClauses.Add($" COMPACTA = @COMPACTA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByBOL_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ID, MAQUINA_ID, DATA_INI, DATA_FIM, CLP_EMISSAO, QTD, GRUPO, STATUS, URN_ID, URM_ID, ID_LOTE_CLP, OCO_ID, FASE, CLP_ORIGEM, CLP_LOTE, COMPACTA, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM ClpMedicoesH ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["BOL_ID"] = value; //06
                      whereClauses.Add($" BOL_ID = @BOL_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOR_SEQUENCIAQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ID, MAQUINA_ID, DATA_INI, DATA_FIM, CLP_EMISSAO, QTD, GRUPO, STATUS, URN_ID, URM_ID, ID_LOTE_CLP, OCO_ID, FASE, CLP_ORIGEM, CLP_LOTE, COMPACTA, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM ClpMedicoesH ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["COR_SEQUENCIA"] = value; //06
                      whereClauses.Add($" COR_SEQUENCIA = @COR_SEQUENCIA ");//06
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
            this.Query = $"SELECT ID, MAQUINA_ID, DATA_INI, DATA_FIM, CLP_EMISSAO, QTD, GRUPO, STATUS, URN_ID, URM_ID, ID_LOTE_CLP, OCO_ID, FASE, CLP_ORIGEM, CLP_LOTE, COMPACTA, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM ClpMedicoesH ";
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
            this.Query = $"SELECT ID, MAQUINA_ID, DATA_INI, DATA_FIM, CLP_EMISSAO, QTD, GRUPO, STATUS, URN_ID, URM_ID, ID_LOTE_CLP, OCO_ID, FASE, CLP_ORIGEM, CLP_LOTE, COMPACTA, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM ClpMedicoesH ";
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
            this.Query = $"SELECT ID, MAQUINA_ID, DATA_INI, DATA_FIM, CLP_EMISSAO, QTD, GRUPO, STATUS, URN_ID, URM_ID, ID_LOTE_CLP, OCO_ID, FASE, CLP_ORIGEM, CLP_LOTE, COMPACTA, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM ClpMedicoesH ";
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
            this.Query = $"SELECT ID, MAQUINA_ID, DATA_INI, DATA_FIM, CLP_EMISSAO, QTD, GRUPO, STATUS, URN_ID, URM_ID, ID_LOTE_CLP, OCO_ID, FASE, CLP_ORIGEM, CLP_LOTE, COMPACTA, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM ClpMedicoesH ";
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