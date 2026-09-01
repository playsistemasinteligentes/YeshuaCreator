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
    public partial class T_NegocioReadRepository : IT_NegocioReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IT_NegocioQueryRead _query;

        public T_NegocioReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IT_NegocioQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetT_NegocioCustom(Command.Read.T_NegocioReadCommand command, ref DataPagination<T_NegocioDTO> result, ref bool handled);

        public DataPagination<T_NegocioDTO> getT_Negocio(ICommandRead command )
         {
            if (command is Command.Read.T_NegocioReadCommand c)
                return getT_Negocio(c );
            throw new NotImplementedException();
        }
        private DataPagination<T_NegocioDTO> getT_Negocio(Command.Read.T_NegocioReadCommand command )
        {
            DataPagination<T_NegocioDTO> customResult = null;
            var customHandled = false;
            TryGetT_NegocioCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.T_NegocioQuery(command );

                var itens = _unitOfWork.Query<T_NegocioDTO>(query.Query,query.Parameters);
                return new DataPagination<T_NegocioDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<T_NegocioTenantIDDTO> getT_NegocioReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<T_NegocioTenantIDDTO> lista;
            var query = _query.T_NegocioTenantIDQuery(command );

                lista = _unitOfWork.Query<T_NegocioTenantIDDTO>(query.Query,query.Parameters) as List<T_NegocioTenantIDDTO>;
            return lista;
        }

        public IEnumerable<T_NegocioTenantIDDTO> getT_NegocioReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getT_NegocioReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<T_NegocioUserIdDTO> getT_NegocioReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<T_NegocioUserIdDTO> lista;
            var query = _query.T_NegocioUserIdQuery(command );

                lista = _unitOfWork.Query<T_NegocioUserIdDTO>(query.Query,query.Parameters) as List<T_NegocioUserIdDTO>;
            return lista;
        }

        public IEnumerable<T_NegocioUserIdDTO> getT_NegocioReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getT_NegocioReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByNEG_ID(int value )
        {
            var query = _query.ExistsByNEG_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByNEG_DESCRICAO(string value )
        {
            var query = _query.ExistsByNEG_DESCRICAOQuery(value );

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

        public T_NegocioDTO FirstByNEG_ID(int value )
        {
            var query = _query.FirstByNEG_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_NegocioDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_NegocioDTO FirstByNEG_DESCRICAO(string value )
        {
            var query = _query.FirstByNEG_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_NegocioDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_NegocioDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_NegocioDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_NegocioDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_NegocioDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_NegocioDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_NegocioDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_NegocioDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_NegocioDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<T_NegocioDTO> GetAllByNEG_ID(int value )
        {
            var query = _query.FirstByNEG_IDQuery(value );

                var result = _unitOfWork.Query<T_NegocioDTO>(query.Query,query.Parameters) as List<T_NegocioDTO>;
                return result;
        }

        public IEnumerable<T_NegocioDTO> GetAllByNEG_DESCRICAO(string value )
        {
            var query = _query.FirstByNEG_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<T_NegocioDTO>(query.Query,query.Parameters) as List<T_NegocioDTO>;
                return result;
        }

        public IEnumerable<T_NegocioDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<T_NegocioDTO>(query.Query,query.Parameters) as List<T_NegocioDTO>;
                return result;
        }

        public IEnumerable<T_NegocioDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<T_NegocioDTO>(query.Query,query.Parameters) as List<T_NegocioDTO>;
                return result;
        }

        public IEnumerable<T_NegocioDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<T_NegocioDTO>(query.Query,query.Parameters) as List<T_NegocioDTO>;
                return result;
        }

        public IEnumerable<T_NegocioDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<T_NegocioDTO>(query.Query,query.Parameters) as List<T_NegocioDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration