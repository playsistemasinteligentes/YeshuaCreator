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
    public partial interface IMesesWriteRepository
    {
        void Insert(IMesesEntity meses);
        void Update(IMesesEntity meses);
        void Delete(IMesesEntity meses);
        void Updatefator(string mes, int value);
        void UpdateTenantID(string mes, int value);
        void UpdateDeleted(string mes, bool value);
        void UpdateChanged(string mes, DateTime value);
        void UpdateUserId(string mes, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration