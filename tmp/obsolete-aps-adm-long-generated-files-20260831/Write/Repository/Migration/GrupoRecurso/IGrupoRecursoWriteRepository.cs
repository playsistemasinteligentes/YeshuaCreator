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
    public partial interface IGrupoRecursoWriteRepository
    {
        void Insert(IGrupoRecursoEntity gruporecurso);
        void Update(IGrupoRecursoEntity gruporecurso);
        void Delete(IGrupoRecursoEntity gruporecurso);
        void UpdateGRE_DESCRICAO(string gre_id, string value);
        void UpdateTenantID(string gre_id, int value);
        void UpdateDeleted(string gre_id, bool value);
        void UpdateChanged(string gre_id, DateTime value);
        void UpdateUserId(string gre_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration