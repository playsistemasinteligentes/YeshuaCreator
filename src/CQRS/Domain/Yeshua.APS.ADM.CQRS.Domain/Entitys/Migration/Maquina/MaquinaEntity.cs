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
                    public partial class MaquinaEntity : IMaquinaEntity
{
    public string Id { get; set; }
    public string Descricao { get; set; }
    public string Status { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    public int? CAL_ID { get; set; }
    public string MAQ_CONTROL_IP { get; set; }
    public string GMA_ID { get; set; }
    public DateTime? MAQ_ULTIMA_ATUALIZACAO { get; set; }
    public int? MAQ_SIRENE_SEMAFORO { get; set; }
    public string MAQ_COR_SEMAFORO { get; set; }
    public string MAQ_ID_MAQ_PAI { get; set; }
    public int? MAQ_TIPO_CONTADOR { get; set; }
    public string MAQ_TIPO_PLANEJAMENTO { get; set; }
    public int? MAQ_AVALIA_CUSTO { get; set; }
    public int? FPR_ID_OP_PRODUZINDO { get; set; }
    public int? MAQ_CONGELA_FILA { get; set; }
    public int? MAQ_TEMPO_MIN_PARADA { get; set; }
    public int? MAQ_QTD_CORES { get; set; }
    public string MAQ_ID_INTEGRACAO { get; set; }
    public string MAQ_ID_INTEGRACAO_ERP { get; set; }
    public Decimal? MAQ_HIERARQUIA_SEQ_TRANSFORMACAO { get; set; }
    public string EQU_ID { get; set; }
    public Decimal? MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR { get; set; }
    public string MAQ_ACOMPANHA_LOTE_PILOTO { get; set; }
    public int? MAQ_ID_SENSOR { get; set; }
    public int? MAQ_DEBOUNCING_LOW { get; set; }
    public int? MAQ_DEBOUNCING_HIGHT { get; set; }
    public int? MAQ_TIPO_SINAL { get; set; }
    public int? TEM_ID { get; set; }
    public Decimal? MAQ_COMPRIMENTO_CHAPA_DE { get; set; }
    public Decimal? MAQ_COMPRIMENTO_CHAPA_ATE { get; set; }
    public Decimal? MAQ_LARGURA_CHAPA_DE { get; set; }
    public Decimal? MAQ_LARGURA_CHAPA_ATE { get; set; }
    public Decimal? MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR { get; set; }
    public Decimal? MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR { get; set; }
    public Decimal? MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR { get; set; }
    public Decimal? MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR { get; set; }
    public Decimal? MAQ_COMPRIMENTO_ENTRE_VINCO_DE { get; set; }
    public Decimal? MAQ_COMPRIMENTO_ENTRE_VINCO_ATE { get; set; }
    public Decimal? MAQ_LARGURA_ENTRE_VINCO_DE { get; set; }
    public Decimal? MAQ_LARGURA_ENTRE_VINCO_ATE { get; set; }
    public Decimal? MAQ_ALTURA_ENTRE_VINCO_DE { get; set; }
    public Decimal? MAQ_ALTURA_ENTRE_VINCO_ATE { get; set; }
    public Decimal? MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE { get; set; }
    public Decimal? MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE { get; set; }
    public Decimal? MAQ_ABA_DE { get; set; }
    public Decimal? MAQ_ABA_ATE { get; set; }
    public Decimal? MAQ_LAP_DE { get; set; }
    public Decimal? MAQ_LAP_ATE { get; set; }
    public string MAQ_ONDAS { get; set; }
    public string MAQ_PROLONGA_LAP { get; set; }
    public Decimal? MAQ_LARGURA_IMPRESSAO { get; set; }
    public Decimal? MAQ_COMPRIMENTO_IMPRESSAO { get; set; }
    public Decimal? MAQ_ROLO_DISPOSITIVO_DE { get; set; }
    public Decimal? MAQ_ROLO_DISPOSITIVO_ATE { get; set; }
    public string MAQ_FAMILIAS { get; set; }
    public Decimal? MAQ_REFILE_MINIMO { get; set; }
    public Decimal? MAQ_LARGURA_UTIL { get; set; }
    public Decimal? MAQ_TOTAL_ACO { get; set; }
    public string MAQ_FECHAMENTO { get; set; }
    public Decimal? MAQ_OPERACAO_VINCAR { get; set; }
    public Decimal? MAQ_OPERACAO_MONTA_DIVISAO { get; set; }
    public Decimal? MAQ_OPERACAO_SERRAR { get; set; }
    public string MAQ_TIPO_LAP { get; set; }
    public Decimal? MAQ_INDICE_PARADAS_POR_OP { get; set; }
    public int? MAQ_PERDA_MAXIMA { get; set; }
    public int? MAQ_TOTAL_PECAS_REFILANDO { get; set; }
    public int? MAQ_TOTAL_PECAS_NAO_REFILANDO { get; set; }
    public int? MAQ_TOTAL_VINCOS { get; set; }
    private List<string> _erroMensagem = null;
 internal MaquinaEntity(string id, string descricao, string status, int? cal_id, string maq_control_ip, string gma_id, DateTime? maq_ultima_atualizacao, int? maq_sirene_semaforo, string maq_cor_semaforo, string maq_id_maq_pai, int? maq_tipo_contador, string maq_tipo_planejamento, int? maq_avalia_custo, int? fpr_id_op_produzindo, int? maq_congela_fila, int? maq_tempo_min_parada, int? maq_qtd_cores, string maq_id_integracao, string maq_id_integracao_erp, Decimal? maq_hierarquia_seq_transformacao, string equ_id, Decimal? maq_percentual_inicio_passo_anterior, string maq_acompanha_lote_piloto, int? maq_id_sensor, int? maq_debouncing_low, int? maq_debouncing_hight, int? maq_tipo_sinal, int? tem_id, Decimal? maq_comprimento_chapa_de, Decimal? maq_comprimento_chapa_ate, Decimal? maq_largura_chapa_de, Decimal? maq_largura_chapa_ate, Decimal? maq_comprimento_chapa_de_facao_superior, Decimal? maq_comprimento_chapa_ate_facao_superior, Decimal? maq_comprimento_chapa_de_facao_inferior, Decimal? maq_comprimento_chapa_ate_facao_inferior, Decimal? maq_comprimento_entre_vinco_de, Decimal? maq_comprimento_entre_vinco_ate, Decimal? maq_largura_entre_vinco_de, Decimal? maq_largura_entre_vinco_ate, Decimal? maq_altura_entre_vinco_de, Decimal? maq_altura_entre_vinco_ate, Decimal? maq_comprimento_mais_largura_entre_vinco_de, Decimal? maq_comprimento_mais_largura_entre_vinco_ate, Decimal? maq_aba_de, Decimal? maq_aba_ate, Decimal? maq_lap_de, Decimal? maq_lap_ate, string maq_ondas, string maq_prolonga_lap, Decimal? maq_largura_impressao, Decimal? maq_comprimento_impressao, Decimal? maq_rolo_dispositivo_de, Decimal? maq_rolo_dispositivo_ate, string maq_familias, Decimal? maq_refile_minimo, Decimal? maq_largura_util, Decimal? maq_total_aco, string maq_fechamento, Decimal? maq_operacao_vincar, Decimal? maq_operacao_monta_divisao, Decimal? maq_operacao_serrar, string maq_tipo_lap, Decimal? maq_indice_paradas_por_op, int? maq_perda_maxima, int? maq_total_pecas_refilando, int? maq_total_pecas_nao_refilando, int? maq_total_vincos ){
 Id = id; 
 Descricao = descricao; 
 Status = status; 
 CAL_ID = cal_id; 
 MAQ_CONTROL_IP = maq_control_ip; 
 GMA_ID = gma_id; 
 MAQ_ULTIMA_ATUALIZACAO = (maq_ultima_atualizacao < (new DateTime(1800, 1, 1))) ? DateTime.Now : maq_ultima_atualizacao; 
 MAQ_SIRENE_SEMAFORO = maq_sirene_semaforo; 
 MAQ_COR_SEMAFORO = maq_cor_semaforo; 
 MAQ_ID_MAQ_PAI = maq_id_maq_pai; 
 MAQ_TIPO_CONTADOR = maq_tipo_contador; 
 MAQ_TIPO_PLANEJAMENTO = maq_tipo_planejamento; 
 MAQ_AVALIA_CUSTO = maq_avalia_custo; 
 FPR_ID_OP_PRODUZINDO = fpr_id_op_produzindo; 
 MAQ_CONGELA_FILA = maq_congela_fila; 
 MAQ_TEMPO_MIN_PARADA = maq_tempo_min_parada; 
 MAQ_QTD_CORES = maq_qtd_cores; 
 MAQ_ID_INTEGRACAO = maq_id_integracao; 
 MAQ_ID_INTEGRACAO_ERP = maq_id_integracao_erp; 
 MAQ_HIERARQUIA_SEQ_TRANSFORMACAO = maq_hierarquia_seq_transformacao; 
 EQU_ID = equ_id; 
 MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR = maq_percentual_inicio_passo_anterior; 
 MAQ_ACOMPANHA_LOTE_PILOTO = maq_acompanha_lote_piloto; 
 MAQ_ID_SENSOR = maq_id_sensor; 
 MAQ_DEBOUNCING_LOW = maq_debouncing_low; 
 MAQ_DEBOUNCING_HIGHT = maq_debouncing_hight; 
 MAQ_TIPO_SINAL = maq_tipo_sinal; 
 TEM_ID = tem_id; 
 MAQ_COMPRIMENTO_CHAPA_DE = maq_comprimento_chapa_de; 
 MAQ_COMPRIMENTO_CHAPA_ATE = maq_comprimento_chapa_ate; 
 MAQ_LARGURA_CHAPA_DE = maq_largura_chapa_de; 
 MAQ_LARGURA_CHAPA_ATE = maq_largura_chapa_ate; 
 MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR = maq_comprimento_chapa_de_facao_superior; 
 MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR = maq_comprimento_chapa_ate_facao_superior; 
 MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR = maq_comprimento_chapa_de_facao_inferior; 
 MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR = maq_comprimento_chapa_ate_facao_inferior; 
 MAQ_COMPRIMENTO_ENTRE_VINCO_DE = maq_comprimento_entre_vinco_de; 
 MAQ_COMPRIMENTO_ENTRE_VINCO_ATE = maq_comprimento_entre_vinco_ate; 
 MAQ_LARGURA_ENTRE_VINCO_DE = maq_largura_entre_vinco_de; 
 MAQ_LARGURA_ENTRE_VINCO_ATE = maq_largura_entre_vinco_ate; 
 MAQ_ALTURA_ENTRE_VINCO_DE = maq_altura_entre_vinco_de; 
 MAQ_ALTURA_ENTRE_VINCO_ATE = maq_altura_entre_vinco_ate; 
 MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE = maq_comprimento_mais_largura_entre_vinco_de; 
 MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE = maq_comprimento_mais_largura_entre_vinco_ate; 
 MAQ_ABA_DE = maq_aba_de; 
 MAQ_ABA_ATE = maq_aba_ate; 
 MAQ_LAP_DE = maq_lap_de; 
 MAQ_LAP_ATE = maq_lap_ate; 
 MAQ_ONDAS = maq_ondas; 
 MAQ_PROLONGA_LAP = maq_prolonga_lap; 
 MAQ_LARGURA_IMPRESSAO = maq_largura_impressao; 
 MAQ_COMPRIMENTO_IMPRESSAO = maq_comprimento_impressao; 
 MAQ_ROLO_DISPOSITIVO_DE = maq_rolo_dispositivo_de; 
 MAQ_ROLO_DISPOSITIVO_ATE = maq_rolo_dispositivo_ate; 
 MAQ_FAMILIAS = maq_familias; 
 MAQ_REFILE_MINIMO = maq_refile_minimo; 
 MAQ_LARGURA_UTIL = maq_largura_util; 
 MAQ_TOTAL_ACO = maq_total_aco; 
 MAQ_FECHAMENTO = maq_fechamento; 
 MAQ_OPERACAO_VINCAR = maq_operacao_vincar; 
 MAQ_OPERACAO_MONTA_DIVISAO = maq_operacao_monta_divisao; 
 MAQ_OPERACAO_SERRAR = maq_operacao_serrar; 
 MAQ_TIPO_LAP = maq_tipo_lap; 
 MAQ_INDICE_PARADAS_POR_OP = maq_indice_paradas_por_op; 
 MAQ_PERDA_MAXIMA = maq_perda_maxima; 
 MAQ_TOTAL_PECAS_REFILANDO = maq_total_pecas_refilando; 
 MAQ_TOTAL_PECAS_NAO_REFILANDO = maq_total_pecas_nao_refilando; 
 MAQ_TOTAL_VINCOS = maq_total_vincos; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(GMA_ID))
   this._erroMensagem.Add("GMA ID deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration