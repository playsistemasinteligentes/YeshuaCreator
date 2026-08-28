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
    public partial class OrderTrackReadRepository : IOrderTrackReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IOrderTrackQueryRead _query;

        public OrderTrackReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IOrderTrackQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<OrderTrackDTO> getOrderTrack(ICommandRead command )
         {
            if (command is Command.Read.OrderTrackReadCommand c)
                return getOrderTrack(c );
            throw new NotImplementedException();
        }
        private DataPagination<OrderTrackDTO> getOrderTrack(Command.Read.OrderTrackReadCommand command )
        {
            var query = _query.OrderTrackQuery(command );

                var itens = _unitOfWork.Query<OrderTrackDTO>(query.Query,query.Parameters);
                return new DataPagination<OrderTrackDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<OrderTrackORD_IDDTO> getOrderTrackReadFKORD_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<OrderTrackORD_IDDTO> lista;
            var query = _query.OrderTrackORD_IDQuery(command );

                lista = _unitOfWork.Query<OrderTrackORD_IDDTO>(query.Query,query.Parameters) as List<OrderTrackORD_IDDTO>;
            return lista;
        }

        public IEnumerable<OrderTrackORD_IDDTO> getOrderTrackReadFKORD_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getOrderTrackReadFKORD_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<OrderTrackTenantIDDTO> getOrderTrackReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<OrderTrackTenantIDDTO> lista;
            var query = _query.OrderTrackTenantIDQuery(command );

                lista = _unitOfWork.Query<OrderTrackTenantIDDTO>(query.Query,query.Parameters) as List<OrderTrackTenantIDDTO>;
            return lista;
        }

        public IEnumerable<OrderTrackTenantIDDTO> getOrderTrackReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getOrderTrackReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<OrderTrackUserIdDTO> getOrderTrackReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<OrderTrackUserIdDTO> lista;
            var query = _query.OrderTrackUserIdQuery(command );

                lista = _unitOfWork.Query<OrderTrackUserIdDTO>(query.Query,query.Parameters) as List<OrderTrackUserIdDTO>;
            return lista;
        }

        public IEnumerable<OrderTrackUserIdDTO> getOrderTrackReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getOrderTrackReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOTK_ID(int value )
        {
            var query = _query.ExistsByOTK_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOTK_SEQUENCIA(Decimal value )
        {
            var query = _query.ExistsByOTK_SEQUENCIAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOTK_VERSSAO(int value )
        {
            var query = _query.ExistsByOTK_VERSSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_ID(string value )
        {
            var query = _query.ExistsByORD_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOTK_EVENTO(string value )
        {
            var query = _query.ExistsByOTK_EVENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOTK_DATA_NECESSIDADE_DE(DateTime value )
        {
            var query = _query.ExistsByOTK_DATA_NECESSIDADE_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOTK_DATA_NECESSIDADE_ATE(DateTime value )
        {
            var query = _query.ExistsByOTK_DATA_NECESSIDADE_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOTK_DATA_PREVISTA(DateTime value )
        {
            var query = _query.ExistsByOTK_DATA_PREVISTAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOTK_DATA_REALIZADA(DateTime value )
        {
            var query = _query.ExistsByOTK_DATA_REALIZADAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_ID(int value )
        {
            var query = _query.ExistsByFPR_IDQuery(value );

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

        public OrderTrackDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderTrackDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderTrackDTO FirstByOTK_ID(int value )
        {
            var query = _query.FirstByOTK_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderTrackDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderTrackDTO FirstByOTK_SEQUENCIA(Decimal value )
        {
            var query = _query.FirstByOTK_SEQUENCIAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderTrackDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderTrackDTO FirstByOTK_VERSSAO(int value )
        {
            var query = _query.FirstByOTK_VERSSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderTrackDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderTrackDTO FirstByORD_ID(string value )
        {
            var query = _query.FirstByORD_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderTrackDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderTrackDTO FirstByOTK_EVENTO(string value )
        {
            var query = _query.FirstByOTK_EVENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderTrackDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderTrackDTO FirstByOTK_DATA_NECESSIDADE_DE(DateTime value )
        {
            var query = _query.FirstByOTK_DATA_NECESSIDADE_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderTrackDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderTrackDTO FirstByOTK_DATA_NECESSIDADE_ATE(DateTime value )
        {
            var query = _query.FirstByOTK_DATA_NECESSIDADE_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderTrackDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderTrackDTO FirstByOTK_DATA_PREVISTA(DateTime value )
        {
            var query = _query.FirstByOTK_DATA_PREVISTAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderTrackDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderTrackDTO FirstByOTK_DATA_REALIZADA(DateTime value )
        {
            var query = _query.FirstByOTK_DATA_REALIZADAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderTrackDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderTrackDTO FirstByFPR_ID(int value )
        {
            var query = _query.FirstByFPR_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderTrackDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderTrackDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderTrackDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderTrackDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderTrackDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderTrackDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderTrackDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderTrackDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderTrackDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<OrderTrackDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<OrderTrackDTO>(query.Query,query.Parameters) as List<OrderTrackDTO>;
                return result;
        }

        public IEnumerable<OrderTrackDTO> GetAllByOTK_ID(int value )
        {
            var query = _query.FirstByOTK_IDQuery(value );

                var result = _unitOfWork.Query<OrderTrackDTO>(query.Query,query.Parameters) as List<OrderTrackDTO>;
                return result;
        }

        public IEnumerable<OrderTrackDTO> GetAllByOTK_SEQUENCIA(Decimal value )
        {
            var query = _query.FirstByOTK_SEQUENCIAQuery(value );

                var result = _unitOfWork.Query<OrderTrackDTO>(query.Query,query.Parameters) as List<OrderTrackDTO>;
                return result;
        }

        public IEnumerable<OrderTrackDTO> GetAllByOTK_VERSSAO(int value )
        {
            var query = _query.FirstByOTK_VERSSAOQuery(value );

                var result = _unitOfWork.Query<OrderTrackDTO>(query.Query,query.Parameters) as List<OrderTrackDTO>;
                return result;
        }

        public IEnumerable<OrderTrackDTO> GetAllByORD_ID(string value )
        {
            var query = _query.FirstByORD_IDQuery(value );

                var result = _unitOfWork.Query<OrderTrackDTO>(query.Query,query.Parameters) as List<OrderTrackDTO>;
                return result;
        }

        public IEnumerable<OrderTrackDTO> GetAllByOTK_EVENTO(string value )
        {
            var query = _query.FirstByOTK_EVENTOQuery(value );

                var result = _unitOfWork.Query<OrderTrackDTO>(query.Query,query.Parameters) as List<OrderTrackDTO>;
                return result;
        }

        public IEnumerable<OrderTrackDTO> GetAllByOTK_DATA_NECESSIDADE_DE(DateTime value )
        {
            var query = _query.FirstByOTK_DATA_NECESSIDADE_DEQuery(value );

                var result = _unitOfWork.Query<OrderTrackDTO>(query.Query,query.Parameters) as List<OrderTrackDTO>;
                return result;
        }

        public IEnumerable<OrderTrackDTO> GetAllByOTK_DATA_NECESSIDADE_ATE(DateTime value )
        {
            var query = _query.FirstByOTK_DATA_NECESSIDADE_ATEQuery(value );

                var result = _unitOfWork.Query<OrderTrackDTO>(query.Query,query.Parameters) as List<OrderTrackDTO>;
                return result;
        }

        public IEnumerable<OrderTrackDTO> GetAllByOTK_DATA_PREVISTA(DateTime value )
        {
            var query = _query.FirstByOTK_DATA_PREVISTAQuery(value );

                var result = _unitOfWork.Query<OrderTrackDTO>(query.Query,query.Parameters) as List<OrderTrackDTO>;
                return result;
        }

        public IEnumerable<OrderTrackDTO> GetAllByOTK_DATA_REALIZADA(DateTime value )
        {
            var query = _query.FirstByOTK_DATA_REALIZADAQuery(value );

                var result = _unitOfWork.Query<OrderTrackDTO>(query.Query,query.Parameters) as List<OrderTrackDTO>;
                return result;
        }

        public IEnumerable<OrderTrackDTO> GetAllByFPR_ID(int value )
        {
            var query = _query.FirstByFPR_IDQuery(value );

                var result = _unitOfWork.Query<OrderTrackDTO>(query.Query,query.Parameters) as List<OrderTrackDTO>;
                return result;
        }

        public IEnumerable<OrderTrackDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<OrderTrackDTO>(query.Query,query.Parameters) as List<OrderTrackDTO>;
                return result;
        }

        public IEnumerable<OrderTrackDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<OrderTrackDTO>(query.Query,query.Parameters) as List<OrderTrackDTO>;
                return result;
        }

        public IEnumerable<OrderTrackDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<OrderTrackDTO>(query.Query,query.Parameters) as List<OrderTrackDTO>;
                return result;
        }

        public IEnumerable<OrderTrackDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<OrderTrackDTO>(query.Query,query.Parameters) as List<OrderTrackDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration