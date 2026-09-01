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
    public partial interface IMaquinaGrupoMaquinaReadRepository
    {
        public DataPagination<MaquinaGrupoMaquinaDTO> getMaquinaGrupoMaquina(ICommandRead command );
        public IEnumerable<MaquinaGrupoMaquinaTenantIDDTO> getMaquinaGrupoMaquinaReadFKTenantID(object command );
        public IEnumerable<MaquinaGrupoMaquinaUserIdDTO> getMaquinaGrupoMaquinaReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByGMA_ID(string value );
        public bool ExistsByMAQ_ID(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public MaquinaGrupoMaquinaDTO FirstById(int value );
        public MaquinaGrupoMaquinaDTO FirstByGMA_ID(string value );
        public MaquinaGrupoMaquinaDTO FirstByMAQ_ID(string value );
        public MaquinaGrupoMaquinaDTO FirstByTenantID(int value );
        public MaquinaGrupoMaquinaDTO FirstByDeleted(bool value );
        public MaquinaGrupoMaquinaDTO FirstByChanged(DateTime value );
        public MaquinaGrupoMaquinaDTO FirstByUserId(int value );
        public IEnumerable<MaquinaGrupoMaquinaDTO> GetAllById(int value );
        public IEnumerable<MaquinaGrupoMaquinaDTO> GetAllByGMA_ID(string value );
        public IEnumerable<MaquinaGrupoMaquinaDTO> GetAllByMAQ_ID(string value );
        public IEnumerable<MaquinaGrupoMaquinaDTO> GetAllByTenantID(int value );
        public IEnumerable<MaquinaGrupoMaquinaDTO> GetAllByDeleted(bool value );
        public IEnumerable<MaquinaGrupoMaquinaDTO> GetAllByChanged(DateTime value );
        public IEnumerable<MaquinaGrupoMaquinaDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration