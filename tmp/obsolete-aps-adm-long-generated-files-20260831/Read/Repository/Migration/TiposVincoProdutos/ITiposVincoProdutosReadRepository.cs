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
    public partial interface ITiposVincoProdutosReadRepository
    {
        public DataPagination<TiposVincoProdutosDTO> getTiposVincoProdutos(ICommandRead command );
        public IEnumerable<TiposVincoProdutosTenantIDDTO> getTiposVincoProdutosReadFKTenantID(object command );
        public IEnumerable<TiposVincoProdutosUserIdDTO> getTiposVincoProdutosReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsById2(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public TiposVincoProdutosDTO FirstById(int value );
        public TiposVincoProdutosDTO FirstById2(int value );
        public TiposVincoProdutosDTO FirstByTenantID(int value );
        public TiposVincoProdutosDTO FirstByDeleted(bool value );
        public TiposVincoProdutosDTO FirstByChanged(DateTime value );
        public TiposVincoProdutosDTO FirstByUserId(int value );
        public IEnumerable<TiposVincoProdutosDTO> GetAllById(int value );
        public IEnumerable<TiposVincoProdutosDTO> GetAllById2(int value );
        public IEnumerable<TiposVincoProdutosDTO> GetAllByTenantID(int value );
        public IEnumerable<TiposVincoProdutosDTO> GetAllByDeleted(bool value );
        public IEnumerable<TiposVincoProdutosDTO> GetAllByChanged(DateTime value );
        public IEnumerable<TiposVincoProdutosDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration