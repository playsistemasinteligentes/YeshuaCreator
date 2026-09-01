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
    public partial class VariavelPlotagemReadRepository : IVariavelPlotagemReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IVariavelPlotagemQueryRead _query;

        public VariavelPlotagemReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IVariavelPlotagemQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetVariavelPlotagemCustom(Command.Read.VariavelPlotagemReadCommand command, ref DataPagination<VariavelPlotagemDTO> result, ref bool handled);

        public DataPagination<VariavelPlotagemDTO> getVariavelPlotagem(ICommandRead command )
         {
            if (command is Command.Read.VariavelPlotagemReadCommand c)
                return getVariavelPlotagem(c );
            throw new NotImplementedException();
        }
        private DataPagination<VariavelPlotagemDTO> getVariavelPlotagem(Command.Read.VariavelPlotagemReadCommand command )
        {
            DataPagination<VariavelPlotagemDTO> customResult = null;
            var customHandled = false;
            TryGetVariavelPlotagemCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.VariavelPlotagemQuery(command );

                var itens = _unitOfWork.Query<VariavelPlotagemDTO>(query.Query,query.Parameters);
                return new DataPagination<VariavelPlotagemDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<VariavelPlotagemTenantIDDTO> getVariavelPlotagemReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<VariavelPlotagemTenantIDDTO> lista;
            var query = _query.VariavelPlotagemTenantIDQuery(command );

                lista = _unitOfWork.Query<VariavelPlotagemTenantIDDTO>(query.Query,query.Parameters) as List<VariavelPlotagemTenantIDDTO>;
            return lista;
        }

        public IEnumerable<VariavelPlotagemTenantIDDTO> getVariavelPlotagemReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getVariavelPlotagemReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<VariavelPlotagemUserIdDTO> getVariavelPlotagemReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<VariavelPlotagemUserIdDTO> lista;
            var query = _query.VariavelPlotagemUserIdQuery(command );

                lista = _unitOfWork.Query<VariavelPlotagemUserIdDTO>(query.Query,query.Parameters) as List<VariavelPlotagemUserIdDTO>;
            return lista;
        }

        public IEnumerable<VariavelPlotagemUserIdDTO> getVariavelPlotagemReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getVariavelPlotagemReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByVAR_ID(int value )
        {
            var query = _query.ExistsByVAR_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPLO_ID(int value )
        {
            var query = _query.ExistsByPLO_IDQuery(value );

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

        public VariavelPlotagemDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VariavelPlotagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public VariavelPlotagemDTO FirstByVAR_ID(int value )
        {
            var query = _query.FirstByVAR_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VariavelPlotagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public VariavelPlotagemDTO FirstByPLO_ID(int value )
        {
            var query = _query.FirstByPLO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VariavelPlotagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public VariavelPlotagemDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VariavelPlotagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public VariavelPlotagemDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VariavelPlotagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public VariavelPlotagemDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VariavelPlotagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public VariavelPlotagemDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VariavelPlotagemDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<VariavelPlotagemDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<VariavelPlotagemDTO>(query.Query,query.Parameters) as List<VariavelPlotagemDTO>;
                return result;
        }

        public IEnumerable<VariavelPlotagemDTO> GetAllByVAR_ID(int value )
        {
            var query = _query.FirstByVAR_IDQuery(value );

                var result = _unitOfWork.Query<VariavelPlotagemDTO>(query.Query,query.Parameters) as List<VariavelPlotagemDTO>;
                return result;
        }

        public IEnumerable<VariavelPlotagemDTO> GetAllByPLO_ID(int value )
        {
            var query = _query.FirstByPLO_IDQuery(value );

                var result = _unitOfWork.Query<VariavelPlotagemDTO>(query.Query,query.Parameters) as List<VariavelPlotagemDTO>;
                return result;
        }

        public IEnumerable<VariavelPlotagemDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<VariavelPlotagemDTO>(query.Query,query.Parameters) as List<VariavelPlotagemDTO>;
                return result;
        }

        public IEnumerable<VariavelPlotagemDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<VariavelPlotagemDTO>(query.Query,query.Parameters) as List<VariavelPlotagemDTO>;
                return result;
        }

        public IEnumerable<VariavelPlotagemDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<VariavelPlotagemDTO>(query.Query,query.Parameters) as List<VariavelPlotagemDTO>;
                return result;
        }

        public IEnumerable<VariavelPlotagemDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<VariavelPlotagemDTO>(query.Query,query.Parameters) as List<VariavelPlotagemDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration