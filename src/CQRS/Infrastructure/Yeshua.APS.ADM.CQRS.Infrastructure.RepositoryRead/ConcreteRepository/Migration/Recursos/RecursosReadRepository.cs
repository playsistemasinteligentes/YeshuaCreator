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
    public partial class RecursosReadRepository : IRecursosReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IRecursosQueryRead _query;

        public RecursosReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IRecursosQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetRecursosCustom(Command.Read.RecursosReadCommand command, ref DataPagination<RecursosDTO> result, ref bool handled);

        public DataPagination<RecursosDTO> getRecursos(ICommandRead command )
         {
            if (command is Command.Read.RecursosReadCommand c)
                return getRecursos(c );
            throw new NotImplementedException();
        }
        private DataPagination<RecursosDTO> getRecursos(Command.Read.RecursosReadCommand command )
        {
            DataPagination<RecursosDTO> customResult = null;
            var customHandled = false;
            TryGetRecursosCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.RecursosQuery(command );

                var itens = _unitOfWork.Query<RecursosDTO>(query.Query,query.Parameters);
                return new DataPagination<RecursosDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<RecursosCAL_IDDTO> getRecursosReadFKCAL_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<RecursosCAL_IDDTO> lista;
            var query = _query.RecursosCAL_IDQuery(command );

                lista = _unitOfWork.Query<RecursosCAL_IDDTO>(query.Query,query.Parameters) as List<RecursosCAL_IDDTO>;
            return lista;
        }

        public IEnumerable<RecursosCAL_IDDTO> getRecursosReadFKCAL_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getRecursosReadFKCAL_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<RecursosTenantIDDTO> getRecursosReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<RecursosTenantIDDTO> lista;
            var query = _query.RecursosTenantIDQuery(command );

                lista = _unitOfWork.Query<RecursosTenantIDDTO>(query.Query,query.Parameters) as List<RecursosTenantIDDTO>;
            return lista;
        }

        public IEnumerable<RecursosTenantIDDTO> getRecursosReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getRecursosReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<RecursosUserIdDTO> getRecursosReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<RecursosUserIdDTO> lista;
            var query = _query.RecursosUserIdQuery(command );

                lista = _unitOfWork.Query<RecursosUserIdDTO>(query.Query,query.Parameters) as List<RecursosUserIdDTO>;
            return lista;
        }

        public IEnumerable<RecursosUserIdDTO> getRecursosReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getRecursosReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByREC_ID(string value )
        {
            var query = _query.ExistsByREC_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByREC_DESCRICAO(string value )
        {
            var query = _query.ExistsByREC_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAL_ID(int value )
        {
            var query = _query.ExistsByCAL_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByREC_CONTROL_IP(string value )
        {
            var query = _query.ExistsByREC_CONTROL_IPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRE_ID(string value )
        {
            var query = _query.ExistsByGRE_IDQuery(value );

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

        public RecursosDTO FirstByREC_ID(string value )
        {
            var query = _query.FirstByREC_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RecursosDTO>(query.Query, query.Parameters);
                return result;
        }

        public RecursosDTO FirstByREC_DESCRICAO(string value )
        {
            var query = _query.FirstByREC_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RecursosDTO>(query.Query, query.Parameters);
                return result;
        }

        public RecursosDTO FirstByCAL_ID(int value )
        {
            var query = _query.FirstByCAL_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RecursosDTO>(query.Query, query.Parameters);
                return result;
        }

        public RecursosDTO FirstByREC_CONTROL_IP(string value )
        {
            var query = _query.FirstByREC_CONTROL_IPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RecursosDTO>(query.Query, query.Parameters);
                return result;
        }

        public RecursosDTO FirstByGRE_ID(string value )
        {
            var query = _query.FirstByGRE_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RecursosDTO>(query.Query, query.Parameters);
                return result;
        }

        public RecursosDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RecursosDTO>(query.Query, query.Parameters);
                return result;
        }

        public RecursosDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RecursosDTO>(query.Query, query.Parameters);
                return result;
        }

        public RecursosDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RecursosDTO>(query.Query, query.Parameters);
                return result;
        }

        public RecursosDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<RecursosDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<RecursosDTO> GetAllByREC_ID(string value )
        {
            var query = _query.FirstByREC_IDQuery(value );

                var result = _unitOfWork.Query<RecursosDTO>(query.Query,query.Parameters) as List<RecursosDTO>;
                return result;
        }

        public IEnumerable<RecursosDTO> GetAllByREC_DESCRICAO(string value )
        {
            var query = _query.FirstByREC_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<RecursosDTO>(query.Query,query.Parameters) as List<RecursosDTO>;
                return result;
        }

        public IEnumerable<RecursosDTO> GetAllByCAL_ID(int value )
        {
            var query = _query.FirstByCAL_IDQuery(value );

                var result = _unitOfWork.Query<RecursosDTO>(query.Query,query.Parameters) as List<RecursosDTO>;
                return result;
        }

        public IEnumerable<RecursosDTO> GetAllByREC_CONTROL_IP(string value )
        {
            var query = _query.FirstByREC_CONTROL_IPQuery(value );

                var result = _unitOfWork.Query<RecursosDTO>(query.Query,query.Parameters) as List<RecursosDTO>;
                return result;
        }

        public IEnumerable<RecursosDTO> GetAllByGRE_ID(string value )
        {
            var query = _query.FirstByGRE_IDQuery(value );

                var result = _unitOfWork.Query<RecursosDTO>(query.Query,query.Parameters) as List<RecursosDTO>;
                return result;
        }

        public IEnumerable<RecursosDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<RecursosDTO>(query.Query,query.Parameters) as List<RecursosDTO>;
                return result;
        }

        public IEnumerable<RecursosDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<RecursosDTO>(query.Query,query.Parameters) as List<RecursosDTO>;
                return result;
        }

        public IEnumerable<RecursosDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<RecursosDTO>(query.Query,query.Parameters) as List<RecursosDTO>;
                return result;
        }

        public IEnumerable<RecursosDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<RecursosDTO>(query.Query,query.Parameters) as List<RecursosDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration