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
    public partial interface IT_NegocioWriteRepository
    {
        void Insert(IT_NegocioEntity t_negocio);
        void Update(IT_NegocioEntity t_negocio);
        void Delete(IT_NegocioEntity t_negocio);
        void UpdateNEG_DESCRICAO(int neg_id, string value);
        void UpdateTenantID(int neg_id, int value);
        void UpdateDeleted(int neg_id, bool value);
        void UpdateChanged(int neg_id, DateTime value);
        void UpdateUserId(int neg_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration