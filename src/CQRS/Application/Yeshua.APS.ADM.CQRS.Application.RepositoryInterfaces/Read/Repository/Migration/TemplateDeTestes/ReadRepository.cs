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
    public partial interface ITemplateDeTestesReadRepository
    {
        public DataPagination<TemplateDeTestesDTO> getTemplateDeTestes(ICommandRead command );
        public IEnumerable<TemplateDeTestesTenantIDDTO> getTemplateDeTestesReadFKTenantID(object command );
        public IEnumerable<TemplateDeTestesUserIdDTO> getTemplateDeTestesReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByDescricao(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public bool ExistsByObservacao(string value );
        public TemplateDeTestesDTO FirstById(int value );
        public TemplateDeTestesDTO FirstByDescricao(string value );
        public TemplateDeTestesDTO FirstByTenantID(int value );
        public TemplateDeTestesDTO FirstByDeleted(bool value );
        public TemplateDeTestesDTO FirstByChanged(DateTime value );
        public TemplateDeTestesDTO FirstByUserId(int value );
        public TemplateDeTestesDTO FirstByObservacao(string value );
        public IEnumerable<TemplateDeTestesDTO> GetAllById(int value );
        public IEnumerable<TemplateDeTestesDTO> GetAllByDescricao(string value );
        public IEnumerable<TemplateDeTestesDTO> GetAllByTenantID(int value );
        public IEnumerable<TemplateDeTestesDTO> GetAllByDeleted(bool value );
        public IEnumerable<TemplateDeTestesDTO> GetAllByChanged(DateTime value );
        public IEnumerable<TemplateDeTestesDTO> GetAllByUserId(int value );
        public IEnumerable<TemplateDeTestesDTO> GetAllByObservacao(string value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration