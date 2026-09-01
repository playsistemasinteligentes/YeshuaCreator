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
    public partial interface IResultLoteReadRepository
    {
        public DataPagination<ResultLoteDTO> getResultLote(ICommandRead command );
        public IEnumerable<ResultLoteTenantIDDTO> getResultLoteReadFKTenantID(object command );
        public IEnumerable<ResultLoteUserIdDTO> getResultLoteReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public ResultLoteDTO FirstById(int value );
        public ResultLoteDTO FirstByTenantID(int value );
        public ResultLoteDTO FirstByDeleted(bool value );
        public ResultLoteDTO FirstByChanged(DateTime value );
        public ResultLoteDTO FirstByUserId(int value );
        public IEnumerable<ResultLoteDTO> GetAllById(int value );
        public IEnumerable<ResultLoteDTO> GetAllByTenantID(int value );
        public IEnumerable<ResultLoteDTO> GetAllByDeleted(bool value );
        public IEnumerable<ResultLoteDTO> GetAllByChanged(DateTime value );
        public IEnumerable<ResultLoteDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration