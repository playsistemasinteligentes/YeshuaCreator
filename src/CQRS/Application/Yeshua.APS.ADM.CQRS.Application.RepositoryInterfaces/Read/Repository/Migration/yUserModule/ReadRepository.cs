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
    public partial interface IyUserModuleReadRepository
    {
        public DataPagination<yUserModuleDTO> getyUserModule(ICommandRead command );
        public IEnumerable<yUserModuleModuleIdDTO> getyUserModuleReadFKModuleId(object command );
        public IEnumerable<yUserModuleUserIdDTO> getyUserModuleReadFKUserId(object command );
        public IEnumerable<yUserModuleTenantIDDTO> getyUserModuleReadFKTenantID(object command );
        public bool ExistsById(int value );
        public bool ExistsByModuleId(string value );
        public bool ExistsByUserId(int value );
        public bool ExistsByValidUntil(DateTime value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public yUserModuleDTO FirstById(int value );
        public yUserModuleDTO FirstByModuleId(string value );
        public yUserModuleDTO FirstByUserId(int value );
        public yUserModuleDTO FirstByValidUntil(DateTime value );
        public yUserModuleDTO FirstByTenantID(int value );
        public yUserModuleDTO FirstByDeleted(bool value );
        public yUserModuleDTO FirstByChanged(DateTime value );
        public IEnumerable<yUserModuleDTO> GetAllById(int value );
        public IEnumerable<yUserModuleDTO> GetAllByModuleId(string value );
        public IEnumerable<yUserModuleDTO> GetAllByUserId(int value );
        public IEnumerable<yUserModuleDTO> GetAllByValidUntil(DateTime value );
        public IEnumerable<yUserModuleDTO> GetAllByTenantID(int value );
        public IEnumerable<yUserModuleDTO> GetAllByDeleted(bool value );
        public IEnumerable<yUserModuleDTO> GetAllByChanged(DateTime value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration