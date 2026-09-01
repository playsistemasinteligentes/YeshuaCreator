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
    public partial interface IIndicadoresDepartamentosReadRepository
    {
        public DataPagination<IndicadoresDepartamentosDTO> getIndicadoresDepartamentos(ICommandRead command );
        public IEnumerable<IndicadoresDepartamentosDEP_IDDTO> getIndicadoresDepartamentosReadFKDEP_ID(object command );
        public IEnumerable<IndicadoresDepartamentosIND_IDDTO> getIndicadoresDepartamentosReadFKIND_ID(object command );
        public IEnumerable<IndicadoresDepartamentosTenantIDDTO> getIndicadoresDepartamentosReadFKTenantID(object command );
        public IEnumerable<IndicadoresDepartamentosUserIdDTO> getIndicadoresDepartamentosReadFKUserId(object command );
        public bool ExistsByINDDEP_ID(int value );
        public bool ExistsByDEP_ID(int value );
        public bool ExistsByIND_ID(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public IndicadoresDepartamentosDTO FirstByINDDEP_ID(int value );
        public IndicadoresDepartamentosDTO FirstByDEP_ID(int value );
        public IndicadoresDepartamentosDTO FirstByIND_ID(int value );
        public IndicadoresDepartamentosDTO FirstByTenantID(int value );
        public IndicadoresDepartamentosDTO FirstByDeleted(bool value );
        public IndicadoresDepartamentosDTO FirstByChanged(DateTime value );
        public IndicadoresDepartamentosDTO FirstByUserId(int value );
        public IEnumerable<IndicadoresDepartamentosDTO> GetAllByINDDEP_ID(int value );
        public IEnumerable<IndicadoresDepartamentosDTO> GetAllByDEP_ID(int value );
        public IEnumerable<IndicadoresDepartamentosDTO> GetAllByIND_ID(int value );
        public IEnumerable<IndicadoresDepartamentosDTO> GetAllByTenantID(int value );
        public IEnumerable<IndicadoresDepartamentosDTO> GetAllByDeleted(bool value );
        public IEnumerable<IndicadoresDepartamentosDTO> GetAllByChanged(DateTime value );
        public IEnumerable<IndicadoresDepartamentosDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration