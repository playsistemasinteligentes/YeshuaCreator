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
        void UpdateGMA_DESCRICAO(string gma_id, string value);
        void UpdateGMA_STATUS(string gma_id, string value);
        void UpdateTenantID(string gma_id, int value);
        void UpdateDeleted(string gma_id, bool value);
        void UpdateChanged(string gma_id, DateTime value);
        void UpdateUserId(string gma_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration