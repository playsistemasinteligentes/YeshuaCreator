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
    public partial interface IRodoviasReadRepository
    {
        public DataPagination<RodoviasDTO> getRodovias(ICommandRead command );
        public IEnumerable<RodoviasTenantIDDTO> getRodoviasReadFKTenantID(object command );
        public IEnumerable<RodoviasUserIdDTO> getRodoviasReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByROD_ID(int value );
        public bool ExistsByROD_DESCRICAO(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public RodoviasDTO FirstById(int value );
        public RodoviasDTO FirstByROD_ID(int value );
        public RodoviasDTO FirstByROD_DESCRICAO(string value );
        public RodoviasDTO FirstByTenantID(int value );
        public RodoviasDTO FirstByDeleted(bool value );
        public RodoviasDTO FirstByChanged(DateTime value );
        public RodoviasDTO FirstByUserId(int value );
        public IEnumerable<RodoviasDTO> GetAllById(int value );
        public IEnumerable<RodoviasDTO> GetAllByROD_ID(int value );
        public IEnumerable<RodoviasDTO> GetAllByROD_DESCRICAO(string value );
        public IEnumerable<RodoviasDTO> GetAllByTenantID(int value );
        public IEnumerable<RodoviasDTO> GetAllByDeleted(bool value );
        public IEnumerable<RodoviasDTO> GetAllByChanged(DateTime value );
        public IEnumerable<RodoviasDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration