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
    public partial class TurnoReadRepository : ITurnoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ITurnoQueryRead _query;

        public TurnoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ITurnoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetTurnoCustom(Command.Read.TurnoReadCommand command, ref DataPagination<TurnoDTO> result, ref bool handled);

        public DataPagination<TurnoDTO> getTurno(ICommandRead command )
         {
            if (command is Command.Read.TurnoReadCommand c)
                return getTurno(c );
            throw new NotImplementedException();
        }
        private DataPagination<TurnoDTO> getTurno(Command.Read.TurnoReadCommand command )
        {
            DataPagination<TurnoDTO> customResult = null;
            var customHandled = false;
            TryGetTurnoCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.TurnoQuery(command );

                var itens = _unitOfWork.Query<TurnoDTO>(query.Query,query.Parameters);
                return new DataPagination<TurnoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<TurnoTenantIDDTO> getTurnoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TurnoTenantIDDTO> lista;
            var query = _query.TurnoTenantIDQuery(command );

                lista = _unitOfWork.Query<TurnoTenantIDDTO>(query.Query,query.Parameters) as List<TurnoTenantIDDTO>;
            return lista;
        }

        public IEnumerable<TurnoTenantIDDTO> getTurnoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTurnoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<TurnoUserIdDTO> getTurnoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TurnoUserIdDTO> lista;
            var query = _query.TurnoUserIdQuery(command );

                lista = _unitOfWork.Query<TurnoUserIdDTO>(query.Query,query.Parameters) as List<TurnoUserIdDTO>;
            return lista;
        }

        public IEnumerable<TurnoUserIdDTO> getTurnoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTurnoReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(string value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDescricao(string value )
        {
            var query = _query.ExistsByDescricaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTURN_PRIORIDADE(int value )
        {
            var query = _query.ExistsByTURN_PRIORIDADEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTURN_HORA_INI_DIA1(DateTime value )
        {
            var query = _query.ExistsByTURN_HORA_INI_DIA1Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTURN_HORA_FIM_DIA1(DateTime value )
        {
            var query = _query.ExistsByTURN_HORA_FIM_DIA1Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTURN_HORA_INI_DIA2(DateTime value )
        {
            var query = _query.ExistsByTURN_HORA_INI_DIA2Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTURN_HORA_FIM_DIA2(DateTime value )
        {
            var query = _query.ExistsByTURN_HORA_FIM_DIA2Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTURN_HORA_INI_DIA3(DateTime value )
        {
            var query = _query.ExistsByTURN_HORA_INI_DIA3Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTURN_HORA_FIM_DIA3(DateTime value )
        {
            var query = _query.ExistsByTURN_HORA_FIM_DIA3Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTURN_HORA_INI_DIA4(DateTime value )
        {
            var query = _query.ExistsByTURN_HORA_INI_DIA4Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTURN_HORA_FIM_DIA4(DateTime value )
        {
            var query = _query.ExistsByTURN_HORA_FIM_DIA4Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTURN_HORA_INI_DIA5(DateTime value )
        {
            var query = _query.ExistsByTURN_HORA_INI_DIA5Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTURN_HORA_FIM_DIA5(DateTime value )
        {
            var query = _query.ExistsByTURN_HORA_FIM_DIA5Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTURN_HORA_INI_DIA6(DateTime value )
        {
            var query = _query.ExistsByTURN_HORA_INI_DIA6Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTURN_HORA_FIM_DIA6(DateTime value )
        {
            var query = _query.ExistsByTURN_HORA_FIM_DIA6Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTURN_HORA_INI_DIA7(DateTime value )
        {
            var query = _query.ExistsByTURN_HORA_INI_DIA7Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTURN_HORA_FIM_DIA7(DateTime value )
        {
            var query = _query.ExistsByTURN_HORA_FIM_DIA7Query(value );

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

        public TurnoDTO FirstById(string value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TurnoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TurnoDTO FirstByDescricao(string value )
        {
            var query = _query.FirstByDescricaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TurnoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TurnoDTO FirstByTURN_PRIORIDADE(int value )
        {
            var query = _query.FirstByTURN_PRIORIDADEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TurnoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TurnoDTO FirstByTURN_HORA_INI_DIA1(DateTime value )
        {
            var query = _query.FirstByTURN_HORA_INI_DIA1Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<TurnoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TurnoDTO FirstByTURN_HORA_FIM_DIA1(DateTime value )
        {
            var query = _query.FirstByTURN_HORA_FIM_DIA1Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<TurnoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TurnoDTO FirstByTURN_HORA_INI_DIA2(DateTime value )
        {
            var query = _query.FirstByTURN_HORA_INI_DIA2Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<TurnoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TurnoDTO FirstByTURN_HORA_FIM_DIA2(DateTime value )
        {
            var query = _query.FirstByTURN_HORA_FIM_DIA2Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<TurnoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TurnoDTO FirstByTURN_HORA_INI_DIA3(DateTime value )
        {
            var query = _query.FirstByTURN_HORA_INI_DIA3Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<TurnoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TurnoDTO FirstByTURN_HORA_FIM_DIA3(DateTime value )
        {
            var query = _query.FirstByTURN_HORA_FIM_DIA3Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<TurnoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TurnoDTO FirstByTURN_HORA_INI_DIA4(DateTime value )
        {
            var query = _query.FirstByTURN_HORA_INI_DIA4Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<TurnoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TurnoDTO FirstByTURN_HORA_FIM_DIA4(DateTime value )
        {
            var query = _query.FirstByTURN_HORA_FIM_DIA4Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<TurnoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TurnoDTO FirstByTURN_HORA_INI_DIA5(DateTime value )
        {
            var query = _query.FirstByTURN_HORA_INI_DIA5Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<TurnoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TurnoDTO FirstByTURN_HORA_FIM_DIA5(DateTime value )
        {
            var query = _query.FirstByTURN_HORA_FIM_DIA5Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<TurnoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TurnoDTO FirstByTURN_HORA_INI_DIA6(DateTime value )
        {
            var query = _query.FirstByTURN_HORA_INI_DIA6Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<TurnoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TurnoDTO FirstByTURN_HORA_FIM_DIA6(DateTime value )
        {
            var query = _query.FirstByTURN_HORA_FIM_DIA6Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<TurnoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TurnoDTO FirstByTURN_HORA_INI_DIA7(DateTime value )
        {
            var query = _query.FirstByTURN_HORA_INI_DIA7Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<TurnoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TurnoDTO FirstByTURN_HORA_FIM_DIA7(DateTime value )
        {
            var query = _query.FirstByTURN_HORA_FIM_DIA7Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<TurnoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TurnoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TurnoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TurnoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TurnoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TurnoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TurnoDTO>(query.Query, query.Parameters);
                return result;
        }

        public TurnoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TurnoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<TurnoDTO> GetAllById(string value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<TurnoDTO>(query.Query,query.Parameters) as List<TurnoDTO>;
                return result;
        }

        public IEnumerable<TurnoDTO> GetAllByDescricao(string value )
        {
            var query = _query.FirstByDescricaoQuery(value );

                var result = _unitOfWork.Query<TurnoDTO>(query.Query,query.Parameters) as List<TurnoDTO>;
                return result;
        }

        public IEnumerable<TurnoDTO> GetAllByTURN_PRIORIDADE(int value )
        {
            var query = _query.FirstByTURN_PRIORIDADEQuery(value );

                var result = _unitOfWork.Query<TurnoDTO>(query.Query,query.Parameters) as List<TurnoDTO>;
                return result;
        }

        public IEnumerable<TurnoDTO> GetAllByTURN_HORA_INI_DIA1(DateTime value )
        {
            var query = _query.FirstByTURN_HORA_INI_DIA1Query(value );

                var result = _unitOfWork.Query<TurnoDTO>(query.Query,query.Parameters) as List<TurnoDTO>;
                return result;
        }

        public IEnumerable<TurnoDTO> GetAllByTURN_HORA_FIM_DIA1(DateTime value )
        {
            var query = _query.FirstByTURN_HORA_FIM_DIA1Query(value );

                var result = _unitOfWork.Query<TurnoDTO>(query.Query,query.Parameters) as List<TurnoDTO>;
                return result;
        }

        public IEnumerable<TurnoDTO> GetAllByTURN_HORA_INI_DIA2(DateTime value )
        {
            var query = _query.FirstByTURN_HORA_INI_DIA2Query(value );

                var result = _unitOfWork.Query<TurnoDTO>(query.Query,query.Parameters) as List<TurnoDTO>;
                return result;
        }

        public IEnumerable<TurnoDTO> GetAllByTURN_HORA_FIM_DIA2(DateTime value )
        {
            var query = _query.FirstByTURN_HORA_FIM_DIA2Query(value );

                var result = _unitOfWork.Query<TurnoDTO>(query.Query,query.Parameters) as List<TurnoDTO>;
                return result;
        }

        public IEnumerable<TurnoDTO> GetAllByTURN_HORA_INI_DIA3(DateTime value )
        {
            var query = _query.FirstByTURN_HORA_INI_DIA3Query(value );

                var result = _unitOfWork.Query<TurnoDTO>(query.Query,query.Parameters) as List<TurnoDTO>;
                return result;
        }

        public IEnumerable<TurnoDTO> GetAllByTURN_HORA_FIM_DIA3(DateTime value )
        {
            var query = _query.FirstByTURN_HORA_FIM_DIA3Query(value );

                var result = _unitOfWork.Query<TurnoDTO>(query.Query,query.Parameters) as List<TurnoDTO>;
                return result;
        }

        public IEnumerable<TurnoDTO> GetAllByTURN_HORA_INI_DIA4(DateTime value )
        {
            var query = _query.FirstByTURN_HORA_INI_DIA4Query(value );

                var result = _unitOfWork.Query<TurnoDTO>(query.Query,query.Parameters) as List<TurnoDTO>;
                return result;
        }

        public IEnumerable<TurnoDTO> GetAllByTURN_HORA_FIM_DIA4(DateTime value )
        {
            var query = _query.FirstByTURN_HORA_FIM_DIA4Query(value );

                var result = _unitOfWork.Query<TurnoDTO>(query.Query,query.Parameters) as List<TurnoDTO>;
                return result;
        }

        public IEnumerable<TurnoDTO> GetAllByTURN_HORA_INI_DIA5(DateTime value )
        {
            var query = _query.FirstByTURN_HORA_INI_DIA5Query(value );

                var result = _unitOfWork.Query<TurnoDTO>(query.Query,query.Parameters) as List<TurnoDTO>;
                return result;
        }

        public IEnumerable<TurnoDTO> GetAllByTURN_HORA_FIM_DIA5(DateTime value )
        {
            var query = _query.FirstByTURN_HORA_FIM_DIA5Query(value );

                var result = _unitOfWork.Query<TurnoDTO>(query.Query,query.Parameters) as List<TurnoDTO>;
                return result;
        }

        public IEnumerable<TurnoDTO> GetAllByTURN_HORA_INI_DIA6(DateTime value )
        {
            var query = _query.FirstByTURN_HORA_INI_DIA6Query(value );

                var result = _unitOfWork.Query<TurnoDTO>(query.Query,query.Parameters) as List<TurnoDTO>;
                return result;
        }

        public IEnumerable<TurnoDTO> GetAllByTURN_HORA_FIM_DIA6(DateTime value )
        {
            var query = _query.FirstByTURN_HORA_FIM_DIA6Query(value );

                var result = _unitOfWork.Query<TurnoDTO>(query.Query,query.Parameters) as List<TurnoDTO>;
                return result;
        }

        public IEnumerable<TurnoDTO> GetAllByTURN_HORA_INI_DIA7(DateTime value )
        {
            var query = _query.FirstByTURN_HORA_INI_DIA7Query(value );

                var result = _unitOfWork.Query<TurnoDTO>(query.Query,query.Parameters) as List<TurnoDTO>;
                return result;
        }

        public IEnumerable<TurnoDTO> GetAllByTURN_HORA_FIM_DIA7(DateTime value )
        {
            var query = _query.FirstByTURN_HORA_FIM_DIA7Query(value );

                var result = _unitOfWork.Query<TurnoDTO>(query.Query,query.Parameters) as List<TurnoDTO>;
                return result;
        }

        public IEnumerable<TurnoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<TurnoDTO>(query.Query,query.Parameters) as List<TurnoDTO>;
                return result;
        }

        public IEnumerable<TurnoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<TurnoDTO>(query.Query,query.Parameters) as List<TurnoDTO>;
                return result;
        }

        public IEnumerable<TurnoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<TurnoDTO>(query.Query,query.Parameters) as List<TurnoDTO>;
                return result;
        }

        public IEnumerable<TurnoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<TurnoDTO>(query.Query,query.Parameters) as List<TurnoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration