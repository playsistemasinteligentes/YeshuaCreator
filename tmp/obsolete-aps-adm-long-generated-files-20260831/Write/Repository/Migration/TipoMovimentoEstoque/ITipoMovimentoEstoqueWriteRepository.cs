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
    public partial interface ITipoMovimentoEstoqueWriteRepository
    {
        void Insert(ITipoMovimentoEstoqueEntity tipomovimentoestoque);
        void Update(ITipoMovimentoEstoqueEntity tipomovimentoestoque);
        void Delete(ITipoMovimentoEstoqueEntity tipomovimentoestoque);
        void UpdateTIP_DESCRICAO(string tip_id, string value);
        void UpdateTIP_TYPE(string tip_id, int value);
        void UpdateSPR(string tip_id, int value);
        void UpdateTenantID(string tip_id, int value);
        void UpdateDeleted(string tip_id, bool value);
        void UpdateChanged(string tip_id, DateTime value);
        void UpdateUserId(string tip_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration