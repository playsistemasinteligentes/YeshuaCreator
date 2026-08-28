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
    public class InspecaoVisualQueryRead : QueryBase, IInspecaoVisualQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public InspecaoVisualQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InspecaoVisualQuery(Command.Read.InspecaoVisualReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select IPV_ID, IPV_VALOR, IPV_ID_OPERADOR, IPV_ID_LIBERACAO, IPV_OBS, IPV_DATA_COLETA, IPV_DATA_AVAL, TIV_ID, TURN_ID, TURM_ID, ORD_ID, ROT_PRO_ID, ROT_MAQ_ID, ROT_SEQ_TRANSFORMACAO, FPR_SEQ_REPETICAO, IPV_STATUS_LIBERACAO, IPV_VALOR_MEDIDA, TenantID, Deleted, Changed, UserId from InspecaoVisual ";
if (Command.IPV_ID.HasValue) dict["IPV_ID"] = Command.IPV_ID.Value;
if (Command.IPV_ID.HasValue) whereClauses.Add($"IPV_ID = @IPV_ID");
if (!string.IsNullOrEmpty(Command.IPV_VALOR)) dict["IPV_VALOR"] = $"%{Command.IPV_VALOR}%";
if (!string.IsNullOrEmpty(Command.IPV_VALOR)) whereClauses.Add($"IPV_VALOR like @IPV_VALOR");
if (Command.IPV_ID_OPERADOR.HasValue) dict["IPV_ID_OPERADOR"] = Command.IPV_ID_OPERADOR.Value;
if (Command.IPV_ID_OPERADOR.HasValue) whereClauses.Add($"IPV_ID_OPERADOR = @IPV_ID_OPERADOR");
if (Command.IPV_ID_LIBERACAO.HasValue) dict["IPV_ID_LIBERACAO"] = Command.IPV_ID_LIBERACAO.Value;
if (Command.IPV_ID_LIBERACAO.HasValue) whereClauses.Add($"IPV_ID_LIBERACAO = @IPV_ID_LIBERACAO");
if (!string.IsNullOrEmpty(Command.IPV_OBS)) dict["IPV_OBS"] = $"%{Command.IPV_OBS}%";
if (!string.IsNullOrEmpty(Command.IPV_OBS)) whereClauses.Add($"IPV_OBS like @IPV_OBS");
if (Command.TIV_ID.HasValue) dict["TIV_ID"] = Command.TIV_ID.Value;
if (Command.TIV_ID.HasValue) whereClauses.Add($"TIV_ID = @TIV_ID");
if (!string.IsNullOrEmpty(Command.TURN_ID)) dict["TURN_ID"] = $"%{Command.TURN_ID}%";
if (!string.IsNullOrEmpty(Command.TURN_ID)) whereClauses.Add($"TURN_ID like @TURN_ID");
if (!string.IsNullOrEmpty(Command.TURM_ID)) dict["TURM_ID"] = $"%{Command.TURM_ID}%";
if (!string.IsNullOrEmpty(Command.TURM_ID)) whereClauses.Add($"TURM_ID like @TURM_ID");
if (!string.IsNullOrEmpty(Command.ORD_ID)) dict["ORD_ID"] = $"%{Command.ORD_ID}%";
if (!string.IsNullOrEmpty(Command.ORD_ID)) whereClauses.Add($"ORD_ID like @ORD_ID");
if (!string.IsNullOrEmpty(Command.ROT_PRO_ID)) dict["ROT_PRO_ID"] = $"%{Command.ROT_PRO_ID}%";
if (!string.IsNullOrEmpty(Command.ROT_PRO_ID)) whereClauses.Add($"ROT_PRO_ID like @ROT_PRO_ID");
if (!string.IsNullOrEmpty(Command.ROT_MAQ_ID)) dict["ROT_MAQ_ID"] = $"%{Command.ROT_MAQ_ID}%";
if (!string.IsNullOrEmpty(Command.ROT_MAQ_ID)) whereClauses.Add($"ROT_MAQ_ID like @ROT_MAQ_ID");
if (Command.ROT_SEQ_TRANSFORMACAO.HasValue) dict["ROT_SEQ_TRANSFORMACAO"] = Command.ROT_SEQ_TRANSFORMACAO.Value;
if (Command.ROT_SEQ_TRANSFORMACAO.HasValue) whereClauses.Add($"ROT_SEQ_TRANSFORMACAO = @ROT_SEQ_TRANSFORMACAO");
if (Command.FPR_SEQ_REPETICAO.HasValue) dict["FPR_SEQ_REPETICAO"] = Command.FPR_SEQ_REPETICAO.Value;
if (Command.FPR_SEQ_REPETICAO.HasValue) whereClauses.Add($"FPR_SEQ_REPETICAO = @FPR_SEQ_REPETICAO");
if (!string.IsNullOrEmpty(Command.IPV_STATUS_LIBERACAO)) dict["IPV_STATUS_LIBERACAO"] = $"%{Command.IPV_STATUS_LIBERACAO}%";
if (!string.IsNullOrEmpty(Command.IPV_STATUS_LIBERACAO)) whereClauses.Add($"IPV_STATUS_LIBERACAO like @IPV_STATUS_LIBERACAO");
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
            Query += " ORDER BY IPV_ID OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel InspecaoVisualTURN_IDQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select Id, Descricao from Turno ";
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
                      dict["Descricao"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" Descricao like @Descricao ");//02
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
        public QueryModel InspecaoVisualTURM_IDQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select Id, Descricao from Turma ";
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
                      dict["Descricao"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" Descricao like @Descricao ");//02
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
        public QueryModel InspecaoVisualTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel InspecaoVisualUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel ExistsByIPV_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM InspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["IPV_ID"] = value; //04
                      whereClauses.Add($" IPV_ID = @IPV_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByIPV_VALORQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM InspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["IPV_VALOR"] = value; //04
                      whereClauses.Add($" IPV_VALOR = @IPV_VALOR ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByIPV_ID_OPERADORQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM InspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["IPV_ID_OPERADOR"] = value; //04
                      whereClauses.Add($" IPV_ID_OPERADOR = @IPV_ID_OPERADOR ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByIPV_ID_LIBERACAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM InspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["IPV_ID_LIBERACAO"] = value; //04
                      whereClauses.Add($" IPV_ID_LIBERACAO = @IPV_ID_LIBERACAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByIPV_OBSQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM InspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["IPV_OBS"] = value; //04
                      whereClauses.Add($" IPV_OBS = @IPV_OBS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByIPV_DATA_COLETAQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM InspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["IPV_DATA_COLETA"] = value; //04
                      whereClauses.Add($" IPV_DATA_COLETA = @IPV_DATA_COLETA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByIPV_DATA_AVALQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM InspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["IPV_DATA_AVAL"] = value; //04
                      whereClauses.Add($" IPV_DATA_AVAL = @IPV_DATA_AVAL ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTIV_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM InspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TIV_ID"] = value; //04
                      whereClauses.Add($" TIV_ID = @TIV_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTURN_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM InspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TURN_ID"] = value; //04
                      whereClauses.Add($" TURN_ID = @TURN_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTURM_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM InspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TURM_ID"] = value; //04
                      whereClauses.Add($" TURM_ID = @TURM_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM InspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_ID"] = value; //04
                      whereClauses.Add($" ORD_ID = @ORD_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByROT_PRO_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM InspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ROT_PRO_ID"] = value; //04
                      whereClauses.Add($" ROT_PRO_ID = @ROT_PRO_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByROT_MAQ_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM InspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ROT_MAQ_ID"] = value; //04
                      whereClauses.Add($" ROT_MAQ_ID = @ROT_MAQ_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByROT_SEQ_TRANSFORMACAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM InspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ROT_SEQ_TRANSFORMACAO"] = value; //04
                      whereClauses.Add($" ROT_SEQ_TRANSFORMACAO = @ROT_SEQ_TRANSFORMACAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_SEQ_REPETICAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM InspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_SEQ_REPETICAO"] = value; //04
                      whereClauses.Add($" FPR_SEQ_REPETICAO = @FPR_SEQ_REPETICAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByIPV_STATUS_LIBERACAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM InspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["IPV_STATUS_LIBERACAO"] = value; //04
                      whereClauses.Add($" IPV_STATUS_LIBERACAO = @IPV_STATUS_LIBERACAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByIPV_VALOR_MEDIDAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM InspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["IPV_VALOR_MEDIDA"] = value; //04
                      whereClauses.Add($" IPV_VALOR_MEDIDA = @IPV_VALOR_MEDIDA ");//04
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
            this.Query = $"SELECT 1 FROM InspecaoVisual ";
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
            this.Query = $"SELECT 1 FROM InspecaoVisual ";
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
            this.Query = $"SELECT 1 FROM InspecaoVisual ";
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
            this.Query = $"SELECT 1 FROM InspecaoVisual ";
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
        public QueryModel FirstByIPV_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT IPV_ID, IPV_VALOR, IPV_ID_OPERADOR, IPV_ID_LIBERACAO, IPV_OBS, IPV_DATA_COLETA, IPV_DATA_AVAL, TIV_ID, TURN_ID, TURM_ID, ORD_ID, ROT_PRO_ID, ROT_MAQ_ID, ROT_SEQ_TRANSFORMACAO, FPR_SEQ_REPETICAO, IPV_STATUS_LIBERACAO, IPV_VALOR_MEDIDA, TenantID, Deleted, Changed, UserId FROM InspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["IPV_ID"] = value; //06
                      whereClauses.Add($" IPV_ID = @IPV_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByIPV_VALORQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT IPV_ID, IPV_VALOR, IPV_ID_OPERADOR, IPV_ID_LIBERACAO, IPV_OBS, IPV_DATA_COLETA, IPV_DATA_AVAL, TIV_ID, TURN_ID, TURM_ID, ORD_ID, ROT_PRO_ID, ROT_MAQ_ID, ROT_SEQ_TRANSFORMACAO, FPR_SEQ_REPETICAO, IPV_STATUS_LIBERACAO, IPV_VALOR_MEDIDA, TenantID, Deleted, Changed, UserId FROM InspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["IPV_VALOR"] = value; //06
                      whereClauses.Add($" IPV_VALOR = @IPV_VALOR ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByIPV_ID_OPERADORQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT IPV_ID, IPV_VALOR, IPV_ID_OPERADOR, IPV_ID_LIBERACAO, IPV_OBS, IPV_DATA_COLETA, IPV_DATA_AVAL, TIV_ID, TURN_ID, TURM_ID, ORD_ID, ROT_PRO_ID, ROT_MAQ_ID, ROT_SEQ_TRANSFORMACAO, FPR_SEQ_REPETICAO, IPV_STATUS_LIBERACAO, IPV_VALOR_MEDIDA, TenantID, Deleted, Changed, UserId FROM InspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["IPV_ID_OPERADOR"] = value; //06
                      whereClauses.Add($" IPV_ID_OPERADOR = @IPV_ID_OPERADOR ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByIPV_ID_LIBERACAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT IPV_ID, IPV_VALOR, IPV_ID_OPERADOR, IPV_ID_LIBERACAO, IPV_OBS, IPV_DATA_COLETA, IPV_DATA_AVAL, TIV_ID, TURN_ID, TURM_ID, ORD_ID, ROT_PRO_ID, ROT_MAQ_ID, ROT_SEQ_TRANSFORMACAO, FPR_SEQ_REPETICAO, IPV_STATUS_LIBERACAO, IPV_VALOR_MEDIDA, TenantID, Deleted, Changed, UserId FROM InspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["IPV_ID_LIBERACAO"] = value; //06
                      whereClauses.Add($" IPV_ID_LIBERACAO = @IPV_ID_LIBERACAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByIPV_OBSQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT IPV_ID, IPV_VALOR, IPV_ID_OPERADOR, IPV_ID_LIBERACAO, IPV_OBS, IPV_DATA_COLETA, IPV_DATA_AVAL, TIV_ID, TURN_ID, TURM_ID, ORD_ID, ROT_PRO_ID, ROT_MAQ_ID, ROT_SEQ_TRANSFORMACAO, FPR_SEQ_REPETICAO, IPV_STATUS_LIBERACAO, IPV_VALOR_MEDIDA, TenantID, Deleted, Changed, UserId FROM InspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["IPV_OBS"] = value; //06
                      whereClauses.Add($" IPV_OBS = @IPV_OBS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByIPV_DATA_COLETAQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT IPV_ID, IPV_VALOR, IPV_ID_OPERADOR, IPV_ID_LIBERACAO, IPV_OBS, IPV_DATA_COLETA, IPV_DATA_AVAL, TIV_ID, TURN_ID, TURM_ID, ORD_ID, ROT_PRO_ID, ROT_MAQ_ID, ROT_SEQ_TRANSFORMACAO, FPR_SEQ_REPETICAO, IPV_STATUS_LIBERACAO, IPV_VALOR_MEDIDA, TenantID, Deleted, Changed, UserId FROM InspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["IPV_DATA_COLETA"] = value; //06
                      whereClauses.Add($" IPV_DATA_COLETA = @IPV_DATA_COLETA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByIPV_DATA_AVALQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT IPV_ID, IPV_VALOR, IPV_ID_OPERADOR, IPV_ID_LIBERACAO, IPV_OBS, IPV_DATA_COLETA, IPV_DATA_AVAL, TIV_ID, TURN_ID, TURM_ID, ORD_ID, ROT_PRO_ID, ROT_MAQ_ID, ROT_SEQ_TRANSFORMACAO, FPR_SEQ_REPETICAO, IPV_STATUS_LIBERACAO, IPV_VALOR_MEDIDA, TenantID, Deleted, Changed, UserId FROM InspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["IPV_DATA_AVAL"] = value; //06
                      whereClauses.Add($" IPV_DATA_AVAL = @IPV_DATA_AVAL ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTIV_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT IPV_ID, IPV_VALOR, IPV_ID_OPERADOR, IPV_ID_LIBERACAO, IPV_OBS, IPV_DATA_COLETA, IPV_DATA_AVAL, TIV_ID, TURN_ID, TURM_ID, ORD_ID, ROT_PRO_ID, ROT_MAQ_ID, ROT_SEQ_TRANSFORMACAO, FPR_SEQ_REPETICAO, IPV_STATUS_LIBERACAO, IPV_VALOR_MEDIDA, TenantID, Deleted, Changed, UserId FROM InspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TIV_ID"] = value; //06
                      whereClauses.Add($" TIV_ID = @TIV_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTURN_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT IPV_ID, IPV_VALOR, IPV_ID_OPERADOR, IPV_ID_LIBERACAO, IPV_OBS, IPV_DATA_COLETA, IPV_DATA_AVAL, TIV_ID, TURN_ID, TURM_ID, ORD_ID, ROT_PRO_ID, ROT_MAQ_ID, ROT_SEQ_TRANSFORMACAO, FPR_SEQ_REPETICAO, IPV_STATUS_LIBERACAO, IPV_VALOR_MEDIDA, TenantID, Deleted, Changed, UserId FROM InspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TURN_ID"] = value; //06
                      whereClauses.Add($" TURN_ID = @TURN_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTURM_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT IPV_ID, IPV_VALOR, IPV_ID_OPERADOR, IPV_ID_LIBERACAO, IPV_OBS, IPV_DATA_COLETA, IPV_DATA_AVAL, TIV_ID, TURN_ID, TURM_ID, ORD_ID, ROT_PRO_ID, ROT_MAQ_ID, ROT_SEQ_TRANSFORMACAO, FPR_SEQ_REPETICAO, IPV_STATUS_LIBERACAO, IPV_VALOR_MEDIDA, TenantID, Deleted, Changed, UserId FROM InspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TURM_ID"] = value; //06
                      whereClauses.Add($" TURM_ID = @TURM_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT IPV_ID, IPV_VALOR, IPV_ID_OPERADOR, IPV_ID_LIBERACAO, IPV_OBS, IPV_DATA_COLETA, IPV_DATA_AVAL, TIV_ID, TURN_ID, TURM_ID, ORD_ID, ROT_PRO_ID, ROT_MAQ_ID, ROT_SEQ_TRANSFORMACAO, FPR_SEQ_REPETICAO, IPV_STATUS_LIBERACAO, IPV_VALOR_MEDIDA, TenantID, Deleted, Changed, UserId FROM InspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_ID"] = value; //06
                      whereClauses.Add($" ORD_ID = @ORD_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByROT_PRO_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT IPV_ID, IPV_VALOR, IPV_ID_OPERADOR, IPV_ID_LIBERACAO, IPV_OBS, IPV_DATA_COLETA, IPV_DATA_AVAL, TIV_ID, TURN_ID, TURM_ID, ORD_ID, ROT_PRO_ID, ROT_MAQ_ID, ROT_SEQ_TRANSFORMACAO, FPR_SEQ_REPETICAO, IPV_STATUS_LIBERACAO, IPV_VALOR_MEDIDA, TenantID, Deleted, Changed, UserId FROM InspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ROT_PRO_ID"] = value; //06
                      whereClauses.Add($" ROT_PRO_ID = @ROT_PRO_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByROT_MAQ_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT IPV_ID, IPV_VALOR, IPV_ID_OPERADOR, IPV_ID_LIBERACAO, IPV_OBS, IPV_DATA_COLETA, IPV_DATA_AVAL, TIV_ID, TURN_ID, TURM_ID, ORD_ID, ROT_PRO_ID, ROT_MAQ_ID, ROT_SEQ_TRANSFORMACAO, FPR_SEQ_REPETICAO, IPV_STATUS_LIBERACAO, IPV_VALOR_MEDIDA, TenantID, Deleted, Changed, UserId FROM InspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ROT_MAQ_ID"] = value; //06
                      whereClauses.Add($" ROT_MAQ_ID = @ROT_MAQ_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByROT_SEQ_TRANSFORMACAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT IPV_ID, IPV_VALOR, IPV_ID_OPERADOR, IPV_ID_LIBERACAO, IPV_OBS, IPV_DATA_COLETA, IPV_DATA_AVAL, TIV_ID, TURN_ID, TURM_ID, ORD_ID, ROT_PRO_ID, ROT_MAQ_ID, ROT_SEQ_TRANSFORMACAO, FPR_SEQ_REPETICAO, IPV_STATUS_LIBERACAO, IPV_VALOR_MEDIDA, TenantID, Deleted, Changed, UserId FROM InspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ROT_SEQ_TRANSFORMACAO"] = value; //06
                      whereClauses.Add($" ROT_SEQ_TRANSFORMACAO = @ROT_SEQ_TRANSFORMACAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_SEQ_REPETICAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT IPV_ID, IPV_VALOR, IPV_ID_OPERADOR, IPV_ID_LIBERACAO, IPV_OBS, IPV_DATA_COLETA, IPV_DATA_AVAL, TIV_ID, TURN_ID, TURM_ID, ORD_ID, ROT_PRO_ID, ROT_MAQ_ID, ROT_SEQ_TRANSFORMACAO, FPR_SEQ_REPETICAO, IPV_STATUS_LIBERACAO, IPV_VALOR_MEDIDA, TenantID, Deleted, Changed, UserId FROM InspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_SEQ_REPETICAO"] = value; //06
                      whereClauses.Add($" FPR_SEQ_REPETICAO = @FPR_SEQ_REPETICAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByIPV_STATUS_LIBERACAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT IPV_ID, IPV_VALOR, IPV_ID_OPERADOR, IPV_ID_LIBERACAO, IPV_OBS, IPV_DATA_COLETA, IPV_DATA_AVAL, TIV_ID, TURN_ID, TURM_ID, ORD_ID, ROT_PRO_ID, ROT_MAQ_ID, ROT_SEQ_TRANSFORMACAO, FPR_SEQ_REPETICAO, IPV_STATUS_LIBERACAO, IPV_VALOR_MEDIDA, TenantID, Deleted, Changed, UserId FROM InspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["IPV_STATUS_LIBERACAO"] = value; //06
                      whereClauses.Add($" IPV_STATUS_LIBERACAO = @IPV_STATUS_LIBERACAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByIPV_VALOR_MEDIDAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT IPV_ID, IPV_VALOR, IPV_ID_OPERADOR, IPV_ID_LIBERACAO, IPV_OBS, IPV_DATA_COLETA, IPV_DATA_AVAL, TIV_ID, TURN_ID, TURM_ID, ORD_ID, ROT_PRO_ID, ROT_MAQ_ID, ROT_SEQ_TRANSFORMACAO, FPR_SEQ_REPETICAO, IPV_STATUS_LIBERACAO, IPV_VALOR_MEDIDA, TenantID, Deleted, Changed, UserId FROM InspecaoVisual ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["IPV_VALOR_MEDIDA"] = value; //06
                      whereClauses.Add($" IPV_VALOR_MEDIDA = @IPV_VALOR_MEDIDA ");//06
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
            this.Query = $"SELECT IPV_ID, IPV_VALOR, IPV_ID_OPERADOR, IPV_ID_LIBERACAO, IPV_OBS, IPV_DATA_COLETA, IPV_DATA_AVAL, TIV_ID, TURN_ID, TURM_ID, ORD_ID, ROT_PRO_ID, ROT_MAQ_ID, ROT_SEQ_TRANSFORMACAO, FPR_SEQ_REPETICAO, IPV_STATUS_LIBERACAO, IPV_VALOR_MEDIDA, TenantID, Deleted, Changed, UserId FROM InspecaoVisual ";
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
            this.Query = $"SELECT IPV_ID, IPV_VALOR, IPV_ID_OPERADOR, IPV_ID_LIBERACAO, IPV_OBS, IPV_DATA_COLETA, IPV_DATA_AVAL, TIV_ID, TURN_ID, TURM_ID, ORD_ID, ROT_PRO_ID, ROT_MAQ_ID, ROT_SEQ_TRANSFORMACAO, FPR_SEQ_REPETICAO, IPV_STATUS_LIBERACAO, IPV_VALOR_MEDIDA, TenantID, Deleted, Changed, UserId FROM InspecaoVisual ";
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
            this.Query = $"SELECT IPV_ID, IPV_VALOR, IPV_ID_OPERADOR, IPV_ID_LIBERACAO, IPV_OBS, IPV_DATA_COLETA, IPV_DATA_AVAL, TIV_ID, TURN_ID, TURM_ID, ORD_ID, ROT_PRO_ID, ROT_MAQ_ID, ROT_SEQ_TRANSFORMACAO, FPR_SEQ_REPETICAO, IPV_STATUS_LIBERACAO, IPV_VALOR_MEDIDA, TenantID, Deleted, Changed, UserId FROM InspecaoVisual ";
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
            this.Query = $"SELECT IPV_ID, IPV_VALOR, IPV_ID_OPERADOR, IPV_ID_LIBERACAO, IPV_OBS, IPV_DATA_COLETA, IPV_DATA_AVAL, TIV_ID, TURN_ID, TURM_ID, ORD_ID, ROT_PRO_ID, ROT_MAQ_ID, ROT_SEQ_TRANSFORMACAO, FPR_SEQ_REPETICAO, IPV_STATUS_LIBERACAO, IPV_VALOR_MEDIDA, TenantID, Deleted, Changed, UserId FROM InspecaoVisual ";
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