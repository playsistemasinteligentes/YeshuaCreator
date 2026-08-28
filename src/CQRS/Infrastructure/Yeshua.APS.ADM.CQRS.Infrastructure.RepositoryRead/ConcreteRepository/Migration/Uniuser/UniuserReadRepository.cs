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
    public partial class UniuserReadRepository : IUniuserReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IUniuserQueryRead _query;

        public UniuserReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IUniuserQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<UniuserDTO> getUniuser(ICommandRead command )
         {
            if (command is Command.Read.UniuserReadCommand c)
                return getUniuser(c );
            throw new NotImplementedException();
        }
        private DataPagination<UniuserDTO> getUniuser(Command.Read.UniuserReadCommand command )
        {
            var query = _query.UniuserQuery(command );

                var itens = _unitOfWork.Query<UniuserDTO>(query.Query,query.Parameters);
                return new DataPagination<UniuserDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<UniuserUNI_IDDTO> getUniuserReadFKUNI_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<UniuserUNI_IDDTO> lista;
            var query = _query.UniuserUNI_IDQuery(command );

                lista = _unitOfWork.Query<UniuserUNI_IDDTO>(query.Query,query.Parameters) as List<UniuserUNI_IDDTO>;
            return lista;
        }

        public IEnumerable<UniuserUNI_IDDTO> getUniuserReadFKUNI_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getUniuserReadFKUNI_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<UniuserUSE_IDDTO> getUniuserReadFKUSE_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<UniuserUSE_IDDTO> lista;
            var query = _query.UniuserUSE_IDQuery(command );

                lista = _unitOfWork.Query<UniuserUSE_IDDTO>(query.Query,query.Parameters) as List<UniuserUSE_IDDTO>;
            return lista;
        }

        public IEnumerable<UniuserUSE_IDDTO> getUniuserReadFKUSE_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getUniuserReadFKUSE_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<UniuserTenantIDDTO> getUniuserReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<UniuserTenantIDDTO> lista;
            var query = _query.UniuserTenantIDQuery(command );

                lista = _unitOfWork.Query<UniuserTenantIDDTO>(query.Query,query.Parameters) as List<UniuserTenantIDDTO>;
            return lista;
        }

        public IEnumerable<UniuserTenantIDDTO> getUniuserReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getUniuserReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<UniuserUserIdDTO> getUniuserReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<UniuserUserIdDTO> lista;
            var query = _query.UniuserUserIdQuery(command );

                lista = _unitOfWork.Query<UniuserUserIdDTO>(query.Query,query.Parameters) as List<UniuserUserIdDTO>;
            return lista;
        }

        public IEnumerable<UniuserUserIdDTO> getUniuserReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getUniuserReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByUSERGRU_ID(int value )
        {
            var query = _query.ExistsByUSERGRU_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUNI_ID(int value )
        {
            var query = _query.ExistsByUNI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUSE_ID(int value )
        {
            var query = _query.ExistsByUSE_IDQuery(value );

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

        public UniuserDTO FirstByUSERGRU_ID(int value )
        {
            var query = _query.FirstByUSERGRU_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UniuserDTO>(query.Query, query.Parameters);
                return result;
        }

        public UniuserDTO FirstByUNI_ID(int value )
        {
            var query = _query.FirstByUNI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UniuserDTO>(query.Query, query.Parameters);
                return result;
        }

        public UniuserDTO FirstByUSE_ID(int value )
        {
            var query = _query.FirstByUSE_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UniuserDTO>(query.Query, query.Parameters);
                return result;
        }

        public UniuserDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UniuserDTO>(query.Query, query.Parameters);
                return result;
        }

        public UniuserDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UniuserDTO>(query.Query, query.Parameters);
                return result;
        }

        public UniuserDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UniuserDTO>(query.Query, query.Parameters);
                return result;
        }

        public UniuserDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UniuserDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<UniuserDTO> GetAllByUSERGRU_ID(int value )
        {
            var query = _query.FirstByUSERGRU_IDQuery(value );

                var result = _unitOfWork.Query<UniuserDTO>(query.Query,query.Parameters) as List<UniuserDTO>;
                return result;
        }

        public IEnumerable<UniuserDTO> GetAllByUNI_ID(int value )
        {
            var query = _query.FirstByUNI_IDQuery(value );

                var result = _unitOfWork.Query<UniuserDTO>(query.Query,query.Parameters) as List<UniuserDTO>;
                return result;
        }

        public IEnumerable<UniuserDTO> GetAllByUSE_ID(int value )
        {
            var query = _query.FirstByUSE_IDQuery(value );

                var result = _unitOfWork.Query<UniuserDTO>(query.Query,query.Parameters) as List<UniuserDTO>;
                return result;
        }

        public IEnumerable<UniuserDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<UniuserDTO>(query.Query,query.Parameters) as List<UniuserDTO>;
                return result;
        }

        public IEnumerable<UniuserDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<UniuserDTO>(query.Query,query.Parameters) as List<UniuserDTO>;
                return result;
        }

        public IEnumerable<UniuserDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<UniuserDTO>(query.Query,query.Parameters) as List<UniuserDTO>;
                return result;
        }

        public IEnumerable<UniuserDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<UniuserDTO>(query.Query,query.Parameters) as List<UniuserDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration