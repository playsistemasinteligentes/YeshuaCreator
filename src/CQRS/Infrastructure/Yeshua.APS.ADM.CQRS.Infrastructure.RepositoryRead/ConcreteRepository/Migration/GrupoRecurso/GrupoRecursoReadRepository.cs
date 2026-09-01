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
    public partial class GrupoRecursoReadRepository : IGrupoRecursoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IGrupoRecursoQueryRead _query;

        public GrupoRecursoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IGrupoRecursoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetGrupoRecursoCustom(Command.Read.GrupoRecursoReadCommand command, ref DataPagination<GrupoRecursoDTO> result, ref bool handled);

        public DataPagination<GrupoRecursoDTO> getGrupoRecurso(ICommandRead command )
         {
            if (command is Command.Read.GrupoRecursoReadCommand c)
                return getGrupoRecurso(c );
            throw new NotImplementedException();
        }
        private DataPagination<GrupoRecursoDTO> getGrupoRecurso(Command.Read.GrupoRecursoReadCommand command )
        {
            DataPagination<GrupoRecursoDTO> customResult = null;
            var customHandled = false;
            TryGetGrupoRecursoCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.GrupoRecursoQuery(command );

                var itens = _unitOfWork.Query<GrupoRecursoDTO>(query.Query,query.Parameters);
                return new DataPagination<GrupoRecursoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<GrupoRecursoTenantIDDTO> getGrupoRecursoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<GrupoRecursoTenantIDDTO> lista;
            var query = _query.GrupoRecursoTenantIDQuery(command );

                lista = _unitOfWork.Query<GrupoRecursoTenantIDDTO>(query.Query,query.Parameters) as List<GrupoRecursoTenantIDDTO>;
            return lista;
        }

        public IEnumerable<GrupoRecursoTenantIDDTO> getGrupoRecursoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getGrupoRecursoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<GrupoRecursoUserIdDTO> getGrupoRecursoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<GrupoRecursoUserIdDTO> lista;
            var query = _query.GrupoRecursoUserIdQuery(command );

                lista = _unitOfWork.Query<GrupoRecursoUserIdDTO>(query.Query,query.Parameters) as List<GrupoRecursoUserIdDTO>;
            return lista;
        }

        public IEnumerable<GrupoRecursoUserIdDTO> getGrupoRecursoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getGrupoRecursoReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByGRE_ID(string value )
        {
            var query = _query.ExistsByGRE_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRE_DESCRICAO(string value )
        {
            var query = _query.ExistsByGRE_DESCRICAOQuery(value );

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

        public GrupoRecursoDTO FirstByGRE_ID(string value )
        {
            var query = _query.FirstByGRE_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoRecursoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoRecursoDTO FirstByGRE_DESCRICAO(string value )
        {
            var query = _query.FirstByGRE_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoRecursoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoRecursoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoRecursoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoRecursoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoRecursoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoRecursoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoRecursoDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoRecursoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoRecursoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<GrupoRecursoDTO> GetAllByGRE_ID(string value )
        {
            var query = _query.FirstByGRE_IDQuery(value );

                var result = _unitOfWork.Query<GrupoRecursoDTO>(query.Query,query.Parameters) as List<GrupoRecursoDTO>;
                return result;
        }

        public IEnumerable<GrupoRecursoDTO> GetAllByGRE_DESCRICAO(string value )
        {
            var query = _query.FirstByGRE_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<GrupoRecursoDTO>(query.Query,query.Parameters) as List<GrupoRecursoDTO>;
                return result;
        }

        public IEnumerable<GrupoRecursoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<GrupoRecursoDTO>(query.Query,query.Parameters) as List<GrupoRecursoDTO>;
                return result;
        }

        public IEnumerable<GrupoRecursoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<GrupoRecursoDTO>(query.Query,query.Parameters) as List<GrupoRecursoDTO>;
                return result;
        }

        public IEnumerable<GrupoRecursoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<GrupoRecursoDTO>(query.Query,query.Parameters) as List<GrupoRecursoDTO>;
                return result;
        }

        public IEnumerable<GrupoRecursoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<GrupoRecursoDTO>(query.Query,query.Parameters) as List<GrupoRecursoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration