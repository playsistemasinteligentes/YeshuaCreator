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
    public partial interface IParamReadRepository
    {
        public DataPagination<ParamDTO> getParam(ICommandRead command );
        public IEnumerable<ParamTenantIDDTO> getParamReadFKTenantID(object command );
        public IEnumerable<ParamUserIdDTO> getParamReadFKUserId(object command );
        public bool ExistsByPAR_ID(string value );
        public bool ExistsByPAR_DESCRICAO(string value );
        public bool ExistsByPAR_VALOR_S(string value );
        public bool ExistsByPAR_VALOR_N(Decimal value );
        public bool ExistsByPAR_VALOR_D(DateTime value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public ParamDTO FirstByPAR_ID(string value );
        public ParamDTO FirstByPAR_DESCRICAO(string value );
        public ParamDTO FirstByPAR_VALOR_S(string value );
        public ParamDTO FirstByPAR_VALOR_N(Decimal value );
        public ParamDTO FirstByPAR_VALOR_D(DateTime value );
        public ParamDTO FirstByTenantID(int value );
        public ParamDTO FirstByDeleted(bool value );
        public ParamDTO FirstByChanged(DateTime value );
        public ParamDTO FirstByUserId(int value );
        public IEnumerable<ParamDTO> GetAllByPAR_ID(string value );
        public IEnumerable<ParamDTO> GetAllByPAR_DESCRICAO(string value );
        public IEnumerable<ParamDTO> GetAllByPAR_VALOR_S(string value );
        public IEnumerable<ParamDTO> GetAllByPAR_VALOR_N(Decimal value );
        public IEnumerable<ParamDTO> GetAllByPAR_VALOR_D(DateTime value );
        public IEnumerable<ParamDTO> GetAllByTenantID(int value );
        public IEnumerable<ParamDTO> GetAllByDeleted(bool value );
        public IEnumerable<ParamDTO> GetAllByChanged(DateTime value );
        public IEnumerable<ParamDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration