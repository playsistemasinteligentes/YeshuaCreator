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
    public partial class VersaoCustoReadRepository : IVersaoCustoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IVersaoCustoQueryRead _query;

        public VersaoCustoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IVersaoCustoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetVersaoCustoCustom(Command.Read.VersaoCustoReadCommand command, ref DataPagination<VersaoCustoDTO> result, ref bool handled);

        public DataPagination<VersaoCustoDTO> getVersaoCusto(ICommandRead command )
         {
            if (command is Command.Read.VersaoCustoReadCommand c)
                return getVersaoCusto(c );
            throw new NotImplementedException();
        }
        private DataPagination<VersaoCustoDTO> getVersaoCusto(Command.Read.VersaoCustoReadCommand command )
        {
            DataPagination<VersaoCustoDTO> customResult = null;
            var customHandled = false;
            TryGetVersaoCustoCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.VersaoCustoQuery(command );

                var itens = _unitOfWork.Query<VersaoCustoDTO>(query.Query,query.Parameters);
                return new DataPagination<VersaoCustoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<VersaoCustoTenantIDDTO> getVersaoCustoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<VersaoCustoTenantIDDTO> lista;
            var query = _query.VersaoCustoTenantIDQuery(command );

                lista = _unitOfWork.Query<VersaoCustoTenantIDDTO>(query.Query,query.Parameters) as List<VersaoCustoTenantIDDTO>;
            return lista;
        }

        public IEnumerable<VersaoCustoTenantIDDTO> getVersaoCustoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getVersaoCustoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<VersaoCustoUserIdDTO> getVersaoCustoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<VersaoCustoUserIdDTO> lista;
            var query = _query.VersaoCustoUserIdQuery(command );

                lista = _unitOfWork.Query<VersaoCustoUserIdDTO>(query.Query,query.Parameters) as List<VersaoCustoUserIdDTO>;
            return lista;
        }

        public IEnumerable<VersaoCustoUserIdDTO> getVersaoCustoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getVersaoCustoReadFKUserId(c );
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

        public VersaoCustoDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VersaoCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public VersaoCustoDTO FirstByVER_ID(int value )
        {
            var query = _query.FirstByVER_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VersaoCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public VersaoCustoDTO FirstByVER_STATUS(string value )
        {
            var query = _query.FirstByVER_STATUSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VersaoCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public VersaoCustoDTO FirstByVER_OBS(string value )
        {
            var query = _query.FirstByVER_OBSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VersaoCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public VersaoCustoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VersaoCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public VersaoCustoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VersaoCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public VersaoCustoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VersaoCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public VersaoCustoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VersaoCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<VersaoCustoDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<VersaoCustoDTO>(query.Query,query.Parameters) as List<VersaoCustoDTO>;
                return result;
        }

        public IEnumerable<VersaoCustoDTO> GetAllByVER_ID(int value )
        {
            var query = _query.FirstByVER_IDQuery(value );

                var result = _unitOfWork.Query<VersaoCustoDTO>(query.Query,query.Parameters) as List<VersaoCustoDTO>;
                return result;
        }

        public IEnumerable<VersaoCustoDTO> GetAllByVER_STATUS(string value )
        {
            var query = _query.FirstByVER_STATUSQuery(value );

                var result = _unitOfWork.Query<VersaoCustoDTO>(query.Query,query.Parameters) as List<VersaoCustoDTO>;
                return result;
        }

        public IEnumerable<VersaoCustoDTO> GetAllByVER_OBS(string value )
        {
            var query = _query.FirstByVER_OBSQuery(value );

                var result = _unitOfWork.Query<VersaoCustoDTO>(query.Query,query.Parameters) as List<VersaoCustoDTO>;
                return result;
        }

        public IEnumerable<VersaoCustoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<VersaoCustoDTO>(query.Query,query.Parameters) as List<VersaoCustoDTO>;
                return result;
        }

        public IEnumerable<VersaoCustoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<VersaoCustoDTO>(query.Query,query.Parameters) as List<VersaoCustoDTO>;
                return result;
        }

        public IEnumerable<VersaoCustoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<VersaoCustoDTO>(query.Query,query.Parameters) as List<VersaoCustoDTO>;
                return result;
        }

        public IEnumerable<VersaoCustoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<VersaoCustoDTO>(query.Query,query.Parameters) as List<VersaoCustoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration