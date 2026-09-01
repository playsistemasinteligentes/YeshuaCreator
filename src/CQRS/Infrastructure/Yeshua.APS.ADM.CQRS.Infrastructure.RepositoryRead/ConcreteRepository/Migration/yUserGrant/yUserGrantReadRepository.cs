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
    public partial class yUserGrantReadRepository : IyUserGrantReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IyUserGrantQueryRead _query;

        public yUserGrantReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IyUserGrantQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetyUserGrantCustom(Command.Read.yUserGrantReadCommand command, ref DataPagination<yUserGrantDTO> result, ref bool handled);

        public DataPagination<yUserGrantDTO> getyUserGrant(ICommandRead command )
         {
            if (command is Command.Read.yUserGrantReadCommand c)
                return getyUserGrant(c );
            throw new NotImplementedException();
        }
        private DataPagination<yUserGrantDTO> getyUserGrant(Command.Read.yUserGrantReadCommand command )
        {
            DataPagination<yUserGrantDTO> customResult = null;
            var customHandled = false;
            TryGetyUserGrantCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.yUserGrantQuery(command );

                var itens = _unitOfWork.Query<yUserGrantDTO>(query.Query,query.Parameters);
                return new DataPagination<yUserGrantDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<yUserGrantPerfilIdDTO> getyUserGrantReadFKPerfilId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<yUserGrantPerfilIdDTO> lista;
            var query = _query.yUserGrantPerfilIdQuery(command );

                lista = _unitOfWork.Query<yUserGrantPerfilIdDTO>(query.Query,query.Parameters) as List<yUserGrantPerfilIdDTO>;
            return lista;
        }

        public IEnumerable<yUserGrantPerfilIdDTO> getyUserGrantReadFKPerfilId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyUserGrantReadFKPerfilId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<yUserGrantGrantIdDTO> getyUserGrantReadFKGrantId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<yUserGrantGrantIdDTO> lista;
            var query = _query.yUserGrantGrantIdQuery(command );

                lista = _unitOfWork.Query<yUserGrantGrantIdDTO>(query.Query,query.Parameters) as List<yUserGrantGrantIdDTO>;
            return lista;
        }

        public IEnumerable<yUserGrantGrantIdDTO> getyUserGrantReadFKGrantId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyUserGrantReadFKGrantId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<yUserGrantTenantIDDTO> getyUserGrantReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<yUserGrantTenantIDDTO> lista;
            var query = _query.yUserGrantTenantIDQuery(command );

                lista = _unitOfWork.Query<yUserGrantTenantIDDTO>(query.Query,query.Parameters) as List<yUserGrantTenantIDDTO>;
            return lista;
        }

        public IEnumerable<yUserGrantTenantIDDTO> getyUserGrantReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyUserGrantReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<yUserGrantUserIdDTO> getyUserGrantReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<yUserGrantUserIdDTO> lista;
            var query = _query.yUserGrantUserIdQuery(command );

                lista = _unitOfWork.Query<yUserGrantUserIdDTO>(query.Query,query.Parameters) as List<yUserGrantUserIdDTO>;
            return lista;
        }

        public IEnumerable<yUserGrantUserIdDTO> getyUserGrantReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyUserGrantReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPerfilId(int value )
        {
            var query = _query.ExistsByPerfilIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGrantId(string value )
        {
            var query = _query.ExistsByGrantIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCanGrant(bool value )
        {
            var query = _query.ExistsByCanGrantQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCanCreate(bool value )
        {
            var query = _query.ExistsByCanCreateQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCanRead(bool value )
        {
            var query = _query.ExistsByCanReadQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCanUpdate(bool value )
        {
            var query = _query.ExistsByCanUpdateQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCanDelete(bool value )
        {
            var query = _query.ExistsByCanDeleteQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByValidUntil(DateTime value )
        {
            var query = _query.ExistsByValidUntilQuery(value );

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

        public yUserGrantDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yUserGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yUserGrantDTO FirstByPerfilId(int value )
        {
            var query = _query.FirstByPerfilIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yUserGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yUserGrantDTO FirstByGrantId(string value )
        {
            var query = _query.FirstByGrantIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yUserGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yUserGrantDTO FirstByCanGrant(bool value )
        {
            var query = _query.FirstByCanGrantQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yUserGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yUserGrantDTO FirstByCanCreate(bool value )
        {
            var query = _query.FirstByCanCreateQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yUserGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yUserGrantDTO FirstByCanRead(bool value )
        {
            var query = _query.FirstByCanReadQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yUserGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yUserGrantDTO FirstByCanUpdate(bool value )
        {
            var query = _query.FirstByCanUpdateQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yUserGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yUserGrantDTO FirstByCanDelete(bool value )
        {
            var query = _query.FirstByCanDeleteQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yUserGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yUserGrantDTO FirstByValidUntil(DateTime value )
        {
            var query = _query.FirstByValidUntilQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yUserGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yUserGrantDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yUserGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yUserGrantDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yUserGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yUserGrantDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yUserGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yUserGrantDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yUserGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<yUserGrantDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<yUserGrantDTO>(query.Query,query.Parameters) as List<yUserGrantDTO>;
                return result;
        }

        public IEnumerable<yUserGrantDTO> GetAllByPerfilId(int value )
        {
            var query = _query.FirstByPerfilIdQuery(value );

                var result = _unitOfWork.Query<yUserGrantDTO>(query.Query,query.Parameters) as List<yUserGrantDTO>;
                return result;
        }

        public IEnumerable<yUserGrantDTO> GetAllByGrantId(string value )
        {
            var query = _query.FirstByGrantIdQuery(value );

                var result = _unitOfWork.Query<yUserGrantDTO>(query.Query,query.Parameters) as List<yUserGrantDTO>;
                return result;
        }

        public IEnumerable<yUserGrantDTO> GetAllByCanGrant(bool value )
        {
            var query = _query.FirstByCanGrantQuery(value );

                var result = _unitOfWork.Query<yUserGrantDTO>(query.Query,query.Parameters) as List<yUserGrantDTO>;
                return result;
        }

        public IEnumerable<yUserGrantDTO> GetAllByCanCreate(bool value )
        {
            var query = _query.FirstByCanCreateQuery(value );

                var result = _unitOfWork.Query<yUserGrantDTO>(query.Query,query.Parameters) as List<yUserGrantDTO>;
                return result;
        }

        public IEnumerable<yUserGrantDTO> GetAllByCanRead(bool value )
        {
            var query = _query.FirstByCanReadQuery(value );

                var result = _unitOfWork.Query<yUserGrantDTO>(query.Query,query.Parameters) as List<yUserGrantDTO>;
                return result;
        }

        public IEnumerable<yUserGrantDTO> GetAllByCanUpdate(bool value )
        {
            var query = _query.FirstByCanUpdateQuery(value );

                var result = _unitOfWork.Query<yUserGrantDTO>(query.Query,query.Parameters) as List<yUserGrantDTO>;
                return result;
        }

        public IEnumerable<yUserGrantDTO> GetAllByCanDelete(bool value )
        {
            var query = _query.FirstByCanDeleteQuery(value );

                var result = _unitOfWork.Query<yUserGrantDTO>(query.Query,query.Parameters) as List<yUserGrantDTO>;
                return result;
        }

        public IEnumerable<yUserGrantDTO> GetAllByValidUntil(DateTime value )
        {
            var query = _query.FirstByValidUntilQuery(value );

                var result = _unitOfWork.Query<yUserGrantDTO>(query.Query,query.Parameters) as List<yUserGrantDTO>;
                return result;
        }

        public IEnumerable<yUserGrantDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<yUserGrantDTO>(query.Query,query.Parameters) as List<yUserGrantDTO>;
                return result;
        }

        public IEnumerable<yUserGrantDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<yUserGrantDTO>(query.Query,query.Parameters) as List<yUserGrantDTO>;
                return result;
        }

        public IEnumerable<yUserGrantDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<yUserGrantDTO>(query.Query,query.Parameters) as List<yUserGrantDTO>;
                return result;
        }

        public IEnumerable<yUserGrantDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<yUserGrantDTO>(query.Query,query.Parameters) as List<yUserGrantDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration