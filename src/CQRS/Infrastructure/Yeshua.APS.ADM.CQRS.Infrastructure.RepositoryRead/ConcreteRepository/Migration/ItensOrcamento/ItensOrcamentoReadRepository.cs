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
    public partial class ItensOrcamentoReadRepository : IItensOrcamentoReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IItensOrcamentoQueryRead _query;

        public ItensOrcamentoReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IItensOrcamentoQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        partial void TryGetItensOrcamentoCustom(Command.Read.ItensOrcamentoReadCommand command, ref DataPagination<ItensOrcamentoDTO> result, ref bool handled);

        public DataPagination<ItensOrcamentoDTO> getItensOrcamento(ICommandRead command )
         {
            if (command is Command.Read.ItensOrcamentoReadCommand c)
                return getItensOrcamento(c );
            throw new NotImplementedException();
        }
        private DataPagination<ItensOrcamentoDTO> getItensOrcamento(Command.Read.ItensOrcamentoReadCommand command )
        {
            DataPagination<ItensOrcamentoDTO> customResult = null;
            var customHandled = false;
            TryGetItensOrcamentoCustom(command, ref customResult, ref customHandled);
            if (customHandled)
                return customResult;

            var query = _query.ItensOrcamentoQuery(command );

                var itens = _unitOfWork.Query<ItensOrcamentoDTO>(query.Query,query.Parameters);
                return new DataPagination<ItensOrcamentoDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<ItensOrcamentoGRP_ID_COMPOSICAODTO> getItensOrcamentoReadFKGRP_ID_COMPOSICAO(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ItensOrcamentoGRP_ID_COMPOSICAODTO> lista;
            var query = _query.ItensOrcamentoGRP_ID_COMPOSICAOQuery(command );

                lista = _unitOfWork.Query<ItensOrcamentoGRP_ID_COMPOSICAODTO>(query.Query,query.Parameters) as List<ItensOrcamentoGRP_ID_COMPOSICAODTO>;
            return lista;
        }

        public IEnumerable<ItensOrcamentoGRP_ID_COMPOSICAODTO> getItensOrcamentoReadFKGRP_ID_COMPOSICAO(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getItensOrcamentoReadFKGRP_ID_COMPOSICAO(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ItensOrcamentoTenantIDDTO> getItensOrcamentoReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ItensOrcamentoTenantIDDTO> lista;
            var query = _query.ItensOrcamentoTenantIDQuery(command );

                lista = _unitOfWork.Query<ItensOrcamentoTenantIDDTO>(query.Query,query.Parameters) as List<ItensOrcamentoTenantIDDTO>;
            return lista;
        }

        public IEnumerable<ItensOrcamentoTenantIDDTO> getItensOrcamentoReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getItensOrcamentoReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<ItensOrcamentoUserIdDTO> getItensOrcamentoReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<ItensOrcamentoUserIdDTO> lista;
            var query = _query.ItensOrcamentoUserIdQuery(command );

                lista = _unitOfWork.Query<ItensOrcamentoUserIdDTO>(query.Query,query.Parameters) as List<ItensOrcamentoUserIdDTO>;
            return lista;
        }

        public IEnumerable<ItensOrcamentoUserIdDTO> getItensOrcamentoReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getItensOrcamentoReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsById(int value )
        {
            var query = _query.ExistsByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByITO_ID(int value )
        {
            var query = _query.ExistsByITO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORC_ID(int value )
        {
            var query = _query.ExistsByORC_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTIP_ID(int value )
        {
            var query = _query.ExistsByTIP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ID(string value )
        {
            var query = _query.ExistsByPRO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByITO_OBS(string value )
        {
            var query = _query.ExistsByITO_OBSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByITO_QUANTIDADE(Decimal value )
        {
            var query = _query.ExistsByITO_QUANTIDADEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByITO_CUSTO(Decimal value )
        {
            var query = _query.ExistsByITO_CUSTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByITO_MARGEM(Decimal value )
        {
            var query = _query.ExistsByITO_MARGEMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByITO_VALOR_UNITARIO(Decimal value )
        {
            var query = _query.ExistsByITO_VALOR_UNITARIOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByITO_VERSSAO_CUSTO(DateTime value )
        {
            var query = _query.ExistsByITO_VERSSAO_CUSTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByITO_STATUS(string value )
        {
            var query = _query.ExistsByITO_STATUSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByITO_ERP_CUSTOS_FIXOS(Decimal value )
        {
            var query = _query.ExistsByITO_ERP_CUSTOS_FIXOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByITO_ERP_CUSTOS_VARIAVEIS(Decimal value )
        {
            var query = _query.ExistsByITO_ERP_CUSTOS_VARIAVEISQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByITO_ERP_DESPESAS_VAR_VENDA(Decimal value )
        {
            var query = _query.ExistsByITO_ERP_DESPESAS_VAR_VENDAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByITO_ERP_IMPOSTOS(Decimal value )
        {
            var query = _query.ExistsByITO_ERP_IMPOSTOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_ID_COMPOSICAO(string value )
        {
            var query = _query.ExistsByGRP_ID_COMPOSICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByITO_LARGURA(Decimal value )
        {
            var query = _query.ExistsByITO_LARGURAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByITO_COMPRIMENTO(Decimal value )
        {
            var query = _query.ExistsByITO_COMPRIMENTOQuery(value );

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

        public ItensOrcamentoDTO FirstById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensOrcamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensOrcamentoDTO FirstByITO_ID(int value )
        {
            var query = _query.FirstByITO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensOrcamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensOrcamentoDTO FirstByORC_ID(int value )
        {
            var query = _query.FirstByORC_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensOrcamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensOrcamentoDTO FirstByTIP_ID(int value )
        {
            var query = _query.FirstByTIP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensOrcamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensOrcamentoDTO FirstByPRO_ID(string value )
        {
            var query = _query.FirstByPRO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensOrcamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensOrcamentoDTO FirstByITO_OBS(string value )
        {
            var query = _query.FirstByITO_OBSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensOrcamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensOrcamentoDTO FirstByITO_QUANTIDADE(Decimal value )
        {
            var query = _query.FirstByITO_QUANTIDADEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensOrcamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensOrcamentoDTO FirstByITO_CUSTO(Decimal value )
        {
            var query = _query.FirstByITO_CUSTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensOrcamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensOrcamentoDTO FirstByITO_MARGEM(Decimal value )
        {
            var query = _query.FirstByITO_MARGEMQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensOrcamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensOrcamentoDTO FirstByITO_VALOR_UNITARIO(Decimal value )
        {
            var query = _query.FirstByITO_VALOR_UNITARIOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensOrcamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensOrcamentoDTO FirstByITO_VERSSAO_CUSTO(DateTime value )
        {
            var query = _query.FirstByITO_VERSSAO_CUSTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensOrcamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensOrcamentoDTO FirstByITO_STATUS(string value )
        {
            var query = _query.FirstByITO_STATUSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensOrcamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensOrcamentoDTO FirstByITO_ERP_CUSTOS_FIXOS(Decimal value )
        {
            var query = _query.FirstByITO_ERP_CUSTOS_FIXOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensOrcamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensOrcamentoDTO FirstByITO_ERP_CUSTOS_VARIAVEIS(Decimal value )
        {
            var query = _query.FirstByITO_ERP_CUSTOS_VARIAVEISQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensOrcamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensOrcamentoDTO FirstByITO_ERP_DESPESAS_VAR_VENDA(Decimal value )
        {
            var query = _query.FirstByITO_ERP_DESPESAS_VAR_VENDAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensOrcamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensOrcamentoDTO FirstByITO_ERP_IMPOSTOS(Decimal value )
        {
            var query = _query.FirstByITO_ERP_IMPOSTOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensOrcamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensOrcamentoDTO FirstByGRP_ID_COMPOSICAO(string value )
        {
            var query = _query.FirstByGRP_ID_COMPOSICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensOrcamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensOrcamentoDTO FirstByITO_LARGURA(Decimal value )
        {
            var query = _query.FirstByITO_LARGURAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensOrcamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensOrcamentoDTO FirstByITO_COMPRIMENTO(Decimal value )
        {
            var query = _query.FirstByITO_COMPRIMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensOrcamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensOrcamentoDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensOrcamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensOrcamentoDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensOrcamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensOrcamentoDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensOrcamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public ItensOrcamentoDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<ItensOrcamentoDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<ItensOrcamentoDTO> GetAllById(int value )
        {
            var query = _query.FirstByIdQuery(value );

                var result = _unitOfWork.Query<ItensOrcamentoDTO>(query.Query,query.Parameters) as List<ItensOrcamentoDTO>;
                return result;
        }

        public IEnumerable<ItensOrcamentoDTO> GetAllByITO_ID(int value )
        {
            var query = _query.FirstByITO_IDQuery(value );

                var result = _unitOfWork.Query<ItensOrcamentoDTO>(query.Query,query.Parameters) as List<ItensOrcamentoDTO>;
                return result;
        }

        public IEnumerable<ItensOrcamentoDTO> GetAllByORC_ID(int value )
        {
            var query = _query.FirstByORC_IDQuery(value );

                var result = _unitOfWork.Query<ItensOrcamentoDTO>(query.Query,query.Parameters) as List<ItensOrcamentoDTO>;
                return result;
        }

        public IEnumerable<ItensOrcamentoDTO> GetAllByTIP_ID(int value )
        {
            var query = _query.FirstByTIP_IDQuery(value );

                var result = _unitOfWork.Query<ItensOrcamentoDTO>(query.Query,query.Parameters) as List<ItensOrcamentoDTO>;
                return result;
        }

        public IEnumerable<ItensOrcamentoDTO> GetAllByPRO_ID(string value )
        {
            var query = _query.FirstByPRO_IDQuery(value );

                var result = _unitOfWork.Query<ItensOrcamentoDTO>(query.Query,query.Parameters) as List<ItensOrcamentoDTO>;
                return result;
        }

        public IEnumerable<ItensOrcamentoDTO> GetAllByITO_OBS(string value )
        {
            var query = _query.FirstByITO_OBSQuery(value );

                var result = _unitOfWork.Query<ItensOrcamentoDTO>(query.Query,query.Parameters) as List<ItensOrcamentoDTO>;
                return result;
        }

        public IEnumerable<ItensOrcamentoDTO> GetAllByITO_QUANTIDADE(Decimal value )
        {
            var query = _query.FirstByITO_QUANTIDADEQuery(value );

                var result = _unitOfWork.Query<ItensOrcamentoDTO>(query.Query,query.Parameters) as List<ItensOrcamentoDTO>;
                return result;
        }

        public IEnumerable<ItensOrcamentoDTO> GetAllByITO_CUSTO(Decimal value )
        {
            var query = _query.FirstByITO_CUSTOQuery(value );

                var result = _unitOfWork.Query<ItensOrcamentoDTO>(query.Query,query.Parameters) as List<ItensOrcamentoDTO>;
                return result;
        }

        public IEnumerable<ItensOrcamentoDTO> GetAllByITO_MARGEM(Decimal value )
        {
            var query = _query.FirstByITO_MARGEMQuery(value );

                var result = _unitOfWork.Query<ItensOrcamentoDTO>(query.Query,query.Parameters) as List<ItensOrcamentoDTO>;
                return result;
        }

        public IEnumerable<ItensOrcamentoDTO> GetAllByITO_VALOR_UNITARIO(Decimal value )
        {
            var query = _query.FirstByITO_VALOR_UNITARIOQuery(value );

                var result = _unitOfWork.Query<ItensOrcamentoDTO>(query.Query,query.Parameters) as List<ItensOrcamentoDTO>;
                return result;
        }

        public IEnumerable<ItensOrcamentoDTO> GetAllByITO_VERSSAO_CUSTO(DateTime value )
        {
            var query = _query.FirstByITO_VERSSAO_CUSTOQuery(value );

                var result = _unitOfWork.Query<ItensOrcamentoDTO>(query.Query,query.Parameters) as List<ItensOrcamentoDTO>;
                return result;
        }

        public IEnumerable<ItensOrcamentoDTO> GetAllByITO_STATUS(string value )
        {
            var query = _query.FirstByITO_STATUSQuery(value );

                var result = _unitOfWork.Query<ItensOrcamentoDTO>(query.Query,query.Parameters) as List<ItensOrcamentoDTO>;
                return result;
        }

        public IEnumerable<ItensOrcamentoDTO> GetAllByITO_ERP_CUSTOS_FIXOS(Decimal value )
        {
            var query = _query.FirstByITO_ERP_CUSTOS_FIXOSQuery(value );

                var result = _unitOfWork.Query<ItensOrcamentoDTO>(query.Query,query.Parameters) as List<ItensOrcamentoDTO>;
                return result;
        }

        public IEnumerable<ItensOrcamentoDTO> GetAllByITO_ERP_CUSTOS_VARIAVEIS(Decimal value )
        {
            var query = _query.FirstByITO_ERP_CUSTOS_VARIAVEISQuery(value );

                var result = _unitOfWork.Query<ItensOrcamentoDTO>(query.Query,query.Parameters) as List<ItensOrcamentoDTO>;
                return result;
        }

        public IEnumerable<ItensOrcamentoDTO> GetAllByITO_ERP_DESPESAS_VAR_VENDA(Decimal value )
        {
            var query = _query.FirstByITO_ERP_DESPESAS_VAR_VENDAQuery(value );

                var result = _unitOfWork.Query<ItensOrcamentoDTO>(query.Query,query.Parameters) as List<ItensOrcamentoDTO>;
                return result;
        }

        public IEnumerable<ItensOrcamentoDTO> GetAllByITO_ERP_IMPOSTOS(Decimal value )
        {
            var query = _query.FirstByITO_ERP_IMPOSTOSQuery(value );

                var result = _unitOfWork.Query<ItensOrcamentoDTO>(query.Query,query.Parameters) as List<ItensOrcamentoDTO>;
                return result;
        }

        public IEnumerable<ItensOrcamentoDTO> GetAllByGRP_ID_COMPOSICAO(string value )
        {
            var query = _query.FirstByGRP_ID_COMPOSICAOQuery(value );

                var result = _unitOfWork.Query<ItensOrcamentoDTO>(query.Query,query.Parameters) as List<ItensOrcamentoDTO>;
                return result;
        }

        public IEnumerable<ItensOrcamentoDTO> GetAllByITO_LARGURA(Decimal value )
        {
            var query = _query.FirstByITO_LARGURAQuery(value );

                var result = _unitOfWork.Query<ItensOrcamentoDTO>(query.Query,query.Parameters) as List<ItensOrcamentoDTO>;
                return result;
        }

        public IEnumerable<ItensOrcamentoDTO> GetAllByITO_COMPRIMENTO(Decimal value )
        {
            var query = _query.FirstByITO_COMPRIMENTOQuery(value );

                var result = _unitOfWork.Query<ItensOrcamentoDTO>(query.Query,query.Parameters) as List<ItensOrcamentoDTO>;
                return result;
        }

        public IEnumerable<ItensOrcamentoDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<ItensOrcamentoDTO>(query.Query,query.Parameters) as List<ItensOrcamentoDTO>;
                return result;
        }

        public IEnumerable<ItensOrcamentoDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<ItensOrcamentoDTO>(query.Query,query.Parameters) as List<ItensOrcamentoDTO>;
                return result;
        }

        public IEnumerable<ItensOrcamentoDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<ItensOrcamentoDTO>(query.Query,query.Parameters) as List<ItensOrcamentoDTO>;
                return result;
        }

        public IEnumerable<ItensOrcamentoDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<ItensOrcamentoDTO>(query.Query,query.Parameters) as List<ItensOrcamentoDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration