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
    public partial interface IyPerfilGrantReadRepository
    {
        public DataPagination<yPerfilGrantDTO> getyPerfilGrant(ICommandRead command );
        public IEnumerable<yPerfilGrantPerfilIdDTO> getyPerfilGrantReadFKPerfilId(object command );
        public IEnumerable<yPerfilGrantGrantIdDTO> getyPerfilGrantReadFKGrantId(object command );
        public IEnumerable<yPerfilGrantTenantIDDTO> getyPerfilGrantReadFKTenantID(object command );
        public IEnumerable<yPerfilGrantUserIdDTO> getyPerfilGrantReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByPerfilId(int value );
        public bool ExistsByGrantId(string value );
        public bool ExistsByCanGrant(bool value );
        public bool ExistsByCanCreate(bool value );
        public bool ExistsByCanRead(bool value );
        public bool ExistsByCanUpdate(bool value );
        public bool ExistsByCanDelete(bool value );
        public bool ExistsByValidUntil(DateTime value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public yPerfilGrantDTO FirstById(int value );
        public yPerfilGrantDTO FirstByPerfilId(int value );
        public yPerfilGrantDTO FirstByGrantId(string value );
        public yPerfilGrantDTO FirstByCanGrant(bool value );
        public yPerfilGrantDTO FirstByCanCreate(bool value );
        public yPerfilGrantDTO FirstByCanRead(bool value );
        public yPerfilGrantDTO FirstByCanUpdate(bool value );
        public yPerfilGrantDTO FirstByCanDelete(bool value );
        public yPerfilGrantDTO FirstByValidUntil(DateTime value );
        public yPerfilGrantDTO FirstByTenantID(int value );
        public yPerfilGrantDTO FirstByDeleted(bool value );
        public yPerfilGrantDTO FirstByChanged(DateTime value );
        public yPerfilGrantDTO FirstByUserId(int value );
        public IEnumerable<yPerfilGrantDTO> GetAllById(int value );
        public IEnumerable<yPerfilGrantDTO> GetAllByPerfilId(int value );
        public IEnumerable<yPerfilGrantDTO> GetAllByGrantId(string value );
        public IEnumerable<yPerfilGrantDTO> GetAllByCanGrant(bool value );
        public IEnumerable<yPerfilGrantDTO> GetAllByCanCreate(bool value );
        public IEnumerable<yPerfilGrantDTO> GetAllByCanRead(bool value );
        public IEnumerable<yPerfilGrantDTO> GetAllByCanUpdate(bool value );
        public IEnumerable<yPerfilGrantDTO> GetAllByCanDelete(bool value );
        public IEnumerable<yPerfilGrantDTO> GetAllByValidUntil(DateTime value );
        public IEnumerable<yPerfilGrantDTO> GetAllByTenantID(int value );
        public IEnumerable<yPerfilGrantDTO> GetAllByDeleted(bool value );
        public IEnumerable<yPerfilGrantDTO> GetAllByChanged(DateTime value );
        public IEnumerable<yPerfilGrantDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration