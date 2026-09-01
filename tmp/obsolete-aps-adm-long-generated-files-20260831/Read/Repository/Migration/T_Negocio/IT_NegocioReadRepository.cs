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
    public partial interface IT_NegocioReadRepository
    {
        public DataPagination<T_NegocioDTO> getT_Negocio(ICommandRead command );
        public IEnumerable<T_NegocioTenantIDDTO> getT_NegocioReadFKTenantID(object command );
        public IEnumerable<T_NegocioUserIdDTO> getT_NegocioReadFKUserId(object command );
        public bool ExistsByNEG_ID(int value );
        public bool ExistsByNEG_DESCRICAO(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public T_NegocioDTO FirstByNEG_ID(int value );
        public T_NegocioDTO FirstByNEG_DESCRICAO(string value );
        public T_NegocioDTO FirstByTenantID(int value );
        public T_NegocioDTO FirstByDeleted(bool value );
        public T_NegocioDTO FirstByChanged(DateTime value );
        public T_NegocioDTO FirstByUserId(int value );
        public IEnumerable<T_NegocioDTO> GetAllByNEG_ID(int value );
        public IEnumerable<T_NegocioDTO> GetAllByNEG_DESCRICAO(string value );
        public IEnumerable<T_NegocioDTO> GetAllByTenantID(int value );
        public IEnumerable<T_NegocioDTO> GetAllByDeleted(bool value );
        public IEnumerable<T_NegocioDTO> GetAllByChanged(DateTime value );
        public IEnumerable<T_NegocioDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration