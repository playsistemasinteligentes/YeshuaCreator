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
    public partial class CTeEntradaOficialReadRepository : ICTeEntradaOficialReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ICTeEntradaOficialQueryRead _query;

        public CTeEntradaOficialReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ICTeEntradaOficialQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetCTeEntradaOficialCustom(Command.Read.CTeEntradaOficialReadCommand command, ref DataPagination<CTeEntradaOficialDTO> result, ref bool handled);

        public DataPagination<CTeEntradaOficialDTO> getCTeEntradaOficial(ICommandRead command )
         {
            if (command is Command.Read.CTeEntradaOficialReadCommand c)
                return getCTeEntradaOficial(c );
            throw new NotImplementedException();
        }
        private DataPagination<CTeEntradaOficialDTO> getCTeEntradaOficial(Command.Read.CTeEntradaOficialReadCommand command )
        {
            var customResult = new DataPagination<CTeEntradaOficialDTO>();
            var customHandled = false;
            TryGetCTeEntradaOficialCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.CTeEntradaOficialQuery(command );

                var itens = _unitOfWork.Query<CTeEntradaOficialDTO>(query.Query,query.Parameters);
                return new DataPagination<CTeEntradaOficialDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<CTeEntradaOficialTenantIDDTO> getCTeEntradaOficialReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.CTeEntradaOficialTenantIDQuery(command );

                var lista = _unitOfWork.Query<CTeEntradaOficialTenantIDDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<CTeEntradaOficialTenantIDDTO> getCTeEntradaOficialReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCTeEntradaOficialReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<CTeEntradaOficialUserIdDTO> getCTeEntradaOficialReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.CTeEntradaOficialUserIdQuery(command );

                var lista = _unitOfWork.Query<CTeEntradaOficialUserIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<CTeEntradaOficialUserIdDTO> getCTeEntradaOficialReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCTeEntradaOficialReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCorrelationId(string value )
        {
            var query = _query.ExistsByCorrelationIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySourceApplication(string value )
        {
            var query = _query.ExistsBySourceApplicationQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySourceModule(string value )
        {
            var query = _query.ExistsBySourceModuleQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsBySourceMessageId(string value )
        {
            var query = _query.ExistsBySourceMessageIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMessageType(string value )
        {
            var query = _query.ExistsByMessageTypeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMessageVersion(string value )
        {
            var query = _query.ExistsByMessageVersionQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByReceivedAtUtc(DateTime value )
        {
            var query = _query.ExistsByReceivedAtUtcQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPayloadHash(string value )
        {
            var query = _query.ExistsByPayloadHashQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPayloadStorageKey(string value )
        {
            var query = _query.ExistsByPayloadStorageKeyQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByStatus(int value )
        {
            var query = _query.ExistsByStatusQuery(value );

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

        public CTeEntradaOficialDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeEntradaOficialDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeEntradaOficialDTO FirstByCorrelationId(string value )
        {
            var query = _query.FirstByCorrelationIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeEntradaOficialDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeEntradaOficialDTO FirstBySourceApplication(string value )
        {
            var query = _query.FirstBySourceApplicationQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeEntradaOficialDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeEntradaOficialDTO FirstBySourceModule(string value )
        {
            var query = _query.FirstBySourceModuleQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeEntradaOficialDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeEntradaOficialDTO FirstBySourceMessageId(string value )
        {
            var query = _query.FirstBySourceMessageIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeEntradaOficialDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeEntradaOficialDTO FirstByMessageType(string value )
        {
            var query = _query.FirstByMessageTypeQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeEntradaOficialDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeEntradaOficialDTO FirstByMessageVersion(string value )
        {
            var query = _query.FirstByMessageVersionQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeEntradaOficialDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeEntradaOficialDTO FirstByReceivedAtUtc(DateTime value )
        {
            var query = _query.FirstByReceivedAtUtcQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeEntradaOficialDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeEntradaOficialDTO FirstByPayloadHash(string value )
        {
            var query = _query.FirstByPayloadHashQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeEntradaOficialDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeEntradaOficialDTO FirstByPayloadStorageKey(string value )
        {
            var query = _query.FirstByPayloadStorageKeyQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeEntradaOficialDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeEntradaOficialDTO FirstByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeEntradaOficialDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeEntradaOficialDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeEntradaOficialDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeEntradaOficialDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeEntradaOficialDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeEntradaOficialDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeEntradaOficialDTO>(query.Query, query.Parameters);
                return result;
        }

        public CTeEntradaOficialDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CTeEntradaOficialDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<CTeEntradaOficialDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<CTeEntradaOficialDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeEntradaOficialDTO> GetAllByCorrelationId(string value )
        {
            var query = _query.FirstByCorrelationIdQuery(value );

                var result = _unitOfWork.Query<CTeEntradaOficialDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeEntradaOficialDTO> GetAllBySourceApplication(string value )
        {
            var query = _query.FirstBySourceApplicationQuery(value );

                var result = _unitOfWork.Query<CTeEntradaOficialDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeEntradaOficialDTO> GetAllBySourceModule(string value )
        {
            var query = _query.FirstBySourceModuleQuery(value );

                var result = _unitOfWork.Query<CTeEntradaOficialDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeEntradaOficialDTO> GetAllBySourceMessageId(string value )
        {
            var query = _query.FirstBySourceMessageIdQuery(value );

                var result = _unitOfWork.Query<CTeEntradaOficialDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeEntradaOficialDTO> GetAllByMessageType(string value )
        {
            var query = _query.FirstByMessageTypeQuery(value );

                var result = _unitOfWork.Query<CTeEntradaOficialDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeEntradaOficialDTO> GetAllByMessageVersion(string value )
        {
            var query = _query.FirstByMessageVersionQuery(value );

                var result = _unitOfWork.Query<CTeEntradaOficialDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeEntradaOficialDTO> GetAllByReceivedAtUtc(DateTime value )
        {
            var query = _query.FirstByReceivedAtUtcQuery(value );

                var result = _unitOfWork.Query<CTeEntradaOficialDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeEntradaOficialDTO> GetAllByPayloadHash(string value )
        {
            var query = _query.FirstByPayloadHashQuery(value );

                var result = _unitOfWork.Query<CTeEntradaOficialDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeEntradaOficialDTO> GetAllByPayloadStorageKey(string value )
        {
            var query = _query.FirstByPayloadStorageKeyQuery(value );

                var result = _unitOfWork.Query<CTeEntradaOficialDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeEntradaOficialDTO> GetAllByStatus(int value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.Query<CTeEntradaOficialDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeEntradaOficialDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<CTeEntradaOficialDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeEntradaOficialDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<CTeEntradaOficialDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeEntradaOficialDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<CTeEntradaOficialDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<CTeEntradaOficialDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<CTeEntradaOficialDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration