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
    public partial interface IPerfilWriteRepository
    {
        void Insert(IPerfilEntity perfil);
        void Update(IPerfilEntity perfil);
        void Delete(IPerfilEntity perfil);
        void UpdatePER_NOME(int per_id, string value);
        void UpdateTenantID(int per_id, int value);
        void UpdateDeleted(int per_id, bool value);
        void UpdateChanged(int per_id, DateTime value);
        void UpdateUserId(int per_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration