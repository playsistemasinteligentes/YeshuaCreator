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
    public partial class yPerfilGrantReadRepository : IyPerfilGrantReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IyPerfilGrantQueryRead _query;

        public yPerfilGrantReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IyPerfilGrantQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetyPerfilGrantCustom(Command.Read.yPerfilGrantReadCommand command, ref DataPagination<yPerfilGrantDTO> result, ref bool handled);

        public DataPagination<yPerfilGrantDTO> getyPerfilGrant(ICommandRead command )
         {
            if (command is Command.Read.yPerfilGrantReadCommand c)
                return getyPerfilGrant(c );
            throw new NotImplementedException();
        }
        private DataPagination<yPerfilGrantDTO> getyPerfilGrant(Command.Read.yPerfilGrantReadCommand command )
        {
            var customResult = new DataPagination<yPerfilGrantDTO>();
            var customHandled = false;
            TryGetyPerfilGrantCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.yPerfilGrantQuery(command );

                var itens = _unitOfWork.Query<yPerfilGrantDTO>(query.Query,query.Parameters);
                return new DataPagination<yPerfilGrantDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<yPerfilGrantPerfilIdDTO> getyPerfilGrantReadFKPerfilId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.yPerfilGrantPerfilIdQuery(command );

                var lista = _unitOfWork.Query<yPerfilGrantPerfilIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<yPerfilGrantPerfilIdDTO> getyPerfilGrantReadFKPerfilId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyPerfilGrantReadFKPerfilId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<yPerfilGrantGrantIdDTO> getyPerfilGrantReadFKGrantId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.yPerfilGrantGrantIdQuery(command );

                var lista = _unitOfWork.Query<yPerfilGrantGrantIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<yPerfilGrantGrantIdDTO> getyPerfilGrantReadFKGrantId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyPerfilGrantReadFKGrantId(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<yPerfilGrantTenantIDDTO> getyPerfilGrantReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.yPerfilGrantTenantIDQuery(command );

                var lista = _unitOfWork.Query<yPerfilGrantTenantIDDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<yPerfilGrantTenantIDDTO> getyPerfilGrantReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyPerfilGrantReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<yPerfilGrantUserIdDTO> getyPerfilGrantReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            var query = _query.yPerfilGrantUserIdQuery(command );

                var lista = _unitOfWork.Query<yPerfilGrantUserIdDTO>(query.Query,query.Parameters).ToList();
            return lista;
        }

        public IEnumerable<yPerfilGrantUserIdDTO> getyPerfilGrantReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getyPerfilGrantReadFKUserId(c );
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

        public yPerfilGrantDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yPerfilGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yPerfilGrantDTO FirstByPerfilId(int value )
        {
            var query = _query.FirstByPerfilIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yPerfilGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yPerfilGrantDTO FirstByGrantId(string value )
        {
            var query = _query.FirstByGrantIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yPerfilGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yPerfilGrantDTO FirstByCanGrant(bool value )
        {
            var query = _query.FirstByCanGrantQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yPerfilGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yPerfilGrantDTO FirstByCanCreate(bool value )
        {
            var query = _query.FirstByCanCreateQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yPerfilGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yPerfilGrantDTO FirstByCanRead(bool value )
        {
            var query = _query.FirstByCanReadQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yPerfilGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yPerfilGrantDTO FirstByCanUpdate(bool value )
        {
            var query = _query.FirstByCanUpdateQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yPerfilGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yPerfilGrantDTO FirstByCanDelete(bool value )
        {
            var query = _query.FirstByCanDeleteQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yPerfilGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yPerfilGrantDTO FirstByValidUntil(DateTime value )
        {
            var query = _query.FirstByValidUntilQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yPerfilGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yPerfilGrantDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yPerfilGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yPerfilGrantDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yPerfilGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yPerfilGrantDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yPerfilGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yPerfilGrantDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yPerfilGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<yPerfilGrantDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<yPerfilGrantDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<yPerfilGrantDTO> GetAllByPerfilId(int value )
        {
            var query = _query.FirstByPerfilIdQuery(value );

                var result = _unitOfWork.Query<yPerfilGrantDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<yPerfilGrantDTO> GetAllByGrantId(string value )
        {
            var query = _query.FirstByGrantIdQuery(value );

                var result = _unitOfWork.Query<yPerfilGrantDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<yPerfilGrantDTO> GetAllByCanGrant(bool value )
        {
            var query = _query.FirstByCanGrantQuery(value );

                var result = _unitOfWork.Query<yPerfilGrantDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<yPerfilGrantDTO> GetAllByCanCreate(bool value )
        {
            var query = _query.FirstByCanCreateQuery(value );

                var result = _unitOfWork.Query<yPerfilGrantDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<yPerfilGrantDTO> GetAllByCanRead(bool value )
        {
            var query = _query.FirstByCanReadQuery(value );

                var result = _unitOfWork.Query<yPerfilGrantDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<yPerfilGrantDTO> GetAllByCanUpdate(bool value )
        {
            var query = _query.FirstByCanUpdateQuery(value );

                var result = _unitOfWork.Query<yPerfilGrantDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<yPerfilGrantDTO> GetAllByCanDelete(bool value )
        {
            var query = _query.FirstByCanDeleteQuery(value );

                var result = _unitOfWork.Query<yPerfilGrantDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<yPerfilGrantDTO> GetAllByValidUntil(DateTime value )
        {
            var query = _query.FirstByValidUntilQuery(value );

                var result = _unitOfWork.Query<yPerfilGrantDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<yPerfilGrantDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<yPerfilGrantDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<yPerfilGrantDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<yPerfilGrantDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<yPerfilGrantDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<yPerfilGrantDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

        public IEnumerable<yPerfilGrantDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<yPerfilGrantDTO>(query.Query,query.Parameters).ToList();
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration