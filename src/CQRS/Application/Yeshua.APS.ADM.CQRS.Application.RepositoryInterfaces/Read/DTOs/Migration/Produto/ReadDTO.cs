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
    public partial record ProdutoDTO
    {
    public string id { get; set; }
    public string descricao { get; set; }
    public string status { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    public Decimal pro_estoque_atual { get; set; }
    public string uni_id { get; set; }
    public Decimal pro_fardos_por_camada { get; set; }
    public Decimal pro_camadas_por_palete { get; set; }
    public int pro_tipo_identificacao { get; set; }
    public string pro_grupo_paletizacao { get; set; }
    public Decimal pro_pecas_por_fardo { get; set; }
    public string pro_id_integracao { get; set; }
    public string pro_id_integracao_erp { get; set; }
    public string grp_id { get; set; }
    public int tem_id { get; set; }
    public Decimal pro_largura_peca { get; set; }
    public Decimal pro_comprimento_peca { get; set; }
    public Decimal pro_altura_peca { get; set; }
    public Decimal pro_largura_embalada { get; set; }
    public Decimal pro_comprimento_embalada { get; set; }
    public Decimal pro_altura_embalada { get; set; }
    public string pro_frente { get; set; }
    public string pro_rotaciona_comprimento { get; set; }
    public string pro_rotaciona_largura { get; set; }
    public string pro_rotaciona_altura { get; set; }
    public string pro_escala_cor { get; set; }
    public string pro_sub_escala_cor { get; set; }
    public Decimal pro_custo_subida_escala_cor { get; set; }
    public Decimal pro_custo_decida_escala_cor { get; set; }
    public string tmp_tipo_carga { get; set; }
    public Decimal pro_tempo_carregamento_unitario { get; set; }
    public Decimal pro_tempo_descarregamento_unitario { get; set; }
    public Decimal pro_percentual_janela_embarque { get; set; }
    public Decimal pro_tempo_producao_conjunto { get; set; }
    public Decimal pro_pecas_da_peca { get; set; }
    public int pro_type { get; set; }
    public string pro_color_hexa { get; set; }
    public string pro_vincos_largura { get; set; }
    public string pro_vincos_comprimento { get; set; }
    public Decimal pro_largura_interna { get; set; }
    public Decimal pro_comprimento_interna { get; set; }
    public Decimal pro_altura_interna { get; set; }
    public string pro_cod_desenho { get; set; }
    public string pro_fechamento { get; set; }
    public string pro_tipo_lap { get; set; }
    public Decimal pro_tamanho_lap { get; set; }
    public string pro_lap_prolongado { get; set; }
    public Decimal pro_tamanho_lap_prolong { get; set; }
    public Decimal pro_arranjo_largura { get; set; }
    public Decimal pro_arranjo_comprimento { get; set; }
    public int pro_fitilhos_fardo_larg { get; set; }
    public int pro_fitilhos_fardo_comp { get; set; }
    public int pro_fitilhos_palete_larg { get; set; }
    public int pro_fitilhos_palete_comp { get; set; }
    public int pro_filme_palete { get; set; }
    public int pro_qtd_espelho { get; set; }
    public Decimal pro_custo { get; set; }
    public Decimal pro_area_liquida { get; set; }
    public Decimal pro_peso { get; set; }
    public int pro_tolerancia_dimensao_chapa_de { get; set; }
    public int pro_tolerancia_dimensao_chapa_ate { get; set; }
    public string pro_img_lastro { get; set; }
    public string abn_id { get; set; }
    public int seg_id { get; set; }
    public string pro_resina { get; set; }
    public string pro_endurecedor_miolo { get; set; }
    public string pro_vincos_onduladeira { get; set; }
    public int pro_adicional_aba_superior { get; set; }
    public int pro_adicional_aba_inferior { get; set; }
    public string pro_promove_resina { get; set; }
    public Decimal pro_promove_de { get; set; }
    public Decimal pro_promove_ate { get; set; }
    public int pro_profundidade_vinco { get; set; }
    public int vin_id { get; set; }
    public string pro_promove_produto { get; set; }
    public Decimal pro_tara { get; set; }
    public Decimal pro_compressao { get; set; }
    public string pro_cod_barras_caixa { get; set; }
    public string cjn_id { get; set; }
    public string prj_id { get; set; }
    public int pro_refile_largura { get; set; }
    public int pro_refile_comprimento { get; set; }
    public Decimal pro_m2_ponta { get; set; }
    public int pro_qtd_cortes_peca1 { get; set; }
    public int pro_qtd_cortes_peca2 { get; set; }
    public string pro_divisao_montada { get; set; }
    public Decimal pro_segmento_a { get; set; }
    public Decimal pro_segmento_b { get; set; }
    public Decimal pro_segmento_c { get; set; }
    public Decimal pro_segmento_d { get; set; }
    public Decimal pro_segmento_e { get; set; }
    public Decimal pro_segmento_f { get; set; }
    public Decimal pro_segmento_g { get; set; }
    public Decimal pro_segmento_h { get; set; }
    public Decimal pro_segmento_i { get; set; }
    public Decimal pro_qtd_grampos { get; set; }
    public Decimal pro_area_refile_interno { get; set; }
    public Decimal pro_area_refile_externo { get; set; }
    public Decimal pro_peso_refile { get; set; }
    public string pro_orelha_invertida { get; set; }
    public string pro_endereco { get; set; }
    public string pro_id_vinculado { get; set; }
    public int pro_batidas_proxima_manutencao { get; set; }
    public string pro_entrada_na_maquina { get; set; }
    public string tdi_id { get; set; }
    public int pro_quebra_vinco { get; set; }
    public int pro_largura_fardo { get; set; }
    public int pro_comprimento_fardo { get; set; }
    public Decimal pro_altura_fardo { get; set; }
    public string pro_tipo_custo { get; set; }
    public string pro_grupo_contabil { get; set; }
    public string pro_classe_custo_01 { get; set; }
    public string pro_obs_alteracao { get; set; }
    public int tip_id { get; set; }
    public Decimal pro_pecas_por_veiculo { get; set; }
    public int pro_distancia_entre_vincos { get; set; }
    public int pro_distancia_entre_vincos2 { get; set; }
    public int pro_distancia_entre_vincos3 { get; set; }
    public int pro_out { get; set; }
    public string pro_id_faca { get; set; }
    public string pro_id_cliche { get; set; }
    public string pro_id_tinta_01 { get; set; }
    public string pro_id_tinta_02 { get; set; }
    public string pro_id_tinta_03 { get; set; }
    public string pro_id_tinta_04 { get; set; }
    public string pro_id_tinta_05 { get; set; }
    public string pro_id_forrosup { get; set; }
    public string pro_id_cantoneira { get; set; }
    public string pro_id_palete { get; set; }
    public string pro_id_tampo { get; set; }
    public string pro_id_forroinf { get; set; }
    public string pro_id_chapa { get; set; }
    public string pro_id_composicao { get; set; }
    public int pro_quebra_vinco_maior { get; set; }
    public int pro_quebra_vinco_menor { get; set; }
    public string cli_id { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration