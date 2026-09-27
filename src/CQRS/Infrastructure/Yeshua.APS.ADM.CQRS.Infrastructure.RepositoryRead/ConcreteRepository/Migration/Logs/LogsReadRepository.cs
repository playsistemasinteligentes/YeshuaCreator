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
    public partial class LogsReadRepository : ILogsReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ILogsQueryRead _query;

        public LogsReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ILogsQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetLogsCustom(Command.Read.LogsReadCommand command, ref DataPagination<LogsDTO> result, ref bool handled);

        public DataPagination<LogsDTO> getLogs(ICommandRead command )
         {
            if (command is Command.Read.LogsReadCommand c)
                return getLogs(c );
            throw new NotImplementedException();
        }
        private DataPagination<LogsDTO> getLogs(Command.Read.LogsReadCommand command )
        {
            var customResult = new DataPagination<LogsDTO>();
            var customHandled = false;
            TryGetLogsCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.LogsQuery(command );

                var itens = _unitOfWork.Query<LogsDTO>(query.Query,query.Parameters);
                return new DataPagination<LogsDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<LogsTenantIDDTO> getLogsReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.LogsTenantIDQuery(command );

                var lista = _unitOfWork.Query<LogsTenantIDDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<LogsTenantIDDTO> getLogsReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getLogsReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<LogsUserIdDTO> getLogsReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.LogsUserIdQuery(command );

                var lista = _unitOfWork.Query<LogsUserIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<LogsUserIdDTO> getLogsReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getLogsReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByLOG_CHAVE(string value )
        {
            var query = _query.ExistsByLOG_CHAVEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByLOG_CONTEXTO(string value )
        {
            var query = _query.ExistsByLOG_CONTEXTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByLOG_CONTEUDO(string value )
        {
            var query = _query.ExistsByLOG_CONTEUDOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByLOG_ID(int value )
        {
            var query = _query.ExistsByLOG_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByLOG_EMISSAO(DateTime value )
        {
            var query = _query.ExistsByLOG_EMISSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOperationalEntityId(string value )
        {
            var query = _query.ExistsByOperationalEntityIdQuery(value );

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

        public LogsDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LogsDTO>(query.Query, query.Parameters);
                return result;
        }

        public LogsDTO FirstByLOG_CHAVE(string value )
        {
            var query = _query.FirstByLOG_CHAVEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LogsDTO>(query.Query, query.Parameters);
                return result;
        }

        public LogsDTO FirstByLOG_CONTEXTO(string value )
        {
            var query = _query.FirstByLOG_CONTEXTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LogsDTO>(query.Query, query.Parameters);
                return result;
        }

        public LogsDTO FirstByLOG_CONTEUDO(string value )
        {
            var query = _query.FirstByLOG_CONTEUDOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LogsDTO>(query.Query, query.Parameters);
                return result;
        }

        public LogsDTO FirstByLOG_ID(int value )
        {
            var query = _query.FirstByLOG_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LogsDTO>(query.Query, query.Parameters);
                return result;
        }

        public LogsDTO FirstByLOG_EMISSAO(DateTime value )
        {
            var query = _query.FirstByLOG_EMISSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LogsDTO>(query.Query, query.Parameters);
                return result;
        }

        public LogsDTO FirstByOperationalEntityId(string value )
        {
            var query = _query.FirstByOperationalEntityIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LogsDTO>(query.Query, query.Parameters);
                return result;
        }

        public LogsDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LogsDTO>(query.Query, query.Parameters);
                return result;
        }

        public LogsDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LogsDTO>(query.Query, query.Parameters);
                return result;
        }

        public LogsDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LogsDTO>(query.Query, query.Parameters);
                return result;
        }

        public LogsDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LogsDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<LogsDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<LogsDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<LogsDTO> GetAllByLOG_CHAVE(string value )
        {
            var query = _query.FirstByLOG_CHAVEQuery(value );

                var result = _unitOfWork.Query<LogsDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<LogsDTO> GetAllByLOG_CONTEXTO(string value )
        {
            var query = _query.FirstByLOG_CONTEXTOQuery(value );

                var result = _unitOfWork.Query<LogsDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<LogsDTO> GetAllByLOG_CONTEUDO(string value )
        {
            var query = _query.FirstByLOG_CONTEUDOQuery(value );

                var result = _unitOfWork.Query<LogsDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<LogsDTO> GetAllByLOG_ID(int value )
        {
            var query = _query.FirstByLOG_IDQuery(value );

                var result = _unitOfWork.Query<LogsDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<LogsDTO> GetAllByLOG_EMISSAO(DateTime value )
        {
            var query = _query.FirstByLOG_EMISSAOQuery(value );

                var result = _unitOfWork.Query<LogsDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<LogsDTO> GetAllByOperationalEntityId(string value )
        {
            var query = _query.FirstByOperationalEntityIdQuery(value );

                var result = _unitOfWork.Query<LogsDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<LogsDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<LogsDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<LogsDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<LogsDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<LogsDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<LogsDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<LogsDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<LogsDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration