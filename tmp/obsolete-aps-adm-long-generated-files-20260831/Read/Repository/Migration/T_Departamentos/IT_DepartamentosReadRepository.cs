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
    public partial interface IT_DepartamentosReadRepository
    {
        public DataPagination<T_DepartamentosDTO> getT_Departamentos(ICommandRead command );
        public IEnumerable<T_DepartamentosTenantIDDTO> getT_DepartamentosReadFKTenantID(object command );
        public IEnumerable<T_DepartamentosUserIdDTO> getT_DepartamentosReadFKUserId(object command );
        public bool ExistsByDEP_ID(int value );
        public bool ExistsByDEP_NOME(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public T_DepartamentosDTO FirstByDEP_ID(int value );
        public T_DepartamentosDTO FirstByDEP_NOME(string value );
        public T_DepartamentosDTO FirstByTenantID(int value );
        public T_DepartamentosDTO FirstByDeleted(bool value );
        public T_DepartamentosDTO FirstByChanged(DateTime value );
        public T_DepartamentosDTO FirstByUserId(int value );
        public IEnumerable<T_DepartamentosDTO> GetAllByDEP_ID(int value );
        public IEnumerable<T_DepartamentosDTO> GetAllByDEP_NOME(string value );
        public IEnumerable<T_DepartamentosDTO> GetAllByTenantID(int value );
        public IEnumerable<T_DepartamentosDTO> GetAllByDeleted(bool value );
        public IEnumerable<T_DepartamentosDTO> GetAllByChanged(DateTime value );
        public IEnumerable<T_DepartamentosDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration