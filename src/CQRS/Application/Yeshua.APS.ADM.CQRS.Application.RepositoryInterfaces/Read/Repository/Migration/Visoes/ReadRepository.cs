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
    public partial interface IVisoesReadRepository
    {
        public DataPagination<VisoesDTO> getVisoes(ICommandRead command );
        public IEnumerable<VisoesVIS_PLANIDDTO> getVisoesReadFKVIS_PLANID(object command );
        public IEnumerable<VisoesCAB_IDDTO> getVisoesReadFKCAB_ID(object command );
        public IEnumerable<VisoesTenantIDDTO> getVisoesReadFKTenantID(object command );
        public IEnumerable<VisoesUserIdDTO> getVisoesReadFKUserId(object command );
        public bool ExistsByVIS_ID(int value );
        public bool ExistsByVIS_PLANID(int value );
        public bool ExistsByVIS_FORMULA(string value );
        public bool ExistsByCAB_ID(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public VisoesDTO FirstByVIS_ID(int value );
        public VisoesDTO FirstByVIS_PLANID(int value );
        public VisoesDTO FirstByVIS_FORMULA(string value );
        public VisoesDTO FirstByCAB_ID(int value );
        public VisoesDTO FirstByTenantID(int value );
        public VisoesDTO FirstByDeleted(bool value );
        public VisoesDTO FirstByChanged(DateTime value );
        public VisoesDTO FirstByUserId(int value );
        public IEnumerable<VisoesDTO> GetAllByVIS_ID(int value );
        public IEnumerable<VisoesDTO> GetAllByVIS_PLANID(int value );
        public IEnumerable<VisoesDTO> GetAllByVIS_FORMULA(string value );
        public IEnumerable<VisoesDTO> GetAllByCAB_ID(int value );
        public IEnumerable<VisoesDTO> GetAllByTenantID(int value );
        public IEnumerable<VisoesDTO> GetAllByDeleted(bool value );
        public IEnumerable<VisoesDTO> GetAllByChanged(DateTime value );
        public IEnumerable<VisoesDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration