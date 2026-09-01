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
    public partial interface IEstruturaImpressaoReadRepository
    {
        public DataPagination<EstruturaImpressaoDTO> getEstruturaImpressao(ICommandRead command );
        public IEnumerable<EstruturaImpressaoCLI_IDDTO> getEstruturaImpressaoReadFKCLI_ID(object command );
        public IEnumerable<EstruturaImpressaoTenantIDDTO> getEstruturaImpressaoReadFKTenantID(object command );
        public IEnumerable<EstruturaImpressaoUserIdDTO> getEstruturaImpressaoReadFKUserId(object command );
        public bool ExistsByEST_ID(int value );
        public bool ExistsByHTML_ESTRUTURA(string value );
        public bool ExistsByCLI_ID(string value );
        public bool ExistsByEST_DESCRICAO(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public EstruturaImpressaoDTO FirstByEST_ID(int value );
        public EstruturaImpressaoDTO FirstByHTML_ESTRUTURA(string value );
        public EstruturaImpressaoDTO FirstByCLI_ID(string value );
        public EstruturaImpressaoDTO FirstByEST_DESCRICAO(string value );
        public EstruturaImpressaoDTO FirstByTenantID(int value );
        public EstruturaImpressaoDTO FirstByDeleted(bool value );
        public EstruturaImpressaoDTO FirstByChanged(DateTime value );
        public EstruturaImpressaoDTO FirstByUserId(int value );
        public IEnumerable<EstruturaImpressaoDTO> GetAllByEST_ID(int value );
        public IEnumerable<EstruturaImpressaoDTO> GetAllByHTML_ESTRUTURA(string value );
        public IEnumerable<EstruturaImpressaoDTO> GetAllByCLI_ID(string value );
        public IEnumerable<EstruturaImpressaoDTO> GetAllByEST_DESCRICAO(string value );
        public IEnumerable<EstruturaImpressaoDTO> GetAllByTenantID(int value );
        public IEnumerable<EstruturaImpressaoDTO> GetAllByDeleted(bool value );
        public IEnumerable<EstruturaImpressaoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<EstruturaImpressaoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration