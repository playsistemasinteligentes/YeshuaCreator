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
    public partial interface IUsuariosCargaReadRepository
    {
        public DataPagination<UsuariosCargaDTO> getUsuariosCarga(ICommandRead command );
        public IEnumerable<UsuariosCargaUSE_IDDTO> getUsuariosCargaReadFKUSE_ID(object command );
        public IEnumerable<UsuariosCargaTenantIDDTO> getUsuariosCargaReadFKTenantID(object command );
        public IEnumerable<UsuariosCargaUserIdDTO> getUsuariosCargaReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByUSE_ID(int value );
        public bool ExistsByCAR_ID(string value );
        public bool ExistsByRGO_ID(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public UsuariosCargaDTO FirstById(int value );
        public UsuariosCargaDTO FirstByUSE_ID(int value );
        public UsuariosCargaDTO FirstByCAR_ID(string value );
        public UsuariosCargaDTO FirstByRGO_ID(string value );
        public UsuariosCargaDTO FirstByTenantID(int value );
        public UsuariosCargaDTO FirstByDeleted(bool value );
        public UsuariosCargaDTO FirstByChanged(DateTime value );
        public UsuariosCargaDTO FirstByUserId(int value );
        public IEnumerable<UsuariosCargaDTO> GetAllById(int value );
        public IEnumerable<UsuariosCargaDTO> GetAllByUSE_ID(int value );
        public IEnumerable<UsuariosCargaDTO> GetAllByCAR_ID(string value );
        public IEnumerable<UsuariosCargaDTO> GetAllByRGO_ID(string value );
        public IEnumerable<UsuariosCargaDTO> GetAllByTenantID(int value );
        public IEnumerable<UsuariosCargaDTO> GetAllByDeleted(bool value );
        public IEnumerable<UsuariosCargaDTO> GetAllByChanged(DateTime value );
        public IEnumerable<UsuariosCargaDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration