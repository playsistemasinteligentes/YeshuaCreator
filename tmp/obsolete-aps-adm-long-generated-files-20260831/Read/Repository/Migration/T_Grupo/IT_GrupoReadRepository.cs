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
    public partial interface IT_GrupoReadRepository
    {
        public DataPagination<T_GrupoDTO> getT_Grupo(ICommandRead command );
        public IEnumerable<T_GrupoTenantIDDTO> getT_GrupoReadFKTenantID(object command );
        public IEnumerable<T_GrupoUserIdDTO> getT_GrupoReadFKUserId(object command );
        public bool ExistsByGRU_ID(int value );
        public bool ExistsByNOME(string value );
        public bool ExistsByEXIBELISTA(int value );
        public bool ExistsByGRU_DESCRICAO(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public T_GrupoDTO FirstByGRU_ID(int value );
        public T_GrupoDTO FirstByNOME(string value );
        public T_GrupoDTO FirstByEXIBELISTA(int value );
        public T_GrupoDTO FirstByGRU_DESCRICAO(string value );
        public T_GrupoDTO FirstByTenantID(int value );
        public T_GrupoDTO FirstByDeleted(bool value );
        public T_GrupoDTO FirstByChanged(DateTime value );
        public T_GrupoDTO FirstByUserId(int value );
        public IEnumerable<T_GrupoDTO> GetAllByGRU_ID(int value );
        public IEnumerable<T_GrupoDTO> GetAllByNOME(string value );
        public IEnumerable<T_GrupoDTO> GetAllByEXIBELISTA(int value );
        public IEnumerable<T_GrupoDTO> GetAllByGRU_DESCRICAO(string value );
        public IEnumerable<T_GrupoDTO> GetAllByTenantID(int value );
        public IEnumerable<T_GrupoDTO> GetAllByDeleted(bool value );
        public IEnumerable<T_GrupoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<T_GrupoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration