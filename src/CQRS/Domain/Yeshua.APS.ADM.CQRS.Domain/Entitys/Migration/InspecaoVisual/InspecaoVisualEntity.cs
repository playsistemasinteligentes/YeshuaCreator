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
                    public partial class InspecaoVisualEntity : IInspecaoVisualEntity
{
    public int IPV_ID { get; set; }
    public string IPV_VALOR { get; set; }
    public int? IPV_ID_OPERADOR { get; set; }
    public int? IPV_ID_LIBERACAO { get; set; }
    public string IPV_OBS { get; set; }
    public DateTime? IPV_DATA_COLETA { get; set; }
    public DateTime? IPV_DATA_AVAL { get; set; }
    public int? TIV_ID { get; set; }
    public string TURN_ID { get; set; }
    public string TURM_ID { get; set; }
    public string ORD_ID { get; set; }
    public string ROT_PRO_ID { get; set; }
    public string ROT_MAQ_ID { get; set; }
    public int? ROT_SEQ_TRANSFORMACAO { get; set; }
    public int? FPR_SEQ_REPETICAO { get; set; }
    public string IPV_STATUS_LIBERACAO { get; set; }
    public Decimal? IPV_VALOR_MEDIDA { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal InspecaoVisualEntity(int ipv_id, string ipv_valor, int? ipv_id_operador, int? ipv_id_liberacao, string ipv_obs, DateTime? ipv_data_coleta, DateTime? ipv_data_aval, int? tiv_id, string turn_id, string turm_id, string ord_id, string rot_pro_id, string rot_maq_id, int? rot_seq_transformacao, int? fpr_seq_repeticao, string ipv_status_liberacao, Decimal? ipv_valor_medida ){
 IPV_ID = ipv_id; 
 IPV_VALOR = ipv_valor; 
 IPV_ID_OPERADOR = ipv_id_operador; 
 IPV_ID_LIBERACAO = ipv_id_liberacao; 
 IPV_OBS = ipv_obs; 
 IPV_DATA_COLETA = (ipv_data_coleta < (new DateTime(1800, 1, 1))) ? DateTime.Now : ipv_data_coleta; 
 IPV_DATA_AVAL = (ipv_data_aval < (new DateTime(1800, 1, 1))) ? DateTime.Now : ipv_data_aval; 
 TIV_ID = tiv_id; 
 TURN_ID = turn_id; 
 TURM_ID = turm_id; 
 ORD_ID = ord_id; 
 ROT_PRO_ID = rot_pro_id; 
 ROT_MAQ_ID = rot_maq_id; 
 ROT_SEQ_TRANSFORMACAO = rot_seq_transformacao; 
 FPR_SEQ_REPETICAO = fpr_seq_repeticao; 
 IPV_STATUS_LIBERACAO = ipv_status_liberacao; 
 IPV_VALOR_MEDIDA = ipv_valor_medida; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration