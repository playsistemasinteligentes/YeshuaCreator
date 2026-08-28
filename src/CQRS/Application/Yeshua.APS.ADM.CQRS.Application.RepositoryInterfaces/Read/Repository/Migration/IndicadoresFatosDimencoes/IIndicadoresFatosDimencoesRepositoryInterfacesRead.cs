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
    public partial interface IIndicadoresFatosDimencoesReadRepository
    {
        public DataPagination<IndicadoresFatosDimencoesDTO> getIndicadoresFatosDimencoes(ICommandRead command );
        public IEnumerable<IndicadoresFatosDimencoesIND_IDDTO> getIndicadoresFatosDimencoesReadFKIND_ID(object command );
        public IEnumerable<IndicadoresFatosDimencoesTenantIDDTO> getIndicadoresFatosDimencoesReadFKTenantID(object command );
        public IEnumerable<IndicadoresFatosDimencoesUserIdDTO> getIndicadoresFatosDimencoesReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByFAT_ID(string value );
        public bool ExistsByIND_ID(int value );
        public bool ExistsByDIM_ID(int value );
        public bool ExistsByFAT_DESCRICAO(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public IndicadoresFatosDimencoesDTO FirstById(int value );
        public IndicadoresFatosDimencoesDTO FirstByFAT_ID(string value );
        public IndicadoresFatosDimencoesDTO FirstByIND_ID(int value );
        public IndicadoresFatosDimencoesDTO FirstByDIM_ID(int value );
        public IndicadoresFatosDimencoesDTO FirstByFAT_DESCRICAO(string value );
        public IndicadoresFatosDimencoesDTO FirstByTenantID(int value );
        public IndicadoresFatosDimencoesDTO FirstByDeleted(bool value );
        public IndicadoresFatosDimencoesDTO FirstByChanged(DateTime value );
        public IndicadoresFatosDimencoesDTO FirstByUserId(int value );
        public IEnumerable<IndicadoresFatosDimencoesDTO> GetAllById(int value );
        public IEnumerable<IndicadoresFatosDimencoesDTO> GetAllByFAT_ID(string value );
        public IEnumerable<IndicadoresFatosDimencoesDTO> GetAllByIND_ID(int value );
        public IEnumerable<IndicadoresFatosDimencoesDTO> GetAllByDIM_ID(int value );
        public IEnumerable<IndicadoresFatosDimencoesDTO> GetAllByFAT_DESCRICAO(string value );
        public IEnumerable<IndicadoresFatosDimencoesDTO> GetAllByTenantID(int value );
        public IEnumerable<IndicadoresFatosDimencoesDTO> GetAllByDeleted(bool value );
        public IEnumerable<IndicadoresFatosDimencoesDTO> GetAllByChanged(DateTime value );
        public IEnumerable<IndicadoresFatosDimencoesDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration