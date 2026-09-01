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
    public partial interface IRecursosReadRepository
    {
        public DataPagination<RecursosDTO> getRecursos(ICommandRead command );
        public IEnumerable<RecursosCAL_IDDTO> getRecursosReadFKCAL_ID(object command );
        public IEnumerable<RecursosTenantIDDTO> getRecursosReadFKTenantID(object command );
        public IEnumerable<RecursosUserIdDTO> getRecursosReadFKUserId(object command );
        public bool ExistsByREC_ID(string value );
        public bool ExistsByREC_DESCRICAO(string value );
        public bool ExistsByCAL_ID(int value );
        public bool ExistsByREC_CONTROL_IP(string value );
        public bool ExistsByGRE_ID(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public RecursosDTO FirstByREC_ID(string value );
        public RecursosDTO FirstByREC_DESCRICAO(string value );
        public RecursosDTO FirstByCAL_ID(int value );
        public RecursosDTO FirstByREC_CONTROL_IP(string value );
        public RecursosDTO FirstByGRE_ID(string value );
        public RecursosDTO FirstByTenantID(int value );
        public RecursosDTO FirstByDeleted(bool value );
        public RecursosDTO FirstByChanged(DateTime value );
        public RecursosDTO FirstByUserId(int value );
        public IEnumerable<RecursosDTO> GetAllByREC_ID(string value );
        public IEnumerable<RecursosDTO> GetAllByREC_DESCRICAO(string value );
        public IEnumerable<RecursosDTO> GetAllByCAL_ID(int value );
        public IEnumerable<RecursosDTO> GetAllByREC_CONTROL_IP(string value );
        public IEnumerable<RecursosDTO> GetAllByGRE_ID(string value );
        public IEnumerable<RecursosDTO> GetAllByTenantID(int value );
        public IEnumerable<RecursosDTO> GetAllByDeleted(bool value );
        public IEnumerable<RecursosDTO> GetAllByChanged(DateTime value );
        public IEnumerable<RecursosDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration