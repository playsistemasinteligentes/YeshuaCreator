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
    public partial interface IConsultasIndicadoresReadRepository
    {
        public DataPagination<ConsultasIndicadoresDTO> getConsultasIndicadores(ICommandRead command );
        public IEnumerable<ConsultasIndicadoresTenantIDDTO> getConsultasIndicadoresReadFKTenantID(object command );
        public IEnumerable<ConsultasIndicadoresUserIdDTO> getConsultasIndicadoresReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByCON_ID(int value );
        public bool ExistsByIND_ID(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public ConsultasIndicadoresDTO FirstById(int value );
        public ConsultasIndicadoresDTO FirstByCON_ID(int value );
        public ConsultasIndicadoresDTO FirstByIND_ID(int value );
        public ConsultasIndicadoresDTO FirstByTenantID(int value );
        public ConsultasIndicadoresDTO FirstByDeleted(bool value );
        public ConsultasIndicadoresDTO FirstByChanged(DateTime value );
        public ConsultasIndicadoresDTO FirstByUserId(int value );
        public IEnumerable<ConsultasIndicadoresDTO> GetAllById(int value );
        public IEnumerable<ConsultasIndicadoresDTO> GetAllByCON_ID(int value );
        public IEnumerable<ConsultasIndicadoresDTO> GetAllByIND_ID(int value );
        public IEnumerable<ConsultasIndicadoresDTO> GetAllByTenantID(int value );
        public IEnumerable<ConsultasIndicadoresDTO> GetAllByDeleted(bool value );
        public IEnumerable<ConsultasIndicadoresDTO> GetAllByChanged(DateTime value );
        public IEnumerable<ConsultasIndicadoresDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration