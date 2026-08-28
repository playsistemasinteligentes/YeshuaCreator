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
    public partial class UsuarioPerfilReadRepository : IUsuarioPerfilReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IUsuarioPerfilQueryRead _query;

        public UsuarioPerfilReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IUsuarioPerfilQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<UsuarioPerfilDTO> getUsuarioPerfil(ICommandRead command )
         {
            if (command is Command.Read.UsuarioPerfilReadCommand c)
                return getUsuarioPerfil(c );
            throw new NotImplementedException();
        }
        private DataPagination<UsuarioPerfilDTO> getUsuarioPerfil(Command.Read.UsuarioPerfilReadCommand command )
        {
            var query = _query.UsuarioPerfilQuery(command );

                var itens = _unitOfWork.Query<UsuarioPerfilDTO>(query.Query,query.Parameters);
                return new DataPagination<UsuarioPerfilDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<UsuarioPerfilUSE_IDDTO> getUsuarioPerfilReadFKUSE_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<UsuarioPerfilUSE_IDDTO> lista;
            var query = _query.UsuarioPerfilUSE_IDQuery(command );

                lista = _unitOfWork.Query<UsuarioPerfilUSE_IDDTO>(query.Query,query.Parameters) as List<UsuarioPerfilUSE_IDDTO>;
            return lista;
        }

        public IEnumerable<UsuarioPerfilUSE_IDDTO> getUsuarioPerfilReadFKUSE_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getUsuarioPerfilReadFKUSE_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<UsuarioPerfilPER_IDDTO> getUsuarioPerfilReadFKPER_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<UsuarioPerfilPER_IDDTO> lista;
            var query = _query.UsuarioPerfilPER_IDQuery(command );

                lista = _unitOfWork.Query<UsuarioPerfilPER_IDDTO>(query.Query,query.Parameters) as List<UsuarioPerfilPER_IDDTO>;
            return lista;
        }

        public IEnumerable<UsuarioPerfilPER_IDDTO> getUsuarioPerfilReadFKPER_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getUsuarioPerfilReadFKPER_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<UsuarioPerfilTenantIDDTO> getUsuarioPerfilReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<UsuarioPerfilTenantIDDTO> lista;
            var query = _query.UsuarioPerfilTenantIDQuery(command );

                lista = _unitOfWork.Query<UsuarioPerfilTenantIDDTO>(query.Query,query.Parameters) as List<UsuarioPerfilTenantIDDTO>;
            return lista;
        }

        public IEnumerable<UsuarioPerfilTenantIDDTO> getUsuarioPerfilReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getUsuarioPerfilReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<UsuarioPerfilUserIdDTO> getUsuarioPerfilReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<UsuarioPerfilUserIdDTO> lista;
            var query = _query.UsuarioPerfilUserIdQuery(command );

                lista = _unitOfWork.Query<UsuarioPerfilUserIdDTO>(query.Query,query.Parameters) as List<UsuarioPerfilUserIdDTO>;
            return lista;
        }

        public IEnumerable<UsuarioPerfilUserIdDTO> getUsuarioPerfilReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getUsuarioPerfilReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUSE_ID(int value )
        {
            var query = _query.ExistsByUSE_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPER_ID(int value )
        {
            var query = _query.ExistsByPER_IDQuery(value );

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

        public UsuarioPerfilDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UsuarioPerfilDTO>(query.Query, query.Parameters);
                return result;
        }

        public UsuarioPerfilDTO FirstByUSE_ID(int value )
        {
            var query = _query.FirstByUSE_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UsuarioPerfilDTO>(query.Query, query.Parameters);
                return result;
        }

        public UsuarioPerfilDTO FirstByPER_ID(int value )
        {
            var query = _query.FirstByPER_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UsuarioPerfilDTO>(query.Query, query.Parameters);
                return result;
        }

        public UsuarioPerfilDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UsuarioPerfilDTO>(query.Query, query.Parameters);
                return result;
        }

        public UsuarioPerfilDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UsuarioPerfilDTO>(query.Query, query.Parameters);
                return result;
        }

        public UsuarioPerfilDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UsuarioPerfilDTO>(query.Query, query.Parameters);
                return result;
        }

        public UsuarioPerfilDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UsuarioPerfilDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<UsuarioPerfilDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<UsuarioPerfilDTO>(query.Query,query.Parameters) as List<UsuarioPerfilDTO>;
                return result;
        }

        public IEnumerable<UsuarioPerfilDTO> GetAllByUSE_ID(int value )
        {
            var query = _query.FirstByUSE_IDQuery(value );

                var result = _unitOfWork.Query<UsuarioPerfilDTO>(query.Query,query.Parameters) as List<UsuarioPerfilDTO>;
                return result;
        }

        public IEnumerable<UsuarioPerfilDTO> GetAllByPER_ID(int value )
        {
            var query = _query.FirstByPER_IDQuery(value );

                var result = _unitOfWork.Query<UsuarioPerfilDTO>(query.Query,query.Parameters) as List<UsuarioPerfilDTO>;
                return result;
        }

        public IEnumerable<UsuarioPerfilDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<UsuarioPerfilDTO>(query.Query,query.Parameters) as List<UsuarioPerfilDTO>;
                return result;
        }

        public IEnumerable<UsuarioPerfilDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<UsuarioPerfilDTO>(query.Query,query.Parameters) as List<UsuarioPerfilDTO>;
                return result;
        }

        public IEnumerable<UsuarioPerfilDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<UsuarioPerfilDTO>(query.Query,query.Parameters) as List<UsuarioPerfilDTO>;
                return result;
        }

        public IEnumerable<UsuarioPerfilDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<UsuarioPerfilDTO>(query.Query,query.Parameters) as List<UsuarioPerfilDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration