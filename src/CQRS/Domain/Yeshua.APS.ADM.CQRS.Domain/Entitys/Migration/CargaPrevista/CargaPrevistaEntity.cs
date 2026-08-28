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
                    public partial class CargaPrevistaEntity : ICargaPrevistaEntity
{
    public int? Id { get; set; }
    public string CAR_ID { get; set; }
    public string ORD_ID { get; set; }
    public Decimal ITC_QTD_PLANEJADA { get; set; }
    public DateTime? CAR_PREVISAO_MATERIA_PRIMA { get; set; }
    public DateTime? CAR_DATA_INICIO_PREVISTO { get; set; }
    public DateTime? CAR_DATA_INICIO_REALIZADO { get; set; }
    public DateTime? CAR_DATA_FIM_PREVISTO { get; set; }
    public DateTime? CAR_DATA_FIM_REALIZADO { get; set; }
    public DateTime? CAR_INICIO_JANELA_EMBARQUE { get; set; }
    public DateTime? CAR_FIM_JANELA_EMBARQUE { get; set; }
    public DateTime? CAR_EMBARQUE_ALVO { get; set; }
    public Decimal? CAR_STATUS { get; set; }
    public Decimal? CAR_PESO_TEORICO { get; set; }
    public Decimal? CAR_VOLUME_TEORICO { get; set; }
    public Decimal? CAR_PESO_REAL { get; set; }
    public Decimal? CAR_VOLUME_REAL { get; set; }
    public Decimal? CAR_PESO_EMBALAGEM { get; set; }
    public Decimal? CAR_PESO_ENTRADA { get; set; }
    public Decimal? CAR_PESO_SAIDA { get; set; }
    public string CAR_ID_DOCA { get; set; }
    public string VEI_PLACA { get; set; }
    public int? TIP_ID { get; set; }
    public string TRA_ID { get; set; }
    public Decimal? CAR_GRUPO_PRODUTIVO { get; set; }
    public string ROT_ID { get; set; }
    public string CAR_OBSERVACAO_DE_TRANSPORTE { get; set; }
    public string CAR_JUSTIFICATIVA_DE_CARREGAMENTO { get; set; }
    public string OCO_ID { get; set; }
    public string CAR_ID_JUNTADA { get; set; }
    public string CAR_OBSERVACAO_OTIMIZADOR { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal CargaPrevistaEntity(int? id, string car_id, string ord_id, Decimal itc_qtd_planejada, DateTime? car_previsao_materia_prima, DateTime? car_data_inicio_previsto, DateTime? car_data_inicio_realizado, DateTime? car_data_fim_previsto, DateTime? car_data_fim_realizado, DateTime? car_inicio_janela_embarque, DateTime? car_fim_janela_embarque, DateTime? car_embarque_alvo, Decimal? car_status, Decimal? car_peso_teorico, Decimal? car_volume_teorico, Decimal? car_peso_real, Decimal? car_volume_real, Decimal? car_peso_embalagem, Decimal? car_peso_entrada, Decimal? car_peso_saida, string car_id_doca, string vei_placa, int? tip_id, string tra_id, Decimal? car_grupo_produtivo, string rot_id, string car_observacao_de_transporte, string car_justificativa_de_carregamento, string oco_id, string car_id_juntada, string car_observacao_otimizador ){
 Id = id; 
 CAR_ID = car_id; 
 ORD_ID = ord_id; 
 ITC_QTD_PLANEJADA = itc_qtd_planejada; 
 CAR_PREVISAO_MATERIA_PRIMA = (car_previsao_materia_prima < (new DateTime(1800, 1, 1))) ? DateTime.Now : car_previsao_materia_prima; 
 CAR_DATA_INICIO_PREVISTO = (car_data_inicio_previsto < (new DateTime(1800, 1, 1))) ? DateTime.Now : car_data_inicio_previsto; 
 CAR_DATA_INICIO_REALIZADO = (car_data_inicio_realizado < (new DateTime(1800, 1, 1))) ? DateTime.Now : car_data_inicio_realizado; 
 CAR_DATA_FIM_PREVISTO = (car_data_fim_previsto < (new DateTime(1800, 1, 1))) ? DateTime.Now : car_data_fim_previsto; 
 CAR_DATA_FIM_REALIZADO = (car_data_fim_realizado < (new DateTime(1800, 1, 1))) ? DateTime.Now : car_data_fim_realizado; 
 CAR_INICIO_JANELA_EMBARQUE = (car_inicio_janela_embarque < (new DateTime(1800, 1, 1))) ? DateTime.Now : car_inicio_janela_embarque; 
 CAR_FIM_JANELA_EMBARQUE = (car_fim_janela_embarque < (new DateTime(1800, 1, 1))) ? DateTime.Now : car_fim_janela_embarque; 
 CAR_EMBARQUE_ALVO = (car_embarque_alvo < (new DateTime(1800, 1, 1))) ? DateTime.Now : car_embarque_alvo; 
 CAR_STATUS = car_status; 
 CAR_PESO_TEORICO = car_peso_teorico; 
 CAR_VOLUME_TEORICO = car_volume_teorico; 
 CAR_PESO_REAL = car_peso_real; 
 CAR_VOLUME_REAL = car_volume_real; 
 CAR_PESO_EMBALAGEM = car_peso_embalagem; 
 CAR_PESO_ENTRADA = car_peso_entrada; 
 CAR_PESO_SAIDA = car_peso_saida; 
 CAR_ID_DOCA = car_id_doca; 
 VEI_PLACA = vei_placa; 
 TIP_ID = tip_id; 
 TRA_ID = tra_id; 
 CAR_GRUPO_PRODUTIVO = car_grupo_produtivo; 
 ROT_ID = rot_id; 
 CAR_OBSERVACAO_DE_TRANSPORTE = car_observacao_de_transporte; 
 CAR_JUSTIFICATIVA_DE_CARREGAMENTO = car_justificativa_de_carregamento; 
 OCO_ID = oco_id; 
 CAR_ID_JUNTADA = car_id_juntada; 
 CAR_OBSERVACAO_OTIMIZADOR = car_observacao_otimizador; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(CAR_ID))
   this._erroMensagem.Add("CAR ID deve ser informado.");
   if(string.IsNullOrEmpty(ORD_ID))
   this._erroMensagem.Add("ORD ID deve ser informado.");
   if (ITC_QTD_PLANEJADA == null)
   this._erroMensagem.Add("ITC QTD PLANEJADA deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration