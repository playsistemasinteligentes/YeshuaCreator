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
    public partial class OrderReadRepository : IOrderReadRepository
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IExecutionContext _executionContext;
       protected readonly IOrderQueryRead _query;

        public OrderReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,IOrderQueryRead query)
        {
            _unitOfWork = unitOfWork;
            _executionContext = executionContext;
            _query = query;
        }

        public DataPagination<OrderDTO> getOrder(ICommandRead command )
         {
            if (command is Command.Read.OrderReadCommand c)
                return getOrder(c );
            throw new NotImplementedException();
        }
        private DataPagination<OrderDTO> getOrder(Command.Read.OrderReadCommand command )
        {
            var query = _query.OrderQuery(command );

                var itens = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters);
                return new DataPagination<OrderDTO>(
                                itens,
                command.Paginacao?.Page ?? 0,
                command.Paginacao?.PageSize ?? 0,
                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);
        }

        private IEnumerable<OrderCLI_IDDTO> getOrderReadFKCLI_ID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<OrderCLI_IDDTO> lista;
            var query = _query.OrderCLI_IDQuery(command );

                lista = _unitOfWork.Query<OrderCLI_IDDTO>(query.Query,query.Parameters) as List<OrderCLI_IDDTO>;
            return lista;
        }

        public IEnumerable<OrderCLI_IDDTO> getOrderReadFKCLI_ID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getOrderReadFKCLI_ID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<OrderMUN_ID_ENTREGADTO> getOrderReadFKMUN_ID_ENTREGA(Command.Patterns.Command.SearchFKCommand command )
        {
            List<OrderMUN_ID_ENTREGADTO> lista;
            var query = _query.OrderMUN_ID_ENTREGAQuery(command );

                lista = _unitOfWork.Query<OrderMUN_ID_ENTREGADTO>(query.Query,query.Parameters) as List<OrderMUN_ID_ENTREGADTO>;
            return lista;
        }

        public IEnumerable<OrderMUN_ID_ENTREGADTO> getOrderReadFKMUN_ID_ENTREGA(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getOrderReadFKMUN_ID_ENTREGA(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<OrderORD_REGIAO_ENTREGADTO> getOrderReadFKORD_REGIAO_ENTREGA(Command.Patterns.Command.SearchFKCommand command )
        {
            List<OrderORD_REGIAO_ENTREGADTO> lista;
            var query = _query.OrderORD_REGIAO_ENTREGAQuery(command );

                lista = _unitOfWork.Query<OrderORD_REGIAO_ENTREGADTO>(query.Query,query.Parameters) as List<OrderORD_REGIAO_ENTREGADTO>;
            return lista;
        }

        public IEnumerable<OrderORD_REGIAO_ENTREGADTO> getOrderReadFKORD_REGIAO_ENTREGA(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getOrderReadFKORD_REGIAO_ENTREGA(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<OrderOCO_ID_CANCELAMENTODTO> getOrderReadFKOCO_ID_CANCELAMENTO(Command.Patterns.Command.SearchFKCommand command )
        {
            List<OrderOCO_ID_CANCELAMENTODTO> lista;
            var query = _query.OrderOCO_ID_CANCELAMENTOQuery(command );

                lista = _unitOfWork.Query<OrderOCO_ID_CANCELAMENTODTO>(query.Query,query.Parameters) as List<OrderOCO_ID_CANCELAMENTODTO>;
            return lista;
        }

        public IEnumerable<OrderOCO_ID_CANCELAMENTODTO> getOrderReadFKOCO_ID_CANCELAMENTO(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getOrderReadFKOCO_ID_CANCELAMENTO(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<OrderTenantIDDTO> getOrderReadFKTenantID(Command.Patterns.Command.SearchFKCommand command )
        {
            List<OrderTenantIDDTO> lista;
            var query = _query.OrderTenantIDQuery(command );

                lista = _unitOfWork.Query<OrderTenantIDDTO>(query.Query,query.Parameters) as List<OrderTenantIDDTO>;
            return lista;
        }

        public IEnumerable<OrderTenantIDDTO> getOrderReadFKTenantID(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getOrderReadFKTenantID(c );
            }
            throw new NotImplementedException();
        }

        private IEnumerable<OrderUserIdDTO> getOrderReadFKUserId(Command.Patterns.Command.SearchFKCommand command )
        {
            List<OrderUserIdDTO> lista;
            var query = _query.OrderUserIdQuery(command );

                lista = _unitOfWork.Query<OrderUserIdDTO>(query.Query,query.Parameters) as List<OrderUserIdDTO>;
            return lista;
        }

        public IEnumerable<OrderUserIdDTO> getOrderReadFKUserId(object command )
        {
            if (command is Command.Patterns.Command.SearchFKCommand c)
            {
                return getOrderReadFKUserId(c );
            }
            throw new NotImplementedException();
        }

        public bool ExistsByORD_ID(string value )
        {
            var query = _query.ExistsByORD_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_ID_RESERVA(string value )
        {
            var query = _query.ExistsByORD_ID_RESERVAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_ID_CONJUNTO(string value )
        {
            var query = _query.ExistsByORD_ID_CONJUNTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ID(string value )
        {
            var query = _query.ExistsByPRO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ID_CONJUNTO(string value )
        {
            var query = _query.ExistsByPRO_ID_CONJUNTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCLI_ID(string value )
        {
            var query = _query.ExistsByCLI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_PRECO_UNITARIO(Decimal value )
        {
            var query = _query.ExistsByORD_PRECO_UNITARIOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_QUANTIDADE(Decimal value )
        {
            var query = _query.ExistsByORD_QUANTIDADEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_DATA_ENTREGA_DE(DateTime value )
        {
            var query = _query.ExistsByORD_DATA_ENTREGA_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_DATA_ENTREGA_ATE(DateTime value )
        {
            var query = _query.ExistsByORD_DATA_ENTREGA_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_TIPO(int value )
        {
            var query = _query.ExistsByORD_TIPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_TOLERANCIA_MAIS(Decimal value )
        {
            var query = _query.ExistsByORD_TOLERANCIA_MAISQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_TOLERANCIA_MENOS(Decimal value )
        {
            var query = _query.ExistsByORD_TOLERANCIA_MENOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByHASH_KEY(string value )
        {
            var query = _query.ExistsByHASH_KEYQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_INICIO_JANELA_EMBARQUE(DateTime value )
        {
            var query = _query.ExistsByORD_INICIO_JANELA_EMBARQUEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_FIM_JANELA_EMBARQUE(DateTime value )
        {
            var query = _query.ExistsByORD_FIM_JANELA_EMBARQUEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_EMBARQUE_ALVO(DateTime value )
        {
            var query = _query.ExistsByORD_EMBARQUE_ALVOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_INICIO_GRUPO_PRODUTIVO(DateTime value )
        {
            var query = _query.ExistsByORD_INICIO_GRUPO_PRODUTIVOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_FIM_GRUPO_PRODUTIVO(DateTime value )
        {
            var query = _query.ExistsByORD_FIM_GRUPO_PRODUTIVOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_PESO_UNITARIO(Decimal value )
        {
            var query = _query.ExistsByORD_PESO_UNITARIOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_PESO_UNITARIO_BRUTO(Decimal value )
        {
            var query = _query.ExistsByORD_PESO_UNITARIO_BRUTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_M2_UNITARIO(Decimal value )
        {
            var query = _query.ExistsByORD_M2_UNITARIOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_MIT(string value )
        {
            var query = _query.ExistsByORD_MITQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByCAR_TIPO_CARREGAMENTO(string value )
        {
            var query = _query.ExistsByCAR_TIPO_CARREGAMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_STATUS(string value )
        {
            var query = _query.ExistsByORD_STATUSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_TIPO_FRETE(string value )
        {
            var query = _query.ExistsByORD_TIPO_FRETEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_ENDERECO_ENTREGA(string value )
        {
            var query = _query.ExistsByORD_ENDERECO_ENTREGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_BAIRRO_ENTREGA(string value )
        {
            var query = _query.ExistsByORD_BAIRRO_ENTREGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByUF_ID_ENTREGA(string value )
        {
            var query = _query.ExistsByUF_ID_ENTREGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_CEP_ENTREGA(string value )
        {
            var query = _query.ExistsByORD_CEP_ENTREGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByMUN_ID_ENTREGA(string value )
        {
            var query = _query.ExistsByMUN_ID_ENTREGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_REGIAO_ENTREGA(string value )
        {
            var query = _query.ExistsByORD_REGIAO_ENTREGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_LARGURA(Decimal value )
        {
            var query = _query.ExistsByORD_LARGURAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_COMPRIMENTO(Decimal value )
        {
            var query = _query.ExistsByORD_COMPRIMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_GRAMATURA(Decimal value )
        {
            var query = _query.ExistsByORD_GRAMATURAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByGRP_ID(string value )
        {
            var query = _query.ExistsByGRP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_ID_INTEGRACAO(string value )
        {
            var query = _query.ExistsByORD_ID_INTEGRACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_OBSERVACAO_OTIMIZADOR(string value )
        {
            var query = _query.ExistsByORD_OBSERVACAO_OTIMIZADORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_COR_FILA(string value )
        {
            var query = _query.ExistsByORD_COR_FILAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_PED_CLI(string value )
        {
            var query = _query.ExistsByORD_PED_CLIQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_OP_INTEGRACAO(string value )
        {
            var query = _query.ExistsByORD_OP_INTEGRACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_LOTE_PILOTO(string value )
        {
            var query = _query.ExistsByORD_LOTE_PILOTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_PRIORIDADE(int value )
        {
            var query = _query.ExistsByORD_PRIORIDADEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_EMISSAO(DateTime value )
        {
            var query = _query.ExistsByORD_EMISSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByREP_ID(string value )
        {
            var query = _query.ExistsByREP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_RESINA(string value )
        {
            var query = _query.ExistsByORD_RESINAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_ENDURECEDOR_MIOLO(string value )
        {
            var query = _query.ExistsByORD_ENDURECEDOR_MIOLOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ID_INTEGRACAO_ERP(string value )
        {
            var query = _query.ExistsByPRO_ID_INTEGRACAO_ERPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_VINCOS_ONDULADEIRA(string value )
        {
            var query = _query.ExistsByORD_VINCOS_ONDULADEIRAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_ERP_CUSTOS_FIXOS(Decimal value )
        {
            var query = _query.ExistsByORD_ERP_CUSTOS_FIXOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_ERP_CUSTOS_VARIAVEIS(Decimal value )
        {
            var query = _query.ExistsByORD_ERP_CUSTOS_VARIAVEISQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_ERP_DESPESAS_VAR_VENDA(Decimal value )
        {
            var query = _query.ExistsByORD_ERP_DESPESAS_VAR_VENDAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_ERP_IMPOSTOS(Decimal value )
        {
            var query = _query.ExistsByORD_ERP_IMPOSTOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_STATUS_PLANEJAMENTO(string value )
        {
            var query = _query.ExistsByORD_STATUS_PLANEJAMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_TOLERANCIA_DIMENSAO_CHAPA_DE(int value )
        {
            var query = _query.ExistsByORD_TOLERANCIA_DIMENSAO_CHAPA_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_TOLERANCIA_DIMENSAO_CHAPA_ATE(int value )
        {
            var query = _query.ExistsByORD_TOLERANCIA_DIMENSAO_CHAPA_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_PROMOVE_DE(Decimal value )
        {
            var query = _query.ExistsByORD_PROMOVE_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_PROMOVE_ATE(Decimal value )
        {
            var query = _query.ExistsByORD_PROMOVE_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_TRAVA_COMPOSICAO(string value )
        {
            var query = _query.ExistsByORD_TRAVA_COMPOSICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_TRAVA_RESINA(string value )
        {
            var query = _query.ExistsByORD_TRAVA_RESINAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_PROMOVE_RESINA(string value )
        {
            var query = _query.ExistsByORD_PROMOVE_RESINAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_LATITUDE_ENTREGA(Decimal value )
        {
            var query = _query.ExistsByORD_LATITUDE_ENTREGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_LONGITUDE_ENTREGA(Decimal value )
        {
            var query = _query.ExistsByORD_LONGITUDE_ENTREGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOCO_ID_CANCELAMENTO(string value )
        {
            var query = _query.ExistsByOCO_ID_CANCELAMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByTMP_TIPO_CARGA(string value )
        {
            var query = _query.ExistsByTMP_TIPO_CARGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ID_PALETE(string value )
        {
            var query = _query.ExistsByPRO_ID_PALETEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByPRO_ID_TAMPO(string value )
        {
            var query = _query.ExistsByPRO_ID_TAMPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_PILHAS_POR_PALETE(int value )
        {
            var query = _query.ExistsByORD_PILHAS_POR_PALETEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_CHAPAS_POR_PILHA(int value )
        {
            var query = _query.ExistsByORD_CHAPAS_POR_PILHAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_DATA_CANCELAMENTO(DateTime value )
        {
            var query = _query.ExistsByORD_DATA_CANCELAMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_STATUS_ESTATISTICA(string value )
        {
            var query = _query.ExistsByORD_STATUS_ESTATISTICAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByORD_DATA_ESTATISTICA(DateTime value )
        {
            var query = _query.ExistsByORD_DATA_ESTATISTICAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOCO_ID_MOTIVO_ATRASO(string value )
        {
            var query = _query.ExistsByOCO_ID_MOTIVO_ATRASOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);
                return result == 1;
        }

        public bool ExistsByOTK_VERSSAO(int value )
        {
            var query = _query.ExistsByOTK_VERSSAOQuery(value );

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

        public OrderDTO FirstByORD_ID(string value )
        {
            var query = _query.FirstByORD_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_ID_RESERVA(string value )
        {
            var query = _query.FirstByORD_ID_RESERVAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_ID_CONJUNTO(string value )
        {
            var query = _query.FirstByORD_ID_CONJUNTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByPRO_ID(string value )
        {
            var query = _query.FirstByPRO_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByPRO_ID_CONJUNTO(string value )
        {
            var query = _query.FirstByPRO_ID_CONJUNTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByCLI_ID(string value )
        {
            var query = _query.FirstByCLI_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_PRECO_UNITARIO(Decimal value )
        {
            var query = _query.FirstByORD_PRECO_UNITARIOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_QUANTIDADE(Decimal value )
        {
            var query = _query.FirstByORD_QUANTIDADEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_DATA_ENTREGA_DE(DateTime value )
        {
            var query = _query.FirstByORD_DATA_ENTREGA_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_DATA_ENTREGA_ATE(DateTime value )
        {
            var query = _query.FirstByORD_DATA_ENTREGA_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_TIPO(int value )
        {
            var query = _query.FirstByORD_TIPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_TOLERANCIA_MAIS(Decimal value )
        {
            var query = _query.FirstByORD_TOLERANCIA_MAISQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_TOLERANCIA_MENOS(Decimal value )
        {
            var query = _query.FirstByORD_TOLERANCIA_MENOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByHASH_KEY(string value )
        {
            var query = _query.FirstByHASH_KEYQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_INICIO_JANELA_EMBARQUE(DateTime value )
        {
            var query = _query.FirstByORD_INICIO_JANELA_EMBARQUEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_FIM_JANELA_EMBARQUE(DateTime value )
        {
            var query = _query.FirstByORD_FIM_JANELA_EMBARQUEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_EMBARQUE_ALVO(DateTime value )
        {
            var query = _query.FirstByORD_EMBARQUE_ALVOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_INICIO_GRUPO_PRODUTIVO(DateTime value )
        {
            var query = _query.FirstByORD_INICIO_GRUPO_PRODUTIVOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_FIM_GRUPO_PRODUTIVO(DateTime value )
        {
            var query = _query.FirstByORD_FIM_GRUPO_PRODUTIVOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_PESO_UNITARIO(Decimal value )
        {
            var query = _query.FirstByORD_PESO_UNITARIOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_PESO_UNITARIO_BRUTO(Decimal value )
        {
            var query = _query.FirstByORD_PESO_UNITARIO_BRUTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_M2_UNITARIO(Decimal value )
        {
            var query = _query.FirstByORD_M2_UNITARIOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_MIT(string value )
        {
            var query = _query.FirstByORD_MITQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByCAR_TIPO_CARREGAMENTO(string value )
        {
            var query = _query.FirstByCAR_TIPO_CARREGAMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_STATUS(string value )
        {
            var query = _query.FirstByORD_STATUSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_TIPO_FRETE(string value )
        {
            var query = _query.FirstByORD_TIPO_FRETEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_ENDERECO_ENTREGA(string value )
        {
            var query = _query.FirstByORD_ENDERECO_ENTREGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_BAIRRO_ENTREGA(string value )
        {
            var query = _query.FirstByORD_BAIRRO_ENTREGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByUF_ID_ENTREGA(string value )
        {
            var query = _query.FirstByUF_ID_ENTREGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_CEP_ENTREGA(string value )
        {
            var query = _query.FirstByORD_CEP_ENTREGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByMUN_ID_ENTREGA(string value )
        {
            var query = _query.FirstByMUN_ID_ENTREGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_REGIAO_ENTREGA(string value )
        {
            var query = _query.FirstByORD_REGIAO_ENTREGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_LARGURA(Decimal value )
        {
            var query = _query.FirstByORD_LARGURAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_COMPRIMENTO(Decimal value )
        {
            var query = _query.FirstByORD_COMPRIMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_GRAMATURA(Decimal value )
        {
            var query = _query.FirstByORD_GRAMATURAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByGRP_ID(string value )
        {
            var query = _query.FirstByGRP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_ID_INTEGRACAO(string value )
        {
            var query = _query.FirstByORD_ID_INTEGRACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_OBSERVACAO_OTIMIZADOR(string value )
        {
            var query = _query.FirstByORD_OBSERVACAO_OTIMIZADORQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_COR_FILA(string value )
        {
            var query = _query.FirstByORD_COR_FILAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_PED_CLI(string value )
        {
            var query = _query.FirstByORD_PED_CLIQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_OP_INTEGRACAO(string value )
        {
            var query = _query.FirstByORD_OP_INTEGRACAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_LOTE_PILOTO(string value )
        {
            var query = _query.FirstByORD_LOTE_PILOTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_PRIORIDADE(int value )
        {
            var query = _query.FirstByORD_PRIORIDADEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_EMISSAO(DateTime value )
        {
            var query = _query.FirstByORD_EMISSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByREP_ID(string value )
        {
            var query = _query.FirstByREP_IDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_RESINA(string value )
        {
            var query = _query.FirstByORD_RESINAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_ENDURECEDOR_MIOLO(string value )
        {
            var query = _query.FirstByORD_ENDURECEDOR_MIOLOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByPRO_ID_INTEGRACAO_ERP(string value )
        {
            var query = _query.FirstByPRO_ID_INTEGRACAO_ERPQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_VINCOS_ONDULADEIRA(string value )
        {
            var query = _query.FirstByORD_VINCOS_ONDULADEIRAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_ERP_CUSTOS_FIXOS(Decimal value )
        {
            var query = _query.FirstByORD_ERP_CUSTOS_FIXOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_ERP_CUSTOS_VARIAVEIS(Decimal value )
        {
            var query = _query.FirstByORD_ERP_CUSTOS_VARIAVEISQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_ERP_DESPESAS_VAR_VENDA(Decimal value )
        {
            var query = _query.FirstByORD_ERP_DESPESAS_VAR_VENDAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_ERP_IMPOSTOS(Decimal value )
        {
            var query = _query.FirstByORD_ERP_IMPOSTOSQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_STATUS_PLANEJAMENTO(string value )
        {
            var query = _query.FirstByORD_STATUS_PLANEJAMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_TOLERANCIA_DIMENSAO_CHAPA_DE(int value )
        {
            var query = _query.FirstByORD_TOLERANCIA_DIMENSAO_CHAPA_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_TOLERANCIA_DIMENSAO_CHAPA_ATE(int value )
        {
            var query = _query.FirstByORD_TOLERANCIA_DIMENSAO_CHAPA_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_PROMOVE_DE(Decimal value )
        {
            var query = _query.FirstByORD_PROMOVE_DEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_PROMOVE_ATE(Decimal value )
        {
            var query = _query.FirstByORD_PROMOVE_ATEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_TRAVA_COMPOSICAO(string value )
        {
            var query = _query.FirstByORD_TRAVA_COMPOSICAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_TRAVA_RESINA(string value )
        {
            var query = _query.FirstByORD_TRAVA_RESINAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_PROMOVE_RESINA(string value )
        {
            var query = _query.FirstByORD_PROMOVE_RESINAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_LATITUDE_ENTREGA(Decimal value )
        {
            var query = _query.FirstByORD_LATITUDE_ENTREGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_LONGITUDE_ENTREGA(Decimal value )
        {
            var query = _query.FirstByORD_LONGITUDE_ENTREGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByOCO_ID_CANCELAMENTO(string value )
        {
            var query = _query.FirstByOCO_ID_CANCELAMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByTMP_TIPO_CARGA(string value )
        {
            var query = _query.FirstByTMP_TIPO_CARGAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByPRO_ID_PALETE(string value )
        {
            var query = _query.FirstByPRO_ID_PALETEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByPRO_ID_TAMPO(string value )
        {
            var query = _query.FirstByPRO_ID_TAMPOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_PILHAS_POR_PALETE(int value )
        {
            var query = _query.FirstByORD_PILHAS_POR_PALETEQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_CHAPAS_POR_PILHA(int value )
        {
            var query = _query.FirstByORD_CHAPAS_POR_PILHAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_DATA_CANCELAMENTO(DateTime value )
        {
            var query = _query.FirstByORD_DATA_CANCELAMENTOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_STATUS_ESTATISTICA(string value )
        {
            var query = _query.FirstByORD_STATUS_ESTATISTICAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByORD_DATA_ESTATISTICA(DateTime value )
        {
            var query = _query.FirstByORD_DATA_ESTATISTICAQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByOCO_ID_MOTIVO_ATRASO(string value )
        {
            var query = _query.FirstByOCO_ID_MOTIVO_ATRASOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByOTK_VERSSAO(int value )
        {
            var query = _query.FirstByOTK_VERSSAOQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public OrderDTO FirstByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.QueryFirstOrDefault<OrderDTO>(query.Query, query.Parameters);
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_ID(string value )
        {
            var query = _query.FirstByORD_IDQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_ID_RESERVA(string value )
        {
            var query = _query.FirstByORD_ID_RESERVAQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_ID_CONJUNTO(string value )
        {
            var query = _query.FirstByORD_ID_CONJUNTOQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByPRO_ID(string value )
        {
            var query = _query.FirstByPRO_IDQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByPRO_ID_CONJUNTO(string value )
        {
            var query = _query.FirstByPRO_ID_CONJUNTOQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByCLI_ID(string value )
        {
            var query = _query.FirstByCLI_IDQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_PRECO_UNITARIO(Decimal value )
        {
            var query = _query.FirstByORD_PRECO_UNITARIOQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_QUANTIDADE(Decimal value )
        {
            var query = _query.FirstByORD_QUANTIDADEQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_DATA_ENTREGA_DE(DateTime value )
        {
            var query = _query.FirstByORD_DATA_ENTREGA_DEQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_DATA_ENTREGA_ATE(DateTime value )
        {
            var query = _query.FirstByORD_DATA_ENTREGA_ATEQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_TIPO(int value )
        {
            var query = _query.FirstByORD_TIPOQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_TOLERANCIA_MAIS(Decimal value )
        {
            var query = _query.FirstByORD_TOLERANCIA_MAISQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_TOLERANCIA_MENOS(Decimal value )
        {
            var query = _query.FirstByORD_TOLERANCIA_MENOSQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByHASH_KEY(string value )
        {
            var query = _query.FirstByHASH_KEYQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_INICIO_JANELA_EMBARQUE(DateTime value )
        {
            var query = _query.FirstByORD_INICIO_JANELA_EMBARQUEQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_FIM_JANELA_EMBARQUE(DateTime value )
        {
            var query = _query.FirstByORD_FIM_JANELA_EMBARQUEQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_EMBARQUE_ALVO(DateTime value )
        {
            var query = _query.FirstByORD_EMBARQUE_ALVOQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_INICIO_GRUPO_PRODUTIVO(DateTime value )
        {
            var query = _query.FirstByORD_INICIO_GRUPO_PRODUTIVOQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_FIM_GRUPO_PRODUTIVO(DateTime value )
        {
            var query = _query.FirstByORD_FIM_GRUPO_PRODUTIVOQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_PESO_UNITARIO(Decimal value )
        {
            var query = _query.FirstByORD_PESO_UNITARIOQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_PESO_UNITARIO_BRUTO(Decimal value )
        {
            var query = _query.FirstByORD_PESO_UNITARIO_BRUTOQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_M2_UNITARIO(Decimal value )
        {
            var query = _query.FirstByORD_M2_UNITARIOQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_MIT(string value )
        {
            var query = _query.FirstByORD_MITQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByCAR_TIPO_CARREGAMENTO(string value )
        {
            var query = _query.FirstByCAR_TIPO_CARREGAMENTOQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_STATUS(string value )
        {
            var query = _query.FirstByORD_STATUSQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_TIPO_FRETE(string value )
        {
            var query = _query.FirstByORD_TIPO_FRETEQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_ENDERECO_ENTREGA(string value )
        {
            var query = _query.FirstByORD_ENDERECO_ENTREGAQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_BAIRRO_ENTREGA(string value )
        {
            var query = _query.FirstByORD_BAIRRO_ENTREGAQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByUF_ID_ENTREGA(string value )
        {
            var query = _query.FirstByUF_ID_ENTREGAQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_CEP_ENTREGA(string value )
        {
            var query = _query.FirstByORD_CEP_ENTREGAQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByMUN_ID_ENTREGA(string value )
        {
            var query = _query.FirstByMUN_ID_ENTREGAQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_REGIAO_ENTREGA(string value )
        {
            var query = _query.FirstByORD_REGIAO_ENTREGAQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_LARGURA(Decimal value )
        {
            var query = _query.FirstByORD_LARGURAQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_COMPRIMENTO(Decimal value )
        {
            var query = _query.FirstByORD_COMPRIMENTOQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_GRAMATURA(Decimal value )
        {
            var query = _query.FirstByORD_GRAMATURAQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByGRP_ID(string value )
        {
            var query = _query.FirstByGRP_IDQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_ID_INTEGRACAO(string value )
        {
            var query = _query.FirstByORD_ID_INTEGRACAOQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_OBSERVACAO_OTIMIZADOR(string value )
        {
            var query = _query.FirstByORD_OBSERVACAO_OTIMIZADORQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_COR_FILA(string value )
        {
            var query = _query.FirstByORD_COR_FILAQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_PED_CLI(string value )
        {
            var query = _query.FirstByORD_PED_CLIQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_OP_INTEGRACAO(string value )
        {
            var query = _query.FirstByORD_OP_INTEGRACAOQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_LOTE_PILOTO(string value )
        {
            var query = _query.FirstByORD_LOTE_PILOTOQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_PRIORIDADE(int value )
        {
            var query = _query.FirstByORD_PRIORIDADEQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_EMISSAO(DateTime value )
        {
            var query = _query.FirstByORD_EMISSAOQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByREP_ID(string value )
        {
            var query = _query.FirstByREP_IDQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_RESINA(string value )
        {
            var query = _query.FirstByORD_RESINAQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_ENDURECEDOR_MIOLO(string value )
        {
            var query = _query.FirstByORD_ENDURECEDOR_MIOLOQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByPRO_ID_INTEGRACAO_ERP(string value )
        {
            var query = _query.FirstByPRO_ID_INTEGRACAO_ERPQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_VINCOS_ONDULADEIRA(string value )
        {
            var query = _query.FirstByORD_VINCOS_ONDULADEIRAQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_ERP_CUSTOS_FIXOS(Decimal value )
        {
            var query = _query.FirstByORD_ERP_CUSTOS_FIXOSQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_ERP_CUSTOS_VARIAVEIS(Decimal value )
        {
            var query = _query.FirstByORD_ERP_CUSTOS_VARIAVEISQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_ERP_DESPESAS_VAR_VENDA(Decimal value )
        {
            var query = _query.FirstByORD_ERP_DESPESAS_VAR_VENDAQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_ERP_IMPOSTOS(Decimal value )
        {
            var query = _query.FirstByORD_ERP_IMPOSTOSQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_STATUS_PLANEJAMENTO(string value )
        {
            var query = _query.FirstByORD_STATUS_PLANEJAMENTOQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_TOLERANCIA_DIMENSAO_CHAPA_DE(int value )
        {
            var query = _query.FirstByORD_TOLERANCIA_DIMENSAO_CHAPA_DEQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_TOLERANCIA_DIMENSAO_CHAPA_ATE(int value )
        {
            var query = _query.FirstByORD_TOLERANCIA_DIMENSAO_CHAPA_ATEQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_PROMOVE_DE(Decimal value )
        {
            var query = _query.FirstByORD_PROMOVE_DEQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_PROMOVE_ATE(Decimal value )
        {
            var query = _query.FirstByORD_PROMOVE_ATEQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_TRAVA_COMPOSICAO(string value )
        {
            var query = _query.FirstByORD_TRAVA_COMPOSICAOQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_TRAVA_RESINA(string value )
        {
            var query = _query.FirstByORD_TRAVA_RESINAQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_PROMOVE_RESINA(string value )
        {
            var query = _query.FirstByORD_PROMOVE_RESINAQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_LATITUDE_ENTREGA(Decimal value )
        {
            var query = _query.FirstByORD_LATITUDE_ENTREGAQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_LONGITUDE_ENTREGA(Decimal value )
        {
            var query = _query.FirstByORD_LONGITUDE_ENTREGAQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByOCO_ID_CANCELAMENTO(string value )
        {
            var query = _query.FirstByOCO_ID_CANCELAMENTOQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByTMP_TIPO_CARGA(string value )
        {
            var query = _query.FirstByTMP_TIPO_CARGAQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByPRO_ID_PALETE(string value )
        {
            var query = _query.FirstByPRO_ID_PALETEQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByPRO_ID_TAMPO(string value )
        {
            var query = _query.FirstByPRO_ID_TAMPOQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_PILHAS_POR_PALETE(int value )
        {
            var query = _query.FirstByORD_PILHAS_POR_PALETEQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_CHAPAS_POR_PILHA(int value )
        {
            var query = _query.FirstByORD_CHAPAS_POR_PILHAQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_DATA_CANCELAMENTO(DateTime value )
        {
            var query = _query.FirstByORD_DATA_CANCELAMENTOQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_STATUS_ESTATISTICA(string value )
        {
            var query = _query.FirstByORD_STATUS_ESTATISTICAQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByORD_DATA_ESTATISTICA(DateTime value )
        {
            var query = _query.FirstByORD_DATA_ESTATISTICAQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByOCO_ID_MOTIVO_ATRASO(string value )
        {
            var query = _query.FirstByOCO_ID_MOTIVO_ATRASOQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByOTK_VERSSAO(int value )
        {
            var query = _query.FirstByOTK_VERSSAOQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByTenantID(int value )
        {
            var query = _query.FirstByTenantIDQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByDeleted(bool value )
        {
            var query = _query.FirstByDeletedQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByChanged(DateTime value )
        {
            var query = _query.FirstByChangedQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

        public IEnumerable<OrderDTO> GetAllByUserId(int value )
        {
            var query = _query.FirstByUserIdQuery(value );

                var result = _unitOfWork.Query<OrderDTO>(query.Query,query.Parameters) as List<OrderDTO>;
                return result;
        }

    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration