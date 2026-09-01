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
    public partial class T_GrupoReadRepository : IT_GrupoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IT_GrupoQueryRead _query;

        public T_GrupoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IT_GrupoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetT_GrupoCustom(Command.Read.T_GrupoReadCommand command, ref DataPagination<T_GrupoDTO> result, ref bool handled);

        public DataPagination<T_GrupoDTO> getT_Grupo(ICommandRead command )
         {
            if (command is Command.Read.T_GrupoReadCommand c)
                return getT_Grupo(c );
            throw new NotImplementedException();
        }
        private DataPagination<T_GrupoDTO> getT_Grupo(Command.Read.T_GrupoReadCommand command )
        {
            DataPagination<T_GrupoDTO> customResult = null;
            var customHandled = false;
            TryGetT_GrupoCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.T_GrupoQuery(command );

                var itens = _unitOfWork.Query<T_GrupoDTO>(query.Query,query.Parameters);
                return new DataPagination<T_GrupoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<T_GrupoTenantIDDTO> getT_GrupoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<T_GrupoTenantIDDTO> lista;
            var query = _query.T_GrupoTenantIDQuery(command );

                lista = _unitOfWork.Query<T_GrupoTenantIDDTO>(query.Query,query.Parameters) as List<T_GrupoTenantIDDTO>;
            return lista;
        }

        public IEnumerable<T_GrupoTenantIDDTO> getT_GrupoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getT_GrupoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<T_GrupoUserIdDTO> getT_GrupoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<T_GrupoUserIdDTO> lista;
            var query = _query.T_GrupoUserIdQuery(command );

                lista = _unitOfWork.Query<T_GrupoUserIdDTO>(query.Query,query.Parameters) as List<T_GrupoUserIdDTO>;
            return lista;
        }

        public IEnumerable<T_GrupoUserIdDTO> getT_GrupoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getT_GrupoReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByGRU_ID(int value )
        {
            var query = _query.ExistsByGRU_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByNOME(string value )
        {
            var query = _query.ExistsByNOMEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEXIBELISTA(int value )
        {
            var query = _query.ExistsByEXIBELISTAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRU_DESCRICAO(string value )
        {
            var query = _query.ExistsByGRU_DESCRICAOQuery(value );

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

        public T_GrupoDTO FirstByGRU_ID(int value )
        {
            var query = _query.FirstByGRU_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_GrupoDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_GrupoDTO FirstByNOME(string value )
        {
            var query = _query.FirstByNOMEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_GrupoDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_GrupoDTO FirstByEXIBELISTA(int value )
        {
            var query = _query.FirstByEXIBELISTAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_GrupoDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_GrupoDTO FirstByGRU_DESCRICAO(string value )
        {
            var query = _query.FirstByGRU_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_GrupoDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_GrupoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_GrupoDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_GrupoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_GrupoDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_GrupoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_GrupoDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_GrupoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_GrupoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<T_GrupoDTO> GetAllByGRU_ID(int value )
        {
            var query = _query.FirstByGRU_IDQuery(value );

                var result = _unitOfWork.Query<T_GrupoDTO>(query.Query,query.Parameters) as List<T_GrupoDTO>;
                return result;
        }

        public IEnumerable<T_GrupoDTO> GetAllByNOME(string value )
        {
            var query = _query.FirstByNOMEQuery(value );

                var result = _unitOfWork.Query<T_GrupoDTO>(query.Query,query.Parameters) as List<T_GrupoDTO>;
                return result;
        }

        public IEnumerable<T_GrupoDTO> GetAllByEXIBELISTA(int value )
        {
            var query = _query.FirstByEXIBELISTAQuery(value );

                var result = _unitOfWork.Query<T_GrupoDTO>(query.Query,query.Parameters) as List<T_GrupoDTO>;
                return result;
        }

        public IEnumerable<T_GrupoDTO> GetAllByGRU_DESCRICAO(string value )
        {
            var query = _query.FirstByGRU_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<T_GrupoDTO>(query.Query,query.Parameters) as List<T_GrupoDTO>;
                return result;
        }

        public IEnumerable<T_GrupoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<T_GrupoDTO>(query.Query,query.Parameters) as List<T_GrupoDTO>;
                return result;
        }

        public IEnumerable<T_GrupoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<T_GrupoDTO>(query.Query,query.Parameters) as List<T_GrupoDTO>;
                return result;
        }

        public IEnumerable<T_GrupoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<T_GrupoDTO>(query.Query,query.Parameters) as List<T_GrupoDTO>;
                return result;
        }

        public IEnumerable<T_GrupoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<T_GrupoDTO>(query.Query,query.Parameters) as List<T_GrupoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration