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
    public partial interface IGrupoIndicadorReadRepository
    {
        public DataPagination<GrupoIndicadorDTO> getGrupoIndicador(ICommandRead command );
        public IEnumerable<GrupoIndicadorGRU_IDDTO> getGrupoIndicadorReadFKGRU_ID(object command );
        public IEnumerable<GrupoIndicadorIND_IDDTO> getGrupoIndicadorReadFKIND_ID(object command );
        public IEnumerable<GrupoIndicadorTenantIDDTO> getGrupoIndicadorReadFKTenantID(object command );
        public IEnumerable<GrupoIndicadorUserIdDTO> getGrupoIndicadorReadFKUserId(object command );
        public bool ExistsByGRU_IND_ID(int value );
        public bool ExistsByGRU_ID(int value );
        public bool ExistsByIND_ID(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public GrupoIndicadorDTO FirstByGRU_IND_ID(int value );
        public GrupoIndicadorDTO FirstByGRU_ID(int value );
        public GrupoIndicadorDTO FirstByIND_ID(int value );
        public GrupoIndicadorDTO FirstByTenantID(int value );
        public GrupoIndicadorDTO FirstByDeleted(bool value );
        public GrupoIndicadorDTO FirstByChanged(DateTime value );
        public GrupoIndicadorDTO FirstByUserId(int value );
        public IEnumerable<GrupoIndicadorDTO> GetAllByGRU_IND_ID(int value );
        public IEnumerable<GrupoIndicadorDTO> GetAllByGRU_ID(int value );
        public IEnumerable<GrupoIndicadorDTO> GetAllByIND_ID(int value );
        public IEnumerable<GrupoIndicadorDTO> GetAllByTenantID(int value );
        public IEnumerable<GrupoIndicadorDTO> GetAllByDeleted(bool value );
        public IEnumerable<GrupoIndicadorDTO> GetAllByChanged(DateTime value );
        public IEnumerable<GrupoIndicadorDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration