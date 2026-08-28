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
                    public partial class ObservacoesEntity : IObservacoesEntity
{
    public int OBS_ID { get; set; }
    public string OBS_TIPO { get; set; }
    public string OBS_DESCRICAO { get; set; }
    public string CLI_ID { get; set; }
    public string MAQ_ID { get; set; }
    public string PRO_ID { get; set; }
    public int? ROT_SEQ_TRANFORMACAO { get; set; }
    public string OBS_INTEGRACAO { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal ObservacoesEntity(int obs_id, string obs_tipo, string obs_descricao, string cli_id, string maq_id, string pro_id, int? rot_seq_tranformacao, string obs_integracao ){
 OBS_ID = obs_id; 
 OBS_TIPO = obs_tipo; 
 OBS_DESCRICAO = obs_descricao; 
 CLI_ID = cli_id; 
 MAQ_ID = maq_id; 
 PRO_ID = pro_id; 
 ROT_SEQ_TRANFORMACAO = rot_seq_tranformacao; 
 OBS_INTEGRACAO = obs_integracao; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (OBS_ID == null)
   this._erroMensagem.Add("OBS ID deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration