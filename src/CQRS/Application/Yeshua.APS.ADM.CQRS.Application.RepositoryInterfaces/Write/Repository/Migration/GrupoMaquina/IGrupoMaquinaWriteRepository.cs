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
    public partial interface IGrupoMaquinaWriteRepository
    {
        void Insert(IGrupoMaquinaEntity grupomaquina);
        void Update(IGrupoMaquinaEntity grupomaquina);
        void Delete(IGrupoMaquinaEntity grupomaquina);
        void UpdateDescricao(string id, string value);
        void UpdateStatus(string id, string value);
        void UpdateTenantID(string id, int value);
        void UpdateDeleted(string id, bool value);
        void UpdateChanged(string id, DateTime value);
        void UpdateUserId(string id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration