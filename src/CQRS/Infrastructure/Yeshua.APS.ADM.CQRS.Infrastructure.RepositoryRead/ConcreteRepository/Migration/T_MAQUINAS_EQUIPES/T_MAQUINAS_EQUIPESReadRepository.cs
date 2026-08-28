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
    public partial class T_MAQUINAS_EQUIPESReadRepository : IT_MAQUINAS_EQUIPESReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IT_MAQUINAS_EQUIPESQueryRead _query;

        public T_MAQUINAS_EQUIPESReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IT_MAQUINAS_EQUIPESQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<T_MAQUINAS_EQUIPESDTO> getT_MAQUINAS_EQUIPES(ICommandRead command )
         {
            if (command is Command.Read.T_MAQUINAS_EQUIPESReadCommand c)
                return getT_MAQUINAS_EQUIPES(c );
            throw new NotImplementedException();
        }
        private DataPagination<T_MAQUINAS_EQUIPESDTO> getT_MAQUINAS_EQUIPES(Command.Read.T_MAQUINAS_EQUIPESReadCommand command )
        {
            var query = _query.T_MAQUINAS_EQUIPESQuery(command );

                var itens = _unitOfWork.Query<T_MAQUINAS_EQUIPESDTO>(query.Query,query.Parameters);
                return new DataPagination<T_MAQUINAS_EQUIPESDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<T_MAQUINAS_EQUIPESTenantIDDTO> getT_MAQUINAS_EQUIPESReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<T_MAQUINAS_EQUIPESTenantIDDTO> lista;
            var query = _query.T_MAQUINAS_EQUIPESTenantIDQuery(command );

                lista = _unitOfWork.Query<T_MAQUINAS_EQUIPESTenantIDDTO>(query.Query,query.Parameters) as List<T_MAQUINAS_EQUIPESTenantIDDTO>;
            return lista;
        }

        public IEnumerable<T_MAQUINAS_EQUIPESTenantIDDTO> getT_MAQUINAS_EQUIPESReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getT_MAQUINAS_EQUIPESReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<T_MAQUINAS_EQUIPESUserIdDTO> getT_MAQUINAS_EQUIPESReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<T_MAQUINAS_EQUIPESUserIdDTO> lista;
            var query = _query.T_MAQUINAS_EQUIPESUserIdQuery(command );

                lista = _unitOfWork.Query<T_MAQUINAS_EQUIPESUserIdDTO>(query.Query,query.Parameters) as List<T_MAQUINAS_EQUIPESUserIdDTO>;
            return lista;
        }

        public IEnumerable<T_MAQUINAS_EQUIPESUserIdDTO> getT_MAQUINAS_EQUIPESReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getT_MAQUINAS_EQUIPESReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_ID(string value )
        {
            var query = _query.ExistsByMAQ_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEQU_ID(string value )
        {
            var query = _query.ExistsByEQU_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAL_ID(int value )
        {
            var query = _query.ExistsByCAL_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCLI_ID(string value )
        {
            var query = _query.ExistsByCLI_IDQuery(value );

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

        public T_MAQUINAS_EQUIPESDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MAQUINAS_EQUIPESDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MAQUINAS_EQUIPESDTO FirstByMAQ_ID(string value )
        {
            var query = _query.FirstByMAQ_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MAQUINAS_EQUIPESDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MAQUINAS_EQUIPESDTO FirstByEQU_ID(string value )
        {
            var query = _query.FirstByEQU_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MAQUINAS_EQUIPESDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MAQUINAS_EQUIPESDTO FirstByCAL_ID(int value )
        {
            var query = _query.FirstByCAL_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MAQUINAS_EQUIPESDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MAQUINAS_EQUIPESDTO FirstByCLI_ID(string value )
        {
            var query = _query.FirstByCLI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MAQUINAS_EQUIPESDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MAQUINAS_EQUIPESDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MAQUINAS_EQUIPESDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MAQUINAS_EQUIPESDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MAQUINAS_EQUIPESDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MAQUINAS_EQUIPESDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MAQUINAS_EQUIPESDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_MAQUINAS_EQUIPESDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_MAQUINAS_EQUIPESDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<T_MAQUINAS_EQUIPESDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<T_MAQUINAS_EQUIPESDTO>(query.Query,query.Parameters) as List<T_MAQUINAS_EQUIPESDTO>;
                return result;
        }

        public IEnumerable<T_MAQUINAS_EQUIPESDTO> GetAllByMAQ_ID(string value )
        {
            var query = _query.FirstByMAQ_IDQuery(value );

                var result = _unitOfWork.Query<T_MAQUINAS_EQUIPESDTO>(query.Query,query.Parameters) as List<T_MAQUINAS_EQUIPESDTO>;
                return result;
        }

        public IEnumerable<T_MAQUINAS_EQUIPESDTO> GetAllByEQU_ID(string value )
        {
            var query = _query.FirstByEQU_IDQuery(value );

                var result = _unitOfWork.Query<T_MAQUINAS_EQUIPESDTO>(query.Query,query.Parameters) as List<T_MAQUINAS_EQUIPESDTO>;
                return result;
        }

        public IEnumerable<T_MAQUINAS_EQUIPESDTO> GetAllByCAL_ID(int value )
        {
            var query = _query.FirstByCAL_IDQuery(value );

                var result = _unitOfWork.Query<T_MAQUINAS_EQUIPESDTO>(query.Query,query.Parameters) as List<T_MAQUINAS_EQUIPESDTO>;
                return result;
        }

        public IEnumerable<T_MAQUINAS_EQUIPESDTO> GetAllByCLI_ID(string value )
        {
            var query = _query.FirstByCLI_IDQuery(value );

                var result = _unitOfWork.Query<T_MAQUINAS_EQUIPESDTO>(query.Query,query.Parameters) as List<T_MAQUINAS_EQUIPESDTO>;
                return result;
        }

        public IEnumerable<T_MAQUINAS_EQUIPESDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<T_MAQUINAS_EQUIPESDTO>(query.Query,query.Parameters) as List<T_MAQUINAS_EQUIPESDTO>;
                return result;
        }

        public IEnumerable<T_MAQUINAS_EQUIPESDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<T_MAQUINAS_EQUIPESDTO>(query.Query,query.Parameters) as List<T_MAQUINAS_EQUIPESDTO>;
                return result;
        }

        public IEnumerable<T_MAQUINAS_EQUIPESDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<T_MAQUINAS_EQUIPESDTO>(query.Query,query.Parameters) as List<T_MAQUINAS_EQUIPESDTO>;
                return result;
        }

        public IEnumerable<T_MAQUINAS_EQUIPESDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<T_MAQUINAS_EQUIPESDTO>(query.Query,query.Parameters) as List<T_MAQUINAS_EQUIPESDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration