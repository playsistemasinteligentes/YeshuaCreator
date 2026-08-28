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
    public partial class GrupoIndicadorReadRepository : IGrupoIndicadorReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IGrupoIndicadorQueryRead _query;

        public GrupoIndicadorReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IGrupoIndicadorQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<GrupoIndicadorDTO> getGrupoIndicador(ICommandRead command )
         {
            if (command is Command.Read.GrupoIndicadorReadCommand c)
                return getGrupoIndicador(c );
            throw new NotImplementedException();
        }
        private DataPagination<GrupoIndicadorDTO> getGrupoIndicador(Command.Read.GrupoIndicadorReadCommand command )
        {
            var query = _query.GrupoIndicadorQuery(command );

                var itens = _unitOfWork.Query<GrupoIndicadorDTO>(query.Query,query.Parameters);
                return new DataPagination<GrupoIndicadorDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<GrupoIndicadorGRU_IDDTO> getGrupoIndicadorReadFKGRU_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<GrupoIndicadorGRU_IDDTO> lista;
            var query = _query.GrupoIndicadorGRU_IDQuery(command );

                lista = _unitOfWork.Query<GrupoIndicadorGRU_IDDTO>(query.Query,query.Parameters) as List<GrupoIndicadorGRU_IDDTO>;
            return lista;
        }

        public IEnumerable<GrupoIndicadorGRU_IDDTO> getGrupoIndicadorReadFKGRU_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getGrupoIndicadorReadFKGRU_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<GrupoIndicadorIND_IDDTO> getGrupoIndicadorReadFKIND_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<GrupoIndicadorIND_IDDTO> lista;
            var query = _query.GrupoIndicadorIND_IDQuery(command );

                lista = _unitOfWork.Query<GrupoIndicadorIND_IDDTO>(query.Query,query.Parameters) as List<GrupoIndicadorIND_IDDTO>;
            return lista;
        }

        public IEnumerable<GrupoIndicadorIND_IDDTO> getGrupoIndicadorReadFKIND_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getGrupoIndicadorReadFKIND_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<GrupoIndicadorTenantIDDTO> getGrupoIndicadorReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<GrupoIndicadorTenantIDDTO> lista;
            var query = _query.GrupoIndicadorTenantIDQuery(command );

                lista = _unitOfWork.Query<GrupoIndicadorTenantIDDTO>(query.Query,query.Parameters) as List<GrupoIndicadorTenantIDDTO>;
            return lista;
        }

        public IEnumerable<GrupoIndicadorTenantIDDTO> getGrupoIndicadorReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getGrupoIndicadorReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<GrupoIndicadorUserIdDTO> getGrupoIndicadorReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<GrupoIndicadorUserIdDTO> lista;
            var query = _query.GrupoIndicadorUserIdQuery(command );

                lista = _unitOfWork.Query<GrupoIndicadorUserIdDTO>(query.Query,query.Parameters) as List<GrupoIndicadorUserIdDTO>;
            return lista;
        }

        public IEnumerable<GrupoIndicadorUserIdDTO> getGrupoIndicadorReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getGrupoIndicadorReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByGRU_IND_ID(int value )
        {
            var query = _query.ExistsByGRU_IND_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRU_ID(int value )
        {
            var query = _query.ExistsByGRU_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByIND_ID(int value )
        {
            var query = _query.ExistsByIND_IDQuery(value );

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

        public GrupoIndicadorDTO FirstByGRU_IND_ID(int value )
        {
            var query = _query.FirstByGRU_IND_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoIndicadorDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoIndicadorDTO FirstByGRU_ID(int value )
        {
            var query = _query.FirstByGRU_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoIndicadorDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoIndicadorDTO FirstByIND_ID(int value )
        {
            var query = _query.FirstByIND_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoIndicadorDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoIndicadorDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoIndicadorDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoIndicadorDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoIndicadorDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoIndicadorDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoIndicadorDTO>(query.Query, query.Parameters);
                return result;
        }

        public GrupoIndicadorDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<GrupoIndicadorDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<GrupoIndicadorDTO> GetAllByGRU_IND_ID(int value )
        {
            var query = _query.FirstByGRU_IND_IDQuery(value );

                var result = _unitOfWork.Query<GrupoIndicadorDTO>(query.Query,query.Parameters) as List<GrupoIndicadorDTO>;
                return result;
        }

        public IEnumerable<GrupoIndicadorDTO> GetAllByGRU_ID(int value )
        {
            var query = _query.FirstByGRU_IDQuery(value );

                var result = _unitOfWork.Query<GrupoIndicadorDTO>(query.Query,query.Parameters) as List<GrupoIndicadorDTO>;
                return result;
        }

        public IEnumerable<GrupoIndicadorDTO> GetAllByIND_ID(int value )
        {
            var query = _query.FirstByIND_IDQuery(value );

                var result = _unitOfWork.Query<GrupoIndicadorDTO>(query.Query,query.Parameters) as List<GrupoIndicadorDTO>;
                return result;
        }

        public IEnumerable<GrupoIndicadorDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<GrupoIndicadorDTO>(query.Query,query.Parameters) as List<GrupoIndicadorDTO>;
                return result;
        }

        public IEnumerable<GrupoIndicadorDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<GrupoIndicadorDTO>(query.Query,query.Parameters) as List<GrupoIndicadorDTO>;
                return result;
        }

        public IEnumerable<GrupoIndicadorDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<GrupoIndicadorDTO>(query.Query,query.Parameters) as List<GrupoIndicadorDTO>;
                return result;
        }

        public IEnumerable<GrupoIndicadorDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<GrupoIndicadorDTO>(query.Query,query.Parameters) as List<GrupoIndicadorDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration