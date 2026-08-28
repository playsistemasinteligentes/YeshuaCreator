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
    public partial class IndicadoresDimencoesReadRepository : IIndicadoresDimencoesReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IIndicadoresDimencoesQueryRead _query;

        public IndicadoresDimencoesReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IIndicadoresDimencoesQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<IndicadoresDimencoesDTO> getIndicadoresDimencoes(ICommandRead command )
         {
            if (command is Command.Read.IndicadoresDimencoesReadCommand c)
                return getIndicadoresDimencoes(c );
            throw new NotImplementedException();
        }
        private DataPagination<IndicadoresDimencoesDTO> getIndicadoresDimencoes(Command.Read.IndicadoresDimencoesReadCommand command )
        {
            var query = _query.IndicadoresDimencoesQuery(command );

                var itens = _unitOfWork.Query<IndicadoresDimencoesDTO>(query.Query,query.Parameters);
                return new DataPagination<IndicadoresDimencoesDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<IndicadoresDimencoesIND_IDDTO> getIndicadoresDimencoesReadFKIND_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<IndicadoresDimencoesIND_IDDTO> lista;
            var query = _query.IndicadoresDimencoesIND_IDQuery(command );

                lista = _unitOfWork.Query<IndicadoresDimencoesIND_IDDTO>(query.Query,query.Parameters) as List<IndicadoresDimencoesIND_IDDTO>;
            return lista;
        }

        public IEnumerable<IndicadoresDimencoesIND_IDDTO> getIndicadoresDimencoesReadFKIND_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getIndicadoresDimencoesReadFKIND_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<IndicadoresDimencoesTenantIDDTO> getIndicadoresDimencoesReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<IndicadoresDimencoesTenantIDDTO> lista;
            var query = _query.IndicadoresDimencoesTenantIDQuery(command );

                lista = _unitOfWork.Query<IndicadoresDimencoesTenantIDDTO>(query.Query,query.Parameters) as List<IndicadoresDimencoesTenantIDDTO>;
            return lista;
        }

        public IEnumerable<IndicadoresDimencoesTenantIDDTO> getIndicadoresDimencoesReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getIndicadoresDimencoesReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<IndicadoresDimencoesUserIdDTO> getIndicadoresDimencoesReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<IndicadoresDimencoesUserIdDTO> lista;
            var query = _query.IndicadoresDimencoesUserIdQuery(command );

                lista = _unitOfWork.Query<IndicadoresDimencoesUserIdDTO>(query.Query,query.Parameters) as List<IndicadoresDimencoesUserIdDTO>;
            return lista;
        }

        public IEnumerable<IndicadoresDimencoesUserIdDTO> getIndicadoresDimencoesReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getIndicadoresDimencoesReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDIM_ID(int value )
        {
            var query = _query.ExistsByDIM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByIND_ID(int value )
        {
            var query = _query.ExistsByIND_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDIM_DESCRICAO(string value )
        {
            var query = _query.ExistsByDIM_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDIM_SQL(string value )
        {
            var query = _query.ExistsByDIM_SQLQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDIM_CONEXAO(string value )
        {
            var query = _query.ExistsByDIM_CONEXAOQuery(value );

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

        public IndicadoresDimencoesDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<IndicadoresDimencoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public IndicadoresDimencoesDTO FirstByDIM_ID(int value )
        {
            var query = _query.FirstByDIM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<IndicadoresDimencoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public IndicadoresDimencoesDTO FirstByIND_ID(int value )
        {
            var query = _query.FirstByIND_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<IndicadoresDimencoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public IndicadoresDimencoesDTO FirstByDIM_DESCRICAO(string value )
        {
            var query = _query.FirstByDIM_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<IndicadoresDimencoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public IndicadoresDimencoesDTO FirstByDIM_SQL(string value )
        {
            var query = _query.FirstByDIM_SQLQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<IndicadoresDimencoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public IndicadoresDimencoesDTO FirstByDIM_CONEXAO(string value )
        {
            var query = _query.FirstByDIM_CONEXAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<IndicadoresDimencoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public IndicadoresDimencoesDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<IndicadoresDimencoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public IndicadoresDimencoesDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<IndicadoresDimencoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public IndicadoresDimencoesDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<IndicadoresDimencoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public IndicadoresDimencoesDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<IndicadoresDimencoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<IndicadoresDimencoesDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<IndicadoresDimencoesDTO>(query.Query,query.Parameters) as List<IndicadoresDimencoesDTO>;
                return result;
        }

        public IEnumerable<IndicadoresDimencoesDTO> GetAllByDIM_ID(int value )
        {
            var query = _query.FirstByDIM_IDQuery(value );

                var result = _unitOfWork.Query<IndicadoresDimencoesDTO>(query.Query,query.Parameters) as List<IndicadoresDimencoesDTO>;
                return result;
        }

        public IEnumerable<IndicadoresDimencoesDTO> GetAllByIND_ID(int value )
        {
            var query = _query.FirstByIND_IDQuery(value );

                var result = _unitOfWork.Query<IndicadoresDimencoesDTO>(query.Query,query.Parameters) as List<IndicadoresDimencoesDTO>;
                return result;
        }

        public IEnumerable<IndicadoresDimencoesDTO> GetAllByDIM_DESCRICAO(string value )
        {
            var query = _query.FirstByDIM_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<IndicadoresDimencoesDTO>(query.Query,query.Parameters) as List<IndicadoresDimencoesDTO>;
                return result;
        }

        public IEnumerable<IndicadoresDimencoesDTO> GetAllByDIM_SQL(string value )
        {
            var query = _query.FirstByDIM_SQLQuery(value );

                var result = _unitOfWork.Query<IndicadoresDimencoesDTO>(query.Query,query.Parameters) as List<IndicadoresDimencoesDTO>;
                return result;
        }

        public IEnumerable<IndicadoresDimencoesDTO> GetAllByDIM_CONEXAO(string value )
        {
            var query = _query.FirstByDIM_CONEXAOQuery(value );

                var result = _unitOfWork.Query<IndicadoresDimencoesDTO>(query.Query,query.Parameters) as List<IndicadoresDimencoesDTO>;
                return result;
        }

        public IEnumerable<IndicadoresDimencoesDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<IndicadoresDimencoesDTO>(query.Query,query.Parameters) as List<IndicadoresDimencoesDTO>;
                return result;
        }

        public IEnumerable<IndicadoresDimencoesDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<IndicadoresDimencoesDTO>(query.Query,query.Parameters) as List<IndicadoresDimencoesDTO>;
                return result;
        }

        public IEnumerable<IndicadoresDimencoesDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<IndicadoresDimencoesDTO>(query.Query,query.Parameters) as List<IndicadoresDimencoesDTO>;
                return result;
        }

        public IEnumerable<IndicadoresDimencoesDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<IndicadoresDimencoesDTO>(query.Query,query.Parameters) as List<IndicadoresDimencoesDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration