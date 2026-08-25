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
    public partial class GrupoMaquinaReadRepository : IGrupoMaquinaReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IGrupoMaquinaQueryRead _query;

        public GrupoMaquinaReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IGrupoMaquinaQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<GrupoMaquinaDTO> getGrupoMaquina(ICommandRead command )
         {
            if (command is Command.Read.GrupoMaquinaReadCommand c)
                return getGrupoMaquina(c );
            throw new NotImplementedException();
        }
        private DataPagination<GrupoMaquinaDTO> getGrupoMaquina(Command.Read.GrupoMaquinaReadCommand command )
        {
            var query = _query.GrupoMaquinaQuery(command );

                var itens = _unitOfWork.Query<GrupoMaquinaDTO>(query.Query,query.Parameters);
                return new DataPagination<GrupoMaquinaDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<GrupoMaquinaTenantIDDTO> getGrupoMaquinaReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<GrupoMaquinaTenantIDDTO> lista;
            var query = _query.GrupoMaquinaTenantIDQuery(command );

                lista = _unitOfWork.Query<GrupoMaquinaTenantIDDTO>(query.Query,query.Parameters) as List<GrupoMaquinaTenantIDDTO>;
            return lista;
        }

        public IEnumerable<GrupoMaquinaTenantIDDTO> getGrupoMaquinaReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getGrupoMaquinaReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<GrupoMaquinaUserIdDTO> getGrupoMaquinaReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<GrupoMaquinaUserIdDTO> lista;
            var query = _query.GrupoMaquinaUserIdQuery(command );

                lista = _unitOfWork.Query<GrupoMaquinaUserIdDTO>(query.Query,query.Parameters) as List<GrupoMaquinaUserIdDTO>;
            return lista;
        }

        public IEnumerable<GrupoMaquinaUserIdDTO> getGrupoMaquinaReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getGrupoMaquinaReadFKUserId(c );
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

        public bool ExistsByStatus(string value )
        {
            var query = _query.ExistsByStatusQuery(value );

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

        public GrupoMaquinaDTO FirstById(string value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoMaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoMaquinaDTO FirstByDescricao(string value )
        {
            var query = _query.FirstByDescricaoQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoMaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoMaquinaDTO FirstByStatus(string value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoMaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoMaquinaDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoMaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoMaquinaDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoMaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoMaquinaDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoMaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoMaquinaDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoMaquinaDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<GrupoMaquinaDTO> GetAllById(string value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<GrupoMaquinaDTO>(query.Query,query.Parameters) as List<GrupoMaquinaDTO>;
                return result;
        }

        public IEnumerable<GrupoMaquinaDTO> GetAllByDescricao(string value )
        {
            var query = _query.FirstByDescricaoQuery(value );

                var result = _unitOfWork.Query<GrupoMaquinaDTO>(query.Query,query.Parameters) as List<GrupoMaquinaDTO>;
                return result;
        }

        public IEnumerable<GrupoMaquinaDTO> GetAllByStatus(string value )
        {
            var query = _query.FirstByStatusQuery(value );

                var result = _unitOfWork.Query<GrupoMaquinaDTO>(query.Query,query.Parameters) as List<GrupoMaquinaDTO>;
                return result;
        }

        public IEnumerable<GrupoMaquinaDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<GrupoMaquinaDTO>(query.Query,query.Parameters) as List<GrupoMaquinaDTO>;
                return result;
        }

        public IEnumerable<GrupoMaquinaDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<GrupoMaquinaDTO>(query.Query,query.Parameters) as List<GrupoMaquinaDTO>;
                return result;
        }

        public IEnumerable<GrupoMaquinaDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<GrupoMaquinaDTO>(query.Query,query.Parameters) as List<GrupoMaquinaDTO>;
                return result;
        }

        public IEnumerable<GrupoMaquinaDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<GrupoMaquinaDTO>(query.Query,query.Parameters) as List<GrupoMaquinaDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration