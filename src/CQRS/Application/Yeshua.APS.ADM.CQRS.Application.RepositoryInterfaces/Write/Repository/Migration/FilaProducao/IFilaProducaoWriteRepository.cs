// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration
// </yeshua>

using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IFilaProducaoWriteRepository
    {
        void Insert(IFilaProducaoEntity filaproducao);
        void Update(IFilaProducaoEntity filaproducao);
        void Delete(IFilaProducaoEntity filaproducao);
        void UpdateORD_ID(int id, string value);
        void UpdateROT_PRO_ID(int id, string value);
        void UpdateFPR_QUANTIDADE_PREVISTA(int id, Decimal value);
        void UpdateROT_MAQ_ID(int id, string value);
        void UpdateFPR_DATA_INICIO_PREVISTA(int id, DateTime value);
        void UpdateFPR_DATA_FIM_PREVISTA(int id, DateTime value);
        void UpdateFPR_DATA_FIM_MAXIMA(int id, DateTime value);
        void UpdateROT_SEQ_TRANFORMACAO(int id, int value);
        void UpdateFPR_SEQ_REPETICAO(int id, int value);
        void UpdateFPR_OBS_PRODUCAO(int id, string value);
        void UpdateFPR_STATUS(int id, string value);
        void UpdateFPR_TEMPO_DECORRIDO_SETUP(int id, Decimal value);
        void UpdateFPR_TEMPO_DECORRIDO_SETUPA(int id, Decimal value);
        void UpdateFPR_TEMPO_DECORRIDO_PERFORMANC(int id, Decimal value);
        void UpdateFPR_TEMPO_DECO_PEQUENA_PARADA(int id, Decimal value);
        void UpdateFPR_QTD_PERFORMANCE(int id, Decimal value);
        void UpdateFPR_QTD_SETUP(int id, Decimal value);
        void UpdateFPR_QTD_PRODUZIDA(int id, Decimal value);
        void UpdateFPR_TEMPO_TEORICO_PERFORMANCE(int id, Decimal value);
        void UpdateFPR_TEMPO_RESTANTE_PERFORMANC(int id, Decimal value);
        void UpdateFPR_VELOCIDADE_P_ATINGIR_META(int id, Decimal value);
        void UpdateFPR_QTD_RESTANTE(int id, Decimal value);
        void UpdateFPR_VELO_ATU_PC_SEGUNDO(int id, Decimal value);
        void UpdateFPR_PERFORMANCE_PROJETADA(int id, Decimal value);
        void UpdateFPR_TEMPO_RESTANTE_TOTAL(int id, Decimal value);
        void UpdateFPR_FIM_PREVISTO_ATUAL(int id, DateTime value);
        void UpdateFPR_PRODUZINDO(int id, int value);
        void UpdateFPR_ORDEM_NA_FILA(int id, Decimal value);
        void UpdateFPR_ID_INTEGRACAO(int id, string value);
        void UpdateFPR_TRUNCADO(int id, string value);
        void UpdateFPR_DATA_TRUNC_INI(int id, DateTime value);
        void UpdateFPR_DATA_TRUNC_FIM(int id, DateTime value);
        void UpdateFPR_ID(int id, int value);
        void UpdateFPR_COR_FILA(int id, string value);
        void UpdateMAQ_ID_MANUAL(int id, string value);
        void UpdateMAQ_ID_RESTRINGIDA(int id, string value);
        void UpdateFPR_PREVISAO_MATERIA_PRIMA(int id, DateTime value);
        void UpdateFPR_DATA_NECESSIDADE_INICIO_PRODUCAO(int id, DateTime value);
        void UpdateFPR_DATA_NECESSIDADE_FIM_PRODUCAO(int id, DateTime value);
        void UpdateFPR_GRUPO_PRODUTIVO(int id, Decimal value);
        void UpdateFPR_INICIO_GRUPO_PRODUTIVO(int id, DateTime value);
        void UpdateFPR_FIM_GRUPO_PRODUTIVO(int id, DateTime value);
        void UpdateFPR_COR_BICO1(int id, string value);
        void UpdateFPR_COR_BICO2(int id, string value);
        void UpdateFPR_COR_BICO3(int id, string value);
        void UpdateFPR_COR_BICO4(int id, string value);
        void UpdateFPR_COR_BICO5(int id, string value);
        void UpdateFPR_META_SETUP(int id, Decimal value);
        void UpdateFPR_ORD_ID_REPROGRAMADO(int id, string value);
        void UpdateFPR_PRIORIDADE(int id, int value);
        void UpdateFPR_SEQ_INCLUSAO_FILA(int id, int value);
        void UpdateFPR_HIERARQUIA_SEQ_TRANSFORMACAO(int id, int value);
        void UpdateFPR_ID_ORIGEM(int id, int value);
        void UpdateFPR_DATA_ENTREGA(int id, DateTime value);
        void UpdateEQU_ID(int id, string value);
        void UpdateFPR_GRUPO_PRODUTIVO_MANUAL(int id, Decimal value);
        void UpdateFPR_EMISSAO(int id, DateTime value);
        void UpdateFPR_MOTIVO_PULA_FILA(int id, string value);
        void UpdateOCO_ID(int id, string value);
        void UpdateFPR_TOLERANCIA_MENOS(int id, Decimal value);
        void UpdateFPR_TOLERANCIA_MAIS(int id, Decimal value);
        void UpdateFPR_DATA_ENCERRAMENTO(int id, DateTime value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration