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
    public partial interface ICalendarioReadRepository
    {
        public DataPagination<CalendarioDTO> getCalendario(ICommandRead command );
        public IEnumerable<CalendarioTenantIDDTO> getCalendarioReadFKTenantID(object command );
        public IEnumerable<CalendarioUserIdDTO> getCalendarioReadFKUserId(object command );
        public bool ExistsByCAL_ID(int value );
        public bool ExistsByCAL_DESCRICAO(string value );
        public bool ExistsByCAL_DIVIDE_DIA_EM(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public CalendarioDTO FirstByCAL_ID(int value );
        public CalendarioDTO FirstByCAL_DESCRICAO(string value );
        public CalendarioDTO FirstByCAL_DIVIDE_DIA_EM(int value );
        public CalendarioDTO FirstByTenantID(int value );
        public CalendarioDTO FirstByDeleted(bool value );
        public CalendarioDTO FirstByChanged(DateTime value );
        public CalendarioDTO FirstByUserId(int value );
        public IEnumerable<CalendarioDTO> GetAllByCAL_ID(int value );
        public IEnumerable<CalendarioDTO> GetAllByCAL_DESCRICAO(string value );
        public IEnumerable<CalendarioDTO> GetAllByCAL_DIVIDE_DIA_EM(int value );
        public IEnumerable<CalendarioDTO> GetAllByTenantID(int value );
        public IEnumerable<CalendarioDTO> GetAllByDeleted(bool value );
        public IEnumerable<CalendarioDTO> GetAllByChanged(DateTime value );
        public IEnumerable<CalendarioDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration