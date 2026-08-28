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
    public class EtiquetaQueryRead : QueryBase, IEtiquetaQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public EtiquetaQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel EtiquetaQuery(Command.Read.EtiquetaReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select ETI_ID, ETI_EMISSAO, ETI_CODIGO_BARRAS, ETI_SEQUENCIA, ETI_NUMERO_COPIAS, ETI_STATUS, ETI_DATA_FABRICACAO, ETI_COD_BARRAS_ORIGINAL, ETI_OP_ORIGINAL, MAQ_ID, IMP_ID, USE_ID, ORD_ID, ROT_PRO_ID, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, ETI_QUANTIDADE_PALETE, ETI_LOTE, ETI_SUB_LOTE, ETI_IMPRIMIR_DE, ETI_IMPRIMIR_ATE, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId from Etiqueta ";
if (Command.ETI_ID.HasValue) dict["ETI_ID"] = Command.ETI_ID.Value;
if (Command.ETI_ID.HasValue) whereClauses.Add($"ETI_ID = @ETI_ID");
if (!string.IsNullOrEmpty(Command.ETI_CODIGO_BARRAS)) dict["ETI_CODIGO_BARRAS"] = $"%{Command.ETI_CODIGO_BARRAS}%";
if (!string.IsNullOrEmpty(Command.ETI_CODIGO_BARRAS)) whereClauses.Add($"ETI_CODIGO_BARRAS like @ETI_CODIGO_BARRAS");
if (Command.ETI_SEQUENCIA.HasValue) dict["ETI_SEQUENCIA"] = Command.ETI_SEQUENCIA.Value;
if (Command.ETI_SEQUENCIA.HasValue) whereClauses.Add($"ETI_SEQUENCIA = @ETI_SEQUENCIA");
if (Command.ETI_NUMERO_COPIAS.HasValue) dict["ETI_NUMERO_COPIAS"] = Command.ETI_NUMERO_COPIAS.Value;
if (Command.ETI_NUMERO_COPIAS.HasValue) whereClauses.Add($"ETI_NUMERO_COPIAS = @ETI_NUMERO_COPIAS");
if (!string.IsNullOrEmpty(Command.ETI_STATUS)) dict["ETI_STATUS"] = $"%{Command.ETI_STATUS}%";
if (!string.IsNullOrEmpty(Command.ETI_STATUS)) whereClauses.Add($"ETI_STATUS like @ETI_STATUS");
if (!string.IsNullOrEmpty(Command.ETI_COD_BARRAS_ORIGINAL)) dict["ETI_COD_BARRAS_ORIGINAL"] = $"%{Command.ETI_COD_BARRAS_ORIGINAL}%";
if (!string.IsNullOrEmpty(Command.ETI_COD_BARRAS_ORIGINAL)) whereClauses.Add($"ETI_COD_BARRAS_ORIGINAL like @ETI_COD_BARRAS_ORIGINAL");
if (!string.IsNullOrEmpty(Command.ETI_OP_ORIGINAL)) dict["ETI_OP_ORIGINAL"] = $"%{Command.ETI_OP_ORIGINAL}%";
if (!string.IsNullOrEmpty(Command.ETI_OP_ORIGINAL)) whereClauses.Add($"ETI_OP_ORIGINAL like @ETI_OP_ORIGINAL");
if (!string.IsNullOrEmpty(Command.MAQ_ID)) dict["MAQ_ID"] = $"%{Command.MAQ_ID}%";
if (!string.IsNullOrEmpty(Command.MAQ_ID)) whereClauses.Add($"MAQ_ID like @MAQ_ID");
if (Command.IMP_ID.HasValue) dict["IMP_ID"] = Command.IMP_ID.Value;
if (Command.IMP_ID.HasValue) whereClauses.Add($"IMP_ID = @IMP_ID");
if (Command.USE_ID.HasValue) dict["USE_ID"] = Command.USE_ID.Value;
if (Command.USE_ID.HasValue) whereClauses.Add($"USE_ID = @USE_ID");
if (!string.IsNullOrEmpty(Command.ORD_ID)) dict["ORD_ID"] = $"%{Command.ORD_ID}%";
if (!string.IsNullOrEmpty(Command.ORD_ID)) whereClauses.Add($"ORD_ID like @ORD_ID");
if (!string.IsNullOrEmpty(Command.ROT_PRO_ID)) dict["ROT_PRO_ID"] = $"%{Command.ROT_PRO_ID}%";
if (!string.IsNullOrEmpty(Command.ROT_PRO_ID)) whereClauses.Add($"ROT_PRO_ID like @ROT_PRO_ID");
if (Command.ROT_SEQ_TRANFORMACAO.HasValue) dict["ROT_SEQ_TRANFORMACAO"] = Command.ROT_SEQ_TRANFORMACAO.Value;
if (Command.ROT_SEQ_TRANFORMACAO.HasValue) whereClauses.Add($"ROT_SEQ_TRANFORMACAO = @ROT_SEQ_TRANFORMACAO");
if (Command.FPR_SEQ_REPETICAO.HasValue) dict["FPR_SEQ_REPETICAO"] = Command.FPR_SEQ_REPETICAO.Value;
if (Command.FPR_SEQ_REPETICAO.HasValue) whereClauses.Add($"FPR_SEQ_REPETICAO = @FPR_SEQ_REPETICAO");
if (!string.IsNullOrEmpty(Command.ETI_LOTE)) dict["ETI_LOTE"] = $"%{Command.ETI_LOTE}%";
if (!string.IsNullOrEmpty(Command.ETI_LOTE)) whereClauses.Add($"ETI_LOTE like @ETI_LOTE");
if (!string.IsNullOrEmpty(Command.ETI_SUB_LOTE)) dict["ETI_SUB_LOTE"] = $"%{Command.ETI_SUB_LOTE}%";
if (!string.IsNullOrEmpty(Command.ETI_SUB_LOTE)) whereClauses.Add($"ETI_SUB_LOTE like @ETI_SUB_LOTE");
if (Command.ETI_IMPRIMIR_DE.HasValue) dict["ETI_IMPRIMIR_DE"] = Command.ETI_IMPRIMIR_DE.Value;
if (Command.ETI_IMPRIMIR_DE.HasValue) whereClauses.Add($"ETI_IMPRIMIR_DE = @ETI_IMPRIMIR_DE");
if (Command.ETI_IMPRIMIR_ATE.HasValue) dict["ETI_IMPRIMIR_ATE"] = Command.ETI_IMPRIMIR_ATE.Value;
if (Command.ETI_IMPRIMIR_ATE.HasValue) whereClauses.Add($"ETI_IMPRIMIR_ATE = @ETI_IMPRIMIR_ATE");
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
            Query += " ORDER BY ETI_ID OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel EtiquetaUSE_IDQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select USE_ID from Usuario ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["USE_ID"] = numero; //01
                      whereClauses.Add($" USE_ID = @USE_ID");//01 
                 }
                 else 
                 {
                      dict["USE_ID"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" USE_ID like @USE_ID ");//02
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
        public QueryModel EtiquetaORD_IDQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select ORD_ID from Order ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["ORD_ID"] = numero; //01
                      whereClauses.Add($" ORD_ID = @ORD_ID");//01 
                 }
                 else 
                 {
                      dict["ORD_ID"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" ORD_ID like @ORD_ID ");//02
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
        public QueryModel EtiquetaTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel EtiquetaUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel ExistsByETI_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Etiqueta ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ETI_ID"] = value; //04
                      whereClauses.Add($" ETI_ID = @ETI_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByETI_EMISSAOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Etiqueta ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ETI_EMISSAO"] = value; //04
                      whereClauses.Add($" ETI_EMISSAO = @ETI_EMISSAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByETI_CODIGO_BARRASQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Etiqueta ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ETI_CODIGO_BARRAS"] = value; //04
                      whereClauses.Add($" ETI_CODIGO_BARRAS = @ETI_CODIGO_BARRAS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByETI_SEQUENCIAQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Etiqueta ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ETI_SEQUENCIA"] = value; //04
                      whereClauses.Add($" ETI_SEQUENCIA = @ETI_SEQUENCIA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByETI_NUMERO_COPIASQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Etiqueta ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ETI_NUMERO_COPIAS"] = value; //04
                      whereClauses.Add($" ETI_NUMERO_COPIAS = @ETI_NUMERO_COPIAS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByETI_STATUSQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Etiqueta ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ETI_STATUS"] = value; //04
                      whereClauses.Add($" ETI_STATUS = @ETI_STATUS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByETI_DATA_FABRICACAOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Etiqueta ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ETI_DATA_FABRICACAO"] = value; //04
                      whereClauses.Add($" ETI_DATA_FABRICACAO = @ETI_DATA_FABRICACAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByETI_COD_BARRAS_ORIGINALQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Etiqueta ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ETI_COD_BARRAS_ORIGINAL"] = value; //04
                      whereClauses.Add($" ETI_COD_BARRAS_ORIGINAL = @ETI_COD_BARRAS_ORIGINAL ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByETI_OP_ORIGINALQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Etiqueta ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ETI_OP_ORIGINAL"] = value; //04
                      whereClauses.Add($" ETI_OP_ORIGINAL = @ETI_OP_ORIGINAL ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Etiqueta ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MAQ_ID"] = value; //04
                      whereClauses.Add($" MAQ_ID = @MAQ_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByIMP_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Etiqueta ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["IMP_ID"] = value; //04
                      whereClauses.Add($" IMP_ID = @IMP_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByUSE_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Etiqueta ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["USE_ID"] = value; //04
                      whereClauses.Add($" USE_ID = @USE_ID ");//04
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
            this.Query = $"SELECT 1 FROM Etiqueta ";
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
            this.Query = $"SELECT 1 FROM Etiqueta ";
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
        public QueryModel ExistsByROT_SEQ_TRANFORMACAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Etiqueta ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ROT_SEQ_TRANFORMACAO"] = value; //04
                      whereClauses.Add($" ROT_SEQ_TRANFORMACAO = @ROT_SEQ_TRANFORMACAO ");//04
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
            this.Query = $"SELECT 1 FROM Etiqueta ";
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
        public QueryModel ExistsByETI_QUANTIDADE_PALETEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Etiqueta ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ETI_QUANTIDADE_PALETE"] = value; //04
                      whereClauses.Add($" ETI_QUANTIDADE_PALETE = @ETI_QUANTIDADE_PALETE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByETI_LOTEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Etiqueta ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ETI_LOTE"] = value; //04
                      whereClauses.Add($" ETI_LOTE = @ETI_LOTE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByETI_SUB_LOTEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Etiqueta ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ETI_SUB_LOTE"] = value; //04
                      whereClauses.Add($" ETI_SUB_LOTE = @ETI_SUB_LOTE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByETI_IMPRIMIR_DEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Etiqueta ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ETI_IMPRIMIR_DE"] = value; //04
                      whereClauses.Add($" ETI_IMPRIMIR_DE = @ETI_IMPRIMIR_DE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByETI_IMPRIMIR_ATEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Etiqueta ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ETI_IMPRIMIR_ATE"] = value; //04
                      whereClauses.Add($" ETI_IMPRIMIR_ATE = @ETI_IMPRIMIR_ATE ");//04
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
            this.Query = $"SELECT 1 FROM Etiqueta ";
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
            this.Query = $"SELECT 1 FROM Etiqueta ";
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
            this.Query = $"SELECT 1 FROM Etiqueta ";
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
            this.Query = $"SELECT 1 FROM Etiqueta ";
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
            this.Query = $"SELECT 1 FROM Etiqueta ";
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
            this.Query = $"SELECT 1 FROM Etiqueta ";
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
        public QueryModel FirstByETI_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ETI_ID, ETI_EMISSAO, ETI_CODIGO_BARRAS, ETI_SEQUENCIA, ETI_NUMERO_COPIAS, ETI_STATUS, ETI_DATA_FABRICACAO, ETI_COD_BARRAS_ORIGINAL, ETI_OP_ORIGINAL, MAQ_ID, IMP_ID, USE_ID, ORD_ID, ROT_PRO_ID, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, ETI_QUANTIDADE_PALETE, ETI_LOTE, ETI_SUB_LOTE, ETI_IMPRIMIR_DE, ETI_IMPRIMIR_ATE, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM Etiqueta ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ETI_ID"] = value; //06
                      whereClauses.Add($" ETI_ID = @ETI_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByETI_EMISSAOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ETI_ID, ETI_EMISSAO, ETI_CODIGO_BARRAS, ETI_SEQUENCIA, ETI_NUMERO_COPIAS, ETI_STATUS, ETI_DATA_FABRICACAO, ETI_COD_BARRAS_ORIGINAL, ETI_OP_ORIGINAL, MAQ_ID, IMP_ID, USE_ID, ORD_ID, ROT_PRO_ID, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, ETI_QUANTIDADE_PALETE, ETI_LOTE, ETI_SUB_LOTE, ETI_IMPRIMIR_DE, ETI_IMPRIMIR_ATE, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM Etiqueta ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ETI_EMISSAO"] = value; //06
                      whereClauses.Add($" ETI_EMISSAO = @ETI_EMISSAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByETI_CODIGO_BARRASQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ETI_ID, ETI_EMISSAO, ETI_CODIGO_BARRAS, ETI_SEQUENCIA, ETI_NUMERO_COPIAS, ETI_STATUS, ETI_DATA_FABRICACAO, ETI_COD_BARRAS_ORIGINAL, ETI_OP_ORIGINAL, MAQ_ID, IMP_ID, USE_ID, ORD_ID, ROT_PRO_ID, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, ETI_QUANTIDADE_PALETE, ETI_LOTE, ETI_SUB_LOTE, ETI_IMPRIMIR_DE, ETI_IMPRIMIR_ATE, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM Etiqueta ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ETI_CODIGO_BARRAS"] = value; //06
                      whereClauses.Add($" ETI_CODIGO_BARRAS = @ETI_CODIGO_BARRAS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByETI_SEQUENCIAQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ETI_ID, ETI_EMISSAO, ETI_CODIGO_BARRAS, ETI_SEQUENCIA, ETI_NUMERO_COPIAS, ETI_STATUS, ETI_DATA_FABRICACAO, ETI_COD_BARRAS_ORIGINAL, ETI_OP_ORIGINAL, MAQ_ID, IMP_ID, USE_ID, ORD_ID, ROT_PRO_ID, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, ETI_QUANTIDADE_PALETE, ETI_LOTE, ETI_SUB_LOTE, ETI_IMPRIMIR_DE, ETI_IMPRIMIR_ATE, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM Etiqueta ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ETI_SEQUENCIA"] = value; //06
                      whereClauses.Add($" ETI_SEQUENCIA = @ETI_SEQUENCIA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByETI_NUMERO_COPIASQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ETI_ID, ETI_EMISSAO, ETI_CODIGO_BARRAS, ETI_SEQUENCIA, ETI_NUMERO_COPIAS, ETI_STATUS, ETI_DATA_FABRICACAO, ETI_COD_BARRAS_ORIGINAL, ETI_OP_ORIGINAL, MAQ_ID, IMP_ID, USE_ID, ORD_ID, ROT_PRO_ID, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, ETI_QUANTIDADE_PALETE, ETI_LOTE, ETI_SUB_LOTE, ETI_IMPRIMIR_DE, ETI_IMPRIMIR_ATE, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM Etiqueta ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ETI_NUMERO_COPIAS"] = value; //06
                      whereClauses.Add($" ETI_NUMERO_COPIAS = @ETI_NUMERO_COPIAS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByETI_STATUSQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ETI_ID, ETI_EMISSAO, ETI_CODIGO_BARRAS, ETI_SEQUENCIA, ETI_NUMERO_COPIAS, ETI_STATUS, ETI_DATA_FABRICACAO, ETI_COD_BARRAS_ORIGINAL, ETI_OP_ORIGINAL, MAQ_ID, IMP_ID, USE_ID, ORD_ID, ROT_PRO_ID, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, ETI_QUANTIDADE_PALETE, ETI_LOTE, ETI_SUB_LOTE, ETI_IMPRIMIR_DE, ETI_IMPRIMIR_ATE, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM Etiqueta ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ETI_STATUS"] = value; //06
                      whereClauses.Add($" ETI_STATUS = @ETI_STATUS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByETI_DATA_FABRICACAOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ETI_ID, ETI_EMISSAO, ETI_CODIGO_BARRAS, ETI_SEQUENCIA, ETI_NUMERO_COPIAS, ETI_STATUS, ETI_DATA_FABRICACAO, ETI_COD_BARRAS_ORIGINAL, ETI_OP_ORIGINAL, MAQ_ID, IMP_ID, USE_ID, ORD_ID, ROT_PRO_ID, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, ETI_QUANTIDADE_PALETE, ETI_LOTE, ETI_SUB_LOTE, ETI_IMPRIMIR_DE, ETI_IMPRIMIR_ATE, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM Etiqueta ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ETI_DATA_FABRICACAO"] = value; //06
                      whereClauses.Add($" ETI_DATA_FABRICACAO = @ETI_DATA_FABRICACAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByETI_COD_BARRAS_ORIGINALQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ETI_ID, ETI_EMISSAO, ETI_CODIGO_BARRAS, ETI_SEQUENCIA, ETI_NUMERO_COPIAS, ETI_STATUS, ETI_DATA_FABRICACAO, ETI_COD_BARRAS_ORIGINAL, ETI_OP_ORIGINAL, MAQ_ID, IMP_ID, USE_ID, ORD_ID, ROT_PRO_ID, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, ETI_QUANTIDADE_PALETE, ETI_LOTE, ETI_SUB_LOTE, ETI_IMPRIMIR_DE, ETI_IMPRIMIR_ATE, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM Etiqueta ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ETI_COD_BARRAS_ORIGINAL"] = value; //06
                      whereClauses.Add($" ETI_COD_BARRAS_ORIGINAL = @ETI_COD_BARRAS_ORIGINAL ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByETI_OP_ORIGINALQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ETI_ID, ETI_EMISSAO, ETI_CODIGO_BARRAS, ETI_SEQUENCIA, ETI_NUMERO_COPIAS, ETI_STATUS, ETI_DATA_FABRICACAO, ETI_COD_BARRAS_ORIGINAL, ETI_OP_ORIGINAL, MAQ_ID, IMP_ID, USE_ID, ORD_ID, ROT_PRO_ID, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, ETI_QUANTIDADE_PALETE, ETI_LOTE, ETI_SUB_LOTE, ETI_IMPRIMIR_DE, ETI_IMPRIMIR_ATE, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM Etiqueta ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ETI_OP_ORIGINAL"] = value; //06
                      whereClauses.Add($" ETI_OP_ORIGINAL = @ETI_OP_ORIGINAL ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ETI_ID, ETI_EMISSAO, ETI_CODIGO_BARRAS, ETI_SEQUENCIA, ETI_NUMERO_COPIAS, ETI_STATUS, ETI_DATA_FABRICACAO, ETI_COD_BARRAS_ORIGINAL, ETI_OP_ORIGINAL, MAQ_ID, IMP_ID, USE_ID, ORD_ID, ROT_PRO_ID, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, ETI_QUANTIDADE_PALETE, ETI_LOTE, ETI_SUB_LOTE, ETI_IMPRIMIR_DE, ETI_IMPRIMIR_ATE, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM Etiqueta ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MAQ_ID"] = value; //06
                      whereClauses.Add($" MAQ_ID = @MAQ_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByIMP_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ETI_ID, ETI_EMISSAO, ETI_CODIGO_BARRAS, ETI_SEQUENCIA, ETI_NUMERO_COPIAS, ETI_STATUS, ETI_DATA_FABRICACAO, ETI_COD_BARRAS_ORIGINAL, ETI_OP_ORIGINAL, MAQ_ID, IMP_ID, USE_ID, ORD_ID, ROT_PRO_ID, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, ETI_QUANTIDADE_PALETE, ETI_LOTE, ETI_SUB_LOTE, ETI_IMPRIMIR_DE, ETI_IMPRIMIR_ATE, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM Etiqueta ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["IMP_ID"] = value; //06
                      whereClauses.Add($" IMP_ID = @IMP_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByUSE_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ETI_ID, ETI_EMISSAO, ETI_CODIGO_BARRAS, ETI_SEQUENCIA, ETI_NUMERO_COPIAS, ETI_STATUS, ETI_DATA_FABRICACAO, ETI_COD_BARRAS_ORIGINAL, ETI_OP_ORIGINAL, MAQ_ID, IMP_ID, USE_ID, ORD_ID, ROT_PRO_ID, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, ETI_QUANTIDADE_PALETE, ETI_LOTE, ETI_SUB_LOTE, ETI_IMPRIMIR_DE, ETI_IMPRIMIR_ATE, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM Etiqueta ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["USE_ID"] = value; //06
                      whereClauses.Add($" USE_ID = @USE_ID ");//06
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
            this.Query = $"SELECT ETI_ID, ETI_EMISSAO, ETI_CODIGO_BARRAS, ETI_SEQUENCIA, ETI_NUMERO_COPIAS, ETI_STATUS, ETI_DATA_FABRICACAO, ETI_COD_BARRAS_ORIGINAL, ETI_OP_ORIGINAL, MAQ_ID, IMP_ID, USE_ID, ORD_ID, ROT_PRO_ID, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, ETI_QUANTIDADE_PALETE, ETI_LOTE, ETI_SUB_LOTE, ETI_IMPRIMIR_DE, ETI_IMPRIMIR_ATE, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM Etiqueta ";
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
            this.Query = $"SELECT ETI_ID, ETI_EMISSAO, ETI_CODIGO_BARRAS, ETI_SEQUENCIA, ETI_NUMERO_COPIAS, ETI_STATUS, ETI_DATA_FABRICACAO, ETI_COD_BARRAS_ORIGINAL, ETI_OP_ORIGINAL, MAQ_ID, IMP_ID, USE_ID, ORD_ID, ROT_PRO_ID, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, ETI_QUANTIDADE_PALETE, ETI_LOTE, ETI_SUB_LOTE, ETI_IMPRIMIR_DE, ETI_IMPRIMIR_ATE, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM Etiqueta ";
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
        public QueryModel FirstByROT_SEQ_TRANFORMACAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ETI_ID, ETI_EMISSAO, ETI_CODIGO_BARRAS, ETI_SEQUENCIA, ETI_NUMERO_COPIAS, ETI_STATUS, ETI_DATA_FABRICACAO, ETI_COD_BARRAS_ORIGINAL, ETI_OP_ORIGINAL, MAQ_ID, IMP_ID, USE_ID, ORD_ID, ROT_PRO_ID, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, ETI_QUANTIDADE_PALETE, ETI_LOTE, ETI_SUB_LOTE, ETI_IMPRIMIR_DE, ETI_IMPRIMIR_ATE, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM Etiqueta ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ROT_SEQ_TRANFORMACAO"] = value; //06
                      whereClauses.Add($" ROT_SEQ_TRANFORMACAO = @ROT_SEQ_TRANFORMACAO ");//06
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
            this.Query = $"SELECT ETI_ID, ETI_EMISSAO, ETI_CODIGO_BARRAS, ETI_SEQUENCIA, ETI_NUMERO_COPIAS, ETI_STATUS, ETI_DATA_FABRICACAO, ETI_COD_BARRAS_ORIGINAL, ETI_OP_ORIGINAL, MAQ_ID, IMP_ID, USE_ID, ORD_ID, ROT_PRO_ID, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, ETI_QUANTIDADE_PALETE, ETI_LOTE, ETI_SUB_LOTE, ETI_IMPRIMIR_DE, ETI_IMPRIMIR_ATE, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM Etiqueta ";
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
        public QueryModel FirstByETI_QUANTIDADE_PALETEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ETI_ID, ETI_EMISSAO, ETI_CODIGO_BARRAS, ETI_SEQUENCIA, ETI_NUMERO_COPIAS, ETI_STATUS, ETI_DATA_FABRICACAO, ETI_COD_BARRAS_ORIGINAL, ETI_OP_ORIGINAL, MAQ_ID, IMP_ID, USE_ID, ORD_ID, ROT_PRO_ID, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, ETI_QUANTIDADE_PALETE, ETI_LOTE, ETI_SUB_LOTE, ETI_IMPRIMIR_DE, ETI_IMPRIMIR_ATE, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM Etiqueta ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ETI_QUANTIDADE_PALETE"] = value; //06
                      whereClauses.Add($" ETI_QUANTIDADE_PALETE = @ETI_QUANTIDADE_PALETE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByETI_LOTEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ETI_ID, ETI_EMISSAO, ETI_CODIGO_BARRAS, ETI_SEQUENCIA, ETI_NUMERO_COPIAS, ETI_STATUS, ETI_DATA_FABRICACAO, ETI_COD_BARRAS_ORIGINAL, ETI_OP_ORIGINAL, MAQ_ID, IMP_ID, USE_ID, ORD_ID, ROT_PRO_ID, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, ETI_QUANTIDADE_PALETE, ETI_LOTE, ETI_SUB_LOTE, ETI_IMPRIMIR_DE, ETI_IMPRIMIR_ATE, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM Etiqueta ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ETI_LOTE"] = value; //06
                      whereClauses.Add($" ETI_LOTE = @ETI_LOTE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByETI_SUB_LOTEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ETI_ID, ETI_EMISSAO, ETI_CODIGO_BARRAS, ETI_SEQUENCIA, ETI_NUMERO_COPIAS, ETI_STATUS, ETI_DATA_FABRICACAO, ETI_COD_BARRAS_ORIGINAL, ETI_OP_ORIGINAL, MAQ_ID, IMP_ID, USE_ID, ORD_ID, ROT_PRO_ID, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, ETI_QUANTIDADE_PALETE, ETI_LOTE, ETI_SUB_LOTE, ETI_IMPRIMIR_DE, ETI_IMPRIMIR_ATE, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM Etiqueta ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ETI_SUB_LOTE"] = value; //06
                      whereClauses.Add($" ETI_SUB_LOTE = @ETI_SUB_LOTE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByETI_IMPRIMIR_DEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ETI_ID, ETI_EMISSAO, ETI_CODIGO_BARRAS, ETI_SEQUENCIA, ETI_NUMERO_COPIAS, ETI_STATUS, ETI_DATA_FABRICACAO, ETI_COD_BARRAS_ORIGINAL, ETI_OP_ORIGINAL, MAQ_ID, IMP_ID, USE_ID, ORD_ID, ROT_PRO_ID, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, ETI_QUANTIDADE_PALETE, ETI_LOTE, ETI_SUB_LOTE, ETI_IMPRIMIR_DE, ETI_IMPRIMIR_ATE, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM Etiqueta ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ETI_IMPRIMIR_DE"] = value; //06
                      whereClauses.Add($" ETI_IMPRIMIR_DE = @ETI_IMPRIMIR_DE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByETI_IMPRIMIR_ATEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ETI_ID, ETI_EMISSAO, ETI_CODIGO_BARRAS, ETI_SEQUENCIA, ETI_NUMERO_COPIAS, ETI_STATUS, ETI_DATA_FABRICACAO, ETI_COD_BARRAS_ORIGINAL, ETI_OP_ORIGINAL, MAQ_ID, IMP_ID, USE_ID, ORD_ID, ROT_PRO_ID, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, ETI_QUANTIDADE_PALETE, ETI_LOTE, ETI_SUB_LOTE, ETI_IMPRIMIR_DE, ETI_IMPRIMIR_ATE, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM Etiqueta ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ETI_IMPRIMIR_ATE"] = value; //06
                      whereClauses.Add($" ETI_IMPRIMIR_ATE = @ETI_IMPRIMIR_ATE ");//06
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
            this.Query = $"SELECT ETI_ID, ETI_EMISSAO, ETI_CODIGO_BARRAS, ETI_SEQUENCIA, ETI_NUMERO_COPIAS, ETI_STATUS, ETI_DATA_FABRICACAO, ETI_COD_BARRAS_ORIGINAL, ETI_OP_ORIGINAL, MAQ_ID, IMP_ID, USE_ID, ORD_ID, ROT_PRO_ID, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, ETI_QUANTIDADE_PALETE, ETI_LOTE, ETI_SUB_LOTE, ETI_IMPRIMIR_DE, ETI_IMPRIMIR_ATE, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM Etiqueta ";
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
            this.Query = $"SELECT ETI_ID, ETI_EMISSAO, ETI_CODIGO_BARRAS, ETI_SEQUENCIA, ETI_NUMERO_COPIAS, ETI_STATUS, ETI_DATA_FABRICACAO, ETI_COD_BARRAS_ORIGINAL, ETI_OP_ORIGINAL, MAQ_ID, IMP_ID, USE_ID, ORD_ID, ROT_PRO_ID, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, ETI_QUANTIDADE_PALETE, ETI_LOTE, ETI_SUB_LOTE, ETI_IMPRIMIR_DE, ETI_IMPRIMIR_ATE, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM Etiqueta ";
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
            this.Query = $"SELECT ETI_ID, ETI_EMISSAO, ETI_CODIGO_BARRAS, ETI_SEQUENCIA, ETI_NUMERO_COPIAS, ETI_STATUS, ETI_DATA_FABRICACAO, ETI_COD_BARRAS_ORIGINAL, ETI_OP_ORIGINAL, MAQ_ID, IMP_ID, USE_ID, ORD_ID, ROT_PRO_ID, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, ETI_QUANTIDADE_PALETE, ETI_LOTE, ETI_SUB_LOTE, ETI_IMPRIMIR_DE, ETI_IMPRIMIR_ATE, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM Etiqueta ";
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
            this.Query = $"SELECT ETI_ID, ETI_EMISSAO, ETI_CODIGO_BARRAS, ETI_SEQUENCIA, ETI_NUMERO_COPIAS, ETI_STATUS, ETI_DATA_FABRICACAO, ETI_COD_BARRAS_ORIGINAL, ETI_OP_ORIGINAL, MAQ_ID, IMP_ID, USE_ID, ORD_ID, ROT_PRO_ID, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, ETI_QUANTIDADE_PALETE, ETI_LOTE, ETI_SUB_LOTE, ETI_IMPRIMIR_DE, ETI_IMPRIMIR_ATE, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM Etiqueta ";
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
            this.Query = $"SELECT ETI_ID, ETI_EMISSAO, ETI_CODIGO_BARRAS, ETI_SEQUENCIA, ETI_NUMERO_COPIAS, ETI_STATUS, ETI_DATA_FABRICACAO, ETI_COD_BARRAS_ORIGINAL, ETI_OP_ORIGINAL, MAQ_ID, IMP_ID, USE_ID, ORD_ID, ROT_PRO_ID, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, ETI_QUANTIDADE_PALETE, ETI_LOTE, ETI_SUB_LOTE, ETI_IMPRIMIR_DE, ETI_IMPRIMIR_ATE, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM Etiqueta ";
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
            this.Query = $"SELECT ETI_ID, ETI_EMISSAO, ETI_CODIGO_BARRAS, ETI_SEQUENCIA, ETI_NUMERO_COPIAS, ETI_STATUS, ETI_DATA_FABRICACAO, ETI_COD_BARRAS_ORIGINAL, ETI_OP_ORIGINAL, MAQ_ID, IMP_ID, USE_ID, ORD_ID, ROT_PRO_ID, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, ETI_QUANTIDADE_PALETE, ETI_LOTE, ETI_SUB_LOTE, ETI_IMPRIMIR_DE, ETI_IMPRIMIR_ATE, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId FROM Etiqueta ";
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