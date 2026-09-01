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
    public partial class ObjetoControlavelReadRepository : IObjetoControlavelReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IObjetoControlavelQueryRead _query;

        public ObjetoControlavelReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IObjetoControlavelQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetObjetoControlavelCustom(Command.Read.ObjetoControlavelReadCommand command, ref DataPagination<ObjetoControlavelDTO> result, ref bool handled);

        public DataPagination<ObjetoControlavelDTO> getObjetoControlavel(ICommandRead command )
         {
            if (command is Command.Read.ObjetoControlavelReadCommand c)
                return getObjetoControlavel(c );
            throw new NotImplementedException();
        }
        private DataPagination<ObjetoControlavelDTO> getObjetoControlavel(Command.Read.ObjetoControlavelReadCommand command )
        {
            DataPagination<ObjetoControlavelDTO> customResult = null;
            var customHandled = false;
            TryGetObjetoControlavelCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.ObjetoControlavelQuery(command );

                var itens = _unitOfWork.Query<ObjetoControlavelDTO>(query.Query,query.Parameters);
                return new DataPagination<ObjetoControlavelDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<ObjetoControlavelTenantIDDTO> getObjetoControlavelReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ObjetoControlavelTenantIDDTO> lista;
            var query = _query.ObjetoControlavelTenantIDQuery(command );

                lista = _unitOfWork.Query<ObjetoControlavelTenantIDDTO>(query.Query,query.Parameters) as List<ObjetoControlavelTenantIDDTO>;
            return lista;
        }

        public IEnumerable<ObjetoControlavelTenantIDDTO> getObjetoControlavelReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getObjetoControlavelReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ObjetoControlavelUserIdDTO> getObjetoControlavelReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ObjetoControlavelUserIdDTO> lista;
            var query = _query.ObjetoControlavelUserIdQuery(command );

                lista = _unitOfWork.Query<ObjetoControlavelUserIdDTO>(query.Query,query.Parameters) as List<ObjetoControlavelUserIdDTO>;
            return lista;
        }

        public IEnumerable<ObjetoControlavelUserIdDTO> getObjetoControlavelReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getObjetoControlavelReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOBJ_ID(string value )
        {
            var query = _query.ExistsByOBJ_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOBJ_DESCRICAO(string value )
        {
            var query = _query.ExistsByOBJ_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOBJ_TIPO(string value )
        {
            var query = _query.ExistsByOBJ_TIPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOBJ_GRUPO(string value )
        {
            var query = _query.ExistsByOBJ_GRUPOQuery(value );

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

        public ObjetoControlavelDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ObjetoControlavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public ObjetoControlavelDTO FirstByOBJ_ID(string value )
        {
            var query = _query.FirstByOBJ_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ObjetoControlavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public ObjetoControlavelDTO FirstByOBJ_DESCRICAO(string value )
        {
            var query = _query.FirstByOBJ_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ObjetoControlavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public ObjetoControlavelDTO FirstByOBJ_TIPO(string value )
        {
            var query = _query.FirstByOBJ_TIPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ObjetoControlavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public ObjetoControlavelDTO FirstByOBJ_GRUPO(string value )
        {
            var query = _query.FirstByOBJ_GRUPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ObjetoControlavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public ObjetoControlavelDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ObjetoControlavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public ObjetoControlavelDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ObjetoControlavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public ObjetoControlavelDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ObjetoControlavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public ObjetoControlavelDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ObjetoControlavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<ObjetoControlavelDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<ObjetoControlavelDTO>(query.Query,query.Parameters) as List<ObjetoControlavelDTO>;
                return result;
        }

        public IEnumerable<ObjetoControlavelDTO> GetAllByOBJ_ID(string value )
        {
            var query = _query.FirstByOBJ_IDQuery(value );

                var result = _unitOfWork.Query<ObjetoControlavelDTO>(query.Query,query.Parameters) as List<ObjetoControlavelDTO>;
                return result;
        }

        public IEnumerable<ObjetoControlavelDTO> GetAllByOBJ_DESCRICAO(string value )
        {
            var query = _query.FirstByOBJ_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<ObjetoControlavelDTO>(query.Query,query.Parameters) as List<ObjetoControlavelDTO>;
                return result;
        }

        public IEnumerable<ObjetoControlavelDTO> GetAllByOBJ_TIPO(string value )
        {
            var query = _query.FirstByOBJ_TIPOQuery(value );

                var result = _unitOfWork.Query<ObjetoControlavelDTO>(query.Query,query.Parameters) as List<ObjetoControlavelDTO>;
                return result;
        }

        public IEnumerable<ObjetoControlavelDTO> GetAllByOBJ_GRUPO(string value )
        {
            var query = _query.FirstByOBJ_GRUPOQuery(value );

                var result = _unitOfWork.Query<ObjetoControlavelDTO>(query.Query,query.Parameters) as List<ObjetoControlavelDTO>;
                return result;
        }

        public IEnumerable<ObjetoControlavelDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<ObjetoControlavelDTO>(query.Query,query.Parameters) as List<ObjetoControlavelDTO>;
                return result;
        }

        public IEnumerable<ObjetoControlavelDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<ObjetoControlavelDTO>(query.Query,query.Parameters) as List<ObjetoControlavelDTO>;
                return result;
        }

        public IEnumerable<ObjetoControlavelDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<ObjetoControlavelDTO>(query.Query,query.Parameters) as List<ObjetoControlavelDTO>;
                return result;
        }

        public IEnumerable<ObjetoControlavelDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<ObjetoControlavelDTO>(query.Query,query.Parameters) as List<ObjetoControlavelDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration