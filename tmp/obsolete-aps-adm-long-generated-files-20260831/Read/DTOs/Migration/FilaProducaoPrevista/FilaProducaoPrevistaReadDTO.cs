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
    public partial record FilaProducaoPrevistaDTO
    {
    public int id { get; set; }
    public string ord_id { get; set; }
    public string rot_pro_id { get; set; }
    public Decimal fpr_quantidade_prevista { get; set; }
    public string rot_maq_id { get; set; }
    public DateTime fpr_data_inicio_prevista { get; set; }
    public DateTime fpr_data_fim_prevista { get; set; }
    public DateTime fpr_data_fim_maxima { get; set; }
    public int rot_seq_tranformacao { get; set; }
    public int fpr_seq_repeticao { get; set; }
    public string fpr_obs_producao { get; set; }
    public string fpr_status { get; set; }
    public Decimal fpr_tempo_decorrido_setup { get; set; }
    public Decimal fpr_tempo_decorrido_setupa { get; set; }
    public Decimal fpr_tempo_decorrido_performanc { get; set; }
    public Decimal fpr_tempo_deco_pequena_parada { get; set; }
    public Decimal fpr_qtd_performance { get; set; }
    public Decimal fpr_qtd_setup { get; set; }
    public Decimal fpr_qtd_produzida { get; set; }
    public Decimal fpr_tempo_teorico_performance { get; set; }
    public Decimal fpr_tempo_restante_performanc { get; set; }
    public Decimal fpr_velocidade_p_atingir_meta { get; set; }
    public Decimal fpr_qtd_restante { get; set; }
    public Decimal fpr_velo_atu_pc_segundo { get; set; }
    public Decimal fpr_performance_projetada { get; set; }
    public Decimal fpr_tempo_restante_total { get; set; }
    public DateTime fpr_fim_previsto_atual { get; set; }
    public int fpr_produzindo { get; set; }
    public Decimal fpr_ordem_na_fila { get; set; }
    public string fpr_id_integracao { get; set; }
    public string fpr_truncado { get; set; }
    public DateTime fpr_data_trunc_ini { get; set; }
    public DateTime fpr_data_trunc_fim { get; set; }
    public int fpr_id { get; set; }
    public string fpr_cor_fila { get; set; }
    public string maq_id_manual { get; set; }
    public string maq_id_restringida { get; set; }
    public DateTime fpr_previsao_materia_prima { get; set; }
    public DateTime fpr_data_necessidade_inicio_producao { get; set; }
    public DateTime fpr_data_necessidade_fim_producao { get; set; }
    public Decimal fpr_grupo_produtivo { get; set; }
    public DateTime fpr_inicio_grupo_produtivo { get; set; }
    public DateTime fpr_fim_grupo_produtivo { get; set; }
    public string fpr_cor_bico1 { get; set; }
    public string fpr_cor_bico2 { get; set; }
    public string fpr_cor_bico3 { get; set; }
    public string fpr_cor_bico4 { get; set; }
    public string fpr_cor_bico5 { get; set; }
    public Decimal fpr_meta_setup { get; set; }
    public string fpr_ord_id_reprogramado { get; set; }
    public int fpr_prioridade { get; set; }
    public int fpr_seq_inclusao_fila { get; set; }
    public int fpr_hierarquia_seq_transformacao { get; set; }
    public int fpr_id_origem { get; set; }
    public DateTime fpr_data_entrega { get; set; }
    public string equ_id { get; set; }
    public Decimal fpr_grupo_produtivo_manual { get; set; }
    public DateTime fpr_emissao { get; set; }
    public string fpr_motivo_pula_fila { get; set; }
    public string oco_id { get; set; }
    public string fpr_peso_unitario { get; set; }
    public string fpr_m2_unitario { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration