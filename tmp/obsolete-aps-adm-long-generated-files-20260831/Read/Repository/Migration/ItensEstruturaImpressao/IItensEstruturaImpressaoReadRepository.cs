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
    public partial interface IItensEstruturaImpressaoReadRepository
    {
        public DataPagination<ItensEstruturaImpressaoDTO> getItensEstruturaImpressao(ICommandRead command );
        public IEnumerable<ItensEstruturaImpressaoTenantIDDTO> getItensEstruturaImpressaoReadFKTenantID(object command );
        public IEnumerable<ItensEstruturaImpressaoUserIdDTO> getItensEstruturaImpressaoReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByIES_CUSTOM_FONT_SIZE(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public ItensEstruturaImpressaoDTO FirstById(int value );
        public ItensEstruturaImpressaoDTO FirstByIES_CUSTOM_FONT_SIZE(int value );
        public ItensEstruturaImpressaoDTO FirstByTenantID(int value );
        public ItensEstruturaImpressaoDTO FirstByDeleted(bool value );
        public ItensEstruturaImpressaoDTO FirstByChanged(DateTime value );
        public ItensEstruturaImpressaoDTO FirstByUserId(int value );
        public IEnumerable<ItensEstruturaImpressaoDTO> GetAllById(int value );
        public IEnumerable<ItensEstruturaImpressaoDTO> GetAllByIES_CUSTOM_FONT_SIZE(int value );
        public IEnumerable<ItensEstruturaImpressaoDTO> GetAllByTenantID(int value );
        public IEnumerable<ItensEstruturaImpressaoDTO> GetAllByDeleted(bool value );
        public IEnumerable<ItensEstruturaImpressaoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<ItensEstruturaImpressaoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration