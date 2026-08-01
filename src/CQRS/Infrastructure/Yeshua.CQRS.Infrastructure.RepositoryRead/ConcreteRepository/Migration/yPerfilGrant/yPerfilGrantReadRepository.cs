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

        public DataPagination<yPerfilGrantDTO> getyPerfilGrant(ICommandRead command )
         {
            if (command is Command.Read.yPerfilGrantReadCommand c)
                return getyPerfilGrant(c );
            throw new NotImplementedException();
        }
        private DataPagination<yPerfilGrantDTO> getyPerfilGrant(Command.Read.yPerfilGrantReadCommand command )
        {
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
            List<yPerfilGrantPerfilIdDTO> lista;
            var query = _query.yPerfilGrantPerfilIdQuery(command );

                lista = _unitOfWork.Query<yPerfilGrantPerfilIdDTO>(query.Query,query.Parameters) as List<yPerfilGrantPerfilIdDTO>;
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
            List<yPerfilGrantGrantIdDTO> lista;
            var query = _query.yPerfilGrantGrantIdQuery(command );

                lista = _unitOfWork.Query<yPerfilGrantGrantIdDTO>(query.Query,query.Parameters) as List<yPerfilGrantGrantIdDTO>;
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
            List<yPerfilGrantTenantIDDTO> lista;
            var query = _query.yPerfilGrantTenantIDQuery(command );

                lista = _unitOfWork.Query<yPerfilGrantTenantIDDTO>(query.Query,query.Parameters) as List<yPerfilGrantTenantIDDTO>;
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
            List<yPerfilGrantUserIdDTO> lista;
            var query = _query.yPerfilGrantUserIdQuery(command );

                lista = _unitOfWork.Query<yPerfilGrantUserIdDTO>(query.Query,query.Parameters) as List<yPerfilGrantUserIdDTO>;
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

        public bool ExistsByGrant(bool value )
        {
            var query = _query.ExistsByGrantQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCreate(bool value )
        {
            var query = _query.ExistsByCreateQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByRead(bool value )
        {
            var query = _query.ExistsByReadQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUpdate(bool value )
        {
            var query = _query.ExistsByUpdateQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDelete(bool value )
        {
            var query = _query.ExistsByDeleteQuery(value );

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

        public yPerfilGrantDTO FirstByGrant(bool value )
        {
            var query = _query.FirstByGrantQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yPerfilGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yPerfilGrantDTO FirstByCreate(bool value )
        {
            var query = _query.FirstByCreateQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yPerfilGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yPerfilGrantDTO FirstByRead(bool value )
        {
            var query = _query.FirstByReadQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yPerfilGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yPerfilGrantDTO FirstByUpdate(bool value )
        {
            var query = _query.FirstByUpdateQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<yPerfilGrantDTO>(query.Query, query.Parameters);
                return result;
        }

        public yPerfilGrantDTO FirstByDelete(bool value )
        {
            var query = _query.FirstByDeleteQuery(value );

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

                var result = _unitOfWork.Query<yPerfilGrantDTO>(query.Query,query.Parameters) as List<yPerfilGrantDTO>;
                return result;
        }

        public IEnumerable<yPerfilGrantDTO> GetAllByPerfilId(int value )
        {
            var query = _query.FirstByPerfilIdQuery(value );

                var result = _unitOfWork.Query<yPerfilGrantDTO>(query.Query,query.Parameters) as List<yPerfilGrantDTO>;
                return result;
        }

        public IEnumerable<yPerfilGrantDTO> GetAllByGrantId(string value )
        {
            var query = _query.FirstByGrantIdQuery(value );

                var result = _unitOfWork.Query<yPerfilGrantDTO>(query.Query,query.Parameters) as List<yPerfilGrantDTO>;
                return result;
        }

        public IEnumerable<yPerfilGrantDTO> GetAllByGrant(bool value )
        {
            var query = _query.FirstByGrantQuery(value );

                var result = _unitOfWork.Query<yPerfilGrantDTO>(query.Query,query.Parameters) as List<yPerfilGrantDTO>;
                return result;
        }

        public IEnumerable<yPerfilGrantDTO> GetAllByCreate(bool value )
        {
            var query = _query.FirstByCreateQuery(value );

                var result = _unitOfWork.Query<yPerfilGrantDTO>(query.Query,query.Parameters) as List<yPerfilGrantDTO>;
                return result;
        }

        public IEnumerable<yPerfilGrantDTO> GetAllByRead(bool value )
        {
            var query = _query.FirstByReadQuery(value );

                var result = _unitOfWork.Query<yPerfilGrantDTO>(query.Query,query.Parameters) as List<yPerfilGrantDTO>;
                return result;
        }

        public IEnumerable<yPerfilGrantDTO> GetAllByUpdate(bool value )
        {
            var query = _query.FirstByUpdateQuery(value );

                var result = _unitOfWork.Query<yPerfilGrantDTO>(query.Query,query.Parameters) as List<yPerfilGrantDTO>;
                return result;
        }

        public IEnumerable<yPerfilGrantDTO> GetAllByDelete(bool value )
        {
            var query = _query.FirstByDeleteQuery(value );

                var result = _unitOfWork.Query<yPerfilGrantDTO>(query.Query,query.Parameters) as List<yPerfilGrantDTO>;
                return result;
        }

        public IEnumerable<yPerfilGrantDTO> GetAllByValidUntil(DateTime value )
        {
            var query = _query.FirstByValidUntilQuery(value );

                var result = _unitOfWork.Query<yPerfilGrantDTO>(query.Query,query.Parameters) as List<yPerfilGrantDTO>;
                return result;
        }

        public IEnumerable<yPerfilGrantDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<yPerfilGrantDTO>(query.Query,query.Parameters) as List<yPerfilGrantDTO>;
                return result;
        }

        public IEnumerable<yPerfilGrantDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<yPerfilGrantDTO>(query.Query,query.Parameters) as List<yPerfilGrantDTO>;
                return result;
        }

        public IEnumerable<yPerfilGrantDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<yPerfilGrantDTO>(query.Query,query.Parameters) as List<yPerfilGrantDTO>;
                return result;
        }

        public IEnumerable<yPerfilGrantDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<yPerfilGrantDTO>(query.Query,query.Parameters) as List<yPerfilGrantDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration