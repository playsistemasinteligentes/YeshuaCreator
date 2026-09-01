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
    public partial interface IPerfilObjetoControlavelReadRepository
    {
        public DataPagination<PerfilObjetoControlavelDTO> getPerfilObjetoControlavel(ICommandRead command );
        public IEnumerable<PerfilObjetoControlavelPER_IDDTO> getPerfilObjetoControlavelReadFKPER_ID(object command );
        public IEnumerable<PerfilObjetoControlavelTenantIDDTO> getPerfilObjetoControlavelReadFKTenantID(object command );
        public IEnumerable<PerfilObjetoControlavelUserIdDTO> getPerfilObjetoControlavelReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByPER_ID(int value );
        public bool ExistsByOBJ_ID(string value );
        public bool ExistsByPEO_ACAO(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public PerfilObjetoControlavelDTO FirstById(int value );
        public PerfilObjetoControlavelDTO FirstByPER_ID(int value );
        public PerfilObjetoControlavelDTO FirstByOBJ_ID(string value );
        public PerfilObjetoControlavelDTO FirstByPEO_ACAO(string value );
        public PerfilObjetoControlavelDTO FirstByTenantID(int value );
        public PerfilObjetoControlavelDTO FirstByDeleted(bool value );
        public PerfilObjetoControlavelDTO FirstByChanged(DateTime value );
        public PerfilObjetoControlavelDTO FirstByUserId(int value );
        public IEnumerable<PerfilObjetoControlavelDTO> GetAllById(int value );
        public IEnumerable<PerfilObjetoControlavelDTO> GetAllByPER_ID(int value );
        public IEnumerable<PerfilObjetoControlavelDTO> GetAllByOBJ_ID(string value );
        public IEnumerable<PerfilObjetoControlavelDTO> GetAllByPEO_ACAO(string value );
        public IEnumerable<PerfilObjetoControlavelDTO> GetAllByTenantID(int value );
        public IEnumerable<PerfilObjetoControlavelDTO> GetAllByDeleted(bool value );
        public IEnumerable<PerfilObjetoControlavelDTO> GetAllByChanged(DateTime value );
        public IEnumerable<PerfilObjetoControlavelDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration