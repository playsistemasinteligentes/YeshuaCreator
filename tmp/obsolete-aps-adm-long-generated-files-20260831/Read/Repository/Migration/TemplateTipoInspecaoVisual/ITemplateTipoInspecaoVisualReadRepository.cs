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
    public partial interface ITemplateTipoInspecaoVisualReadRepository
    {
        public DataPagination<TemplateTipoInspecaoVisualDTO> getTemplateTipoInspecaoVisual(ICommandRead command );
        public IEnumerable<TemplateTipoInspecaoVisualTEM_IDDTO> getTemplateTipoInspecaoVisualReadFKTEM_ID(object command );
        public IEnumerable<TemplateTipoInspecaoVisualTenantIDDTO> getTemplateTipoInspecaoVisualReadFKTenantID(object command );
        public IEnumerable<TemplateTipoInspecaoVisualUserIdDTO> getTemplateTipoInspecaoVisualReadFKUserId(object command );
        public bool ExistsByTTI_ID(int value );
        public bool ExistsByTIV_ID(int value );
        public bool ExistsByTEM_ID(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public TemplateTipoInspecaoVisualDTO FirstByTTI_ID(int value );
        public TemplateTipoInspecaoVisualDTO FirstByTIV_ID(int value );
        public TemplateTipoInspecaoVisualDTO FirstByTEM_ID(int value );
        public TemplateTipoInspecaoVisualDTO FirstByTenantID(int value );
        public TemplateTipoInspecaoVisualDTO FirstByDeleted(bool value );
        public TemplateTipoInspecaoVisualDTO FirstByChanged(DateTime value );
        public TemplateTipoInspecaoVisualDTO FirstByUserId(int value );
        public IEnumerable<TemplateTipoInspecaoVisualDTO> GetAllByTTI_ID(int value );
        public IEnumerable<TemplateTipoInspecaoVisualDTO> GetAllByTIV_ID(int value );
        public IEnumerable<TemplateTipoInspecaoVisualDTO> GetAllByTEM_ID(int value );
        public IEnumerable<TemplateTipoInspecaoVisualDTO> GetAllByTenantID(int value );
        public IEnumerable<TemplateTipoInspecaoVisualDTO> GetAllByDeleted(bool value );
        public IEnumerable<TemplateTipoInspecaoVisualDTO> GetAllByChanged(DateTime value );
        public IEnumerable<TemplateTipoInspecaoVisualDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration