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
    public partial interface ITiposVincoOndasReadRepository
    {
        public DataPagination<TiposVincoOndasDTO> getTiposVincoOndas(ICommandRead command );
        public IEnumerable<TiposVincoOndasTenantIDDTO> getTiposVincoOndasReadFKTenantID(object command );
        public IEnumerable<TiposVincoOndasUserIdDTO> getTiposVincoOndasReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsById2(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public TiposVincoOndasDTO FirstById(int value );
        public TiposVincoOndasDTO FirstById2(int value );
        public TiposVincoOndasDTO FirstByTenantID(int value );
        public TiposVincoOndasDTO FirstByDeleted(bool value );
        public TiposVincoOndasDTO FirstByChanged(DateTime value );
        public TiposVincoOndasDTO FirstByUserId(int value );
        public IEnumerable<TiposVincoOndasDTO> GetAllById(int value );
        public IEnumerable<TiposVincoOndasDTO> GetAllById2(int value );
        public IEnumerable<TiposVincoOndasDTO> GetAllByTenantID(int value );
        public IEnumerable<TiposVincoOndasDTO> GetAllByDeleted(bool value );
        public IEnumerable<TiposVincoOndasDTO> GetAllByChanged(DateTime value );
        public IEnumerable<TiposVincoOndasDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration