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
    public partial interface ITargetProdutoWriteRepository
    {
        void Insert(ITargetProdutoEntity targetproduto);
        void Update(ITargetProdutoEntity targetproduto);
        void Delete(ITargetProdutoEntity targetproduto);
        void UpdateMOV_ID(int tar_id, int value);
        void UpdateORD_ID(int tar_id, string value);
        void UpdatePRO_ID(int tar_id, string value);
        void UpdateMAQ_ID(int tar_id, string value);
        void UpdateUNI_ID(int tar_id, string value);
        void UpdateTURM_ID(int tar_id, string value);
        void UpdateTURN_ID(int tar_id, string value);
        void UpdateUSE_ID(int tar_id, int value);
        void UpdateTAR_DIA_TURMA(int tar_id, string value);
        void UpdateTAR_META_PERFORMANCE(int tar_id, Decimal value);
        void UpdateTAR_REALIZADO_PERFORMANCE(int tar_id, Decimal value);
        void UpdateTAR_PERCENTUAL_REALIZADO_PERFORMANCE(int tar_id, Decimal value);
        void UpdateTAR_PROXIMA_META_PERFORMANCE(int tar_id, Decimal value);
        void UpdateTAR_META_TEMPO_SETUP(int tar_id, Decimal value);
        void UpdateTAR_REALIZADO_TEMPO_SETUP(int tar_id, Decimal value);
        void UpdateTAR_PROXIMA_META_TEMPO_SETUP(int tar_id, Decimal value);
        void UpdateTAR_META_TEMPO_SETUP_AJUSTE(int tar_id, Decimal value);
        void UpdateTAR_REALIZADO_TEMPO_SETUP_AJUSTE(int tar_id, Decimal value);
        void UpdateTAR_PROXIMA_META_TEMPO_SETUP_AJUSTE(int tar_id, Decimal value);
        void UpdateOCO_ID_PERFORMANCE(int tar_id, string value);
        void UpdateTAR_OBS_PERFORMANCE(int tar_id, string value);
        void UpdateOCO_ID_SETUP(int tar_id, string value);
        void UpdateTAR_OBS_SETUP(int tar_id, string value);
        void UpdateOCO_ID_SETUPA(int tar_id, string value);
        void UpdateTAR_OBS_SETUPA(int tar_id, string value);
        void UpdateTAR_TIPO_FEEDBACK_PERFORMANCE(int tar_id, string value);
        void UpdateTAR_TIPO_FEEDBACK_SETUP(int tar_id, string value);
        void UpdateTAR_TIPO_FEEDBACK_SETUP_AJUSTE(int tar_id, string value);
        void UpdateTAR_QTD_SETUP_AJUSTE(int tar_id, Decimal value);
        void UpdateTAR_QTD(int tar_id, Decimal value);
        void UpdateTAR_PARAMETRO_TIME_WORK_STOP_MACHINE(int tar_id, int value);
        void UpdateTAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE(int tar_id, int value);
        void UpdateROT_SEQ_TRANFORMACAO(int tar_id, int value);
        void UpdateFPR_SEQ_REPETICAO(int tar_id, int value);
        void UpdateTAR_PERFORMANCE_MAX_VERDE(int tar_id, Decimal value);
        void UpdateTAR_PERFORMANCE_MIN_VERDE(int tar_id, Decimal value);
        void UpdateTAR_SETUP_MAX_VERDE(int tar_id, Decimal value);
        void UpdateTAR_SETUP_MIN_VERDE(int tar_id, Decimal value);
        void UpdateTAR_SETUPA_MAX_VERDE(int tar_id, Decimal value);
        void UpdateTAR_SETUPA_MIN_VERDE(int tar_id, Decimal value);
        void UpdateTAR_PERFORMANCE_MIN_AMARELO(int tar_id, Decimal value);
        void UpdateTAR_SETUP_MAX_AMARELO(int tar_id, Decimal value);
        void UpdateTAR_SETUPA_MAX_AMARELO(int tar_id, Decimal value);
        void UpdateTAR_OBS_OP_PARCIAL(int tar_id, string value);
        void UpdateTAR_OCO_ID_OP_PARCIAL(int tar_id, string value);
        void UpdateTAR_COR_PERFORMANCE(int tar_id, string value);
        void UpdateTAR_COR_SETUP_GERAL(int tar_id, string value);
        void UpdateTAR_COR_SETUP(int tar_id, string value);
        void UpdateTAR_COR_SETUPA(int tar_id, string value);
        void UpdateTAR_DIA_TURMA_D(int tar_id, DateTime value);
        void UpdateFEE_QTD_PECAS_POR_PULSO(int tar_id, Decimal value);
        void UpdateTAR_QTD_PERDAS(int tar_id, Decimal value);
        void UpdateTAR_DATA_INICIAL(int tar_id, DateTime value);
        void UpdateTAR_DATA_FINAL(int tar_id, DateTime value);
        void UpdateTAR_APROVADO(int tar_id, string value);
        void UpdateTAR_TEMPO_PRODUZINDO(int tar_id, int value);
        void UpdateTenantID(int tar_id, int value);
        void UpdateDeleted(int tar_id, bool value);
        void UpdateChanged(int tar_id, DateTime value);
        void UpdateUserId(int tar_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration