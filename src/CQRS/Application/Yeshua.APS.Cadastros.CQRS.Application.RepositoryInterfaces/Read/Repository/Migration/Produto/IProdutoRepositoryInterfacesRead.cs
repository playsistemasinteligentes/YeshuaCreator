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
    public partial interface IProdutoReadRepository
    {
        public DataPagination<ProdutoDTO> getProduto(ICommandRead command );
        public IEnumerable<ProdutoTenantIDDTO> getProdutoReadFKTenantID(object command );
        public IEnumerable<ProdutoUserIdDTO> getProdutoReadFKUserId(object command );
        public bool ExistsByPRO_ID(string value );
        public bool ExistsByPRO_DESCRICAO(string value );
        public bool ExistsByPRO_STATUS(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public ProdutoDTO FirstByPRO_ID(string value );
        public ProdutoDTO FirstByPRO_DESCRICAO(string value );
        public ProdutoDTO FirstByPRO_STATUS(string value );
        public ProdutoDTO FirstByTenantID(int value );
        public ProdutoDTO FirstByDeleted(bool value );
        public ProdutoDTO FirstByChanged(DateTime value );
        public ProdutoDTO FirstByUserId(int value );
        public IEnumerable<ProdutoDTO> GetAllByPRO_ID(string value );
        public IEnumerable<ProdutoDTO> GetAllByPRO_DESCRICAO(string value );
        public IEnumerable<ProdutoDTO> GetAllByPRO_STATUS(string value );
        public IEnumerable<ProdutoDTO> GetAllByTenantID(int value );
        public IEnumerable<ProdutoDTO> GetAllByDeleted(bool value );
        public IEnumerable<ProdutoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<ProdutoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration