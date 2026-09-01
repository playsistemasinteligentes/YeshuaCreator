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
    public partial interface IPerfilReadRepository
    {
        public DataPagination<PerfilDTO> getPerfil(ICommandRead command );
        public IEnumerable<PerfilTenantIDDTO> getPerfilReadFKTenantID(object command );
        public IEnumerable<PerfilUserIdDTO> getPerfilReadFKUserId(object command );
        public bool ExistsByPER_ID(int value );
        public bool ExistsByPER_NOME(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public PerfilDTO FirstByPER_ID(int value );
        public PerfilDTO FirstByPER_NOME(string value );
        public PerfilDTO FirstByTenantID(int value );
        public PerfilDTO FirstByDeleted(bool value );
        public PerfilDTO FirstByChanged(DateTime value );
        public PerfilDTO FirstByUserId(int value );
        public IEnumerable<PerfilDTO> GetAllByPER_ID(int value );
        public IEnumerable<PerfilDTO> GetAllByPER_NOME(string value );
        public IEnumerable<PerfilDTO> GetAllByTenantID(int value );
        public IEnumerable<PerfilDTO> GetAllByDeleted(bool value );
        public IEnumerable<PerfilDTO> GetAllByChanged(DateTime value );
        public IEnumerable<PerfilDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration