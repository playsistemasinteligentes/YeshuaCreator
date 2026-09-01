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
    public partial interface IGrupoIndicadorWriteRepository
    {
        void Insert(IGrupoIndicadorEntity grupoindicador);
        void Update(IGrupoIndicadorEntity grupoindicador);
        void Delete(IGrupoIndicadorEntity grupoindicador);
        void UpdateGRU_ID(int gru_ind_id, int value);
        void UpdateIND_ID(int gru_ind_id, int value);
        void UpdateTenantID(int gru_ind_id, int value);
        void UpdateDeleted(int gru_ind_id, bool value);
        void UpdateChanged(int gru_ind_id, DateTime value);
        void UpdateUserId(int gru_ind_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration