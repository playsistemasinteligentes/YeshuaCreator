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
    public partial class yTenantApplicationReadRepository : IyTenantApplicationReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IyTenantApplicationQueryRead _query;

        public yTenantApplicationReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IyTenantApplicationQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetyTenantApplicationCustom(Command.Read.yTenantApplicationReadCommand command, ref DataPagination<yTenantApplicationDTO> result, ref bool handled);

        public DataPagination<yTenantApplicationDTO> getyTenantApplication(ICommandRead command )
         {
            if (command is Command.Read.yTenantApplicationReadCommand c)
                return getyTenantApplication(c );
            throw new NotImplementedException();
        }
        private DataPagination<yTenantApplicationDTO> getyTenantApplication(Command.Read.yTenantApplicationReadCommand command )
        {
            var customResult = new DataPagination<yTenantApplicationDTO>();
            var customHandled = false;
            TryGetyTenantApplicationCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.yTenantApplicationQuery(command );

                var itens = _unitOfWork.Query<yTenantApplicationDTO>(query.Query,query.Parameters);
                return new DataPagination<yTenantApplicationDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<yTenantApplicationTenantIDDTO> getyTenantApplicationReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.yTenantApplicationTenantIDQuery(command );

                var lista = _unitOfWork.Query<yTenantApplicationTenantIDDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<yTenantApplicationTenantIDDTO> getyTenantApplicationReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyTenantApplicationReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<yTenantApplicationUserIdDTO> getyTenantApplicationReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.yTenantApplicationUserIdQuery(command );

                var lista = _unitOfWork.Query<yTenantApplicationUserIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<yTenantApplicationUserIdDTO> getyTenantApplicationReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyTenantApplicationReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByApplicationKey(string value )
        {
            var query = _query.ExistsByApplicationKeyQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTenantID(int value )
        {
            var query = _query.ExistsByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByValidUntil(DateTime value )
        {
            var query = _query.ExistsByValidUntilQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOperationalEntityId(string value )
        {
            var query = _query.ExistsByOperationalEntityIdQuery(value );

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

        public yTenantApplicationDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yTenantApplicationDTO>(query.Query, query.Parameters);
                return result;
        }

        public yTenantApplicationDTO FirstByApplicationKey(string value )
        {
            var query = _query.FirstByApplicationKeyQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yTenantApplicationDTO>(query.Query, query.Parameters);
                return result;
        }

        public yTenantApplicationDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yTenantApplicationDTO>(query.Query, query.Parameters);
                return result;
        }

        public yTenantApplicationDTO FirstByValidUntil(DateTime value )
        {
            var query = _query.FirstByValidUntilQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yTenantApplicationDTO>(query.Query, query.Parameters);
                return result;
        }

        public yTenantApplicationDTO FirstByOperationalEntityId(string value )
        {
            var query = _query.FirstByOperationalEntityIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yTenantApplicationDTO>(query.Query, query.Parameters);
                return result;
        }

        public yTenantApplicationDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yTenantApplicationDTO>(query.Query, query.Parameters);
                return result;
        }

        public yTenantApplicationDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yTenantApplicationDTO>(query.Query, query.Parameters);
                return result;
        }

        public yTenantApplicationDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yTenantApplicationDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<yTenantApplicationDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<yTenantApplicationDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<yTenantApplicationDTO> GetAllByApplicationKey(string value )
        {
            var query = _query.FirstByApplicationKeyQuery(value );

                var result = _unitOfWork.Query<yTenantApplicationDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<yTenantApplicationDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<yTenantApplicationDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<yTenantApplicationDTO> GetAllByValidUntil(DateTime value )
        {
            var query = _query.FirstByValidUntilQuery(value );

                var result = _unitOfWork.Query<yTenantApplicationDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<yTenantApplicationDTO> GetAllByOperationalEntityId(string value )
        {
            var query = _query.FirstByOperationalEntityIdQuery(value );

                var result = _unitOfWork.Query<yTenantApplicationDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<yTenantApplicationDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<yTenantApplicationDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<yTenantApplicationDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<yTenantApplicationDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<yTenantApplicationDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<yTenantApplicationDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration