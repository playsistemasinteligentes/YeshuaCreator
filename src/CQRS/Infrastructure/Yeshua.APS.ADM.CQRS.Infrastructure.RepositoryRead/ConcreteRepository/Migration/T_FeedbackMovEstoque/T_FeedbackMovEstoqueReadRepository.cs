// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration
// </yeshua>

using Dapper;
using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Read.Repository;
using IRepository.Read;
using IQuery.Read;
using Aplication.Interfaces.Services;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.Repository
{
    public partial class T_FeedbackMovEstoqueReadRepository : IT_FeedbackMovEstoqueReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IT_FeedbackMovEstoqueQueryRead _query;

        public T_FeedbackMovEstoqueReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IT_FeedbackMovEstoqueQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<T_FeedbackMovEstoqueDTO> getT_FeedbackMovEstoque(ICommandRead command )
         {
            if (command is Command.Read.T_FeedbackMovEstoqueReadCommand c)
                return getT_FeedbackMovEstoque(c );
            throw new NotImplementedException();
        }
        private DataPagination<T_FeedbackMovEstoqueDTO> getT_FeedbackMovEstoque(Command.Read.T_FeedbackMovEstoqueReadCommand command )
        {
            var query = _query.T_FeedbackMovEstoqueQuery(command );

                var itens = _unitOfWork.Query<T_FeedbackMovEstoqueDTO>(query.Query,query.Parameters);
                return new DataPagination<T_FeedbackMovEstoqueDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<T_FeedbackMovEstoqueFeedbackIdDTO> getT_FeedbackMovEstoqueReadFKFeedbackId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<T_FeedbackMovEstoqueFeedbackIdDTO> lista;
            var query = _query.T_FeedbackMovEstoqueFeedbackIdQuery(command );

                lista = _unitOfWork.Query<T_FeedbackMovEstoqueFeedbackIdDTO>(query.Query,query.Parameters) as List<T_FeedbackMovEstoqueFeedbackIdDTO>;
            return lista;
        }

        public IEnumerable<T_FeedbackMovEstoqueFeedbackIdDTO> getT_FeedbackMovEstoqueReadFKFeedbackId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getT_FeedbackMovEstoqueReadFKFeedbackId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<T_FeedbackMovEstoqueMovimentoEstoqueIdDTO> getT_FeedbackMovEstoqueReadFKMovimentoEstoqueId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<T_FeedbackMovEstoqueMovimentoEstoqueIdDTO> lista;
            var query = _query.T_FeedbackMovEstoqueMovimentoEstoqueIdQuery(command );

                lista = _unitOfWork.Query<T_FeedbackMovEstoqueMovimentoEstoqueIdDTO>(query.Query,query.Parameters) as List<T_FeedbackMovEstoqueMovimentoEstoqueIdDTO>;
            return lista;
        }

        public IEnumerable<T_FeedbackMovEstoqueMovimentoEstoqueIdDTO> getT_FeedbackMovEstoqueReadFKMovimentoEstoqueId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getT_FeedbackMovEstoqueReadFKMovimentoEstoqueId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<T_FeedbackMovEstoqueTenantIDDTO> getT_FeedbackMovEstoqueReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<T_FeedbackMovEstoqueTenantIDDTO> lista;
            var query = _query.T_FeedbackMovEstoqueTenantIDQuery(command );

                lista = _unitOfWork.Query<T_FeedbackMovEstoqueTenantIDDTO>(query.Query,query.Parameters) as List<T_FeedbackMovEstoqueTenantIDDTO>;
            return lista;
        }

        public IEnumerable<T_FeedbackMovEstoqueTenantIDDTO> getT_FeedbackMovEstoqueReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getT_FeedbackMovEstoqueReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<T_FeedbackMovEstoqueUserIdDTO> getT_FeedbackMovEstoqueReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<T_FeedbackMovEstoqueUserIdDTO> lista;
            var query = _query.T_FeedbackMovEstoqueUserIdQuery(command );

                lista = _unitOfWork.Query<T_FeedbackMovEstoqueUserIdDTO>(query.Query,query.Parameters) as List<T_FeedbackMovEstoqueUserIdDTO>;
            return lista;
        }

        public IEnumerable<T_FeedbackMovEstoqueUserIdDTO> getT_FeedbackMovEstoqueReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getT_FeedbackMovEstoqueReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFeedbackId(int value )
        {
            var query = _query.ExistsByFeedbackIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMovimentoEstoqueId(int value )
        {
            var query = _query.ExistsByMovimentoEstoqueIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTenantID(int value )
        {
            var query = _query.ExistsByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDeleted(bool value )
        {
            var query = _query.ExistsByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByChanged(DateTime value )
        {
            var query = _query.ExistsByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUserId(int value )
        {
            var query = _query.ExistsByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public T_FeedbackMovEstoqueDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_FeedbackMovEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_FeedbackMovEstoqueDTO FirstByFeedbackId(int value )
        {
            var query = _query.FirstByFeedbackIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_FeedbackMovEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_FeedbackMovEstoqueDTO FirstByMovimentoEstoqueId(int value )
        {
            var query = _query.FirstByMovimentoEstoqueIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_FeedbackMovEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_FeedbackMovEstoqueDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_FeedbackMovEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_FeedbackMovEstoqueDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_FeedbackMovEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_FeedbackMovEstoqueDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_FeedbackMovEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_FeedbackMovEstoqueDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_FeedbackMovEstoqueDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<T_FeedbackMovEstoqueDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<T_FeedbackMovEstoqueDTO>(query.Query,query.Parameters) as List<T_FeedbackMovEstoqueDTO>;
                return result;
        }

        public IEnumerable<T_FeedbackMovEstoqueDTO> GetAllByFeedbackId(int value )
        {
            var query = _query.FirstByFeedbackIdQuery(value );

                var result = _unitOfWork.Query<T_FeedbackMovEstoqueDTO>(query.Query,query.Parameters) as List<T_FeedbackMovEstoqueDTO>;
                return result;
        }

        public IEnumerable<T_FeedbackMovEstoqueDTO> GetAllByMovimentoEstoqueId(int value )
        {
            var query = _query.FirstByMovimentoEstoqueIdQuery(value );

                var result = _unitOfWork.Query<T_FeedbackMovEstoqueDTO>(query.Query,query.Parameters) as List<T_FeedbackMovEstoqueDTO>;
                return result;
        }

        public IEnumerable<T_FeedbackMovEstoqueDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<T_FeedbackMovEstoqueDTO>(query.Query,query.Parameters) as List<T_FeedbackMovEstoqueDTO>;
                return result;
        }

        public IEnumerable<T_FeedbackMovEstoqueDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<T_FeedbackMovEstoqueDTO>(query.Query,query.Parameters) as List<T_FeedbackMovEstoqueDTO>;
                return result;
        }

        public IEnumerable<T_FeedbackMovEstoqueDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<T_FeedbackMovEstoqueDTO>(query.Query,query.Parameters) as List<T_FeedbackMovEstoqueDTO>;
                return result;
        }

        public IEnumerable<T_FeedbackMovEstoqueDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<T_FeedbackMovEstoqueDTO>(query.Query,query.Parameters) as List<T_FeedbackMovEstoqueDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration