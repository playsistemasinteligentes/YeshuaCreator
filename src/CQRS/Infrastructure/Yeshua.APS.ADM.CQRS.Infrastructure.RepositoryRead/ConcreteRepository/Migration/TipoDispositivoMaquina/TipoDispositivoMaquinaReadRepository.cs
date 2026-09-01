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
    public partial class TipoDispositivoMaquinaReadRepository : ITipoDispositivoMaquinaReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ITipoDispositivoMaquinaQueryRead _query;

        public TipoDispositivoMaquinaReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ITipoDispositivoMaquinaQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetTipoDispositivoMaquinaCustom(Command.Read.TipoDispositivoMaquinaReadCommand command, ref DataPagination<TipoDispositivoMaquinaDTO> result, ref bool handled);

        public DataPagination<TipoDispositivoMaquinaDTO> getTipoDispositivoMaquina(ICommandRead command )
         {
            if (command is Command.Read.TipoDispositivoMaquinaReadCommand c)
                return getTipoDispositivoMaquina(c );
            throw new NotImplementedException();
        }
        private DataPagination<TipoDispositivoMaquinaDTO> getTipoDispositivoMaquina(Command.Read.TipoDispositivoMaquinaReadCommand command )
        {
            DataPagination<TipoDispositivoMaquinaDTO> customResult = null;
            var customHandled = false;
            TryGetTipoDispositivoMaquinaCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.TipoDispositivoMaquinaQuery(command );

                var itens = _unitOfWork.Query<TipoDispositivoMaquinaDTO>(query.Query,query.Parameters);
                return new DataPagination<TipoDispositivoMaquinaDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<TipoDispositivoMaquinaTenantIDDTO> getTipoDispositivoMaquinaReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TipoDispositivoMaquinaTenantIDDTO> lista;
            var query = _query.TipoDispositivoMaquinaTenantIDQuery(command );

                lista = _unitOfWork.Query<TipoDispositivoMaquinaTenantIDDTO>(query.Query,query.Parameters) as List<TipoDispositivoMaquinaTenantIDDTO>;
            return lista;
        }

        public IEnumerable<TipoDispositivoMaquinaTenantIDDTO> getTipoDispositivoMaquinaReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTipoDispositivoMaquinaReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<TipoDispositivoMaquinaUserIdDTO> getTipoDispositivoMaquinaReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TipoDispositivoMaquinaUserIdDTO> lista;
            var query = _query.TipoDispositivoMaquinaUserIdQuery(command );

                lista = _unitOfWork.Query<TipoDispositivoMaquinaUserIdDTO>(query.Query,query.Parameters) as List<TipoDispositivoMaquinaUserIdDTO>;
            return lista;
        }

        public IEnumerable<TipoDispositivoMaquinaUserIdDTO> getTipoDispositivoMaquinaReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTipoDispositivoMaquinaReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTDI_ID(string value )
        {
            var query = _query.ExistsByTDI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMAQ_ID(string value )
        {
            var query = _query.ExistsByMAQ_IDQuery(value );

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

        public TipoDispositivoMaquinaDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoDispositivoMaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoDispositivoMaquinaDTO FirstByTDI_ID(string value )
        {
            var query = _query.FirstByTDI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoDispositivoMaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoDispositivoMaquinaDTO FirstByMAQ_ID(string value )
        {
            var query = _query.FirstByMAQ_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoDispositivoMaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoDispositivoMaquinaDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoDispositivoMaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoDispositivoMaquinaDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoDispositivoMaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoDispositivoMaquinaDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoDispositivoMaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TipoDispositivoMaquinaDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TipoDispositivoMaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<TipoDispositivoMaquinaDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<TipoDispositivoMaquinaDTO>(query.Query,query.Parameters) as List<TipoDispositivoMaquinaDTO>;
                return result;
        }

        public IEnumerable<TipoDispositivoMaquinaDTO> GetAllByTDI_ID(string value )
        {
            var query = _query.FirstByTDI_IDQuery(value );

                var result = _unitOfWork.Query<TipoDispositivoMaquinaDTO>(query.Query,query.Parameters) as List<TipoDispositivoMaquinaDTO>;
                return result;
        }

        public IEnumerable<TipoDispositivoMaquinaDTO> GetAllByMAQ_ID(string value )
        {
            var query = _query.FirstByMAQ_IDQuery(value );

                var result = _unitOfWork.Query<TipoDispositivoMaquinaDTO>(query.Query,query.Parameters) as List<TipoDispositivoMaquinaDTO>;
                return result;
        }

        public IEnumerable<TipoDispositivoMaquinaDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<TipoDispositivoMaquinaDTO>(query.Query,query.Parameters) as List<TipoDispositivoMaquinaDTO>;
                return result;
        }

        public IEnumerable<TipoDispositivoMaquinaDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<TipoDispositivoMaquinaDTO>(query.Query,query.Parameters) as List<TipoDispositivoMaquinaDTO>;
                return result;
        }

        public IEnumerable<TipoDispositivoMaquinaDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<TipoDispositivoMaquinaDTO>(query.Query,query.Parameters) as List<TipoDispositivoMaquinaDTO>;
                return result;
        }

        public IEnumerable<TipoDispositivoMaquinaDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<TipoDispositivoMaquinaDTO>(query.Query,query.Parameters) as List<TipoDispositivoMaquinaDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration