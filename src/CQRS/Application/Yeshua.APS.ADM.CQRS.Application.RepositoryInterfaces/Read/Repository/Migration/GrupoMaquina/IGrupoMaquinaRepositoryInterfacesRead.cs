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
    public partial interface IGrupoMaquinaReadRepository
    {
        public DataPagination<GrupoMaquinaDTO> getGrupoMaquina(ICommandRead command );
        public IEnumerable<GrupoMaquinaTenantIDDTO> getGrupoMaquinaReadFKTenantID(object command );
        public IEnumerable<GrupoMaquinaUserIdDTO> getGrupoMaquinaReadFKUserId(object command );
        public bool ExistsById(string value );
        public bool ExistsByDescricao(string value );
        public bool ExistsByStatus(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public GrupoMaquinaDTO FirstById(string value );
        public GrupoMaquinaDTO FirstByDescricao(string value );
        public GrupoMaquinaDTO FirstByStatus(string value );
        public GrupoMaquinaDTO FirstByTenantID(int value );
        public GrupoMaquinaDTO FirstByDeleted(bool value );
        public GrupoMaquinaDTO FirstByChanged(DateTime value );
        public GrupoMaquinaDTO FirstByUserId(int value );
        public IEnumerable<GrupoMaquinaDTO> GetAllById(string value );
        public IEnumerable<GrupoMaquinaDTO> GetAllByDescricao(string value );
        public IEnumerable<GrupoMaquinaDTO> GetAllByStatus(string value );
        public IEnumerable<GrupoMaquinaDTO> GetAllByTenantID(int value );
        public IEnumerable<GrupoMaquinaDTO> GetAllByDeleted(bool value );
        public IEnumerable<GrupoMaquinaDTO> GetAllByChanged(DateTime value );
        public IEnumerable<GrupoMaquinaDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration