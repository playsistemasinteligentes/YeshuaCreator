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
    public partial interface IVerssaoCustoReadRepository
    {
        public DataPagination<VerssaoCustoDTO> getVerssaoCusto(ICommandRead command );
        public IEnumerable<VerssaoCustoTenantIDDTO> getVerssaoCustoReadFKTenantID(object command );
        public IEnumerable<VerssaoCustoUserIdDTO> getVerssaoCustoReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByVER_ID(int value );
        public bool ExistsByVER_STATUS(string value );
        public bool ExistsByVER_DATA_VERSSAO_CUSTO(DateTime value );
        public bool ExistsByVER_OBS(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public VerssaoCustoDTO FirstById(int value );
        public VerssaoCustoDTO FirstByVER_ID(int value );
        public VerssaoCustoDTO FirstByVER_STATUS(string value );
        public VerssaoCustoDTO FirstByVER_DATA_VERSSAO_CUSTO(DateTime value );
        public VerssaoCustoDTO FirstByVER_OBS(string value );
        public VerssaoCustoDTO FirstByTenantID(int value );
        public VerssaoCustoDTO FirstByDeleted(bool value );
        public VerssaoCustoDTO FirstByChanged(DateTime value );
        public VerssaoCustoDTO FirstByUserId(int value );
        public IEnumerable<VerssaoCustoDTO> GetAllById(int value );
        public IEnumerable<VerssaoCustoDTO> GetAllByVER_ID(int value );
        public IEnumerable<VerssaoCustoDTO> GetAllByVER_STATUS(string value );
        public IEnumerable<VerssaoCustoDTO> GetAllByVER_DATA_VERSSAO_CUSTO(DateTime value );
        public IEnumerable<VerssaoCustoDTO> GetAllByVER_OBS(string value );
        public IEnumerable<VerssaoCustoDTO> GetAllByTenantID(int value );
        public IEnumerable<VerssaoCustoDTO> GetAllByDeleted(bool value );
        public IEnumerable<VerssaoCustoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<VerssaoCustoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration