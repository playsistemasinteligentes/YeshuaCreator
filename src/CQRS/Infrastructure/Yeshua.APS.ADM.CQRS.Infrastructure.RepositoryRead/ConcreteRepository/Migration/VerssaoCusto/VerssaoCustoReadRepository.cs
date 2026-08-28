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
    public partial class VerssaoCustoReadRepository : IVerssaoCustoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IVerssaoCustoQueryRead _query;

        public VerssaoCustoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IVerssaoCustoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<VerssaoCustoDTO> getVerssaoCusto(ICommandRead command )
         {
            if (command is Command.Read.VerssaoCustoReadCommand c)
                return getVerssaoCusto(c );
            throw new NotImplementedException();
        }
        private DataPagination<VerssaoCustoDTO> getVerssaoCusto(Command.Read.VerssaoCustoReadCommand command )
        {
            var query = _query.VerssaoCustoQuery(command );

                var itens = _unitOfWork.Query<VerssaoCustoDTO>(query.Query,query.Parameters);
                return new DataPagination<VerssaoCustoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<VerssaoCustoTenantIDDTO> getVerssaoCustoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<VerssaoCustoTenantIDDTO> lista;
            var query = _query.VerssaoCustoTenantIDQuery(command );

                lista = _unitOfWork.Query<VerssaoCustoTenantIDDTO>(query.Query,query.Parameters) as List<VerssaoCustoTenantIDDTO>;
            return lista;
        }

        public IEnumerable<VerssaoCustoTenantIDDTO> getVerssaoCustoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getVerssaoCustoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<VerssaoCustoUserIdDTO> getVerssaoCustoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<VerssaoCustoUserIdDTO> lista;
            var query = _query.VerssaoCustoUserIdQuery(command );

                lista = _unitOfWork.Query<VerssaoCustoUserIdDTO>(query.Query,query.Parameters) as List<VerssaoCustoUserIdDTO>;
            return lista;
        }

        public IEnumerable<VerssaoCustoUserIdDTO> getVerssaoCustoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getVerssaoCustoReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByVER_ID(int value )
        {
            var query = _query.ExistsByVER_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByVER_STATUS(string value )
        {
            var query = _query.ExistsByVER_STATUSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByVER_DATA_VERSSAO_CUSTO(DateTime value )
        {
            var query = _query.ExistsByVER_DATA_VERSSAO_CUSTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByVER_OBS(string value )
        {
            var query = _query.ExistsByVER_OBSQuery(value );

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

        public VerssaoCustoDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VerssaoCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public VerssaoCustoDTO FirstByVER_ID(int value )
        {
            var query = _query.FirstByVER_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VerssaoCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public VerssaoCustoDTO FirstByVER_STATUS(string value )
        {
            var query = _query.FirstByVER_STATUSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VerssaoCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public VerssaoCustoDTO FirstByVER_DATA_VERSSAO_CUSTO(DateTime value )
        {
            var query = _query.FirstByVER_DATA_VERSSAO_CUSTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VerssaoCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public VerssaoCustoDTO FirstByVER_OBS(string value )
        {
            var query = _query.FirstByVER_OBSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VerssaoCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public VerssaoCustoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VerssaoCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public VerssaoCustoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VerssaoCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public VerssaoCustoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VerssaoCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public VerssaoCustoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VerssaoCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<VerssaoCustoDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<VerssaoCustoDTO>(query.Query,query.Parameters) as List<VerssaoCustoDTO>;
                return result;
        }

        public IEnumerable<VerssaoCustoDTO> GetAllByVER_ID(int value )
        {
            var query = _query.FirstByVER_IDQuery(value );

                var result = _unitOfWork.Query<VerssaoCustoDTO>(query.Query,query.Parameters) as List<VerssaoCustoDTO>;
                return result;
        }

        public IEnumerable<VerssaoCustoDTO> GetAllByVER_STATUS(string value )
        {
            var query = _query.FirstByVER_STATUSQuery(value );

                var result = _unitOfWork.Query<VerssaoCustoDTO>(query.Query,query.Parameters) as List<VerssaoCustoDTO>;
                return result;
        }

        public IEnumerable<VerssaoCustoDTO> GetAllByVER_DATA_VERSSAO_CUSTO(DateTime value )
        {
            var query = _query.FirstByVER_DATA_VERSSAO_CUSTOQuery(value );

                var result = _unitOfWork.Query<VerssaoCustoDTO>(query.Query,query.Parameters) as List<VerssaoCustoDTO>;
                return result;
        }

        public IEnumerable<VerssaoCustoDTO> GetAllByVER_OBS(string value )
        {
            var query = _query.FirstByVER_OBSQuery(value );

                var result = _unitOfWork.Query<VerssaoCustoDTO>(query.Query,query.Parameters) as List<VerssaoCustoDTO>;
                return result;
        }

        public IEnumerable<VerssaoCustoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<VerssaoCustoDTO>(query.Query,query.Parameters) as List<VerssaoCustoDTO>;
                return result;
        }

        public IEnumerable<VerssaoCustoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<VerssaoCustoDTO>(query.Query,query.Parameters) as List<VerssaoCustoDTO>;
                return result;
        }

        public IEnumerable<VerssaoCustoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<VerssaoCustoDTO>(query.Query,query.Parameters) as List<VerssaoCustoDTO>;
                return result;
        }

        public IEnumerable<VerssaoCustoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<VerssaoCustoDTO>(query.Query,query.Parameters) as List<VerssaoCustoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration