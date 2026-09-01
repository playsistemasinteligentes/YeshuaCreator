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
    public partial class ParamReadRepository : IParamReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IParamQueryRead _query;

        public ParamReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IParamQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetParamCustom(Command.Read.ParamReadCommand command, ref DataPagination<ParamDTO> result, ref bool handled);

        public DataPagination<ParamDTO> getParam(ICommandRead command )
         {
            if (command is Command.Read.ParamReadCommand c)
                return getParam(c );
            throw new NotImplementedException();
        }
        private DataPagination<ParamDTO> getParam(Command.Read.ParamReadCommand command )
        {
            DataPagination<ParamDTO> customResult = null;
            var customHandled = false;
            TryGetParamCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.ParamQuery(command );

                var itens = _unitOfWork.Query<ParamDTO>(query.Query,query.Parameters);
                return new DataPagination<ParamDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<ParamTenantIDDTO> getParamReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ParamTenantIDDTO> lista;
            var query = _query.ParamTenantIDQuery(command );

                lista = _unitOfWork.Query<ParamTenantIDDTO>(query.Query,query.Parameters) as List<ParamTenantIDDTO>;
            return lista;
        }

        public IEnumerable<ParamTenantIDDTO> getParamReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getParamReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ParamUserIdDTO> getParamReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ParamUserIdDTO> lista;
            var query = _query.ParamUserIdQuery(command );

                lista = _unitOfWork.Query<ParamUserIdDTO>(query.Query,query.Parameters) as List<ParamUserIdDTO>;
            return lista;
        }

        public IEnumerable<ParamUserIdDTO> getParamReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getParamReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByPAR_ID(string value )
        {
            var query = _query.ExistsByPAR_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPAR_DESCRICAO(string value )
        {
            var query = _query.ExistsByPAR_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPAR_VALOR_S(string value )
        {
            var query = _query.ExistsByPAR_VALOR_SQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPAR_VALOR_N(Decimal value )
        {
            var query = _query.ExistsByPAR_VALOR_NQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPAR_VALOR_D(DateTime value )
        {
            var query = _query.ExistsByPAR_VALOR_DQuery(value );

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

        public ParamDTO FirstByPAR_ID(string value )
        {
            var query = _query.FirstByPAR_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ParamDTO>(query.Query, query.Parameters);
                return result;
        }

        public ParamDTO FirstByPAR_DESCRICAO(string value )
        {
            var query = _query.FirstByPAR_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ParamDTO>(query.Query, query.Parameters);
                return result;
        }

        public ParamDTO FirstByPAR_VALOR_S(string value )
        {
            var query = _query.FirstByPAR_VALOR_SQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ParamDTO>(query.Query, query.Parameters);
                return result;
        }

        public ParamDTO FirstByPAR_VALOR_N(Decimal value )
        {
            var query = _query.FirstByPAR_VALOR_NQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ParamDTO>(query.Query, query.Parameters);
                return result;
        }

        public ParamDTO FirstByPAR_VALOR_D(DateTime value )
        {
            var query = _query.FirstByPAR_VALOR_DQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ParamDTO>(query.Query, query.Parameters);
                return result;
        }

        public ParamDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ParamDTO>(query.Query, query.Parameters);
                return result;
        }

        public ParamDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ParamDTO>(query.Query, query.Parameters);
                return result;
        }

        public ParamDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ParamDTO>(query.Query, query.Parameters);
                return result;
        }

        public ParamDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ParamDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<ParamDTO> GetAllByPAR_ID(string value )
        {
            var query = _query.FirstByPAR_IDQuery(value );

                var result = _unitOfWork.Query<ParamDTO>(query.Query,query.Parameters) as List<ParamDTO>;
                return result;
        }

        public IEnumerable<ParamDTO> GetAllByPAR_DESCRICAO(string value )
        {
            var query = _query.FirstByPAR_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<ParamDTO>(query.Query,query.Parameters) as List<ParamDTO>;
                return result;
        }

        public IEnumerable<ParamDTO> GetAllByPAR_VALOR_S(string value )
        {
            var query = _query.FirstByPAR_VALOR_SQuery(value );

                var result = _unitOfWork.Query<ParamDTO>(query.Query,query.Parameters) as List<ParamDTO>;
                return result;
        }

        public IEnumerable<ParamDTO> GetAllByPAR_VALOR_N(Decimal value )
        {
            var query = _query.FirstByPAR_VALOR_NQuery(value );

                var result = _unitOfWork.Query<ParamDTO>(query.Query,query.Parameters) as List<ParamDTO>;
                return result;
        }

        public IEnumerable<ParamDTO> GetAllByPAR_VALOR_D(DateTime value )
        {
            var query = _query.FirstByPAR_VALOR_DQuery(value );

                var result = _unitOfWork.Query<ParamDTO>(query.Query,query.Parameters) as List<ParamDTO>;
                return result;
        }

        public IEnumerable<ParamDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<ParamDTO>(query.Query,query.Parameters) as List<ParamDTO>;
                return result;
        }

        public IEnumerable<ParamDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<ParamDTO>(query.Query,query.Parameters) as List<ParamDTO>;
                return result;
        }

        public IEnumerable<ParamDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<ParamDTO>(query.Query,query.Parameters) as List<ParamDTO>;
                return result;
        }

        public IEnumerable<ParamDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<ParamDTO>(query.Query,query.Parameters) as List<ParamDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration