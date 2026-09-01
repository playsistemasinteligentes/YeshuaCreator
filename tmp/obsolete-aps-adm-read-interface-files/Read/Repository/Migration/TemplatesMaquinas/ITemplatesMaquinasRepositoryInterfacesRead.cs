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
    public partial interface ITemplatesMaquinasReadRepository
    {
        public DataPagination<TemplatesMaquinasDTO> getTemplatesMaquinas(ICommandRead command );
        public IEnumerable<TemplatesMaquinasTenantIDDTO> getTemplatesMaquinasReadFKTenantID(object command );
        public IEnumerable<TemplatesMaquinasUserIdDTO> getTemplatesMaquinasReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByTEM_ID(int value );
        public bool ExistsByMAQ_ID(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public TemplatesMaquinasDTO FirstById(int value );
        public TemplatesMaquinasDTO FirstByTEM_ID(int value );
        public TemplatesMaquinasDTO FirstByMAQ_ID(string value );
        public TemplatesMaquinasDTO FirstByTenantID(int value );
        public TemplatesMaquinasDTO FirstByDeleted(bool value );
        public TemplatesMaquinasDTO FirstByChanged(DateTime value );
        public TemplatesMaquinasDTO FirstByUserId(int value );
        public IEnumerable<TemplatesMaquinasDTO> GetAllById(int value );
        public IEnumerable<TemplatesMaquinasDTO> GetAllByTEM_ID(int value );
        public IEnumerable<TemplatesMaquinasDTO> GetAllByMAQ_ID(string value );
        public IEnumerable<TemplatesMaquinasDTO> GetAllByTenantID(int value );
        public IEnumerable<TemplatesMaquinasDTO> GetAllByDeleted(bool value );
        public IEnumerable<TemplatesMaquinasDTO> GetAllByChanged(DateTime value );
        public IEnumerable<TemplatesMaquinasDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration