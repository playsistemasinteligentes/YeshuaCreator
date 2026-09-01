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
    public partial class IndicadoresPeriodosDimencoesReadRepository : IIndicadoresPeriodosDimencoesReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IIndicadoresPeriodosDimencoesQueryRead _query;

        public IndicadoresPeriodosDimencoesReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IIndicadoresPeriodosDimencoesQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetIndicadoresPeriodosDimencoesCustom(Command.Read.IndicadoresPeriodosDimencoesReadCommand command, ref DataPagination<IndicadoresPeriodosDimencoesDTO> result, ref bool handled);

        public DataPagination<IndicadoresPeriodosDimencoesDTO> getIndicadoresPeriodosDimencoes(ICommandRead command )
         {
            if (command is Command.Read.IndicadoresPeriodosDimencoesReadCommand c)
                return getIndicadoresPeriodosDimencoes(c );
            throw new NotImplementedException();
        }
        private DataPagination<IndicadoresPeriodosDimencoesDTO> getIndicadoresPeriodosDimencoes(Command.Read.IndicadoresPeriodosDimencoesReadCommand command )
        {
            DataPagination<IndicadoresPeriodosDimencoesDTO> customResult = null;
            var customHandled = false;
            TryGetIndicadoresPeriodosDimencoesCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.IndicadoresPeriodosDimencoesQuery(command );

                var itens = _unitOfWork.Query<IndicadoresPeriodosDimencoesDTO>(query.Query,query.Parameters);
                return new DataPagination<IndicadoresPeriodosDimencoesDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<IndicadoresPeriodosDimencoesIND_IDDTO> getIndicadoresPeriodosDimencoesReadFKIND_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<IndicadoresPeriodosDimencoesIND_IDDTO> lista;
            var query = _query.IndicadoresPeriodosDimencoesIND_IDQuery(command );

                lista = _unitOfWork.Query<IndicadoresPeriodosDimencoesIND_IDDTO>(query.Query,query.Parameters) as List<IndicadoresPeriodosDimencoesIND_IDDTO>;
            return lista;
        }

        public IEnumerable<IndicadoresPeriodosDimencoesIND_IDDTO> getIndicadoresPeriodosDimencoesReadFKIND_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getIndicadoresPeriodosDimencoesReadFKIND_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<IndicadoresPeriodosDimencoesTenantIDDTO> getIndicadoresPeriodosDimencoesReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<IndicadoresPeriodosDimencoesTenantIDDTO> lista;
            var query = _query.IndicadoresPeriodosDimencoesTenantIDQuery(command );

                lista = _unitOfWork.Query<IndicadoresPeriodosDimencoesTenantIDDTO>(query.Query,query.Parameters) as List<IndicadoresPeriodosDimencoesTenantIDDTO>;
            return lista;
        }

        public IEnumerable<IndicadoresPeriodosDimencoesTenantIDDTO> getIndicadoresPeriodosDimencoesReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getIndicadoresPeriodosDimencoesReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<IndicadoresPeriodosDimencoesUserIdDTO> getIndicadoresPeriodosDimencoesReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<IndicadoresPeriodosDimencoesUserIdDTO> lista;
            var query = _query.IndicadoresPeriodosDimencoesUserIdQuery(command );

                lista = _unitOfWork.Query<IndicadoresPeriodosDimencoesUserIdDTO>(query.Query,query.Parameters) as List<IndicadoresPeriodosDimencoesUserIdDTO>;
            return lista;
        }

        public IEnumerable<IndicadoresPeriodosDimencoesUserIdDTO> getIndicadoresPeriodosDimencoesReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getIndicadoresPeriodosDimencoesReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPER_ID(string value )
        {
            var query = _query.ExistsByPER_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByIND_ID(int value )
        {
            var query = _query.ExistsByIND_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDIM_ID(int value )
        {
            var query = _query.ExistsByDIM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPER_DESCRICAO(string value )
        {
            var query = _query.ExistsByPER_DESCRICAOQuery(value );

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

        public IndicadoresPeriodosDimencoesDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<IndicadoresPeriodosDimencoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public IndicadoresPeriodosDimencoesDTO FirstByPER_ID(string value )
        {
            var query = _query.FirstByPER_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<IndicadoresPeriodosDimencoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public IndicadoresPeriodosDimencoesDTO FirstByIND_ID(int value )
        {
            var query = _query.FirstByIND_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<IndicadoresPeriodosDimencoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public IndicadoresPeriodosDimencoesDTO FirstByDIM_ID(int value )
        {
            var query = _query.FirstByDIM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<IndicadoresPeriodosDimencoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public IndicadoresPeriodosDimencoesDTO FirstByPER_DESCRICAO(string value )
        {
            var query = _query.FirstByPER_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<IndicadoresPeriodosDimencoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public IndicadoresPeriodosDimencoesDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<IndicadoresPeriodosDimencoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public IndicadoresPeriodosDimencoesDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<IndicadoresPeriodosDimencoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public IndicadoresPeriodosDimencoesDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<IndicadoresPeriodosDimencoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public IndicadoresPeriodosDimencoesDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<IndicadoresPeriodosDimencoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<IndicadoresPeriodosDimencoesDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<IndicadoresPeriodosDimencoesDTO>(query.Query,query.Parameters) as List<IndicadoresPeriodosDimencoesDTO>;
                return result;
        }

        public IEnumerable<IndicadoresPeriodosDimencoesDTO> GetAllByPER_ID(string value )
        {
            var query = _query.FirstByPER_IDQuery(value );

                var result = _unitOfWork.Query<IndicadoresPeriodosDimencoesDTO>(query.Query,query.Parameters) as List<IndicadoresPeriodosDimencoesDTO>;
                return result;
        }

        public IEnumerable<IndicadoresPeriodosDimencoesDTO> GetAllByIND_ID(int value )
        {
            var query = _query.FirstByIND_IDQuery(value );

                var result = _unitOfWork.Query<IndicadoresPeriodosDimencoesDTO>(query.Query,query.Parameters) as List<IndicadoresPeriodosDimencoesDTO>;
                return result;
        }

        public IEnumerable<IndicadoresPeriodosDimencoesDTO> GetAllByDIM_ID(int value )
        {
            var query = _query.FirstByDIM_IDQuery(value );

                var result = _unitOfWork.Query<IndicadoresPeriodosDimencoesDTO>(query.Query,query.Parameters) as List<IndicadoresPeriodosDimencoesDTO>;
                return result;
        }

        public IEnumerable<IndicadoresPeriodosDimencoesDTO> GetAllByPER_DESCRICAO(string value )
        {
            var query = _query.FirstByPER_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<IndicadoresPeriodosDimencoesDTO>(query.Query,query.Parameters) as List<IndicadoresPeriodosDimencoesDTO>;
                return result;
        }

        public IEnumerable<IndicadoresPeriodosDimencoesDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<IndicadoresPeriodosDimencoesDTO>(query.Query,query.Parameters) as List<IndicadoresPeriodosDimencoesDTO>;
                return result;
        }

        public IEnumerable<IndicadoresPeriodosDimencoesDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<IndicadoresPeriodosDimencoesDTO>(query.Query,query.Parameters) as List<IndicadoresPeriodosDimencoesDTO>;
                return result;
        }

        public IEnumerable<IndicadoresPeriodosDimencoesDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<IndicadoresPeriodosDimencoesDTO>(query.Query,query.Parameters) as List<IndicadoresPeriodosDimencoesDTO>;
                return result;
        }

        public IEnumerable<IndicadoresPeriodosDimencoesDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<IndicadoresPeriodosDimencoesDTO>(query.Query,query.Parameters) as List<IndicadoresPeriodosDimencoesDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration