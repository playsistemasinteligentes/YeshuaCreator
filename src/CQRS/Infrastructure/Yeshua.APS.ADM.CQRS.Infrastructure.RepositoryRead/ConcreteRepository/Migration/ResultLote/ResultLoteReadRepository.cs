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
    public partial class ResultLoteReadRepository : IResultLoteReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IResultLoteQueryRead _query;

        public ResultLoteReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IResultLoteQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<ResultLoteDTO> getResultLote(ICommandRead command )
         {
            if (command is Command.Read.ResultLoteReadCommand c)
                return getResultLote(c );
            throw new NotImplementedException();
        }
        private DataPagination<ResultLoteDTO> getResultLote(Command.Read.ResultLoteReadCommand command )
        {
            var query = _query.ResultLoteQuery(command );

                var itens = _unitOfWork.Query<ResultLoteDTO>(query.Query,query.Parameters);
                return new DataPagination<ResultLoteDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<ResultLoteTenantIDDTO> getResultLoteReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ResultLoteTenantIDDTO> lista;
            var query = _query.ResultLoteTenantIDQuery(command );

                lista = _unitOfWork.Query<ResultLoteTenantIDDTO>(query.Query,query.Parameters) as List<ResultLoteTenantIDDTO>;
            return lista;
        }

        public IEnumerable<ResultLoteTenantIDDTO> getResultLoteReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getResultLoteReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ResultLoteUserIdDTO> getResultLoteReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ResultLoteUserIdDTO> lista;
            var query = _query.ResultLoteUserIdQuery(command );

                lista = _unitOfWork.Query<ResultLoteUserIdDTO>(query.Query,query.Parameters) as List<ResultLoteUserIdDTO>;
            return lista;
        }

        public IEnumerable<ResultLoteUserIdDTO> getResultLoteReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getResultLoteReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

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

        public ResultLoteDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ResultLoteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ResultLoteDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ResultLoteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ResultLoteDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ResultLoteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ResultLoteDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ResultLoteDTO>(query.Query, query.Parameters);
                return result;
        }

        public ResultLoteDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ResultLoteDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<ResultLoteDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<ResultLoteDTO>(query.Query,query.Parameters) as List<ResultLoteDTO>;
                return result;
        }

        public IEnumerable<ResultLoteDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<ResultLoteDTO>(query.Query,query.Parameters) as List<ResultLoteDTO>;
                return result;
        }

        public IEnumerable<ResultLoteDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<ResultLoteDTO>(query.Query,query.Parameters) as List<ResultLoteDTO>;
                return result;
        }

        public IEnumerable<ResultLoteDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<ResultLoteDTO>(query.Query,query.Parameters) as List<ResultLoteDTO>;
                return result;
        }

        public IEnumerable<ResultLoteDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<ResultLoteDTO>(query.Query,query.Parameters) as List<ResultLoteDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration