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
    public partial class RodoviasReadRepository : IRodoviasReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IRodoviasQueryRead _query;

        public RodoviasReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IRodoviasQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<RodoviasDTO> getRodovias(ICommandRead command )
         {
            if (command is Command.Read.RodoviasReadCommand c)
                return getRodovias(c );
            throw new NotImplementedException();
        }
        private DataPagination<RodoviasDTO> getRodovias(Command.Read.RodoviasReadCommand command )
        {
            var query = _query.RodoviasQuery(command );

                var itens = _unitOfWork.Query<RodoviasDTO>(query.Query,query.Parameters);
                return new DataPagination<RodoviasDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<RodoviasTenantIDDTO> getRodoviasReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<RodoviasTenantIDDTO> lista;
            var query = _query.RodoviasTenantIDQuery(command );

                lista = _unitOfWork.Query<RodoviasTenantIDDTO>(query.Query,query.Parameters) as List<RodoviasTenantIDDTO>;
            return lista;
        }

        public IEnumerable<RodoviasTenantIDDTO> getRodoviasReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getRodoviasReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<RodoviasUserIdDTO> getRodoviasReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<RodoviasUserIdDTO> lista;
            var query = _query.RodoviasUserIdQuery(command );

                lista = _unitOfWork.Query<RodoviasUserIdDTO>(query.Query,query.Parameters) as List<RodoviasUserIdDTO>;
            return lista;
        }

        public IEnumerable<RodoviasUserIdDTO> getRodoviasReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getRodoviasReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByROD_ID(int value )
        {
            var query = _query.ExistsByROD_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByROD_DESCRICAO(string value )
        {
            var query = _query.ExistsByROD_DESCRICAOQuery(value );

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

        public RodoviasDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RodoviasDTO>(query.Query, query.Parameters);
                return result;
        }

        public RodoviasDTO FirstByROD_ID(int value )
        {
            var query = _query.FirstByROD_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RodoviasDTO>(query.Query, query.Parameters);
                return result;
        }

        public RodoviasDTO FirstByROD_DESCRICAO(string value )
        {
            var query = _query.FirstByROD_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RodoviasDTO>(query.Query, query.Parameters);
                return result;
        }

        public RodoviasDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RodoviasDTO>(query.Query, query.Parameters);
                return result;
        }

        public RodoviasDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RodoviasDTO>(query.Query, query.Parameters);
                return result;
        }

        public RodoviasDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RodoviasDTO>(query.Query, query.Parameters);
                return result;
        }

        public RodoviasDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RodoviasDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<RodoviasDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<RodoviasDTO>(query.Query,query.Parameters) as List<RodoviasDTO>;
                return result;
        }

        public IEnumerable<RodoviasDTO> GetAllByROD_ID(int value )
        {
            var query = _query.FirstByROD_IDQuery(value );

                var result = _unitOfWork.Query<RodoviasDTO>(query.Query,query.Parameters) as List<RodoviasDTO>;
                return result;
        }

        public IEnumerable<RodoviasDTO> GetAllByROD_DESCRICAO(string value )
        {
            var query = _query.FirstByROD_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<RodoviasDTO>(query.Query,query.Parameters) as List<RodoviasDTO>;
                return result;
        }

        public IEnumerable<RodoviasDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<RodoviasDTO>(query.Query,query.Parameters) as List<RodoviasDTO>;
                return result;
        }

        public IEnumerable<RodoviasDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<RodoviasDTO>(query.Query,query.Parameters) as List<RodoviasDTO>;
                return result;
        }

        public IEnumerable<RodoviasDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<RodoviasDTO>(query.Query,query.Parameters) as List<RodoviasDTO>;
                return result;
        }

        public IEnumerable<RodoviasDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<RodoviasDTO>(query.Query,query.Parameters) as List<RodoviasDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration