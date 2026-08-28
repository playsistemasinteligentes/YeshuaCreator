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
    public partial class UnidadeReadRepository : IUnidadeReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IUnidadeQueryRead _query;

        public UnidadeReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IUnidadeQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<UnidadeDTO> getUnidade(ICommandRead command )
         {
            if (command is Command.Read.UnidadeReadCommand c)
                return getUnidade(c );
            throw new NotImplementedException();
        }
        private DataPagination<UnidadeDTO> getUnidade(Command.Read.UnidadeReadCommand command )
        {
            var query = _query.UnidadeQuery(command );

                var itens = _unitOfWork.Query<UnidadeDTO>(query.Query,query.Parameters);
                return new DataPagination<UnidadeDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<UnidadeTenantIDDTO> getUnidadeReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<UnidadeTenantIDDTO> lista;
            var query = _query.UnidadeTenantIDQuery(command );

                lista = _unitOfWork.Query<UnidadeTenantIDDTO>(query.Query,query.Parameters) as List<UnidadeTenantIDDTO>;
            return lista;
        }

        public IEnumerable<UnidadeTenantIDDTO> getUnidadeReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getUnidadeReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<UnidadeUserIdDTO> getUnidadeReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<UnidadeUserIdDTO> lista;
            var query = _query.UnidadeUserIdQuery(command );

                lista = _unitOfWork.Query<UnidadeUserIdDTO>(query.Query,query.Parameters) as List<UnidadeUserIdDTO>;
            return lista;
        }

        public IEnumerable<UnidadeUserIdDTO> getUnidadeReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getUnidadeReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByUNI_ID(int value )
        {
            var query = _query.ExistsByUNI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByDEESCRICAO(string value )
        {
            var query = _query.ExistsByDEESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUN(string value )
        {
            var query = _query.ExistsByUNQuery(value );

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

        public UnidadeDTO FirstByUNI_ID(int value )
        {
            var query = _query.FirstByUNI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UnidadeDTO>(query.Query, query.Parameters);
                return result;
        }

        public UnidadeDTO FirstByDEESCRICAO(string value )
        {
            var query = _query.FirstByDEESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UnidadeDTO>(query.Query, query.Parameters);
                return result;
        }

        public UnidadeDTO FirstByUN(string value )
        {
            var query = _query.FirstByUNQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UnidadeDTO>(query.Query, query.Parameters);
                return result;
        }

        public UnidadeDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UnidadeDTO>(query.Query, query.Parameters);
                return result;
        }

        public UnidadeDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UnidadeDTO>(query.Query, query.Parameters);
                return result;
        }

        public UnidadeDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UnidadeDTO>(query.Query, query.Parameters);
                return result;
        }

        public UnidadeDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<UnidadeDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<UnidadeDTO> GetAllByUNI_ID(int value )
        {
            var query = _query.FirstByUNI_IDQuery(value );

                var result = _unitOfWork.Query<UnidadeDTO>(query.Query,query.Parameters) as List<UnidadeDTO>;
                return result;
        }

        public IEnumerable<UnidadeDTO> GetAllByDEESCRICAO(string value )
        {
            var query = _query.FirstByDEESCRICAOQuery(value );

                var result = _unitOfWork.Query<UnidadeDTO>(query.Query,query.Parameters) as List<UnidadeDTO>;
                return result;
        }

        public IEnumerable<UnidadeDTO> GetAllByUN(string value )
        {
            var query = _query.FirstByUNQuery(value );

                var result = _unitOfWork.Query<UnidadeDTO>(query.Query,query.Parameters) as List<UnidadeDTO>;
                return result;
        }

        public IEnumerable<UnidadeDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<UnidadeDTO>(query.Query,query.Parameters) as List<UnidadeDTO>;
                return result;
        }

        public IEnumerable<UnidadeDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<UnidadeDTO>(query.Query,query.Parameters) as List<UnidadeDTO>;
                return result;
        }

        public IEnumerable<UnidadeDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<UnidadeDTO>(query.Query,query.Parameters) as List<UnidadeDTO>;
                return result;
        }

        public IEnumerable<UnidadeDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<UnidadeDTO>(query.Query,query.Parameters) as List<UnidadeDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration