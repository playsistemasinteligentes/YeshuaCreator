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
    public partial class RespInspVisualReadRepository : IRespInspVisualReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IRespInspVisualQueryRead _query;

        public RespInspVisualReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IRespInspVisualQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<RespInspVisualDTO> getRespInspVisual(ICommandRead command )
         {
            if (command is Command.Read.RespInspVisualReadCommand c)
                return getRespInspVisual(c );
            throw new NotImplementedException();
        }
        private DataPagination<RespInspVisualDTO> getRespInspVisual(Command.Read.RespInspVisualReadCommand command )
        {
            var query = _query.RespInspVisualQuery(command );

                var itens = _unitOfWork.Query<RespInspVisualDTO>(query.Query,query.Parameters);
                return new DataPagination<RespInspVisualDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<RespInspVisualTenantIDDTO> getRespInspVisualReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<RespInspVisualTenantIDDTO> lista;
            var query = _query.RespInspVisualTenantIDQuery(command );

                lista = _unitOfWork.Query<RespInspVisualTenantIDDTO>(query.Query,query.Parameters) as List<RespInspVisualTenantIDDTO>;
            return lista;
        }

        public IEnumerable<RespInspVisualTenantIDDTO> getRespInspVisualReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getRespInspVisualReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<RespInspVisualUserIdDTO> getRespInspVisualReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<RespInspVisualUserIdDTO> lista;
            var query = _query.RespInspVisualUserIdQuery(command );

                lista = _unitOfWork.Query<RespInspVisualUserIdDTO>(query.Query,query.Parameters) as List<RespInspVisualUserIdDTO>;
            return lista;
        }

        public IEnumerable<RespInspVisualUserIdDTO> getRespInspVisualReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getRespInspVisualReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByRIV_ID(int value )
        {
            var query = _query.ExistsByRIV_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByIPV_ID(int value )
        {
            var query = _query.ExistsByIPV_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByITI_ID(int value )
        {
            var query = _query.ExistsByITI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByRIV_STATUS(string value )
        {
            var query = _query.ExistsByRIV_STATUSQuery(value );

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

        public RespInspVisualDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RespInspVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public RespInspVisualDTO FirstByRIV_ID(int value )
        {
            var query = _query.FirstByRIV_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RespInspVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public RespInspVisualDTO FirstByIPV_ID(int value )
        {
            var query = _query.FirstByIPV_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RespInspVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public RespInspVisualDTO FirstByITI_ID(int value )
        {
            var query = _query.FirstByITI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RespInspVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public RespInspVisualDTO FirstByRIV_STATUS(string value )
        {
            var query = _query.FirstByRIV_STATUSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RespInspVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public RespInspVisualDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RespInspVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public RespInspVisualDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RespInspVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public RespInspVisualDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RespInspVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public RespInspVisualDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RespInspVisualDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<RespInspVisualDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<RespInspVisualDTO>(query.Query,query.Parameters) as List<RespInspVisualDTO>;
                return result;
        }

        public IEnumerable<RespInspVisualDTO> GetAllByRIV_ID(int value )
        {
            var query = _query.FirstByRIV_IDQuery(value );

                var result = _unitOfWork.Query<RespInspVisualDTO>(query.Query,query.Parameters) as List<RespInspVisualDTO>;
                return result;
        }

        public IEnumerable<RespInspVisualDTO> GetAllByIPV_ID(int value )
        {
            var query = _query.FirstByIPV_IDQuery(value );

                var result = _unitOfWork.Query<RespInspVisualDTO>(query.Query,query.Parameters) as List<RespInspVisualDTO>;
                return result;
        }

        public IEnumerable<RespInspVisualDTO> GetAllByITI_ID(int value )
        {
            var query = _query.FirstByITI_IDQuery(value );

                var result = _unitOfWork.Query<RespInspVisualDTO>(query.Query,query.Parameters) as List<RespInspVisualDTO>;
                return result;
        }

        public IEnumerable<RespInspVisualDTO> GetAllByRIV_STATUS(string value )
        {
            var query = _query.FirstByRIV_STATUSQuery(value );

                var result = _unitOfWork.Query<RespInspVisualDTO>(query.Query,query.Parameters) as List<RespInspVisualDTO>;
                return result;
        }

        public IEnumerable<RespInspVisualDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<RespInspVisualDTO>(query.Query,query.Parameters) as List<RespInspVisualDTO>;
                return result;
        }

        public IEnumerable<RespInspVisualDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<RespInspVisualDTO>(query.Query,query.Parameters) as List<RespInspVisualDTO>;
                return result;
        }

        public IEnumerable<RespInspVisualDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<RespInspVisualDTO>(query.Query,query.Parameters) as List<RespInspVisualDTO>;
                return result;
        }

        public IEnumerable<RespInspVisualDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<RespInspVisualDTO>(query.Query,query.Parameters) as List<RespInspVisualDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration