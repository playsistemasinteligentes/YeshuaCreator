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
    public partial interface IMaquinaReadRepository
    {
        public DataPagination<MaquinaDTO> getMaquina(ICommandRead command );
        public IEnumerable<MaquinaTenantIDDTO> getMaquinaReadFKTenantID(object command );
        public IEnumerable<MaquinaUserIdDTO> getMaquinaReadFKUserId(object command );
        public bool ExistsById(string value );
        public bool ExistsByDescricao(string value );
        public bool ExistsByStatus(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public MaquinaDTO FirstById(string value );
        public MaquinaDTO FirstByDescricao(string value );
        public MaquinaDTO FirstByStatus(string value );
        public MaquinaDTO FirstByTenantID(int value );
        public MaquinaDTO FirstByDeleted(bool value );
        public MaquinaDTO FirstByChanged(DateTime value );
        public MaquinaDTO FirstByUserId(int value );
        public IEnumerable<MaquinaDTO> GetAllById(string value );
        public IEnumerable<MaquinaDTO> GetAllByDescricao(string value );
        public IEnumerable<MaquinaDTO> GetAllByStatus(string value );
        public IEnumerable<MaquinaDTO> GetAllByTenantID(int value );
        public IEnumerable<MaquinaDTO> GetAllByDeleted(bool value );
        public IEnumerable<MaquinaDTO> GetAllByChanged(DateTime value );
        public IEnumerable<MaquinaDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration