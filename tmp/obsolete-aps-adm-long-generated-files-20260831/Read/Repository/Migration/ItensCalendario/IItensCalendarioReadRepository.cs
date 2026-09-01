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
    public partial interface IItensCalendarioReadRepository
    {
        public DataPagination<ItensCalendarioDTO> getItensCalendario(ICommandRead command );
        public IEnumerable<ItensCalendarioURM_IDDTO> getItensCalendarioReadFKURM_ID(object command );
        public IEnumerable<ItensCalendarioURN_IDDTO> getItensCalendarioReadFKURN_ID(object command );
        public IEnumerable<ItensCalendarioCAL_IDDTO> getItensCalendarioReadFKCAL_ID(object command );
        public IEnumerable<ItensCalendarioTenantIDDTO> getItensCalendarioReadFKTenantID(object command );
        public IEnumerable<ItensCalendarioUserIdDTO> getItensCalendarioReadFKUserId(object command );
        public bool ExistsByICA_ID(int value );
        public bool ExistsByICA_DATA_DE(DateTime value );
        public bool ExistsByICA_DATA_ATE(DateTime value );
        public bool ExistsByICA_OBSERVACAO(string value );
        public bool ExistsByICA_TIPO(int value );
        public bool ExistsByURM_ID(string value );
        public bool ExistsByURN_ID(string value );
        public bool ExistsByCAL_ID(int value );
        public bool ExistsByMAQ_ID(string value );
        public bool ExistsByPRO_ID(string value );
        public bool ExistsByICA_LIMPESA_MAQUINA(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public ItensCalendarioDTO FirstByICA_ID(int value );
        public ItensCalendarioDTO FirstByICA_DATA_DE(DateTime value );
        public ItensCalendarioDTO FirstByICA_DATA_ATE(DateTime value );
        public ItensCalendarioDTO FirstByICA_OBSERVACAO(string value );
        public ItensCalendarioDTO FirstByICA_TIPO(int value );
        public ItensCalendarioDTO FirstByURM_ID(string value );
        public ItensCalendarioDTO FirstByURN_ID(string value );
        public ItensCalendarioDTO FirstByCAL_ID(int value );
        public ItensCalendarioDTO FirstByMAQ_ID(string value );
        public ItensCalendarioDTO FirstByPRO_ID(string value );
        public ItensCalendarioDTO FirstByICA_LIMPESA_MAQUINA(int value );
        public ItensCalendarioDTO FirstByTenantID(int value );
        public ItensCalendarioDTO FirstByDeleted(bool value );
        public ItensCalendarioDTO FirstByChanged(DateTime value );
        public ItensCalendarioDTO FirstByUserId(int value );
        public IEnumerable<ItensCalendarioDTO> GetAllByICA_ID(int value );
        public IEnumerable<ItensCalendarioDTO> GetAllByICA_DATA_DE(DateTime value );
        public IEnumerable<ItensCalendarioDTO> GetAllByICA_DATA_ATE(DateTime value );
        public IEnumerable<ItensCalendarioDTO> GetAllByICA_OBSERVACAO(string value );
        public IEnumerable<ItensCalendarioDTO> GetAllByICA_TIPO(int value );
        public IEnumerable<ItensCalendarioDTO> GetAllByURM_ID(string value );
        public IEnumerable<ItensCalendarioDTO> GetAllByURN_ID(string value );
        public IEnumerable<ItensCalendarioDTO> GetAllByCAL_ID(int value );
        public IEnumerable<ItensCalendarioDTO> GetAllByMAQ_ID(string value );
        public IEnumerable<ItensCalendarioDTO> GetAllByPRO_ID(string value );
        public IEnumerable<ItensCalendarioDTO> GetAllByICA_LIMPESA_MAQUINA(int value );
        public IEnumerable<ItensCalendarioDTO> GetAllByTenantID(int value );
        public IEnumerable<ItensCalendarioDTO> GetAllByDeleted(bool value );
        public IEnumerable<ItensCalendarioDTO> GetAllByChanged(DateTime value );
        public IEnumerable<ItensCalendarioDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration