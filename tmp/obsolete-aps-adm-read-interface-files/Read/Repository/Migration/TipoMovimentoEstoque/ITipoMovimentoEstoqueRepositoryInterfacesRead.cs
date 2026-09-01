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
    public partial interface ITipoMovimentoEstoqueReadRepository
    {
        public DataPagination<TipoMovimentoEstoqueDTO> getTipoMovimentoEstoque(ICommandRead command );
        public IEnumerable<TipoMovimentoEstoqueTenantIDDTO> getTipoMovimentoEstoqueReadFKTenantID(object command );
        public IEnumerable<TipoMovimentoEstoqueUserIdDTO> getTipoMovimentoEstoqueReadFKUserId(object command );
        public bool ExistsByTIP_ID(string value );
        public bool ExistsByTIP_DESCRICAO(string value );
        public bool ExistsByTIP_TYPE(int value );
        public bool ExistsBySPR(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public TipoMovimentoEstoqueDTO FirstByTIP_ID(string value );
        public TipoMovimentoEstoqueDTO FirstByTIP_DESCRICAO(string value );
        public TipoMovimentoEstoqueDTO FirstByTIP_TYPE(int value );
        public TipoMovimentoEstoqueDTO FirstBySPR(int value );
        public TipoMovimentoEstoqueDTO FirstByTenantID(int value );
        public TipoMovimentoEstoqueDTO FirstByDeleted(bool value );
        public TipoMovimentoEstoqueDTO FirstByChanged(DateTime value );
        public TipoMovimentoEstoqueDTO FirstByUserId(int value );
        public IEnumerable<TipoMovimentoEstoqueDTO> GetAllByTIP_ID(string value );
        public IEnumerable<TipoMovimentoEstoqueDTO> GetAllByTIP_DESCRICAO(string value );
        public IEnumerable<TipoMovimentoEstoqueDTO> GetAllByTIP_TYPE(int value );
        public IEnumerable<TipoMovimentoEstoqueDTO> GetAllBySPR(int value );
        public IEnumerable<TipoMovimentoEstoqueDTO> GetAllByTenantID(int value );
        public IEnumerable<TipoMovimentoEstoqueDTO> GetAllByDeleted(bool value );
        public IEnumerable<TipoMovimentoEstoqueDTO> GetAllByChanged(DateTime value );
        public IEnumerable<TipoMovimentoEstoqueDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration