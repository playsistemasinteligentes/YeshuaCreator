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
                    public partial class TargetProdutoEntity : ITargetProdutoEntity
{
    public int TAR_ID { get; set; }
    public int? MOV_ID { get; set; }
    public string ORD_ID { get; set; }
    public string PRO_ID { get; set; }
    public string MAQ_ID { get; set; }
    public string UNI_ID { get; set; }
    public string TURM_ID { get; set; }
    public string TURN_ID { get; set; }
    public int? USE_ID { get; set; }
    public string TAR_DIA_TURMA { get; set; }
    public Decimal TAR_META_PERFORMANCE { get; set; }
    public Decimal? TAR_REALIZADO_PERFORMANCE { get; set; }
    public Decimal? TAR_PERCENTUAL_REALIZADO_PERFORMANCE { get; set; }
    public Decimal? TAR_PROXIMA_META_PERFORMANCE { get; set; }
    public Decimal TAR_META_TEMPO_SETUP { get; set; }
    public Decimal? TAR_REALIZADO_TEMPO_SETUP { get; set; }
    public Decimal? TAR_PROXIMA_META_TEMPO_SETUP { get; set; }
    public Decimal TAR_META_TEMPO_SETUP_AJUSTE { get; set; }
    public Decimal? TAR_REALIZADO_TEMPO_SETUP_AJUSTE { get; set; }
    public Decimal? TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE { get; set; }
    public string OCO_ID_PERFORMANCE { get; set; }
    public string TAR_OBS_PERFORMANCE { get; set; }
    public string OCO_ID_SETUP { get; set; }
    public string TAR_OBS_SETUP { get; set; }
    public string OCO_ID_SETUPA { get; set; }
    public string TAR_OBS_SETUPA { get; set; }
    public string TAR_TIPO_FEEDBACK_PERFORMANCE { get; set; }
    public string TAR_TIPO_FEEDBACK_SETUP { get; set; }
    public string TAR_TIPO_FEEDBACK_SETUP_AJUSTE { get; set; }
    public Decimal? TAR_QTD_SETUP_AJUSTE { get; set; }
    public Decimal? TAR_QTD { get; set; }
    public int? TAR_PARAMETRO_TIME_WORK_STOP_MACHINE { get; set; }
    public int? TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE { get; set; }
    public int? ROT_SEQ_TRANFORMACAO { get; set; }
    public int? FPR_SEQ_REPETICAO { get; set; }
    public Decimal? TAR_PERFORMANCE_MAX_VERDE { get; set; }
    public Decimal? TAR_PERFORMANCE_MIN_VERDE { get; set; }
    public Decimal? TAR_SETUP_MAX_VERDE { get; set; }
    public Decimal? TAR_SETUP_MIN_VERDE { get; set; }
    public Decimal? TAR_SETUPA_MAX_VERDE { get; set; }
    public Decimal? TAR_SETUPA_MIN_VERDE { get; set; }
    public Decimal? TAR_PERFORMANCE_MIN_AMARELO { get; set; }
    public Decimal? TAR_SETUP_MAX_AMARELO { get; set; }
    public Decimal? TAR_SETUPA_MAX_AMARELO { get; set; }
    public string TAR_OBS_OP_PARCIAL { get; set; }
    public string TAR_OCO_ID_OP_PARCIAL { get; set; }
    public string TAR_COR_PERFORMANCE { get; set; }
    public string TAR_COR_SETUP_GERAL { get; set; }
    public string TAR_COR_SETUP { get; set; }
    public string TAR_COR_SETUPA { get; set; }
    public DateTime? TAR_DIA_TURMA_D { get; set; }
    public Decimal? FEE_QTD_PECAS_POR_PULSO { get; set; }
    public Decimal? TAR_QTD_PERDAS { get; set; }
    public DateTime? TAR_DATA_INICIAL { get; set; }
    public DateTime? TAR_DATA_FINAL { get; set; }
    public string TAR_APROVADO { get; set; }
    public int? TAR_TEMPO_PRODUZINDO { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal TargetProdutoEntity(int tar_id, int? mov_id, string ord_id, string pro_id, string maq_id, string uni_id, string turm_id, string turn_id, int? use_id, string tar_dia_turma, Decimal tar_meta_performance, Decimal? tar_realizado_performance, Decimal? tar_percentual_realizado_performance, Decimal? tar_proxima_meta_performance, Decimal tar_meta_tempo_setup, Decimal? tar_realizado_tempo_setup, Decimal? tar_proxima_meta_tempo_setup, Decimal tar_meta_tempo_setup_ajuste, Decimal? tar_realizado_tempo_setup_ajuste, Decimal? tar_proxima_meta_tempo_setup_ajuste, string oco_id_performance, string tar_obs_performance, string oco_id_setup, string tar_obs_setup, string oco_id_setupa, string tar_obs_setupa, string tar_tipo_feedback_performance, string tar_tipo_feedback_setup, string tar_tipo_feedback_setup_ajuste, Decimal? tar_qtd_setup_ajuste, Decimal? tar_qtd, int? tar_parametro_time_work_stop_machine, int? tar_parametro_tempo_quebra_de_lote, int? rot_seq_tranformacao, int? fpr_seq_repeticao, Decimal? tar_performance_max_verde, Decimal? tar_performance_min_verde, Decimal? tar_setup_max_verde, Decimal? tar_setup_min_verde, Decimal? tar_setupa_max_verde, Decimal? tar_setupa_min_verde, Decimal? tar_performance_min_amarelo, Decimal? tar_setup_max_amarelo, Decimal? tar_setupa_max_amarelo, string tar_obs_op_parcial, string tar_oco_id_op_parcial, string tar_cor_performance, string tar_cor_setup_geral, string tar_cor_setup, string tar_cor_setupa, DateTime? tar_dia_turma_d, Decimal? fee_qtd_pecas_por_pulso, Decimal? tar_qtd_perdas, DateTime? tar_data_inicial, DateTime? tar_data_final, string tar_aprovado, int? tar_tempo_produzindo ){
 TAR_ID = tar_id; 
 MOV_ID = mov_id; 
 ORD_ID = ord_id; 
 PRO_ID = pro_id; 
 MAQ_ID = maq_id; 
 UNI_ID = uni_id; 
 TURM_ID = turm_id; 
 TURN_ID = turn_id; 
 USE_ID = use_id; 
 TAR_DIA_TURMA = tar_dia_turma; 
 TAR_META_PERFORMANCE = tar_meta_performance; 
 TAR_REALIZADO_PERFORMANCE = tar_realizado_performance; 
 TAR_PERCENTUAL_REALIZADO_PERFORMANCE = tar_percentual_realizado_performance; 
 TAR_PROXIMA_META_PERFORMANCE = tar_proxima_meta_performance; 
 TAR_META_TEMPO_SETUP = tar_meta_tempo_setup; 
 TAR_REALIZADO_TEMPO_SETUP = tar_realizado_tempo_setup; 
 TAR_PROXIMA_META_TEMPO_SETUP = tar_proxima_meta_tempo_setup; 
 TAR_META_TEMPO_SETUP_AJUSTE = tar_meta_tempo_setup_ajuste; 
 TAR_REALIZADO_TEMPO_SETUP_AJUSTE = tar_realizado_tempo_setup_ajuste; 
 TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE = tar_proxima_meta_tempo_setup_ajuste; 
 OCO_ID_PERFORMANCE = oco_id_performance; 
 TAR_OBS_PERFORMANCE = tar_obs_performance; 
 OCO_ID_SETUP = oco_id_setup; 
 TAR_OBS_SETUP = tar_obs_setup; 
 OCO_ID_SETUPA = oco_id_setupa; 
 TAR_OBS_SETUPA = tar_obs_setupa; 
 TAR_TIPO_FEEDBACK_PERFORMANCE = tar_tipo_feedback_performance; 
 TAR_TIPO_FEEDBACK_SETUP = tar_tipo_feedback_setup; 
 TAR_TIPO_FEEDBACK_SETUP_AJUSTE = tar_tipo_feedback_setup_ajuste; 
 TAR_QTD_SETUP_AJUSTE = tar_qtd_setup_ajuste; 
 TAR_QTD = tar_qtd; 
 TAR_PARAMETRO_TIME_WORK_STOP_MACHINE = tar_parametro_time_work_stop_machine; 
 TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE = tar_parametro_tempo_quebra_de_lote; 
 ROT_SEQ_TRANFORMACAO = rot_seq_tranformacao; 
 FPR_SEQ_REPETICAO = fpr_seq_repeticao; 
 TAR_PERFORMANCE_MAX_VERDE = tar_performance_max_verde; 
 TAR_PERFORMANCE_MIN_VERDE = tar_performance_min_verde; 
 TAR_SETUP_MAX_VERDE = tar_setup_max_verde; 
 TAR_SETUP_MIN_VERDE = tar_setup_min_verde; 
 TAR_SETUPA_MAX_VERDE = tar_setupa_max_verde; 
 TAR_SETUPA_MIN_VERDE = tar_setupa_min_verde; 
 TAR_PERFORMANCE_MIN_AMARELO = tar_performance_min_amarelo; 
 TAR_SETUP_MAX_AMARELO = tar_setup_max_amarelo; 
 TAR_SETUPA_MAX_AMARELO = tar_setupa_max_amarelo; 
 TAR_OBS_OP_PARCIAL = tar_obs_op_parcial; 
 TAR_OCO_ID_OP_PARCIAL = tar_oco_id_op_parcial; 
 TAR_COR_PERFORMANCE = tar_cor_performance; 
 TAR_COR_SETUP_GERAL = tar_cor_setup_geral; 
 TAR_COR_SETUP = tar_cor_setup; 
 TAR_COR_SETUPA = tar_cor_setupa; 
 TAR_DIA_TURMA_D = (tar_dia_turma_d < (new DateTime(1800, 1, 1))) ? DateTime.Now : tar_dia_turma_d; 
 FEE_QTD_PECAS_POR_PULSO = fee_qtd_pecas_por_pulso; 
 TAR_QTD_PERDAS = tar_qtd_perdas; 
 TAR_DATA_INICIAL = (tar_data_inicial < (new DateTime(1800, 1, 1))) ? DateTime.Now : tar_data_inicial; 
 TAR_DATA_FINAL = (tar_data_final < (new DateTime(1800, 1, 1))) ? DateTime.Now : tar_data_final; 
 TAR_APROVADO = tar_aprovado; 
 TAR_TEMPO_PRODUZINDO = tar_tempo_produzindo; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(PRO_ID))
   this._erroMensagem.Add("PRO ID deve ser informado.");
   if(string.IsNullOrEmpty(MAQ_ID))
   this._erroMensagem.Add("MAQ ID deve ser informado.");
   if(string.IsNullOrEmpty(TAR_DIA_TURMA))
   this._erroMensagem.Add("TAR DIA TURMA deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration