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
                    public partial class ItensCalendarioEntity : IItensCalendarioEntity
{
    public int ICA_ID { get; set; }
    public DateTime ICA_DATA_DE { get; set; }
    public DateTime ICA_DATA_ATE { get; set; }
    public string ICA_OBSERVACAO { get; set; }
    public int ICA_TIPO { get; set; }
    public string URM_ID { get; set; }
    public string URN_ID { get; set; }
    public int CAL_ID { get; set; }
    public string MAQ_ID { get; set; }
    public string PRO_ID { get; set; }
    public int? ICA_LIMPESA_MAQUINA { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal ItensCalendarioEntity(int ica_id, DateTime ica_data_de, DateTime ica_data_ate, string ica_observacao, int ica_tipo, string urm_id, string urn_id, int cal_id, string maq_id, string pro_id, int? ica_limpesa_maquina ){
 ICA_ID = ica_id; 
 ICA_DATA_DE = (ica_data_de < (new DateTime(1800, 1, 1))) ? DateTime.Now : ica_data_de; 
 ICA_DATA_ATE = (ica_data_ate < (new DateTime(1800, 1, 1))) ? DateTime.Now : ica_data_ate; 
 ICA_OBSERVACAO = ica_observacao; 
 ICA_TIPO = ica_tipo; 
 URM_ID = urm_id; 
 URN_ID = urn_id; 
 CAL_ID = cal_id; 
 MAQ_ID = maq_id; 
 PRO_ID = pro_id; 
 ICA_LIMPESA_MAQUINA = ica_limpesa_maquina; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (ICA_ID == null)
   this._erroMensagem.Add("ICA ID deve ser informado.");
   if (ICA_DATA_DE == null || ICA_DATA_DE < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("ICA DATA DE deve ser informado.");
   if (ICA_DATA_ATE == null || ICA_DATA_ATE < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("ICA DATA ATE deve ser informado.");
   if (ICA_TIPO == null)
   this._erroMensagem.Add("ICA TIPO deve ser informado.");
   if (CAL_ID == null)
   this._erroMensagem.Add("CAL ID deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration