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
    public partial class UsuarioReadRepository : IUsuarioReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IUsuarioQueryRead _query;

        public UsuarioReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IUsuarioQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<UsuarioDTO> getUsuario(ICommandRead command )
         {
            if (command is Command.Read.UsuarioReadCommand c)
                return getUsuario(c );
            throw new NotImplementedException();
        }
        private DataPagination<UsuarioDTO> getUsuario(Command.Read.UsuarioReadCommand command )
        {
            var query = _query.UsuarioQuery(command );

                var itens = _unitOfWork.Query<UsuarioDTO>(query.Query,query.Parameters);
                return new DataPagination<UsuarioDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<UsuarioTURM_IDDTO> getUsuarioReadFKTURM_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<UsuarioTURM_IDDTO> lista;
            var query = _query.UsuarioTURM_IDQuery(command );

                lista = _unitOfWork.Query<UsuarioTURM_IDDTO>(query.Query,query.Parameters) as List<UsuarioTURM_IDDTO>;
            return lista;
        }

        public IEnumerable<UsuarioTURM_IDDTO> getUsuarioReadFKTURM_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getUsuarioReadFKTURM_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<UsuarioTenantIDDTO> getUsuarioReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<UsuarioTenantIDDTO> lista;
            var query = _query.UsuarioTenantIDQuery(command );

                lista = _unitOfWork.Query<UsuarioTenantIDDTO>(query.Query,query.Parameters) as List<UsuarioTenantIDDTO>;
            return lista;
        }

        public IEnumerable<UsuarioTenantIDDTO> getUsuarioReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getUsuarioReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<UsuarioUserIdDTO> getUsuarioReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<UsuarioUserIdDTO> lista;
            var query = _query.UsuarioUserIdQuery(command );

                lista = _unitOfWork.Query<UsuarioUserIdDTO>(query.Query,query.Parameters) as List<UsuarioUserIdDTO>;
            return lista;
        }

        public IEnumerable<UsuarioUserIdDTO> getUsuarioReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getUsuarioReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByUSE_ID(int value )
        {
            var query = _query.ExistsByUSE_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUSE_NOME(string value )
        {
            var query = _query.ExistsByUSE_NOMEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUSE_EMAIL(string value )
        {
            var query = _query.ExistsByUSE_EMAILQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUSE_SENHA(string value )
        {
            var query = _query.ExistsByUSE_SENHAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTURM_ID(string value )
        {
            var query = _query.ExistsByTURM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUSE_ATIVO(int value )
        {
            var query = _query.ExistsByUSE_ATIVOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUSE_CODERP(string value )
        {
            var query = _query.ExistsByUSE_CODERPQuery(value );

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

        public UsuarioDTO FirstByUSE_ID(int value )
        {
            var query = _query.FirstByUSE_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UsuarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public UsuarioDTO FirstByUSE_NOME(string value )
        {
            var query = _query.FirstByUSE_NOMEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UsuarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public UsuarioDTO FirstByUSE_EMAIL(string value )
        {
            var query = _query.FirstByUSE_EMAILQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UsuarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public UsuarioDTO FirstByUSE_SENHA(string value )
        {
            var query = _query.FirstByUSE_SENHAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UsuarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public UsuarioDTO FirstByTURM_ID(string value )
        {
            var query = _query.FirstByTURM_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UsuarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public UsuarioDTO FirstByUSE_ATIVO(int value )
        {
            var query = _query.FirstByUSE_ATIVOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UsuarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public UsuarioDTO FirstByUSE_CODERP(string value )
        {
            var query = _query.FirstByUSE_CODERPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UsuarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public UsuarioDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UsuarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public UsuarioDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UsuarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public UsuarioDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UsuarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public UsuarioDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UsuarioDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<UsuarioDTO> GetAllByUSE_ID(int value )
        {
            var query = _query.FirstByUSE_IDQuery(value );

                var result = _unitOfWork.Query<UsuarioDTO>(query.Query,query.Parameters) as List<UsuarioDTO>;
                return result;
        }

        public IEnumerable<UsuarioDTO> GetAllByUSE_NOME(string value )
        {
            var query = _query.FirstByUSE_NOMEQuery(value );

                var result = _unitOfWork.Query<UsuarioDTO>(query.Query,query.Parameters) as List<UsuarioDTO>;
                return result;
        }

        public IEnumerable<UsuarioDTO> GetAllByUSE_EMAIL(string value )
        {
            var query = _query.FirstByUSE_EMAILQuery(value );

                var result = _unitOfWork.Query<UsuarioDTO>(query.Query,query.Parameters) as List<UsuarioDTO>;
                return result;
        }

        public IEnumerable<UsuarioDTO> GetAllByUSE_SENHA(string value )
        {
            var query = _query.FirstByUSE_SENHAQuery(value );

                var result = _unitOfWork.Query<UsuarioDTO>(query.Query,query.Parameters) as List<UsuarioDTO>;
                return result;
        }

        public IEnumerable<UsuarioDTO> GetAllByTURM_ID(string value )
        {
            var query = _query.FirstByTURM_IDQuery(value );

                var result = _unitOfWork.Query<UsuarioDTO>(query.Query,query.Parameters) as List<UsuarioDTO>;
                return result;
        }

        public IEnumerable<UsuarioDTO> GetAllByUSE_ATIVO(int value )
        {
            var query = _query.FirstByUSE_ATIVOQuery(value );

                var result = _unitOfWork.Query<UsuarioDTO>(query.Query,query.Parameters) as List<UsuarioDTO>;
                return result;
        }

        public IEnumerable<UsuarioDTO> GetAllByUSE_CODERP(string value )
        {
            var query = _query.FirstByUSE_CODERPQuery(value );

                var result = _unitOfWork.Query<UsuarioDTO>(query.Query,query.Parameters) as List<UsuarioDTO>;
                return result;
        }

        public IEnumerable<UsuarioDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<UsuarioDTO>(query.Query,query.Parameters) as List<UsuarioDTO>;
                return result;
        }

        public IEnumerable<UsuarioDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<UsuarioDTO>(query.Query,query.Parameters) as List<UsuarioDTO>;
                return result;
        }

        public IEnumerable<UsuarioDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<UsuarioDTO>(query.Query,query.Parameters) as List<UsuarioDTO>;
                return result;
        }

        public IEnumerable<UsuarioDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<UsuarioDTO>(query.Query,query.Parameters) as List<UsuarioDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration