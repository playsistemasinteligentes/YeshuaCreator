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
    public partial interface IUsuarioPerfilReadRepository
    {
        public DataPagination<UsuarioPerfilDTO> getUsuarioPerfil(ICommandRead command );
        public IEnumerable<UsuarioPerfilUSE_IDDTO> getUsuarioPerfilReadFKUSE_ID(object command );
        public IEnumerable<UsuarioPerfilPER_IDDTO> getUsuarioPerfilReadFKPER_ID(object command );
        public IEnumerable<UsuarioPerfilTenantIDDTO> getUsuarioPerfilReadFKTenantID(object command );
        public IEnumerable<UsuarioPerfilUserIdDTO> getUsuarioPerfilReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByUSE_ID(int value );
        public bool ExistsByPER_ID(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public UsuarioPerfilDTO FirstById(int value );
        public UsuarioPerfilDTO FirstByUSE_ID(int value );
        public UsuarioPerfilDTO FirstByPER_ID(int value );
        public UsuarioPerfilDTO FirstByTenantID(int value );
        public UsuarioPerfilDTO FirstByDeleted(bool value );
        public UsuarioPerfilDTO FirstByChanged(DateTime value );
        public UsuarioPerfilDTO FirstByUserId(int value );
        public IEnumerable<UsuarioPerfilDTO> GetAllById(int value );
        public IEnumerable<UsuarioPerfilDTO> GetAllByUSE_ID(int value );
        public IEnumerable<UsuarioPerfilDTO> GetAllByPER_ID(int value );
        public IEnumerable<UsuarioPerfilDTO> GetAllByTenantID(int value );
        public IEnumerable<UsuarioPerfilDTO> GetAllByDeleted(bool value );
        public IEnumerable<UsuarioPerfilDTO> GetAllByChanged(DateTime value );
        public IEnumerable<UsuarioPerfilDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration