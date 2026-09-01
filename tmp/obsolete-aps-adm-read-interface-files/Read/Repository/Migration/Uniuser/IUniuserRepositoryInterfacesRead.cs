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
    public partial interface IUniuserReadRepository
    {
        public DataPagination<UniuserDTO> getUniuser(ICommandRead command );
        public IEnumerable<UniuserUNI_IDDTO> getUniuserReadFKUNI_ID(object command );
        public IEnumerable<UniuserUSE_IDDTO> getUniuserReadFKUSE_ID(object command );
        public IEnumerable<UniuserTenantIDDTO> getUniuserReadFKTenantID(object command );
        public IEnumerable<UniuserUserIdDTO> getUniuserReadFKUserId(object command );
        public bool ExistsByUSERGRU_ID(int value );
        public bool ExistsByUNI_ID(int value );
        public bool ExistsByUSE_ID(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public UniuserDTO FirstByUSERGRU_ID(int value );
        public UniuserDTO FirstByUNI_ID(int value );
        public UniuserDTO FirstByUSE_ID(int value );
        public UniuserDTO FirstByTenantID(int value );
        public UniuserDTO FirstByDeleted(bool value );
        public UniuserDTO FirstByChanged(DateTime value );
        public UniuserDTO FirstByUserId(int value );
        public IEnumerable<UniuserDTO> GetAllByUSERGRU_ID(int value );
        public IEnumerable<UniuserDTO> GetAllByUNI_ID(int value );
        public IEnumerable<UniuserDTO> GetAllByUSE_ID(int value );
        public IEnumerable<UniuserDTO> GetAllByTenantID(int value );
        public IEnumerable<UniuserDTO> GetAllByDeleted(bool value );
        public IEnumerable<UniuserDTO> GetAllByChanged(DateTime value );
        public IEnumerable<UniuserDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration