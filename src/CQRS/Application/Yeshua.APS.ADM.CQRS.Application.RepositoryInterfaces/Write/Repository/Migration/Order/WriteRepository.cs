// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration
// </yeshua>

using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IOrderWriteRepository
    {
        void Insert(IOrderEntity order);
        void Update(IOrderEntity order);
        void Delete(IOrderEntity order);
        void UpdateORD_ID_RESERVA(string ord_id, string value);
        void UpdateORD_ID_CONJUNTO(string ord_id, string value);
        void UpdatePRO_ID(string ord_id, string value);
        void UpdatePRO_ID_CONJUNTO(string ord_id, string value);
        void UpdateCLI_ID(string ord_id, string value);
        void UpdateORD_PRECO_UNITARIO(string ord_id, Decimal value);
        void UpdateORD_QUANTIDADE(string ord_id, Decimal value);
        void UpdateORD_DATA_ENTREGA_DE(string ord_id, DateTime value);
        void UpdateORD_DATA_ENTREGA_ATE(string ord_id, DateTime value);
        void UpdateORD_TIPO(string ord_id, int value);
        void UpdateORD_TOLERANCIA_MAIS(string ord_id, Decimal value);
        void UpdateORD_TOLERANCIA_MENOS(string ord_id, Decimal value);
        void UpdateHASH_KEY(string ord_id, string value);
        void UpdateORD_INICIO_JANELA_EMBARQUE(string ord_id, DateTime value);
        void UpdateORD_FIM_JANELA_EMBARQUE(string ord_id, DateTime value);
        void UpdateORD_EMBARQUE_ALVO(string ord_id, DateTime value);
        void UpdateORD_INICIO_GRUPO_PRODUTIVO(string ord_id, DateTime value);
        void UpdateORD_FIM_GRUPO_PRODUTIVO(string ord_id, DateTime value);
        void UpdateORD_PESO_UNITARIO(string ord_id, Decimal value);
        void UpdateORD_PESO_UNITARIO_BRUTO(string ord_id, Decimal value);
        void UpdateORD_M2_UNITARIO(string ord_id, Decimal value);
        void UpdateORD_MIT(string ord_id, string value);
        void UpdateCAR_TIPO_CARREGAMENTO(string ord_id, string value);
        void UpdateORD_STATUS(string ord_id, string value);
        void UpdateORD_TIPO_FRETE(string ord_id, string value);
        void UpdateORD_ENDERECO_ENTREGA(string ord_id, string value);
        void UpdateORD_BAIRRO_ENTREGA(string ord_id, string value);
        void UpdateUF_ID_ENTREGA(string ord_id, string value);
        void UpdateORD_CEP_ENTREGA(string ord_id, string value);
        void UpdateMUN_ID_ENTREGA(string ord_id, string value);
        void UpdateORD_REGIAO_ENTREGA(string ord_id, string value);
        void UpdateORD_LARGURA(string ord_id, Decimal value);
        void UpdateORD_COMPRIMENTO(string ord_id, Decimal value);
        void UpdateORD_GRAMATURA(string ord_id, Decimal value);
        void UpdateGRP_ID(string ord_id, string value);
        void UpdateORD_ID_INTEGRACAO(string ord_id, string value);
        void UpdateORD_OBSERVACAO_OTIMIZADOR(string ord_id, string value);
        void UpdateORD_COR_FILA(string ord_id, string value);
        void UpdateORD_PED_CLI(string ord_id, string value);
        void UpdateORD_OP_INTEGRACAO(string ord_id, string value);
        void UpdateORD_LOTE_PILOTO(string ord_id, string value);
        void UpdateORD_PRIORIDADE(string ord_id, int value);
        void UpdateORD_EMISSAO(string ord_id, DateTime value);
        void UpdateREP_ID(string ord_id, string value);
        void UpdateORD_RESINA(string ord_id, string value);
        void UpdateORD_ENDURECEDOR_MIOLO(string ord_id, string value);
        void UpdatePRO_ID_INTEGRACAO_ERP(string ord_id, string value);
        void UpdateORD_VINCOS_ONDULADEIRA(string ord_id, string value);
        void UpdateORD_ERP_CUSTOS_FIXOS(string ord_id, Decimal value);
        void UpdateORD_ERP_CUSTOS_VARIAVEIS(string ord_id, Decimal value);
        void UpdateORD_ERP_DESPESAS_VAR_VENDA(string ord_id, Decimal value);
        void UpdateORD_ERP_IMPOSTOS(string ord_id, Decimal value);
        void UpdateORD_STATUS_PLANEJAMENTO(string ord_id, string value);
        void UpdateORD_TOLERANCIA_DIMENSAO_CHAPA_DE(string ord_id, int value);
        void UpdateORD_TOLERANCIA_DIMENSAO_CHAPA_ATE(string ord_id, int value);
        void UpdateORD_PROMOVE_DE(string ord_id, Decimal value);
        void UpdateORD_PROMOVE_ATE(string ord_id, Decimal value);
        void UpdateORD_TRAVA_COMPOSICAO(string ord_id, string value);
        void UpdateORD_TRAVA_RESINA(string ord_id, string value);
        void UpdateORD_PROMOVE_RESINA(string ord_id, string value);
        void UpdateORD_LATITUDE_ENTREGA(string ord_id, Decimal value);
        void UpdateORD_LONGITUDE_ENTREGA(string ord_id, Decimal value);
        void UpdateOCO_ID_CANCELAMENTO(string ord_id, string value);
        void UpdateTMP_TIPO_CARGA(string ord_id, string value);
        void UpdatePRO_ID_PALETE(string ord_id, string value);
        void UpdatePRO_ID_TAMPO(string ord_id, string value);
        void UpdateORD_PILHAS_POR_PALETE(string ord_id, int value);
        void UpdateORD_CHAPAS_POR_PILHA(string ord_id, int value);
        void UpdateORD_DATA_CANCELAMENTO(string ord_id, DateTime value);
        void UpdateORD_STATUS_ESTATISTICA(string ord_id, string value);
        void UpdateORD_DATA_ESTATISTICA(string ord_id, DateTime value);
        void UpdateOCO_ID_MOTIVO_ATRASO(string ord_id, string value);
        void UpdateOTK_VERSSAO(string ord_id, int value);
        void UpdateTenantID(string ord_id, int value);
        void UpdateDeleted(string ord_id, bool value);
        void UpdateChanged(string ord_id, DateTime value);
        void UpdateUserId(string ord_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration