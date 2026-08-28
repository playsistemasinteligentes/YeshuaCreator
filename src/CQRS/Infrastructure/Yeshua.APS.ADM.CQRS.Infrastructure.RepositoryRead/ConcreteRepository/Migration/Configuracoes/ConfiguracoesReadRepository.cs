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
    public partial class ConfiguracoesReadRepository : IConfiguracoesReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IConfiguracoesQueryRead _query;

        public ConfiguracoesReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IConfiguracoesQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<ConfiguracoesDTO> getConfiguracoes(ICommandRead command )
         {
            if (command is Command.Read.ConfiguracoesReadCommand c)
                return getConfiguracoes(c );
            throw new NotImplementedException();
        }
        private DataPagination<ConfiguracoesDTO> getConfiguracoes(Command.Read.ConfiguracoesReadCommand command )
        {
            var query = _query.ConfiguracoesQuery(command );

                var itens = _unitOfWork.Query<ConfiguracoesDTO>(query.Query,query.Parameters);
                return new DataPagination<ConfiguracoesDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<ConfiguracoesTenantIDDTO> getConfiguracoesReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ConfiguracoesTenantIDDTO> lista;
            var query = _query.ConfiguracoesTenantIDQuery(command );

                lista = _unitOfWork.Query<ConfiguracoesTenantIDDTO>(query.Query,query.Parameters) as List<ConfiguracoesTenantIDDTO>;
            return lista;
        }

        public IEnumerable<ConfiguracoesTenantIDDTO> getConfiguracoesReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getConfiguracoesReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ConfiguracoesUserIdDTO> getConfiguracoesReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ConfiguracoesUserIdDTO> lista;
            var query = _query.ConfiguracoesUserIdQuery(command );

                lista = _unitOfWork.Query<ConfiguracoesUserIdDTO>(query.Query,query.Parameters) as List<ConfiguracoesUserIdDTO>;
            return lista;
        }

        public IEnumerable<ConfiguracoesUserIdDTO> getConfiguracoesReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getConfiguracoesReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByCON_ID(int value )
        {
            var query = _query.ExistsByCON_IDQuery(value );

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

        public ConfiguracoesDTO FirstByCON_ID(int value )
        {
            var query = _query.FirstByCON_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ConfiguracoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public ConfiguracoesDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ConfiguracoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public ConfiguracoesDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ConfiguracoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public ConfiguracoesDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ConfiguracoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public ConfiguracoesDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ConfiguracoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<ConfiguracoesDTO> GetAllByCON_ID(int value )
        {
            var query = _query.FirstByCON_IDQuery(value );

                var result = _unitOfWork.Query<ConfiguracoesDTO>(query.Query,query.Parameters) as List<ConfiguracoesDTO>;
                return result;
        }

        public IEnumerable<ConfiguracoesDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<ConfiguracoesDTO>(query.Query,query.Parameters) as List<ConfiguracoesDTO>;
                return result;
        }

        public IEnumerable<ConfiguracoesDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<ConfiguracoesDTO>(query.Query,query.Parameters) as List<ConfiguracoesDTO>;
                return result;
        }

        public IEnumerable<ConfiguracoesDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<ConfiguracoesDTO>(query.Query,query.Parameters) as List<ConfiguracoesDTO>;
                return result;
        }

        public IEnumerable<ConfiguracoesDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<ConfiguracoesDTO>(query.Query,query.Parameters) as List<ConfiguracoesDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration