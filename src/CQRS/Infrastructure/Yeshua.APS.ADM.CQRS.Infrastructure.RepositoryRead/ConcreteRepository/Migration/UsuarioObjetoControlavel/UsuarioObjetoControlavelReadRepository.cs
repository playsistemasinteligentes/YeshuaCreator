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
    public partial class UsuarioObjetoControlavelReadRepository : IUsuarioObjetoControlavelReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IUsuarioObjetoControlavelQueryRead _query;

        public UsuarioObjetoControlavelReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IUsuarioObjetoControlavelQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetUsuarioObjetoControlavelCustom(Command.Read.UsuarioObjetoControlavelReadCommand command, ref DataPagination<UsuarioObjetoControlavelDTO> result, ref bool handled);

        public DataPagination<UsuarioObjetoControlavelDTO> getUsuarioObjetoControlavel(ICommandRead command )
         {
            if (command is Command.Read.UsuarioObjetoControlavelReadCommand c)
                return getUsuarioObjetoControlavel(c );
            throw new NotImplementedException();
        }
        private DataPagination<UsuarioObjetoControlavelDTO> getUsuarioObjetoControlavel(Command.Read.UsuarioObjetoControlavelReadCommand command )
        {
            DataPagination<UsuarioObjetoControlavelDTO> customResult = null;
            var customHandled = false;
            TryGetUsuarioObjetoControlavelCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.UsuarioObjetoControlavelQuery(command );

                var itens = _unitOfWork.Query<UsuarioObjetoControlavelDTO>(query.Query,query.Parameters);
                return new DataPagination<UsuarioObjetoControlavelDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<UsuarioObjetoControlavelUSE_IDDTO> getUsuarioObjetoControlavelReadFKUSE_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<UsuarioObjetoControlavelUSE_IDDTO> lista;
            var query = _query.UsuarioObjetoControlavelUSE_IDQuery(command );

                lista = _unitOfWork.Query<UsuarioObjetoControlavelUSE_IDDTO>(query.Query,query.Parameters) as List<UsuarioObjetoControlavelUSE_IDDTO>;
            return lista;
        }

        public IEnumerable<UsuarioObjetoControlavelUSE_IDDTO> getUsuarioObjetoControlavelReadFKUSE_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getUsuarioObjetoControlavelReadFKUSE_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<UsuarioObjetoControlavelTenantIDDTO> getUsuarioObjetoControlavelReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<UsuarioObjetoControlavelTenantIDDTO> lista;
            var query = _query.UsuarioObjetoControlavelTenantIDQuery(command );

                lista = _unitOfWork.Query<UsuarioObjetoControlavelTenantIDDTO>(query.Query,query.Parameters) as List<UsuarioObjetoControlavelTenantIDDTO>;
            return lista;
        }

        public IEnumerable<UsuarioObjetoControlavelTenantIDDTO> getUsuarioObjetoControlavelReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getUsuarioObjetoControlavelReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<UsuarioObjetoControlavelUserIdDTO> getUsuarioObjetoControlavelReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<UsuarioObjetoControlavelUserIdDTO> lista;
            var query = _query.UsuarioObjetoControlavelUserIdQuery(command );

                lista = _unitOfWork.Query<UsuarioObjetoControlavelUserIdDTO>(query.Query,query.Parameters) as List<UsuarioObjetoControlavelUserIdDTO>;
            return lista;
        }

        public IEnumerable<UsuarioObjetoControlavelUserIdDTO> getUsuarioObjetoControlavelReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getUsuarioObjetoControlavelReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUSE_ID(int value )
        {
            var query = _query.ExistsByUSE_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOBJ_ID(string value )
        {
            var query = _query.ExistsByOBJ_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUSU_OBJETO_ACAO(string value )
        {
            var query = _query.ExistsByUSU_OBJETO_ACAOQuery(value );

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

        public UsuarioObjetoControlavelDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UsuarioObjetoControlavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public UsuarioObjetoControlavelDTO FirstByUSE_ID(int value )
        {
            var query = _query.FirstByUSE_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UsuarioObjetoControlavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public UsuarioObjetoControlavelDTO FirstByOBJ_ID(string value )
        {
            var query = _query.FirstByOBJ_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UsuarioObjetoControlavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public UsuarioObjetoControlavelDTO FirstByUSU_OBJETO_ACAO(string value )
        {
            var query = _query.FirstByUSU_OBJETO_ACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UsuarioObjetoControlavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public UsuarioObjetoControlavelDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UsuarioObjetoControlavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public UsuarioObjetoControlavelDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UsuarioObjetoControlavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public UsuarioObjetoControlavelDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UsuarioObjetoControlavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public UsuarioObjetoControlavelDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UsuarioObjetoControlavelDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<UsuarioObjetoControlavelDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<UsuarioObjetoControlavelDTO>(query.Query,query.Parameters) as List<UsuarioObjetoControlavelDTO>;
                return result;
        }

        public IEnumerable<UsuarioObjetoControlavelDTO> GetAllByUSE_ID(int value )
        {
            var query = _query.FirstByUSE_IDQuery(value );

                var result = _unitOfWork.Query<UsuarioObjetoControlavelDTO>(query.Query,query.Parameters) as List<UsuarioObjetoControlavelDTO>;
                return result;
        }

        public IEnumerable<UsuarioObjetoControlavelDTO> GetAllByOBJ_ID(string value )
        {
            var query = _query.FirstByOBJ_IDQuery(value );

                var result = _unitOfWork.Query<UsuarioObjetoControlavelDTO>(query.Query,query.Parameters) as List<UsuarioObjetoControlavelDTO>;
                return result;
        }

        public IEnumerable<UsuarioObjetoControlavelDTO> GetAllByUSU_OBJETO_ACAO(string value )
        {
            var query = _query.FirstByUSU_OBJETO_ACAOQuery(value );

                var result = _unitOfWork.Query<UsuarioObjetoControlavelDTO>(query.Query,query.Parameters) as List<UsuarioObjetoControlavelDTO>;
                return result;
        }

        public IEnumerable<UsuarioObjetoControlavelDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<UsuarioObjetoControlavelDTO>(query.Query,query.Parameters) as List<UsuarioObjetoControlavelDTO>;
                return result;
        }

        public IEnumerable<UsuarioObjetoControlavelDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<UsuarioObjetoControlavelDTO>(query.Query,query.Parameters) as List<UsuarioObjetoControlavelDTO>;
                return result;
        }

        public IEnumerable<UsuarioObjetoControlavelDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<UsuarioObjetoControlavelDTO>(query.Query,query.Parameters) as List<UsuarioObjetoControlavelDTO>;
                return result;
        }

        public IEnumerable<UsuarioObjetoControlavelDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<UsuarioObjetoControlavelDTO>(query.Query,query.Parameters) as List<UsuarioObjetoControlavelDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration