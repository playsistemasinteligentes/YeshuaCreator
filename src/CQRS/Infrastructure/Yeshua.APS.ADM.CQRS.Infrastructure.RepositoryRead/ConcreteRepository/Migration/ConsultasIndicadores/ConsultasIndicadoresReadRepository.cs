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
    public partial class ConsultasIndicadoresReadRepository : IConsultasIndicadoresReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IConsultasIndicadoresQueryRead _query;

        public ConsultasIndicadoresReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IConsultasIndicadoresQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetConsultasIndicadoresCustom(Command.Read.ConsultasIndicadoresReadCommand command, ref DataPagination<ConsultasIndicadoresDTO> result, ref bool handled);

        public DataPagination<ConsultasIndicadoresDTO> getConsultasIndicadores(ICommandRead command )
         {
            if (command is Command.Read.ConsultasIndicadoresReadCommand c)
                return getConsultasIndicadores(c );
            throw new NotImplementedException();
        }
        private DataPagination<ConsultasIndicadoresDTO> getConsultasIndicadores(Command.Read.ConsultasIndicadoresReadCommand command )
        {
            DataPagination<ConsultasIndicadoresDTO> customResult = null;
            var customHandled = false;
            TryGetConsultasIndicadoresCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.ConsultasIndicadoresQuery(command );

                var itens = _unitOfWork.Query<ConsultasIndicadoresDTO>(query.Query,query.Parameters);
                return new DataPagination<ConsultasIndicadoresDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<ConsultasIndicadoresTenantIDDTO> getConsultasIndicadoresReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ConsultasIndicadoresTenantIDDTO> lista;
            var query = _query.ConsultasIndicadoresTenantIDQuery(command );

                lista = _unitOfWork.Query<ConsultasIndicadoresTenantIDDTO>(query.Query,query.Parameters) as List<ConsultasIndicadoresTenantIDDTO>;
            return lista;
        }

        public IEnumerable<ConsultasIndicadoresTenantIDDTO> getConsultasIndicadoresReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getConsultasIndicadoresReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ConsultasIndicadoresUserIdDTO> getConsultasIndicadoresReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ConsultasIndicadoresUserIdDTO> lista;
            var query = _query.ConsultasIndicadoresUserIdQuery(command );

                lista = _unitOfWork.Query<ConsultasIndicadoresUserIdDTO>(query.Query,query.Parameters) as List<ConsultasIndicadoresUserIdDTO>;
            return lista;
        }

        public IEnumerable<ConsultasIndicadoresUserIdDTO> getConsultasIndicadoresReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getConsultasIndicadoresReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCON_ID(int value )
        {
            var query = _query.ExistsByCON_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByIND_ID(int value )
        {
            var query = _query.ExistsByIND_IDQuery(value );

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

        public ConsultasIndicadoresDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ConsultasIndicadoresDTO>(query.Query, query.Parameters);
                return result;
        }

        public ConsultasIndicadoresDTO FirstByCON_ID(int value )
        {
            var query = _query.FirstByCON_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ConsultasIndicadoresDTO>(query.Query, query.Parameters);
                return result;
        }

        public ConsultasIndicadoresDTO FirstByIND_ID(int value )
        {
            var query = _query.FirstByIND_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ConsultasIndicadoresDTO>(query.Query, query.Parameters);
                return result;
        }

        public ConsultasIndicadoresDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ConsultasIndicadoresDTO>(query.Query, query.Parameters);
                return result;
        }

        public ConsultasIndicadoresDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ConsultasIndicadoresDTO>(query.Query, query.Parameters);
                return result;
        }

        public ConsultasIndicadoresDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ConsultasIndicadoresDTO>(query.Query, query.Parameters);
                return result;
        }

        public ConsultasIndicadoresDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ConsultasIndicadoresDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<ConsultasIndicadoresDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<ConsultasIndicadoresDTO>(query.Query,query.Parameters) as List<ConsultasIndicadoresDTO>;
                return result;
        }

        public IEnumerable<ConsultasIndicadoresDTO> GetAllByCON_ID(int value )
        {
            var query = _query.FirstByCON_IDQuery(value );

                var result = _unitOfWork.Query<ConsultasIndicadoresDTO>(query.Query,query.Parameters) as List<ConsultasIndicadoresDTO>;
                return result;
        }

        public IEnumerable<ConsultasIndicadoresDTO> GetAllByIND_ID(int value )
        {
            var query = _query.FirstByIND_IDQuery(value );

                var result = _unitOfWork.Query<ConsultasIndicadoresDTO>(query.Query,query.Parameters) as List<ConsultasIndicadoresDTO>;
                return result;
        }

        public IEnumerable<ConsultasIndicadoresDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<ConsultasIndicadoresDTO>(query.Query,query.Parameters) as List<ConsultasIndicadoresDTO>;
                return result;
        }

        public IEnumerable<ConsultasIndicadoresDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<ConsultasIndicadoresDTO>(query.Query,query.Parameters) as List<ConsultasIndicadoresDTO>;
                return result;
        }

        public IEnumerable<ConsultasIndicadoresDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<ConsultasIndicadoresDTO>(query.Query,query.Parameters) as List<ConsultasIndicadoresDTO>;
                return result;
        }

        public IEnumerable<ConsultasIndicadoresDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<ConsultasIndicadoresDTO>(query.Query,query.Parameters) as List<ConsultasIndicadoresDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration