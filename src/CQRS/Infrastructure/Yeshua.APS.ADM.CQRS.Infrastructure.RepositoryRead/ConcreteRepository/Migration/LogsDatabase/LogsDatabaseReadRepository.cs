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
    public partial class LogsDatabaseReadRepository : ILogsDatabaseReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ILogsDatabaseQueryRead _query;

        public LogsDatabaseReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ILogsDatabaseQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<LogsDatabaseDTO> getLogsDatabase(ICommandRead command )
         {
            if (command is Command.Read.LogsDatabaseReadCommand c)
                return getLogsDatabase(c );
            throw new NotImplementedException();
        }
        private DataPagination<LogsDatabaseDTO> getLogsDatabase(Command.Read.LogsDatabaseReadCommand command )
        {
            var query = _query.LogsDatabaseQuery(command );

                var itens = _unitOfWork.Query<LogsDatabaseDTO>(query.Query,query.Parameters);
                return new DataPagination<LogsDatabaseDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<LogsDatabaseUSE_IDDTO> getLogsDatabaseReadFKUSE_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<LogsDatabaseUSE_IDDTO> lista;
            var query = _query.LogsDatabaseUSE_IDQuery(command );

                lista = _unitOfWork.Query<LogsDatabaseUSE_IDDTO>(query.Query,query.Parameters) as List<LogsDatabaseUSE_IDDTO>;
            return lista;
        }

        public IEnumerable<LogsDatabaseUSE_IDDTO> getLogsDatabaseReadFKUSE_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getLogsDatabaseReadFKUSE_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<LogsDatabaseTenantIDDTO> getLogsDatabaseReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<LogsDatabaseTenantIDDTO> lista;
            var query = _query.LogsDatabaseTenantIDQuery(command );

                lista = _unitOfWork.Query<LogsDatabaseTenantIDDTO>(query.Query,query.Parameters) as List<LogsDatabaseTenantIDDTO>;
            return lista;
        }

        public IEnumerable<LogsDatabaseTenantIDDTO> getLogsDatabaseReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getLogsDatabaseReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<LogsDatabaseUserIdDTO> getLogsDatabaseReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<LogsDatabaseUserIdDTO> lista;
            var query = _query.LogsDatabaseUserIdQuery(command );

                lista = _unitOfWork.Query<LogsDatabaseUserIdDTO>(query.Query,query.Parameters) as List<LogsDatabaseUserIdDTO>;
            return lista;
        }

        public IEnumerable<LogsDatabaseUserIdDTO> getLogsDatabaseReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getLogsDatabaseReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByLOGS_ID(int value )
        {
            var query = _query.ExistsByLOGS_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByLOGS_TABLE(string value )
        {
            var query = _query.ExistsByLOGS_TABLEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByLOGS_KEY(string value )
        {
            var query = _query.ExistsByLOGS_KEYQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByLOGS_KEY1(string value )
        {
            var query = _query.ExistsByLOGS_KEY1Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByLOGS_KEY2(string value )
        {
            var query = _query.ExistsByLOGS_KEY2Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByLOGS_KEY3(string value )
        {
            var query = _query.ExistsByLOGS_KEY3Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByLOGS_KEY4(string value )
        {
            var query = _query.ExistsByLOGS_KEY4Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByLOGS_COLUMN(string value )
        {
            var query = _query.ExistsByLOGS_COLUMNQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByLOGS_BEFORE(string value )
        {
            var query = _query.ExistsByLOGS_BEFOREQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByLOGS_AFTER(string value )
        {
            var query = _query.ExistsByLOGS_AFTERQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByLOGS_ACTION(string value )
        {
            var query = _query.ExistsByLOGS_ACTIONQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByLOGS_DATE(DateTime value )
        {
            var query = _query.ExistsByLOGS_DATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUSE_ID(int value )
        {
            var query = _query.ExistsByUSE_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByLOGS_ORIGEM(string value )
        {
            var query = _query.ExistsByLOGS_ORIGEMQuery(value );

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

        public LogsDatabaseDTO FirstByLOGS_ID(int value )
        {
            var query = _query.FirstByLOGS_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LogsDatabaseDTO>(query.Query, query.Parameters);
                return result;
        }

        public LogsDatabaseDTO FirstByLOGS_TABLE(string value )
        {
            var query = _query.FirstByLOGS_TABLEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LogsDatabaseDTO>(query.Query, query.Parameters);
                return result;
        }

        public LogsDatabaseDTO FirstByLOGS_KEY(string value )
        {
            var query = _query.FirstByLOGS_KEYQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LogsDatabaseDTO>(query.Query, query.Parameters);
                return result;
        }

        public LogsDatabaseDTO FirstByLOGS_KEY1(string value )
        {
            var query = _query.FirstByLOGS_KEY1Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<LogsDatabaseDTO>(query.Query, query.Parameters);
                return result;
        }

        public LogsDatabaseDTO FirstByLOGS_KEY2(string value )
        {
            var query = _query.FirstByLOGS_KEY2Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<LogsDatabaseDTO>(query.Query, query.Parameters);
                return result;
        }

        public LogsDatabaseDTO FirstByLOGS_KEY3(string value )
        {
            var query = _query.FirstByLOGS_KEY3Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<LogsDatabaseDTO>(query.Query, query.Parameters);
                return result;
        }

        public LogsDatabaseDTO FirstByLOGS_KEY4(string value )
        {
            var query = _query.FirstByLOGS_KEY4Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<LogsDatabaseDTO>(query.Query, query.Parameters);
                return result;
        }

        public LogsDatabaseDTO FirstByLOGS_COLUMN(string value )
        {
            var query = _query.FirstByLOGS_COLUMNQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LogsDatabaseDTO>(query.Query, query.Parameters);
                return result;
        }

        public LogsDatabaseDTO FirstByLOGS_BEFORE(string value )
        {
            var query = _query.FirstByLOGS_BEFOREQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LogsDatabaseDTO>(query.Query, query.Parameters);
                return result;
        }

        public LogsDatabaseDTO FirstByLOGS_AFTER(string value )
        {
            var query = _query.FirstByLOGS_AFTERQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LogsDatabaseDTO>(query.Query, query.Parameters);
                return result;
        }

        public LogsDatabaseDTO FirstByLOGS_ACTION(string value )
        {
            var query = _query.FirstByLOGS_ACTIONQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LogsDatabaseDTO>(query.Query, query.Parameters);
                return result;
        }

        public LogsDatabaseDTO FirstByLOGS_DATE(DateTime value )
        {
            var query = _query.FirstByLOGS_DATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LogsDatabaseDTO>(query.Query, query.Parameters);
                return result;
        }

        public LogsDatabaseDTO FirstByUSE_ID(int value )
        {
            var query = _query.FirstByUSE_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LogsDatabaseDTO>(query.Query, query.Parameters);
                return result;
        }

        public LogsDatabaseDTO FirstByLOGS_ORIGEM(string value )
        {
            var query = _query.FirstByLOGS_ORIGEMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LogsDatabaseDTO>(query.Query, query.Parameters);
                return result;
        }

        public LogsDatabaseDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LogsDatabaseDTO>(query.Query, query.Parameters);
                return result;
        }

        public LogsDatabaseDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LogsDatabaseDTO>(query.Query, query.Parameters);
                return result;
        }

        public LogsDatabaseDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LogsDatabaseDTO>(query.Query, query.Parameters);
                return result;
        }

        public LogsDatabaseDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<LogsDatabaseDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<LogsDatabaseDTO> GetAllByLOGS_ID(int value )
        {
            var query = _query.FirstByLOGS_IDQuery(value );

                var result = _unitOfWork.Query<LogsDatabaseDTO>(query.Query,query.Parameters) as List<LogsDatabaseDTO>;
                return result;
        }

        public IEnumerable<LogsDatabaseDTO> GetAllByLOGS_TABLE(string value )
        {
            var query = _query.FirstByLOGS_TABLEQuery(value );

                var result = _unitOfWork.Query<LogsDatabaseDTO>(query.Query,query.Parameters) as List<LogsDatabaseDTO>;
                return result;
        }

        public IEnumerable<LogsDatabaseDTO> GetAllByLOGS_KEY(string value )
        {
            var query = _query.FirstByLOGS_KEYQuery(value );

                var result = _unitOfWork.Query<LogsDatabaseDTO>(query.Query,query.Parameters) as List<LogsDatabaseDTO>;
                return result;
        }

        public IEnumerable<LogsDatabaseDTO> GetAllByLOGS_KEY1(string value )
        {
            var query = _query.FirstByLOGS_KEY1Query(value );

                var result = _unitOfWork.Query<LogsDatabaseDTO>(query.Query,query.Parameters) as List<LogsDatabaseDTO>;
                return result;
        }

        public IEnumerable<LogsDatabaseDTO> GetAllByLOGS_KEY2(string value )
        {
            var query = _query.FirstByLOGS_KEY2Query(value );

                var result = _unitOfWork.Query<LogsDatabaseDTO>(query.Query,query.Parameters) as List<LogsDatabaseDTO>;
                return result;
        }

        public IEnumerable<LogsDatabaseDTO> GetAllByLOGS_KEY3(string value )
        {
            var query = _query.FirstByLOGS_KEY3Query(value );

                var result = _unitOfWork.Query<LogsDatabaseDTO>(query.Query,query.Parameters) as List<LogsDatabaseDTO>;
                return result;
        }

        public IEnumerable<LogsDatabaseDTO> GetAllByLOGS_KEY4(string value )
        {
            var query = _query.FirstByLOGS_KEY4Query(value );

                var result = _unitOfWork.Query<LogsDatabaseDTO>(query.Query,query.Parameters) as List<LogsDatabaseDTO>;
                return result;
        }

        public IEnumerable<LogsDatabaseDTO> GetAllByLOGS_COLUMN(string value )
        {
            var query = _query.FirstByLOGS_COLUMNQuery(value );

                var result = _unitOfWork.Query<LogsDatabaseDTO>(query.Query,query.Parameters) as List<LogsDatabaseDTO>;
                return result;
        }

        public IEnumerable<LogsDatabaseDTO> GetAllByLOGS_BEFORE(string value )
        {
            var query = _query.FirstByLOGS_BEFOREQuery(value );

                var result = _unitOfWork.Query<LogsDatabaseDTO>(query.Query,query.Parameters) as List<LogsDatabaseDTO>;
                return result;
        }

        public IEnumerable<LogsDatabaseDTO> GetAllByLOGS_AFTER(string value )
        {
            var query = _query.FirstByLOGS_AFTERQuery(value );

                var result = _unitOfWork.Query<LogsDatabaseDTO>(query.Query,query.Parameters) as List<LogsDatabaseDTO>;
                return result;
        }

        public IEnumerable<LogsDatabaseDTO> GetAllByLOGS_ACTION(string value )
        {
            var query = _query.FirstByLOGS_ACTIONQuery(value );

                var result = _unitOfWork.Query<LogsDatabaseDTO>(query.Query,query.Parameters) as List<LogsDatabaseDTO>;
                return result;
        }

        public IEnumerable<LogsDatabaseDTO> GetAllByLOGS_DATE(DateTime value )
        {
            var query = _query.FirstByLOGS_DATEQuery(value );

                var result = _unitOfWork.Query<LogsDatabaseDTO>(query.Query,query.Parameters) as List<LogsDatabaseDTO>;
                return result;
        }

        public IEnumerable<LogsDatabaseDTO> GetAllByUSE_ID(int value )
        {
            var query = _query.FirstByUSE_IDQuery(value );

                var result = _unitOfWork.Query<LogsDatabaseDTO>(query.Query,query.Parameters) as List<LogsDatabaseDTO>;
                return result;
        }

        public IEnumerable<LogsDatabaseDTO> GetAllByLOGS_ORIGEM(string value )
        {
            var query = _query.FirstByLOGS_ORIGEMQuery(value );

                var result = _unitOfWork.Query<LogsDatabaseDTO>(query.Query,query.Parameters) as List<LogsDatabaseDTO>;
                return result;
        }

        public IEnumerable<LogsDatabaseDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<LogsDatabaseDTO>(query.Query,query.Parameters) as List<LogsDatabaseDTO>;
                return result;
        }

        public IEnumerable<LogsDatabaseDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<LogsDatabaseDTO>(query.Query,query.Parameters) as List<LogsDatabaseDTO>;
                return result;
        }

        public IEnumerable<LogsDatabaseDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<LogsDatabaseDTO>(query.Query,query.Parameters) as List<LogsDatabaseDTO>;
                return result;
        }

        public IEnumerable<LogsDatabaseDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<LogsDatabaseDTO>(query.Query,query.Parameters) as List<LogsDatabaseDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration