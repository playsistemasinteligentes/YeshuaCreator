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
    public partial class EstruturaProdutoReadRepository : IEstruturaProdutoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IEstruturaProdutoQueryRead _query;

        public EstruturaProdutoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IEstruturaProdutoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<EstruturaProdutoDTO> getEstruturaProduto(ICommandRead command )
         {
            if (command is Command.Read.EstruturaProdutoReadCommand c)
                return getEstruturaProduto(c );
            throw new NotImplementedException();
        }
        private DataPagination<EstruturaProdutoDTO> getEstruturaProduto(Command.Read.EstruturaProdutoReadCommand command )
        {
            var query = _query.EstruturaProdutoQuery(command );

                var itens = _unitOfWork.Query<EstruturaProdutoDTO>(query.Query,query.Parameters);
                return new DataPagination<EstruturaProdutoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<EstruturaProdutoTenantIDDTO> getEstruturaProdutoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<EstruturaProdutoTenantIDDTO> lista;
            var query = _query.EstruturaProdutoTenantIDQuery(command );

                lista = _unitOfWork.Query<EstruturaProdutoTenantIDDTO>(query.Query,query.Parameters) as List<EstruturaProdutoTenantIDDTO>;
            return lista;
        }

        public IEnumerable<EstruturaProdutoTenantIDDTO> getEstruturaProdutoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getEstruturaProdutoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<EstruturaProdutoUserIdDTO> getEstruturaProdutoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<EstruturaProdutoUserIdDTO> lista;
            var query = _query.EstruturaProdutoUserIdQuery(command );

                lista = _unitOfWork.Query<EstruturaProdutoUserIdDTO>(query.Query,query.Parameters) as List<EstruturaProdutoUserIdDTO>;
            return lista;
        }

        public IEnumerable<EstruturaProdutoUserIdDTO> getEstruturaProdutoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getEstruturaProdutoReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEST_DATA_VALIDADE(DateTime value )
        {
            var query = _query.ExistsByEST_DATA_VALIDADEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ID_PRODUTO(string value )
        {
            var query = _query.ExistsByPRO_ID_PRODUTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ID_COMPONENTE(string value )
        {
            var query = _query.ExistsByPRO_ID_COMPONENTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEST_QUANT(Decimal value )
        {
            var query = _query.ExistsByEST_QUANTQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEST_DATA_INCLUSAO(DateTime value )
        {
            var query = _query.ExistsByEST_DATA_INCLUSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEST_BASE_PRODUCAO(Decimal value )
        {
            var query = _query.ExistsByEST_BASE_PRODUCAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEST_TIPO_REQUISICAO(string value )
        {
            var query = _query.ExistsByEST_TIPO_REQUISICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEST_CODIGO_DE_EXCECAO(string value )
        {
            var query = _query.ExistsByEST_CODIGO_DE_EXCECAOQuery(value );

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

        public EstruturaProdutoDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstruturaProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstruturaProdutoDTO FirstByEST_DATA_VALIDADE(DateTime value )
        {
            var query = _query.FirstByEST_DATA_VALIDADEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstruturaProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstruturaProdutoDTO FirstByPRO_ID_PRODUTO(string value )
        {
            var query = _query.FirstByPRO_ID_PRODUTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstruturaProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstruturaProdutoDTO FirstByPRO_ID_COMPONENTE(string value )
        {
            var query = _query.FirstByPRO_ID_COMPONENTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstruturaProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstruturaProdutoDTO FirstByEST_QUANT(Decimal value )
        {
            var query = _query.FirstByEST_QUANTQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstruturaProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstruturaProdutoDTO FirstByEST_DATA_INCLUSAO(DateTime value )
        {
            var query = _query.FirstByEST_DATA_INCLUSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstruturaProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstruturaProdutoDTO FirstByEST_BASE_PRODUCAO(Decimal value )
        {
            var query = _query.FirstByEST_BASE_PRODUCAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstruturaProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstruturaProdutoDTO FirstByEST_TIPO_REQUISICAO(string value )
        {
            var query = _query.FirstByEST_TIPO_REQUISICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstruturaProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstruturaProdutoDTO FirstByEST_CODIGO_DE_EXCECAO(string value )
        {
            var query = _query.FirstByEST_CODIGO_DE_EXCECAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstruturaProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstruturaProdutoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstruturaProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstruturaProdutoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstruturaProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstruturaProdutoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstruturaProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstruturaProdutoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstruturaProdutoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<EstruturaProdutoDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<EstruturaProdutoDTO>(query.Query,query.Parameters) as List<EstruturaProdutoDTO>;
                return result;
        }

        public IEnumerable<EstruturaProdutoDTO> GetAllByEST_DATA_VALIDADE(DateTime value )
        {
            var query = _query.FirstByEST_DATA_VALIDADEQuery(value );

                var result = _unitOfWork.Query<EstruturaProdutoDTO>(query.Query,query.Parameters) as List<EstruturaProdutoDTO>;
                return result;
        }

        public IEnumerable<EstruturaProdutoDTO> GetAllByPRO_ID_PRODUTO(string value )
        {
            var query = _query.FirstByPRO_ID_PRODUTOQuery(value );

                var result = _unitOfWork.Query<EstruturaProdutoDTO>(query.Query,query.Parameters) as List<EstruturaProdutoDTO>;
                return result;
        }

        public IEnumerable<EstruturaProdutoDTO> GetAllByPRO_ID_COMPONENTE(string value )
        {
            var query = _query.FirstByPRO_ID_COMPONENTEQuery(value );

                var result = _unitOfWork.Query<EstruturaProdutoDTO>(query.Query,query.Parameters) as List<EstruturaProdutoDTO>;
                return result;
        }

        public IEnumerable<EstruturaProdutoDTO> GetAllByEST_QUANT(Decimal value )
        {
            var query = _query.FirstByEST_QUANTQuery(value );

                var result = _unitOfWork.Query<EstruturaProdutoDTO>(query.Query,query.Parameters) as List<EstruturaProdutoDTO>;
                return result;
        }

        public IEnumerable<EstruturaProdutoDTO> GetAllByEST_DATA_INCLUSAO(DateTime value )
        {
            var query = _query.FirstByEST_DATA_INCLUSAOQuery(value );

                var result = _unitOfWork.Query<EstruturaProdutoDTO>(query.Query,query.Parameters) as List<EstruturaProdutoDTO>;
                return result;
        }

        public IEnumerable<EstruturaProdutoDTO> GetAllByEST_BASE_PRODUCAO(Decimal value )
        {
            var query = _query.FirstByEST_BASE_PRODUCAOQuery(value );

                var result = _unitOfWork.Query<EstruturaProdutoDTO>(query.Query,query.Parameters) as List<EstruturaProdutoDTO>;
                return result;
        }

        public IEnumerable<EstruturaProdutoDTO> GetAllByEST_TIPO_REQUISICAO(string value )
        {
            var query = _query.FirstByEST_TIPO_REQUISICAOQuery(value );

                var result = _unitOfWork.Query<EstruturaProdutoDTO>(query.Query,query.Parameters) as List<EstruturaProdutoDTO>;
                return result;
        }

        public IEnumerable<EstruturaProdutoDTO> GetAllByEST_CODIGO_DE_EXCECAO(string value )
        {
            var query = _query.FirstByEST_CODIGO_DE_EXCECAOQuery(value );

                var result = _unitOfWork.Query<EstruturaProdutoDTO>(query.Query,query.Parameters) as List<EstruturaProdutoDTO>;
                return result;
        }

        public IEnumerable<EstruturaProdutoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<EstruturaProdutoDTO>(query.Query,query.Parameters) as List<EstruturaProdutoDTO>;
                return result;
        }

        public IEnumerable<EstruturaProdutoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<EstruturaProdutoDTO>(query.Query,query.Parameters) as List<EstruturaProdutoDTO>;
                return result;
        }

        public IEnumerable<EstruturaProdutoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<EstruturaProdutoDTO>(query.Query,query.Parameters) as List<EstruturaProdutoDTO>;
                return result;
        }

        public IEnumerable<EstruturaProdutoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<EstruturaProdutoDTO>(query.Query,query.Parameters) as List<EstruturaProdutoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration