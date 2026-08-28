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
                    public partial class OrderEntity : IOrderEntity
{
    public string ORD_ID { get; set; }
    public string ORD_ID_RESERVA { get; set; }
    public string ORD_ID_CONJUNTO { get; set; }
    public string PRO_ID { get; set; }
    public string PRO_ID_CONJUNTO { get; set; }
    public string CLI_ID { get; set; }
    public Decimal? ORD_PRECO_UNITARIO { get; set; }
    public Decimal ORD_QUANTIDADE { get; set; }
    public DateTime ORD_DATA_ENTREGA_DE { get; set; }
    public DateTime ORD_DATA_ENTREGA_ATE { get; set; }
    public int? ORD_TIPO { get; set; }
    public Decimal? ORD_TOLERANCIA_MAIS { get; set; }
    public Decimal? ORD_TOLERANCIA_MENOS { get; set; }
    public string HASH_KEY { get; set; }
    public DateTime? ORD_INICIO_JANELA_EMBARQUE { get; set; }
    public DateTime? ORD_FIM_JANELA_EMBARQUE { get; set; }
    public DateTime? ORD_EMBARQUE_ALVO { get; set; }
    public DateTime? ORD_INICIO_GRUPO_PRODUTIVO { get; set; }
    public DateTime? ORD_FIM_GRUPO_PRODUTIVO { get; set; }
    public Decimal? ORD_PESO_UNITARIO { get; set; }
    public Decimal? ORD_PESO_UNITARIO_BRUTO { get; set; }
    public Decimal? ORD_M2_UNITARIO { get; set; }
    public string ORD_MIT { get; set; }
    public string CAR_TIPO_CARREGAMENTO { get; set; }
    public string ORD_STATUS { get; set; }
    public string ORD_TIPO_FRETE { get; set; }
    public string ORD_ENDERECO_ENTREGA { get; set; }
    public string ORD_BAIRRO_ENTREGA { get; set; }
    public string UF_ID_ENTREGA { get; set; }
    public string ORD_CEP_ENTREGA { get; set; }
    public string MUN_ID_ENTREGA { get; set; }
    public string ORD_REGIAO_ENTREGA { get; set; }
    public Decimal? ORD_LARGURA { get; set; }
    public Decimal? ORD_COMPRIMENTO { get; set; }
    public Decimal? ORD_GRAMATURA { get; set; }
    public string GRP_ID { get; set; }
    public string ORD_ID_INTEGRACAO { get; set; }
    public string ORD_OBSERVACAO_OTIMIZADOR { get; set; }
    public string ORD_COR_FILA { get; set; }
    public string ORD_PED_CLI { get; set; }
    public string ORD_OP_INTEGRACAO { get; set; }
    public string ORD_LOTE_PILOTO { get; set; }
    public int? ORD_PRIORIDADE { get; set; }
    public DateTime? ORD_EMISSAO { get; set; }
    public string REP_ID { get; set; }
    public string ORD_RESINA { get; set; }
    public string ORD_ENDURECEDOR_MIOLO { get; set; }
    public string PRO_ID_INTEGRACAO_ERP { get; set; }
    public string ORD_VINCOS_ONDULADEIRA { get; set; }
    public Decimal? ORD_ERP_CUSTOS_FIXOS { get; set; }
    public Decimal? ORD_ERP_CUSTOS_VARIAVEIS { get; set; }
    public Decimal? ORD_ERP_DESPESAS_VAR_VENDA { get; set; }
    public Decimal? ORD_ERP_IMPOSTOS { get; set; }
    public string ORD_STATUS_PLANEJAMENTO { get; set; }
    public int? ORD_TOLERANCIA_DIMENSAO_CHAPA_DE { get; set; }
    public int? ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE { get; set; }
    public Decimal? ORD_PROMOVE_DE { get; set; }
    public Decimal? ORD_PROMOVE_ATE { get; set; }
    public string ORD_TRAVA_COMPOSICAO { get; set; }
    public string ORD_TRAVA_RESINA { get; set; }
    public string ORD_PROMOVE_RESINA { get; set; }
    public Decimal? ORD_LATITUDE_ENTREGA { get; set; }
    public Decimal? ORD_LONGITUDE_ENTREGA { get; set; }
    public string OCO_ID_CANCELAMENTO { get; set; }
    public string TMP_TIPO_CARGA { get; set; }
    public string PRO_ID_PALETE { get; set; }
    public string PRO_ID_TAMPO { get; set; }
    public int? ORD_PILHAS_POR_PALETE { get; set; }
    public int? ORD_CHAPAS_POR_PILHA { get; set; }
    public DateTime? ORD_DATA_CANCELAMENTO { get; set; }
    public string ORD_STATUS_ESTATISTICA { get; set; }
    public DateTime? ORD_DATA_ESTATISTICA { get; set; }
    public string OCO_ID_MOTIVO_ATRASO { get; set; }
    public int? OTK_VERSSAO { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal OrderEntity(string ord_id, string ord_id_reserva, string ord_id_conjunto, string pro_id, string pro_id_conjunto, string cli_id, Decimal? ord_preco_unitario, Decimal ord_quantidade, DateTime ord_data_entrega_de, DateTime ord_data_entrega_ate, int? ord_tipo, Decimal? ord_tolerancia_mais, Decimal? ord_tolerancia_menos, string hash_key, DateTime? ord_inicio_janela_embarque, DateTime? ord_fim_janela_embarque, DateTime? ord_embarque_alvo, DateTime? ord_inicio_grupo_produtivo, DateTime? ord_fim_grupo_produtivo, Decimal? ord_peso_unitario, Decimal? ord_peso_unitario_bruto, Decimal? ord_m2_unitario, string ord_mit, string car_tipo_carregamento, string ord_status, string ord_tipo_frete, string ord_endereco_entrega, string ord_bairro_entrega, string uf_id_entrega, string ord_cep_entrega, string mun_id_entrega, string ord_regiao_entrega, Decimal? ord_largura, Decimal? ord_comprimento, Decimal? ord_gramatura, string grp_id, string ord_id_integracao, string ord_observacao_otimizador, string ord_cor_fila, string ord_ped_cli, string ord_op_integracao, string ord_lote_piloto, int? ord_prioridade, DateTime? ord_emissao, string rep_id, string ord_resina, string ord_endurecedor_miolo, string pro_id_integracao_erp, string ord_vincos_onduladeira, Decimal? ord_erp_custos_fixos, Decimal? ord_erp_custos_variaveis, Decimal? ord_erp_despesas_var_venda, Decimal? ord_erp_impostos, string ord_status_planejamento, int? ord_tolerancia_dimensao_chapa_de, int? ord_tolerancia_dimensao_chapa_ate, Decimal? ord_promove_de, Decimal? ord_promove_ate, string ord_trava_composicao, string ord_trava_resina, string ord_promove_resina, Decimal? ord_latitude_entrega, Decimal? ord_longitude_entrega, string oco_id_cancelamento, string tmp_tipo_carga, string pro_id_palete, string pro_id_tampo, int? ord_pilhas_por_palete, int? ord_chapas_por_pilha, DateTime? ord_data_cancelamento, string ord_status_estatistica, DateTime? ord_data_estatistica, string oco_id_motivo_atraso, int? otk_verssao ){
 ORD_ID = ord_id; 
 ORD_ID_RESERVA = ord_id_reserva; 
 ORD_ID_CONJUNTO = ord_id_conjunto; 
 PRO_ID = pro_id; 
 PRO_ID_CONJUNTO = pro_id_conjunto; 
 CLI_ID = cli_id; 
 ORD_PRECO_UNITARIO = ord_preco_unitario; 
 ORD_QUANTIDADE = ord_quantidade; 
 ORD_DATA_ENTREGA_DE = (ord_data_entrega_de < (new DateTime(1800, 1, 1))) ? DateTime.Now : ord_data_entrega_de; 
 ORD_DATA_ENTREGA_ATE = (ord_data_entrega_ate < (new DateTime(1800, 1, 1))) ? DateTime.Now : ord_data_entrega_ate; 
 ORD_TIPO = ord_tipo; 
 ORD_TOLERANCIA_MAIS = ord_tolerancia_mais; 
 ORD_TOLERANCIA_MENOS = ord_tolerancia_menos; 
 HASH_KEY = hash_key; 
 ORD_INICIO_JANELA_EMBARQUE = (ord_inicio_janela_embarque < (new DateTime(1800, 1, 1))) ? DateTime.Now : ord_inicio_janela_embarque; 
 ORD_FIM_JANELA_EMBARQUE = (ord_fim_janela_embarque < (new DateTime(1800, 1, 1))) ? DateTime.Now : ord_fim_janela_embarque; 
 ORD_EMBARQUE_ALVO = (ord_embarque_alvo < (new DateTime(1800, 1, 1))) ? DateTime.Now : ord_embarque_alvo; 
 ORD_INICIO_GRUPO_PRODUTIVO = (ord_inicio_grupo_produtivo < (new DateTime(1800, 1, 1))) ? DateTime.Now : ord_inicio_grupo_produtivo; 
 ORD_FIM_GRUPO_PRODUTIVO = (ord_fim_grupo_produtivo < (new DateTime(1800, 1, 1))) ? DateTime.Now : ord_fim_grupo_produtivo; 
 ORD_PESO_UNITARIO = ord_peso_unitario; 
 ORD_PESO_UNITARIO_BRUTO = ord_peso_unitario_bruto; 
 ORD_M2_UNITARIO = ord_m2_unitario; 
 ORD_MIT = ord_mit; 
 CAR_TIPO_CARREGAMENTO = car_tipo_carregamento; 
 ORD_STATUS = ord_status; 
 ORD_TIPO_FRETE = ord_tipo_frete; 
 ORD_ENDERECO_ENTREGA = ord_endereco_entrega; 
 ORD_BAIRRO_ENTREGA = ord_bairro_entrega; 
 UF_ID_ENTREGA = uf_id_entrega; 
 ORD_CEP_ENTREGA = ord_cep_entrega; 
 MUN_ID_ENTREGA = mun_id_entrega; 
 ORD_REGIAO_ENTREGA = ord_regiao_entrega; 
 ORD_LARGURA = ord_largura; 
 ORD_COMPRIMENTO = ord_comprimento; 
 ORD_GRAMATURA = ord_gramatura; 
 GRP_ID = grp_id; 
 ORD_ID_INTEGRACAO = ord_id_integracao; 
 ORD_OBSERVACAO_OTIMIZADOR = ord_observacao_otimizador; 
 ORD_COR_FILA = ord_cor_fila; 
 ORD_PED_CLI = ord_ped_cli; 
 ORD_OP_INTEGRACAO = ord_op_integracao; 
 ORD_LOTE_PILOTO = ord_lote_piloto; 
 ORD_PRIORIDADE = ord_prioridade; 
 ORD_EMISSAO = (ord_emissao < (new DateTime(1800, 1, 1))) ? DateTime.Now : ord_emissao; 
 REP_ID = rep_id; 
 ORD_RESINA = ord_resina; 
 ORD_ENDURECEDOR_MIOLO = ord_endurecedor_miolo; 
 PRO_ID_INTEGRACAO_ERP = pro_id_integracao_erp; 
 ORD_VINCOS_ONDULADEIRA = ord_vincos_onduladeira; 
 ORD_ERP_CUSTOS_FIXOS = ord_erp_custos_fixos; 
 ORD_ERP_CUSTOS_VARIAVEIS = ord_erp_custos_variaveis; 
 ORD_ERP_DESPESAS_VAR_VENDA = ord_erp_despesas_var_venda; 
 ORD_ERP_IMPOSTOS = ord_erp_impostos; 
 ORD_STATUS_PLANEJAMENTO = ord_status_planejamento; 
 ORD_TOLERANCIA_DIMENSAO_CHAPA_DE = ord_tolerancia_dimensao_chapa_de; 
 ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE = ord_tolerancia_dimensao_chapa_ate; 
 ORD_PROMOVE_DE = ord_promove_de; 
 ORD_PROMOVE_ATE = ord_promove_ate; 
 ORD_TRAVA_COMPOSICAO = ord_trava_composicao; 
 ORD_TRAVA_RESINA = ord_trava_resina; 
 ORD_PROMOVE_RESINA = ord_promove_resina; 
 ORD_LATITUDE_ENTREGA = ord_latitude_entrega; 
 ORD_LONGITUDE_ENTREGA = ord_longitude_entrega; 
 OCO_ID_CANCELAMENTO = oco_id_cancelamento; 
 TMP_TIPO_CARGA = tmp_tipo_carga; 
 PRO_ID_PALETE = pro_id_palete; 
 PRO_ID_TAMPO = pro_id_tampo; 
 ORD_PILHAS_POR_PALETE = ord_pilhas_por_palete; 
 ORD_CHAPAS_POR_PILHA = ord_chapas_por_pilha; 
 ORD_DATA_CANCELAMENTO = (ord_data_cancelamento < (new DateTime(1800, 1, 1))) ? DateTime.Now : ord_data_cancelamento; 
 ORD_STATUS_ESTATISTICA = ord_status_estatistica; 
 ORD_DATA_ESTATISTICA = (ord_data_estatistica < (new DateTime(1800, 1, 1))) ? DateTime.Now : ord_data_estatistica; 
 OCO_ID_MOTIVO_ATRASO = oco_id_motivo_atraso; 
 OTK_VERSSAO = otk_verssao; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(ORD_ID))
   this._erroMensagem.Add("ORD ID deve ser informado.");
   if(string.IsNullOrEmpty(ORD_ID_CONJUNTO))
   this._erroMensagem.Add("ORD ID CONJUNTO deve ser informado.");
   if(string.IsNullOrEmpty(PRO_ID))
   this._erroMensagem.Add("PRO ID deve ser informado.");
   if(string.IsNullOrEmpty(PRO_ID_CONJUNTO))
   this._erroMensagem.Add("PRO ID CONJUNTO deve ser informado.");
   if(string.IsNullOrEmpty(CLI_ID))
   this._erroMensagem.Add("CLI ID deve ser informado.");
   if (ORD_QUANTIDADE == null)
   this._erroMensagem.Add("ORD QUANTIDADE deve ser informado.");
   if (ORD_DATA_ENTREGA_DE == null || ORD_DATA_ENTREGA_DE < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("ORD DATA ENTREGA DE deve ser informado.");
   if (ORD_DATA_ENTREGA_ATE == null || ORD_DATA_ENTREGA_ATE < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("ORD DATA ENTREGA ATE deve ser informado.");
   if(string.IsNullOrEmpty(ORD_TIPO_FRETE))
   this._erroMensagem.Add("ORD TIPO FRETE deve ser informado.");
   if(string.IsNullOrEmpty(ORD_REGIAO_ENTREGA))
   this._erroMensagem.Add("ORD REGIAO ENTREGA deve ser informado.");
   if(string.IsNullOrEmpty(ORD_TRAVA_RESINA))
   this._erroMensagem.Add("ORD TRAVA RESINA deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration