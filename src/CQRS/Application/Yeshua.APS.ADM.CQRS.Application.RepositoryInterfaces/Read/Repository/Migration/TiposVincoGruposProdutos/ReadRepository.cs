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
    public partial interface ITiposVincoGruposProdutosReadRepository
    {
        public DataPagination<TiposVincoGruposProdutosDTO> getTiposVincoGruposProdutos(ICommandRead command );
        public IEnumerable<TiposVincoGruposProdutosTenantIDDTO> getTiposVincoGruposProdutosReadFKTenantID(object command );
        public IEnumerable<TiposVincoGruposProdutosUserIdDTO> getTiposVincoGruposProdutosReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsById2(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public TiposVincoGruposProdutosDTO FirstById(int value );
        public TiposVincoGruposProdutosDTO FirstById2(int value );
        public TiposVincoGruposProdutosDTO FirstByTenantID(int value );
        public TiposVincoGruposProdutosDTO FirstByDeleted(bool value );
        public TiposVincoGruposProdutosDTO FirstByChanged(DateTime value );
        public TiposVincoGruposProdutosDTO FirstByUserId(int value );
        public IEnumerable<TiposVincoGruposProdutosDTO> GetAllById(int value );
        public IEnumerable<TiposVincoGruposProdutosDTO> GetAllById2(int value );
        public IEnumerable<TiposVincoGruposProdutosDTO> GetAllByTenantID(int value );
        public IEnumerable<TiposVincoGruposProdutosDTO> GetAllByDeleted(bool value );
        public IEnumerable<TiposVincoGruposProdutosDTO> GetAllByChanged(DateTime value );
        public IEnumerable<TiposVincoGruposProdutosDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration