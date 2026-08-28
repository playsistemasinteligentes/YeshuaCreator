// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration
// </yeshua>

using Dominio.Entitys;
using Shered.DB;
using Command.Write;
using IQuery.Write;
using Aplication.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Write
{
    public class FilaProducaoPrevistaQueryWrite : QueryBase, IFilaProducaoPrevistaQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public FilaProducaoPrevistaQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirFilaProducaoPrevistaQuery(IFilaProducaoPrevistaEntity FilaProducaoPrevista)
        {
            this.Query = $@" INSERT INTO FilaProducaoPrevista (ORD_ID, ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO, FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE, FPR_QTD_SETUP, FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO, FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO, FPR_TRUNCADO, FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM, FPR_COR_FILA, MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1, FPR_COR_BICO2, FPR_COR_BICO3, FPR_COR_BICO4, FPR_COR_BICO5, FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM, FPR_DATA_ENTREGA, EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO, FPR_MOTIVO_PULA_FILA, OCO_ID, FPR_PESO_UNITARIO, FPR_M2_UNITARIO, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@ORD_ID, @ROT_PRO_ID, @FPR_QUANTIDADE_PREVISTA, @ROT_MAQ_ID, @FPR_DATA_INICIO_PREVISTA, @FPR_DATA_FIM_PREVISTA, @FPR_DATA_FIM_MAXIMA, @ROT_SEQ_TRANFORMACAO, @FPR_SEQ_REPETICAO, @FPR_OBS_PRODUCAO, @FPR_STATUS, @FPR_TEMPO_DECORRIDO_SETUP, @FPR_TEMPO_DECORRIDO_SETUPA, @FPR_TEMPO_DECORRIDO_PERFORMANC, @FPR_TEMPO_DECO_PEQUENA_PARADA, @FPR_QTD_PERFORMANCE, @FPR_QTD_SETUP, @FPR_QTD_PRODUZIDA, @FPR_TEMPO_TEORICO_PERFORMANCE, @FPR_TEMPO_RESTANTE_PERFORMANC, @FPR_VELOCIDADE_P_ATINGIR_META, @FPR_QTD_RESTANTE, @FPR_VELO_ATU_PC_SEGUNDO, @FPR_PERFORMANCE_PROJETADA, @FPR_TEMPO_RESTANTE_TOTAL, @FPR_FIM_PREVISTO_ATUAL, @FPR_PRODUZINDO, @FPR_ORDEM_NA_FILA, @FPR_ID_INTEGRACAO, @FPR_TRUNCADO, @FPR_DATA_TRUNC_INI, @FPR_DATA_TRUNC_FIM, @FPR_COR_FILA, @MAQ_ID_MANUAL, @MAQ_ID_RESTRINGIDA, @FPR_PREVISAO_MATERIA_PRIMA, @FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, @FPR_DATA_NECESSIDADE_FIM_PRODUCAO, @FPR_GRUPO_PRODUTIVO, @FPR_INICIO_GRUPO_PRODUTIVO, @FPR_FIM_GRUPO_PRODUTIVO, @FPR_COR_BICO1, @FPR_COR_BICO2, @FPR_COR_BICO3, @FPR_COR_BICO4, @FPR_COR_BICO5, @FPR_META_SETUP, @FPR_ORD_ID_REPROGRAMADO, @FPR_PRIORIDADE, @FPR_SEQ_INCLUSAO_FILA, @FPR_HIERARQUIA_SEQ_TRANSFORMACAO, @FPR_ID_ORIGEM, @FPR_DATA_ENTREGA, @EQU_ID, @FPR_GRUPO_PRODUTIVO_MANUAL, @FPR_EMISSAO, @FPR_MOTIVO_PULA_FILA, @OCO_ID, @FPR_PESO_UNITARIO, @FPR_M2_UNITARIO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                ORD_ID = FilaProducaoPrevista.ORD_ID,
                ROT_PRO_ID = FilaProducaoPrevista.ROT_PRO_ID,
                FPR_QUANTIDADE_PREVISTA = FilaProducaoPrevista.FPR_QUANTIDADE_PREVISTA,
                ROT_MAQ_ID = FilaProducaoPrevista.ROT_MAQ_ID,
                FPR_DATA_INICIO_PREVISTA = FilaProducaoPrevista.FPR_DATA_INICIO_PREVISTA,
                FPR_DATA_FIM_PREVISTA = FilaProducaoPrevista.FPR_DATA_FIM_PREVISTA,
                FPR_DATA_FIM_MAXIMA = FilaProducaoPrevista.FPR_DATA_FIM_MAXIMA,
                ROT_SEQ_TRANFORMACAO = FilaProducaoPrevista.ROT_SEQ_TRANFORMACAO,
                FPR_SEQ_REPETICAO = FilaProducaoPrevista.FPR_SEQ_REPETICAO,
                FPR_OBS_PRODUCAO = FilaProducaoPrevista.FPR_OBS_PRODUCAO,
                FPR_STATUS = FilaProducaoPrevista.FPR_STATUS,
                FPR_TEMPO_DECORRIDO_SETUP = FilaProducaoPrevista.FPR_TEMPO_DECORRIDO_SETUP,
                FPR_TEMPO_DECORRIDO_SETUPA = FilaProducaoPrevista.FPR_TEMPO_DECORRIDO_SETUPA,
                FPR_TEMPO_DECORRIDO_PERFORMANC = FilaProducaoPrevista.FPR_TEMPO_DECORRIDO_PERFORMANC,
                FPR_TEMPO_DECO_PEQUENA_PARADA = FilaProducaoPrevista.FPR_TEMPO_DECO_PEQUENA_PARADA,
                FPR_QTD_PERFORMANCE = FilaProducaoPrevista.FPR_QTD_PERFORMANCE,
                FPR_QTD_SETUP = FilaProducaoPrevista.FPR_QTD_SETUP,
                FPR_QTD_PRODUZIDA = FilaProducaoPrevista.FPR_QTD_PRODUZIDA,
                FPR_TEMPO_TEORICO_PERFORMANCE = FilaProducaoPrevista.FPR_TEMPO_TEORICO_PERFORMANCE,
                FPR_TEMPO_RESTANTE_PERFORMANC = FilaProducaoPrevista.FPR_TEMPO_RESTANTE_PERFORMANC,
                FPR_VELOCIDADE_P_ATINGIR_META = FilaProducaoPrevista.FPR_VELOCIDADE_P_ATINGIR_META,
                FPR_QTD_RESTANTE = FilaProducaoPrevista.FPR_QTD_RESTANTE,
                FPR_VELO_ATU_PC_SEGUNDO = FilaProducaoPrevista.FPR_VELO_ATU_PC_SEGUNDO,
                FPR_PERFORMANCE_PROJETADA = FilaProducaoPrevista.FPR_PERFORMANCE_PROJETADA,
                FPR_TEMPO_RESTANTE_TOTAL = FilaProducaoPrevista.FPR_TEMPO_RESTANTE_TOTAL,
                FPR_FIM_PREVISTO_ATUAL = FilaProducaoPrevista.FPR_FIM_PREVISTO_ATUAL,
                FPR_PRODUZINDO = FilaProducaoPrevista.FPR_PRODUZINDO,
                FPR_ORDEM_NA_FILA = FilaProducaoPrevista.FPR_ORDEM_NA_FILA,
                FPR_ID_INTEGRACAO = FilaProducaoPrevista.FPR_ID_INTEGRACAO,
                FPR_TRUNCADO = FilaProducaoPrevista.FPR_TRUNCADO,
                FPR_DATA_TRUNC_INI = FilaProducaoPrevista.FPR_DATA_TRUNC_INI,
                FPR_DATA_TRUNC_FIM = FilaProducaoPrevista.FPR_DATA_TRUNC_FIM,
                FPR_COR_FILA = FilaProducaoPrevista.FPR_COR_FILA,
                MAQ_ID_MANUAL = FilaProducaoPrevista.MAQ_ID_MANUAL,
                MAQ_ID_RESTRINGIDA = FilaProducaoPrevista.MAQ_ID_RESTRINGIDA,
                FPR_PREVISAO_MATERIA_PRIMA = FilaProducaoPrevista.FPR_PREVISAO_MATERIA_PRIMA,
                FPR_DATA_NECESSIDADE_INICIO_PRODUCAO = FilaProducaoPrevista.FPR_DATA_NECESSIDADE_INICIO_PRODUCAO,
                FPR_DATA_NECESSIDADE_FIM_PRODUCAO = FilaProducaoPrevista.FPR_DATA_NECESSIDADE_FIM_PRODUCAO,
                FPR_GRUPO_PRODUTIVO = FilaProducaoPrevista.FPR_GRUPO_PRODUTIVO,
                FPR_INICIO_GRUPO_PRODUTIVO = FilaProducaoPrevista.FPR_INICIO_GRUPO_PRODUTIVO,
                FPR_FIM_GRUPO_PRODUTIVO = FilaProducaoPrevista.FPR_FIM_GRUPO_PRODUTIVO,
                FPR_COR_BICO1 = FilaProducaoPrevista.FPR_COR_BICO1,
                FPR_COR_BICO2 = FilaProducaoPrevista.FPR_COR_BICO2,
                FPR_COR_BICO3 = FilaProducaoPrevista.FPR_COR_BICO3,
                FPR_COR_BICO4 = FilaProducaoPrevista.FPR_COR_BICO4,
                FPR_COR_BICO5 = FilaProducaoPrevista.FPR_COR_BICO5,
                FPR_META_SETUP = FilaProducaoPrevista.FPR_META_SETUP,
                FPR_ORD_ID_REPROGRAMADO = FilaProducaoPrevista.FPR_ORD_ID_REPROGRAMADO,
                FPR_PRIORIDADE = FilaProducaoPrevista.FPR_PRIORIDADE,
                FPR_SEQ_INCLUSAO_FILA = FilaProducaoPrevista.FPR_SEQ_INCLUSAO_FILA,
                FPR_HIERARQUIA_SEQ_TRANSFORMACAO = FilaProducaoPrevista.FPR_HIERARQUIA_SEQ_TRANSFORMACAO,
                FPR_ID_ORIGEM = FilaProducaoPrevista.FPR_ID_ORIGEM,
                FPR_DATA_ENTREGA = FilaProducaoPrevista.FPR_DATA_ENTREGA,
                EQU_ID = FilaProducaoPrevista.EQU_ID,
                FPR_GRUPO_PRODUTIVO_MANUAL = FilaProducaoPrevista.FPR_GRUPO_PRODUTIVO_MANUAL,
                FPR_EMISSAO = FilaProducaoPrevista.FPR_EMISSAO,
                FPR_MOTIVO_PULA_FILA = FilaProducaoPrevista.FPR_MOTIVO_PULA_FILA,
                OCO_ID = FilaProducaoPrevista.OCO_ID,
                FPR_PESO_UNITARIO = FilaProducaoPrevista.FPR_PESO_UNITARIO,
                FPR_M2_UNITARIO = FilaProducaoPrevista.FPR_M2_UNITARIO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFilaProducaoPrevistaQuery(IFilaProducaoPrevistaEntity FilaProducaoPrevista)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET ORD_ID = @ORD_ID, ROT_PRO_ID = @ROT_PRO_ID, FPR_QUANTIDADE_PREVISTA = @FPR_QUANTIDADE_PREVISTA, ROT_MAQ_ID = @ROT_MAQ_ID, FPR_DATA_INICIO_PREVISTA = @FPR_DATA_INICIO_PREVISTA, FPR_DATA_FIM_PREVISTA = @FPR_DATA_FIM_PREVISTA, FPR_DATA_FIM_MAXIMA = @FPR_DATA_FIM_MAXIMA, ROT_SEQ_TRANFORMACAO = @ROT_SEQ_TRANFORMACAO, FPR_SEQ_REPETICAO = @FPR_SEQ_REPETICAO, FPR_OBS_PRODUCAO = @FPR_OBS_PRODUCAO, FPR_STATUS = @FPR_STATUS, FPR_TEMPO_DECORRIDO_SETUP = @FPR_TEMPO_DECORRIDO_SETUP, FPR_TEMPO_DECORRIDO_SETUPA = @FPR_TEMPO_DECORRIDO_SETUPA, FPR_TEMPO_DECORRIDO_PERFORMANC = @FPR_TEMPO_DECORRIDO_PERFORMANC, FPR_TEMPO_DECO_PEQUENA_PARADA = @FPR_TEMPO_DECO_PEQUENA_PARADA, FPR_QTD_PERFORMANCE = @FPR_QTD_PERFORMANCE, FPR_QTD_SETUP = @FPR_QTD_SETUP, FPR_QTD_PRODUZIDA = @FPR_QTD_PRODUZIDA, FPR_TEMPO_TEORICO_PERFORMANCE = @FPR_TEMPO_TEORICO_PERFORMANCE, FPR_TEMPO_RESTANTE_PERFORMANC = @FPR_TEMPO_RESTANTE_PERFORMANC, FPR_VELOCIDADE_P_ATINGIR_META = @FPR_VELOCIDADE_P_ATINGIR_META, FPR_QTD_RESTANTE = @FPR_QTD_RESTANTE, FPR_VELO_ATU_PC_SEGUNDO = @FPR_VELO_ATU_PC_SEGUNDO, FPR_PERFORMANCE_PROJETADA = @FPR_PERFORMANCE_PROJETADA, FPR_TEMPO_RESTANTE_TOTAL = @FPR_TEMPO_RESTANTE_TOTAL, FPR_FIM_PREVISTO_ATUAL = @FPR_FIM_PREVISTO_ATUAL, FPR_PRODUZINDO = @FPR_PRODUZINDO, FPR_ORDEM_NA_FILA = @FPR_ORDEM_NA_FILA, FPR_ID_INTEGRACAO = @FPR_ID_INTEGRACAO, FPR_TRUNCADO = @FPR_TRUNCADO, FPR_DATA_TRUNC_INI = @FPR_DATA_TRUNC_INI, FPR_DATA_TRUNC_FIM = @FPR_DATA_TRUNC_FIM, FPR_ID = @FPR_ID, FPR_COR_FILA = @FPR_COR_FILA, MAQ_ID_MANUAL = @MAQ_ID_MANUAL, MAQ_ID_RESTRINGIDA = @MAQ_ID_RESTRINGIDA, FPR_PREVISAO_MATERIA_PRIMA = @FPR_PREVISAO_MATERIA_PRIMA, FPR_DATA_NECESSIDADE_INICIO_PRODUCAO = @FPR_DATA_NECESSIDADE_INICIO_PRODUCAO, FPR_DATA_NECESSIDADE_FIM_PRODUCAO = @FPR_DATA_NECESSIDADE_FIM_PRODUCAO, FPR_GRUPO_PRODUTIVO = @FPR_GRUPO_PRODUTIVO, FPR_INICIO_GRUPO_PRODUTIVO = @FPR_INICIO_GRUPO_PRODUTIVO, FPR_FIM_GRUPO_PRODUTIVO = @FPR_FIM_GRUPO_PRODUTIVO, FPR_COR_BICO1 = @FPR_COR_BICO1, FPR_COR_BICO2 = @FPR_COR_BICO2, FPR_COR_BICO3 = @FPR_COR_BICO3, FPR_COR_BICO4 = @FPR_COR_BICO4, FPR_COR_BICO5 = @FPR_COR_BICO5, FPR_META_SETUP = @FPR_META_SETUP, FPR_ORD_ID_REPROGRAMADO = @FPR_ORD_ID_REPROGRAMADO, FPR_PRIORIDADE = @FPR_PRIORIDADE, FPR_SEQ_INCLUSAO_FILA = @FPR_SEQ_INCLUSAO_FILA, FPR_HIERARQUIA_SEQ_TRANSFORMACAO = @FPR_HIERARQUIA_SEQ_TRANSFORMACAO, FPR_ID_ORIGEM = @FPR_ID_ORIGEM, FPR_DATA_ENTREGA = @FPR_DATA_ENTREGA, EQU_ID = @EQU_ID, FPR_GRUPO_PRODUTIVO_MANUAL = @FPR_GRUPO_PRODUTIVO_MANUAL, FPR_EMISSAO = @FPR_EMISSAO, FPR_MOTIVO_PULA_FILA = @FPR_MOTIVO_PULA_FILA, OCO_ID = @OCO_ID, FPR_PESO_UNITARIO = @FPR_PESO_UNITARIO, FPR_M2_UNITARIO = @FPR_M2_UNITARIO, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                ORD_ID = FilaProducaoPrevista.ORD_ID,
                ROT_PRO_ID = FilaProducaoPrevista.ROT_PRO_ID,
                FPR_QUANTIDADE_PREVISTA = FilaProducaoPrevista.FPR_QUANTIDADE_PREVISTA,
                ROT_MAQ_ID = FilaProducaoPrevista.ROT_MAQ_ID,
                FPR_DATA_INICIO_PREVISTA = FilaProducaoPrevista.FPR_DATA_INICIO_PREVISTA,
                FPR_DATA_FIM_PREVISTA = FilaProducaoPrevista.FPR_DATA_FIM_PREVISTA,
                FPR_DATA_FIM_MAXIMA = FilaProducaoPrevista.FPR_DATA_FIM_MAXIMA,
                ROT_SEQ_TRANFORMACAO = FilaProducaoPrevista.ROT_SEQ_TRANFORMACAO,
                FPR_SEQ_REPETICAO = FilaProducaoPrevista.FPR_SEQ_REPETICAO,
                FPR_OBS_PRODUCAO = FilaProducaoPrevista.FPR_OBS_PRODUCAO,
                FPR_STATUS = FilaProducaoPrevista.FPR_STATUS,
                FPR_TEMPO_DECORRIDO_SETUP = FilaProducaoPrevista.FPR_TEMPO_DECORRIDO_SETUP,
                FPR_TEMPO_DECORRIDO_SETUPA = FilaProducaoPrevista.FPR_TEMPO_DECORRIDO_SETUPA,
                FPR_TEMPO_DECORRIDO_PERFORMANC = FilaProducaoPrevista.FPR_TEMPO_DECORRIDO_PERFORMANC,
                FPR_TEMPO_DECO_PEQUENA_PARADA = FilaProducaoPrevista.FPR_TEMPO_DECO_PEQUENA_PARADA,
                FPR_QTD_PERFORMANCE = FilaProducaoPrevista.FPR_QTD_PERFORMANCE,
                FPR_QTD_SETUP = FilaProducaoPrevista.FPR_QTD_SETUP,
                FPR_QTD_PRODUZIDA = FilaProducaoPrevista.FPR_QTD_PRODUZIDA,
                FPR_TEMPO_TEORICO_PERFORMANCE = FilaProducaoPrevista.FPR_TEMPO_TEORICO_PERFORMANCE,
                FPR_TEMPO_RESTANTE_PERFORMANC = FilaProducaoPrevista.FPR_TEMPO_RESTANTE_PERFORMANC,
                FPR_VELOCIDADE_P_ATINGIR_META = FilaProducaoPrevista.FPR_VELOCIDADE_P_ATINGIR_META,
                FPR_QTD_RESTANTE = FilaProducaoPrevista.FPR_QTD_RESTANTE,
                FPR_VELO_ATU_PC_SEGUNDO = FilaProducaoPrevista.FPR_VELO_ATU_PC_SEGUNDO,
                FPR_PERFORMANCE_PROJETADA = FilaProducaoPrevista.FPR_PERFORMANCE_PROJETADA,
                FPR_TEMPO_RESTANTE_TOTAL = FilaProducaoPrevista.FPR_TEMPO_RESTANTE_TOTAL,
                FPR_FIM_PREVISTO_ATUAL = FilaProducaoPrevista.FPR_FIM_PREVISTO_ATUAL,
                FPR_PRODUZINDO = FilaProducaoPrevista.FPR_PRODUZINDO,
                FPR_ORDEM_NA_FILA = FilaProducaoPrevista.FPR_ORDEM_NA_FILA,
                FPR_ID_INTEGRACAO = FilaProducaoPrevista.FPR_ID_INTEGRACAO,
                FPR_TRUNCADO = FilaProducaoPrevista.FPR_TRUNCADO,
                FPR_DATA_TRUNC_INI = FilaProducaoPrevista.FPR_DATA_TRUNC_INI,
                FPR_DATA_TRUNC_FIM = FilaProducaoPrevista.FPR_DATA_TRUNC_FIM,
                FPR_ID = FilaProducaoPrevista.FPR_ID,
                FPR_COR_FILA = FilaProducaoPrevista.FPR_COR_FILA,
                MAQ_ID_MANUAL = FilaProducaoPrevista.MAQ_ID_MANUAL,
                MAQ_ID_RESTRINGIDA = FilaProducaoPrevista.MAQ_ID_RESTRINGIDA,
                FPR_PREVISAO_MATERIA_PRIMA = FilaProducaoPrevista.FPR_PREVISAO_MATERIA_PRIMA,
                FPR_DATA_NECESSIDADE_INICIO_PRODUCAO = FilaProducaoPrevista.FPR_DATA_NECESSIDADE_INICIO_PRODUCAO,
                FPR_DATA_NECESSIDADE_FIM_PRODUCAO = FilaProducaoPrevista.FPR_DATA_NECESSIDADE_FIM_PRODUCAO,
                FPR_GRUPO_PRODUTIVO = FilaProducaoPrevista.FPR_GRUPO_PRODUTIVO,
                FPR_INICIO_GRUPO_PRODUTIVO = FilaProducaoPrevista.FPR_INICIO_GRUPO_PRODUTIVO,
                FPR_FIM_GRUPO_PRODUTIVO = FilaProducaoPrevista.FPR_FIM_GRUPO_PRODUTIVO,
                FPR_COR_BICO1 = FilaProducaoPrevista.FPR_COR_BICO1,
                FPR_COR_BICO2 = FilaProducaoPrevista.FPR_COR_BICO2,
                FPR_COR_BICO3 = FilaProducaoPrevista.FPR_COR_BICO3,
                FPR_COR_BICO4 = FilaProducaoPrevista.FPR_COR_BICO4,
                FPR_COR_BICO5 = FilaProducaoPrevista.FPR_COR_BICO5,
                FPR_META_SETUP = FilaProducaoPrevista.FPR_META_SETUP,
                FPR_ORD_ID_REPROGRAMADO = FilaProducaoPrevista.FPR_ORD_ID_REPROGRAMADO,
                FPR_PRIORIDADE = FilaProducaoPrevista.FPR_PRIORIDADE,
                FPR_SEQ_INCLUSAO_FILA = FilaProducaoPrevista.FPR_SEQ_INCLUSAO_FILA,
                FPR_HIERARQUIA_SEQ_TRANSFORMACAO = FilaProducaoPrevista.FPR_HIERARQUIA_SEQ_TRANSFORMACAO,
                FPR_ID_ORIGEM = FilaProducaoPrevista.FPR_ID_ORIGEM,
                FPR_DATA_ENTREGA = FilaProducaoPrevista.FPR_DATA_ENTREGA,
                EQU_ID = FilaProducaoPrevista.EQU_ID,
                FPR_GRUPO_PRODUTIVO_MANUAL = FilaProducaoPrevista.FPR_GRUPO_PRODUTIVO_MANUAL,
                FPR_EMISSAO = FilaProducaoPrevista.FPR_EMISSAO,
                FPR_MOTIVO_PULA_FILA = FilaProducaoPrevista.FPR_MOTIVO_PULA_FILA,
                OCO_ID = FilaProducaoPrevista.OCO_ID,
                FPR_PESO_UNITARIO = FilaProducaoPrevista.FPR_PESO_UNITARIO,
                FPR_M2_UNITARIO = FilaProducaoPrevista.FPR_M2_UNITARIO,
                Changed = FilaProducaoPrevista.Changed,
                UserId = _executionContext.UserId,
                Id = FilaProducaoPrevista.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_ID(int id, string value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET ORD_ID = @ORD_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                ORD_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateROT_PRO_ID(int id, string value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET ROT_PRO_ID = @ROT_PRO_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                ROT_PRO_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_QUANTIDADE_PREVISTA(int id, Decimal value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_QUANTIDADE_PREVISTA = @FPR_QUANTIDADE_PREVISTA WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_QUANTIDADE_PREVISTA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateROT_MAQ_ID(int id, string value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET ROT_MAQ_ID = @ROT_MAQ_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                ROT_MAQ_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_DATA_INICIO_PREVISTA(int id, DateTime value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_DATA_INICIO_PREVISTA = @FPR_DATA_INICIO_PREVISTA WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_DATA_INICIO_PREVISTA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_DATA_FIM_PREVISTA(int id, DateTime value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_DATA_FIM_PREVISTA = @FPR_DATA_FIM_PREVISTA WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_DATA_FIM_PREVISTA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_DATA_FIM_MAXIMA(int id, DateTime value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_DATA_FIM_MAXIMA = @FPR_DATA_FIM_MAXIMA WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_DATA_FIM_MAXIMA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateROT_SEQ_TRANFORMACAO(int id, int value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET ROT_SEQ_TRANFORMACAO = @ROT_SEQ_TRANFORMACAO WHERE Id = @Id ";
            this.Parameters = new
            {
                ROT_SEQ_TRANFORMACAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_SEQ_REPETICAO(int id, int value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_SEQ_REPETICAO = @FPR_SEQ_REPETICAO WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_SEQ_REPETICAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_OBS_PRODUCAO(int id, string value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_OBS_PRODUCAO = @FPR_OBS_PRODUCAO WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_OBS_PRODUCAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_STATUS(int id, string value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_STATUS = @FPR_STATUS WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_STATUS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_TEMPO_DECORRIDO_SETUP(int id, Decimal value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_TEMPO_DECORRIDO_SETUP = @FPR_TEMPO_DECORRIDO_SETUP WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_TEMPO_DECORRIDO_SETUP = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_TEMPO_DECORRIDO_SETUPA(int id, Decimal value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_TEMPO_DECORRIDO_SETUPA = @FPR_TEMPO_DECORRIDO_SETUPA WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_TEMPO_DECORRIDO_SETUPA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_TEMPO_DECORRIDO_PERFORMANC(int id, Decimal value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_TEMPO_DECORRIDO_PERFORMANC = @FPR_TEMPO_DECORRIDO_PERFORMANC WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_TEMPO_DECORRIDO_PERFORMANC = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_TEMPO_DECO_PEQUENA_PARADA(int id, Decimal value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_TEMPO_DECO_PEQUENA_PARADA = @FPR_TEMPO_DECO_PEQUENA_PARADA WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_TEMPO_DECO_PEQUENA_PARADA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_QTD_PERFORMANCE(int id, Decimal value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_QTD_PERFORMANCE = @FPR_QTD_PERFORMANCE WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_QTD_PERFORMANCE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_QTD_SETUP(int id, Decimal value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_QTD_SETUP = @FPR_QTD_SETUP WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_QTD_SETUP = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_QTD_PRODUZIDA(int id, Decimal value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_QTD_PRODUZIDA = @FPR_QTD_PRODUZIDA WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_QTD_PRODUZIDA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_TEMPO_TEORICO_PERFORMANCE(int id, Decimal value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_TEMPO_TEORICO_PERFORMANCE = @FPR_TEMPO_TEORICO_PERFORMANCE WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_TEMPO_TEORICO_PERFORMANCE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_TEMPO_RESTANTE_PERFORMANC(int id, Decimal value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_TEMPO_RESTANTE_PERFORMANC = @FPR_TEMPO_RESTANTE_PERFORMANC WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_TEMPO_RESTANTE_PERFORMANC = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_VELOCIDADE_P_ATINGIR_META(int id, Decimal value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_VELOCIDADE_P_ATINGIR_META = @FPR_VELOCIDADE_P_ATINGIR_META WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_VELOCIDADE_P_ATINGIR_META = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_QTD_RESTANTE(int id, Decimal value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_QTD_RESTANTE = @FPR_QTD_RESTANTE WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_QTD_RESTANTE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_VELO_ATU_PC_SEGUNDO(int id, Decimal value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_VELO_ATU_PC_SEGUNDO = @FPR_VELO_ATU_PC_SEGUNDO WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_VELO_ATU_PC_SEGUNDO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_PERFORMANCE_PROJETADA(int id, Decimal value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_PERFORMANCE_PROJETADA = @FPR_PERFORMANCE_PROJETADA WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_PERFORMANCE_PROJETADA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_TEMPO_RESTANTE_TOTAL(int id, Decimal value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_TEMPO_RESTANTE_TOTAL = @FPR_TEMPO_RESTANTE_TOTAL WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_TEMPO_RESTANTE_TOTAL = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_FIM_PREVISTO_ATUAL(int id, DateTime value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_FIM_PREVISTO_ATUAL = @FPR_FIM_PREVISTO_ATUAL WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_FIM_PREVISTO_ATUAL = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_PRODUZINDO(int id, int value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_PRODUZINDO = @FPR_PRODUZINDO WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_PRODUZINDO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_ORDEM_NA_FILA(int id, Decimal value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_ORDEM_NA_FILA = @FPR_ORDEM_NA_FILA WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_ORDEM_NA_FILA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_ID_INTEGRACAO(int id, string value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_ID_INTEGRACAO = @FPR_ID_INTEGRACAO WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_ID_INTEGRACAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_TRUNCADO(int id, string value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_TRUNCADO = @FPR_TRUNCADO WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_TRUNCADO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_DATA_TRUNC_INI(int id, DateTime value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_DATA_TRUNC_INI = @FPR_DATA_TRUNC_INI WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_DATA_TRUNC_INI = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_DATA_TRUNC_FIM(int id, DateTime value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_DATA_TRUNC_FIM = @FPR_DATA_TRUNC_FIM WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_DATA_TRUNC_FIM = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_ID(int id, int value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_ID = @FPR_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_COR_FILA(int id, string value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_COR_FILA = @FPR_COR_FILA WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_COR_FILA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_ID_MANUAL(int id, string value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET MAQ_ID_MANUAL = @MAQ_ID_MANUAL WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_ID_MANUAL = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_ID_RESTRINGIDA(int id, string value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET MAQ_ID_RESTRINGIDA = @MAQ_ID_RESTRINGIDA WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_ID_RESTRINGIDA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_PREVISAO_MATERIA_PRIMA(int id, DateTime value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_PREVISAO_MATERIA_PRIMA = @FPR_PREVISAO_MATERIA_PRIMA WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_PREVISAO_MATERIA_PRIMA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_DATA_NECESSIDADE_INICIO_PRODUCAO(int id, DateTime value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_DATA_NECESSIDADE_INICIO_PRODUCAO = @FPR_DATA_NECESSIDADE_INICIO_PRODUCAO WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_DATA_NECESSIDADE_INICIO_PRODUCAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_DATA_NECESSIDADE_FIM_PRODUCAO(int id, DateTime value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_DATA_NECESSIDADE_FIM_PRODUCAO = @FPR_DATA_NECESSIDADE_FIM_PRODUCAO WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_DATA_NECESSIDADE_FIM_PRODUCAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_GRUPO_PRODUTIVO(int id, Decimal value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_GRUPO_PRODUTIVO = @FPR_GRUPO_PRODUTIVO WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_GRUPO_PRODUTIVO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_INICIO_GRUPO_PRODUTIVO(int id, DateTime value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_INICIO_GRUPO_PRODUTIVO = @FPR_INICIO_GRUPO_PRODUTIVO WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_INICIO_GRUPO_PRODUTIVO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_FIM_GRUPO_PRODUTIVO(int id, DateTime value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_FIM_GRUPO_PRODUTIVO = @FPR_FIM_GRUPO_PRODUTIVO WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_FIM_GRUPO_PRODUTIVO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_COR_BICO1(int id, string value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_COR_BICO1 = @FPR_COR_BICO1 WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_COR_BICO1 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_COR_BICO2(int id, string value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_COR_BICO2 = @FPR_COR_BICO2 WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_COR_BICO2 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_COR_BICO3(int id, string value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_COR_BICO3 = @FPR_COR_BICO3 WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_COR_BICO3 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_COR_BICO4(int id, string value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_COR_BICO4 = @FPR_COR_BICO4 WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_COR_BICO4 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_COR_BICO5(int id, string value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_COR_BICO5 = @FPR_COR_BICO5 WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_COR_BICO5 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_META_SETUP(int id, Decimal value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_META_SETUP = @FPR_META_SETUP WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_META_SETUP = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_ORD_ID_REPROGRAMADO(int id, string value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_ORD_ID_REPROGRAMADO = @FPR_ORD_ID_REPROGRAMADO WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_ORD_ID_REPROGRAMADO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_PRIORIDADE(int id, int value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_PRIORIDADE = @FPR_PRIORIDADE WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_PRIORIDADE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_SEQ_INCLUSAO_FILA(int id, int value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_SEQ_INCLUSAO_FILA = @FPR_SEQ_INCLUSAO_FILA WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_SEQ_INCLUSAO_FILA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_HIERARQUIA_SEQ_TRANSFORMACAO(int id, int value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_HIERARQUIA_SEQ_TRANSFORMACAO = @FPR_HIERARQUIA_SEQ_TRANSFORMACAO WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_HIERARQUIA_SEQ_TRANSFORMACAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_ID_ORIGEM(int id, int value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_ID_ORIGEM = @FPR_ID_ORIGEM WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_ID_ORIGEM = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_DATA_ENTREGA(int id, DateTime value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_DATA_ENTREGA = @FPR_DATA_ENTREGA WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_DATA_ENTREGA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEQU_ID(int id, string value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET EQU_ID = @EQU_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                EQU_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_GRUPO_PRODUTIVO_MANUAL(int id, Decimal value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_GRUPO_PRODUTIVO_MANUAL = @FPR_GRUPO_PRODUTIVO_MANUAL WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_GRUPO_PRODUTIVO_MANUAL = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_EMISSAO(int id, DateTime value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_EMISSAO = @FPR_EMISSAO WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_EMISSAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_MOTIVO_PULA_FILA(int id, string value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_MOTIVO_PULA_FILA = @FPR_MOTIVO_PULA_FILA WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_MOTIVO_PULA_FILA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOCO_ID(int id, string value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET OCO_ID = @OCO_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                OCO_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_PESO_UNITARIO(int id, string value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_PESO_UNITARIO = @FPR_PESO_UNITARIO WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_PESO_UNITARIO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_M2_UNITARIO(int id, string value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET FPR_M2_UNITARIO = @FPR_M2_UNITARIO WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_M2_UNITARIO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE FilaProducaoPrevista SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteFilaProducaoPrevistaQuery(IFilaProducaoPrevistaEntity FilaProducaoPrevista)
        {
            this.Query = $@" DELETE FROM FilaProducaoPrevista WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = FilaProducaoPrevista.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration