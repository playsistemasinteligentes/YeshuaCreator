// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration
// </yeshua>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Outputs
{
    public partial record OrderDTO
    {
    public string ord_id { get; set; }
    public string ord_id_reserva { get; set; }
    public string ord_id_conjunto { get; set; }
    public string pro_id { get; set; }
    public string pro_id_conjunto { get; set; }
    public string cli_id { get; set; }
    public Decimal ord_preco_unitario { get; set; }
    public Decimal ord_quantidade { get; set; }
    public DateTime ord_data_entrega_de { get; set; }
    public DateTime ord_data_entrega_ate { get; set; }
    public int ord_tipo { get; set; }
    public Decimal ord_tolerancia_mais { get; set; }
    public Decimal ord_tolerancia_menos { get; set; }
    public string hash_key { get; set; }
    public DateTime ord_inicio_janela_embarque { get; set; }
    public DateTime ord_fim_janela_embarque { get; set; }
    public DateTime ord_embarque_alvo { get; set; }
    public DateTime ord_inicio_grupo_produtivo { get; set; }
    public DateTime ord_fim_grupo_produtivo { get; set; }
    public Decimal ord_peso_unitario { get; set; }
    public Decimal ord_peso_unitario_bruto { get; set; }
    public Decimal ord_m2_unitario { get; set; }
    public string ord_mit { get; set; }
    public string car_tipo_carregamento { get; set; }
    public string ord_status { get; set; }
    public string ord_tipo_frete { get; set; }
    public string ord_endereco_entrega { get; set; }
    public string ord_bairro_entrega { get; set; }
    public string uf_id_entrega { get; set; }
    public string ord_cep_entrega { get; set; }
    public string mun_id_entrega { get; set; }
    public string ord_regiao_entrega { get; set; }
    public Decimal ord_largura { get; set; }
    public Decimal ord_comprimento { get; set; }
    public Decimal ord_gramatura { get; set; }
    public string grp_id { get; set; }
    public string ord_id_integracao { get; set; }
    public string ord_observacao_otimizador { get; set; }
    public string ord_cor_fila { get; set; }
    public string ord_ped_cli { get; set; }
    public string ord_op_integracao { get; set; }
    public string ord_lote_piloto { get; set; }
    public int ord_prioridade { get; set; }
    public DateTime ord_emissao { get; set; }
    public string rep_id { get; set; }
    public string ord_resina { get; set; }
    public string ord_endurecedor_miolo { get; set; }
    public string pro_id_integracao_erp { get; set; }
    public string ord_vincos_onduladeira { get; set; }
    public Decimal ord_erp_custos_fixos { get; set; }
    public Decimal ord_erp_custos_variaveis { get; set; }
    public Decimal ord_erp_despesas_var_venda { get; set; }
    public Decimal ord_erp_impostos { get; set; }
    public string ord_status_planejamento { get; set; }
    public int ord_tolerancia_dimensao_chapa_de { get; set; }
    public int ord_tolerancia_dimensao_chapa_ate { get; set; }
    public Decimal ord_promove_de { get; set; }
    public Decimal ord_promove_ate { get; set; }
    public string ord_trava_composicao { get; set; }
    public string ord_trava_resina { get; set; }
    public string ord_promove_resina { get; set; }
    public Decimal ord_latitude_entrega { get; set; }
    public Decimal ord_longitude_entrega { get; set; }
    public string oco_id_cancelamento { get; set; }
    public string tmp_tipo_carga { get; set; }
    public string pro_id_palete { get; set; }
    public string pro_id_tampo { get; set; }
    public int ord_pilhas_por_palete { get; set; }
    public int ord_chapas_por_pilha { get; set; }
    public DateTime ord_data_cancelamento { get; set; }
    public string ord_status_estatistica { get; set; }
    public DateTime ord_data_estatistica { get; set; }
    public string oco_id_motivo_atraso { get; set; }
    public int otk_verssao { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration