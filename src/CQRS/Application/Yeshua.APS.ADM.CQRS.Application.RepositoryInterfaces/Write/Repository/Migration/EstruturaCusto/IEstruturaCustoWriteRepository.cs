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
    public partial interface IEstruturaCustoWriteRepository
    {
        void Insert(IEstruturaCustoEntity estruturacusto);
        void Update(IEstruturaCustoEntity estruturacusto);
        void Delete(IEstruturaCustoEntity estruturacusto);
        void UpdateITO_ID(int est_id, int value);
        void UpdateORD_ID(int est_id, string value);
        void UpdatePRO_ID(int est_id, string value);
        void UpdatePRO_ID_PRODUTO(int est_id, string value);
        void UpdatePRO_ID_COMPONENTE(int est_id, string value);
        void UpdatePRO_TIPO_CUSTO(int est_id, string value);
        void UpdatePRO_GRUPO_CONTABIL(int est_id, string value);
        void UpdateEST_ORDEM(int est_id, int value);
        void UpdateEST_GRUPO(int est_id, string value);
        void UpdateEST_QUANT(int est_id, Decimal value);
        void UpdateEST_VALOR_TOTAL(int est_id, Decimal value);
        void UpdateEST_DATA_BASE(int est_id, string value);
        void UpdateEST_BASE_PRODUCAO(int est_id, Decimal value);
        void UpdateEST_NIVEL(int est_id, Decimal value);
        void UpdateFPR_SEQ_REPETICAO(int est_id, int value);
        void UpdateTenantID(int est_id, int value);
        void UpdateDeleted(int est_id, bool value);
        void UpdateChanged(int est_id, DateTime value);
        void UpdateUserId(int est_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration