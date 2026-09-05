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
    public class TargetProdutoQueryRead : QueryBase, ITargetProdutoQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public TargetProdutoQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel TargetProdutoQuery(Command.Read.TargetProdutoReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] from [TargetProduto] ";
if (Command.TAR_ID.HasValue) dict["TAR_ID"] = Command.TAR_ID.Value;
if (Command.TAR_ID.HasValue) whereClauses.Add($"[TAR_ID] = @TAR_ID");
if (Command.MOV_ID.HasValue) dict["MOV_ID"] = Command.MOV_ID.Value;
if (Command.MOV_ID.HasValue) whereClauses.Add($"[MOV_ID] = @MOV_ID");
if (!string.IsNullOrEmpty(Command.ORD_ID)) dict["ORD_ID"] = $"%{Command.ORD_ID}%";
if (!string.IsNullOrEmpty(Command.ORD_ID)) whereClauses.Add($"[ORD_ID] like @ORD_ID");
if (!string.IsNullOrEmpty(Command.PRO_ID)) dict["PRO_ID"] = $"%{Command.PRO_ID}%";
if (!string.IsNullOrEmpty(Command.PRO_ID)) whereClauses.Add($"[PRO_ID] like @PRO_ID");
if (!string.IsNullOrEmpty(Command.MAQ_ID)) dict["MAQ_ID"] = $"%{Command.MAQ_ID}%";
if (!string.IsNullOrEmpty(Command.MAQ_ID)) whereClauses.Add($"[MAQ_ID] like @MAQ_ID");
if (!string.IsNullOrEmpty(Command.UNI_ID)) dict["UNI_ID"] = $"%{Command.UNI_ID}%";
if (!string.IsNullOrEmpty(Command.UNI_ID)) whereClauses.Add($"[UNI_ID] like @UNI_ID");
if (!string.IsNullOrEmpty(Command.TURM_ID)) dict["TURM_ID"] = $"%{Command.TURM_ID}%";
if (!string.IsNullOrEmpty(Command.TURM_ID)) whereClauses.Add($"[TURM_ID] like @TURM_ID");
if (!string.IsNullOrEmpty(Command.TURN_ID)) dict["TURN_ID"] = $"%{Command.TURN_ID}%";
if (!string.IsNullOrEmpty(Command.TURN_ID)) whereClauses.Add($"[TURN_ID] like @TURN_ID");
if (Command.USE_ID.HasValue) dict["USE_ID"] = Command.USE_ID.Value;
if (Command.USE_ID.HasValue) whereClauses.Add($"[USE_ID] = @USE_ID");
if (!string.IsNullOrEmpty(Command.TAR_DIA_TURMA)) dict["TAR_DIA_TURMA"] = $"%{Command.TAR_DIA_TURMA}%";
if (!string.IsNullOrEmpty(Command.TAR_DIA_TURMA)) whereClauses.Add($"[TAR_DIA_TURMA] like @TAR_DIA_TURMA");
if (!string.IsNullOrEmpty(Command.OCO_ID_PERFORMANCE)) dict["OCO_ID_PERFORMANCE"] = $"%{Command.OCO_ID_PERFORMANCE}%";
if (!string.IsNullOrEmpty(Command.OCO_ID_PERFORMANCE)) whereClauses.Add($"[OCO_ID_PERFORMANCE] like @OCO_ID_PERFORMANCE");
if (!string.IsNullOrEmpty(Command.TAR_OBS_PERFORMANCE)) dict["TAR_OBS_PERFORMANCE"] = $"%{Command.TAR_OBS_PERFORMANCE}%";
if (!string.IsNullOrEmpty(Command.TAR_OBS_PERFORMANCE)) whereClauses.Add($"[TAR_OBS_PERFORMANCE] like @TAR_OBS_PERFORMANCE");
if (!string.IsNullOrEmpty(Command.OCO_ID_SETUP)) dict["OCO_ID_SETUP"] = $"%{Command.OCO_ID_SETUP}%";
if (!string.IsNullOrEmpty(Command.OCO_ID_SETUP)) whereClauses.Add($"[OCO_ID_SETUP] like @OCO_ID_SETUP");
if (!string.IsNullOrEmpty(Command.TAR_OBS_SETUP)) dict["TAR_OBS_SETUP"] = $"%{Command.TAR_OBS_SETUP}%";
if (!string.IsNullOrEmpty(Command.TAR_OBS_SETUP)) whereClauses.Add($"[TAR_OBS_SETUP] like @TAR_OBS_SETUP");
if (!string.IsNullOrEmpty(Command.OCO_ID_SETUPA)) dict["OCO_ID_SETUPA"] = $"%{Command.OCO_ID_SETUPA}%";
if (!string.IsNullOrEmpty(Command.OCO_ID_SETUPA)) whereClauses.Add($"[OCO_ID_SETUPA] like @OCO_ID_SETUPA");
if (!string.IsNullOrEmpty(Command.TAR_OBS_SETUPA)) dict["TAR_OBS_SETUPA"] = $"%{Command.TAR_OBS_SETUPA}%";
if (!string.IsNullOrEmpty(Command.TAR_OBS_SETUPA)) whereClauses.Add($"[TAR_OBS_SETUPA] like @TAR_OBS_SETUPA");
if (!string.IsNullOrEmpty(Command.TAR_TIPO_FEEDBACK_PERFORMANCE)) dict["TAR_TIPO_FEEDBACK_PERFORMANCE"] = $"%{Command.TAR_TIPO_FEEDBACK_PERFORMANCE}%";
if (!string.IsNullOrEmpty(Command.TAR_TIPO_FEEDBACK_PERFORMANCE)) whereClauses.Add($"[TAR_TIPO_FEEDBACK_PERFORMANCE] like @TAR_TIPO_FEEDBACK_PERFORMANCE");
if (!string.IsNullOrEmpty(Command.TAR_TIPO_FEEDBACK_SETUP)) dict["TAR_TIPO_FEEDBACK_SETUP"] = $"%{Command.TAR_TIPO_FEEDBACK_SETUP}%";
if (!string.IsNullOrEmpty(Command.TAR_TIPO_FEEDBACK_SETUP)) whereClauses.Add($"[TAR_TIPO_FEEDBACK_SETUP] like @TAR_TIPO_FEEDBACK_SETUP");
if (!string.IsNullOrEmpty(Command.TAR_TIPO_FEEDBACK_SETUP_AJUSTE)) dict["TAR_TIPO_FEEDBACK_SETUP_AJUSTE"] = $"%{Command.TAR_TIPO_FEEDBACK_SETUP_AJUSTE}%";
if (!string.IsNullOrEmpty(Command.TAR_TIPO_FEEDBACK_SETUP_AJUSTE)) whereClauses.Add($"[TAR_TIPO_FEEDBACK_SETUP_AJUSTE] like @TAR_TIPO_FEEDBACK_SETUP_AJUSTE");
if (Command.TAR_PARAMETRO_TIME_WORK_STOP_MACHINE.HasValue) dict["TAR_PARAMETRO_TIME_WORK_STOP_MACHINE"] = Command.TAR_PARAMETRO_TIME_WORK_STOP_MACHINE.Value;
if (Command.TAR_PARAMETRO_TIME_WORK_STOP_MACHINE.HasValue) whereClauses.Add($"[TAR_PARAMETRO_TIME_WORK_STOP_MACHINE] = @TAR_PARAMETRO_TIME_WORK_STOP_MACHINE");
if (Command.TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE.HasValue) dict["TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE"] = Command.TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE.Value;
if (Command.TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE.HasValue) whereClauses.Add($"[TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE] = @TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE");
if (Command.ROT_SEQ_TRANFORMACAO.HasValue) dict["ROT_SEQ_TRANFORMACAO"] = Command.ROT_SEQ_TRANFORMACAO.Value;
if (Command.ROT_SEQ_TRANFORMACAO.HasValue) whereClauses.Add($"[ROT_SEQ_TRANFORMACAO] = @ROT_SEQ_TRANFORMACAO");
if (Command.FPR_SEQ_REPETICAO.HasValue) dict["FPR_SEQ_REPETICAO"] = Command.FPR_SEQ_REPETICAO.Value;
if (Command.FPR_SEQ_REPETICAO.HasValue) whereClauses.Add($"[FPR_SEQ_REPETICAO] = @FPR_SEQ_REPETICAO");
if (!string.IsNullOrEmpty(Command.TAR_OBS_OP_PARCIAL)) dict["TAR_OBS_OP_PARCIAL"] = $"%{Command.TAR_OBS_OP_PARCIAL}%";
if (!string.IsNullOrEmpty(Command.TAR_OBS_OP_PARCIAL)) whereClauses.Add($"[TAR_OBS_OP_PARCIAL] like @TAR_OBS_OP_PARCIAL");
if (!string.IsNullOrEmpty(Command.TAR_OCO_ID_OP_PARCIAL)) dict["TAR_OCO_ID_OP_PARCIAL"] = $"%{Command.TAR_OCO_ID_OP_PARCIAL}%";
if (!string.IsNullOrEmpty(Command.TAR_OCO_ID_OP_PARCIAL)) whereClauses.Add($"[TAR_OCO_ID_OP_PARCIAL] like @TAR_OCO_ID_OP_PARCIAL");
if (!string.IsNullOrEmpty(Command.TAR_COR_PERFORMANCE)) dict["TAR_COR_PERFORMANCE"] = $"%{Command.TAR_COR_PERFORMANCE}%";
if (!string.IsNullOrEmpty(Command.TAR_COR_PERFORMANCE)) whereClauses.Add($"[TAR_COR_PERFORMANCE] like @TAR_COR_PERFORMANCE");
if (!string.IsNullOrEmpty(Command.TAR_COR_SETUP_GERAL)) dict["TAR_COR_SETUP_GERAL"] = $"%{Command.TAR_COR_SETUP_GERAL}%";
if (!string.IsNullOrEmpty(Command.TAR_COR_SETUP_GERAL)) whereClauses.Add($"[TAR_COR_SETUP_GERAL] like @TAR_COR_SETUP_GERAL");
if (!string.IsNullOrEmpty(Command.TAR_COR_SETUP)) dict["TAR_COR_SETUP"] = $"%{Command.TAR_COR_SETUP}%";
if (!string.IsNullOrEmpty(Command.TAR_COR_SETUP)) whereClauses.Add($"[TAR_COR_SETUP] like @TAR_COR_SETUP");
if (!string.IsNullOrEmpty(Command.TAR_COR_SETUPA)) dict["TAR_COR_SETUPA"] = $"%{Command.TAR_COR_SETUPA}%";
if (!string.IsNullOrEmpty(Command.TAR_COR_SETUPA)) whereClauses.Add($"[TAR_COR_SETUPA] like @TAR_COR_SETUPA");
if (!string.IsNullOrEmpty(Command.TAR_APROVADO)) dict["TAR_APROVADO"] = $"%{Command.TAR_APROVADO}%";
if (!string.IsNullOrEmpty(Command.TAR_APROVADO)) whereClauses.Add($"[TAR_APROVADO] like @TAR_APROVADO");
if (Command.TAR_TEMPO_PRODUZINDO.HasValue) dict["TAR_TEMPO_PRODUZINDO"] = Command.TAR_TEMPO_PRODUZINDO.Value;
if (Command.TAR_TEMPO_PRODUZINDO.HasValue) whereClauses.Add($"[TAR_TEMPO_PRODUZINDO] = @TAR_TEMPO_PRODUZINDO");
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
            Query += " ORDER BY [TAR_ID] OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel TargetProdutoMOV_IDQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select [Id] from [MovimentoEstoque] ";
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
        public QueryModel TargetProdutoORD_IDQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select [ORD_ID] from [Order] ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["ORD_ID"] = numero; //01
                      whereClauses.Add($" [ORD_ID] = @ORD_ID");//01 
                 }
                 else 
                 {
                      dict["ORD_ID"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" [ORD_ID] like @ORD_ID ");//02
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
        public QueryModel TargetProdutoUNI_IDQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select [UNI_ID] from [UnidadeMedida] ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["UNI_ID"] = numero; //01
                      whereClauses.Add($" [UNI_ID] = @UNI_ID");//01 
                 }
                 else 
                 {
                      dict["UNI_ID"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" [UNI_ID] like @UNI_ID ");//02
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
        public QueryModel TargetProdutoTURM_IDQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select [Id], [Descricao] from [Turma] ";
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
                      dict["Descricao"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" [Descricao] like @Descricao ");//02
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
        public QueryModel TargetProdutoTURN_IDQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select [Id], [Descricao] from [Turno] ";
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
                      dict["Descricao"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" [Descricao] like @Descricao ");//02
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
        public QueryModel TargetProdutoUSE_IDQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select [USE_ID] from [Usuario] ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["USE_ID"] = numero; //01
                      whereClauses.Add($" [USE_ID] = @USE_ID");//01 
                 }
                 else 
                 {
                      dict["USE_ID"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" [USE_ID] like @USE_ID ");//02
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
        public QueryModel TargetProdutoOCO_ID_PERFORMANCEQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select [OCO_ID] from [Ocorrencia] ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["OCO_ID"] = numero; //01
                      whereClauses.Add($" [OCO_ID] = @OCO_ID");//01 
                 }
                 else 
                 {
                      dict["OCO_ID"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" [OCO_ID] like @OCO_ID ");//02
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
        public QueryModel TargetProdutoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel TargetProdutoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel ExistsByTAR_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_ID"] = value; //04
                      whereClauses.Add($" [TAR_ID] = @TAR_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMOV_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MOV_ID"] = value; //04
                      whereClauses.Add($" [MOV_ID] = @MOV_ID ");//04
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
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ORD_ID"] = value; //04
                      whereClauses.Add($" [ORD_ID] = @ORD_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PRO_ID"] = value; //04
                      whereClauses.Add($" [PRO_ID] = @PRO_ID ");//04
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
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_ID"] = value; //04
                      whereClauses.Add($" [MAQ_ID] = @MAQ_ID ");//04
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
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
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
        public QueryModel ExistsByTURM_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TURM_ID"] = value; //04
                      whereClauses.Add($" [TURM_ID] = @TURM_ID ");//04
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
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TURN_ID"] = value; //04
                      whereClauses.Add($" [TURN_ID] = @TURN_ID ");//04
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
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["USE_ID"] = value; //04
                      whereClauses.Add($" [USE_ID] = @USE_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTAR_DIA_TURMAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_DIA_TURMA"] = value; //04
                      whereClauses.Add($" [TAR_DIA_TURMA] = @TAR_DIA_TURMA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTAR_META_PERFORMANCEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_META_PERFORMANCE"] = value; //04
                      whereClauses.Add($" [TAR_META_PERFORMANCE] = @TAR_META_PERFORMANCE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTAR_REALIZADO_PERFORMANCEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_REALIZADO_PERFORMANCE"] = value; //04
                      whereClauses.Add($" [TAR_REALIZADO_PERFORMANCE] = @TAR_REALIZADO_PERFORMANCE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTAR_PERCENTUAL_REALIZADO_PERFORMANCEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_PERCENTUAL_REALIZADO_PERFORMANCE"] = value; //04
                      whereClauses.Add($" [TAR_PERCENTUAL_REALIZADO_PERFORMANCE] = @TAR_PERCENTUAL_REALIZADO_PERFORMANCE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTAR_PROXIMA_META_PERFORMANCEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_PROXIMA_META_PERFORMANCE"] = value; //04
                      whereClauses.Add($" [TAR_PROXIMA_META_PERFORMANCE] = @TAR_PROXIMA_META_PERFORMANCE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTAR_META_TEMPO_SETUPQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_META_TEMPO_SETUP"] = value; //04
                      whereClauses.Add($" [TAR_META_TEMPO_SETUP] = @TAR_META_TEMPO_SETUP ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTAR_REALIZADO_TEMPO_SETUPQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_REALIZADO_TEMPO_SETUP"] = value; //04
                      whereClauses.Add($" [TAR_REALIZADO_TEMPO_SETUP] = @TAR_REALIZADO_TEMPO_SETUP ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTAR_PROXIMA_META_TEMPO_SETUPQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_PROXIMA_META_TEMPO_SETUP"] = value; //04
                      whereClauses.Add($" [TAR_PROXIMA_META_TEMPO_SETUP] = @TAR_PROXIMA_META_TEMPO_SETUP ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTAR_META_TEMPO_SETUP_AJUSTEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_META_TEMPO_SETUP_AJUSTE"] = value; //04
                      whereClauses.Add($" [TAR_META_TEMPO_SETUP_AJUSTE] = @TAR_META_TEMPO_SETUP_AJUSTE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTAR_REALIZADO_TEMPO_SETUP_AJUSTEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_REALIZADO_TEMPO_SETUP_AJUSTE"] = value; //04
                      whereClauses.Add($" [TAR_REALIZADO_TEMPO_SETUP_AJUSTE] = @TAR_REALIZADO_TEMPO_SETUP_AJUSTE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTAR_PROXIMA_META_TEMPO_SETUP_AJUSTEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE"] = value; //04
                      whereClauses.Add($" [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE] = @TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByOCO_ID_PERFORMANCEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["OCO_ID_PERFORMANCE"] = value; //04
                      whereClauses.Add($" [OCO_ID_PERFORMANCE] = @OCO_ID_PERFORMANCE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTAR_OBS_PERFORMANCEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_OBS_PERFORMANCE"] = value; //04
                      whereClauses.Add($" [TAR_OBS_PERFORMANCE] = @TAR_OBS_PERFORMANCE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByOCO_ID_SETUPQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["OCO_ID_SETUP"] = value; //04
                      whereClauses.Add($" [OCO_ID_SETUP] = @OCO_ID_SETUP ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTAR_OBS_SETUPQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_OBS_SETUP"] = value; //04
                      whereClauses.Add($" [TAR_OBS_SETUP] = @TAR_OBS_SETUP ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByOCO_ID_SETUPAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["OCO_ID_SETUPA"] = value; //04
                      whereClauses.Add($" [OCO_ID_SETUPA] = @OCO_ID_SETUPA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTAR_OBS_SETUPAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_OBS_SETUPA"] = value; //04
                      whereClauses.Add($" [TAR_OBS_SETUPA] = @TAR_OBS_SETUPA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTAR_TIPO_FEEDBACK_PERFORMANCEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_TIPO_FEEDBACK_PERFORMANCE"] = value; //04
                      whereClauses.Add($" [TAR_TIPO_FEEDBACK_PERFORMANCE] = @TAR_TIPO_FEEDBACK_PERFORMANCE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTAR_TIPO_FEEDBACK_SETUPQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_TIPO_FEEDBACK_SETUP"] = value; //04
                      whereClauses.Add($" [TAR_TIPO_FEEDBACK_SETUP] = @TAR_TIPO_FEEDBACK_SETUP ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTAR_TIPO_FEEDBACK_SETUP_AJUSTEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_TIPO_FEEDBACK_SETUP_AJUSTE"] = value; //04
                      whereClauses.Add($" [TAR_TIPO_FEEDBACK_SETUP_AJUSTE] = @TAR_TIPO_FEEDBACK_SETUP_AJUSTE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTAR_QTD_SETUP_AJUSTEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_QTD_SETUP_AJUSTE"] = value; //04
                      whereClauses.Add($" [TAR_QTD_SETUP_AJUSTE] = @TAR_QTD_SETUP_AJUSTE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTAR_QTDQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_QTD"] = value; //04
                      whereClauses.Add($" [TAR_QTD] = @TAR_QTD ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTAR_PARAMETRO_TIME_WORK_STOP_MACHINEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_PARAMETRO_TIME_WORK_STOP_MACHINE"] = value; //04
                      whereClauses.Add($" [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE] = @TAR_PARAMETRO_TIME_WORK_STOP_MACHINE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE"] = value; //04
                      whereClauses.Add($" [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE] = @TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE ");//04
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
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ROT_SEQ_TRANFORMACAO"] = value; //04
                      whereClauses.Add($" [ROT_SEQ_TRANFORMACAO] = @ROT_SEQ_TRANFORMACAO ");//04
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
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["FPR_SEQ_REPETICAO"] = value; //04
                      whereClauses.Add($" [FPR_SEQ_REPETICAO] = @FPR_SEQ_REPETICAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTAR_PERFORMANCE_MAX_VERDEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_PERFORMANCE_MAX_VERDE"] = value; //04
                      whereClauses.Add($" [TAR_PERFORMANCE_MAX_VERDE] = @TAR_PERFORMANCE_MAX_VERDE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTAR_PERFORMANCE_MIN_VERDEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_PERFORMANCE_MIN_VERDE"] = value; //04
                      whereClauses.Add($" [TAR_PERFORMANCE_MIN_VERDE] = @TAR_PERFORMANCE_MIN_VERDE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTAR_SETUP_MAX_VERDEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_SETUP_MAX_VERDE"] = value; //04
                      whereClauses.Add($" [TAR_SETUP_MAX_VERDE] = @TAR_SETUP_MAX_VERDE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTAR_SETUP_MIN_VERDEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_SETUP_MIN_VERDE"] = value; //04
                      whereClauses.Add($" [TAR_SETUP_MIN_VERDE] = @TAR_SETUP_MIN_VERDE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTAR_SETUPA_MAX_VERDEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_SETUPA_MAX_VERDE"] = value; //04
                      whereClauses.Add($" [TAR_SETUPA_MAX_VERDE] = @TAR_SETUPA_MAX_VERDE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTAR_SETUPA_MIN_VERDEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_SETUPA_MIN_VERDE"] = value; //04
                      whereClauses.Add($" [TAR_SETUPA_MIN_VERDE] = @TAR_SETUPA_MIN_VERDE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTAR_PERFORMANCE_MIN_AMARELOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_PERFORMANCE_MIN_AMARELO"] = value; //04
                      whereClauses.Add($" [TAR_PERFORMANCE_MIN_AMARELO] = @TAR_PERFORMANCE_MIN_AMARELO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTAR_SETUP_MAX_AMARELOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_SETUP_MAX_AMARELO"] = value; //04
                      whereClauses.Add($" [TAR_SETUP_MAX_AMARELO] = @TAR_SETUP_MAX_AMARELO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTAR_SETUPA_MAX_AMARELOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_SETUPA_MAX_AMARELO"] = value; //04
                      whereClauses.Add($" [TAR_SETUPA_MAX_AMARELO] = @TAR_SETUPA_MAX_AMARELO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTAR_OBS_OP_PARCIALQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_OBS_OP_PARCIAL"] = value; //04
                      whereClauses.Add($" [TAR_OBS_OP_PARCIAL] = @TAR_OBS_OP_PARCIAL ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTAR_OCO_ID_OP_PARCIALQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_OCO_ID_OP_PARCIAL"] = value; //04
                      whereClauses.Add($" [TAR_OCO_ID_OP_PARCIAL] = @TAR_OCO_ID_OP_PARCIAL ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTAR_COR_PERFORMANCEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_COR_PERFORMANCE"] = value; //04
                      whereClauses.Add($" [TAR_COR_PERFORMANCE] = @TAR_COR_PERFORMANCE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTAR_COR_SETUP_GERALQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_COR_SETUP_GERAL"] = value; //04
                      whereClauses.Add($" [TAR_COR_SETUP_GERAL] = @TAR_COR_SETUP_GERAL ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTAR_COR_SETUPQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_COR_SETUP"] = value; //04
                      whereClauses.Add($" [TAR_COR_SETUP] = @TAR_COR_SETUP ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTAR_COR_SETUPAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_COR_SETUPA"] = value; //04
                      whereClauses.Add($" [TAR_COR_SETUPA] = @TAR_COR_SETUPA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTAR_DIA_TURMA_DQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_DIA_TURMA_D"] = value; //04
                      whereClauses.Add($" [TAR_DIA_TURMA_D] = @TAR_DIA_TURMA_D ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFEE_QTD_PECAS_POR_PULSOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["FEE_QTD_PECAS_POR_PULSO"] = value; //04
                      whereClauses.Add($" [FEE_QTD_PECAS_POR_PULSO] = @FEE_QTD_PECAS_POR_PULSO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTAR_QTD_PERDASQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_QTD_PERDAS"] = value; //04
                      whereClauses.Add($" [TAR_QTD_PERDAS] = @TAR_QTD_PERDAS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTAR_DATA_INICIALQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_DATA_INICIAL"] = value; //04
                      whereClauses.Add($" [TAR_DATA_INICIAL] = @TAR_DATA_INICIAL ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTAR_DATA_FINALQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_DATA_FINAL"] = value; //04
                      whereClauses.Add($" [TAR_DATA_FINAL] = @TAR_DATA_FINAL ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTAR_APROVADOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_APROVADO"] = value; //04
                      whereClauses.Add($" [TAR_APROVADO] = @TAR_APROVADO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTAR_TEMPO_PRODUZINDOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_TEMPO_PRODUZINDO"] = value; //04
                      whereClauses.Add($" [TAR_TEMPO_PRODUZINDO] = @TAR_TEMPO_PRODUZINDO ");//04
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
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
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
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
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
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
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
            this.Query = $"SELECT 1 FROM [TargetProduto] ";
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
        public QueryModel FirstByTAR_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_ID"] = value; //06
                      whereClauses.Add($" [TAR_ID] = @TAR_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMOV_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MOV_ID"] = value; //06
                      whereClauses.Add($" [MOV_ID] = @MOV_ID ");//06
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
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ORD_ID"] = value; //06
                      whereClauses.Add($" [ORD_ID] = @ORD_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PRO_ID"] = value; //06
                      whereClauses.Add($" [PRO_ID] = @PRO_ID ");//06
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
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_ID"] = value; //06
                      whereClauses.Add($" [MAQ_ID] = @MAQ_ID ");//06
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
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
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
        public QueryModel FirstByTURM_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TURM_ID"] = value; //06
                      whereClauses.Add($" [TURM_ID] = @TURM_ID ");//06
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
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TURN_ID"] = value; //06
                      whereClauses.Add($" [TURN_ID] = @TURN_ID ");//06
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
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["USE_ID"] = value; //06
                      whereClauses.Add($" [USE_ID] = @USE_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTAR_DIA_TURMAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_DIA_TURMA"] = value; //06
                      whereClauses.Add($" [TAR_DIA_TURMA] = @TAR_DIA_TURMA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTAR_META_PERFORMANCEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_META_PERFORMANCE"] = value; //06
                      whereClauses.Add($" [TAR_META_PERFORMANCE] = @TAR_META_PERFORMANCE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTAR_REALIZADO_PERFORMANCEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_REALIZADO_PERFORMANCE"] = value; //06
                      whereClauses.Add($" [TAR_REALIZADO_PERFORMANCE] = @TAR_REALIZADO_PERFORMANCE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTAR_PERCENTUAL_REALIZADO_PERFORMANCEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_PERCENTUAL_REALIZADO_PERFORMANCE"] = value; //06
                      whereClauses.Add($" [TAR_PERCENTUAL_REALIZADO_PERFORMANCE] = @TAR_PERCENTUAL_REALIZADO_PERFORMANCE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTAR_PROXIMA_META_PERFORMANCEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_PROXIMA_META_PERFORMANCE"] = value; //06
                      whereClauses.Add($" [TAR_PROXIMA_META_PERFORMANCE] = @TAR_PROXIMA_META_PERFORMANCE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTAR_META_TEMPO_SETUPQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_META_TEMPO_SETUP"] = value; //06
                      whereClauses.Add($" [TAR_META_TEMPO_SETUP] = @TAR_META_TEMPO_SETUP ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTAR_REALIZADO_TEMPO_SETUPQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_REALIZADO_TEMPO_SETUP"] = value; //06
                      whereClauses.Add($" [TAR_REALIZADO_TEMPO_SETUP] = @TAR_REALIZADO_TEMPO_SETUP ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTAR_PROXIMA_META_TEMPO_SETUPQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_PROXIMA_META_TEMPO_SETUP"] = value; //06
                      whereClauses.Add($" [TAR_PROXIMA_META_TEMPO_SETUP] = @TAR_PROXIMA_META_TEMPO_SETUP ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTAR_META_TEMPO_SETUP_AJUSTEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_META_TEMPO_SETUP_AJUSTE"] = value; //06
                      whereClauses.Add($" [TAR_META_TEMPO_SETUP_AJUSTE] = @TAR_META_TEMPO_SETUP_AJUSTE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTAR_REALIZADO_TEMPO_SETUP_AJUSTEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_REALIZADO_TEMPO_SETUP_AJUSTE"] = value; //06
                      whereClauses.Add($" [TAR_REALIZADO_TEMPO_SETUP_AJUSTE] = @TAR_REALIZADO_TEMPO_SETUP_AJUSTE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTAR_PROXIMA_META_TEMPO_SETUP_AJUSTEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE"] = value; //06
                      whereClauses.Add($" [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE] = @TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByOCO_ID_PERFORMANCEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["OCO_ID_PERFORMANCE"] = value; //06
                      whereClauses.Add($" [OCO_ID_PERFORMANCE] = @OCO_ID_PERFORMANCE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTAR_OBS_PERFORMANCEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_OBS_PERFORMANCE"] = value; //06
                      whereClauses.Add($" [TAR_OBS_PERFORMANCE] = @TAR_OBS_PERFORMANCE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByOCO_ID_SETUPQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["OCO_ID_SETUP"] = value; //06
                      whereClauses.Add($" [OCO_ID_SETUP] = @OCO_ID_SETUP ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTAR_OBS_SETUPQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_OBS_SETUP"] = value; //06
                      whereClauses.Add($" [TAR_OBS_SETUP] = @TAR_OBS_SETUP ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByOCO_ID_SETUPAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["OCO_ID_SETUPA"] = value; //06
                      whereClauses.Add($" [OCO_ID_SETUPA] = @OCO_ID_SETUPA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTAR_OBS_SETUPAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_OBS_SETUPA"] = value; //06
                      whereClauses.Add($" [TAR_OBS_SETUPA] = @TAR_OBS_SETUPA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTAR_TIPO_FEEDBACK_PERFORMANCEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_TIPO_FEEDBACK_PERFORMANCE"] = value; //06
                      whereClauses.Add($" [TAR_TIPO_FEEDBACK_PERFORMANCE] = @TAR_TIPO_FEEDBACK_PERFORMANCE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTAR_TIPO_FEEDBACK_SETUPQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_TIPO_FEEDBACK_SETUP"] = value; //06
                      whereClauses.Add($" [TAR_TIPO_FEEDBACK_SETUP] = @TAR_TIPO_FEEDBACK_SETUP ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTAR_TIPO_FEEDBACK_SETUP_AJUSTEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_TIPO_FEEDBACK_SETUP_AJUSTE"] = value; //06
                      whereClauses.Add($" [TAR_TIPO_FEEDBACK_SETUP_AJUSTE] = @TAR_TIPO_FEEDBACK_SETUP_AJUSTE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTAR_QTD_SETUP_AJUSTEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_QTD_SETUP_AJUSTE"] = value; //06
                      whereClauses.Add($" [TAR_QTD_SETUP_AJUSTE] = @TAR_QTD_SETUP_AJUSTE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTAR_QTDQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_QTD"] = value; //06
                      whereClauses.Add($" [TAR_QTD] = @TAR_QTD ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTAR_PARAMETRO_TIME_WORK_STOP_MACHINEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_PARAMETRO_TIME_WORK_STOP_MACHINE"] = value; //06
                      whereClauses.Add($" [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE] = @TAR_PARAMETRO_TIME_WORK_STOP_MACHINE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE"] = value; //06
                      whereClauses.Add($" [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE] = @TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE ");//06
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
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ROT_SEQ_TRANFORMACAO"] = value; //06
                      whereClauses.Add($" [ROT_SEQ_TRANFORMACAO] = @ROT_SEQ_TRANFORMACAO ");//06
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
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["FPR_SEQ_REPETICAO"] = value; //06
                      whereClauses.Add($" [FPR_SEQ_REPETICAO] = @FPR_SEQ_REPETICAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTAR_PERFORMANCE_MAX_VERDEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_PERFORMANCE_MAX_VERDE"] = value; //06
                      whereClauses.Add($" [TAR_PERFORMANCE_MAX_VERDE] = @TAR_PERFORMANCE_MAX_VERDE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTAR_PERFORMANCE_MIN_VERDEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_PERFORMANCE_MIN_VERDE"] = value; //06
                      whereClauses.Add($" [TAR_PERFORMANCE_MIN_VERDE] = @TAR_PERFORMANCE_MIN_VERDE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTAR_SETUP_MAX_VERDEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_SETUP_MAX_VERDE"] = value; //06
                      whereClauses.Add($" [TAR_SETUP_MAX_VERDE] = @TAR_SETUP_MAX_VERDE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTAR_SETUP_MIN_VERDEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_SETUP_MIN_VERDE"] = value; //06
                      whereClauses.Add($" [TAR_SETUP_MIN_VERDE] = @TAR_SETUP_MIN_VERDE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTAR_SETUPA_MAX_VERDEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_SETUPA_MAX_VERDE"] = value; //06
                      whereClauses.Add($" [TAR_SETUPA_MAX_VERDE] = @TAR_SETUPA_MAX_VERDE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTAR_SETUPA_MIN_VERDEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_SETUPA_MIN_VERDE"] = value; //06
                      whereClauses.Add($" [TAR_SETUPA_MIN_VERDE] = @TAR_SETUPA_MIN_VERDE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTAR_PERFORMANCE_MIN_AMARELOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_PERFORMANCE_MIN_AMARELO"] = value; //06
                      whereClauses.Add($" [TAR_PERFORMANCE_MIN_AMARELO] = @TAR_PERFORMANCE_MIN_AMARELO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTAR_SETUP_MAX_AMARELOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_SETUP_MAX_AMARELO"] = value; //06
                      whereClauses.Add($" [TAR_SETUP_MAX_AMARELO] = @TAR_SETUP_MAX_AMARELO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTAR_SETUPA_MAX_AMARELOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_SETUPA_MAX_AMARELO"] = value; //06
                      whereClauses.Add($" [TAR_SETUPA_MAX_AMARELO] = @TAR_SETUPA_MAX_AMARELO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTAR_OBS_OP_PARCIALQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_OBS_OP_PARCIAL"] = value; //06
                      whereClauses.Add($" [TAR_OBS_OP_PARCIAL] = @TAR_OBS_OP_PARCIAL ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTAR_OCO_ID_OP_PARCIALQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_OCO_ID_OP_PARCIAL"] = value; //06
                      whereClauses.Add($" [TAR_OCO_ID_OP_PARCIAL] = @TAR_OCO_ID_OP_PARCIAL ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTAR_COR_PERFORMANCEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_COR_PERFORMANCE"] = value; //06
                      whereClauses.Add($" [TAR_COR_PERFORMANCE] = @TAR_COR_PERFORMANCE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTAR_COR_SETUP_GERALQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_COR_SETUP_GERAL"] = value; //06
                      whereClauses.Add($" [TAR_COR_SETUP_GERAL] = @TAR_COR_SETUP_GERAL ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTAR_COR_SETUPQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_COR_SETUP"] = value; //06
                      whereClauses.Add($" [TAR_COR_SETUP] = @TAR_COR_SETUP ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTAR_COR_SETUPAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_COR_SETUPA"] = value; //06
                      whereClauses.Add($" [TAR_COR_SETUPA] = @TAR_COR_SETUPA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTAR_DIA_TURMA_DQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_DIA_TURMA_D"] = value; //06
                      whereClauses.Add($" [TAR_DIA_TURMA_D] = @TAR_DIA_TURMA_D ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFEE_QTD_PECAS_POR_PULSOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["FEE_QTD_PECAS_POR_PULSO"] = value; //06
                      whereClauses.Add($" [FEE_QTD_PECAS_POR_PULSO] = @FEE_QTD_PECAS_POR_PULSO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTAR_QTD_PERDASQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_QTD_PERDAS"] = value; //06
                      whereClauses.Add($" [TAR_QTD_PERDAS] = @TAR_QTD_PERDAS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTAR_DATA_INICIALQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_DATA_INICIAL"] = value; //06
                      whereClauses.Add($" [TAR_DATA_INICIAL] = @TAR_DATA_INICIAL ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTAR_DATA_FINALQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_DATA_FINAL"] = value; //06
                      whereClauses.Add($" [TAR_DATA_FINAL] = @TAR_DATA_FINAL ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTAR_APROVADOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_APROVADO"] = value; //06
                      whereClauses.Add($" [TAR_APROVADO] = @TAR_APROVADO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTAR_TEMPO_PRODUZINDOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TAR_TEMPO_PRODUZINDO"] = value; //06
                      whereClauses.Add($" [TAR_TEMPO_PRODUZINDO] = @TAR_TEMPO_PRODUZINDO ");//06
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
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
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
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
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
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
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
            this.Query = $"SELECT [TAR_ID], [MOV_ID], [ORD_ID], [PRO_ID], [MAQ_ID], [UNI_ID], [TURM_ID], [TURN_ID], [USE_ID], [TAR_DIA_TURMA], [TAR_META_PERFORMANCE], [TAR_REALIZADO_PERFORMANCE], [TAR_PERCENTUAL_REALIZADO_PERFORMANCE], [TAR_PROXIMA_META_PERFORMANCE], [TAR_META_TEMPO_SETUP], [TAR_REALIZADO_TEMPO_SETUP], [TAR_PROXIMA_META_TEMPO_SETUP], [TAR_META_TEMPO_SETUP_AJUSTE], [TAR_REALIZADO_TEMPO_SETUP_AJUSTE], [TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE], [OCO_ID_PERFORMANCE], [TAR_OBS_PERFORMANCE], [OCO_ID_SETUP], [TAR_OBS_SETUP], [OCO_ID_SETUPA], [TAR_OBS_SETUPA], [TAR_TIPO_FEEDBACK_PERFORMANCE], [TAR_TIPO_FEEDBACK_SETUP], [TAR_TIPO_FEEDBACK_SETUP_AJUSTE], [TAR_QTD_SETUP_AJUSTE], [TAR_QTD], [TAR_PARAMETRO_TIME_WORK_STOP_MACHINE], [TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [TAR_PERFORMANCE_MAX_VERDE], [TAR_PERFORMANCE_MIN_VERDE], [TAR_SETUP_MAX_VERDE], [TAR_SETUP_MIN_VERDE], [TAR_SETUPA_MAX_VERDE], [TAR_SETUPA_MIN_VERDE], [TAR_PERFORMANCE_MIN_AMARELO], [TAR_SETUP_MAX_AMARELO], [TAR_SETUPA_MAX_AMARELO], [TAR_OBS_OP_PARCIAL], [TAR_OCO_ID_OP_PARCIAL], [TAR_COR_PERFORMANCE], [TAR_COR_SETUP_GERAL], [TAR_COR_SETUP], [TAR_COR_SETUPA], [TAR_DIA_TURMA_D], [FEE_QTD_PECAS_POR_PULSO], [TAR_QTD_PERDAS], [TAR_DATA_INICIAL], [TAR_DATA_FINAL], [TAR_APROVADO], [TAR_TEMPO_PRODUZINDO], [TenantID], [Deleted], [Changed], [UserId] FROM [TargetProduto] ";
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