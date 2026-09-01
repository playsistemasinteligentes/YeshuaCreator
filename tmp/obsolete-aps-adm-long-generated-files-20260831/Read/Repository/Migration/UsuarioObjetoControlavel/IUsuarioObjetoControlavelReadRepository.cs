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
    public partial interface IUsuarioObjetoControlavelReadRepository
    {
        public DataPagination<UsuarioObjetoControlavelDTO> getUsuarioObjetoControlavel(ICommandRead command );
        public IEnumerable<UsuarioObjetoControlavelUSE_IDDTO> getUsuarioObjetoControlavelReadFKUSE_ID(object command );
        public IEnumerable<UsuarioObjetoControlavelTenantIDDTO> getUsuarioObjetoControlavelReadFKTenantID(object command );
        public IEnumerable<UsuarioObjetoControlavelUserIdDTO> getUsuarioObjetoControlavelReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByUSE_ID(int value );
        public bool ExistsByOBJ_ID(string value );
        public bool ExistsByUSU_OBJETO_ACAO(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public UsuarioObjetoControlavelDTO FirstById(int value );
        public UsuarioObjetoControlavelDTO FirstByUSE_ID(int value );
        public UsuarioObjetoControlavelDTO FirstByOBJ_ID(string value );
        public UsuarioObjetoControlavelDTO FirstByUSU_OBJETO_ACAO(string value );
        public UsuarioObjetoControlavelDTO FirstByTenantID(int value );
        public UsuarioObjetoControlavelDTO FirstByDeleted(bool value );
        public UsuarioObjetoControlavelDTO FirstByChanged(DateTime value );
        public UsuarioObjetoControlavelDTO FirstByUserId(int value );
        public IEnumerable<UsuarioObjetoControlavelDTO> GetAllById(int value );
        public IEnumerable<UsuarioObjetoControlavelDTO> GetAllByUSE_ID(int value );
        public IEnumerable<UsuarioObjetoControlavelDTO> GetAllByOBJ_ID(string value );
        public IEnumerable<UsuarioObjetoControlavelDTO> GetAllByUSU_OBJETO_ACAO(string value );
        public IEnumerable<UsuarioObjetoControlavelDTO> GetAllByTenantID(int value );
        public IEnumerable<UsuarioObjetoControlavelDTO> GetAllByDeleted(bool value );
        public IEnumerable<UsuarioObjetoControlavelDTO> GetAllByChanged(DateTime value );
        public IEnumerable<UsuarioObjetoControlavelDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration