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
    public partial interface IUsuarioReadRepository
    {
        public DataPagination<UsuarioDTO> getUsuario(ICommandRead command );
        public IEnumerable<UsuarioTURM_IDDTO> getUsuarioReadFKTURM_ID(object command );
        public IEnumerable<UsuarioTenantIDDTO> getUsuarioReadFKTenantID(object command );
        public IEnumerable<UsuarioUserIdDTO> getUsuarioReadFKUserId(object command );
        public bool ExistsByUSE_ID(int value );
        public bool ExistsByUSE_NOME(string value );
        public bool ExistsByUSE_EMAIL(string value );
        public bool ExistsByUSE_SENHA(string value );
        public bool ExistsByTURM_ID(string value );
        public bool ExistsByUSE_ATIVO(int value );
        public bool ExistsByUSE_CODERP(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public UsuarioDTO FirstByUSE_ID(int value );
        public UsuarioDTO FirstByUSE_NOME(string value );
        public UsuarioDTO FirstByUSE_EMAIL(string value );
        public UsuarioDTO FirstByUSE_SENHA(string value );
        public UsuarioDTO FirstByTURM_ID(string value );
        public UsuarioDTO FirstByUSE_ATIVO(int value );
        public UsuarioDTO FirstByUSE_CODERP(string value );
        public UsuarioDTO FirstByTenantID(int value );
        public UsuarioDTO FirstByDeleted(bool value );
        public UsuarioDTO FirstByChanged(DateTime value );
        public UsuarioDTO FirstByUserId(int value );
        public IEnumerable<UsuarioDTO> GetAllByUSE_ID(int value );
        public IEnumerable<UsuarioDTO> GetAllByUSE_NOME(string value );
        public IEnumerable<UsuarioDTO> GetAllByUSE_EMAIL(string value );
        public IEnumerable<UsuarioDTO> GetAllByUSE_SENHA(string value );
        public IEnumerable<UsuarioDTO> GetAllByTURM_ID(string value );
        public IEnumerable<UsuarioDTO> GetAllByUSE_ATIVO(int value );
        public IEnumerable<UsuarioDTO> GetAllByUSE_CODERP(string value );
        public IEnumerable<UsuarioDTO> GetAllByTenantID(int value );
        public IEnumerable<UsuarioDTO> GetAllByDeleted(bool value );
        public IEnumerable<UsuarioDTO> GetAllByChanged(DateTime value );
        public IEnumerable<UsuarioDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration