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
    public partial class TurmaReadRepository : ITurmaReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ITurmaQueryRead _query;

        public TurmaReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ITurmaQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<TurmaDTO> getTurma(ICommandRead command )
         {
            if (command is Command.Read.TurmaReadCommand c)
                return getTurma(c );
            throw new NotImplementedException();
        }
        private DataPagination<TurmaDTO> getTurma(Command.Read.TurmaReadCommand command )
        {
            var query = _query.TurmaQuery(command );

                var itens = _unitOfWork.Query<TurmaDTO>(query.Query,query.Parameters);
                return new DataPagination<TurmaDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<TurmaTenantIDDTO> getTurmaReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TurmaTenantIDDTO> lista;
            var query = _query.TurmaTenantIDQuery(command );

                lista = _unitOfWork.Query<TurmaTenantIDDTO>(query.Query,query.Parameters) as List<TurmaTenantIDDTO>;
            return lista;
        }

        public IEnumerable<TurmaTenantIDDTO> getTurmaReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTurmaReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<TurmaUserIdDTO> getTurmaReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TurmaUserIdDTO> lista;
            var query = _query.TurmaUserIdQuery(command );

                lista = _unitOfWork.Query<TurmaUserIdDTO>(query.Query,query.Parameters) as List<TurmaUserIdDTO>;
            return lista;
        }

        public IEnumerable<TurmaUserIdDTO> getTurmaReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTurmaReadFKUserId(c );
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

        public bool ExistsByTURM_HORA_INI_DIA1(DateTime value )
        {
            var query = _query.ExistsByTURM_HORA_INI_DIA1Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTURM_HORA_FIM_DIA1(DateTime value )
        {
            var query = _query.ExistsByTURM_HORA_FIM_DIA1Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTURM_HORA_INI_DIA2(DateTime value )
        {
            var query = _query.ExistsByTURM_HORA_INI_DIA2Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTURM_HORA_FIM_DIA2(DateTime value )
        {
            var query = _query.ExistsByTURM_HORA_FIM_DIA2Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTURM_HORA_INI_DIA3(DateTime value )
        {
            var query = _query.ExistsByTURM_HORA_INI_DIA3Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTURM_HORA_FIM_DIA3(DateTime value )
        {
            var query = _query.ExistsByTURM_HORA_FIM_DIA3Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTURM_HORA_INI_DIA4(DateTime value )
        {
            var query = _query.ExistsByTURM_HORA_INI_DIA4Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTURM_HORA_FIM_DIA4(DateTime value )
        {
            var query = _query.ExistsByTURM_HORA_FIM_DIA4Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTURM_HORA_INI_DIA5(DateTime value )
        {
            var query = _query.ExistsByTURM_HORA_INI_DIA5Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTURM_HORA_FIM_DIA5(DateTime value )
        {
            var query = _query.ExistsByTURM_HORA_FIM_DIA5Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTURM_HORA_INI_DIA6(DateTime value )
        {
            var query = _query.ExistsByTURM_HORA_INI_DIA6Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTURM_HORA_FIM_DIA6(DateTime value )
        {
            var query = _query.ExistsByTURM_HORA_FIM_DIA6Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTURM_HORA_INI_DIA7(DateTime value )
        {
            var query = _query.ExistsByTURM_HORA_INI_DIA7Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTURM_HORA_FIM_DIA7(DateTime value )
        {
            var query = _query.ExistsByTURM_HORA_FIM_DIA7Query(value );

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

        public TurmaDTO FirstById(string value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TurmaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TurmaDTO FirstByDescricao(string value )
        {
            var query = _query.FirstByDescricaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TurmaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TurmaDTO FirstByTURM_HORA_INI_DIA1(DateTime value )
        {
            var query = _query.FirstByTURM_HORA_INI_DIA1Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<TurmaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TurmaDTO FirstByTURM_HORA_FIM_DIA1(DateTime value )
        {
            var query = _query.FirstByTURM_HORA_FIM_DIA1Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<TurmaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TurmaDTO FirstByTURM_HORA_INI_DIA2(DateTime value )
        {
            var query = _query.FirstByTURM_HORA_INI_DIA2Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<TurmaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TurmaDTO FirstByTURM_HORA_FIM_DIA2(DateTime value )
        {
            var query = _query.FirstByTURM_HORA_FIM_DIA2Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<TurmaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TurmaDTO FirstByTURM_HORA_INI_DIA3(DateTime value )
        {
            var query = _query.FirstByTURM_HORA_INI_DIA3Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<TurmaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TurmaDTO FirstByTURM_HORA_FIM_DIA3(DateTime value )
        {
            var query = _query.FirstByTURM_HORA_FIM_DIA3Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<TurmaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TurmaDTO FirstByTURM_HORA_INI_DIA4(DateTime value )
        {
            var query = _query.FirstByTURM_HORA_INI_DIA4Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<TurmaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TurmaDTO FirstByTURM_HORA_FIM_DIA4(DateTime value )
        {
            var query = _query.FirstByTURM_HORA_FIM_DIA4Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<TurmaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TurmaDTO FirstByTURM_HORA_INI_DIA5(DateTime value )
        {
            var query = _query.FirstByTURM_HORA_INI_DIA5Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<TurmaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TurmaDTO FirstByTURM_HORA_FIM_DIA5(DateTime value )
        {
            var query = _query.FirstByTURM_HORA_FIM_DIA5Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<TurmaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TurmaDTO FirstByTURM_HORA_INI_DIA6(DateTime value )
        {
            var query = _query.FirstByTURM_HORA_INI_DIA6Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<TurmaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TurmaDTO FirstByTURM_HORA_FIM_DIA6(DateTime value )
        {
            var query = _query.FirstByTURM_HORA_FIM_DIA6Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<TurmaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TurmaDTO FirstByTURM_HORA_INI_DIA7(DateTime value )
        {
            var query = _query.FirstByTURM_HORA_INI_DIA7Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<TurmaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TurmaDTO FirstByTURM_HORA_FIM_DIA7(DateTime value )
        {
            var query = _query.FirstByTURM_HORA_FIM_DIA7Query(value );

                var result = _unitOfWork.QueryFirstOrDefault<TurmaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TurmaDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TurmaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TurmaDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TurmaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TurmaDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TurmaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TurmaDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TurmaDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<TurmaDTO> GetAllById(string value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<TurmaDTO>(query.Query,query.Parameters) as List<TurmaDTO>;
                return result;
        }

        public IEnumerable<TurmaDTO> GetAllByDescricao(string value )
        {
            var query = _query.FirstByDescricaoQuery(value );

                var result = _unitOfWork.Query<TurmaDTO>(query.Query,query.Parameters) as List<TurmaDTO>;
                return result;
        }

        public IEnumerable<TurmaDTO> GetAllByTURM_HORA_INI_DIA1(DateTime value )
        {
            var query = _query.FirstByTURM_HORA_INI_DIA1Query(value );

                var result = _unitOfWork.Query<TurmaDTO>(query.Query,query.Parameters) as List<TurmaDTO>;
                return result;
        }

        public IEnumerable<TurmaDTO> GetAllByTURM_HORA_FIM_DIA1(DateTime value )
        {
            var query = _query.FirstByTURM_HORA_FIM_DIA1Query(value );

                var result = _unitOfWork.Query<TurmaDTO>(query.Query,query.Parameters) as List<TurmaDTO>;
                return result;
        }

        public IEnumerable<TurmaDTO> GetAllByTURM_HORA_INI_DIA2(DateTime value )
        {
            var query = _query.FirstByTURM_HORA_INI_DIA2Query(value );

                var result = _unitOfWork.Query<TurmaDTO>(query.Query,query.Parameters) as List<TurmaDTO>;
                return result;
        }

        public IEnumerable<TurmaDTO> GetAllByTURM_HORA_FIM_DIA2(DateTime value )
        {
            var query = _query.FirstByTURM_HORA_FIM_DIA2Query(value );

                var result = _unitOfWork.Query<TurmaDTO>(query.Query,query.Parameters) as List<TurmaDTO>;
                return result;
        }

        public IEnumerable<TurmaDTO> GetAllByTURM_HORA_INI_DIA3(DateTime value )
        {
            var query = _query.FirstByTURM_HORA_INI_DIA3Query(value );

                var result = _unitOfWork.Query<TurmaDTO>(query.Query,query.Parameters) as List<TurmaDTO>;
                return result;
        }

        public IEnumerable<TurmaDTO> GetAllByTURM_HORA_FIM_DIA3(DateTime value )
        {
            var query = _query.FirstByTURM_HORA_FIM_DIA3Query(value );

                var result = _unitOfWork.Query<TurmaDTO>(query.Query,query.Parameters) as List<TurmaDTO>;
                return result;
        }

        public IEnumerable<TurmaDTO> GetAllByTURM_HORA_INI_DIA4(DateTime value )
        {
            var query = _query.FirstByTURM_HORA_INI_DIA4Query(value );

                var result = _unitOfWork.Query<TurmaDTO>(query.Query,query.Parameters) as List<TurmaDTO>;
                return result;
        }

        public IEnumerable<TurmaDTO> GetAllByTURM_HORA_FIM_DIA4(DateTime value )
        {
            var query = _query.FirstByTURM_HORA_FIM_DIA4Query(value );

                var result = _unitOfWork.Query<TurmaDTO>(query.Query,query.Parameters) as List<TurmaDTO>;
                return result;
        }

        public IEnumerable<TurmaDTO> GetAllByTURM_HORA_INI_DIA5(DateTime value )
        {
            var query = _query.FirstByTURM_HORA_INI_DIA5Query(value );

                var result = _unitOfWork.Query<TurmaDTO>(query.Query,query.Parameters) as List<TurmaDTO>;
                return result;
        }

        public IEnumerable<TurmaDTO> GetAllByTURM_HORA_FIM_DIA5(DateTime value )
        {
            var query = _query.FirstByTURM_HORA_FIM_DIA5Query(value );

                var result = _unitOfWork.Query<TurmaDTO>(query.Query,query.Parameters) as List<TurmaDTO>;
                return result;
        }

        public IEnumerable<TurmaDTO> GetAllByTURM_HORA_INI_DIA6(DateTime value )
        {
            var query = _query.FirstByTURM_HORA_INI_DIA6Query(value );

                var result = _unitOfWork.Query<TurmaDTO>(query.Query,query.Parameters) as List<TurmaDTO>;
                return result;
        }

        public IEnumerable<TurmaDTO> GetAllByTURM_HORA_FIM_DIA6(DateTime value )
        {
            var query = _query.FirstByTURM_HORA_FIM_DIA6Query(value );

                var result = _unitOfWork.Query<TurmaDTO>(query.Query,query.Parameters) as List<TurmaDTO>;
                return result;
        }

        public IEnumerable<TurmaDTO> GetAllByTURM_HORA_INI_DIA7(DateTime value )
        {
            var query = _query.FirstByTURM_HORA_INI_DIA7Query(value );

                var result = _unitOfWork.Query<TurmaDTO>(query.Query,query.Parameters) as List<TurmaDTO>;
                return result;
        }

        public IEnumerable<TurmaDTO> GetAllByTURM_HORA_FIM_DIA7(DateTime value )
        {
            var query = _query.FirstByTURM_HORA_FIM_DIA7Query(value );

                var result = _unitOfWork.Query<TurmaDTO>(query.Query,query.Parameters) as List<TurmaDTO>;
                return result;
        }

        public IEnumerable<TurmaDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<TurmaDTO>(query.Query,query.Parameters) as List<TurmaDTO>;
                return result;
        }

        public IEnumerable<TurmaDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<TurmaDTO>(query.Query,query.Parameters) as List<TurmaDTO>;
                return result;
        }

        public IEnumerable<TurmaDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<TurmaDTO>(query.Query,query.Parameters) as List<TurmaDTO>;
                return result;
        }

        public IEnumerable<TurmaDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<TurmaDTO>(query.Query,query.Parameters) as List<TurmaDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration