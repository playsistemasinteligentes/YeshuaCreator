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
    public partial interface ICargaPrevistaWriteRepository
    {
        void Insert(ICargaPrevistaEntity cargaprevista);
        void Update(ICargaPrevistaEntity cargaprevista);
        void Delete(ICargaPrevistaEntity cargaprevista);
        void UpdateCAR_ID(int id, string value);
        void UpdateORD_ID(int id, string value);
        void UpdateITC_QTD_PLANEJADA(int id, Decimal value);
        void UpdateCAR_PREVISAO_MATERIA_PRIMA(int id, DateTime value);
        void UpdateCAR_DATA_INICIO_PREVISTO(int id, DateTime value);
        void UpdateCAR_DATA_INICIO_REALIZADO(int id, DateTime value);
        void UpdateCAR_DATA_FIM_PREVISTO(int id, DateTime value);
        void UpdateCAR_DATA_FIM_REALIZADO(int id, DateTime value);
        void UpdateCAR_INICIO_JANELA_EMBARQUE(int id, DateTime value);
        void UpdateCAR_FIM_JANELA_EMBARQUE(int id, DateTime value);
        void UpdateCAR_EMBARQUE_ALVO(int id, DateTime value);
        void UpdateCAR_STATUS(int id, Decimal value);
        void UpdateCAR_PESO_TEORICO(int id, Decimal value);
        void UpdateCAR_VOLUME_TEORICO(int id, Decimal value);
        void UpdateCAR_PESO_REAL(int id, Decimal value);
        void UpdateCAR_VOLUME_REAL(int id, Decimal value);
        void UpdateCAR_PESO_EMBALAGEM(int id, Decimal value);
        void UpdateCAR_PESO_ENTRADA(int id, Decimal value);
        void UpdateCAR_PESO_SAIDA(int id, Decimal value);
        void UpdateCAR_ID_DOCA(int id, string value);
        void UpdateVEI_PLACA(int id, string value);
        void UpdateTIP_ID(int id, int value);
        void UpdateTRA_ID(int id, string value);
        void UpdateCAR_GRUPO_PRODUTIVO(int id, Decimal value);
        void UpdateROT_ID(int id, string value);
        void UpdateCAR_OBSERVACAO_DE_TRANSPORTE(int id, string value);
        void UpdateCAR_JUSTIFICATIVA_DE_CARREGAMENTO(int id, string value);
        void UpdateOCO_ID(int id, string value);
        void UpdateCAR_ID_JUNTADA(int id, string value);
        void UpdateCAR_OBSERVACAO_OTIMIZADOR(int id, string value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration