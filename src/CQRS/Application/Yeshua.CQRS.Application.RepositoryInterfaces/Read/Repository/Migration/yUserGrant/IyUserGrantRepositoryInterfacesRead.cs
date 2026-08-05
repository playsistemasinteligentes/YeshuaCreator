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
    public partial interface IyUserGrantReadRepository
    {
        public DataPagination<yUserGrantDTO> getyUserGrant(ICommandRead command );
        public IEnumerable<yUserGrantPerfilIdDTO> getyUserGrantReadFKPerfilId(object command );
        public IEnumerable<yUserGrantGrantIdDTO> getyUserGrantReadFKGrantId(object command );
        public IEnumerable<yUserGrantTenantIDDTO> getyUserGrantReadFKTenantID(object command );
        public IEnumerable<yUserGrantUserIdDTO> getyUserGrantReadFKUserId(object command );
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
        public yUserGrantDTO FirstById(int value );
        public yUserGrantDTO FirstByPerfilId(int value );
        public yUserGrantDTO FirstByGrantId(string value );
        public yUserGrantDTO FirstByCanGrant(bool value );
        public yUserGrantDTO FirstByCanCreate(bool value );
        public yUserGrantDTO FirstByCanRead(bool value );
        public yUserGrantDTO FirstByCanUpdate(bool value );
        public yUserGrantDTO FirstByCanDelete(bool value );
        public yUserGrantDTO FirstByValidUntil(DateTime value );
        public yUserGrantDTO FirstByTenantID(int value );
        public yUserGrantDTO FirstByDeleted(bool value );
        public yUserGrantDTO FirstByChanged(DateTime value );
        public yUserGrantDTO FirstByUserId(int value );
        public IEnumerable<yUserGrantDTO> GetAllById(int value );
        public IEnumerable<yUserGrantDTO> GetAllByPerfilId(int value );
        public IEnumerable<yUserGrantDTO> GetAllByGrantId(string value );
        public IEnumerable<yUserGrantDTO> GetAllByCanGrant(bool value );
        public IEnumerable<yUserGrantDTO> GetAllByCanCreate(bool value );
        public IEnumerable<yUserGrantDTO> GetAllByCanRead(bool value );
        public IEnumerable<yUserGrantDTO> GetAllByCanUpdate(bool value );
        public IEnumerable<yUserGrantDTO> GetAllByCanDelete(bool value );
        public IEnumerable<yUserGrantDTO> GetAllByValidUntil(DateTime value );
        public IEnumerable<yUserGrantDTO> GetAllByTenantID(int value );
        public IEnumerable<yUserGrantDTO> GetAllByDeleted(bool value );
        public IEnumerable<yUserGrantDTO> GetAllByChanged(DateTime value );
        public IEnumerable<yUserGrantDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration