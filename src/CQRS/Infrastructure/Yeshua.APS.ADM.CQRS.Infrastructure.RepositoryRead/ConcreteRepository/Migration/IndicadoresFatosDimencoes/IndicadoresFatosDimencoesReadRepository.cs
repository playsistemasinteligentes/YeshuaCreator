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
    public partial class IndicadoresFatosDimencoesReadRepository : IIndicadoresFatosDimencoesReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IIndicadoresFatosDimencoesQueryRead _query;

        public IndicadoresFatosDimencoesReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IIndicadoresFatosDimencoesQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetIndicadoresFatosDimencoesCustom(Command.Read.IndicadoresFatosDimencoesReadCommand command, ref DataPagination<IndicadoresFatosDimencoesDTO> result, ref bool handled);

        public DataPagination<IndicadoresFatosDimencoesDTO> getIndicadoresFatosDimencoes(ICommandRead command )
         {
            if (command is Command.Read.IndicadoresFatosDimencoesReadCommand c)
                return getIndicadoresFatosDimencoes(c );
            throw new NotImplementedException();
        }
        private DataPagination<IndicadoresFatosDimencoesDTO> getIndicadoresFatosDimencoes(Command.Read.IndicadoresFatosDimencoesReadCommand command )
        {
            DataPagination<IndicadoresFatosDimencoesDTO> customResult = null;
            var customHandled = false;
            TryGetIndicadoresFatosDimencoesCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.IndicadoresFatosDimencoesQuery(command );

                var itens = _unitOfWork.Query<IndicadoresFatosDimencoesDTO>(query.Query,query.Parameters);
                return new DataPagination<IndicadoresFatosDimencoesDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<IndicadoresFatosDimencoesIND_IDDTO> getIndicadoresFatosDimencoesReadFKIND_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<IndicadoresFatosDimencoesIND_IDDTO> lista;
            var query = _query.IndicadoresFatosDimencoesIND_IDQuery(command );

                lista = _unitOfWork.Query<IndicadoresFatosDimencoesIND_IDDTO>(query.Query,query.Parameters) as List<IndicadoresFatosDimencoesIND_IDDTO>;
            return lista;
        }

        public IEnumerable<IndicadoresFatosDimencoesIND_IDDTO> getIndicadoresFatosDimencoesReadFKIND_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getIndicadoresFatosDimencoesReadFKIND_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<IndicadoresFatosDimencoesTenantIDDTO> getIndicadoresFatosDimencoesReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<IndicadoresFatosDimencoesTenantIDDTO> lista;
            var query = _query.IndicadoresFatosDimencoesTenantIDQuery(command );

                lista = _unitOfWork.Query<IndicadoresFatosDimencoesTenantIDDTO>(query.Query,query.Parameters) as List<IndicadoresFatosDimencoesTenantIDDTO>;
            return lista;
        }

        public IEnumerable<IndicadoresFatosDimencoesTenantIDDTO> getIndicadoresFatosDimencoesReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getIndicadoresFatosDimencoesReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<IndicadoresFatosDimencoesUserIdDTO> getIndicadoresFatosDimencoesReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<IndicadoresFatosDimencoesUserIdDTO> lista;
            var query = _query.IndicadoresFatosDimencoesUserIdQuery(command );

                lista = _unitOfWork.Query<IndicadoresFatosDimencoesUserIdDTO>(query.Query,query.Parameters) as List<IndicadoresFatosDimencoesUserIdDTO>;
            return lista;
        }

        public IEnumerable<IndicadoresFatosDimencoesUserIdDTO> getIndicadoresFatosDimencoesReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getIndicadoresFatosDimencoesReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFAT_ID(string value )
        {
            var query = _query.ExistsByFAT_IDQuery(value );

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

        public bool ExistsByFAT_DESCRICAO(string value )
        {
            var query = _query.ExistsByFAT_DESCRICAOQuery(value );

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

        public IndicadoresFatosDimencoesDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<IndicadoresFatosDimencoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public IndicadoresFatosDimencoesDTO FirstByFAT_ID(string value )
        {
            var query = _query.FirstByFAT_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<IndicadoresFatosDimencoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public IndicadoresFatosDimencoesDTO FirstByIND_ID(int value )
        {
            var query = _query.FirstByIND_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<IndicadoresFatosDimencoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public IndicadoresFatosDimencoesDTO FirstByDIM_ID(int value )
        {
            var query = _query.FirstByDIM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<IndicadoresFatosDimencoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public IndicadoresFatosDimencoesDTO FirstByFAT_DESCRICAO(string value )
        {
            var query = _query.FirstByFAT_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<IndicadoresFatosDimencoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public IndicadoresFatosDimencoesDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<IndicadoresFatosDimencoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public IndicadoresFatosDimencoesDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<IndicadoresFatosDimencoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public IndicadoresFatosDimencoesDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<IndicadoresFatosDimencoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public IndicadoresFatosDimencoesDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<IndicadoresFatosDimencoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<IndicadoresFatosDimencoesDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<IndicadoresFatosDimencoesDTO>(query.Query,query.Parameters) as List<IndicadoresFatosDimencoesDTO>;
                return result;
        }

        public IEnumerable<IndicadoresFatosDimencoesDTO> GetAllByFAT_ID(string value )
        {
            var query = _query.FirstByFAT_IDQuery(value );

                var result = _unitOfWork.Query<IndicadoresFatosDimencoesDTO>(query.Query,query.Parameters) as List<IndicadoresFatosDimencoesDTO>;
                return result;
        }

        public IEnumerable<IndicadoresFatosDimencoesDTO> GetAllByIND_ID(int value )
        {
            var query = _query.FirstByIND_IDQuery(value );

                var result = _unitOfWork.Query<IndicadoresFatosDimencoesDTO>(query.Query,query.Parameters) as List<IndicadoresFatosDimencoesDTO>;
                return result;
        }

        public IEnumerable<IndicadoresFatosDimencoesDTO> GetAllByDIM_ID(int value )
        {
            var query = _query.FirstByDIM_IDQuery(value );

                var result = _unitOfWork.Query<IndicadoresFatosDimencoesDTO>(query.Query,query.Parameters) as List<IndicadoresFatosDimencoesDTO>;
                return result;
        }

        public IEnumerable<IndicadoresFatosDimencoesDTO> GetAllByFAT_DESCRICAO(string value )
        {
            var query = _query.FirstByFAT_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<IndicadoresFatosDimencoesDTO>(query.Query,query.Parameters) as List<IndicadoresFatosDimencoesDTO>;
                return result;
        }

        public IEnumerable<IndicadoresFatosDimencoesDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<IndicadoresFatosDimencoesDTO>(query.Query,query.Parameters) as List<IndicadoresFatosDimencoesDTO>;
                return result;
        }

        public IEnumerable<IndicadoresFatosDimencoesDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<IndicadoresFatosDimencoesDTO>(query.Query,query.Parameters) as List<IndicadoresFatosDimencoesDTO>;
                return result;
        }

        public IEnumerable<IndicadoresFatosDimencoesDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<IndicadoresFatosDimencoesDTO>(query.Query,query.Parameters) as List<IndicadoresFatosDimencoesDTO>;
                return result;
        }

        public IEnumerable<IndicadoresFatosDimencoesDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<IndicadoresFatosDimencoesDTO>(query.Query,query.Parameters) as List<IndicadoresFatosDimencoesDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration