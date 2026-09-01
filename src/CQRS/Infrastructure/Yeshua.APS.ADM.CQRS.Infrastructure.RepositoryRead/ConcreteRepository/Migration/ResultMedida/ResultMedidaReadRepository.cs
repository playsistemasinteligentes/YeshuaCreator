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
    public partial class ResultMedidaReadRepository : IResultMedidaReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IResultMedidaQueryRead _query;

        public ResultMedidaReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IResultMedidaQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetResultMedidaCustom(Command.Read.ResultMedidaReadCommand command, ref DataPagination<ResultMedidaDTO> result, ref bool handled);

        public DataPagination<ResultMedidaDTO> getResultMedida(ICommandRead command )
         {
            if (command is Command.Read.ResultMedidaReadCommand c)
                return getResultMedida(c );
            throw new NotImplementedException();
        }
        private DataPagination<ResultMedidaDTO> getResultMedida(Command.Read.ResultMedidaReadCommand command )
        {
            DataPagination<ResultMedidaDTO> customResult = null;
            var customHandled = false;
            TryGetResultMedidaCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.ResultMedidaQuery(command );

                var itens = _unitOfWork.Query<ResultMedidaDTO>(query.Query,query.Parameters);
                return new DataPagination<ResultMedidaDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<ResultMedidaTenantIDDTO> getResultMedidaReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ResultMedidaTenantIDDTO> lista;
            var query = _query.ResultMedidaTenantIDQuery(command );

                lista = _unitOfWork.Query<ResultMedidaTenantIDDTO>(query.Query,query.Parameters) as List<ResultMedidaTenantIDDTO>;
            return lista;
        }

        public IEnumerable<ResultMedidaTenantIDDTO> getResultMedidaReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getResultMedidaReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ResultMedidaUserIdDTO> getResultMedidaReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ResultMedidaUserIdDTO> lista;
            var query = _query.ResultMedidaUserIdQuery(command );

                lista = _unitOfWork.Query<ResultMedidaUserIdDTO>(query.Query,query.Parameters) as List<ResultMedidaUserIdDTO>;
            return lista;
        }

        public IEnumerable<ResultMedidaUserIdDTO> getResultMedidaReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getResultMedidaReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByRSM_ID(int value )
        {
            var query = _query.ExistsByRSM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByRL_ID(int value )
        {
            var query = _query.ExistsByRL_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMDT_ID(int value )
        {
            var query = _query.ExistsByMDT_IDQuery(value );

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

        public ResultMedidaDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ResultMedidaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ResultMedidaDTO FirstByRSM_ID(int value )
        {
            var query = _query.FirstByRSM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ResultMedidaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ResultMedidaDTO FirstByRL_ID(int value )
        {
            var query = _query.FirstByRL_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ResultMedidaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ResultMedidaDTO FirstByMDT_ID(int value )
        {
            var query = _query.FirstByMDT_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ResultMedidaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ResultMedidaDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ResultMedidaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ResultMedidaDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ResultMedidaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ResultMedidaDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ResultMedidaDTO>(query.Query, query.Parameters);
                return result;
        }

        public ResultMedidaDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ResultMedidaDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<ResultMedidaDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<ResultMedidaDTO>(query.Query,query.Parameters) as List<ResultMedidaDTO>;
                return result;
        }

        public IEnumerable<ResultMedidaDTO> GetAllByRSM_ID(int value )
        {
            var query = _query.FirstByRSM_IDQuery(value );

                var result = _unitOfWork.Query<ResultMedidaDTO>(query.Query,query.Parameters) as List<ResultMedidaDTO>;
                return result;
        }

        public IEnumerable<ResultMedidaDTO> GetAllByRL_ID(int value )
        {
            var query = _query.FirstByRL_IDQuery(value );

                var result = _unitOfWork.Query<ResultMedidaDTO>(query.Query,query.Parameters) as List<ResultMedidaDTO>;
                return result;
        }

        public IEnumerable<ResultMedidaDTO> GetAllByMDT_ID(int value )
        {
            var query = _query.FirstByMDT_IDQuery(value );

                var result = _unitOfWork.Query<ResultMedidaDTO>(query.Query,query.Parameters) as List<ResultMedidaDTO>;
                return result;
        }

        public IEnumerable<ResultMedidaDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<ResultMedidaDTO>(query.Query,query.Parameters) as List<ResultMedidaDTO>;
                return result;
        }

        public IEnumerable<ResultMedidaDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<ResultMedidaDTO>(query.Query,query.Parameters) as List<ResultMedidaDTO>;
                return result;
        }

        public IEnumerable<ResultMedidaDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<ResultMedidaDTO>(query.Query,query.Parameters) as List<ResultMedidaDTO>;
                return result;
        }

        public IEnumerable<ResultMedidaDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<ResultMedidaDTO>(query.Query,query.Parameters) as List<ResultMedidaDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration