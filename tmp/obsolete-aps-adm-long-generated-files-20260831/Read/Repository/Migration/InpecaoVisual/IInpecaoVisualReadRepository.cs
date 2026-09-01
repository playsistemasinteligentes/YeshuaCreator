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
    public partial interface IInpecaoVisualReadRepository
    {
        public DataPagination<InpecaoVisualDTO> getInpecaoVisual(ICommandRead command );
        public IEnumerable<InpecaoVisualTenantIDDTO> getInpecaoVisualReadFKTenantID(object command );
        public IEnumerable<InpecaoVisualUserIdDTO> getInpecaoVisualReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByIPV_ID(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public InpecaoVisualDTO FirstById(int value );
        public InpecaoVisualDTO FirstByIPV_ID(int value );
        public InpecaoVisualDTO FirstByTenantID(int value );
        public InpecaoVisualDTO FirstByDeleted(bool value );
        public InpecaoVisualDTO FirstByChanged(DateTime value );
        public InpecaoVisualDTO FirstByUserId(int value );
        public IEnumerable<InpecaoVisualDTO> GetAllById(int value );
        public IEnumerable<InpecaoVisualDTO> GetAllByIPV_ID(int value );
        public IEnumerable<InpecaoVisualDTO> GetAllByTenantID(int value );
        public IEnumerable<InpecaoVisualDTO> GetAllByDeleted(bool value );
        public IEnumerable<InpecaoVisualDTO> GetAllByChanged(DateTime value );
        public IEnumerable<InpecaoVisualDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration