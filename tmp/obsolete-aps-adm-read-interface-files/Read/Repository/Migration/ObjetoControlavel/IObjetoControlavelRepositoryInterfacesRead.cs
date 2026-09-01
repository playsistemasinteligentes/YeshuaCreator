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
    public partial interface IObjetoControlavelReadRepository
    {
        public DataPagination<ObjetoControlavelDTO> getObjetoControlavel(ICommandRead command );
        public IEnumerable<ObjetoControlavelTenantIDDTO> getObjetoControlavelReadFKTenantID(object command );
        public IEnumerable<ObjetoControlavelUserIdDTO> getObjetoControlavelReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByOBJ_ID(string value );
        public bool ExistsByOBJ_DESCRICAO(string value );
        public bool ExistsByOBJ_TIPO(string value );
        public bool ExistsByOBJ_GRUPO(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public ObjetoControlavelDTO FirstById(int value );
        public ObjetoControlavelDTO FirstByOBJ_ID(string value );
        public ObjetoControlavelDTO FirstByOBJ_DESCRICAO(string value );
        public ObjetoControlavelDTO FirstByOBJ_TIPO(string value );
        public ObjetoControlavelDTO FirstByOBJ_GRUPO(string value );
        public ObjetoControlavelDTO FirstByTenantID(int value );
        public ObjetoControlavelDTO FirstByDeleted(bool value );
        public ObjetoControlavelDTO FirstByChanged(DateTime value );
        public ObjetoControlavelDTO FirstByUserId(int value );
        public IEnumerable<ObjetoControlavelDTO> GetAllById(int value );
        public IEnumerable<ObjetoControlavelDTO> GetAllByOBJ_ID(string value );
        public IEnumerable<ObjetoControlavelDTO> GetAllByOBJ_DESCRICAO(string value );
        public IEnumerable<ObjetoControlavelDTO> GetAllByOBJ_TIPO(string value );
        public IEnumerable<ObjetoControlavelDTO> GetAllByOBJ_GRUPO(string value );
        public IEnumerable<ObjetoControlavelDTO> GetAllByTenantID(int value );
        public IEnumerable<ObjetoControlavelDTO> GetAllByDeleted(bool value );
        public IEnumerable<ObjetoControlavelDTO> GetAllByChanged(DateTime value );
        public IEnumerable<ObjetoControlavelDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration