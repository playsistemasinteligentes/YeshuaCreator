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
        public bool ExistsByMAQ_ID(string value );
        public bool ExistsByMAQ_DESCRICAO(string value );
        public bool ExistsByMAQ_STATUS(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public MaquinaDTO FirstByMAQ_ID(string value );
        public MaquinaDTO FirstByMAQ_DESCRICAO(string value );
        public MaquinaDTO FirstByMAQ_STATUS(string value );
        public MaquinaDTO FirstByTenantID(int value );
        public MaquinaDTO FirstByDeleted(bool value );
        public MaquinaDTO FirstByChanged(DateTime value );
        public MaquinaDTO FirstByUserId(int value );
        public IEnumerable<MaquinaDTO> GetAllByMAQ_ID(string value );
        public IEnumerable<MaquinaDTO> GetAllByMAQ_DESCRICAO(string value );
        public IEnumerable<MaquinaDTO> GetAllByMAQ_STATUS(string value );
        public IEnumerable<MaquinaDTO> GetAllByTenantID(int value );
        public IEnumerable<MaquinaDTO> GetAllByDeleted(bool value );
        public IEnumerable<MaquinaDTO> GetAllByChanged(DateTime value );
        public IEnumerable<MaquinaDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration