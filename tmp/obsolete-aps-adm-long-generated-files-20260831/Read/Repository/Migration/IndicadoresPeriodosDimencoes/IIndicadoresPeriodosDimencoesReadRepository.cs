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
    public partial interface IIndicadoresPeriodosDimencoesReadRepository
    {
        public DataPagination<IndicadoresPeriodosDimencoesDTO> getIndicadoresPeriodosDimencoes(ICommandRead command );
        public IEnumerable<IndicadoresPeriodosDimencoesIND_IDDTO> getIndicadoresPeriodosDimencoesReadFKIND_ID(object command );
        public IEnumerable<IndicadoresPeriodosDimencoesTenantIDDTO> getIndicadoresPeriodosDimencoesReadFKTenantID(object command );
        public IEnumerable<IndicadoresPeriodosDimencoesUserIdDTO> getIndicadoresPeriodosDimencoesReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByPER_ID(string value );
        public bool ExistsByIND_ID(int value );
        public bool ExistsByDIM_ID(int value );
        public bool ExistsByPER_DESCRICAO(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public IndicadoresPeriodosDimencoesDTO FirstById(int value );
        public IndicadoresPeriodosDimencoesDTO FirstByPER_ID(string value );
        public IndicadoresPeriodosDimencoesDTO FirstByIND_ID(int value );
        public IndicadoresPeriodosDimencoesDTO FirstByDIM_ID(int value );
        public IndicadoresPeriodosDimencoesDTO FirstByPER_DESCRICAO(string value );
        public IndicadoresPeriodosDimencoesDTO FirstByTenantID(int value );
        public IndicadoresPeriodosDimencoesDTO FirstByDeleted(bool value );
        public IndicadoresPeriodosDimencoesDTO FirstByChanged(DateTime value );
        public IndicadoresPeriodosDimencoesDTO FirstByUserId(int value );
        public IEnumerable<IndicadoresPeriodosDimencoesDTO> GetAllById(int value );
        public IEnumerable<IndicadoresPeriodosDimencoesDTO> GetAllByPER_ID(string value );
        public IEnumerable<IndicadoresPeriodosDimencoesDTO> GetAllByIND_ID(int value );
        public IEnumerable<IndicadoresPeriodosDimencoesDTO> GetAllByDIM_ID(int value );
        public IEnumerable<IndicadoresPeriodosDimencoesDTO> GetAllByPER_DESCRICAO(string value );
        public IEnumerable<IndicadoresPeriodosDimencoesDTO> GetAllByTenantID(int value );
        public IEnumerable<IndicadoresPeriodosDimencoesDTO> GetAllByDeleted(bool value );
        public IEnumerable<IndicadoresPeriodosDimencoesDTO> GetAllByChanged(DateTime value );
        public IEnumerable<IndicadoresPeriodosDimencoesDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration