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
    public partial interface IT_MetasWriteRepository
    {
        void Insert(IT_MetasEntity t_metas);
        void Update(IT_MetasEntity t_metas);
        void Delete(IT_MetasEntity t_metas);
        void UpdateMET_DTINICIO(int met_id, string value);
        void UpdateMET_DTFIM(int met_id, string value);
        void UpdateMET_ALVO(int met_id, string value);
        void UpdateMET_TIPOALVO(int met_id, int value);
        void UpdateIND_ID(int met_id, int value);
        void UpdateMET_RANGE01(int met_id, Decimal value);
        void UpdateMET_RANGE02(int met_id, Decimal value);
        void UpdateMET_RANGE03(int met_id, Decimal value);
        void UpdateDIM_ID(int met_id, int value);
        void UpdateFAT_ID(int met_id, string value);
        void UpdateDIM_SUBDIMENSAO_ID(int met_id, string value);
        void UpdatePER_ID(int met_id, string value);
        void UpdateDOM_EMPRESA(int met_id, string value);
        void UpdateDOM_FILIAL(int met_id, string value);
        void UpdateTenantID(int met_id, int value);
        void UpdateDeleted(int met_id, bool value);
        void UpdateChanged(int met_id, DateTime value);
        void UpdateUserId(int met_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration