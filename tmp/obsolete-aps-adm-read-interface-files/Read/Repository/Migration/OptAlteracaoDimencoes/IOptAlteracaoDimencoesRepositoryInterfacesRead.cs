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
    public partial interface IOptAlteracaoDimencoesReadRepository
    {
        public DataPagination<OptAlteracaoDimencoesDTO> getOptAlteracaoDimencoes(ICommandRead command );
        public IEnumerable<OptAlteracaoDimencoesTenantIDDTO> getOptAlteracaoDimencoesReadFKTenantID(object command );
        public IEnumerable<OptAlteracaoDimencoesUserIdDTO> getOptAlteracaoDimencoesReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByOAD_ID(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public OptAlteracaoDimencoesDTO FirstById(int value );
        public OptAlteracaoDimencoesDTO FirstByOAD_ID(int value );
        public OptAlteracaoDimencoesDTO FirstByTenantID(int value );
        public OptAlteracaoDimencoesDTO FirstByDeleted(bool value );
        public OptAlteracaoDimencoesDTO FirstByChanged(DateTime value );
        public OptAlteracaoDimencoesDTO FirstByUserId(int value );
        public IEnumerable<OptAlteracaoDimencoesDTO> GetAllById(int value );
        public IEnumerable<OptAlteracaoDimencoesDTO> GetAllByOAD_ID(int value );
        public IEnumerable<OptAlteracaoDimencoesDTO> GetAllByTenantID(int value );
        public IEnumerable<OptAlteracaoDimencoesDTO> GetAllByDeleted(bool value );
        public IEnumerable<OptAlteracaoDimencoesDTO> GetAllByChanged(DateTime value );
        public IEnumerable<OptAlteracaoDimencoesDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration