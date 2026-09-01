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
    public partial interface IT_PREFERENCIASReadRepository
    {
        public DataPagination<T_PREFERENCIASDTO> getT_PREFERENCIAS(ICommandRead command );
        public IEnumerable<T_PREFERENCIASTenantIDDTO> getT_PREFERENCIASReadFKTenantID(object command );
        public IEnumerable<T_PREFERENCIASUserIdDTO> getT_PREFERENCIASReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByPRE_ID(int value );
        public bool ExistsByPRE_DESCRICAO(string value );
        public bool ExistsByPRE_NAMESPACE(string value );
        public bool ExistsByPRE_TIPO(string value );
        public bool ExistsByPRE_VALOR(string value );
        public bool ExistsByUSE_ID(int value );
        public bool ExistsByPER_ID(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public T_PREFERENCIASDTO FirstById(int value );
        public T_PREFERENCIASDTO FirstByPRE_ID(int value );
        public T_PREFERENCIASDTO FirstByPRE_DESCRICAO(string value );
        public T_PREFERENCIASDTO FirstByPRE_NAMESPACE(string value );
        public T_PREFERENCIASDTO FirstByPRE_TIPO(string value );
        public T_PREFERENCIASDTO FirstByPRE_VALOR(string value );
        public T_PREFERENCIASDTO FirstByUSE_ID(int value );
        public T_PREFERENCIASDTO FirstByPER_ID(int value );
        public T_PREFERENCIASDTO FirstByTenantID(int value );
        public T_PREFERENCIASDTO FirstByDeleted(bool value );
        public T_PREFERENCIASDTO FirstByChanged(DateTime value );
        public T_PREFERENCIASDTO FirstByUserId(int value );
        public IEnumerable<T_PREFERENCIASDTO> GetAllById(int value );
        public IEnumerable<T_PREFERENCIASDTO> GetAllByPRE_ID(int value );
        public IEnumerable<T_PREFERENCIASDTO> GetAllByPRE_DESCRICAO(string value );
        public IEnumerable<T_PREFERENCIASDTO> GetAllByPRE_NAMESPACE(string value );
        public IEnumerable<T_PREFERENCIASDTO> GetAllByPRE_TIPO(string value );
        public IEnumerable<T_PREFERENCIASDTO> GetAllByPRE_VALOR(string value );
        public IEnumerable<T_PREFERENCIASDTO> GetAllByUSE_ID(int value );
        public IEnumerable<T_PREFERENCIASDTO> GetAllByPER_ID(int value );
        public IEnumerable<T_PREFERENCIASDTO> GetAllByTenantID(int value );
        public IEnumerable<T_PREFERENCIASDTO> GetAllByDeleted(bool value );
        public IEnumerable<T_PREFERENCIASDTO> GetAllByChanged(DateTime value );
        public IEnumerable<T_PREFERENCIASDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration