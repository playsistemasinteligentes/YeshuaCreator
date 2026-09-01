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
    public partial interface IEstruturaProdutoReadRepository
    {
        public DataPagination<EstruturaProdutoDTO> getEstruturaProduto(ICommandRead command );
        public IEnumerable<EstruturaProdutoTenantIDDTO> getEstruturaProdutoReadFKTenantID(object command );
        public IEnumerable<EstruturaProdutoUserIdDTO> getEstruturaProdutoReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByEST_DATA_VALIDADE(DateTime value );
        public bool ExistsByPRO_ID_PRODUTO(string value );
        public bool ExistsByPRO_ID_COMPONENTE(string value );
        public bool ExistsByEST_QUANT(Decimal value );
        public bool ExistsByEST_DATA_INCLUSAO(DateTime value );
        public bool ExistsByEST_BASE_PRODUCAO(Decimal value );
        public bool ExistsByEST_TIPO_REQUISICAO(string value );
        public bool ExistsByEST_CODIGO_DE_EXCECAO(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public EstruturaProdutoDTO FirstById(int value );
        public EstruturaProdutoDTO FirstByEST_DATA_VALIDADE(DateTime value );
        public EstruturaProdutoDTO FirstByPRO_ID_PRODUTO(string value );
        public EstruturaProdutoDTO FirstByPRO_ID_COMPONENTE(string value );
        public EstruturaProdutoDTO FirstByEST_QUANT(Decimal value );
        public EstruturaProdutoDTO FirstByEST_DATA_INCLUSAO(DateTime value );
        public EstruturaProdutoDTO FirstByEST_BASE_PRODUCAO(Decimal value );
        public EstruturaProdutoDTO FirstByEST_TIPO_REQUISICAO(string value );
        public EstruturaProdutoDTO FirstByEST_CODIGO_DE_EXCECAO(string value );
        public EstruturaProdutoDTO FirstByTenantID(int value );
        public EstruturaProdutoDTO FirstByDeleted(bool value );
        public EstruturaProdutoDTO FirstByChanged(DateTime value );
        public EstruturaProdutoDTO FirstByUserId(int value );
        public IEnumerable<EstruturaProdutoDTO> GetAllById(int value );
        public IEnumerable<EstruturaProdutoDTO> GetAllByEST_DATA_VALIDADE(DateTime value );
        public IEnumerable<EstruturaProdutoDTO> GetAllByPRO_ID_PRODUTO(string value );
        public IEnumerable<EstruturaProdutoDTO> GetAllByPRO_ID_COMPONENTE(string value );
        public IEnumerable<EstruturaProdutoDTO> GetAllByEST_QUANT(Decimal value );
        public IEnumerable<EstruturaProdutoDTO> GetAllByEST_DATA_INCLUSAO(DateTime value );
        public IEnumerable<EstruturaProdutoDTO> GetAllByEST_BASE_PRODUCAO(Decimal value );
        public IEnumerable<EstruturaProdutoDTO> GetAllByEST_TIPO_REQUISICAO(string value );
        public IEnumerable<EstruturaProdutoDTO> GetAllByEST_CODIGO_DE_EXCECAO(string value );
        public IEnumerable<EstruturaProdutoDTO> GetAllByTenantID(int value );
        public IEnumerable<EstruturaProdutoDTO> GetAllByDeleted(bool value );
        public IEnumerable<EstruturaProdutoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<EstruturaProdutoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration