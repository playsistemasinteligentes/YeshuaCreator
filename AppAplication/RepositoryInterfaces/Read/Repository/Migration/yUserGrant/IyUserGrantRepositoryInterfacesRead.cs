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
        public bool ExistsByPerfilId(int value );
        public bool ExistsByGrantId(string value );
        public bool ExistsByGrant(bool value );
        public bool ExistsByCreate(bool value );
        public bool ExistsByRead(bool value );
        public bool ExistsByUpdate(bool value );
        public bool ExistsByDelete(bool value );
        public bool ExistsByValidUntil(DateTime value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public yUserGrantDTO FirstByPerfilId(int value );
        public yUserGrantDTO FirstByGrantId(string value );
        public yUserGrantDTO FirstByGrant(bool value );
        public yUserGrantDTO FirstByCreate(bool value );
        public yUserGrantDTO FirstByRead(bool value );
        public yUserGrantDTO FirstByUpdate(bool value );
        public yUserGrantDTO FirstByDelete(bool value );
        public yUserGrantDTO FirstByValidUntil(DateTime value );
        public yUserGrantDTO FirstByTenantID(int value );
        public yUserGrantDTO FirstByDeleted(bool value );
        public yUserGrantDTO FirstByChanged(DateTime value );
        public yUserGrantDTO FirstByUserId(int value );
        public IEnumerable<yUserGrantDTO> GetAllByPerfilId(int value );
        public IEnumerable<yUserGrantDTO> GetAllByGrantId(string value );
        public IEnumerable<yUserGrantDTO> GetAllByGrant(bool value );
        public IEnumerable<yUserGrantDTO> GetAllByCreate(bool value );
        public IEnumerable<yUserGrantDTO> GetAllByRead(bool value );
        public IEnumerable<yUserGrantDTO> GetAllByUpdate(bool value );
        public IEnumerable<yUserGrantDTO> GetAllByDelete(bool value );
        public IEnumerable<yUserGrantDTO> GetAllByValidUntil(DateTime value );
        public IEnumerable<yUserGrantDTO> GetAllByTenantID(int value );
        public IEnumerable<yUserGrantDTO> GetAllByDeleted(bool value );
        public IEnumerable<yUserGrantDTO> GetAllByChanged(DateTime value );
        public IEnumerable<yUserGrantDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration