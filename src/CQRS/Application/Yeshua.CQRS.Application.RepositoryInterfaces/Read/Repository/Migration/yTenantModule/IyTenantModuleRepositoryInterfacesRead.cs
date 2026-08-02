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
    public partial interface IyTenantModuleReadRepository
    {
        public DataPagination<yTenantModuleDTO> getyTenantModule(ICommandRead command );
        public IEnumerable<yTenantModuleModuleIdDTO> getyTenantModuleReadFKModuleId(object command );
        public IEnumerable<yTenantModuleTenantIDDTO> getyTenantModuleReadFKTenantID(object command );
        public IEnumerable<yTenantModuleUserIdDTO> getyTenantModuleReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByModuleId(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByValidUntil(DateTime value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public yTenantModuleDTO FirstById(int value );
        public yTenantModuleDTO FirstByModuleId(string value );
        public yTenantModuleDTO FirstByTenantID(int value );
        public yTenantModuleDTO FirstByValidUntil(DateTime value );
        public yTenantModuleDTO FirstByDeleted(bool value );
        public yTenantModuleDTO FirstByChanged(DateTime value );
        public yTenantModuleDTO FirstByUserId(int value );
        public IEnumerable<yTenantModuleDTO> GetAllById(int value );
        public IEnumerable<yTenantModuleDTO> GetAllByModuleId(string value );
        public IEnumerable<yTenantModuleDTO> GetAllByTenantID(int value );
        public IEnumerable<yTenantModuleDTO> GetAllByValidUntil(DateTime value );
        public IEnumerable<yTenantModuleDTO> GetAllByDeleted(bool value );
        public IEnumerable<yTenantModuleDTO> GetAllByChanged(DateTime value );
        public IEnumerable<yTenantModuleDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration