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
    public partial interface IyTenantApplicationReadRepository
    {
        public DataPagination<yTenantApplicationDTO> getyTenantApplication(ICommandRead command );
        public IEnumerable<yTenantApplicationTenantIDDTO> getyTenantApplicationReadFKTenantID(object command );
        public IEnumerable<yTenantApplicationUserIdDTO> getyTenantApplicationReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByApplicationKey(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByValidUntil(DateTime value );
        public bool ExistsByOperationalEntityId(string value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public yTenantApplicationDTO FirstById(int value );
        public yTenantApplicationDTO FirstByApplicationKey(string value );
        public yTenantApplicationDTO FirstByTenantID(int value );
        public yTenantApplicationDTO FirstByValidUntil(DateTime value );
        public yTenantApplicationDTO FirstByOperationalEntityId(string value );
        public yTenantApplicationDTO FirstByDeleted(bool value );
        public yTenantApplicationDTO FirstByChanged(DateTime value );
        public yTenantApplicationDTO FirstByUserId(int value );
        public IEnumerable<yTenantApplicationDTO> GetAllById(int value );
        public IEnumerable<yTenantApplicationDTO> GetAllByApplicationKey(string value );
        public IEnumerable<yTenantApplicationDTO> GetAllByTenantID(int value );
        public IEnumerable<yTenantApplicationDTO> GetAllByValidUntil(DateTime value );
        public IEnumerable<yTenantApplicationDTO> GetAllByOperationalEntityId(string value );
        public IEnumerable<yTenantApplicationDTO> GetAllByDeleted(bool value );
        public IEnumerable<yTenantApplicationDTO> GetAllByChanged(DateTime value );
        public IEnumerable<yTenantApplicationDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration