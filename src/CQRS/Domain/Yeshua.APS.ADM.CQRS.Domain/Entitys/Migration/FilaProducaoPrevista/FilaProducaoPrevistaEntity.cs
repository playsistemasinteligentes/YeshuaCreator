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
                    public partial class FilaProducaoPrevistaEntity : IFilaProducaoPrevistaEntity
{
    public int? Id { get; set; }
    public string ORD_ID { get; set; }
    public string ROT_PRO_ID { get; set; }
    public Decimal FPR_QUANTIDADE_PREVISTA { get; set; }
    public string ROT_MAQ_ID { get; set; }
    public DateTime FPR_DATA_INICIO_PREVISTA { get; set; }
    public DateTime FPR_DATA_FIM_PREVISTA { get; set; }
    public DateTime FPR_DATA_FIM_MAXIMA { get; set; }
    public int ROT_SEQ_TRANFORMACAO { get; set; }
    public int FPR_SEQ_REPETICAO { get; set; }
    public string FPR_OBS_PRODUCAO { get; set; }
    public string FPR_STATUS { get; set; }
    public Decimal? FPR_TEMPO_DECORRIDO_SETUP { get; set; }
    public Decimal? FPR_TEMPO_DECORRIDO_SETUPA { get; set; }
    public Decimal? FPR_TEMPO_DECORRIDO_PERFORMANC { get; set; }
    public Decimal? FPR_TEMPO_DECO_PEQUENA_PARADA { get; set; }
    public Decimal? FPR_QTD_PERFORMANCE { get; set; }
    public Decimal? FPR_QTD_SETUP { get; set; }
    public Decimal? FPR_QTD_PRODUZIDA { get; set; }
    public Decimal? FPR_TEMPO_TEORICO_PERFORMANCE { get; set; }
    public Decimal? FPR_TEMPO_RESTANTE_PERFORMANC { get; set; }
    public Decimal? FPR_VELOCIDADE_P_ATINGIR_META { get; set; }
    public Decimal? FPR_QTD_RESTANTE { get; set; }
    public Decimal? FPR_VELO_ATU_PC_SEGUNDO { get; set; }
    public Decimal? FPR_PERFORMANCE_PROJETADA { get; set; }
    public Decimal? FPR_TEMPO_RESTANTE_TOTAL { get; set; }
    public DateTime? FPR_FIM_PREVISTO_ATUAL { get; set; }
    public int? FPR_PRODUZINDO { get; set; }
    public Decimal? FPR_ORDEM_NA_FILA { get; set; }
    public string FPR_ID_INTEGRACAO { get; set; }
    public string FPR_TRUNCADO { get; set; }
    public DateTime? FPR_DATA_TRUNC_INI { get; set; }
    public DateTime? FPR_DATA_TRUNC_FIM { get; set; }
    public int FPR_ID { get; set; }
    public string FPR_COR_FILA { get; set; }
    public string MAQ_ID_MANUAL { get; set; }
    public string MAQ_ID_RESTRINGIDA { get; set; }
    public DateTime FPR_PREVISAO_MATERIA_PRIMA { get; set; }
    public DateTime? FPR_DATA_NECESSIDADE_INICIO_PRODUCAO { get; set; }
    public DateTime? FPR_DATA_NECESSIDADE_FIM_PRODUCAO { get; set; }
    public Decimal? FPR_GRUPO_PRODUTIVO { get; set; }
    public DateTime? FPR_INICIO_GRUPO_PRODUTIVO { get; set; }
    public DateTime? FPR_FIM_GRUPO_PRODUTIVO { get; set; }
    public string FPR_COR_BICO1 { get; set; }
    public string FPR_COR_BICO2 { get; set; }
    public string FPR_COR_BICO3 { get; set; }
    public string FPR_COR_BICO4 { get; set; }
    public string FPR_COR_BICO5 { get; set; }
    public Decimal? FPR_META_SETUP { get; set; }
    public string FPR_ORD_ID_REPROGRAMADO { get; set; }
    public int? FPR_PRIORIDADE { get; set; }
    public int? FPR_SEQ_INCLUSAO_FILA { get; set; }
    public int? FPR_HIERARQUIA_SEQ_TRANSFORMACAO { get; set; }
    public int? FPR_ID_ORIGEM { get; set; }
    public DateTime? FPR_DATA_ENTREGA { get; set; }
    public string EQU_ID { get; set; }
    public Decimal? FPR_GRUPO_PRODUTIVO_MANUAL { get; set; }
    public DateTime? FPR_EMISSAO { get; set; }
    public string FPR_MOTIVO_PULA_FILA { get; set; }
    public string OCO_ID { get; set; }
    public string FPR_PESO_UNITARIO { get; set; }
    public string FPR_M2_UNITARIO { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal FilaProducaoPrevistaEntity(int? id, string ord_id, string rot_pro_id, Decimal fpr_quantidade_prevista, string rot_maq_id, DateTime fpr_data_inicio_prevista, DateTime fpr_data_fim_prevista, DateTime fpr_data_fim_maxima, int rot_seq_tranformacao, int fpr_seq_repeticao, string fpr_obs_producao, string fpr_status, Decimal? fpr_tempo_decorrido_setup, Decimal? fpr_tempo_decorrido_setupa, Decimal? fpr_tempo_decorrido_performanc, Decimal? fpr_tempo_deco_pequena_parada, Decimal? fpr_qtd_performance, Decimal? fpr_qtd_setup, Decimal? fpr_qtd_produzida, Decimal? fpr_tempo_teorico_performance, Decimal? fpr_tempo_restante_performanc, Decimal? fpr_velocidade_p_atingir_meta, Decimal? fpr_qtd_restante, Decimal? fpr_velo_atu_pc_segundo, Decimal? fpr_performance_projetada, Decimal? fpr_tempo_restante_total, DateTime? fpr_fim_previsto_atual, int? fpr_produzindo, Decimal? fpr_ordem_na_fila, string fpr_id_integracao, string fpr_truncado, DateTime? fpr_data_trunc_ini, DateTime? fpr_data_trunc_fim, int fpr_id, string fpr_cor_fila, string maq_id_manual, string maq_id_restringida, DateTime fpr_previsao_materia_prima, DateTime? fpr_data_necessidade_inicio_producao, DateTime? fpr_data_necessidade_fim_producao, Decimal? fpr_grupo_produtivo, DateTime? fpr_inicio_grupo_produtivo, DateTime? fpr_fim_grupo_produtivo, string fpr_cor_bico1, string fpr_cor_bico2, string fpr_cor_bico3, string fpr_cor_bico4, string fpr_cor_bico5, Decimal? fpr_meta_setup, string fpr_ord_id_reprogramado, int? fpr_prioridade, int? fpr_seq_inclusao_fila, int? fpr_hierarquia_seq_transformacao, int? fpr_id_origem, DateTime? fpr_data_entrega, string equ_id, Decimal? fpr_grupo_produtivo_manual, DateTime? fpr_emissao, string fpr_motivo_pula_fila, string oco_id, string fpr_peso_unitario, string fpr_m2_unitario ){
 Id = id; 
 ORD_ID = ord_id; 
 ROT_PRO_ID = rot_pro_id; 
 FPR_QUANTIDADE_PREVISTA = fpr_quantidade_prevista; 
 ROT_MAQ_ID = rot_maq_id; 
 FPR_DATA_INICIO_PREVISTA = (fpr_data_inicio_prevista < (new DateTime(1800, 1, 1))) ? DateTime.Now : fpr_data_inicio_prevista; 
 FPR_DATA_FIM_PREVISTA = (fpr_data_fim_prevista < (new DateTime(1800, 1, 1))) ? DateTime.Now : fpr_data_fim_prevista; 
 FPR_DATA_FIM_MAXIMA = (fpr_data_fim_maxima < (new DateTime(1800, 1, 1))) ? DateTime.Now : fpr_data_fim_maxima; 
 ROT_SEQ_TRANFORMACAO = rot_seq_tranformacao; 
 FPR_SEQ_REPETICAO = fpr_seq_repeticao; 
 FPR_OBS_PRODUCAO = fpr_obs_producao; 
 FPR_STATUS = fpr_status; 
 FPR_TEMPO_DECORRIDO_SETUP = fpr_tempo_decorrido_setup; 
 FPR_TEMPO_DECORRIDO_SETUPA = fpr_tempo_decorrido_setupa; 
 FPR_TEMPO_DECORRIDO_PERFORMANC = fpr_tempo_decorrido_performanc; 
 FPR_TEMPO_DECO_PEQUENA_PARADA = fpr_tempo_deco_pequena_parada; 
 FPR_QTD_PERFORMANCE = fpr_qtd_performance; 
 FPR_QTD_SETUP = fpr_qtd_setup; 
 FPR_QTD_PRODUZIDA = fpr_qtd_produzida; 
 FPR_TEMPO_TEORICO_PERFORMANCE = fpr_tempo_teorico_performance; 
 FPR_TEMPO_RESTANTE_PERFORMANC = fpr_tempo_restante_performanc; 
 FPR_VELOCIDADE_P_ATINGIR_META = fpr_velocidade_p_atingir_meta; 
 FPR_QTD_RESTANTE = fpr_qtd_restante; 
 FPR_VELO_ATU_PC_SEGUNDO = fpr_velo_atu_pc_segundo; 
 FPR_PERFORMANCE_PROJETADA = fpr_performance_projetada; 
 FPR_TEMPO_RESTANTE_TOTAL = fpr_tempo_restante_total; 
 FPR_FIM_PREVISTO_ATUAL = (fpr_fim_previsto_atual < (new DateTime(1800, 1, 1))) ? DateTime.Now : fpr_fim_previsto_atual; 
 FPR_PRODUZINDO = fpr_produzindo; 
 FPR_ORDEM_NA_FILA = fpr_ordem_na_fila; 
 FPR_ID_INTEGRACAO = fpr_id_integracao; 
 FPR_TRUNCADO = fpr_truncado; 
 FPR_DATA_TRUNC_INI = (fpr_data_trunc_ini < (new DateTime(1800, 1, 1))) ? DateTime.Now : fpr_data_trunc_ini; 
 FPR_DATA_TRUNC_FIM = (fpr_data_trunc_fim < (new DateTime(1800, 1, 1))) ? DateTime.Now : fpr_data_trunc_fim; 
 FPR_ID = fpr_id; 
 FPR_COR_FILA = fpr_cor_fila; 
 MAQ_ID_MANUAL = maq_id_manual; 
 MAQ_ID_RESTRINGIDA = maq_id_restringida; 
 FPR_PREVISAO_MATERIA_PRIMA = (fpr_previsao_materia_prima < (new DateTime(1800, 1, 1))) ? DateTime.Now : fpr_previsao_materia_prima; 
 FPR_DATA_NECESSIDADE_INICIO_PRODUCAO = (fpr_data_necessidade_inicio_producao < (new DateTime(1800, 1, 1))) ? DateTime.Now : fpr_data_necessidade_inicio_producao; 
 FPR_DATA_NECESSIDADE_FIM_PRODUCAO = (fpr_data_necessidade_fim_producao < (new DateTime(1800, 1, 1))) ? DateTime.Now : fpr_data_necessidade_fim_producao; 
 FPR_GRUPO_PRODUTIVO = fpr_grupo_produtivo; 
 FPR_INICIO_GRUPO_PRODUTIVO = (fpr_inicio_grupo_produtivo < (new DateTime(1800, 1, 1))) ? DateTime.Now : fpr_inicio_grupo_produtivo; 
 FPR_FIM_GRUPO_PRODUTIVO = (fpr_fim_grupo_produtivo < (new DateTime(1800, 1, 1))) ? DateTime.Now : fpr_fim_grupo_produtivo; 
 FPR_COR_BICO1 = fpr_cor_bico1; 
 FPR_COR_BICO2 = fpr_cor_bico2; 
 FPR_COR_BICO3 = fpr_cor_bico3; 
 FPR_COR_BICO4 = fpr_cor_bico4; 
 FPR_COR_BICO5 = fpr_cor_bico5; 
 FPR_META_SETUP = fpr_meta_setup; 
 FPR_ORD_ID_REPROGRAMADO = fpr_ord_id_reprogramado; 
 FPR_PRIORIDADE = fpr_prioridade; 
 FPR_SEQ_INCLUSAO_FILA = fpr_seq_inclusao_fila; 
 FPR_HIERARQUIA_SEQ_TRANSFORMACAO = fpr_hierarquia_seq_transformacao; 
 FPR_ID_ORIGEM = fpr_id_origem; 
 FPR_DATA_ENTREGA = (fpr_data_entrega < (new DateTime(1800, 1, 1))) ? DateTime.Now : fpr_data_entrega; 
 EQU_ID = equ_id; 
 FPR_GRUPO_PRODUTIVO_MANUAL = fpr_grupo_produtivo_manual; 
 FPR_EMISSAO = (fpr_emissao < (new DateTime(1800, 1, 1))) ? DateTime.Now : fpr_emissao; 
 FPR_MOTIVO_PULA_FILA = fpr_motivo_pula_fila; 
 OCO_ID = oco_id; 
 FPR_PESO_UNITARIO = fpr_peso_unitario; 
 FPR_M2_UNITARIO = fpr_m2_unitario; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(ORD_ID))
   this._erroMensagem.Add("ORD ID deve ser informado.");
   if(string.IsNullOrEmpty(ROT_PRO_ID))
   this._erroMensagem.Add("ROT PRO ID deve ser informado.");
   if(string.IsNullOrEmpty(ROT_MAQ_ID))
   this._erroMensagem.Add("ROT MAQ ID deve ser informado.");
   if(FPR_DATA_INICIO_PREVISTA == null || FPR_DATA_INICIO_PREVISTA < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("FPR DATA INICIO PREVISTA deve ser informado.");
   if(FPR_DATA_FIM_PREVISTA == null || FPR_DATA_FIM_PREVISTA < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("FPR DATA FIM PREVISTA deve ser informado.");
   if(FPR_DATA_FIM_MAXIMA == null || FPR_DATA_FIM_MAXIMA < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("FPR DATA FIM MAXIMA deve ser informado.");
   if(FPR_PREVISAO_MATERIA_PRIMA == null || FPR_PREVISAO_MATERIA_PRIMA < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("FPR PREVISAO MATERIA PRIMA deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration