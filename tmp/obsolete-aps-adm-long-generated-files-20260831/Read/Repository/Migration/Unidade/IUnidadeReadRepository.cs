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
    public partial interface IUnidadeReadRepository
    {
        public DataPagination<UnidadeDTO> getUnidade(ICommandRead command );
        public IEnumerable<UnidadeTenantIDDTO> getUnidadeReadFKTenantID(object command );
        public IEnumerable<UnidadeUserIdDTO> getUnidadeReadFKUserId(object command );
        public bool ExistsByUNI_ID(int value );
        public bool ExistsByDEESCRICAO(string value );
        public bool ExistsByUN(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public UnidadeDTO FirstByUNI_ID(int value );
        public UnidadeDTO FirstByDEESCRICAO(string value );
        public UnidadeDTO FirstByUN(string value );
        public UnidadeDTO FirstByTenantID(int value );
        public UnidadeDTO FirstByDeleted(bool value );
        public UnidadeDTO FirstByChanged(DateTime value );
        public UnidadeDTO FirstByUserId(int value );
        public IEnumerable<UnidadeDTO> GetAllByUNI_ID(int value );
        public IEnumerable<UnidadeDTO> GetAllByDEESCRICAO(string value );
        public IEnumerable<UnidadeDTO> GetAllByUN(string value );
        public IEnumerable<UnidadeDTO> GetAllByTenantID(int value );
        public IEnumerable<UnidadeDTO> GetAllByDeleted(bool value );
        public IEnumerable<UnidadeDTO> GetAllByChanged(DateTime value );
        public IEnumerable<UnidadeDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration