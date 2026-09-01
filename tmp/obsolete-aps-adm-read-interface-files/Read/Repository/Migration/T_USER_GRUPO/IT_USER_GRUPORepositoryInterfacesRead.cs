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
    public partial interface IT_USER_GRUPOReadRepository
    {
        public DataPagination<T_USER_GRUPODTO> getT_USER_GRUPO(ICommandRead command );
        public IEnumerable<T_USER_GRUPOGRU_IDDTO> getT_USER_GRUPOReadFKGRU_ID(object command );
        public IEnumerable<T_USER_GRUPOID_USUARIODTO> getT_USER_GRUPOReadFKID_USUARIO(object command );
        public IEnumerable<T_USER_GRUPOTenantIDDTO> getT_USER_GRUPOReadFKTenantID(object command );
        public IEnumerable<T_USER_GRUPOUserIdDTO> getT_USER_GRUPOReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByGRU_ID(int value );
        public bool ExistsByID_USUARIO(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public T_USER_GRUPODTO FirstById(int value );
        public T_USER_GRUPODTO FirstByGRU_ID(int value );
        public T_USER_GRUPODTO FirstByID_USUARIO(int value );
        public T_USER_GRUPODTO FirstByTenantID(int value );
        public T_USER_GRUPODTO FirstByDeleted(bool value );
        public T_USER_GRUPODTO FirstByChanged(DateTime value );
        public T_USER_GRUPODTO FirstByUserId(int value );
        public IEnumerable<T_USER_GRUPODTO> GetAllById(int value );
        public IEnumerable<T_USER_GRUPODTO> GetAllByGRU_ID(int value );
        public IEnumerable<T_USER_GRUPODTO> GetAllByID_USUARIO(int value );
        public IEnumerable<T_USER_GRUPODTO> GetAllByTenantID(int value );
        public IEnumerable<T_USER_GRUPODTO> GetAllByDeleted(bool value );
        public IEnumerable<T_USER_GRUPODTO> GetAllByChanged(DateTime value );
        public IEnumerable<T_USER_GRUPODTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration