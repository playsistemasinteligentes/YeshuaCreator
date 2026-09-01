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
    public partial class TipoAvaliacaoReadRepository : ITipoAvaliacaoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ITipoAvaliacaoQueryRead _query;

        public TipoAvaliacaoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ITipoAvaliacaoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetTipoAvaliacaoCustom(Command.Read.TipoAvaliacaoReadCommand command, ref DataPagination<TipoAvaliacaoDTO> result, ref bool handled);

        public DataPagination<TipoAvaliacaoDTO> getTipoAvaliacao(ICommandRead command )
         {
            if (command is Command.Read.TipoAvaliacaoReadCommand c)
                return getTipoAvaliacao(c );
            throw new NotImplementedException();
        }
        private DataPagination<TipoAvaliacaoDTO> getTipoAvaliacao(Command.Read.TipoAvaliacaoReadCommand command )
        {
            DataPagination<TipoAvaliacaoDTO> customResult = null;
            var customHandled = false;
            TryGetTipoAvaliacaoCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.TipoAvaliacaoQuery(command );

                var itens = _unitOfWork.Query<TipoAvaliacaoDTO>(query.Query,query.Parameters);
                return new DataPagination<TipoAvaliacaoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<TipoAvaliacaoTenantIDDTO> getTipoAvaliacaoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TipoAvaliacaoTenantIDDTO> lista;
            var query = _query.TipoAvaliacaoTenantIDQuery(command );

                lista = _unitOfWork.Query<TipoAvaliacaoTenantIDDTO>(query.Query,query.Parameters) as List<TipoAvaliacaoTenantIDDTO>;
            return lista;
        }

        public IEnumerable<TipoAvaliacaoTenantIDDTO> getTipoAvaliacaoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTipoAvaliacaoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<TipoAvaliacaoUserIdDTO> getTipoAvaliacaoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TipoAvaliacaoUserIdDTO> lista;
            var query = _query.TipoAvaliacaoUserIdQuery(command );

                lista = _unitOfWork.Query<TipoAvaliacaoUserIdDTO>(query.Query,query.Parameters) as List<TipoAvaliacaoUserIdDTO>;
            return lista;
        }

        public IEnumerable<TipoAvaliacaoUserIdDTO> getTipoAvaliacaoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTipoAvaliacaoReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByTA_ID(int value )
        {
            var query = _query.ExistsByTA_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTA_DESC(string value )
        {
            var query = _query.ExistsByTA_DESCQuery(value );

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

        public TipoAvaliacaoDTO FirstByTA_ID(int value )
        {
            var query = _query.FirstByTA_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoAvaliacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoAvaliacaoDTO FirstByTA_DESC(string value )
        {
            var query = _query.FirstByTA_DESCQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoAvaliacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoAvaliacaoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoAvaliacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoAvaliacaoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoAvaliacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoAvaliacaoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoAvaliacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoAvaliacaoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoAvaliacaoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<TipoAvaliacaoDTO> GetAllByTA_ID(int value )
        {
            var query = _query.FirstByTA_IDQuery(value );

                var result = _unitOfWork.Query<TipoAvaliacaoDTO>(query.Query,query.Parameters) as List<TipoAvaliacaoDTO>;
                return result;
        }

        public IEnumerable<TipoAvaliacaoDTO> GetAllByTA_DESC(string value )
        {
            var query = _query.FirstByTA_DESCQuery(value );

                var result = _unitOfWork.Query<TipoAvaliacaoDTO>(query.Query,query.Parameters) as List<TipoAvaliacaoDTO>;
                return result;
        }

        public IEnumerable<TipoAvaliacaoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<TipoAvaliacaoDTO>(query.Query,query.Parameters) as List<TipoAvaliacaoDTO>;
                return result;
        }

        public IEnumerable<TipoAvaliacaoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<TipoAvaliacaoDTO>(query.Query,query.Parameters) as List<TipoAvaliacaoDTO>;
                return result;
        }

        public IEnumerable<TipoAvaliacaoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<TipoAvaliacaoDTO>(query.Query,query.Parameters) as List<TipoAvaliacaoDTO>;
                return result;
        }

        public IEnumerable<TipoAvaliacaoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<TipoAvaliacaoDTO>(query.Query,query.Parameters) as List<TipoAvaliacaoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration