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
    public partial record MaquinaDTO
    {
    public string id { get; set; }
    public string descricao { get; set; }
    public string status { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    public int cal_id { get; set; }
    public string maq_control_ip { get; set; }
    public string gma_id { get; set; }
    public DateTime maq_ultima_atualizacao { get; set; }
    public int maq_sirene_semaforo { get; set; }
    public string maq_cor_semaforo { get; set; }
    public string maq_id_maq_pai { get; set; }
    public int maq_tipo_contador { get; set; }
    public string maq_tipo_planejamento { get; set; }
    public int maq_avalia_custo { get; set; }
    public int fpr_id_op_produzindo { get; set; }
    public int maq_congela_fila { get; set; }
    public int maq_tempo_min_parada { get; set; }
    public int maq_qtd_cores { get; set; }
    public string maq_id_integracao { get; set; }
    public string maq_id_integracao_erp { get; set; }
    public Decimal maq_hierarquia_seq_transformacao { get; set; }
    public string equ_id { get; set; }
    public Decimal maq_percentual_inicio_passo_anterior { get; set; }
    public string maq_acompanha_lote_piloto { get; set; }
    public int maq_id_sensor { get; set; }
    public int maq_debouncing_low { get; set; }
    public int maq_debouncing_hight { get; set; }
    public int maq_tipo_sinal { get; set; }
    public int tem_id { get; set; }
    public Decimal maq_comprimento_chapa_de { get; set; }
    public Decimal maq_comprimento_chapa_ate { get; set; }
    public Decimal maq_largura_chapa_de { get; set; }
    public Decimal maq_largura_chapa_ate { get; set; }
    public Decimal maq_comprimento_chapa_de_facao_superior { get; set; }
    public Decimal maq_comprimento_chapa_ate_facao_superior { get; set; }
    public Decimal maq_comprimento_chapa_de_facao_inferior { get; set; }
    public Decimal maq_comprimento_chapa_ate_facao_inferior { get; set; }
    public Decimal maq_comprimento_entre_vinco_de { get; set; }
    public Decimal maq_comprimento_entre_vinco_ate { get; set; }
    public Decimal maq_largura_entre_vinco_de { get; set; }
    public Decimal maq_largura_entre_vinco_ate { get; set; }
    public Decimal maq_altura_entre_vinco_de { get; set; }
    public Decimal maq_altura_entre_vinco_ate { get; set; }
    public Decimal maq_comprimento_mais_largura_entre_vinco_de { get; set; }
    public Decimal maq_comprimento_mais_largura_entre_vinco_ate { get; set; }
    public Decimal maq_aba_de { get; set; }
    public Decimal maq_aba_ate { get; set; }
    public Decimal maq_lap_de { get; set; }
    public Decimal maq_lap_ate { get; set; }
    public string maq_ondas { get; set; }
    public string maq_prolonga_lap { get; set; }
    public Decimal maq_largura_impressao { get; set; }
    public Decimal maq_comprimento_impressao { get; set; }
    public Decimal maq_rolo_dispositivo_de { get; set; }
    public Decimal maq_rolo_dispositivo_ate { get; set; }
    public string maq_familias { get; set; }
    public Decimal maq_refile_minimo { get; set; }
    public Decimal maq_largura_util { get; set; }
    public Decimal maq_total_aco { get; set; }
    public string maq_fechamento { get; set; }
    public Decimal maq_operacao_vincar { get; set; }
    public Decimal maq_operacao_monta_divisao { get; set; }
    public Decimal maq_operacao_serrar { get; set; }
    public string maq_tipo_lap { get; set; }
    public Decimal maq_indice_paradas_por_op { get; set; }
    public int maq_perda_maxima { get; set; }
    public int maq_total_pecas_refilando { get; set; }
    public int maq_total_pecas_nao_refilando { get; set; }
    public int maq_total_vincos { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration