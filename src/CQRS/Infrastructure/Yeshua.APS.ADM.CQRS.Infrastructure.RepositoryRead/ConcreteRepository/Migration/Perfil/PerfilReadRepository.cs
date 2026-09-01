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
    public partial class PerfilReadRepository : IPerfilReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IPerfilQueryRead _query;

        public PerfilReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IPerfilQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetPerfilCustom(Command.Read.PerfilReadCommand command, ref DataPagination<PerfilDTO> result, ref bool handled);

        public DataPagination<PerfilDTO> getPerfil(ICommandRead command )
         {
            if (command is Command.Read.PerfilReadCommand c)
                return getPerfil(c );
            throw new NotImplementedException();
        }
        private DataPagination<PerfilDTO> getPerfil(Command.Read.PerfilReadCommand command )
        {
            DataPagination<PerfilDTO> customResult = null;
            var customHandled = false;
            TryGetPerfilCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.PerfilQuery(command );

                var itens = _unitOfWork.Query<PerfilDTO>(query.Query,query.Parameters);
                return new DataPagination<PerfilDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<PerfilTenantIDDTO> getPerfilReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<PerfilTenantIDDTO> lista;
            var query = _query.PerfilTenantIDQuery(command );

                lista = _unitOfWork.Query<PerfilTenantIDDTO>(query.Query,query.Parameters) as List<PerfilTenantIDDTO>;
            return lista;
        }

        public IEnumerable<PerfilTenantIDDTO> getPerfilReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getPerfilReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<PerfilUserIdDTO> getPerfilReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<PerfilUserIdDTO> lista;
            var query = _query.PerfilUserIdQuery(command );

                lista = _unitOfWork.Query<PerfilUserIdDTO>(query.Query,query.Parameters) as List<PerfilUserIdDTO>;
            return lista;
        }

        public IEnumerable<PerfilUserIdDTO> getPerfilReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getPerfilReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByPER_ID(int value )
        {
            var query = _query.ExistsByPER_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPER_NOME(string value )
        {
            var query = _query.ExistsByPER_NOMEQuery(value );

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

        public PerfilDTO FirstByPER_ID(int value )
        {
            var query = _query.FirstByPER_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PerfilDTO>(query.Query, query.Parameters);
                return result;
        }

        public PerfilDTO FirstByPER_NOME(string value )
        {
            var query = _query.FirstByPER_NOMEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PerfilDTO>(query.Query, query.Parameters);
                return result;
        }

        public PerfilDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PerfilDTO>(query.Query, query.Parameters);
                return result;
        }

        public PerfilDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PerfilDTO>(query.Query, query.Parameters);
                return result;
        }

        public PerfilDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PerfilDTO>(query.Query, query.Parameters);
                return result;
        }

        public PerfilDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<PerfilDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<PerfilDTO> GetAllByPER_ID(int value )
        {
            var query = _query.FirstByPER_IDQuery(value );

                var result = _unitOfWork.Query<PerfilDTO>(query.Query,query.Parameters) as List<PerfilDTO>;
                return result;
        }

        public IEnumerable<PerfilDTO> GetAllByPER_NOME(string value )
        {
            var query = _query.FirstByPER_NOMEQuery(value );

                var result = _unitOfWork.Query<PerfilDTO>(query.Query,query.Parameters) as List<PerfilDTO>;
                return result;
        }

        public IEnumerable<PerfilDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<PerfilDTO>(query.Query,query.Parameters) as List<PerfilDTO>;
                return result;
        }

        public IEnumerable<PerfilDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<PerfilDTO>(query.Query,query.Parameters) as List<PerfilDTO>;
                return result;
        }

        public IEnumerable<PerfilDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<PerfilDTO>(query.Query,query.Parameters) as List<PerfilDTO>;
                return result;
        }

        public IEnumerable<PerfilDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<PerfilDTO>(query.Query,query.Parameters) as List<PerfilDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration