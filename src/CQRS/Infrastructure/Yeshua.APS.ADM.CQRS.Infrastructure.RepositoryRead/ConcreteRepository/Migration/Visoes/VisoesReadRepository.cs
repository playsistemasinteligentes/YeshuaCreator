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
    public partial class VisoesReadRepository : IVisoesReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IVisoesQueryRead _query;

        public VisoesReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IVisoesQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<VisoesDTO> getVisoes(ICommandRead command )
         {
            if (command is Command.Read.VisoesReadCommand c)
                return getVisoes(c );
            throw new NotImplementedException();
        }
        private DataPagination<VisoesDTO> getVisoes(Command.Read.VisoesReadCommand command )
        {
            var query = _query.VisoesQuery(command );

                var itens = _unitOfWork.Query<VisoesDTO>(query.Query,query.Parameters);
                return new DataPagination<VisoesDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<VisoesVIS_PLANIDDTO> getVisoesReadFKVIS_PLANID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<VisoesVIS_PLANIDDTO> lista;
            var query = _query.VisoesVIS_PLANIDQuery(command );

                lista = _unitOfWork.Query<VisoesVIS_PLANIDDTO>(query.Query,query.Parameters) as List<VisoesVIS_PLANIDDTO>;
            return lista;
        }

        public IEnumerable<VisoesVIS_PLANIDDTO> getVisoesReadFKVIS_PLANID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getVisoesReadFKVIS_PLANID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<VisoesCAB_IDDTO> getVisoesReadFKCAB_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<VisoesCAB_IDDTO> lista;
            var query = _query.VisoesCAB_IDQuery(command );

                lista = _unitOfWork.Query<VisoesCAB_IDDTO>(query.Query,query.Parameters) as List<VisoesCAB_IDDTO>;
            return lista;
        }

        public IEnumerable<VisoesCAB_IDDTO> getVisoesReadFKCAB_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getVisoesReadFKCAB_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<VisoesTenantIDDTO> getVisoesReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<VisoesTenantIDDTO> lista;
            var query = _query.VisoesTenantIDQuery(command );

                lista = _unitOfWork.Query<VisoesTenantIDDTO>(query.Query,query.Parameters) as List<VisoesTenantIDDTO>;
            return lista;
        }

        public IEnumerable<VisoesTenantIDDTO> getVisoesReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getVisoesReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<VisoesUserIdDTO> getVisoesReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<VisoesUserIdDTO> lista;
            var query = _query.VisoesUserIdQuery(command );

                lista = _unitOfWork.Query<VisoesUserIdDTO>(query.Query,query.Parameters) as List<VisoesUserIdDTO>;
            return lista;
        }

        public IEnumerable<VisoesUserIdDTO> getVisoesReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getVisoesReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByVIS_ID(int value )
        {
            var query = _query.ExistsByVIS_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByVIS_PLANID(int value )
        {
            var query = _query.ExistsByVIS_PLANIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByVIS_FORMULA(string value )
        {
            var query = _query.ExistsByVIS_FORMULAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAB_ID(int value )
        {
            var query = _query.ExistsByCAB_IDQuery(value );

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

        public VisoesDTO FirstByVIS_ID(int value )
        {
            var query = _query.FirstByVIS_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VisoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public VisoesDTO FirstByVIS_PLANID(int value )
        {
            var query = _query.FirstByVIS_PLANIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VisoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public VisoesDTO FirstByVIS_FORMULA(string value )
        {
            var query = _query.FirstByVIS_FORMULAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VisoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public VisoesDTO FirstByCAB_ID(int value )
        {
            var query = _query.FirstByCAB_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VisoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public VisoesDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VisoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public VisoesDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VisoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public VisoesDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VisoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public VisoesDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<VisoesDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<VisoesDTO> GetAllByVIS_ID(int value )
        {
            var query = _query.FirstByVIS_IDQuery(value );

                var result = _unitOfWork.Query<VisoesDTO>(query.Query,query.Parameters) as List<VisoesDTO>;
                return result;
        }

        public IEnumerable<VisoesDTO> GetAllByVIS_PLANID(int value )
        {
            var query = _query.FirstByVIS_PLANIDQuery(value );

                var result = _unitOfWork.Query<VisoesDTO>(query.Query,query.Parameters) as List<VisoesDTO>;
                return result;
        }

        public IEnumerable<VisoesDTO> GetAllByVIS_FORMULA(string value )
        {
            var query = _query.FirstByVIS_FORMULAQuery(value );

                var result = _unitOfWork.Query<VisoesDTO>(query.Query,query.Parameters) as List<VisoesDTO>;
                return result;
        }

        public IEnumerable<VisoesDTO> GetAllByCAB_ID(int value )
        {
            var query = _query.FirstByCAB_IDQuery(value );

                var result = _unitOfWork.Query<VisoesDTO>(query.Query,query.Parameters) as List<VisoesDTO>;
                return result;
        }

        public IEnumerable<VisoesDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<VisoesDTO>(query.Query,query.Parameters) as List<VisoesDTO>;
                return result;
        }

        public IEnumerable<VisoesDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<VisoesDTO>(query.Query,query.Parameters) as List<VisoesDTO>;
                return result;
        }

        public IEnumerable<VisoesDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<VisoesDTO>(query.Query,query.Parameters) as List<VisoesDTO>;
                return result;
        }

        public IEnumerable<VisoesDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<VisoesDTO>(query.Query,query.Parameters) as List<VisoesDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration