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
    public partial class ItenCalendarioDisponibilidadeVeiculosReadRepository : IItenCalendarioDisponibilidadeVeiculosReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IItenCalendarioDisponibilidadeVeiculosQueryRead _query;

        public ItenCalendarioDisponibilidadeVeiculosReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IItenCalendarioDisponibilidadeVeiculosQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetItenCalendarioDisponibilidadeVeiculosCustom(Command.Read.ItenCalendarioDisponibilidadeVeiculosReadCommand command, ref DataPagination<ItenCalendarioDisponibilidadeVeiculosDTO> result, ref bool handled);

        public DataPagination<ItenCalendarioDisponibilidadeVeiculosDTO> getItenCalendarioDisponibilidadeVeiculos(ICommandRead command )
         {
            if (command is Command.Read.ItenCalendarioDisponibilidadeVeiculosReadCommand c)
                return getItenCalendarioDisponibilidadeVeiculos(c );
            throw new NotImplementedException();
        }
        private DataPagination<ItenCalendarioDisponibilidadeVeiculosDTO> getItenCalendarioDisponibilidadeVeiculos(Command.Read.ItenCalendarioDisponibilidadeVeiculosReadCommand command )
        {
            DataPagination<ItenCalendarioDisponibilidadeVeiculosDTO> customResult = null;
            var customHandled = false;
            TryGetItenCalendarioDisponibilidadeVeiculosCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.ItenCalendarioDisponibilidadeVeiculosQuery(command );

                var itens = _unitOfWork.Query<ItenCalendarioDisponibilidadeVeiculosDTO>(query.Query,query.Parameters);
                return new DataPagination<ItenCalendarioDisponibilidadeVeiculosDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<ItenCalendarioDisponibilidadeVeiculosTenantIDDTO> getItenCalendarioDisponibilidadeVeiculosReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ItenCalendarioDisponibilidadeVeiculosTenantIDDTO> lista;
            var query = _query.ItenCalendarioDisponibilidadeVeiculosTenantIDQuery(command );

                lista = _unitOfWork.Query<ItenCalendarioDisponibilidadeVeiculosTenantIDDTO>(query.Query,query.Parameters) as List<ItenCalendarioDisponibilidadeVeiculosTenantIDDTO>;
            return lista;
        }

        public IEnumerable<ItenCalendarioDisponibilidadeVeiculosTenantIDDTO> getItenCalendarioDisponibilidadeVeiculosReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getItenCalendarioDisponibilidadeVeiculosReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ItenCalendarioDisponibilidadeVeiculosUserIdDTO> getItenCalendarioDisponibilidadeVeiculosReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ItenCalendarioDisponibilidadeVeiculosUserIdDTO> lista;
            var query = _query.ItenCalendarioDisponibilidadeVeiculosUserIdQuery(command );

                lista = _unitOfWork.Query<ItenCalendarioDisponibilidadeVeiculosUserIdDTO>(query.Query,query.Parameters) as List<ItenCalendarioDisponibilidadeVeiculosUserIdDTO>;
            return lista;
        }

        public IEnumerable<ItenCalendarioDisponibilidadeVeiculosUserIdDTO> getItenCalendarioDisponibilidadeVeiculosReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getItenCalendarioDisponibilidadeVeiculosReadFKUserId(c );
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

        public bool ExistsByTIP_ID(int value )
        {
            var query = _query.ExistsByTIP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByIDV_QTD(int value )
        {
            var query = _query.ExistsByIDV_QTDQuery(value );

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

        public ItenCalendarioDisponibilidadeVeiculosDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItenCalendarioDisponibilidadeVeiculosDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItenCalendarioDisponibilidadeVeiculosDTO FirstByCDV_ID(int value )
        {
            var query = _query.FirstByCDV_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItenCalendarioDisponibilidadeVeiculosDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItenCalendarioDisponibilidadeVeiculosDTO FirstByTIP_ID(int value )
        {
            var query = _query.FirstByTIP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItenCalendarioDisponibilidadeVeiculosDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItenCalendarioDisponibilidadeVeiculosDTO FirstByIDV_QTD(int value )
        {
            var query = _query.FirstByIDV_QTDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItenCalendarioDisponibilidadeVeiculosDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItenCalendarioDisponibilidadeVeiculosDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItenCalendarioDisponibilidadeVeiculosDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItenCalendarioDisponibilidadeVeiculosDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItenCalendarioDisponibilidadeVeiculosDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItenCalendarioDisponibilidadeVeiculosDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItenCalendarioDisponibilidadeVeiculosDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItenCalendarioDisponibilidadeVeiculosDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItenCalendarioDisponibilidadeVeiculosDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<ItenCalendarioDisponibilidadeVeiculosDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<ItenCalendarioDisponibilidadeVeiculosDTO>(query.Query,query.Parameters) as List<ItenCalendarioDisponibilidadeVeiculosDTO>;
                return result;
        }

        public IEnumerable<ItenCalendarioDisponibilidadeVeiculosDTO> GetAllByCDV_ID(int value )
        {
            var query = _query.FirstByCDV_IDQuery(value );

                var result = _unitOfWork.Query<ItenCalendarioDisponibilidadeVeiculosDTO>(query.Query,query.Parameters) as List<ItenCalendarioDisponibilidadeVeiculosDTO>;
                return result;
        }

        public IEnumerable<ItenCalendarioDisponibilidadeVeiculosDTO> GetAllByTIP_ID(int value )
        {
            var query = _query.FirstByTIP_IDQuery(value );

                var result = _unitOfWork.Query<ItenCalendarioDisponibilidadeVeiculosDTO>(query.Query,query.Parameters) as List<ItenCalendarioDisponibilidadeVeiculosDTO>;
                return result;
        }

        public IEnumerable<ItenCalendarioDisponibilidadeVeiculosDTO> GetAllByIDV_QTD(int value )
        {
            var query = _query.FirstByIDV_QTDQuery(value );

                var result = _unitOfWork.Query<ItenCalendarioDisponibilidadeVeiculosDTO>(query.Query,query.Parameters) as List<ItenCalendarioDisponibilidadeVeiculosDTO>;
                return result;
        }

        public IEnumerable<ItenCalendarioDisponibilidadeVeiculosDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<ItenCalendarioDisponibilidadeVeiculosDTO>(query.Query,query.Parameters) as List<ItenCalendarioDisponibilidadeVeiculosDTO>;
                return result;
        }

        public IEnumerable<ItenCalendarioDisponibilidadeVeiculosDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<ItenCalendarioDisponibilidadeVeiculosDTO>(query.Query,query.Parameters) as List<ItenCalendarioDisponibilidadeVeiculosDTO>;
                return result;
        }

        public IEnumerable<ItenCalendarioDisponibilidadeVeiculosDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<ItenCalendarioDisponibilidadeVeiculosDTO>(query.Query,query.Parameters) as List<ItenCalendarioDisponibilidadeVeiculosDTO>;
                return result;
        }

        public IEnumerable<ItenCalendarioDisponibilidadeVeiculosDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<ItenCalendarioDisponibilidadeVeiculosDTO>(query.Query,query.Parameters) as List<ItenCalendarioDisponibilidadeVeiculosDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration