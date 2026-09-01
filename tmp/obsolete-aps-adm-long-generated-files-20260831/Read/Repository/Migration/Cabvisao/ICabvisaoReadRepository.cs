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
    public partial interface ICabvisaoReadRepository
    {
        public DataPagination<CabvisaoDTO> getCabvisao(ICommandRead command );
        public IEnumerable<CabvisaoUSE_IDDTO> getCabvisaoReadFKUSE_ID(object command );
        public IEnumerable<CabvisaoTenantIDDTO> getCabvisaoReadFKTenantID(object command );
        public IEnumerable<CabvisaoUserIdDTO> getCabvisaoReadFKUserId(object command );
        public bool ExistsByCAB_ID(int value );
        public bool ExistsByCAB_DESC(string value );
        public bool ExistsByCAB_STATUS(int value );
        public bool ExistsByUSE_ID(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public CabvisaoDTO FirstByCAB_ID(int value );
        public CabvisaoDTO FirstByCAB_DESC(string value );
        public CabvisaoDTO FirstByCAB_STATUS(int value );
        public CabvisaoDTO FirstByUSE_ID(int value );
        public CabvisaoDTO FirstByTenantID(int value );
        public CabvisaoDTO FirstByDeleted(bool value );
        public CabvisaoDTO FirstByChanged(DateTime value );
        public CabvisaoDTO FirstByUserId(int value );
        public IEnumerable<CabvisaoDTO> GetAllByCAB_ID(int value );
        public IEnumerable<CabvisaoDTO> GetAllByCAB_DESC(string value );
        public IEnumerable<CabvisaoDTO> GetAllByCAB_STATUS(int value );
        public IEnumerable<CabvisaoDTO> GetAllByUSE_ID(int value );
        public IEnumerable<CabvisaoDTO> GetAllByTenantID(int value );
        public IEnumerable<CabvisaoDTO> GetAllByDeleted(bool value );
        public IEnumerable<CabvisaoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<CabvisaoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration