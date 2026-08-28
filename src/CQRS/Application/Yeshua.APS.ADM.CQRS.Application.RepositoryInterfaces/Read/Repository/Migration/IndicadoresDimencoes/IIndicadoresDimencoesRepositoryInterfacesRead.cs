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
    public partial interface IIndicadoresDimencoesReadRepository
    {
        public DataPagination<IndicadoresDimencoesDTO> getIndicadoresDimencoes(ICommandRead command );
        public IEnumerable<IndicadoresDimencoesIND_IDDTO> getIndicadoresDimencoesReadFKIND_ID(object command );
        public IEnumerable<IndicadoresDimencoesTenantIDDTO> getIndicadoresDimencoesReadFKTenantID(object command );
        public IEnumerable<IndicadoresDimencoesUserIdDTO> getIndicadoresDimencoesReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByDIM_ID(int value );
        public bool ExistsByIND_ID(int value );
        public bool ExistsByDIM_DESCRICAO(string value );
        public bool ExistsByDIM_SQL(string value );
        public bool ExistsByDIM_CONEXAO(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public IndicadoresDimencoesDTO FirstById(int value );
        public IndicadoresDimencoesDTO FirstByDIM_ID(int value );
        public IndicadoresDimencoesDTO FirstByIND_ID(int value );
        public IndicadoresDimencoesDTO FirstByDIM_DESCRICAO(string value );
        public IndicadoresDimencoesDTO FirstByDIM_SQL(string value );
        public IndicadoresDimencoesDTO FirstByDIM_CONEXAO(string value );
        public IndicadoresDimencoesDTO FirstByTenantID(int value );
        public IndicadoresDimencoesDTO FirstByDeleted(bool value );
        public IndicadoresDimencoesDTO FirstByChanged(DateTime value );
        public IndicadoresDimencoesDTO FirstByUserId(int value );
        public IEnumerable<IndicadoresDimencoesDTO> GetAllById(int value );
        public IEnumerable<IndicadoresDimencoesDTO> GetAllByDIM_ID(int value );
        public IEnumerable<IndicadoresDimencoesDTO> GetAllByIND_ID(int value );
        public IEnumerable<IndicadoresDimencoesDTO> GetAllByDIM_DESCRICAO(string value );
        public IEnumerable<IndicadoresDimencoesDTO> GetAllByDIM_SQL(string value );
        public IEnumerable<IndicadoresDimencoesDTO> GetAllByDIM_CONEXAO(string value );
        public IEnumerable<IndicadoresDimencoesDTO> GetAllByTenantID(int value );
        public IEnumerable<IndicadoresDimencoesDTO> GetAllByDeleted(bool value );
        public IEnumerable<IndicadoresDimencoesDTO> GetAllByChanged(DateTime value );
        public IEnumerable<IndicadoresDimencoesDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration