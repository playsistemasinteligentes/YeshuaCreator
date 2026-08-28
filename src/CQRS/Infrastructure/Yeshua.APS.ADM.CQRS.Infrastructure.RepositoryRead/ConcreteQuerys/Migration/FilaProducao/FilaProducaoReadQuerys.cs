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
    public class FilaProducaoQueryRead : QueryBase, IFilaProducaoQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public FilaProducaoQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel FilaProducaoQuery(Command.Read.FilaProducaoReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId from FilaProducao ";
if (Command.Id.HasValue) dict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"Id = @Id");
if (!string.IsNullOrEmpty(Command.ORD_ID)) dict["ORD_ID"] = $"%{Command.ORD_ID}%";
if (!string.IsNullOrEmpty(Command.ORD_ID)) whereClauses.Add($"ORD_ID like @ORD_ID");
if (!string.IsNullOrEmpty(Command.ROT_PRO_ID)) dict["ROT_PRO_ID"] = $"%{Command.ROT_PRO_ID}%";
if (!string.IsNullOrEmpty(Command.ROT_PRO_ID)) whereClauses.Add($"ROT_PRO_ID like @ROT_PRO_ID");
if (!string.IsNullOrEmpty(Command.ROT_MAQ_ID)) dict["ROT_MAQ_ID"] = $"%{Command.ROT_MAQ_ID}%";
if (!string.IsNullOrEmpty(Command.ROT_MAQ_ID)) whereClauses.Add($"ROT_MAQ_ID like @ROT_MAQ_ID");
if (Command.ROT_SEQ_TRANFORMACAO.HasValue) dict["ROT_SEQ_TRANFORMACAO"] = Command.ROT_SEQ_TRANFORMACAO.Value;
if (Command.ROT_SEQ_TRANFORMACAO.HasValue) whereClauses.Add($"ROT_SEQ_TRANFORMACAO = @ROT_SEQ_TRANFORMACAO");
if (Command.FPR_SEQ_REPETICAO.HasValue) dict["FPR_SEQ_REPETICAO"] = Command.FPR_SEQ_REPETICAO.Value;
if (Command.FPR_SEQ_REPETICAO.HasValue) whereClauses.Add($"FPR_SEQ_REPETICAO = @FPR_SEQ_REPETICAO");
if (!string.IsNullOrEmpty(Command.FPR_OBS_PRODUCAO)) dict["FPR_OBS_PRODUCAO"] = $"%{Command.FPR_OBS_PRODUCAO}%";
if (!string.IsNullOrEmpty(Command.FPR_OBS_PRODUCAO)) whereClauses.Add($"FPR_OBS_PRODUCAO like @FPR_OBS_PRODUCAO");
if (!string.IsNullOrEmpty(Command.FPR_STATUS)) dict["FPR_STATUS"] = $"%{Command.FPR_STATUS}%";
if (!string.IsNullOrEmpty(Command.FPR_STATUS)) whereClauses.Add($"FPR_STATUS like @FPR_STATUS");
if (Command.FPR_PRODUZINDO.HasValue) dict["FPR_PRODUZINDO"] = Command.FPR_PRODUZINDO.Value;
if (Command.FPR_PRODUZINDO.HasValue) whereClauses.Add($"FPR_PRODUZINDO = @FPR_PRODUZINDO");
if (!string.IsNullOrEmpty(Command.FPR_ID_INTEGRACAO)) dict["FPR_ID_INTEGRACAO"] = $"%{Command.FPR_ID_INTEGRACAO}%";
if (!string.IsNullOrEmpty(Command.FPR_ID_INTEGRACAO)) whereClauses.Add($"FPR_ID_INTEGRACAO like @FPR_ID_INTEGRACAO");
if (!string.IsNullOrEmpty(Command.FPR_TRUNCADO)) dict["FPR_TRUNCADO"] = $"%{Command.FPR_TRUNCADO}%";
if (!string.IsNullOrEmpty(Command.FPR_TRUNCADO)) whereClauses.Add($"FPR_TRUNCADO like @FPR_TRUNCADO");
if (Command.FPR_ID.HasValue) dict["FPR_ID"] = Command.FPR_ID.Value;
if (Command.FPR_ID.HasValue) whereClauses.Add($"FPR_ID = @FPR_ID");
if (!string.IsNullOrEmpty(Command.FPR_COR_FILA)) dict["FPR_COR_FILA"] = $"%{Command.FPR_COR_FILA}%";
if (!string.IsNullOrEmpty(Command.FPR_COR_FILA)) whereClauses.Add($"FPR_COR_FILA like @FPR_COR_FILA");
if (!string.IsNullOrEmpty(Command.MAQ_ID_MANUAL)) dict["MAQ_ID_MANUAL"] = $"%{Command.MAQ_ID_MANUAL}%";
if (!string.IsNullOrEmpty(Command.MAQ_ID_MANUAL)) whereClauses.Add($"MAQ_ID_MANUAL like @MAQ_ID_MANUAL");
if (!string.IsNullOrEmpty(Command.MAQ_ID_RESTRINGIDA)) dict["MAQ_ID_RESTRINGIDA"] = $"%{Command.MAQ_ID_RESTRINGIDA}%";
if (!string.IsNullOrEmpty(Command.MAQ_ID_RESTRINGIDA)) whereClauses.Add($"MAQ_ID_RESTRINGIDA like @MAQ_ID_RESTRINGIDA");
if (!string.IsNullOrEmpty(Command.FPR_COR_BICO1)) dict["FPR_COR_BICO1"] = $"%{Command.FPR_COR_BICO1}%";
if (!string.IsNullOrEmpty(Command.FPR_COR_BICO1)) whereClauses.Add($"FPR_COR_BICO1 like @FPR_COR_BICO1");
if (!string.IsNullOrEmpty(Command.FPR_COR_BICO2)) dict["FPR_COR_BICO2"] = $"%{Command.FPR_COR_BICO2}%";
if (!string.IsNullOrEmpty(Command.FPR_COR_BICO2)) whereClauses.Add($"FPR_COR_BICO2 like @FPR_COR_BICO2");
if (!string.IsNullOrEmpty(Command.FPR_COR_BICO3)) dict["FPR_COR_BICO3"] = $"%{Command.FPR_COR_BICO3}%";
if (!string.IsNullOrEmpty(Command.FPR_COR_BICO3)) whereClauses.Add($"FPR_COR_BICO3 like @FPR_COR_BICO3");
if (!string.IsNullOrEmpty(Command.FPR_COR_BICO4)) dict["FPR_COR_BICO4"] = $"%{Command.FPR_COR_BICO4}%";
if (!string.IsNullOrEmpty(Command.FPR_COR_BICO4)) whereClauses.Add($"FPR_COR_BICO4 like @FPR_COR_BICO4");
if (!string.IsNullOrEmpty(Command.FPR_COR_BICO5)) dict["FPR_COR_BICO5"] = $"%{Command.FPR_COR_BICO5}%";
if (!string.IsNullOrEmpty(Command.FPR_COR_BICO5)) whereClauses.Add($"FPR_COR_BICO5 like @FPR_COR_BICO5");
if (!string.IsNullOrEmpty(Command.FPR_ORD_ID_REPROGRAMADO)) dict["FPR_ORD_ID_REPROGRAMADO"] = $"%{Command.FPR_ORD_ID_REPROGRAMADO}%";
if (!string.IsNullOrEmpty(Command.FPR_ORD_ID_REPROGRAMADO)) whereClauses.Add($"FPR_ORD_ID_REPROGRAMADO like @FPR_ORD_ID_REPROGRAMADO");
if (Command.FPR_PRIORIDADE.HasValue) dict["FPR_PRIORIDADE"] = Command.FPR_PRIORIDADE.Value;
if (Command.FPR_PRIORIDADE.HasValue) whereClauses.Add($"FPR_PRIORIDADE = @FPR_PRIORIDADE");
if (Command.FPR_SEQ_INCLUSAO_FILA.HasValue) dict["FPR_SEQ_INCLUSAO_FILA"] = Command.FPR_SEQ_INCLUSAO_FILA.Value;
if (Command.FPR_SEQ_INCLUSAO_FILA.HasValue) whereClauses.Add($"FPR_SEQ_INCLUSAO_FILA = @FPR_SEQ_INCLUSAO_FILA");
if (Command.FPR_HIERARQUIA_SEQ_TRANSFORMACAO.HasValue) dict["FPR_HIERARQUIA_SEQ_TRANSFORMACAO"] = Command.FPR_HIERARQUIA_SEQ_TRANSFORMACAO.Value;
if (Command.FPR_HIERARQUIA_SEQ_TRANSFORMACAO.HasValue) whereClauses.Add($"FPR_HIERARQUIA_SEQ_TRANSFORMACAO = @FPR_HIERARQUIA_SEQ_TRANSFORMACAO");
if (Command.FPR_ID_ORIGEM.HasValue) dict["FPR_ID_ORIGEM"] = Command.FPR_ID_ORIGEM.Value;
if (Command.FPR_ID_ORIGEM.HasValue) whereClauses.Add($"FPR_ID_ORIGEM = @FPR_ID_ORIGEM");
if (!string.IsNullOrEmpty(Command.EQU_ID)) dict["EQU_ID"] = $"%{Command.EQU_ID}%";
if (!string.IsNullOrEmpty(Command.EQU_ID)) whereClauses.Add($"EQU_ID like @EQU_ID");
if (!string.IsNullOrEmpty(Command.FPR_MOTIVO_PULA_FILA)) dict["FPR_MOTIVO_PULA_FILA"] = $"%{Command.FPR_MOTIVO_PULA_FILA}%";
if (!string.IsNullOrEmpty(Command.FPR_MOTIVO_PULA_FILA)) whereClauses.Add($"FPR_MOTIVO_PULA_FILA like @FPR_MOTIVO_PULA_FILA");
if (!string.IsNullOrEmpty(Command.OCO_ID)) dict["OCO_ID"] = $"%{Command.OCO_ID}%";
if (!string.IsNullOrEmpty(Command.OCO_ID)) whereClauses.Add($"OCO_ID like @OCO_ID");
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
        public QueryModel FilaProducaoORD_IDQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel FilaProducaoOCO_IDQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select OCO_ID from Ocorrencia ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["OCO_ID"] = numero; //01
                      whereClauses.Add($" OCO_ID = @OCO_ID");//01 
                 }
                 else 
                 {
                      dict["OCO_ID"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" OCO_ID like @OCO_ID ");//02
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
        public QueryModel FilaProducaoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel FilaProducaoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
            this.Query = $"SELECT 1 FROM FilaProducao ";
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
        public QueryModel ExistsByORD_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
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
            this.Query = $"SELECT 1 FROM FilaProducao ";
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
        public QueryModel ExistsByFPR_QUANTIDADE_PREVISTAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_QUANTIDADE_PREVISTA"] = value; //04
                      whereClauses.Add($" FPR_QUANTIDADE_PREVISTA = @FPR_QUANTIDADE_PREVISTA ");//04
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
            this.Query = $"SELECT 1 FROM FilaProducao ";
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
        public QueryModel ExistsByFPR_DATA_INICIO_PREVISTAQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_DATA_INICIO_PREVISTA"] = value; //04
                      whereClauses.Add($" FPR_DATA_INICIO_PREVISTA = @FPR_DATA_INICIO_PREVISTA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_DATA_FIM_PREVISTAQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_DATA_FIM_PREVISTA"] = value; //04
                      whereClauses.Add($" FPR_DATA_FIM_PREVISTA = @FPR_DATA_FIM_PREVISTA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_DATA_FIM_MAXIMAQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_DATA_FIM_MAXIMA"] = value; //04
                      whereClauses.Add($" FPR_DATA_FIM_MAXIMA = @FPR_DATA_FIM_MAXIMA ");//04
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
            this.Query = $"SELECT 1 FROM FilaProducao ";
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
            this.Query = $"SELECT 1 FROM FilaProducao ";
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
        public QueryModel ExistsByFPR_OBS_PRODUCAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_OBS_PRODUCAO"] = value; //04
                      whereClauses.Add($" FPR_OBS_PRODUCAO = @FPR_OBS_PRODUCAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_STATUSQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_STATUS"] = value; //04
                      whereClauses.Add($" FPR_STATUS = @FPR_STATUS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_TEMPO_DECORRIDO_SETUPQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_TEMPO_DECORRIDO_SETUP"] = value; //04
                      whereClauses.Add($" FPR_TEMPO_DECORRIDO_SETUP = @FPR_TEMPO_DECORRIDO_SETUP ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_TEMPO_DECORRIDO_SETUPAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_TEMPO_DECORRIDO_SETUPA"] = value; //04
                      whereClauses.Add($" FPR_TEMPO_DECORRIDO_SETUPA = @FPR_TEMPO_DECORRIDO_SETUPA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_TEMPO_DECORRIDO_PERFORMANCQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_TEMPO_DECORRIDO_PERFORMANC"] = value; //04
                      whereClauses.Add($" FPR_TEMPO_DECORRIDO_PERFORMANC = @FPR_TEMPO_DECORRIDO_PERFORMANC ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_TEMPO_DECO_PEQUENA_PARADAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_TEMPO_DECO_PEQUENA_PARADA"] = value; //04
                      whereClauses.Add($" FPR_TEMPO_DECO_PEQUENA_PARADA = @FPR_TEMPO_DECO_PEQUENA_PARADA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_QTD_PERFORMANCEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_QTD_PERFORMANCE"] = value; //04
                      whereClauses.Add($" FPR_QTD_PERFORMANCE = @FPR_QTD_PERFORMANCE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_QTD_SETUPQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_QTD_SETUP"] = value; //04
                      whereClauses.Add($" FPR_QTD_SETUP = @FPR_QTD_SETUP ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_QTD_PRODUZIDAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_QTD_PRODUZIDA"] = value; //04
                      whereClauses.Add($" FPR_QTD_PRODUZIDA = @FPR_QTD_PRODUZIDA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_TEMPO_TEORICO_PERFORMANCEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_TEMPO_TEORICO_PERFORMANCE"] = value; //04
                      whereClauses.Add($" FPR_TEMPO_TEORICO_PERFORMANCE = @FPR_TEMPO_TEORICO_PERFORMANCE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_TEMPO_RESTANTE_PERFORMANCQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_TEMPO_RESTANTE_PERFORMANC"] = value; //04
                      whereClauses.Add($" FPR_TEMPO_RESTANTE_PERFORMANC = @FPR_TEMPO_RESTANTE_PERFORMANC ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_VELOCIDADE_P_ATINGIR_METAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_VELOCIDADE_P_ATINGIR_META"] = value; //04
                      whereClauses.Add($" FPR_VELOCIDADE_P_ATINGIR_META = @FPR_VELOCIDADE_P_ATINGIR_META ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_QTD_RESTANTEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_QTD_RESTANTE"] = value; //04
                      whereClauses.Add($" FPR_QTD_RESTANTE = @FPR_QTD_RESTANTE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_VELO_ATU_PC_SEGUNDOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_VELO_ATU_PC_SEGUNDO"] = value; //04
                      whereClauses.Add($" FPR_VELO_ATU_PC_SEGUNDO = @FPR_VELO_ATU_PC_SEGUNDO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_PERFORMANCE_PROJETADAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_PERFORMANCE_PROJETADA"] = value; //04
                      whereClauses.Add($" FPR_PERFORMANCE_PROJETADA = @FPR_PERFORMANCE_PROJETADA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_TEMPO_RESTANTE_TOTALQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_TEMPO_RESTANTE_TOTAL"] = value; //04
                      whereClauses.Add($" FPR_TEMPO_RESTANTE_TOTAL = @FPR_TEMPO_RESTANTE_TOTAL ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_FIM_PREVISTO_ATUALQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_FIM_PREVISTO_ATUAL"] = value; //04
                      whereClauses.Add($" FPR_FIM_PREVISTO_ATUAL = @FPR_FIM_PREVISTO_ATUAL ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_PRODUZINDOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_PRODUZINDO"] = value; //04
                      whereClauses.Add($" FPR_PRODUZINDO = @FPR_PRODUZINDO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_ORDEM_NA_FILAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_ORDEM_NA_FILA"] = value; //04
                      whereClauses.Add($" FPR_ORDEM_NA_FILA = @FPR_ORDEM_NA_FILA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_ID_INTEGRACAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_ID_INTEGRACAO"] = value; //04
                      whereClauses.Add($" FPR_ID_INTEGRACAO = @FPR_ID_INTEGRACAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_TRUNCADOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_TRUNCADO"] = value; //04
                      whereClauses.Add($" FPR_TRUNCADO = @FPR_TRUNCADO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_DATA_TRUNC_INIQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_DATA_TRUNC_INI"] = value; //04
                      whereClauses.Add($" FPR_DATA_TRUNC_INI = @FPR_DATA_TRUNC_INI ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_DATA_TRUNC_FIMQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_DATA_TRUNC_FIM"] = value; //04
                      whereClauses.Add($" FPR_DATA_TRUNC_FIM = @FPR_DATA_TRUNC_FIM ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_ID"] = value; //04
                      whereClauses.Add($" FPR_ID = @FPR_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_COR_FILAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_COR_FILA"] = value; //04
                      whereClauses.Add($" FPR_COR_FILA = @FPR_COR_FILA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_ID_MANUALQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MAQ_ID_MANUAL"] = value; //04
                      whereClauses.Add($" MAQ_ID_MANUAL = @MAQ_ID_MANUAL ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_ID_RESTRINGIDAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MAQ_ID_RESTRINGIDA"] = value; //04
                      whereClauses.Add($" MAQ_ID_RESTRINGIDA = @MAQ_ID_RESTRINGIDA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_PREVISAO_MATERIA_PRIMAQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_PREVISAO_MATERIA_PRIMA"] = value; //04
                      whereClauses.Add($" FPR_PREVISAO_MATERIA_PRIMA = @FPR_PREVISAO_MATERIA_PRIMA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_DATA_NECESSIDADE_INICIO_PRODUCAOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_DATA_NECESSIDADE_INICIO_PRODUCAO"] = value; //04
                      whereClauses.Add($" FPR_DATA_NECESSIDADE_INICIO_PRODUCAO = @FPR_DATA_NECESSIDADE_INICIO_PRODUCAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_DATA_NECESSIDADE_FIM_PRODUCAOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_DATA_NECESSIDADE_FIM_PRODUCAO"] = value; //04
                      whereClauses.Add($" FPR_DATA_NECESSIDADE_FIM_PRODUCAO = @FPR_DATA_NECESSIDADE_FIM_PRODUCAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_GRUPO_PRODUTIVOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_GRUPO_PRODUTIVO"] = value; //04
                      whereClauses.Add($" FPR_GRUPO_PRODUTIVO = @FPR_GRUPO_PRODUTIVO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_INICIO_GRUPO_PRODUTIVOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_INICIO_GRUPO_PRODUTIVO"] = value; //04
                      whereClauses.Add($" FPR_INICIO_GRUPO_PRODUTIVO = @FPR_INICIO_GRUPO_PRODUTIVO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_FIM_GRUPO_PRODUTIVOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_FIM_GRUPO_PRODUTIVO"] = value; //04
                      whereClauses.Add($" FPR_FIM_GRUPO_PRODUTIVO = @FPR_FIM_GRUPO_PRODUTIVO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_COR_BICO1Query(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_COR_BICO1"] = value; //04
                      whereClauses.Add($" FPR_COR_BICO1 = @FPR_COR_BICO1 ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_COR_BICO2Query(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_COR_BICO2"] = value; //04
                      whereClauses.Add($" FPR_COR_BICO2 = @FPR_COR_BICO2 ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_COR_BICO3Query(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_COR_BICO3"] = value; //04
                      whereClauses.Add($" FPR_COR_BICO3 = @FPR_COR_BICO3 ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_COR_BICO4Query(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_COR_BICO4"] = value; //04
                      whereClauses.Add($" FPR_COR_BICO4 = @FPR_COR_BICO4 ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_COR_BICO5Query(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_COR_BICO5"] = value; //04
                      whereClauses.Add($" FPR_COR_BICO5 = @FPR_COR_BICO5 ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_META_SETUPQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_META_SETUP"] = value; //04
                      whereClauses.Add($" FPR_META_SETUP = @FPR_META_SETUP ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_ORD_ID_REPROGRAMADOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_ORD_ID_REPROGRAMADO"] = value; //04
                      whereClauses.Add($" FPR_ORD_ID_REPROGRAMADO = @FPR_ORD_ID_REPROGRAMADO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_PRIORIDADEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_PRIORIDADE"] = value; //04
                      whereClauses.Add($" FPR_PRIORIDADE = @FPR_PRIORIDADE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_SEQ_INCLUSAO_FILAQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_SEQ_INCLUSAO_FILA"] = value; //04
                      whereClauses.Add($" FPR_SEQ_INCLUSAO_FILA = @FPR_SEQ_INCLUSAO_FILA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_HIERARQUIA_SEQ_TRANSFORMACAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_HIERARQUIA_SEQ_TRANSFORMACAO"] = value; //04
                      whereClauses.Add($" FPR_HIERARQUIA_SEQ_TRANSFORMACAO = @FPR_HIERARQUIA_SEQ_TRANSFORMACAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_ID_ORIGEMQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_ID_ORIGEM"] = value; //04
                      whereClauses.Add($" FPR_ID_ORIGEM = @FPR_ID_ORIGEM ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_DATA_ENTREGAQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_DATA_ENTREGA"] = value; //04
                      whereClauses.Add($" FPR_DATA_ENTREGA = @FPR_DATA_ENTREGA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByEQU_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["EQU_ID"] = value; //04
                      whereClauses.Add($" EQU_ID = @EQU_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_GRUPO_PRODUTIVO_MANUALQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_GRUPO_PRODUTIVO_MANUAL"] = value; //04
                      whereClauses.Add($" FPR_GRUPO_PRODUTIVO_MANUAL = @FPR_GRUPO_PRODUTIVO_MANUAL ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_EMISSAOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_EMISSAO"] = value; //04
                      whereClauses.Add($" FPR_EMISSAO = @FPR_EMISSAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_MOTIVO_PULA_FILAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_MOTIVO_PULA_FILA"] = value; //04
                      whereClauses.Add($" FPR_MOTIVO_PULA_FILA = @FPR_MOTIVO_PULA_FILA ");//04
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
            this.Query = $"SELECT 1 FROM FilaProducao ";
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
        public QueryModel ExistsByFPR_TOLERANCIA_MENOSQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_TOLERANCIA_MENOS"] = value; //04
                      whereClauses.Add($" FPR_TOLERANCIA_MENOS = @FPR_TOLERANCIA_MENOS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_TOLERANCIA_MAISQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_TOLERANCIA_MAIS"] = value; //04
                      whereClauses.Add($" FPR_TOLERANCIA_MAIS = @FPR_TOLERANCIA_MAIS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_DATA_ENCERRAMENTOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_DATA_ENCERRAMENTO"] = value; //04
                      whereClauses.Add($" FPR_DATA_ENCERRAMENTO = @FPR_DATA_ENCERRAMENTO ");//04
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
            this.Query = $"SELECT 1 FROM FilaProducao ";
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
            this.Query = $"SELECT 1 FROM FilaProducao ";
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
            this.Query = $"SELECT 1 FROM FilaProducao ";
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
            this.Query = $"SELECT 1 FROM FilaProducao ";
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
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
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
        public QueryModel FirstByORD_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
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
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
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
        public QueryModel FirstByFPR_QUANTIDADE_PREVISTAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_QUANTIDADE_PREVISTA"] = value; //06
                      whereClauses.Add($" FPR_QUANTIDADE_PREVISTA = @FPR_QUANTIDADE_PREVISTA ");//06
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
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
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
        public QueryModel FirstByFPR_DATA_INICIO_PREVISTAQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_DATA_INICIO_PREVISTA"] = value; //06
                      whereClauses.Add($" FPR_DATA_INICIO_PREVISTA = @FPR_DATA_INICIO_PREVISTA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_DATA_FIM_PREVISTAQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_DATA_FIM_PREVISTA"] = value; //06
                      whereClauses.Add($" FPR_DATA_FIM_PREVISTA = @FPR_DATA_FIM_PREVISTA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_DATA_FIM_MAXIMAQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_DATA_FIM_MAXIMA"] = value; //06
                      whereClauses.Add($" FPR_DATA_FIM_MAXIMA = @FPR_DATA_FIM_MAXIMA ");//06
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
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
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
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
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
        public QueryModel FirstByFPR_OBS_PRODUCAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_OBS_PRODUCAO"] = value; //06
                      whereClauses.Add($" FPR_OBS_PRODUCAO = @FPR_OBS_PRODUCAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_STATUSQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_STATUS"] = value; //06
                      whereClauses.Add($" FPR_STATUS = @FPR_STATUS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_TEMPO_DECORRIDO_SETUPQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_TEMPO_DECORRIDO_SETUP"] = value; //06
                      whereClauses.Add($" FPR_TEMPO_DECORRIDO_SETUP = @FPR_TEMPO_DECORRIDO_SETUP ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_TEMPO_DECORRIDO_SETUPAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_TEMPO_DECORRIDO_SETUPA"] = value; //06
                      whereClauses.Add($" FPR_TEMPO_DECORRIDO_SETUPA = @FPR_TEMPO_DECORRIDO_SETUPA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_TEMPO_DECORRIDO_PERFORMANCQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_TEMPO_DECORRIDO_PERFORMANC"] = value; //06
                      whereClauses.Add($" FPR_TEMPO_DECORRIDO_PERFORMANC = @FPR_TEMPO_DECORRIDO_PERFORMANC ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_TEMPO_DECO_PEQUENA_PARADAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_TEMPO_DECO_PEQUENA_PARADA"] = value; //06
                      whereClauses.Add($" FPR_TEMPO_DECO_PEQUENA_PARADA = @FPR_TEMPO_DECO_PEQUENA_PARADA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_QTD_PERFORMANCEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_QTD_PERFORMANCE"] = value; //06
                      whereClauses.Add($" FPR_QTD_PERFORMANCE = @FPR_QTD_PERFORMANCE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_QTD_SETUPQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_QTD_SETUP"] = value; //06
                      whereClauses.Add($" FPR_QTD_SETUP = @FPR_QTD_SETUP ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_QTD_PRODUZIDAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_QTD_PRODUZIDA"] = value; //06
                      whereClauses.Add($" FPR_QTD_PRODUZIDA = @FPR_QTD_PRODUZIDA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_TEMPO_TEORICO_PERFORMANCEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_TEMPO_TEORICO_PERFORMANCE"] = value; //06
                      whereClauses.Add($" FPR_TEMPO_TEORICO_PERFORMANCE = @FPR_TEMPO_TEORICO_PERFORMANCE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_TEMPO_RESTANTE_PERFORMANCQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_TEMPO_RESTANTE_PERFORMANC"] = value; //06
                      whereClauses.Add($" FPR_TEMPO_RESTANTE_PERFORMANC = @FPR_TEMPO_RESTANTE_PERFORMANC ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_VELOCIDADE_P_ATINGIR_METAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_VELOCIDADE_P_ATINGIR_META"] = value; //06
                      whereClauses.Add($" FPR_VELOCIDADE_P_ATINGIR_META = @FPR_VELOCIDADE_P_ATINGIR_META ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_QTD_RESTANTEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_QTD_RESTANTE"] = value; //06
                      whereClauses.Add($" FPR_QTD_RESTANTE = @FPR_QTD_RESTANTE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_VELO_ATU_PC_SEGUNDOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_VELO_ATU_PC_SEGUNDO"] = value; //06
                      whereClauses.Add($" FPR_VELO_ATU_PC_SEGUNDO = @FPR_VELO_ATU_PC_SEGUNDO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_PERFORMANCE_PROJETADAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_PERFORMANCE_PROJETADA"] = value; //06
                      whereClauses.Add($" FPR_PERFORMANCE_PROJETADA = @FPR_PERFORMANCE_PROJETADA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_TEMPO_RESTANTE_TOTALQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_TEMPO_RESTANTE_TOTAL"] = value; //06
                      whereClauses.Add($" FPR_TEMPO_RESTANTE_TOTAL = @FPR_TEMPO_RESTANTE_TOTAL ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_FIM_PREVISTO_ATUALQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_FIM_PREVISTO_ATUAL"] = value; //06
                      whereClauses.Add($" FPR_FIM_PREVISTO_ATUAL = @FPR_FIM_PREVISTO_ATUAL ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_PRODUZINDOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_PRODUZINDO"] = value; //06
                      whereClauses.Add($" FPR_PRODUZINDO = @FPR_PRODUZINDO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_ORDEM_NA_FILAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_ORDEM_NA_FILA"] = value; //06
                      whereClauses.Add($" FPR_ORDEM_NA_FILA = @FPR_ORDEM_NA_FILA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_ID_INTEGRACAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_ID_INTEGRACAO"] = value; //06
                      whereClauses.Add($" FPR_ID_INTEGRACAO = @FPR_ID_INTEGRACAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_TRUNCADOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_TRUNCADO"] = value; //06
                      whereClauses.Add($" FPR_TRUNCADO = @FPR_TRUNCADO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_DATA_TRUNC_INIQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_DATA_TRUNC_INI"] = value; //06
                      whereClauses.Add($" FPR_DATA_TRUNC_INI = @FPR_DATA_TRUNC_INI ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_DATA_TRUNC_FIMQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_DATA_TRUNC_FIM"] = value; //06
                      whereClauses.Add($" FPR_DATA_TRUNC_FIM = @FPR_DATA_TRUNC_FIM ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_ID"] = value; //06
                      whereClauses.Add($" FPR_ID = @FPR_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_COR_FILAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_COR_FILA"] = value; //06
                      whereClauses.Add($" FPR_COR_FILA = @FPR_COR_FILA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_ID_MANUALQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MAQ_ID_MANUAL"] = value; //06
                      whereClauses.Add($" MAQ_ID_MANUAL = @MAQ_ID_MANUAL ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_ID_RESTRINGIDAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MAQ_ID_RESTRINGIDA"] = value; //06
                      whereClauses.Add($" MAQ_ID_RESTRINGIDA = @MAQ_ID_RESTRINGIDA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_PREVISAO_MATERIA_PRIMAQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_PREVISAO_MATERIA_PRIMA"] = value; //06
                      whereClauses.Add($" FPR_PREVISAO_MATERIA_PRIMA = @FPR_PREVISAO_MATERIA_PRIMA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_DATA_NECESSIDADE_INICIO_PRODUCAOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_DATA_NECESSIDADE_INICIO_PRODUCAO"] = value; //06
                      whereClauses.Add($" FPR_DATA_NECESSIDADE_INICIO_PRODUCAO = @FPR_DATA_NECESSIDADE_INICIO_PRODUCAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_DATA_NECESSIDADE_FIM_PRODUCAOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_DATA_NECESSIDADE_FIM_PRODUCAO"] = value; //06
                      whereClauses.Add($" FPR_DATA_NECESSIDADE_FIM_PRODUCAO = @FPR_DATA_NECESSIDADE_FIM_PRODUCAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_GRUPO_PRODUTIVOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_GRUPO_PRODUTIVO"] = value; //06
                      whereClauses.Add($" FPR_GRUPO_PRODUTIVO = @FPR_GRUPO_PRODUTIVO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_INICIO_GRUPO_PRODUTIVOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_INICIO_GRUPO_PRODUTIVO"] = value; //06
                      whereClauses.Add($" FPR_INICIO_GRUPO_PRODUTIVO = @FPR_INICIO_GRUPO_PRODUTIVO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_FIM_GRUPO_PRODUTIVOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_FIM_GRUPO_PRODUTIVO"] = value; //06
                      whereClauses.Add($" FPR_FIM_GRUPO_PRODUTIVO = @FPR_FIM_GRUPO_PRODUTIVO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_COR_BICO1Query(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_COR_BICO1"] = value; //06
                      whereClauses.Add($" FPR_COR_BICO1 = @FPR_COR_BICO1 ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_COR_BICO2Query(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_COR_BICO2"] = value; //06
                      whereClauses.Add($" FPR_COR_BICO2 = @FPR_COR_BICO2 ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_COR_BICO3Query(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_COR_BICO3"] = value; //06
                      whereClauses.Add($" FPR_COR_BICO3 = @FPR_COR_BICO3 ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_COR_BICO4Query(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_COR_BICO4"] = value; //06
                      whereClauses.Add($" FPR_COR_BICO4 = @FPR_COR_BICO4 ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_COR_BICO5Query(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_COR_BICO5"] = value; //06
                      whereClauses.Add($" FPR_COR_BICO5 = @FPR_COR_BICO5 ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_META_SETUPQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_META_SETUP"] = value; //06
                      whereClauses.Add($" FPR_META_SETUP = @FPR_META_SETUP ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_ORD_ID_REPROGRAMADOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_ORD_ID_REPROGRAMADO"] = value; //06
                      whereClauses.Add($" FPR_ORD_ID_REPROGRAMADO = @FPR_ORD_ID_REPROGRAMADO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_PRIORIDADEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_PRIORIDADE"] = value; //06
                      whereClauses.Add($" FPR_PRIORIDADE = @FPR_PRIORIDADE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_SEQ_INCLUSAO_FILAQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_SEQ_INCLUSAO_FILA"] = value; //06
                      whereClauses.Add($" FPR_SEQ_INCLUSAO_FILA = @FPR_SEQ_INCLUSAO_FILA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_HIERARQUIA_SEQ_TRANSFORMACAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_HIERARQUIA_SEQ_TRANSFORMACAO"] = value; //06
                      whereClauses.Add($" FPR_HIERARQUIA_SEQ_TRANSFORMACAO = @FPR_HIERARQUIA_SEQ_TRANSFORMACAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_ID_ORIGEMQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_ID_ORIGEM"] = value; //06
                      whereClauses.Add($" FPR_ID_ORIGEM = @FPR_ID_ORIGEM ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_DATA_ENTREGAQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_DATA_ENTREGA"] = value; //06
                      whereClauses.Add($" FPR_DATA_ENTREGA = @FPR_DATA_ENTREGA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByEQU_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["EQU_ID"] = value; //06
                      whereClauses.Add($" EQU_ID = @EQU_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_GRUPO_PRODUTIVO_MANUALQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_GRUPO_PRODUTIVO_MANUAL"] = value; //06
                      whereClauses.Add($" FPR_GRUPO_PRODUTIVO_MANUAL = @FPR_GRUPO_PRODUTIVO_MANUAL ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_EMISSAOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_EMISSAO"] = value; //06
                      whereClauses.Add($" FPR_EMISSAO = @FPR_EMISSAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_MOTIVO_PULA_FILAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_MOTIVO_PULA_FILA"] = value; //06
                      whereClauses.Add($" FPR_MOTIVO_PULA_FILA = @FPR_MOTIVO_PULA_FILA ");//06
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
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
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
        public QueryModel FirstByFPR_TOLERANCIA_MENOSQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_TOLERANCIA_MENOS"] = value; //06
                      whereClauses.Add($" FPR_TOLERANCIA_MENOS = @FPR_TOLERANCIA_MENOS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_TOLERANCIA_MAISQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_TOLERANCIA_MAIS"] = value; //06
                      whereClauses.Add($" FPR_TOLERANCIA_MAIS = @FPR_TOLERANCIA_MAIS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_DATA_ENCERRAMENTOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FPR_DATA_ENCERRAMENTO"] = value; //06
                      whereClauses.Add($" FPR_DATA_ENCERRAMENTO = @FPR_DATA_ENCERRAMENTO ");//06
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
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
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
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
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
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
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
            this.Query = $"SELECT Id, ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_ID, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_TOLERANCIA_MENOS, FPR_TOLERANCIA_MAIS, FPR_DATA_ENCERRAMENTO, TenantID, Deleted, Changed, UserId FROM FilaProducao ";
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