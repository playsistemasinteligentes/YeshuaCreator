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
    public partial class TiposVincoOndasReadRepository : ITiposVincoOndasReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ITiposVincoOndasQueryRead _query;

        public TiposVincoOndasReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ITiposVincoOndasQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<TiposVincoOndasDTO> getTiposVincoOndas(ICommandRead command )
         {
            if (command is Command.Read.TiposVincoOndasReadCommand c)
                return getTiposVincoOndas(c );
            throw new NotImplementedException();
        }
        private DataPagination<TiposVincoOndasDTO> getTiposVincoOndas(Command.Read.TiposVincoOndasReadCommand command )
        {
            var query = _query.TiposVincoOndasQuery(command );

                var itens = _unitOfWork.Query<TiposVincoOndasDTO>(query.Query,query.Parameters);
                return new DataPagination<TiposVincoOndasDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<TiposVincoOndasTenantIDDTO> getTiposVincoOndasReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TiposVincoOndasTenantIDDTO> lista;
            var query = _query.TiposVincoOndasTenantIDQuery(command );

                lista = _unitOfWork.Query<TiposVincoOndasTenantIDDTO>(query.Query,query.Parameters) as List<TiposVincoOndasTenantIDDTO>;
            return lista;
        }

        public IEnumerable<TiposVincoOndasTenantIDDTO> getTiposVincoOndasReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTiposVincoOndasReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<TiposVincoOndasUserIdDTO> getTiposVincoOndasReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TiposVincoOndasUserIdDTO> lista;
            var query = _query.TiposVincoOndasUserIdQuery(command );

                lista = _unitOfWork.Query<TiposVincoOndasUserIdDTO>(query.Query,query.Parameters) as List<TiposVincoOndasUserIdDTO>;
            return lista;
        }

        public IEnumerable<TiposVincoOndasUserIdDTO> getTiposVincoOndasReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTiposVincoOndasReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsById2(int value )
        {
            var query = _query.ExistsById2Query(value );

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

        public TiposVincoOndasDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TiposVincoOndasDTO>(query.Query, query.Parameters);
                return result;
        }

        public TiposVincoOndasDTO FirstById2(int value )
        {
            var query = _query.FirstById2Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<TiposVincoOndasDTO>(query.Query, query.Parameters);
                return result;
        }

        public TiposVincoOndasDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TiposVincoOndasDTO>(query.Query, query.Parameters);
                return result;
        }

        public TiposVincoOndasDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TiposVincoOndasDTO>(query.Query, query.Parameters);
                return result;
        }

        public TiposVincoOndasDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TiposVincoOndasDTO>(query.Query, query.Parameters);
                return result;
        }

        public TiposVincoOndasDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TiposVincoOndasDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<TiposVincoOndasDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<TiposVincoOndasDTO>(query.Query,query.Parameters) as List<TiposVincoOndasDTO>;
                return result;
        }

        public IEnumerable<TiposVincoOndasDTO> GetAllById2(int value )
        {
            var query = _query.FirstById2Query(value );

                var result = _unitOfWork.Query<TiposVincoOndasDTO>(query.Query,query.Parameters) as List<TiposVincoOndasDTO>;
                return result;
        }

        public IEnumerable<TiposVincoOndasDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<TiposVincoOndasDTO>(query.Query,query.Parameters) as List<TiposVincoOndasDTO>;
                return result;
        }

        public IEnumerable<TiposVincoOndasDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<TiposVincoOndasDTO>(query.Query,query.Parameters) as List<TiposVincoOndasDTO>;
                return result;
        }

        public IEnumerable<TiposVincoOndasDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<TiposVincoOndasDTO>(query.Query,query.Parameters) as List<TiposVincoOndasDTO>;
                return result;
        }

        public IEnumerable<TiposVincoOndasDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<TiposVincoOndasDTO>(query.Query,query.Parameters) as List<TiposVincoOndasDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration