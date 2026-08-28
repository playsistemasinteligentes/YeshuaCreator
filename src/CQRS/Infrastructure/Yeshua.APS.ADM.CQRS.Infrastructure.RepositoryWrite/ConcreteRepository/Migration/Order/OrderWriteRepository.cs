// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration
// </yeshua>

using Dapper;
using Dominio.Entitys;
using IRepository.Write;
using IQuery.Write;
using RepositoryInterfaces.Services;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Repository.Order
{
    public partial class OrderWriteRepository : IOrderWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IOrderQueryWrite _query; 

        public OrderWriteRepository(IUnitOfWork unitOfWork,IOrderQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IOrderEntity Order)
        {
            var query = _query.InserirOrderQuery(Order);
                _UnitOfWork.Execute(query.Query, query.Parameters);
        }

        public void Update(IOrderEntity Order)
        {
            var query = _query.UpdateOrderQuery(Order);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IOrderEntity Order)
        {
            var query = _query.DeleteOrderQuery(Order);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_ID_RESERVA(string ord_id, string value)
        {
            var query = _query.UpdateORD_ID_RESERVA(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_ID_CONJUNTO(string ord_id, string value)
        {
            var query = _query.UpdateORD_ID_CONJUNTO(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ID(string ord_id, string value)
        {
            var query = _query.UpdatePRO_ID(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ID_CONJUNTO(string ord_id, string value)
        {
            var query = _query.UpdatePRO_ID_CONJUNTO(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCLI_ID(string ord_id, string value)
        {
            var query = _query.UpdateCLI_ID(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_PRECO_UNITARIO(string ord_id, Decimal value)
        {
            var query = _query.UpdateORD_PRECO_UNITARIO(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_QUANTIDADE(string ord_id, Decimal value)
        {
            var query = _query.UpdateORD_QUANTIDADE(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_DATA_ENTREGA_DE(string ord_id, DateTime value)
        {
            var query = _query.UpdateORD_DATA_ENTREGA_DE(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_DATA_ENTREGA_ATE(string ord_id, DateTime value)
        {
            var query = _query.UpdateORD_DATA_ENTREGA_ATE(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_TIPO(string ord_id, int value)
        {
            var query = _query.UpdateORD_TIPO(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_TOLERANCIA_MAIS(string ord_id, Decimal value)
        {
            var query = _query.UpdateORD_TOLERANCIA_MAIS(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_TOLERANCIA_MENOS(string ord_id, Decimal value)
        {
            var query = _query.UpdateORD_TOLERANCIA_MENOS(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateHASH_KEY(string ord_id, string value)
        {
            var query = _query.UpdateHASH_KEY(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_INICIO_JANELA_EMBARQUE(string ord_id, DateTime value)
        {
            var query = _query.UpdateORD_INICIO_JANELA_EMBARQUE(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_FIM_JANELA_EMBARQUE(string ord_id, DateTime value)
        {
            var query = _query.UpdateORD_FIM_JANELA_EMBARQUE(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_EMBARQUE_ALVO(string ord_id, DateTime value)
        {
            var query = _query.UpdateORD_EMBARQUE_ALVO(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_INICIO_GRUPO_PRODUTIVO(string ord_id, DateTime value)
        {
            var query = _query.UpdateORD_INICIO_GRUPO_PRODUTIVO(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_FIM_GRUPO_PRODUTIVO(string ord_id, DateTime value)
        {
            var query = _query.UpdateORD_FIM_GRUPO_PRODUTIVO(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_PESO_UNITARIO(string ord_id, Decimal value)
        {
            var query = _query.UpdateORD_PESO_UNITARIO(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_PESO_UNITARIO_BRUTO(string ord_id, Decimal value)
        {
            var query = _query.UpdateORD_PESO_UNITARIO_BRUTO(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_M2_UNITARIO(string ord_id, Decimal value)
        {
            var query = _query.UpdateORD_M2_UNITARIO(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_MIT(string ord_id, string value)
        {
            var query = _query.UpdateORD_MIT(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAR_TIPO_CARREGAMENTO(string ord_id, string value)
        {
            var query = _query.UpdateCAR_TIPO_CARREGAMENTO(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_STATUS(string ord_id, string value)
        {
            var query = _query.UpdateORD_STATUS(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_TIPO_FRETE(string ord_id, string value)
        {
            var query = _query.UpdateORD_TIPO_FRETE(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_ENDERECO_ENTREGA(string ord_id, string value)
        {
            var query = _query.UpdateORD_ENDERECO_ENTREGA(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_BAIRRO_ENTREGA(string ord_id, string value)
        {
            var query = _query.UpdateORD_BAIRRO_ENTREGA(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUF_ID_ENTREGA(string ord_id, string value)
        {
            var query = _query.UpdateUF_ID_ENTREGA(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_CEP_ENTREGA(string ord_id, string value)
        {
            var query = _query.UpdateORD_CEP_ENTREGA(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMUN_ID_ENTREGA(string ord_id, string value)
        {
            var query = _query.UpdateMUN_ID_ENTREGA(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_REGIAO_ENTREGA(string ord_id, string value)
        {
            var query = _query.UpdateORD_REGIAO_ENTREGA(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_LARGURA(string ord_id, Decimal value)
        {
            var query = _query.UpdateORD_LARGURA(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_COMPRIMENTO(string ord_id, Decimal value)
        {
            var query = _query.UpdateORD_COMPRIMENTO(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_GRAMATURA(string ord_id, Decimal value)
        {
            var query = _query.UpdateORD_GRAMATURA(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_ID(string ord_id, string value)
        {
            var query = _query.UpdateGRP_ID(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_ID_INTEGRACAO(string ord_id, string value)
        {
            var query = _query.UpdateORD_ID_INTEGRACAO(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_OBSERVACAO_OTIMIZADOR(string ord_id, string value)
        {
            var query = _query.UpdateORD_OBSERVACAO_OTIMIZADOR(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_COR_FILA(string ord_id, string value)
        {
            var query = _query.UpdateORD_COR_FILA(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_PED_CLI(string ord_id, string value)
        {
            var query = _query.UpdateORD_PED_CLI(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_OP_INTEGRACAO(string ord_id, string value)
        {
            var query = _query.UpdateORD_OP_INTEGRACAO(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_LOTE_PILOTO(string ord_id, string value)
        {
            var query = _query.UpdateORD_LOTE_PILOTO(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_PRIORIDADE(string ord_id, int value)
        {
            var query = _query.UpdateORD_PRIORIDADE(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_EMISSAO(string ord_id, DateTime value)
        {
            var query = _query.UpdateORD_EMISSAO(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateREP_ID(string ord_id, string value)
        {
            var query = _query.UpdateREP_ID(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_RESINA(string ord_id, string value)
        {
            var query = _query.UpdateORD_RESINA(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_ENDURECEDOR_MIOLO(string ord_id, string value)
        {
            var query = _query.UpdateORD_ENDURECEDOR_MIOLO(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ID_INTEGRACAO_ERP(string ord_id, string value)
        {
            var query = _query.UpdatePRO_ID_INTEGRACAO_ERP(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_VINCOS_ONDULADEIRA(string ord_id, string value)
        {
            var query = _query.UpdateORD_VINCOS_ONDULADEIRA(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_ERP_CUSTOS_FIXOS(string ord_id, Decimal value)
        {
            var query = _query.UpdateORD_ERP_CUSTOS_FIXOS(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_ERP_CUSTOS_VARIAVEIS(string ord_id, Decimal value)
        {
            var query = _query.UpdateORD_ERP_CUSTOS_VARIAVEIS(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_ERP_DESPESAS_VAR_VENDA(string ord_id, Decimal value)
        {
            var query = _query.UpdateORD_ERP_DESPESAS_VAR_VENDA(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_ERP_IMPOSTOS(string ord_id, Decimal value)
        {
            var query = _query.UpdateORD_ERP_IMPOSTOS(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_STATUS_PLANEJAMENTO(string ord_id, string value)
        {
            var query = _query.UpdateORD_STATUS_PLANEJAMENTO(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_TOLERANCIA_DIMENSAO_CHAPA_DE(string ord_id, int value)
        {
            var query = _query.UpdateORD_TOLERANCIA_DIMENSAO_CHAPA_DE(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_TOLERANCIA_DIMENSAO_CHAPA_ATE(string ord_id, int value)
        {
            var query = _query.UpdateORD_TOLERANCIA_DIMENSAO_CHAPA_ATE(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_PROMOVE_DE(string ord_id, Decimal value)
        {
            var query = _query.UpdateORD_PROMOVE_DE(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_PROMOVE_ATE(string ord_id, Decimal value)
        {
            var query = _query.UpdateORD_PROMOVE_ATE(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_TRAVA_COMPOSICAO(string ord_id, string value)
        {
            var query = _query.UpdateORD_TRAVA_COMPOSICAO(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_TRAVA_RESINA(string ord_id, string value)
        {
            var query = _query.UpdateORD_TRAVA_RESINA(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_PROMOVE_RESINA(string ord_id, string value)
        {
            var query = _query.UpdateORD_PROMOVE_RESINA(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_LATITUDE_ENTREGA(string ord_id, Decimal value)
        {
            var query = _query.UpdateORD_LATITUDE_ENTREGA(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_LONGITUDE_ENTREGA(string ord_id, Decimal value)
        {
            var query = _query.UpdateORD_LONGITUDE_ENTREGA(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOCO_ID_CANCELAMENTO(string ord_id, string value)
        {
            var query = _query.UpdateOCO_ID_CANCELAMENTO(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTMP_TIPO_CARGA(string ord_id, string value)
        {
            var query = _query.UpdateTMP_TIPO_CARGA(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ID_PALETE(string ord_id, string value)
        {
            var query = _query.UpdatePRO_ID_PALETE(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ID_TAMPO(string ord_id, string value)
        {
            var query = _query.UpdatePRO_ID_TAMPO(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_PILHAS_POR_PALETE(string ord_id, int value)
        {
            var query = _query.UpdateORD_PILHAS_POR_PALETE(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_CHAPAS_POR_PILHA(string ord_id, int value)
        {
            var query = _query.UpdateORD_CHAPAS_POR_PILHA(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_DATA_CANCELAMENTO(string ord_id, DateTime value)
        {
            var query = _query.UpdateORD_DATA_CANCELAMENTO(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_STATUS_ESTATISTICA(string ord_id, string value)
        {
            var query = _query.UpdateORD_STATUS_ESTATISTICA(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_DATA_ESTATISTICA(string ord_id, DateTime value)
        {
            var query = _query.UpdateORD_DATA_ESTATISTICA(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOCO_ID_MOTIVO_ATRASO(string ord_id, string value)
        {
            var query = _query.UpdateOCO_ID_MOTIVO_ATRASO(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOTK_VERSSAO(string ord_id, int value)
        {
            var query = _query.UpdateOTK_VERSSAO(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(string ord_id, int value)
        {
            var query = _query.UpdateTenantID(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(string ord_id, bool value)
        {
            var query = _query.UpdateDeleted(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(string ord_id, DateTime value)
        {
            var query = _query.UpdateChanged(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(string ord_id, int value)
        {
            var query = _query.UpdateUserId(ord_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration