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
    public partial class CanhotosReadRepository : ICanhotosReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ICanhotosQueryRead _query;

        public CanhotosReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ICanhotosQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetCanhotosCustom(Command.Read.CanhotosReadCommand command, ref DataPagination<CanhotosDTO> result, ref bool handled);

        public DataPagination<CanhotosDTO> getCanhotos(ICommandRead command )
         {
            if (command is Command.Read.CanhotosReadCommand c)
                return getCanhotos(c );
            throw new NotImplementedException();
        }
        private DataPagination<CanhotosDTO> getCanhotos(Command.Read.CanhotosReadCommand command )
        {
            DataPagination<CanhotosDTO> customResult = null;
            var customHandled = false;
            TryGetCanhotosCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.CanhotosQuery(command );

                var itens = _unitOfWork.Query<CanhotosDTO>(query.Query,query.Parameters);
                return new DataPagination<CanhotosDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<CanhotosTenantIDDTO> getCanhotosReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CanhotosTenantIDDTO> lista;
            var query = _query.CanhotosTenantIDQuery(command );

                lista = _unitOfWork.Query<CanhotosTenantIDDTO>(query.Query,query.Parameters) as List<CanhotosTenantIDDTO>;
            return lista;
        }

        public IEnumerable<CanhotosTenantIDDTO> getCanhotosReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCanhotosReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<CanhotosUserIdDTO> getCanhotosReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CanhotosUserIdDTO> lista;
            var query = _query.CanhotosUserIdQuery(command );

                lista = _unitOfWork.Query<CanhotosUserIdDTO>(query.Query,query.Parameters) as List<CanhotosUserIdDTO>;
            return lista;
        }

        public IEnumerable<CanhotosUserIdDTO> getCanhotosReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCanhotosReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAR_ID(string value )
        {
            var query = _query.ExistsByCAR_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_ID(string value )
        {
            var query = _query.ExistsByORD_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByNOT_ID(string value )
        {
            var query = _query.ExistsByNOT_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAN_DATA_ENTREGA(DateTime value )
        {
            var query = _query.ExistsByCAN_DATA_ENTREGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAN_IMG(string value )
        {
            var query = _query.ExistsByCAN_IMGQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAN_LAT_ENTREGA(Decimal value )
        {
            var query = _query.ExistsByCAN_LAT_ENTREGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAN_LONG_ENTREGA(Decimal value )
        {
            var query = _query.ExistsByCAN_LONG_ENTREGAQuery(value );

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

        public CanhotosDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CanhotosDTO>(query.Query, query.Parameters);
                return result;
        }

        public CanhotosDTO FirstByCAR_ID(string value )
        {
            var query = _query.FirstByCAR_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CanhotosDTO>(query.Query, query.Parameters);
                return result;
        }

        public CanhotosDTO FirstByORD_ID(string value )
        {
            var query = _query.FirstByORD_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CanhotosDTO>(query.Query, query.Parameters);
                return result;
        }

        public CanhotosDTO FirstByNOT_ID(string value )
        {
            var query = _query.FirstByNOT_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CanhotosDTO>(query.Query, query.Parameters);
                return result;
        }

        public CanhotosDTO FirstByCAN_DATA_ENTREGA(DateTime value )
        {
            var query = _query.FirstByCAN_DATA_ENTREGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CanhotosDTO>(query.Query, query.Parameters);
                return result;
        }

        public CanhotosDTO FirstByCAN_IMG(string value )
        {
            var query = _query.FirstByCAN_IMGQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CanhotosDTO>(query.Query, query.Parameters);
                return result;
        }

        public CanhotosDTO FirstByCAN_LAT_ENTREGA(Decimal value )
        {
            var query = _query.FirstByCAN_LAT_ENTREGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CanhotosDTO>(query.Query, query.Parameters);
                return result;
        }

        public CanhotosDTO FirstByCAN_LONG_ENTREGA(Decimal value )
        {
            var query = _query.FirstByCAN_LONG_ENTREGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CanhotosDTO>(query.Query, query.Parameters);
                return result;
        }

        public CanhotosDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CanhotosDTO>(query.Query, query.Parameters);
                return result;
        }

        public CanhotosDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CanhotosDTO>(query.Query, query.Parameters);
                return result;
        }

        public CanhotosDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CanhotosDTO>(query.Query, query.Parameters);
                return result;
        }

        public CanhotosDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CanhotosDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<CanhotosDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<CanhotosDTO>(query.Query,query.Parameters) as List<CanhotosDTO>;
                return result;
        }

        public IEnumerable<CanhotosDTO> GetAllByCAR_ID(string value )
        {
            var query = _query.FirstByCAR_IDQuery(value );

                var result = _unitOfWork.Query<CanhotosDTO>(query.Query,query.Parameters) as List<CanhotosDTO>;
                return result;
        }

        public IEnumerable<CanhotosDTO> GetAllByORD_ID(string value )
        {
            var query = _query.FirstByORD_IDQuery(value );

                var result = _unitOfWork.Query<CanhotosDTO>(query.Query,query.Parameters) as List<CanhotosDTO>;
                return result;
        }

        public IEnumerable<CanhotosDTO> GetAllByNOT_ID(string value )
        {
            var query = _query.FirstByNOT_IDQuery(value );

                var result = _unitOfWork.Query<CanhotosDTO>(query.Query,query.Parameters) as List<CanhotosDTO>;
                return result;
        }

        public IEnumerable<CanhotosDTO> GetAllByCAN_DATA_ENTREGA(DateTime value )
        {
            var query = _query.FirstByCAN_DATA_ENTREGAQuery(value );

                var result = _unitOfWork.Query<CanhotosDTO>(query.Query,query.Parameters) as List<CanhotosDTO>;
                return result;
        }

        public IEnumerable<CanhotosDTO> GetAllByCAN_IMG(string value )
        {
            var query = _query.FirstByCAN_IMGQuery(value );

                var result = _unitOfWork.Query<CanhotosDTO>(query.Query,query.Parameters) as List<CanhotosDTO>;
                return result;
        }

        public IEnumerable<CanhotosDTO> GetAllByCAN_LAT_ENTREGA(Decimal value )
        {
            var query = _query.FirstByCAN_LAT_ENTREGAQuery(value );

                var result = _unitOfWork.Query<CanhotosDTO>(query.Query,query.Parameters) as List<CanhotosDTO>;
                return result;
        }

        public IEnumerable<CanhotosDTO> GetAllByCAN_LONG_ENTREGA(Decimal value )
        {
            var query = _query.FirstByCAN_LONG_ENTREGAQuery(value );

                var result = _unitOfWork.Query<CanhotosDTO>(query.Query,query.Parameters) as List<CanhotosDTO>;
                return result;
        }

        public IEnumerable<CanhotosDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<CanhotosDTO>(query.Query,query.Parameters) as List<CanhotosDTO>;
                return result;
        }

        public IEnumerable<CanhotosDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<CanhotosDTO>(query.Query,query.Parameters) as List<CanhotosDTO>;
                return result;
        }

        public IEnumerable<CanhotosDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<CanhotosDTO>(query.Query,query.Parameters) as List<CanhotosDTO>;
                return result;
        }

        public IEnumerable<CanhotosDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<CanhotosDTO>(query.Query,query.Parameters) as List<CanhotosDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration