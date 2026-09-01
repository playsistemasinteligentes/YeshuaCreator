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
    public partial interface IVersaoCustoReadRepository
    {
        public DataPagination<VersaoCustoDTO> getVersaoCusto(ICommandRead command );
        public IEnumerable<VersaoCustoTenantIDDTO> getVersaoCustoReadFKTenantID(object command );
        public IEnumerable<VersaoCustoUserIdDTO> getVersaoCustoReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByVER_ID(int value );
        public bool ExistsByVER_STATUS(string value );
        public bool ExistsByVER_OBS(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public VersaoCustoDTO FirstById(int value );
        public VersaoCustoDTO FirstByVER_ID(int value );
        public VersaoCustoDTO FirstByVER_STATUS(string value );
        public VersaoCustoDTO FirstByVER_OBS(string value );
        public VersaoCustoDTO FirstByTenantID(int value );
        public VersaoCustoDTO FirstByDeleted(bool value );
        public VersaoCustoDTO FirstByChanged(DateTime value );
        public VersaoCustoDTO FirstByUserId(int value );
        public IEnumerable<VersaoCustoDTO> GetAllById(int value );
        public IEnumerable<VersaoCustoDTO> GetAllByVER_ID(int value );
        public IEnumerable<VersaoCustoDTO> GetAllByVER_STATUS(string value );
        public IEnumerable<VersaoCustoDTO> GetAllByVER_OBS(string value );
        public IEnumerable<VersaoCustoDTO> GetAllByTenantID(int value );
        public IEnumerable<VersaoCustoDTO> GetAllByDeleted(bool value );
        public IEnumerable<VersaoCustoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<VersaoCustoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration