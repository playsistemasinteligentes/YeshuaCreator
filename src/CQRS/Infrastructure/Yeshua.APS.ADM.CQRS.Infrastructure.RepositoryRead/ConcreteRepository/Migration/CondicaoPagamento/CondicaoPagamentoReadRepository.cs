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
    public partial class CondicaoPagamentoReadRepository : ICondicaoPagamentoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly ICondicaoPagamentoQueryRead _query;

        public CondicaoPagamentoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,ICondicaoPagamentoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetCondicaoPagamentoCustom(Command.Read.CondicaoPagamentoReadCommand command, ref DataPagination<CondicaoPagamentoDTO> result, ref bool handled);

        public DataPagination<CondicaoPagamentoDTO> getCondicaoPagamento(ICommandRead command )
         {
            if (command is Command.Read.CondicaoPagamentoReadCommand c)
                return getCondicaoPagamento(c );
            throw new NotImplementedException();
        }
        private DataPagination<CondicaoPagamentoDTO> getCondicaoPagamento(Command.Read.CondicaoPagamentoReadCommand command )
        {
            DataPagination<CondicaoPagamentoDTO> customResult = null;
            var customHandled = false;
            TryGetCondicaoPagamentoCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.CondicaoPagamentoQuery(command );

                var itens = _unitOfWork.Query<CondicaoPagamentoDTO>(query.Query,query.Parameters);
                return new DataPagination<CondicaoPagamentoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<CondicaoPagamentoTenantIDDTO> getCondicaoPagamentoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CondicaoPagamentoTenantIDDTO> lista;
            var query = _query.CondicaoPagamentoTenantIDQuery(command );

                lista = _unitOfWork.Query<CondicaoPagamentoTenantIDDTO>(query.Query,query.Parameters) as List<CondicaoPagamentoTenantIDDTO>;
            return lista;
        }

        public IEnumerable<CondicaoPagamentoTenantIDDTO> getCondicaoPagamentoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCondicaoPagamentoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<CondicaoPagamentoUserIdDTO> getCondicaoPagamentoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<CondicaoPagamentoUserIdDTO> lista;
            var query = _query.CondicaoPagamentoUserIdQuery(command );

                lista = _unitOfWork.Query<CondicaoPagamentoUserIdDTO>(query.Query,query.Parameters) as List<CondicaoPagamentoUserIdDTO>;
            return lista;
        }

        public IEnumerable<CondicaoPagamentoUserIdDTO> getCondicaoPagamentoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getCondicaoPagamentoReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCON_ID(string value )
        {
            var query = _query.ExistsByCON_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCON_DESCRICAO(string value )
        {
            var query = _query.ExistsByCON_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCON_PARCELAS(int value )
        {
            var query = _query.ExistsByCON_PARCELASQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCON_VALOR_ACRECIMO(Decimal value )
        {
            var query = _query.ExistsByCON_VALOR_ACRECIMOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCON_INTEGRACAO_ERP(string value )
        {
            var query = _query.ExistsByCON_INTEGRACAO_ERPQuery(value );

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

        public CondicaoPagamentoDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CondicaoPagamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CondicaoPagamentoDTO FirstByCON_ID(string value )
        {
            var query = _query.FirstByCON_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CondicaoPagamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CondicaoPagamentoDTO FirstByCON_DESCRICAO(string value )
        {
            var query = _query.FirstByCON_DESCRICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CondicaoPagamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CondicaoPagamentoDTO FirstByCON_PARCELAS(int value )
        {
            var query = _query.FirstByCON_PARCELASQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CondicaoPagamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CondicaoPagamentoDTO FirstByCON_VALOR_ACRECIMO(Decimal value )
        {
            var query = _query.FirstByCON_VALOR_ACRECIMOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CondicaoPagamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CondicaoPagamentoDTO FirstByCON_INTEGRACAO_ERP(string value )
        {
            var query = _query.FirstByCON_INTEGRACAO_ERPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CondicaoPagamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CondicaoPagamentoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CondicaoPagamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CondicaoPagamentoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CondicaoPagamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CondicaoPagamentoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CondicaoPagamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public CondicaoPagamentoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<CondicaoPagamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<CondicaoPagamentoDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<CondicaoPagamentoDTO>(query.Query,query.Parameters) as List<CondicaoPagamentoDTO>;
                return result;
        }

        public IEnumerable<CondicaoPagamentoDTO> GetAllByCON_ID(string value )
        {
            var query = _query.FirstByCON_IDQuery(value );

                var result = _unitOfWork.Query<CondicaoPagamentoDTO>(query.Query,query.Parameters) as List<CondicaoPagamentoDTO>;
                return result;
        }

        public IEnumerable<CondicaoPagamentoDTO> GetAllByCON_DESCRICAO(string value )
        {
            var query = _query.FirstByCON_DESCRICAOQuery(value );

                var result = _unitOfWork.Query<CondicaoPagamentoDTO>(query.Query,query.Parameters) as List<CondicaoPagamentoDTO>;
                return result;
        }

        public IEnumerable<CondicaoPagamentoDTO> GetAllByCON_PARCELAS(int value )
        {
            var query = _query.FirstByCON_PARCELASQuery(value );

                var result = _unitOfWork.Query<CondicaoPagamentoDTO>(query.Query,query.Parameters) as List<CondicaoPagamentoDTO>;
                return result;
        }

        public IEnumerable<CondicaoPagamentoDTO> GetAllByCON_VALOR_ACRECIMO(Decimal value )
        {
            var query = _query.FirstByCON_VALOR_ACRECIMOQuery(value );

                var result = _unitOfWork.Query<CondicaoPagamentoDTO>(query.Query,query.Parameters) as List<CondicaoPagamentoDTO>;
                return result;
        }

        public IEnumerable<CondicaoPagamentoDTO> GetAllByCON_INTEGRACAO_ERP(string value )
        {
            var query = _query.FirstByCON_INTEGRACAO_ERPQuery(value );

                var result = _unitOfWork.Query<CondicaoPagamentoDTO>(query.Query,query.Parameters) as List<CondicaoPagamentoDTO>;
                return result;
        }

        public IEnumerable<CondicaoPagamentoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<CondicaoPagamentoDTO>(query.Query,query.Parameters) as List<CondicaoPagamentoDTO>;
                return result;
        }

        public IEnumerable<CondicaoPagamentoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<CondicaoPagamentoDTO>(query.Query,query.Parameters) as List<CondicaoPagamentoDTO>;
                return result;
        }

        public IEnumerable<CondicaoPagamentoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<CondicaoPagamentoDTO>(query.Query,query.Parameters) as List<CondicaoPagamentoDTO>;
                return result;
        }

        public IEnumerable<CondicaoPagamentoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<CondicaoPagamentoDTO>(query.Query,query.Parameters) as List<CondicaoPagamentoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration