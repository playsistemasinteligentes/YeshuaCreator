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
    public partial interface IyGrantReadRepository
    {
        public DataPagination<yGrantDTO> getyGrant(ICommandRead command );
        public IEnumerable<yGrantTenantIDDTO> getyGrantReadFKTenantID(object command );
        public IEnumerable<yGrantUserIdDTO> getyGrantReadFKUserId(object command );
        public bool ExistsById(string value );
        public bool ExistsByDescription(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public yGrantDTO FirstById(string value );
        public yGrantDTO FirstByDescription(string value );
        public yGrantDTO FirstByTenantID(int value );
        public yGrantDTO FirstByDeleted(bool value );
        public yGrantDTO FirstByChanged(DateTime value );
        public yGrantDTO FirstByUserId(int value );
        public IEnumerable<yGrantDTO> GetAllById(string value );
        public IEnumerable<yGrantDTO> GetAllByDescription(string value );
        public IEnumerable<yGrantDTO> GetAllByTenantID(int value );
        public IEnumerable<yGrantDTO> GetAllByDeleted(bool value );
        public IEnumerable<yGrantDTO> GetAllByChanged(DateTime value );
        public IEnumerable<yGrantDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration