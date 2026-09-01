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
    public partial interface ITemplatesGrupoMaquinaReadRepository
    {
        public DataPagination<TemplatesGrupoMaquinaDTO> getTemplatesGrupoMaquina(ICommandRead command );
        public IEnumerable<TemplatesGrupoMaquinaTenantIDDTO> getTemplatesGrupoMaquinaReadFKTenantID(object command );
        public IEnumerable<TemplatesGrupoMaquinaUserIdDTO> getTemplatesGrupoMaquinaReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByTEM_ID(int value );
        public bool ExistsByGMA_ID(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public TemplatesGrupoMaquinaDTO FirstById(int value );
        public TemplatesGrupoMaquinaDTO FirstByTEM_ID(int value );
        public TemplatesGrupoMaquinaDTO FirstByGMA_ID(string value );
        public TemplatesGrupoMaquinaDTO FirstByTenantID(int value );
        public TemplatesGrupoMaquinaDTO FirstByDeleted(bool value );
        public TemplatesGrupoMaquinaDTO FirstByChanged(DateTime value );
        public TemplatesGrupoMaquinaDTO FirstByUserId(int value );
        public IEnumerable<TemplatesGrupoMaquinaDTO> GetAllById(int value );
        public IEnumerable<TemplatesGrupoMaquinaDTO> GetAllByTEM_ID(int value );
        public IEnumerable<TemplatesGrupoMaquinaDTO> GetAllByGMA_ID(string value );
        public IEnumerable<TemplatesGrupoMaquinaDTO> GetAllByTenantID(int value );
        public IEnumerable<TemplatesGrupoMaquinaDTO> GetAllByDeleted(bool value );
        public IEnumerable<TemplatesGrupoMaquinaDTO> GetAllByChanged(DateTime value );
        public IEnumerable<TemplatesGrupoMaquinaDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration