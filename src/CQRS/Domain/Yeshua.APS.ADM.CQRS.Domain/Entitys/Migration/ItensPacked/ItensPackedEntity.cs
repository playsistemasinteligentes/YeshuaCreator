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
                    public partial class ItensPackedEntity : IItensPackedEntity
{
    public int? Id { get; set; }
    public int IPA_ID { get; set; }
    public string CAR_ID { get; set; }
    public string PRO_ID { get; set; }
    public string ORD_ID { get; set; }
    public Decimal? IPA_COORDC { get; set; }
    public Decimal? IPA_COORDL { get; set; }
    public Decimal? IPA_COORDA { get; set; }
    public Decimal? IPA_DIMC { get; set; }
    public Decimal? IPA_DIML { get; set; }
    public Decimal? IPA_DIMA { get; set; }
    public Decimal? IPA_QTD_POR_PALETE { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal ItensPackedEntity(int? id, int ipa_id, string car_id, string pro_id, string ord_id, Decimal? ipa_coordc, Decimal? ipa_coordl, Decimal? ipa_coorda, Decimal? ipa_dimc, Decimal? ipa_diml, Decimal? ipa_dima, Decimal? ipa_qtd_por_palete ){
 Id = id; 
 IPA_ID = ipa_id; 
 CAR_ID = car_id; 
 PRO_ID = pro_id; 
 ORD_ID = ord_id; 
 IPA_COORDC = ipa_coordc; 
 IPA_COORDL = ipa_coordl; 
 IPA_COORDA = ipa_coorda; 
 IPA_DIMC = ipa_dimc; 
 IPA_DIML = ipa_diml; 
 IPA_DIMA = ipa_dima; 
 IPA_QTD_POR_PALETE = ipa_qtd_por_palete; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (IPA_ID == null)
   this._erroMensagem.Add("IPA ID deve ser informado.");
   if(string.IsNullOrEmpty(CAR_ID))
   this._erroMensagem.Add("CAR ID deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration