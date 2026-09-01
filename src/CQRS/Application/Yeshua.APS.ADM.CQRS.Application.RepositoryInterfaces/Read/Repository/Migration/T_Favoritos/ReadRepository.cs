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
    public partial interface IT_FavoritosReadRepository
    {
        public DataPagination<T_FavoritosDTO> getT_Favoritos(ICommandRead command );
        public IEnumerable<T_FavoritosUSE_IDDTO> getT_FavoritosReadFKUSE_ID(object command );
        public IEnumerable<T_FavoritosID_INDICADORDTO> getT_FavoritosReadFKID_INDICADOR(object command );
        public IEnumerable<T_FavoritosTenantIDDTO> getT_FavoritosReadFKTenantID(object command );
        public IEnumerable<T_FavoritosUserIdDTO> getT_FavoritosReadFKUserId(object command );
        public bool ExistsByIDFAVORITO(int value );
        public bool ExistsByUSE_ID(int value );
        public bool ExistsByID_INDICADOR(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public T_FavoritosDTO FirstByIDFAVORITO(int value );
        public T_FavoritosDTO FirstByUSE_ID(int value );
        public T_FavoritosDTO FirstByID_INDICADOR(int value );
        public T_FavoritosDTO FirstByTenantID(int value );
        public T_FavoritosDTO FirstByDeleted(bool value );
        public T_FavoritosDTO FirstByChanged(DateTime value );
        public T_FavoritosDTO FirstByUserId(int value );
        public IEnumerable<T_FavoritosDTO> GetAllByIDFAVORITO(int value );
        public IEnumerable<T_FavoritosDTO> GetAllByUSE_ID(int value );
        public IEnumerable<T_FavoritosDTO> GetAllByID_INDICADOR(int value );
        public IEnumerable<T_FavoritosDTO> GetAllByTenantID(int value );
        public IEnumerable<T_FavoritosDTO> GetAllByDeleted(bool value );
        public IEnumerable<T_FavoritosDTO> GetAllByChanged(DateTime value );
        public IEnumerable<T_FavoritosDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration