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
    public partial class T_DepartamentosReadRepository : IT_DepartamentosReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IT_DepartamentosQueryRead _query;

        public T_DepartamentosReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IT_DepartamentosQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetT_DepartamentosCustom(Command.Read.T_DepartamentosReadCommand command, ref DataPagination<T_DepartamentosDTO> result, ref bool handled);

        public DataPagination<T_DepartamentosDTO> getT_Departamentos(ICommandRead command )
         {
            if (command is Command.Read.T_DepartamentosReadCommand c)
                return getT_Departamentos(c );
            throw new NotImplementedException();
        }
        private DataPagination<T_DepartamentosDTO> getT_Departamentos(Command.Read.T_DepartamentosReadCommand command )
        {
            DataPagination<T_DepartamentosDTO> customResult = null;
            var customHandled = false;
            TryGetT_DepartamentosCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.T_DepartamentosQuery(command );

                var itens = _unitOfWork.Query<T_DepartamentosDTO>(query.Query,query.Parameters);
                return new DataPagination<T_DepartamentosDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<T_DepartamentosTenantIDDTO> getT_DepartamentosReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<T_DepartamentosTenantIDDTO> lista;
            var query = _query.T_DepartamentosTenantIDQuery(command );

                lista = _unitOfWork.Query<T_DepartamentosTenantIDDTO>(query.Query,query.Parameters) as List<T_DepartamentosTenantIDDTO>;
            return lista;
        }

        public IEnumerable<T_DepartamentosTenantIDDTO> getT_DepartamentosReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getT_DepartamentosReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<T_DepartamentosUserIdDTO> getT_DepartamentosReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<T_DepartamentosUserIdDTO> lista;
            var query = _query.T_DepartamentosUserIdQuery(command );

                lista = _unitOfWork.Query<T_DepartamentosUserIdDTO>(query.Query,query.Parameters) as List<T_DepartamentosUserIdDTO>;
            return lista;
        }

        public IEnumerable<T_DepartamentosUserIdDTO> getT_DepartamentosReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getT_DepartamentosReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByDEP_ID(int value )
        {
            var query = _query.ExistsByDEP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDEP_NOME(string value )
        {
            var query = _query.ExistsByDEP_NOMEQuery(value );

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

        public T_DepartamentosDTO FirstByDEP_ID(int value )
        {
            var query = _query.FirstByDEP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_DepartamentosDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_DepartamentosDTO FirstByDEP_NOME(string value )
        {
            var query = _query.FirstByDEP_NOMEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_DepartamentosDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_DepartamentosDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_DepartamentosDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_DepartamentosDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_DepartamentosDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_DepartamentosDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_DepartamentosDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_DepartamentosDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_DepartamentosDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<T_DepartamentosDTO> GetAllByDEP_ID(int value )
        {
            var query = _query.FirstByDEP_IDQuery(value );

                var result = _unitOfWork.Query<T_DepartamentosDTO>(query.Query,query.Parameters) as List<T_DepartamentosDTO>;
                return result;
        }

        public IEnumerable<T_DepartamentosDTO> GetAllByDEP_NOME(string value )
        {
            var query = _query.FirstByDEP_NOMEQuery(value );

                var result = _unitOfWork.Query<T_DepartamentosDTO>(query.Query,query.Parameters) as List<T_DepartamentosDTO>;
                return result;
        }

        public IEnumerable<T_DepartamentosDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<T_DepartamentosDTO>(query.Query,query.Parameters) as List<T_DepartamentosDTO>;
                return result;
        }

        public IEnumerable<T_DepartamentosDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<T_DepartamentosDTO>(query.Query,query.Parameters) as List<T_DepartamentosDTO>;
                return result;
        }

        public IEnumerable<T_DepartamentosDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<T_DepartamentosDTO>(query.Query,query.Parameters) as List<T_DepartamentosDTO>;
                return result;
        }

        public IEnumerable<T_DepartamentosDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<T_DepartamentosDTO>(query.Query,query.Parameters) as List<T_DepartamentosDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration