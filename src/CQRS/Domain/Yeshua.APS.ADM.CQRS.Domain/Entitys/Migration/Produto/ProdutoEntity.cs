// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeEntityMigration
// </yeshua>


                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class ProdutoEntity : IProdutoEntity
{
    public string Id { get; set; }
    public string Descricao { get; set; }
    public string Status { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    public Decimal? PRO_ESTOQUE_ATUAL { get; set; }
    public string UNI_ID { get; set; }
    public Decimal? PRO_FARDOS_POR_CAMADA { get; set; }
    public Decimal? PRO_CAMADAS_POR_PALETE { get; set; }
    public int? PRO_TIPO_IDENTIFICACAO { get; set; }
    public string PRO_GRUPO_PALETIZACAO { get; set; }
    public Decimal? PRO_PECAS_POR_FARDO { get; set; }
    public string PRO_ID_INTEGRACAO { get; set; }
    public string PRO_ID_INTEGRACAO_ERP { get; set; }
    public string GRP_ID { get; set; }
    public int? TEM_ID { get; set; }
    public Decimal? PRO_LARGURA_PECA { get; set; }
    public Decimal? PRO_COMPRIMENTO_PECA { get; set; }
    public Decimal? PRO_ALTURA_PECA { get; set; }
    public Decimal? PRO_LARGURA_EMBALADA { get; set; }
    public Decimal? PRO_COMPRIMENTO_EMBALADA { get; set; }
    public Decimal? PRO_ALTURA_EMBALADA { get; set; }
    public string PRO_FRENTE { get; set; }
    public string PRO_ROTACIONA_COMPRIMENTO { get; set; }
    public string PRO_ROTACIONA_LARGURA { get; set; }
    public string PRO_ROTACIONA_ALTURA { get; set; }
    public string PRO_ESCALA_COR { get; set; }
    public string PRO_SUB_ESCALA_COR { get; set; }
    public Decimal? PRO_CUSTO_SUBIDA_ESCALA_COR { get; set; }
    public Decimal? PRO_CUSTO_DECIDA_ESCALA_COR { get; set; }
    public string TMP_TIPO_CARGA { get; set; }
    public Decimal? PRO_TEMPO_CARREGAMENTO_UNITARIO { get; set; }
    public Decimal? PRO_TEMPO_DESCARREGAMENTO_UNITARIO { get; set; }
    public Decimal? PRO_PERCENTUAL_JANELA_EMBARQUE { get; set; }
    public Decimal? PRO_TEMPO_PRODUCAO_CONJUNTO { get; set; }
    public Decimal? PRO_PECAS_DA_PECA { get; set; }
    public int? PRO_TYPE { get; set; }
    public string PRO_COLOR_HEXA { get; set; }
    public string PRO_VINCOS_LARGURA { get; set; }
    public string PRO_VINCOS_COMPRIMENTO { get; set; }
    public Decimal? PRO_LARGURA_INTERNA { get; set; }
    public Decimal? PRO_COMPRIMENTO_INTERNA { get; set; }
    public Decimal? PRO_ALTURA_INTERNA { get; set; }
    public string PRO_COD_DESENHO { get; set; }
    public string PRO_FECHAMENTO { get; set; }
    public string PRO_TIPO_LAP { get; set; }
    public Decimal? PRO_TAMANHO_LAP { get; set; }
    public string PRO_LAP_PROLONGADO { get; set; }
    public Decimal? PRO_TAMANHO_LAP_PROLONG { get; set; }
    public Decimal? PRO_ARRANJO_LARGURA { get; set; }
    public Decimal? PRO_ARRANJO_COMPRIMENTO { get; set; }
    public int? PRO_FITILHOS_FARDO_LARG { get; set; }
    public int? PRO_FITILHOS_FARDO_COMP { get; set; }
    public int? PRO_FITILHOS_PALETE_LARG { get; set; }
    public int? PRO_FITILHOS_PALETE_COMP { get; set; }
    public int? PRO_FILME_PALETE { get; set; }
    public int? PRO_QTD_ESPELHO { get; set; }
    public Decimal? PRO_CUSTO { get; set; }
    public Decimal? PRO_AREA_LIQUIDA { get; set; }
    public Decimal? PRO_PESO { get; set; }
    public int? PRO_TOLERANCIA_DIMENSAO_CHAPA_DE { get; set; }
    public int? PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE { get; set; }
    public string PRO_IMG_LASTRO { get; set; }
    public string ABN_ID { get; set; }
    public int? SEG_ID { get; set; }
    public string PRO_RESINA { get; set; }
    public string PRO_ENDURECEDOR_MIOLO { get; set; }
    public string PRO_VINCOS_ONDULADEIRA { get; set; }
    public int? PRO_ADICIONAL_ABA_SUPERIOR { get; set; }
    public int? PRO_ADICIONAL_ABA_INFERIOR { get; set; }
    public string PRO_PROMOVE_RESINA { get; set; }
    public Decimal? PRO_PROMOVE_DE { get; set; }
    public Decimal? PRO_PROMOVE_ATE { get; set; }
    public int? PRO_PROFUNDIDADE_VINCO { get; set; }
    public int VIN_ID { get; set; }
    public string PRO_PROMOVE_PRODUTO { get; set; }
    public Decimal? PRO_TARA { get; set; }
    public Decimal? PRO_COMPRESSAO { get; set; }
    public string PRO_COD_BARRAS_CAIXA { get; set; }
    public string CJN_ID { get; set; }
    public string PRJ_ID { get; set; }
    public int? PRO_REFILE_LARGURA { get; set; }
    public int? PRO_REFILE_COMPRIMENTO { get; set; }
    public Decimal? PRO_M2_PONTA { get; set; }
    public int? PRO_QTD_CORTES_PECA1 { get; set; }
    public int? PRO_QTD_CORTES_PECA2 { get; set; }
    public string PRO_DIVISAO_MONTADA { get; set; }
    public Decimal? PRO_SEGMENTO_A { get; set; }
    public Decimal? PRO_SEGMENTO_B { get; set; }
    public Decimal? PRO_SEGMENTO_C { get; set; }
    public Decimal? PRO_SEGMENTO_D { get; set; }
    public Decimal? PRO_SEGMENTO_E { get; set; }
    public Decimal? PRO_SEGMENTO_F { get; set; }
    public Decimal? PRO_SEGMENTO_G { get; set; }
    public Decimal? PRO_SEGMENTO_H { get; set; }
    public Decimal? PRO_SEGMENTO_I { get; set; }
    public Decimal? PRO_QTD_GRAMPOS { get; set; }
    public Decimal? PRO_AREA_REFILE_INTERNO { get; set; }
    public Decimal? PRO_AREA_REFILE_EXTERNO { get; set; }
    public Decimal? PRO_PESO_REFILE { get; set; }
    public string PRO_ORELHA_INVERTIDA { get; set; }
    public string PRO_ENDERECO { get; set; }
    public string PRO_ID_VINCULADO { get; set; }
    public int? PRO_BATIDAS_PROXIMA_MANUTENCAO { get; set; }
    public string PRO_ENTRADA_NA_MAQUINA { get; set; }
    public string TDI_ID { get; set; }
    public int? PRO_QUEBRA_VINCO { get; set; }
    public int? PRO_LARGURA_FARDO { get; set; }
    public int? PRO_COMPRIMENTO_FARDO { get; set; }
    public Decimal? PRO_ALTURA_FARDO { get; set; }
    public string PRO_TIPO_CUSTO { get; set; }
    public string PRO_GRUPO_CONTABIL { get; set; }
    public string PRO_CLASSE_CUSTO_01 { get; set; }
    public string PRO_OBS_ALTERACAO { get; set; }
    public int? TIP_ID { get; set; }
    public Decimal? PRO_PECAS_POR_VEICULO { get; set; }
    public int? PRO_DISTANCIA_ENTRE_VINCOS { get; set; }
    public int? PRO_DISTANCIA_ENTRE_VINCOS2 { get; set; }
    public int? PRO_DISTANCIA_ENTRE_VINCOS3 { get; set; }
    public int? PRO_OUT { get; set; }
    public string PRO_ID_FACA { get; set; }
    public string PRO_ID_CLICHE { get; set; }
    public string PRO_ID_TINTA_01 { get; set; }
    public string PRO_ID_TINTA_02 { get; set; }
    public string PRO_ID_TINTA_03 { get; set; }
    public string PRO_ID_TINTA_04 { get; set; }
    public string PRO_ID_TINTA_05 { get; set; }
    public string PRO_ID_FORROSUP { get; set; }
    public string PRO_ID_CANTONEIRA { get; set; }
    public string PRO_ID_PALETE { get; set; }
    public string PRO_ID_TAMPO { get; set; }
    public string PRO_ID_FORROINF { get; set; }
    public string PRO_ID_CHAPA { get; set; }
    public string PRO_ID_COMPOSICAO { get; set; }
    public int? PRO_QUEBRA_VINCO_MAIOR { get; set; }
    public int? PRO_QUEBRA_VINCO_MENOR { get; set; }
    public string CLI_ID { get; set; }
    private List<string> _erroMensagem = null;
 internal ProdutoEntity(string id, string descricao, string status, Decimal? pro_estoque_atual, string uni_id, Decimal? pro_fardos_por_camada, Decimal? pro_camadas_por_palete, int? pro_tipo_identificacao, string pro_grupo_paletizacao, Decimal? pro_pecas_por_fardo, string pro_id_integracao, string pro_id_integracao_erp, string grp_id, int? tem_id, Decimal? pro_largura_peca, Decimal? pro_comprimento_peca, Decimal? pro_altura_peca, Decimal? pro_largura_embalada, Decimal? pro_comprimento_embalada, Decimal? pro_altura_embalada, string pro_frente, string pro_rotaciona_comprimento, string pro_rotaciona_largura, string pro_rotaciona_altura, string pro_escala_cor, string pro_sub_escala_cor, Decimal? pro_custo_subida_escala_cor, Decimal? pro_custo_decida_escala_cor, string tmp_tipo_carga, Decimal? pro_tempo_carregamento_unitario, Decimal? pro_tempo_descarregamento_unitario, Decimal? pro_percentual_janela_embarque, Decimal? pro_tempo_producao_conjunto, Decimal? pro_pecas_da_peca, int? pro_type, string pro_color_hexa, string pro_vincos_largura, string pro_vincos_comprimento, Decimal? pro_largura_interna, Decimal? pro_comprimento_interna, Decimal? pro_altura_interna, string pro_cod_desenho, string pro_fechamento, string pro_tipo_lap, Decimal? pro_tamanho_lap, string pro_lap_prolongado, Decimal? pro_tamanho_lap_prolong, Decimal? pro_arranjo_largura, Decimal? pro_arranjo_comprimento, int? pro_fitilhos_fardo_larg, int? pro_fitilhos_fardo_comp, int? pro_fitilhos_palete_larg, int? pro_fitilhos_palete_comp, int? pro_filme_palete, int? pro_qtd_espelho, Decimal? pro_custo, Decimal? pro_area_liquida, Decimal? pro_peso, int? pro_tolerancia_dimensao_chapa_de, int? pro_tolerancia_dimensao_chapa_ate, string pro_img_lastro, string abn_id, int? seg_id, string pro_resina, string pro_endurecedor_miolo, string pro_vincos_onduladeira, int? pro_adicional_aba_superior, int? pro_adicional_aba_inferior, string pro_promove_resina, Decimal? pro_promove_de, Decimal? pro_promove_ate, int? pro_profundidade_vinco, int vin_id, string pro_promove_produto, Decimal? pro_tara, Decimal? pro_compressao, string pro_cod_barras_caixa, string cjn_id, string prj_id, int? pro_refile_largura, int? pro_refile_comprimento, Decimal? pro_m2_ponta, int? pro_qtd_cortes_peca1, int? pro_qtd_cortes_peca2, string pro_divisao_montada, Decimal? pro_segmento_a, Decimal? pro_segmento_b, Decimal? pro_segmento_c, Decimal? pro_segmento_d, Decimal? pro_segmento_e, Decimal? pro_segmento_f, Decimal? pro_segmento_g, Decimal? pro_segmento_h, Decimal? pro_segmento_i, Decimal? pro_qtd_grampos, Decimal? pro_area_refile_interno, Decimal? pro_area_refile_externo, Decimal? pro_peso_refile, string pro_orelha_invertida, string pro_endereco, string pro_id_vinculado, int? pro_batidas_proxima_manutencao, string pro_entrada_na_maquina, string tdi_id, int? pro_quebra_vinco, int? pro_largura_fardo, int? pro_comprimento_fardo, Decimal? pro_altura_fardo, string pro_tipo_custo, string pro_grupo_contabil, string pro_classe_custo_01, string pro_obs_alteracao, int? tip_id, Decimal? pro_pecas_por_veiculo, int? pro_distancia_entre_vincos, int? pro_distancia_entre_vincos2, int? pro_distancia_entre_vincos3, int? pro_out, string pro_id_faca, string pro_id_cliche, string pro_id_tinta_01, string pro_id_tinta_02, string pro_id_tinta_03, string pro_id_tinta_04, string pro_id_tinta_05, string pro_id_forrosup, string pro_id_cantoneira, string pro_id_palete, string pro_id_tampo, string pro_id_forroinf, string pro_id_chapa, string pro_id_composicao, int? pro_quebra_vinco_maior, int? pro_quebra_vinco_menor, string cli_id ){
 Id = id; 
 Descricao = descricao; 
 Status = status; 
 PRO_ESTOQUE_ATUAL = pro_estoque_atual; 
 UNI_ID = uni_id; 
 PRO_FARDOS_POR_CAMADA = pro_fardos_por_camada; 
 PRO_CAMADAS_POR_PALETE = pro_camadas_por_palete; 
 PRO_TIPO_IDENTIFICACAO = pro_tipo_identificacao; 
 PRO_GRUPO_PALETIZACAO = pro_grupo_paletizacao; 
 PRO_PECAS_POR_FARDO = pro_pecas_por_fardo; 
 PRO_ID_INTEGRACAO = pro_id_integracao; 
 PRO_ID_INTEGRACAO_ERP = pro_id_integracao_erp; 
 GRP_ID = grp_id; 
 TEM_ID = tem_id; 
 PRO_LARGURA_PECA = pro_largura_peca; 
 PRO_COMPRIMENTO_PECA = pro_comprimento_peca; 
 PRO_ALTURA_PECA = pro_altura_peca; 
 PRO_LARGURA_EMBALADA = pro_largura_embalada; 
 PRO_COMPRIMENTO_EMBALADA = pro_comprimento_embalada; 
 PRO_ALTURA_EMBALADA = pro_altura_embalada; 
 PRO_FRENTE = pro_frente; 
 PRO_ROTACIONA_COMPRIMENTO = pro_rotaciona_comprimento; 
 PRO_ROTACIONA_LARGURA = pro_rotaciona_largura; 
 PRO_ROTACIONA_ALTURA = pro_rotaciona_altura; 
 PRO_ESCALA_COR = pro_escala_cor; 
 PRO_SUB_ESCALA_COR = pro_sub_escala_cor; 
 PRO_CUSTO_SUBIDA_ESCALA_COR = pro_custo_subida_escala_cor; 
 PRO_CUSTO_DECIDA_ESCALA_COR = pro_custo_decida_escala_cor; 
 TMP_TIPO_CARGA = tmp_tipo_carga; 
 PRO_TEMPO_CARREGAMENTO_UNITARIO = pro_tempo_carregamento_unitario; 
 PRO_TEMPO_DESCARREGAMENTO_UNITARIO = pro_tempo_descarregamento_unitario; 
 PRO_PERCENTUAL_JANELA_EMBARQUE = pro_percentual_janela_embarque; 
 PRO_TEMPO_PRODUCAO_CONJUNTO = pro_tempo_producao_conjunto; 
 PRO_PECAS_DA_PECA = pro_pecas_da_peca; 
 PRO_TYPE = pro_type; 
 PRO_COLOR_HEXA = pro_color_hexa; 
 PRO_VINCOS_LARGURA = pro_vincos_largura; 
 PRO_VINCOS_COMPRIMENTO = pro_vincos_comprimento; 
 PRO_LARGURA_INTERNA = pro_largura_interna; 
 PRO_COMPRIMENTO_INTERNA = pro_comprimento_interna; 
 PRO_ALTURA_INTERNA = pro_altura_interna; 
 PRO_COD_DESENHO = pro_cod_desenho; 
 PRO_FECHAMENTO = pro_fechamento; 
 PRO_TIPO_LAP = pro_tipo_lap; 
 PRO_TAMANHO_LAP = pro_tamanho_lap; 
 PRO_LAP_PROLONGADO = pro_lap_prolongado; 
 PRO_TAMANHO_LAP_PROLONG = pro_tamanho_lap_prolong; 
 PRO_ARRANJO_LARGURA = pro_arranjo_largura; 
 PRO_ARRANJO_COMPRIMENTO = pro_arranjo_comprimento; 
 PRO_FITILHOS_FARDO_LARG = pro_fitilhos_fardo_larg; 
 PRO_FITILHOS_FARDO_COMP = pro_fitilhos_fardo_comp; 
 PRO_FITILHOS_PALETE_LARG = pro_fitilhos_palete_larg; 
 PRO_FITILHOS_PALETE_COMP = pro_fitilhos_palete_comp; 
 PRO_FILME_PALETE = pro_filme_palete; 
 PRO_QTD_ESPELHO = pro_qtd_espelho; 
 PRO_CUSTO = pro_custo; 
 PRO_AREA_LIQUIDA = pro_area_liquida; 
 PRO_PESO = pro_peso; 
 PRO_TOLERANCIA_DIMENSAO_CHAPA_DE = pro_tolerancia_dimensao_chapa_de; 
 PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE = pro_tolerancia_dimensao_chapa_ate; 
 PRO_IMG_LASTRO = pro_img_lastro; 
 ABN_ID = abn_id; 
 SEG_ID = seg_id; 
 PRO_RESINA = pro_resina; 
 PRO_ENDURECEDOR_MIOLO = pro_endurecedor_miolo; 
 PRO_VINCOS_ONDULADEIRA = pro_vincos_onduladeira; 
 PRO_ADICIONAL_ABA_SUPERIOR = pro_adicional_aba_superior; 
 PRO_ADICIONAL_ABA_INFERIOR = pro_adicional_aba_inferior; 
 PRO_PROMOVE_RESINA = pro_promove_resina; 
 PRO_PROMOVE_DE = pro_promove_de; 
 PRO_PROMOVE_ATE = pro_promove_ate; 
 PRO_PROFUNDIDADE_VINCO = pro_profundidade_vinco; 
 VIN_ID = vin_id; 
 PRO_PROMOVE_PRODUTO = pro_promove_produto; 
 PRO_TARA = pro_tara; 
 PRO_COMPRESSAO = pro_compressao; 
 PRO_COD_BARRAS_CAIXA = pro_cod_barras_caixa; 
 CJN_ID = cjn_id; 
 PRJ_ID = prj_id; 
 PRO_REFILE_LARGURA = pro_refile_largura; 
 PRO_REFILE_COMPRIMENTO = pro_refile_comprimento; 
 PRO_M2_PONTA = pro_m2_ponta; 
 PRO_QTD_CORTES_PECA1 = pro_qtd_cortes_peca1; 
 PRO_QTD_CORTES_PECA2 = pro_qtd_cortes_peca2; 
 PRO_DIVISAO_MONTADA = pro_divisao_montada; 
 PRO_SEGMENTO_A = pro_segmento_a; 
 PRO_SEGMENTO_B = pro_segmento_b; 
 PRO_SEGMENTO_C = pro_segmento_c; 
 PRO_SEGMENTO_D = pro_segmento_d; 
 PRO_SEGMENTO_E = pro_segmento_e; 
 PRO_SEGMENTO_F = pro_segmento_f; 
 PRO_SEGMENTO_G = pro_segmento_g; 
 PRO_SEGMENTO_H = pro_segmento_h; 
 PRO_SEGMENTO_I = pro_segmento_i; 
 PRO_QTD_GRAMPOS = pro_qtd_grampos; 
 PRO_AREA_REFILE_INTERNO = pro_area_refile_interno; 
 PRO_AREA_REFILE_EXTERNO = pro_area_refile_externo; 
 PRO_PESO_REFILE = pro_peso_refile; 
 PRO_ORELHA_INVERTIDA = pro_orelha_invertida; 
 PRO_ENDERECO = pro_endereco; 
 PRO_ID_VINCULADO = pro_id_vinculado; 
 PRO_BATIDAS_PROXIMA_MANUTENCAO = pro_batidas_proxima_manutencao; 
 PRO_ENTRADA_NA_MAQUINA = pro_entrada_na_maquina; 
 TDI_ID = tdi_id; 
 PRO_QUEBRA_VINCO = pro_quebra_vinco; 
 PRO_LARGURA_FARDO = pro_largura_fardo; 
 PRO_COMPRIMENTO_FARDO = pro_comprimento_fardo; 
 PRO_ALTURA_FARDO = pro_altura_fardo; 
 PRO_TIPO_CUSTO = pro_tipo_custo; 
 PRO_GRUPO_CONTABIL = pro_grupo_contabil; 
 PRO_CLASSE_CUSTO_01 = pro_classe_custo_01; 
 PRO_OBS_ALTERACAO = pro_obs_alteracao; 
 TIP_ID = tip_id; 
 PRO_PECAS_POR_VEICULO = pro_pecas_por_veiculo; 
 PRO_DISTANCIA_ENTRE_VINCOS = pro_distancia_entre_vincos; 
 PRO_DISTANCIA_ENTRE_VINCOS2 = pro_distancia_entre_vincos2; 
 PRO_DISTANCIA_ENTRE_VINCOS3 = pro_distancia_entre_vincos3; 
 PRO_OUT = pro_out; 
 PRO_ID_FACA = pro_id_faca; 
 PRO_ID_CLICHE = pro_id_cliche; 
 PRO_ID_TINTA_01 = pro_id_tinta_01; 
 PRO_ID_TINTA_02 = pro_id_tinta_02; 
 PRO_ID_TINTA_03 = pro_id_tinta_03; 
 PRO_ID_TINTA_04 = pro_id_tinta_04; 
 PRO_ID_TINTA_05 = pro_id_tinta_05; 
 PRO_ID_FORROSUP = pro_id_forrosup; 
 PRO_ID_CANTONEIRA = pro_id_cantoneira; 
 PRO_ID_PALETE = pro_id_palete; 
 PRO_ID_TAMPO = pro_id_tampo; 
 PRO_ID_FORROINF = pro_id_forroinf; 
 PRO_ID_CHAPA = pro_id_chapa; 
 PRO_ID_COMPOSICAO = pro_id_composicao; 
 PRO_QUEBRA_VINCO_MAIOR = pro_quebra_vinco_maior; 
 PRO_QUEBRA_VINCO_MENOR = pro_quebra_vinco_menor; 
 CLI_ID = cli_id; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(UNI_ID))
   this._erroMensagem.Add("UNI ID deve ser informado.");
   if(string.IsNullOrEmpty(GRP_ID))
   this._erroMensagem.Add("GRP ID deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration