// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration
// </yeshua>

using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Read
{
    public partial interface IGrupoRecursoReadRepository
    {
        public DataPagination<GrupoRecursoDTO> getGrupoRecurso(ICommandRead command );
        public IEnumerable<GrupoRecursoTenantIDDTO> getGrupoRecursoReadFKTenantID(object command );
        public IEnumerable<GrupoRecursoUserIdDTO> getGrupoRecursoReadFKUserId(object command );
        public bool ExistsByGRE_ID(string value );
        public bool ExistsByGRE_DESCRICAO(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public GrupoRecursoDTO FirstByGRE_ID(string value );
        public GrupoRecursoDTO FirstByGRE_DESCRICAO(string value );
        public GrupoRecursoDTO FirstByTenantID(int value );
        public GrupoRecursoDTO FirstByDeleted(bool value );
        public GrupoRecursoDTO FirstByChanged(DateTime value );
        public GrupoRecursoDTO FirstByUserId(int value );
        public IEnumerable<GrupoRecursoDTO> GetAllByGRE_ID(string value );
        public IEnumerable<GrupoRecursoDTO> GetAllByGRE_DESCRICAO(string value );
        public IEnumerable<GrupoRecursoDTO> GetAllByTenantID(int value );
        public IEnumerable<GrupoRecursoDTO> GetAllByDeleted(bool value );
        public IEnumerable<GrupoRecursoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<GrupoRecursoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration