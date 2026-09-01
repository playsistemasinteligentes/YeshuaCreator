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
    public partial class TemplatesGrupoMaquinaReadRepository : ITemplatesGrupoMaquinaReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ITemplatesGrupoMaquinaQueryRead _query;

        public TemplatesGrupoMaquinaReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ITemplatesGrupoMaquinaQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetTemplatesGrupoMaquinaCustom(Command.Read.TemplatesGrupoMaquinaReadCommand command, ref DataPagination<TemplatesGrupoMaquinaDTO> result, ref bool handled);

        public DataPagination<TemplatesGrupoMaquinaDTO> getTemplatesGrupoMaquina(ICommandRead command )
         {
            if (command is Command.Read.TemplatesGrupoMaquinaReadCommand c)
                return getTemplatesGrupoMaquina(c );
            throw new NotImplementedException();
        }
        private DataPagination<TemplatesGrupoMaquinaDTO> getTemplatesGrupoMaquina(Command.Read.TemplatesGrupoMaquinaReadCommand command )
        {
            DataPagination<TemplatesGrupoMaquinaDTO> customResult = null;
            var customHandled = false;
            TryGetTemplatesGrupoMaquinaCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.TemplatesGrupoMaquinaQuery(command );

                var itens = _unitOfWork.Query<TemplatesGrupoMaquinaDTO>(query.Query,query.Parameters);
                return new DataPagination<TemplatesGrupoMaquinaDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<TemplatesGrupoMaquinaTenantIDDTO> getTemplatesGrupoMaquinaReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TemplatesGrupoMaquinaTenantIDDTO> lista;
            var query = _query.TemplatesGrupoMaquinaTenantIDQuery(command );

                lista = _unitOfWork.Query<TemplatesGrupoMaquinaTenantIDDTO>(query.Query,query.Parameters) as List<TemplatesGrupoMaquinaTenantIDDTO>;
            return lista;
        }

        public IEnumerable<TemplatesGrupoMaquinaTenantIDDTO> getTemplatesGrupoMaquinaReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTemplatesGrupoMaquinaReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<TemplatesGrupoMaquinaUserIdDTO> getTemplatesGrupoMaquinaReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<TemplatesGrupoMaquinaUserIdDTO> lista;
            var query = _query.TemplatesGrupoMaquinaUserIdQuery(command );

                lista = _unitOfWork.Query<TemplatesGrupoMaquinaUserIdDTO>(query.Query,query.Parameters) as List<TemplatesGrupoMaquinaUserIdDTO>;
            return lista;
        }

        public IEnumerable<TemplatesGrupoMaquinaUserIdDTO> getTemplatesGrupoMaquinaReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getTemplatesGrupoMaquinaReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTEM_ID(int value )
        {
            var query = _query.ExistsByTEM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGMA_ID(string value )
        {
            var query = _query.ExistsByGMA_IDQuery(value );

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

        public TemplatesGrupoMaquinaDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemplatesGrupoMaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TemplatesGrupoMaquinaDTO FirstByTEM_ID(int value )
        {
            var query = _query.FirstByTEM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemplatesGrupoMaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TemplatesGrupoMaquinaDTO FirstByGMA_ID(string value )
        {
            var query = _query.FirstByGMA_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemplatesGrupoMaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TemplatesGrupoMaquinaDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemplatesGrupoMaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TemplatesGrupoMaquinaDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemplatesGrupoMaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TemplatesGrupoMaquinaDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemplatesGrupoMaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public TemplatesGrupoMaquinaDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<TemplatesGrupoMaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<TemplatesGrupoMaquinaDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<TemplatesGrupoMaquinaDTO>(query.Query,query.Parameters) as List<TemplatesGrupoMaquinaDTO>;
                return result;
        }

        public IEnumerable<TemplatesGrupoMaquinaDTO> GetAllByTEM_ID(int value )
        {
            var query = _query.FirstByTEM_IDQuery(value );

                var result = _unitOfWork.Query<TemplatesGrupoMaquinaDTO>(query.Query,query.Parameters) as List<TemplatesGrupoMaquinaDTO>;
                return result;
        }

        public IEnumerable<TemplatesGrupoMaquinaDTO> GetAllByGMA_ID(string value )
        {
            var query = _query.FirstByGMA_IDQuery(value );

                var result = _unitOfWork.Query<TemplatesGrupoMaquinaDTO>(query.Query,query.Parameters) as List<TemplatesGrupoMaquinaDTO>;
                return result;
        }

        public IEnumerable<TemplatesGrupoMaquinaDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<TemplatesGrupoMaquinaDTO>(query.Query,query.Parameters) as List<TemplatesGrupoMaquinaDTO>;
                return result;
        }

        public IEnumerable<TemplatesGrupoMaquinaDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<TemplatesGrupoMaquinaDTO>(query.Query,query.Parameters) as List<TemplatesGrupoMaquinaDTO>;
                return result;
        }

        public IEnumerable<TemplatesGrupoMaquinaDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<TemplatesGrupoMaquinaDTO>(query.Query,query.Parameters) as List<TemplatesGrupoMaquinaDTO>;
                return result;
        }

        public IEnumerable<TemplatesGrupoMaquinaDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<TemplatesGrupoMaquinaDTO>(query.Query,query.Parameters) as List<TemplatesGrupoMaquinaDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration