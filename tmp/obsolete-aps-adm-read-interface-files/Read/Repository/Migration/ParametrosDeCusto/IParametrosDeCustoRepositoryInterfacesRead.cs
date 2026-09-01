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
    public partial interface IParametrosDeCustoReadRepository
    {
        public DataPagination<ParametrosDeCustoDTO> getParametrosDeCusto(ICommandRead command );
        public IEnumerable<ParametrosDeCustoTenantIDDTO> getParametrosDeCustoReadFKTenantID(object command );
        public IEnumerable<ParametrosDeCustoUserIdDTO> getParametrosDeCustoReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByPAR_ID(int value );
        public bool ExistsByPRO_ID(string value );
        public bool ExistsByCUS_ID(string value );
        public bool ExistsByPAR_VALOR(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public ParametrosDeCustoDTO FirstById(int value );
        public ParametrosDeCustoDTO FirstByPAR_ID(int value );
        public ParametrosDeCustoDTO FirstByPRO_ID(string value );
        public ParametrosDeCustoDTO FirstByCUS_ID(string value );
        public ParametrosDeCustoDTO FirstByPAR_VALOR(string value );
        public ParametrosDeCustoDTO FirstByTenantID(int value );
        public ParametrosDeCustoDTO FirstByDeleted(bool value );
        public ParametrosDeCustoDTO FirstByChanged(DateTime value );
        public ParametrosDeCustoDTO FirstByUserId(int value );
        public IEnumerable<ParametrosDeCustoDTO> GetAllById(int value );
        public IEnumerable<ParametrosDeCustoDTO> GetAllByPAR_ID(int value );
        public IEnumerable<ParametrosDeCustoDTO> GetAllByPRO_ID(string value );
        public IEnumerable<ParametrosDeCustoDTO> GetAllByCUS_ID(string value );
        public IEnumerable<ParametrosDeCustoDTO> GetAllByPAR_VALOR(string value );
        public IEnumerable<ParametrosDeCustoDTO> GetAllByTenantID(int value );
        public IEnumerable<ParametrosDeCustoDTO> GetAllByDeleted(bool value );
        public IEnumerable<ParametrosDeCustoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<ParametrosDeCustoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration