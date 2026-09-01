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
    public partial class TipoCarroceriaReadRepository : ITipoCarroceriaReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ITipoCarroceriaQueryRead _query;

        public TipoCarroceriaReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ITipoCarroceriaQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetTipoCarroceriaCustom(Command.Read.TipoCarroceriaReadCommand command, ref DataPagination<TipoCarroceriaDTO> result, ref bool handled);

        public DataPagination<TipoCarroceriaDTO> getTipoCarroceria(ICommandRead command )
         {
            if (command is Command.Read.TipoCarroceriaReadCommand c)
                return getTipoCarroceria(c );
            throw new NotImplementedException();
        }
        private DataPagination<TipoCarroceriaDTO> getTipoCarroceria(Command.Read.TipoCarroceriaReadCommand command )
        {
            DataPagination<TipoCarroceriaDTO> customResult = null;
            var customHandled = false;
            TryGetTipoCarroceriaCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.TipoCarroceriaQuery(command );

                var itens = _unitOfWork.Query<TipoCarroceriaDTO>(query.Query,query.Parameters);
                return new DataPagination<TipoCarroceriaDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<TipoCarroceriaTenantIDDTO> getTipoCarroceriaReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TipoCarroceriaTenantIDDTO> lista;
            var query = _query.TipoCarroceriaTenantIDQuery(command );

                lista = _unitOfWork.Query<TipoCarroceriaTenantIDDTO>(query.Query,query.Parameters) as List<TipoCarroceriaTenantIDDTO>;
            return lista;
        }

        public IEnumerable<TipoCarroceriaTenantIDDTO> getTipoCarroceriaReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTipoCarroceriaReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<TipoCarroceriaUserIdDTO> getTipoCarroceriaReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TipoCarroceriaUserIdDTO> lista;
            var query = _query.TipoCarroceriaUserIdQuery(command );

                lista = _unitOfWork.Query<TipoCarroceriaUserIdDTO>(query.Query,query.Parameters) as List<TipoCarroceriaUserIdDTO>;
            return lista;
        }

        public IEnumerable<TipoCarroceriaUserIdDTO> getTipoCarroceriaReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTipoCarroceriaReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTCA_ID(string value )
        {
            var query = _query.ExistsByTCA_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTCA_DESCRICAO(string value )
        {
            var query = _query.ExistsByTCA_DESCRICAOQuery(value );

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

        public TipoCarroceriaDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoCarroceriaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoCarroceriaDTO FirstByTCA_ID(string value )
        {
            var query = _query.FirstByTCA_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoCarroceriaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoCarroceriaDTO FirstByTCA_DESCRICAO(string value )
        {
            var query = _query.FirstByTCA_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoCarroceriaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoCarroceriaDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoCarroceriaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoCarroceriaDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoCarroceriaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoCarroceriaDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoCarroceriaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoCarroceriaDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoCarroceriaDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<TipoCarroceriaDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<TipoCarroceriaDTO>(query.Query,query.Parameters) as List<TipoCarroceriaDTO>;
                return result;
        }

        public IEnumerable<TipoCarroceriaDTO> GetAllByTCA_ID(string value )
        {
            var query = _query.FirstByTCA_IDQuery(value );

                var result = _unitOfWork.Query<TipoCarroceriaDTO>(query.Query,query.Parameters) as List<TipoCarroceriaDTO>;
                return result;
        }

        public IEnumerable<TipoCarroceriaDTO> GetAllByTCA_DESCRICAO(string value )
        {
            var query = _query.FirstByTCA_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<TipoCarroceriaDTO>(query.Query,query.Parameters) as List<TipoCarroceriaDTO>;
                return result;
        }

        public IEnumerable<TipoCarroceriaDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<TipoCarroceriaDTO>(query.Query,query.Parameters) as List<TipoCarroceriaDTO>;
                return result;
        }

        public IEnumerable<TipoCarroceriaDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<TipoCarroceriaDTO>(query.Query,query.Parameters) as List<TipoCarroceriaDTO>;
                return result;
        }

        public IEnumerable<TipoCarroceriaDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<TipoCarroceriaDTO>(query.Query,query.Parameters) as List<TipoCarroceriaDTO>;
                return result;
        }

        public IEnumerable<TipoCarroceriaDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<TipoCarroceriaDTO>(query.Query,query.Parameters) as List<TipoCarroceriaDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration