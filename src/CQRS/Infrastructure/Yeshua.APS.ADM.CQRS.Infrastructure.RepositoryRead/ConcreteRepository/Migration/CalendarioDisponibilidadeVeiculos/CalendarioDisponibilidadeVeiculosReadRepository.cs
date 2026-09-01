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
    public partial class CalendarioDisponibilidadeVeiculosReadRepository : ICalendarioDisponibilidadeVeiculosReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ICalendarioDisponibilidadeVeiculosQueryRead _query;

        public CalendarioDisponibilidadeVeiculosReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ICalendarioDisponibilidadeVeiculosQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetCalendarioDisponibilidadeVeiculosCustom(Command.Read.CalendarioDisponibilidadeVeiculosReadCommand command, ref DataPagination<CalendarioDisponibilidadeVeiculosDTO> result, ref bool handled);

        public DataPagination<CalendarioDisponibilidadeVeiculosDTO> getCalendarioDisponibilidadeVeiculos(ICommandRead command )
         {
            if (command is Command.Read.CalendarioDisponibilidadeVeiculosReadCommand c)
                return getCalendarioDisponibilidadeVeiculos(c );
            throw new NotImplementedException();
        }
        private DataPagination<CalendarioDisponibilidadeVeiculosDTO> getCalendarioDisponibilidadeVeiculos(Command.Read.CalendarioDisponibilidadeVeiculosReadCommand command )
        {
            DataPagination<CalendarioDisponibilidadeVeiculosDTO> customResult = null;
            var customHandled = false;
            TryGetCalendarioDisponibilidadeVeiculosCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.CalendarioDisponibilidadeVeiculosQuery(command );

                var itens = _unitOfWork.Query<CalendarioDisponibilidadeVeiculosDTO>(query.Query,query.Parameters);
                return new DataPagination<CalendarioDisponibilidadeVeiculosDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<CalendarioDisponibilidadeVeiculosTenantIDDTO> getCalendarioDisponibilidadeVeiculosReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CalendarioDisponibilidadeVeiculosTenantIDDTO> lista;
            var query = _query.CalendarioDisponibilidadeVeiculosTenantIDQuery(command );

                lista = _unitOfWork.Query<CalendarioDisponibilidadeVeiculosTenantIDDTO>(query.Query,query.Parameters) as List<CalendarioDisponibilidadeVeiculosTenantIDDTO>;
            return lista;
        }

        public IEnumerable<CalendarioDisponibilidadeVeiculosTenantIDDTO> getCalendarioDisponibilidadeVeiculosReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCalendarioDisponibilidadeVeiculosReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<CalendarioDisponibilidadeVeiculosUserIdDTO> getCalendarioDisponibilidadeVeiculosReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CalendarioDisponibilidadeVeiculosUserIdDTO> lista;
            var query = _query.CalendarioDisponibilidadeVeiculosUserIdQuery(command );

                lista = _unitOfWork.Query<CalendarioDisponibilidadeVeiculosUserIdDTO>(query.Query,query.Parameters) as List<CalendarioDisponibilidadeVeiculosUserIdDTO>;
            return lista;
        }

        public IEnumerable<CalendarioDisponibilidadeVeiculosUserIdDTO> getCalendarioDisponibilidadeVeiculosReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCalendarioDisponibilidadeVeiculosReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCDV_ID(int value )
        {
            var query = _query.ExistsByCDV_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCDV_DATA_DE(DateTime value )
        {
            var query = _query.ExistsByCDV_DATA_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCDV_DATA_ATE(DateTime value )
        {
            var query = _query.ExistsByCDV_DATA_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCDV_SEGUNDA(int value )
        {
            var query = _query.ExistsByCDV_SEGUNDAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCDV_TERCA(int value )
        {
            var query = _query.ExistsByCDV_TERCAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCDV_QUARTA(int value )
        {
            var query = _query.ExistsByCDV_QUARTAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCDV_QUINTA(int value )
        {
            var query = _query.ExistsByCDV_QUINTAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCDV_SEXTA(int value )
        {
            var query = _query.ExistsByCDV_SEXTAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCDV_SABADO(int value )
        {
            var query = _query.ExistsByCDV_SABADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCDV_DOMINGO(int value )
        {
            var query = _query.ExistsByCDV_DOMINGOQuery(value );

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

        public CalendarioDisponibilidadeVeiculosDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CalendarioDisponibilidadeVeiculosDTO>(query.Query, query.Parameters);
                return result;
        }

        public CalendarioDisponibilidadeVeiculosDTO FirstByCDV_ID(int value )
        {
            var query = _query.FirstByCDV_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CalendarioDisponibilidadeVeiculosDTO>(query.Query, query.Parameters);
                return result;
        }

        public CalendarioDisponibilidadeVeiculosDTO FirstByCDV_DATA_DE(DateTime value )
        {
            var query = _query.FirstByCDV_DATA_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CalendarioDisponibilidadeVeiculosDTO>(query.Query, query.Parameters);
                return result;
        }

        public CalendarioDisponibilidadeVeiculosDTO FirstByCDV_DATA_ATE(DateTime value )
        {
            var query = _query.FirstByCDV_DATA_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CalendarioDisponibilidadeVeiculosDTO>(query.Query, query.Parameters);
                return result;
        }

        public CalendarioDisponibilidadeVeiculosDTO FirstByCDV_SEGUNDA(int value )
        {
            var query = _query.FirstByCDV_SEGUNDAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CalendarioDisponibilidadeVeiculosDTO>(query.Query, query.Parameters);
                return result;
        }

        public CalendarioDisponibilidadeVeiculosDTO FirstByCDV_TERCA(int value )
        {
            var query = _query.FirstByCDV_TERCAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CalendarioDisponibilidadeVeiculosDTO>(query.Query, query.Parameters);
                return result;
        }

        public CalendarioDisponibilidadeVeiculosDTO FirstByCDV_QUARTA(int value )
        {
            var query = _query.FirstByCDV_QUARTAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CalendarioDisponibilidadeVeiculosDTO>(query.Query, query.Parameters);
                return result;
        }

        public CalendarioDisponibilidadeVeiculosDTO FirstByCDV_QUINTA(int value )
        {
            var query = _query.FirstByCDV_QUINTAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CalendarioDisponibilidadeVeiculosDTO>(query.Query, query.Parameters);
                return result;
        }

        public CalendarioDisponibilidadeVeiculosDTO FirstByCDV_SEXTA(int value )
        {
            var query = _query.FirstByCDV_SEXTAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CalendarioDisponibilidadeVeiculosDTO>(query.Query, query.Parameters);
                return result;
        }

        public CalendarioDisponibilidadeVeiculosDTO FirstByCDV_SABADO(int value )
        {
            var query = _query.FirstByCDV_SABADOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CalendarioDisponibilidadeVeiculosDTO>(query.Query, query.Parameters);
                return result;
        }

        public CalendarioDisponibilidadeVeiculosDTO FirstByCDV_DOMINGO(int value )
        {
            var query = _query.FirstByCDV_DOMINGOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CalendarioDisponibilidadeVeiculosDTO>(query.Query, query.Parameters);
                return result;
        }

        public CalendarioDisponibilidadeVeiculosDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CalendarioDisponibilidadeVeiculosDTO>(query.Query, query.Parameters);
                return result;
        }

        public CalendarioDisponibilidadeVeiculosDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CalendarioDisponibilidadeVeiculosDTO>(query.Query, query.Parameters);
                return result;
        }

        public CalendarioDisponibilidadeVeiculosDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CalendarioDisponibilidadeVeiculosDTO>(query.Query, query.Parameters);
                return result;
        }

        public CalendarioDisponibilidadeVeiculosDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CalendarioDisponibilidadeVeiculosDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<CalendarioDisponibilidadeVeiculosDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<CalendarioDisponibilidadeVeiculosDTO>(query.Query,query.Parameters) as List<CalendarioDisponibilidadeVeiculosDTO>;
                return result;
        }

        public IEnumerable<CalendarioDisponibilidadeVeiculosDTO> GetAllByCDV_ID(int value )
        {
            var query = _query.FirstByCDV_IDQuery(value );

                var result = _unitOfWork.Query<CalendarioDisponibilidadeVeiculosDTO>(query.Query,query.Parameters) as List<CalendarioDisponibilidadeVeiculosDTO>;
                return result;
        }

        public IEnumerable<CalendarioDisponibilidadeVeiculosDTO> GetAllByCDV_DATA_DE(DateTime value )
        {
            var query = _query.FirstByCDV_DATA_DEQuery(value );

                var result = _unitOfWork.Query<CalendarioDisponibilidadeVeiculosDTO>(query.Query,query.Parameters) as List<CalendarioDisponibilidadeVeiculosDTO>;
                return result;
        }

        public IEnumerable<CalendarioDisponibilidadeVeiculosDTO> GetAllByCDV_DATA_ATE(DateTime value )
        {
            var query = _query.FirstByCDV_DATA_ATEQuery(value );

                var result = _unitOfWork.Query<CalendarioDisponibilidadeVeiculosDTO>(query.Query,query.Parameters) as List<CalendarioDisponibilidadeVeiculosDTO>;
                return result;
        }

        public IEnumerable<CalendarioDisponibilidadeVeiculosDTO> GetAllByCDV_SEGUNDA(int value )
        {
            var query = _query.FirstByCDV_SEGUNDAQuery(value );

                var result = _unitOfWork.Query<CalendarioDisponibilidadeVeiculosDTO>(query.Query,query.Parameters) as List<CalendarioDisponibilidadeVeiculosDTO>;
                return result;
        }

        public IEnumerable<CalendarioDisponibilidadeVeiculosDTO> GetAllByCDV_TERCA(int value )
        {
            var query = _query.FirstByCDV_TERCAQuery(value );

                var result = _unitOfWork.Query<CalendarioDisponibilidadeVeiculosDTO>(query.Query,query.Parameters) as List<CalendarioDisponibilidadeVeiculosDTO>;
                return result;
        }

        public IEnumerable<CalendarioDisponibilidadeVeiculosDTO> GetAllByCDV_QUARTA(int value )
        {
            var query = _query.FirstByCDV_QUARTAQuery(value );

                var result = _unitOfWork.Query<CalendarioDisponibilidadeVeiculosDTO>(query.Query,query.Parameters) as List<CalendarioDisponibilidadeVeiculosDTO>;
                return result;
        }

        public IEnumerable<CalendarioDisponibilidadeVeiculosDTO> GetAllByCDV_QUINTA(int value )
        {
            var query = _query.FirstByCDV_QUINTAQuery(value );

                var result = _unitOfWork.Query<CalendarioDisponibilidadeVeiculosDTO>(query.Query,query.Parameters) as List<CalendarioDisponibilidadeVeiculosDTO>;
                return result;
        }

        public IEnumerable<CalendarioDisponibilidadeVeiculosDTO> GetAllByCDV_SEXTA(int value )
        {
            var query = _query.FirstByCDV_SEXTAQuery(value );

                var result = _unitOfWork.Query<CalendarioDisponibilidadeVeiculosDTO>(query.Query,query.Parameters) as List<CalendarioDisponibilidadeVeiculosDTO>;
                return result;
        }

        public IEnumerable<CalendarioDisponibilidadeVeiculosDTO> GetAllByCDV_SABADO(int value )
        {
            var query = _query.FirstByCDV_SABADOQuery(value );

                var result = _unitOfWork.Query<CalendarioDisponibilidadeVeiculosDTO>(query.Query,query.Parameters) as List<CalendarioDisponibilidadeVeiculosDTO>;
                return result;
        }

        public IEnumerable<CalendarioDisponibilidadeVeiculosDTO> GetAllByCDV_DOMINGO(int value )
        {
            var query = _query.FirstByCDV_DOMINGOQuery(value );

                var result = _unitOfWork.Query<CalendarioDisponibilidadeVeiculosDTO>(query.Query,query.Parameters) as List<CalendarioDisponibilidadeVeiculosDTO>;
                return result;
        }

        public IEnumerable<CalendarioDisponibilidadeVeiculosDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<CalendarioDisponibilidadeVeiculosDTO>(query.Query,query.Parameters) as List<CalendarioDisponibilidadeVeiculosDTO>;
                return result;
        }

        public IEnumerable<CalendarioDisponibilidadeVeiculosDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<CalendarioDisponibilidadeVeiculosDTO>(query.Query,query.Parameters) as List<CalendarioDisponibilidadeVeiculosDTO>;
                return result;
        }

        public IEnumerable<CalendarioDisponibilidadeVeiculosDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<CalendarioDisponibilidadeVeiculosDTO>(query.Query,query.Parameters) as List<CalendarioDisponibilidadeVeiculosDTO>;
                return result;
        }

        public IEnumerable<CalendarioDisponibilidadeVeiculosDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<CalendarioDisponibilidadeVeiculosDTO>(query.Query,query.Parameters) as List<CalendarioDisponibilidadeVeiculosDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration