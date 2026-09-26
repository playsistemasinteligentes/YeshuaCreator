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
    public partial class TenantCatalogoReadRepository : ITenantCatalogoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ITenantCatalogoQueryRead _query;

        public TenantCatalogoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ITenantCatalogoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetTenantCatalogoCustom(Command.Read.TenantCatalogoReadCommand command, ref DataPagination<TenantCatalogoDTO> result, ref bool handled);

        public DataPagination<TenantCatalogoDTO> getTenantCatalogo(ICommandRead command )
         {
            if (command is Command.Read.TenantCatalogoReadCommand c)
                return getTenantCatalogo(c );
            throw new NotImplementedException();
        }
        private DataPagination<TenantCatalogoDTO> getTenantCatalogo(Command.Read.TenantCatalogoReadCommand command )
        {
            var customResult = new DataPagination<TenantCatalogoDTO>();
            var customHandled = false;
            TryGetTenantCatalogoCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.TenantCatalogoQuery(command );

                var itens = _unitOfWork.Query<TenantCatalogoDTO>(query.Query,query.Parameters);
                return new DataPagination<TenantCatalogoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<TenantCatalogoTenantIDDTO> getTenantCatalogoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.TenantCatalogoTenantIDQuery(command );

                var lista = _unitOfWork.Query<TenantCatalogoTenantIDDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<TenantCatalogoTenantIDDTO> getTenantCatalogoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTenantCatalogoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<TenantCatalogoUserIdDTO> getTenantCatalogoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.TenantCatalogoUserIdQuery(command );

                var lista = _unitOfWork.Query<TenantCatalogoUserIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<TenantCatalogoUserIdDTO> getTenantCatalogoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTenantCatalogoReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCatalogo(string value )
        {
            var query = _query.ExistsByCatalogoQuery(value );

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

        public TenantCatalogoDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TenantCatalogoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TenantCatalogoDTO FirstByCatalogo(string value )
        {
            var query = _query.FirstByCatalogoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TenantCatalogoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TenantCatalogoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TenantCatalogoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TenantCatalogoDTO FirstByValidUntil(DateTime value )
        {
            var query = _query.FirstByValidUntilQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TenantCatalogoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TenantCatalogoDTO FirstByOperationalEntityId(string value )
        {
            var query = _query.FirstByOperationalEntityIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TenantCatalogoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TenantCatalogoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TenantCatalogoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TenantCatalogoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TenantCatalogoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TenantCatalogoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TenantCatalogoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<TenantCatalogoDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<TenantCatalogoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<TenantCatalogoDTO> GetAllByCatalogo(string value )
        {
            var query = _query.FirstByCatalogoQuery(value );

                var result = _unitOfWork.Query<TenantCatalogoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<TenantCatalogoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<TenantCatalogoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<TenantCatalogoDTO> GetAllByValidUntil(DateTime value )
        {
            var query = _query.FirstByValidUntilQuery(value );

                var result = _unitOfWork.Query<TenantCatalogoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<TenantCatalogoDTO> GetAllByOperationalEntityId(string value )
        {
            var query = _query.FirstByOperationalEntityIdQuery(value );

                var result = _unitOfWork.Query<TenantCatalogoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<TenantCatalogoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<TenantCatalogoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<TenantCatalogoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<TenantCatalogoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<TenantCatalogoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<TenantCatalogoDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration