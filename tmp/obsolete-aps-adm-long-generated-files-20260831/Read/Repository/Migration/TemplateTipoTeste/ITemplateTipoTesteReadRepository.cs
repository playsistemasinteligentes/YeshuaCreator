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
    public partial interface ITemplateTipoTesteReadRepository
    {
        public DataPagination<TemplateTipoTesteDTO> getTemplateTipoTeste(ICommandRead command );
        public IEnumerable<TemplateTipoTesteTT_IDDTO> getTemplateTipoTesteReadFKTT_ID(object command );
        public IEnumerable<TemplateTipoTesteTEM_IDDTO> getTemplateTipoTesteReadFKTEM_ID(object command );
        public IEnumerable<TemplateTipoTesteTenantIDDTO> getTemplateTipoTesteReadFKTenantID(object command );
        public IEnumerable<TemplateTipoTesteUserIdDTO> getTemplateTipoTesteReadFKUserId(object command );
        public bool ExistsByTTT_ID(int value );
        public bool ExistsByTT_ID(int value );
        public bool ExistsByTEM_ID(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public TemplateTipoTesteDTO FirstByTTT_ID(int value );
        public TemplateTipoTesteDTO FirstByTT_ID(int value );
        public TemplateTipoTesteDTO FirstByTEM_ID(int value );
        public TemplateTipoTesteDTO FirstByTenantID(int value );
        public TemplateTipoTesteDTO FirstByDeleted(bool value );
        public TemplateTipoTesteDTO FirstByChanged(DateTime value );
        public TemplateTipoTesteDTO FirstByUserId(int value );
        public IEnumerable<TemplateTipoTesteDTO> GetAllByTTT_ID(int value );
        public IEnumerable<TemplateTipoTesteDTO> GetAllByTT_ID(int value );
        public IEnumerable<TemplateTipoTesteDTO> GetAllByTEM_ID(int value );
        public IEnumerable<TemplateTipoTesteDTO> GetAllByTenantID(int value );
        public IEnumerable<TemplateTipoTesteDTO> GetAllByDeleted(bool value );
        public IEnumerable<TemplateTipoTesteDTO> GetAllByChanged(DateTime value );
        public IEnumerable<TemplateTipoTesteDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration