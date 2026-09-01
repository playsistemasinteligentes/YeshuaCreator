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
    public partial interface IUnidadeMedidaReadRepository
    {
        public DataPagination<UnidadeMedidaDTO> getUnidadeMedida(ICommandRead command );
        public IEnumerable<UnidadeMedidaTenantIDDTO> getUnidadeMedidaReadFKTenantID(object command );
        public IEnumerable<UnidadeMedidaUserIdDTO> getUnidadeMedidaReadFKUserId(object command );
        public bool ExistsByUNI_ID(string value );
        public bool ExistsByUNI_DESCRICAO(string value );
        public bool ExistsByUNI_ESCALA_TEMPO(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public UnidadeMedidaDTO FirstByUNI_ID(string value );
        public UnidadeMedidaDTO FirstByUNI_DESCRICAO(string value );
        public UnidadeMedidaDTO FirstByUNI_ESCALA_TEMPO(string value );
        public UnidadeMedidaDTO FirstByTenantID(int value );
        public UnidadeMedidaDTO FirstByDeleted(bool value );
        public UnidadeMedidaDTO FirstByChanged(DateTime value );
        public UnidadeMedidaDTO FirstByUserId(int value );
        public IEnumerable<UnidadeMedidaDTO> GetAllByUNI_ID(string value );
        public IEnumerable<UnidadeMedidaDTO> GetAllByUNI_DESCRICAO(string value );
        public IEnumerable<UnidadeMedidaDTO> GetAllByUNI_ESCALA_TEMPO(string value );
        public IEnumerable<UnidadeMedidaDTO> GetAllByTenantID(int value );
        public IEnumerable<UnidadeMedidaDTO> GetAllByDeleted(bool value );
        public IEnumerable<UnidadeMedidaDTO> GetAllByChanged(DateTime value );
        public IEnumerable<UnidadeMedidaDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration