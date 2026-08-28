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
    public partial interface IT_FeedbackMovEstoqueReadRepository
    {
        public DataPagination<T_FeedbackMovEstoqueDTO> getT_FeedbackMovEstoque(ICommandRead command );
        public IEnumerable<T_FeedbackMovEstoqueFeedbackIdDTO> getT_FeedbackMovEstoqueReadFKFeedbackId(object command );
        public IEnumerable<T_FeedbackMovEstoqueMovimentoEstoqueIdDTO> getT_FeedbackMovEstoqueReadFKMovimentoEstoqueId(object command );
        public IEnumerable<T_FeedbackMovEstoqueTenantIDDTO> getT_FeedbackMovEstoqueReadFKTenantID(object command );
        public IEnumerable<T_FeedbackMovEstoqueUserIdDTO> getT_FeedbackMovEstoqueReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByFeedbackId(int value );
        public bool ExistsByMovimentoEstoqueId(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public T_FeedbackMovEstoqueDTO FirstById(int value );
        public T_FeedbackMovEstoqueDTO FirstByFeedbackId(int value );
        public T_FeedbackMovEstoqueDTO FirstByMovimentoEstoqueId(int value );
        public T_FeedbackMovEstoqueDTO FirstByTenantID(int value );
        public T_FeedbackMovEstoqueDTO FirstByDeleted(bool value );
        public T_FeedbackMovEstoqueDTO FirstByChanged(DateTime value );
        public T_FeedbackMovEstoqueDTO FirstByUserId(int value );
        public IEnumerable<T_FeedbackMovEstoqueDTO> GetAllById(int value );
        public IEnumerable<T_FeedbackMovEstoqueDTO> GetAllByFeedbackId(int value );
        public IEnumerable<T_FeedbackMovEstoqueDTO> GetAllByMovimentoEstoqueId(int value );
        public IEnumerable<T_FeedbackMovEstoqueDTO> GetAllByTenantID(int value );
        public IEnumerable<T_FeedbackMovEstoqueDTO> GetAllByDeleted(bool value );
        public IEnumerable<T_FeedbackMovEstoqueDTO> GetAllByChanged(DateTime value );
        public IEnumerable<T_FeedbackMovEstoqueDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration