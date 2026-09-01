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
    public partial interface IConsultasGruposReadRepository
    {
        public DataPagination<ConsultasGruposDTO> getConsultasGrupos(ICommandRead command );
        public IEnumerable<ConsultasGruposTenantIDDTO> getConsultasGruposReadFKTenantID(object command );
        public IEnumerable<ConsultasGruposUserIdDTO> getConsultasGruposReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByCON_ID(int value );
        public bool ExistsByGRU_ID(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public ConsultasGruposDTO FirstById(int value );
        public ConsultasGruposDTO FirstByCON_ID(int value );
        public ConsultasGruposDTO FirstByGRU_ID(int value );
        public ConsultasGruposDTO FirstByTenantID(int value );
        public ConsultasGruposDTO FirstByDeleted(bool value );
        public ConsultasGruposDTO FirstByChanged(DateTime value );
        public ConsultasGruposDTO FirstByUserId(int value );
        public IEnumerable<ConsultasGruposDTO> GetAllById(int value );
        public IEnumerable<ConsultasGruposDTO> GetAllByCON_ID(int value );
        public IEnumerable<ConsultasGruposDTO> GetAllByGRU_ID(int value );
        public IEnumerable<ConsultasGruposDTO> GetAllByTenantID(int value );
        public IEnumerable<ConsultasGruposDTO> GetAllByDeleted(bool value );
        public IEnumerable<ConsultasGruposDTO> GetAllByChanged(DateTime value );
        public IEnumerable<ConsultasGruposDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration