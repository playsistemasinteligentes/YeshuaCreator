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
    public partial interface IResultMedidaReadRepository
    {
        public DataPagination<ResultMedidaDTO> getResultMedida(ICommandRead command );
        public IEnumerable<ResultMedidaTenantIDDTO> getResultMedidaReadFKTenantID(object command );
        public IEnumerable<ResultMedidaUserIdDTO> getResultMedidaReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByRSM_ID(int value );
        public bool ExistsByRL_ID(int value );
        public bool ExistsByMDT_ID(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public ResultMedidaDTO FirstById(int value );
        public ResultMedidaDTO FirstByRSM_ID(int value );
        public ResultMedidaDTO FirstByRL_ID(int value );
        public ResultMedidaDTO FirstByMDT_ID(int value );
        public ResultMedidaDTO FirstByTenantID(int value );
        public ResultMedidaDTO FirstByDeleted(bool value );
        public ResultMedidaDTO FirstByChanged(DateTime value );
        public ResultMedidaDTO FirstByUserId(int value );
        public IEnumerable<ResultMedidaDTO> GetAllById(int value );
        public IEnumerable<ResultMedidaDTO> GetAllByRSM_ID(int value );
        public IEnumerable<ResultMedidaDTO> GetAllByRL_ID(int value );
        public IEnumerable<ResultMedidaDTO> GetAllByMDT_ID(int value );
        public IEnumerable<ResultMedidaDTO> GetAllByTenantID(int value );
        public IEnumerable<ResultMedidaDTO> GetAllByDeleted(bool value );
        public IEnumerable<ResultMedidaDTO> GetAllByChanged(DateTime value );
        public IEnumerable<ResultMedidaDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration