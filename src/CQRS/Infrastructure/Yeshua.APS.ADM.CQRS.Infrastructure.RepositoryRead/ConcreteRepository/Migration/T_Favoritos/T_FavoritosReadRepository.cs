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
    public partial class T_FavoritosReadRepository : IT_FavoritosReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IT_FavoritosQueryRead _query;

        public T_FavoritosReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IT_FavoritosQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetT_FavoritosCustom(Command.Read.T_FavoritosReadCommand command, ref DataPagination<T_FavoritosDTO> result, ref bool handled);

        public DataPagination<T_FavoritosDTO> getT_Favoritos(ICommandRead command )
         {
            if (command is Command.Read.T_FavoritosReadCommand c)
                return getT_Favoritos(c );
            throw new NotImplementedException();
        }
        private DataPagination<T_FavoritosDTO> getT_Favoritos(Command.Read.T_FavoritosReadCommand command )
        {
            DataPagination<T_FavoritosDTO> customResult = null;
            var customHandled = false;
            TryGetT_FavoritosCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.T_FavoritosQuery(command );

                var itens = _unitOfWork.Query<T_FavoritosDTO>(query.Query,query.Parameters);
                return new DataPagination<T_FavoritosDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<T_FavoritosUSE_IDDTO> getT_FavoritosReadFKUSE_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<T_FavoritosUSE_IDDTO> lista;
            var query = _query.T_FavoritosUSE_IDQuery(command );

                lista = _unitOfWork.Query<T_FavoritosUSE_IDDTO>(query.Query,query.Parameters) as List<T_FavoritosUSE_IDDTO>;
            return lista;
        }

        public IEnumerable<T_FavoritosUSE_IDDTO> getT_FavoritosReadFKUSE_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getT_FavoritosReadFKUSE_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<T_FavoritosID_INDICADORDTO> getT_FavoritosReadFKID_INDICADOR(Command.Patterns.Command.SearchFKCommand command )
        {
            List<T_FavoritosID_INDICADORDTO> lista;
            var query = _query.T_FavoritosID_INDICADORQuery(command );

                lista = _unitOfWork.Query<T_FavoritosID_INDICADORDTO>(query.Query,query.Parameters) as List<T_FavoritosID_INDICADORDTO>;
            return lista;
        }

        public IEnumerable<T_FavoritosID_INDICADORDTO> getT_FavoritosReadFKID_INDICADOR(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getT_FavoritosReadFKID_INDICADOR(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<T_FavoritosTenantIDDTO> getT_FavoritosReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<T_FavoritosTenantIDDTO> lista;
            var query = _query.T_FavoritosTenantIDQuery(command );

                lista = _unitOfWork.Query<T_FavoritosTenantIDDTO>(query.Query,query.Parameters) as List<T_FavoritosTenantIDDTO>;
            return lista;
        }

        public IEnumerable<T_FavoritosTenantIDDTO> getT_FavoritosReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getT_FavoritosReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<T_FavoritosUserIdDTO> getT_FavoritosReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<T_FavoritosUserIdDTO> lista;
            var query = _query.T_FavoritosUserIdQuery(command );

                lista = _unitOfWork.Query<T_FavoritosUserIdDTO>(query.Query,query.Parameters) as List<T_FavoritosUserIdDTO>;
            return lista;
        }

        public IEnumerable<T_FavoritosUserIdDTO> getT_FavoritosReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getT_FavoritosReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByIDFAVORITO(int value )
        {
            var query = _query.ExistsByIDFAVORITOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUSE_ID(int value )
        {
            var query = _query.ExistsByUSE_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByID_INDICADOR(int value )
        {
            var query = _query.ExistsByID_INDICADORQuery(value );

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

        public T_FavoritosDTO FirstByIDFAVORITO(int value )
        {
            var query = _query.FirstByIDFAVORITOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_FavoritosDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_FavoritosDTO FirstByUSE_ID(int value )
        {
            var query = _query.FirstByUSE_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_FavoritosDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_FavoritosDTO FirstByID_INDICADOR(int value )
        {
            var query = _query.FirstByID_INDICADORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_FavoritosDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_FavoritosDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_FavoritosDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_FavoritosDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_FavoritosDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_FavoritosDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_FavoritosDTO>(query.Query, query.Parameters);
                return result;
        }

        public T_FavoritosDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<T_FavoritosDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<T_FavoritosDTO> GetAllByIDFAVORITO(int value )
        {
            var query = _query.FirstByIDFAVORITOQuery(value );

                var result = _unitOfWork.Query<T_FavoritosDTO>(query.Query,query.Parameters) as List<T_FavoritosDTO>;
                return result;
        }

        public IEnumerable<T_FavoritosDTO> GetAllByUSE_ID(int value )
        {
            var query = _query.FirstByUSE_IDQuery(value );

                var result = _unitOfWork.Query<T_FavoritosDTO>(query.Query,query.Parameters) as List<T_FavoritosDTO>;
                return result;
        }

        public IEnumerable<T_FavoritosDTO> GetAllByID_INDICADOR(int value )
        {
            var query = _query.FirstByID_INDICADORQuery(value );

                var result = _unitOfWork.Query<T_FavoritosDTO>(query.Query,query.Parameters) as List<T_FavoritosDTO>;
                return result;
        }

        public IEnumerable<T_FavoritosDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<T_FavoritosDTO>(query.Query,query.Parameters) as List<T_FavoritosDTO>;
                return result;
        }

        public IEnumerable<T_FavoritosDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<T_FavoritosDTO>(query.Query,query.Parameters) as List<T_FavoritosDTO>;
                return result;
        }

        public IEnumerable<T_FavoritosDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<T_FavoritosDTO>(query.Query,query.Parameters) as List<T_FavoritosDTO>;
                return result;
        }

        public IEnumerable<T_FavoritosDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<T_FavoritosDTO>(query.Query,query.Parameters) as List<T_FavoritosDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration