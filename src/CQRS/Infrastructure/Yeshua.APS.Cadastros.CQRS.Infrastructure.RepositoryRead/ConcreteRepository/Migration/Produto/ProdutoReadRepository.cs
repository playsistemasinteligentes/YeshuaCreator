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
    public partial class ProdutoReadRepository : IProdutoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IProdutoQueryRead _query;

        public ProdutoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IProdutoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<ProdutoDTO> getProduto(ICommandRead command )
         {
            if (command is Command.Read.ProdutoReadCommand c)
                return getProduto(c );
            throw new NotImplementedException();
        }
        private DataPagination<ProdutoDTO> getProduto(Command.Read.ProdutoReadCommand command )
        {
            var query = _query.ProdutoQuery(command );

                var itens = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters);
                return new DataPagination<ProdutoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<ProdutoTenantIDDTO> getProdutoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ProdutoTenantIDDTO> lista;
            var query = _query.ProdutoTenantIDQuery(command );

                lista = _unitOfWork.Query<ProdutoTenantIDDTO>(query.Query,query.Parameters) as List<ProdutoTenantIDDTO>;
            return lista;
        }

        public IEnumerable<ProdutoTenantIDDTO> getProdutoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getProdutoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ProdutoUserIdDTO> getProdutoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ProdutoUserIdDTO> lista;
            var query = _query.ProdutoUserIdQuery(command );

                lista = _unitOfWork.Query<ProdutoUserIdDTO>(query.Query,query.Parameters) as List<ProdutoUserIdDTO>;
            return lista;
        }

        public IEnumerable<ProdutoUserIdDTO> getProdutoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getProdutoReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByPRO_ID(string value )
        {
            var query = _query.ExistsByPRO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_DESCRICAO(string value )
        {
            var query = _query.ExistsByPRO_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_STATUS(string value )
        {
            var query = _query.ExistsByPRO_STATUSQuery(value );

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

        public ProdutoDTO FirstByPRO_ID(string value )
        {
            var query = _query.FirstByPRO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_DESCRICAO(string value )
        {
            var query = _query.FirstByPRO_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByPRO_STATUS(string value )
        {
            var query = _query.FirstByPRO_STATUSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ProdutoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_ID(string value )
        {
            var query = _query.FirstByPRO_IDQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_DESCRICAO(string value )
        {
            var query = _query.FirstByPRO_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByPRO_STATUS(string value )
        {
            var query = _query.FirstByPRO_STATUSQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

        public IEnumerable<ProdutoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<ProdutoDTO>(query.Query,query.Parameters) as List<ProdutoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration