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
    public partial class OptAlteracaoDimencoesReadRepository : IOptAlteracaoDimencoesReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IOptAlteracaoDimencoesQueryRead _query;

        public OptAlteracaoDimencoesReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IOptAlteracaoDimencoesQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetOptAlteracaoDimencoesCustom(Command.Read.OptAlteracaoDimencoesReadCommand command, ref DataPagination<OptAlteracaoDimencoesDTO> result, ref bool handled);

        public DataPagination<OptAlteracaoDimencoesDTO> getOptAlteracaoDimencoes(ICommandRead command )
         {
            if (command is Command.Read.OptAlteracaoDimencoesReadCommand c)
                return getOptAlteracaoDimencoes(c );
            throw new NotImplementedException();
        }
        private DataPagination<OptAlteracaoDimencoesDTO> getOptAlteracaoDimencoes(Command.Read.OptAlteracaoDimencoesReadCommand command )
        {
            DataPagination<OptAlteracaoDimencoesDTO> customResult = null;
            var customHandled = false;
            TryGetOptAlteracaoDimencoesCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.OptAlteracaoDimencoesQuery(command );

                var itens = _unitOfWork.Query<OptAlteracaoDimencoesDTO>(query.Query,query.Parameters);
                return new DataPagination<OptAlteracaoDimencoesDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<OptAlteracaoDimencoesTenantIDDTO> getOptAlteracaoDimencoesReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<OptAlteracaoDimencoesTenantIDDTO> lista;
            var query = _query.OptAlteracaoDimencoesTenantIDQuery(command );

                lista = _unitOfWork.Query<OptAlteracaoDimencoesTenantIDDTO>(query.Query,query.Parameters) as List<OptAlteracaoDimencoesTenantIDDTO>;
            return lista;
        }

        public IEnumerable<OptAlteracaoDimencoesTenantIDDTO> getOptAlteracaoDimencoesReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getOptAlteracaoDimencoesReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<OptAlteracaoDimencoesUserIdDTO> getOptAlteracaoDimencoesReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<OptAlteracaoDimencoesUserIdDTO> lista;
            var query = _query.OptAlteracaoDimencoesUserIdQuery(command );

                lista = _unitOfWork.Query<OptAlteracaoDimencoesUserIdDTO>(query.Query,query.Parameters) as List<OptAlteracaoDimencoesUserIdDTO>;
            return lista;
        }

        public IEnumerable<OptAlteracaoDimencoesUserIdDTO> getOptAlteracaoDimencoesReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getOptAlteracaoDimencoesReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOAD_ID(int value )
        {
            var query = _query.ExistsByOAD_IDQuery(value );

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

        public OptAlteracaoDimencoesDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OptAlteracaoDimencoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public OptAlteracaoDimencoesDTO FirstByOAD_ID(int value )
        {
            var query = _query.FirstByOAD_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OptAlteracaoDimencoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public OptAlteracaoDimencoesDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OptAlteracaoDimencoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public OptAlteracaoDimencoesDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OptAlteracaoDimencoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public OptAlteracaoDimencoesDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OptAlteracaoDimencoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public OptAlteracaoDimencoesDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OptAlteracaoDimencoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<OptAlteracaoDimencoesDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<OptAlteracaoDimencoesDTO>(query.Query,query.Parameters) as List<OptAlteracaoDimencoesDTO>;
                return result;
        }

        public IEnumerable<OptAlteracaoDimencoesDTO> GetAllByOAD_ID(int value )
        {
            var query = _query.FirstByOAD_IDQuery(value );

                var result = _unitOfWork.Query<OptAlteracaoDimencoesDTO>(query.Query,query.Parameters) as List<OptAlteracaoDimencoesDTO>;
                return result;
        }

        public IEnumerable<OptAlteracaoDimencoesDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<OptAlteracaoDimencoesDTO>(query.Query,query.Parameters) as List<OptAlteracaoDimencoesDTO>;
                return result;
        }

        public IEnumerable<OptAlteracaoDimencoesDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<OptAlteracaoDimencoesDTO>(query.Query,query.Parameters) as List<OptAlteracaoDimencoesDTO>;
                return result;
        }

        public IEnumerable<OptAlteracaoDimencoesDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<OptAlteracaoDimencoesDTO>(query.Query,query.Parameters) as List<OptAlteracaoDimencoesDTO>;
                return result;
        }

        public IEnumerable<OptAlteracaoDimencoesDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<OptAlteracaoDimencoesDTO>(query.Query,query.Parameters) as List<OptAlteracaoDimencoesDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration