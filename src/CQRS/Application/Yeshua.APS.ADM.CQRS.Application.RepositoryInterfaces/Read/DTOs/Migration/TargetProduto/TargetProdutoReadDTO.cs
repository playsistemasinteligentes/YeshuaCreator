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
    public partial record TargetProdutoDTO
    {
    public int tar_id { get; set; }
    public int mov_id { get; set; }
    public string ord_id { get; set; }
    public string pro_id { get; set; }
    public string maq_id { get; set; }
    public string uni_id { get; set; }
    public string turm_id { get; set; }
    public string turn_id { get; set; }
    public int use_id { get; set; }
    public string tar_dia_turma { get; set; }
    public Decimal tar_meta_performance { get; set; }
    public Decimal tar_realizado_performance { get; set; }
    public Decimal tar_percentual_realizado_performance { get; set; }
    public Decimal tar_proxima_meta_performance { get; set; }
    public Decimal tar_meta_tempo_setup { get; set; }
    public Decimal tar_realizado_tempo_setup { get; set; }
    public Decimal tar_proxima_meta_tempo_setup { get; set; }
    public Decimal tar_meta_tempo_setup_ajuste { get; set; }
    public Decimal tar_realizado_tempo_setup_ajuste { get; set; }
    public Decimal tar_proxima_meta_tempo_setup_ajuste { get; set; }
    public string oco_id_performance { get; set; }
    public string tar_obs_performance { get; set; }
    public string oco_id_setup { get; set; }
    public string tar_obs_setup { get; set; }
    public string oco_id_setupa { get; set; }
    public string tar_obs_setupa { get; set; }
    public string tar_tipo_feedback_performance { get; set; }
    public string tar_tipo_feedback_setup { get; set; }
    public string tar_tipo_feedback_setup_ajuste { get; set; }
    public Decimal tar_qtd_setup_ajuste { get; set; }
    public Decimal tar_qtd { get; set; }
    public int tar_parametro_time_work_stop_machine { get; set; }
    public int tar_parametro_tempo_quebra_de_lote { get; set; }
    public int rot_seq_tranformacao { get; set; }
    public int fpr_seq_repeticao { get; set; }
    public Decimal tar_performance_max_verde { get; set; }
    public Decimal tar_performance_min_verde { get; set; }
    public Decimal tar_setup_max_verde { get; set; }
    public Decimal tar_setup_min_verde { get; set; }
    public Decimal tar_setupa_max_verde { get; set; }
    public Decimal tar_setupa_min_verde { get; set; }
    public Decimal tar_performance_min_amarelo { get; set; }
    public Decimal tar_setup_max_amarelo { get; set; }
    public Decimal tar_setupa_max_amarelo { get; set; }
    public string tar_obs_op_parcial { get; set; }
    public string tar_oco_id_op_parcial { get; set; }
    public string tar_cor_performance { get; set; }
    public string tar_cor_setup_geral { get; set; }
    public string tar_cor_setup { get; set; }
    public string tar_cor_setupa { get; set; }
    public DateTime tar_dia_turma_d { get; set; }
    public Decimal fee_qtd_pecas_por_pulso { get; set; }
    public Decimal tar_qtd_perdas { get; set; }
    public DateTime tar_data_inicial { get; set; }
    public DateTime tar_data_final { get; set; }
    public string tar_aprovado { get; set; }
    public int tar_tempo_produzindo { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration