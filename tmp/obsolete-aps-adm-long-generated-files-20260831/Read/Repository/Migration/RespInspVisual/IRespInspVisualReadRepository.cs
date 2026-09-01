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
    public partial interface IRespInspVisualReadRepository
    {
        public DataPagination<RespInspVisualDTO> getRespInspVisual(ICommandRead command );
        public IEnumerable<RespInspVisualTenantIDDTO> getRespInspVisualReadFKTenantID(object command );
        public IEnumerable<RespInspVisualUserIdDTO> getRespInspVisualReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByRIV_ID(int value );
        public bool ExistsByIPV_ID(int value );
        public bool ExistsByITI_ID(int value );
        public bool ExistsByRIV_STATUS(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public RespInspVisualDTO FirstById(int value );
        public RespInspVisualDTO FirstByRIV_ID(int value );
        public RespInspVisualDTO FirstByIPV_ID(int value );
        public RespInspVisualDTO FirstByITI_ID(int value );
        public RespInspVisualDTO FirstByRIV_STATUS(string value );
        public RespInspVisualDTO FirstByTenantID(int value );
        public RespInspVisualDTO FirstByDeleted(bool value );
        public RespInspVisualDTO FirstByChanged(DateTime value );
        public RespInspVisualDTO FirstByUserId(int value );
        public IEnumerable<RespInspVisualDTO> GetAllById(int value );
        public IEnumerable<RespInspVisualDTO> GetAllByRIV_ID(int value );
        public IEnumerable<RespInspVisualDTO> GetAllByIPV_ID(int value );
        public IEnumerable<RespInspVisualDTO> GetAllByITI_ID(int value );
        public IEnumerable<RespInspVisualDTO> GetAllByRIV_STATUS(string value );
        public IEnumerable<RespInspVisualDTO> GetAllByTenantID(int value );
        public IEnumerable<RespInspVisualDTO> GetAllByDeleted(bool value );
        public IEnumerable<RespInspVisualDTO> GetAllByChanged(DateTime value );
        public IEnumerable<RespInspVisualDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration