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
    public partial interface IUnidadeWriteRepository
    {
        void Insert(IUnidadeEntity unidade);
        void Update(IUnidadeEntity unidade);
        void Delete(IUnidadeEntity unidade);
        void UpdateDEESCRICAO(int uni_id, string value);
        void UpdateUN(int uni_id, string value);
        void UpdateTenantID(int uni_id, int value);
        void UpdateDeleted(int uni_id, bool value);
        void UpdateChanged(int uni_id, DateTime value);
        void UpdateUserId(int uni_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration