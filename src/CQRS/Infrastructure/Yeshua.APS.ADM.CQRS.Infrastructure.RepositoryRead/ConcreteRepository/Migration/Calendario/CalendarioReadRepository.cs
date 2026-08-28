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
    public partial class CalendarioReadRepository : ICalendarioReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ICalendarioQueryRead _query;

        public CalendarioReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ICalendarioQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<CalendarioDTO> getCalendario(ICommandRead command )
         {
            if (command is Command.Read.CalendarioReadCommand c)
                return getCalendario(c );
            throw new NotImplementedException();
        }
        private DataPagination<CalendarioDTO> getCalendario(Command.Read.CalendarioReadCommand command )
        {
            var query = _query.CalendarioQuery(command );

                var itens = _unitOfWork.Query<CalendarioDTO>(query.Query,query.Parameters);
                return new DataPagination<CalendarioDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<CalendarioTenantIDDTO> getCalendarioReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CalendarioTenantIDDTO> lista;
            var query = _query.CalendarioTenantIDQuery(command );

                lista = _unitOfWork.Query<CalendarioTenantIDDTO>(query.Query,query.Parameters) as List<CalendarioTenantIDDTO>;
            return lista;
        }

        public IEnumerable<CalendarioTenantIDDTO> getCalendarioReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCalendarioReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<CalendarioUserIdDTO> getCalendarioReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CalendarioUserIdDTO> lista;
            var query = _query.CalendarioUserIdQuery(command );

                lista = _unitOfWork.Query<CalendarioUserIdDTO>(query.Query,query.Parameters) as List<CalendarioUserIdDTO>;
            return lista;
        }

        public IEnumerable<CalendarioUserIdDTO> getCalendarioReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCalendarioReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByCAL_ID(int value )
        {
            var query = _query.ExistsByCAL_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAL_DESCRICAO(string value )
        {
            var query = _query.ExistsByCAL_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAL_DIVIDE_DIA_EM(int value )
        {
            var query = _query.ExistsByCAL_DIVIDE_DIA_EMQuery(value );

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

        public CalendarioDTO FirstByCAL_ID(int value )
        {
            var query = _query.FirstByCAL_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CalendarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public CalendarioDTO FirstByCAL_DESCRICAO(string value )
        {
            var query = _query.FirstByCAL_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CalendarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public CalendarioDTO FirstByCAL_DIVIDE_DIA_EM(int value )
        {
            var query = _query.FirstByCAL_DIVIDE_DIA_EMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CalendarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public CalendarioDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CalendarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public CalendarioDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CalendarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public CalendarioDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CalendarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public CalendarioDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CalendarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<CalendarioDTO> GetAllByCAL_ID(int value )
        {
            var query = _query.FirstByCAL_IDQuery(value );

                var result = _unitOfWork.Query<CalendarioDTO>(query.Query,query.Parameters) as List<CalendarioDTO>;
                return result;
        }

        public IEnumerable<CalendarioDTO> GetAllByCAL_DESCRICAO(string value )
        {
            var query = _query.FirstByCAL_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<CalendarioDTO>(query.Query,query.Parameters) as List<CalendarioDTO>;
                return result;
        }

        public IEnumerable<CalendarioDTO> GetAllByCAL_DIVIDE_DIA_EM(int value )
        {
            var query = _query.FirstByCAL_DIVIDE_DIA_EMQuery(value );

                var result = _unitOfWork.Query<CalendarioDTO>(query.Query,query.Parameters) as List<CalendarioDTO>;
                return result;
        }

        public IEnumerable<CalendarioDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<CalendarioDTO>(query.Query,query.Parameters) as List<CalendarioDTO>;
                return result;
        }

        public IEnumerable<CalendarioDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<CalendarioDTO>(query.Query,query.Parameters) as List<CalendarioDTO>;
                return result;
        }

        public IEnumerable<CalendarioDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<CalendarioDTO>(query.Query,query.Parameters) as List<CalendarioDTO>;
                return result;
        }

        public IEnumerable<CalendarioDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<CalendarioDTO>(query.Query,query.Parameters) as List<CalendarioDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration