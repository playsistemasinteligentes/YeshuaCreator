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
    public partial interface IT_MAQUINAS_EQUIPESReadRepository
    {
        public DataPagination<T_MAQUINAS_EQUIPESDTO> getT_MAQUINAS_EQUIPES(ICommandRead command );
        public IEnumerable<T_MAQUINAS_EQUIPESTenantIDDTO> getT_MAQUINAS_EQUIPESReadFKTenantID(object command );
        public IEnumerable<T_MAQUINAS_EQUIPESUserIdDTO> getT_MAQUINAS_EQUIPESReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByMAQ_ID(string value );
        public bool ExistsByEQU_ID(string value );
        public bool ExistsByCAL_ID(int value );
        public bool ExistsByCLI_ID(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public T_MAQUINAS_EQUIPESDTO FirstById(int value );
        public T_MAQUINAS_EQUIPESDTO FirstByMAQ_ID(string value );
        public T_MAQUINAS_EQUIPESDTO FirstByEQU_ID(string value );
        public T_MAQUINAS_EQUIPESDTO FirstByCAL_ID(int value );
        public T_MAQUINAS_EQUIPESDTO FirstByCLI_ID(string value );
        public T_MAQUINAS_EQUIPESDTO FirstByTenantID(int value );
        public T_MAQUINAS_EQUIPESDTO FirstByDeleted(bool value );
        public T_MAQUINAS_EQUIPESDTO FirstByChanged(DateTime value );
        public T_MAQUINAS_EQUIPESDTO FirstByUserId(int value );
        public IEnumerable<T_MAQUINAS_EQUIPESDTO> GetAllById(int value );
        public IEnumerable<T_MAQUINAS_EQUIPESDTO> GetAllByMAQ_ID(string value );
        public IEnumerable<T_MAQUINAS_EQUIPESDTO> GetAllByEQU_ID(string value );
        public IEnumerable<T_MAQUINAS_EQUIPESDTO> GetAllByCAL_ID(int value );
        public IEnumerable<T_MAQUINAS_EQUIPESDTO> GetAllByCLI_ID(string value );
        public IEnumerable<T_MAQUINAS_EQUIPESDTO> GetAllByTenantID(int value );
        public IEnumerable<T_MAQUINAS_EQUIPESDTO> GetAllByDeleted(bool value );
        public IEnumerable<T_MAQUINAS_EQUIPESDTO> GetAllByChanged(DateTime value );
        public IEnumerable<T_MAQUINAS_EQUIPESDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration