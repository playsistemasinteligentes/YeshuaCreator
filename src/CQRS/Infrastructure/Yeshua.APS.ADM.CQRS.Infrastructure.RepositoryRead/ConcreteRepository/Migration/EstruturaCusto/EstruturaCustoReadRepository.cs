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
    public partial class EstruturaCustoReadRepository : IEstruturaCustoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IEstruturaCustoQueryRead _query;

        public EstruturaCustoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IEstruturaCustoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<EstruturaCustoDTO> getEstruturaCusto(ICommandRead command )
         {
            if (command is Command.Read.EstruturaCustoReadCommand c)
                return getEstruturaCusto(c );
            throw new NotImplementedException();
        }
        private DataPagination<EstruturaCustoDTO> getEstruturaCusto(Command.Read.EstruturaCustoReadCommand command )
        {
            var query = _query.EstruturaCustoQuery(command );

                var itens = _unitOfWork.Query<EstruturaCustoDTO>(query.Query,query.Parameters);
                return new DataPagination<EstruturaCustoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<EstruturaCustoORD_IDDTO> getEstruturaCustoReadFKORD_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<EstruturaCustoORD_IDDTO> lista;
            var query = _query.EstruturaCustoORD_IDQuery(command );

                lista = _unitOfWork.Query<EstruturaCustoORD_IDDTO>(query.Query,query.Parameters) as List<EstruturaCustoORD_IDDTO>;
            return lista;
        }

        public IEnumerable<EstruturaCustoORD_IDDTO> getEstruturaCustoReadFKORD_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getEstruturaCustoReadFKORD_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<EstruturaCustoTenantIDDTO> getEstruturaCustoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<EstruturaCustoTenantIDDTO> lista;
            var query = _query.EstruturaCustoTenantIDQuery(command );

                lista = _unitOfWork.Query<EstruturaCustoTenantIDDTO>(query.Query,query.Parameters) as List<EstruturaCustoTenantIDDTO>;
            return lista;
        }

        public IEnumerable<EstruturaCustoTenantIDDTO> getEstruturaCustoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getEstruturaCustoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<EstruturaCustoUserIdDTO> getEstruturaCustoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<EstruturaCustoUserIdDTO> lista;
            var query = _query.EstruturaCustoUserIdQuery(command );

                lista = _unitOfWork.Query<EstruturaCustoUserIdDTO>(query.Query,query.Parameters) as List<EstruturaCustoUserIdDTO>;
            return lista;
        }

        public IEnumerable<EstruturaCustoUserIdDTO> getEstruturaCustoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getEstruturaCustoReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByEST_ID(int value )
        {
            var query = _query.ExistsByEST_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByITO_ID(int value )
        {
            var query = _query.ExistsByITO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_ID(string value )
        {
            var query = _query.ExistsByORD_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ID(string value )
        {
            var query = _query.ExistsByPRO_IDQuery(value );

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

        public bool ExistsByPRO_TIPO_CUSTO(string value )
        {
            var query = _query.ExistsByPRO_TIPO_CUSTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_GRUPO_CONTABIL(string value )
        {
            var query = _query.ExistsByPRO_GRUPO_CONTABILQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEST_ORDEM(int value )
        {
            var query = _query.ExistsByEST_ORDEMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEST_GRUPO(string value )
        {
            var query = _query.ExistsByEST_GRUPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEST_QUANT(Decimal value )
        {
            var query = _query.ExistsByEST_QUANTQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEST_VALOR_TOTAL(Decimal value )
        {
            var query = _query.ExistsByEST_VALOR_TOTALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEST_DATA_BASE(string value )
        {
            var query = _query.ExistsByEST_DATA_BASEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEST_BASE_PRODUCAO(Decimal value )
        {
            var query = _query.ExistsByEST_BASE_PRODUCAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByEST_NIVEL(Decimal value )
        {
            var query = _query.ExistsByEST_NIVELQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByFPR_SEQ_REPETICAO(int value )
        {
            var query = _query.ExistsByFPR_SEQ_REPETICAOQuery(value );

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

        public EstruturaCustoDTO FirstByEST_ID(int value )
        {
            var query = _query.FirstByEST_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstruturaCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstruturaCustoDTO FirstByITO_ID(int value )
        {
            var query = _query.FirstByITO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstruturaCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstruturaCustoDTO FirstByORD_ID(string value )
        {
            var query = _query.FirstByORD_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstruturaCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstruturaCustoDTO FirstByPRO_ID(string value )
        {
            var query = _query.FirstByPRO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstruturaCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstruturaCustoDTO FirstByPRO_ID_PRODUTO(string value )
        {
            var query = _query.FirstByPRO_ID_PRODUTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstruturaCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstruturaCustoDTO FirstByPRO_ID_COMPONENTE(string value )
        {
            var query = _query.FirstByPRO_ID_COMPONENTEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstruturaCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstruturaCustoDTO FirstByPRO_TIPO_CUSTO(string value )
        {
            var query = _query.FirstByPRO_TIPO_CUSTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstruturaCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstruturaCustoDTO FirstByPRO_GRUPO_CONTABIL(string value )
        {
            var query = _query.FirstByPRO_GRUPO_CONTABILQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstruturaCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstruturaCustoDTO FirstByEST_ORDEM(int value )
        {
            var query = _query.FirstByEST_ORDEMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstruturaCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstruturaCustoDTO FirstByEST_GRUPO(string value )
        {
            var query = _query.FirstByEST_GRUPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstruturaCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstruturaCustoDTO FirstByEST_QUANT(Decimal value )
        {
            var query = _query.FirstByEST_QUANTQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstruturaCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstruturaCustoDTO FirstByEST_VALOR_TOTAL(Decimal value )
        {
            var query = _query.FirstByEST_VALOR_TOTALQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstruturaCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstruturaCustoDTO FirstByEST_DATA_BASE(string value )
        {
            var query = _query.FirstByEST_DATA_BASEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstruturaCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstruturaCustoDTO FirstByEST_BASE_PRODUCAO(Decimal value )
        {
            var query = _query.FirstByEST_BASE_PRODUCAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstruturaCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstruturaCustoDTO FirstByEST_NIVEL(Decimal value )
        {
            var query = _query.FirstByEST_NIVELQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstruturaCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstruturaCustoDTO FirstByFPR_SEQ_REPETICAO(int value )
        {
            var query = _query.FirstByFPR_SEQ_REPETICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstruturaCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstruturaCustoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstruturaCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstruturaCustoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstruturaCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstruturaCustoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstruturaCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public EstruturaCustoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<EstruturaCustoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<EstruturaCustoDTO> GetAllByEST_ID(int value )
        {
            var query = _query.FirstByEST_IDQuery(value );

                var result = _unitOfWork.Query<EstruturaCustoDTO>(query.Query,query.Parameters) as List<EstruturaCustoDTO>;
                return result;
        }

        public IEnumerable<EstruturaCustoDTO> GetAllByITO_ID(int value )
        {
            var query = _query.FirstByITO_IDQuery(value );

                var result = _unitOfWork.Query<EstruturaCustoDTO>(query.Query,query.Parameters) as List<EstruturaCustoDTO>;
                return result;
        }

        public IEnumerable<EstruturaCustoDTO> GetAllByORD_ID(string value )
        {
            var query = _query.FirstByORD_IDQuery(value );

                var result = _unitOfWork.Query<EstruturaCustoDTO>(query.Query,query.Parameters) as List<EstruturaCustoDTO>;
                return result;
        }

        public IEnumerable<EstruturaCustoDTO> GetAllByPRO_ID(string value )
        {
            var query = _query.FirstByPRO_IDQuery(value );

                var result = _unitOfWork.Query<EstruturaCustoDTO>(query.Query,query.Parameters) as List<EstruturaCustoDTO>;
                return result;
        }

        public IEnumerable<EstruturaCustoDTO> GetAllByPRO_ID_PRODUTO(string value )
        {
            var query = _query.FirstByPRO_ID_PRODUTOQuery(value );

                var result = _unitOfWork.Query<EstruturaCustoDTO>(query.Query,query.Parameters) as List<EstruturaCustoDTO>;
                return result;
        }

        public IEnumerable<EstruturaCustoDTO> GetAllByPRO_ID_COMPONENTE(string value )
        {
            var query = _query.FirstByPRO_ID_COMPONENTEQuery(value );

                var result = _unitOfWork.Query<EstruturaCustoDTO>(query.Query,query.Parameters) as List<EstruturaCustoDTO>;
                return result;
        }

        public IEnumerable<EstruturaCustoDTO> GetAllByPRO_TIPO_CUSTO(string value )
        {
            var query = _query.FirstByPRO_TIPO_CUSTOQuery(value );

                var result = _unitOfWork.Query<EstruturaCustoDTO>(query.Query,query.Parameters) as List<EstruturaCustoDTO>;
                return result;
        }

        public IEnumerable<EstruturaCustoDTO> GetAllByPRO_GRUPO_CONTABIL(string value )
        {
            var query = _query.FirstByPRO_GRUPO_CONTABILQuery(value );

                var result = _unitOfWork.Query<EstruturaCustoDTO>(query.Query,query.Parameters) as List<EstruturaCustoDTO>;
                return result;
        }

        public IEnumerable<EstruturaCustoDTO> GetAllByEST_ORDEM(int value )
        {
            var query = _query.FirstByEST_ORDEMQuery(value );

                var result = _unitOfWork.Query<EstruturaCustoDTO>(query.Query,query.Parameters) as List<EstruturaCustoDTO>;
                return result;
        }

        public IEnumerable<EstruturaCustoDTO> GetAllByEST_GRUPO(string value )
        {
            var query = _query.FirstByEST_GRUPOQuery(value );

                var result = _unitOfWork.Query<EstruturaCustoDTO>(query.Query,query.Parameters) as List<EstruturaCustoDTO>;
                return result;
        }

        public IEnumerable<EstruturaCustoDTO> GetAllByEST_QUANT(Decimal value )
        {
            var query = _query.FirstByEST_QUANTQuery(value );

                var result = _unitOfWork.Query<EstruturaCustoDTO>(query.Query,query.Parameters) as List<EstruturaCustoDTO>;
                return result;
        }

        public IEnumerable<EstruturaCustoDTO> GetAllByEST_VALOR_TOTAL(Decimal value )
        {
            var query = _query.FirstByEST_VALOR_TOTALQuery(value );

                var result = _unitOfWork.Query<EstruturaCustoDTO>(query.Query,query.Parameters) as List<EstruturaCustoDTO>;
                return result;
        }

        public IEnumerable<EstruturaCustoDTO> GetAllByEST_DATA_BASE(string value )
        {
            var query = _query.FirstByEST_DATA_BASEQuery(value );

                var result = _unitOfWork.Query<EstruturaCustoDTO>(query.Query,query.Parameters) as List<EstruturaCustoDTO>;
                return result;
        }

        public IEnumerable<EstruturaCustoDTO> GetAllByEST_BASE_PRODUCAO(Decimal value )
        {
            var query = _query.FirstByEST_BASE_PRODUCAOQuery(value );

                var result = _unitOfWork.Query<EstruturaCustoDTO>(query.Query,query.Parameters) as List<EstruturaCustoDTO>;
                return result;
        }

        public IEnumerable<EstruturaCustoDTO> GetAllByEST_NIVEL(Decimal value )
        {
            var query = _query.FirstByEST_NIVELQuery(value );

                var result = _unitOfWork.Query<EstruturaCustoDTO>(query.Query,query.Parameters) as List<EstruturaCustoDTO>;
                return result;
        }

        public IEnumerable<EstruturaCustoDTO> GetAllByFPR_SEQ_REPETICAO(int value )
        {
            var query = _query.FirstByFPR_SEQ_REPETICAOQuery(value );

                var result = _unitOfWork.Query<EstruturaCustoDTO>(query.Query,query.Parameters) as List<EstruturaCustoDTO>;
                return result;
        }

        public IEnumerable<EstruturaCustoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<EstruturaCustoDTO>(query.Query,query.Parameters) as List<EstruturaCustoDTO>;
                return result;
        }

        public IEnumerable<EstruturaCustoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<EstruturaCustoDTO>(query.Query,query.Parameters) as List<EstruturaCustoDTO>;
                return result;
        }

        public IEnumerable<EstruturaCustoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<EstruturaCustoDTO>(query.Query,query.Parameters) as List<EstruturaCustoDTO>;
                return result;
        }

        public IEnumerable<EstruturaCustoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<EstruturaCustoDTO>(query.Query,query.Parameters) as List<EstruturaCustoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration