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
    public partial class T_USER_GRUPOReadRepository : IT_USER_GRUPOReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IT_USER_GRUPOQueryRead _query;

        public T_USER_GRUPOReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IT_USER_GRUPOQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetT_USER_GRUPOCustom(Command.Read.T_USER_GRUPOReadCommand command, ref DataPagination<T_USER_GRUPODTO> result, ref bool handled);

        public DataPagination<T_USER_GRUPODTO> getT_USER_GRUPO(ICommandRead command )
         {
            if (command is Command.Read.T_USER_GRUPOReadCommand c)
                return getT_USER_GRUPO(c );
            throw new NotImplementedException();
        }
        private DataPagination<T_USER_GRUPODTO> getT_USER_GRUPO(Command.Read.T_USER_GRUPOReadCommand command )
        {
            DataPagination<T_USER_GRUPODTO> customResult = null;
            var customHandled = false;
            TryGetT_USER_GRUPOCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.T_USER_GRUPOQuery(command );

                var itens = _unitOfWork.Query<T_USER_GRUPODTO>(query.Query,query.Parameters);
                return new DataPagination<T_USER_GRUPODTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<T_USER_GRUPOGRU_IDDTO> getT_USER_GRUPOReadFKGRU_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<T_USER_GRUPOGRU_IDDTO> lista;
            var query = _query.T_USER_GRUPOGRU_IDQuery(command );

                lista = _unitOfWork.Query<T_USER_GRUPOGRU_IDDTO>(query.Query,query.Parameters) as List<T_USER_GRUPOGRU_IDDTO>;
            return lista;
        }

        public IEnumerable<T_USER_GRUPOGRU_IDDTO> getT_USER_GRUPOReadFKGRU_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getT_USER_GRUPOReadFKGRU_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<T_USER_GRUPOID_USUARIODTO> getT_USER_GRUPOReadFKID_USUARIO(Command.Patterns.Command.SearchFKCommand command )
        {
            List<T_USER_GRUPOID_USUARIODTO> lista;
            var query = _query.T_USER_GRUPOID_USUARIOQuery(command );

                lista = _unitOfWork.Query<T_USER_GRUPOID_USUARIODTO>(query.Query,query.Parameters) as List<T_USER_GRUPOID_USUARIODTO>;
            return lista;
        }

        public IEnumerable<T_USER_GRUPOID_USUARIODTO> getT_USER_GRUPOReadFKID_USUARIO(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getT_USER_GRUPOReadFKID_USUARIO(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<T_USER_GRUPOTenantIDDTO> getT_USER_GRUPOReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<T_USER_GRUPOTenantIDDTO> lista;
            var query = _query.T_USER_GRUPOTenantIDQuery(command );

                lista = _unitOfWork.Query<T_USER_GRUPOTenantIDDTO>(query.Query,query.Parameters) as List<T_USER_GRUPOTenantIDDTO>;
            return lista;
        }

        public IEnumerable<T_USER_GRUPOTenantIDDTO> getT_USER_GRUPOReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getT_USER_GRUPOReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<T_USER_GRUPOUserIdDTO> getT_USER_GRUPOReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<T_USER_GRUPOUserIdDTO> lista;
            var query = _query.T_USER_GRUPOUserIdQuery(command );

                lista = _unitOfWork.Query<T_USER_GRUPOUserIdDTO>(query.Query,query.Parameters) as List<T_USER_GRUPOUserIdDTO>;
            return lista;
        }

        public IEnumerable<T_USER_GRUPOUserIdDTO> getT_USER_GRUPOReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getT_USER_GRUPOReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRU_ID(int value )
        {
            var query = _query.ExistsByGRU_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByID_USUARIO(int value )
        {
            var query = _query.ExistsByID_USUARIOQuery(value );

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

        public T_USER_GRUPODTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_USER_GRUPODTO>(query.Query, query.Parameters);
                return result;
        }

        public T_USER_GRUPODTO FirstByGRU_ID(int value )
        {
            var query = _query.FirstByGRU_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_USER_GRUPODTO>(query.Query, query.Parameters);
                return result;
        }

        public T_USER_GRUPODTO FirstByID_USUARIO(int value )
        {
            var query = _query.FirstByID_USUARIOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_USER_GRUPODTO>(query.Query, query.Parameters);
                return result;
        }

        public T_USER_GRUPODTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_USER_GRUPODTO>(query.Query, query.Parameters);
                return result;
        }

        public T_USER_GRUPODTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_USER_GRUPODTO>(query.Query, query.Parameters);
                return result;
        }

        public T_USER_GRUPODTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_USER_GRUPODTO>(query.Query, query.Parameters);
                return result;
        }

        public T_USER_GRUPODTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_USER_GRUPODTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<T_USER_GRUPODTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<T_USER_GRUPODTO>(query.Query,query.Parameters) as List<T_USER_GRUPODTO>;
                return result;
        }

        public IEnumerable<T_USER_GRUPODTO> GetAllByGRU_ID(int value )
        {
            var query = _query.FirstByGRU_IDQuery(value );

                var result = _unitOfWork.Query<T_USER_GRUPODTO>(query.Query,query.Parameters) as List<T_USER_GRUPODTO>;
                return result;
        }

        public IEnumerable<T_USER_GRUPODTO> GetAllByID_USUARIO(int value )
        {
            var query = _query.FirstByID_USUARIOQuery(value );

                var result = _unitOfWork.Query<T_USER_GRUPODTO>(query.Query,query.Parameters) as List<T_USER_GRUPODTO>;
                return result;
        }

        public IEnumerable<T_USER_GRUPODTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<T_USER_GRUPODTO>(query.Query,query.Parameters) as List<T_USER_GRUPODTO>;
                return result;
        }

        public IEnumerable<T_USER_GRUPODTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<T_USER_GRUPODTO>(query.Query,query.Parameters) as List<T_USER_GRUPODTO>;
                return result;
        }

        public IEnumerable<T_USER_GRUPODTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<T_USER_GRUPODTO>(query.Query,query.Parameters) as List<T_USER_GRUPODTO>;
                return result;
        }

        public IEnumerable<T_USER_GRUPODTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<T_USER_GRUPODTO>(query.Query,query.Parameters) as List<T_USER_GRUPODTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration