// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration
// </yeshua>

using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IOrderQueryWrite 
     {
        public QueryModel InserirOrderQuery(IOrderEntity Order);
        public QueryModel UpdateOrderQuery(IOrderEntity Order);
        QueryModel UpdateORD_ID_RESERVA(string ord_id, string value);
        QueryModel UpdateORD_ID_CONJUNTO(string ord_id, string value);
        QueryModel UpdatePRO_ID(string ord_id, string value);
        QueryModel UpdatePRO_ID_CONJUNTO(string ord_id, string value);
        QueryModel UpdateCLI_ID(string ord_id, string value);
        QueryModel UpdateORD_PRECO_UNITARIO(string ord_id, Decimal value);
        QueryModel UpdateORD_QUANTIDADE(string ord_id, Decimal value);
        QueryModel UpdateORD_DATA_ENTREGA_DE(string ord_id, DateTime value);
        QueryModel UpdateORD_DATA_ENTREGA_ATE(string ord_id, DateTime value);
        QueryModel UpdateORD_TIPO(string ord_id, int value);
        QueryModel UpdateORD_TOLERANCIA_MAIS(string ord_id, Decimal value);
        QueryModel UpdateORD_TOLERANCIA_MENOS(string ord_id, Decimal value);
        QueryModel UpdateHASH_KEY(string ord_id, string value);
        QueryModel UpdateORD_INICIO_JANELA_EMBARQUE(string ord_id, DateTime value);
        QueryModel UpdateORD_FIM_JANELA_EMBARQUE(string ord_id, DateTime value);
        QueryModel UpdateORD_EMBARQUE_ALVO(string ord_id, DateTime value);
        QueryModel UpdateORD_INICIO_GRUPO_PRODUTIVO(string ord_id, DateTime value);
        QueryModel UpdateORD_FIM_GRUPO_PRODUTIVO(string ord_id, DateTime value);
        QueryModel UpdateORD_PESO_UNITARIO(string ord_id, Decimal value);
        QueryModel UpdateORD_PESO_UNITARIO_BRUTO(string ord_id, Decimal value);
        QueryModel UpdateORD_M2_UNITARIO(string ord_id, Decimal value);
        QueryModel UpdateORD_MIT(string ord_id, string value);
        QueryModel UpdateCAR_TIPO_CARREGAMENTO(string ord_id, string value);
        QueryModel UpdateORD_STATUS(string ord_id, string value);
        QueryModel UpdateORD_TIPO_FRETE(string ord_id, string value);
        QueryModel UpdateORD_ENDERECO_ENTREGA(string ord_id, string value);
        QueryModel UpdateORD_BAIRRO_ENTREGA(string ord_id, string value);
        QueryModel UpdateUF_ID_ENTREGA(string ord_id, string value);
        QueryModel UpdateORD_CEP_ENTREGA(string ord_id, string value);
        QueryModel UpdateMUN_ID_ENTREGA(string ord_id, string value);
        QueryModel UpdateORD_REGIAO_ENTREGA(string ord_id, string value);
        QueryModel UpdateORD_LARGURA(string ord_id, Decimal value);
        QueryModel UpdateORD_COMPRIMENTO(string ord_id, Decimal value);
        QueryModel UpdateORD_GRAMATURA(string ord_id, Decimal value);
        QueryModel UpdateGRP_ID(string ord_id, string value);
        QueryModel UpdateORD_ID_INTEGRACAO(string ord_id, string value);
        QueryModel UpdateORD_OBSERVACAO_OTIMIZADOR(string ord_id, string value);
        QueryModel UpdateORD_COR_FILA(string ord_id, string value);
        QueryModel UpdateORD_PED_CLI(string ord_id, string value);
        QueryModel UpdateORD_OP_INTEGRACAO(string ord_id, string value);
        QueryModel UpdateORD_LOTE_PILOTO(string ord_id, string value);
        QueryModel UpdateORD_PRIORIDADE(string ord_id, int value);
        QueryModel UpdateORD_EMISSAO(string ord_id, DateTime value);
        QueryModel UpdateREP_ID(string ord_id, string value);
        QueryModel UpdateORD_RESINA(string ord_id, string value);
        QueryModel UpdateORD_ENDURECEDOR_MIOLO(string ord_id, string value);
        QueryModel UpdatePRO_ID_INTEGRACAO_ERP(string ord_id, string value);
        QueryModel UpdateORD_VINCOS_ONDULADEIRA(string ord_id, string value);
        QueryModel UpdateORD_ERP_CUSTOS_FIXOS(string ord_id, Decimal value);
        QueryModel UpdateORD_ERP_CUSTOS_VARIAVEIS(string ord_id, Decimal value);
        QueryModel UpdateORD_ERP_DESPESAS_VAR_VENDA(string ord_id, Decimal value);
        QueryModel UpdateORD_ERP_IMPOSTOS(string ord_id, Decimal value);
        QueryModel UpdateORD_STATUS_PLANEJAMENTO(string ord_id, string value);
        QueryModel UpdateORD_TOLERANCIA_DIMENSAO_CHAPA_DE(string ord_id, int value);
        QueryModel UpdateORD_TOLERANCIA_DIMENSAO_CHAPA_ATE(string ord_id, int value);
        QueryModel UpdateORD_PROMOVE_DE(string ord_id, Decimal value);
        QueryModel UpdateORD_PROMOVE_ATE(string ord_id, Decimal value);
        QueryModel UpdateORD_TRAVA_COMPOSICAO(string ord_id, string value);
        QueryModel UpdateORD_TRAVA_RESINA(string ord_id, string value);
        QueryModel UpdateORD_PROMOVE_RESINA(string ord_id, string value);
        QueryModel UpdateORD_LATITUDE_ENTREGA(string ord_id, Decimal value);
        QueryModel UpdateORD_LONGITUDE_ENTREGA(string ord_id, Decimal value);
        QueryModel UpdateOCO_ID_CANCELAMENTO(string ord_id, string value);
        QueryModel UpdateTMP_TIPO_CARGA(string ord_id, string value);
        QueryModel UpdatePRO_ID_PALETE(string ord_id, string value);
        QueryModel UpdatePRO_ID_TAMPO(string ord_id, string value);
        QueryModel UpdateORD_PILHAS_POR_PALETE(string ord_id, int value);
        QueryModel UpdateORD_CHAPAS_POR_PILHA(string ord_id, int value);
        QueryModel UpdateORD_DATA_CANCELAMENTO(string ord_id, DateTime value);
        QueryModel UpdateORD_STATUS_ESTATISTICA(string ord_id, string value);
        QueryModel UpdateORD_DATA_ESTATISTICA(string ord_id, DateTime value);
        QueryModel UpdateOCO_ID_MOTIVO_ATRASO(string ord_id, string value);
        QueryModel UpdateOTK_VERSSAO(string ord_id, int value);
        QueryModel UpdateTenantID(string ord_id, int value);
        QueryModel UpdateDeleted(string ord_id, bool value);
        QueryModel UpdateChanged(string ord_id, DateTime value);
        QueryModel UpdateUserId(string ord_id, int value);
        public QueryModel DeleteOrderQuery(IOrderEntity Order);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration