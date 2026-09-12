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
    public partial class yTokenReadRepository : IyTokenReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IyTokenQueryRead _query;

        public yTokenReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IyTokenQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetyTokenCustom(Command.Read.yTokenReadCommand command, ref DataPagination<yTokenDTO> result, ref bool handled);

        public DataPagination<yTokenDTO> getyToken(ICommandRead command , bool TakeOffTenantID = false)
         {
            if (command is Command.Read.yTokenReadCommand c)
                return getyToken(c , TakeOffTenantID);
            throw new NotImplementedException();
        }
        private DataPagination<yTokenDTO> getyToken(Command.Read.yTokenReadCommand command , bool TakeOffTenantID = false)
        {
            var customResult = new DataPagination<yTokenDTO>();
            var customHandled = false;
            TryGetyTokenCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.yTokenQuery(command , TakeOffTenantID);

                var itens = _unitOfWork.Query<yTokenDTO>(query.Query,query.Parameters);
                return new DataPagination<yTokenDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<yTokenTenantIDDTO> getyTokenReadFKTenantID(Command.Patterns.Command.SearchFKCommand command , bool TakeOffTenantID = false)
        {
            var query = _query.yTokenTenantIDQuery(command , TakeOffTenantID);

                var lista = _unitOfWork.Query<yTokenTenantIDDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<yTokenTenantIDDTO> getyTokenReadFKTenantID(object command , bool TakeOffTenantID = false)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyTokenReadFKTenantID(c , TakeOffTenantID);
            }
            throw new NotImplementedException();
        }

        private IEnumerable<yTokenUserIdDTO> getyTokenReadFKUserId(Command.Patterns.Command.SearchFKCommand command , bool TakeOffTenantID = false)
        {
            var query = _query.yTokenUserIdQuery(command , TakeOffTenantID);

                var lista = _unitOfWork.Query<yTokenUserIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<yTokenUserIdDTO> getyTokenReadFKUserId(object command , bool TakeOffTenantID = false)
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyTokenReadFKUserId(c , TakeOffTenantID);
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTokenHash(string value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByTokenHashQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDescription(string value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByDescriptionQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByConnectorKey(string value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByConnectorKeyQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByActive(bool value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByActiveQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByValidUntil(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByValidUntilQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCreatedAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByCreatedAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByLastUsedAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByLastUsedAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTenantID(int value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByTenantIDQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUserId(int value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByUserIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDeleted(bool value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByDeletedQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByChanged(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.ExistsByChangedQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public yTokenDTO FirstById(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yTokenDTO>(query.Query, query.Parameters);
                return result;
        }

        public yTokenDTO FirstByTokenHash(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByTokenHashQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yTokenDTO>(query.Query, query.Parameters);
                return result;
        }

        public yTokenDTO FirstByDescription(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByDescriptionQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yTokenDTO>(query.Query, query.Parameters);
                return result;
        }

        public yTokenDTO FirstByConnectorKey(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByConnectorKeyQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yTokenDTO>(query.Query, query.Parameters);
                return result;
        }

        public yTokenDTO FirstByActive(bool value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByActiveQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yTokenDTO>(query.Query, query.Parameters);
                return result;
        }

        public yTokenDTO FirstByValidUntil(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByValidUntilQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yTokenDTO>(query.Query, query.Parameters);
                return result;
        }

        public yTokenDTO FirstByCreatedAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByCreatedAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yTokenDTO>(query.Query, query.Parameters);
                return result;
        }

        public yTokenDTO FirstByLastUsedAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByLastUsedAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yTokenDTO>(query.Query, query.Parameters);
                return result;
        }

        public yTokenDTO FirstByTenantID(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByTenantIDQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yTokenDTO>(query.Query, query.Parameters);
                return result;
        }

        public yTokenDTO FirstByUserId(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByUserIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yTokenDTO>(query.Query, query.Parameters);
                return result;
        }

        public yTokenDTO FirstByDeleted(bool value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByDeletedQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yTokenDTO>(query.Query, query.Parameters);
                return result;
        }

        public yTokenDTO FirstByChanged(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByChangedQuery(value , TakeOffTenantID);

                var result = _unitOfWork.QueryFirstOrDefault<yTokenDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<yTokenDTO> GetAllById(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yTokenDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<yTokenDTO> GetAllByTokenHash(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByTokenHashQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yTokenDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<yTokenDTO> GetAllByDescription(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByDescriptionQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yTokenDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<yTokenDTO> GetAllByConnectorKey(string value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByConnectorKeyQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yTokenDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<yTokenDTO> GetAllByActive(bool value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByActiveQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yTokenDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<yTokenDTO> GetAllByValidUntil(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByValidUntilQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yTokenDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<yTokenDTO> GetAllByCreatedAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByCreatedAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yTokenDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<yTokenDTO> GetAllByLastUsedAt(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByLastUsedAtQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yTokenDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<yTokenDTO> GetAllByTenantID(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByTenantIDQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yTokenDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<yTokenDTO> GetAllByUserId(int value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByUserIdQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yTokenDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<yTokenDTO> GetAllByDeleted(bool value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByDeletedQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yTokenDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<yTokenDTO> GetAllByChanged(DateTime value , bool TakeOffTenantID = false)
        {
            var query = _query.FirstByChangedQuery(value , TakeOffTenantID);

                var result = _unitOfWork.Query<yTokenDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration