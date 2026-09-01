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
    public partial class UsuariosCargaReadRepository : IUsuariosCargaReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IUsuariosCargaQueryRead _query;

        public UsuariosCargaReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IUsuariosCargaQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetUsuariosCargaCustom(Command.Read.UsuariosCargaReadCommand command, ref DataPagination<UsuariosCargaDTO> result, ref bool handled);

        public DataPagination<UsuariosCargaDTO> getUsuariosCarga(ICommandRead command )
         {
            if (command is Command.Read.UsuariosCargaReadCommand c)
                return getUsuariosCarga(c );
            throw new NotImplementedException();
        }
        private DataPagination<UsuariosCargaDTO> getUsuariosCarga(Command.Read.UsuariosCargaReadCommand command )
        {
            DataPagination<UsuariosCargaDTO> customResult = null;
            var customHandled = false;
            TryGetUsuariosCargaCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.UsuariosCargaQuery(command );

                var itens = _unitOfWork.Query<UsuariosCargaDTO>(query.Query,query.Parameters);
                return new DataPagination<UsuariosCargaDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<UsuariosCargaUSE_IDDTO> getUsuariosCargaReadFKUSE_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<UsuariosCargaUSE_IDDTO> lista;
            var query = _query.UsuariosCargaUSE_IDQuery(command );

                lista = _unitOfWork.Query<UsuariosCargaUSE_IDDTO>(query.Query,query.Parameters) as List<UsuariosCargaUSE_IDDTO>;
            return lista;
        }

        public IEnumerable<UsuariosCargaUSE_IDDTO> getUsuariosCargaReadFKUSE_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getUsuariosCargaReadFKUSE_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<UsuariosCargaTenantIDDTO> getUsuariosCargaReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<UsuariosCargaTenantIDDTO> lista;
            var query = _query.UsuariosCargaTenantIDQuery(command );

                lista = _unitOfWork.Query<UsuariosCargaTenantIDDTO>(query.Query,query.Parameters) as List<UsuariosCargaTenantIDDTO>;
            return lista;
        }

        public IEnumerable<UsuariosCargaTenantIDDTO> getUsuariosCargaReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getUsuariosCargaReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<UsuariosCargaUserIdDTO> getUsuariosCargaReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<UsuariosCargaUserIdDTO> lista;
            var query = _query.UsuariosCargaUserIdQuery(command );

                lista = _unitOfWork.Query<UsuariosCargaUserIdDTO>(query.Query,query.Parameters) as List<UsuariosCargaUserIdDTO>;
            return lista;
        }

        public IEnumerable<UsuariosCargaUserIdDTO> getUsuariosCargaReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getUsuariosCargaReadFKUserId(c );
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

        public bool ExistsByCAR_ID(string value )
        {
            var query = _query.ExistsByCAR_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByRGO_ID(string value )
        {
            var query = _query.ExistsByRGO_IDQuery(value );

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

        public UsuariosCargaDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UsuariosCargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public UsuariosCargaDTO FirstByUSE_ID(int value )
        {
            var query = _query.FirstByUSE_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UsuariosCargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public UsuariosCargaDTO FirstByCAR_ID(string value )
        {
            var query = _query.FirstByCAR_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UsuariosCargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public UsuariosCargaDTO FirstByRGO_ID(string value )
        {
            var query = _query.FirstByRGO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UsuariosCargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public UsuariosCargaDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UsuariosCargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public UsuariosCargaDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UsuariosCargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public UsuariosCargaDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UsuariosCargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public UsuariosCargaDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UsuariosCargaDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<UsuariosCargaDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<UsuariosCargaDTO>(query.Query,query.Parameters) as List<UsuariosCargaDTO>;
                return result;
        }

        public IEnumerable<UsuariosCargaDTO> GetAllByUSE_ID(int value )
        {
            var query = _query.FirstByUSE_IDQuery(value );

                var result = _unitOfWork.Query<UsuariosCargaDTO>(query.Query,query.Parameters) as List<UsuariosCargaDTO>;
                return result;
        }

        public IEnumerable<UsuariosCargaDTO> GetAllByCAR_ID(string value )
        {
            var query = _query.FirstByCAR_IDQuery(value );

                var result = _unitOfWork.Query<UsuariosCargaDTO>(query.Query,query.Parameters) as List<UsuariosCargaDTO>;
                return result;
        }

        public IEnumerable<UsuariosCargaDTO> GetAllByRGO_ID(string value )
        {
            var query = _query.FirstByRGO_IDQuery(value );

                var result = _unitOfWork.Query<UsuariosCargaDTO>(query.Query,query.Parameters) as List<UsuariosCargaDTO>;
                return result;
        }

        public IEnumerable<UsuariosCargaDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<UsuariosCargaDTO>(query.Query,query.Parameters) as List<UsuariosCargaDTO>;
                return result;
        }

        public IEnumerable<UsuariosCargaDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<UsuariosCargaDTO>(query.Query,query.Parameters) as List<UsuariosCargaDTO>;
                return result;
        }

        public IEnumerable<UsuariosCargaDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<UsuariosCargaDTO>(query.Query,query.Parameters) as List<UsuariosCargaDTO>;
                return result;
        }

        public IEnumerable<UsuariosCargaDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<UsuariosCargaDTO>(query.Query,query.Parameters) as List<UsuariosCargaDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration