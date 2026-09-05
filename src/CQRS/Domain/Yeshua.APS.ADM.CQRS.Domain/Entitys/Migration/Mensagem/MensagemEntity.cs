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
                    public partial class MensagemEntity : IMensagemEntity
{
    public string MEN_ID { get; set; }
    public string MEN_SEND { get; set; }
    public DateTime? MEN_EMISSION { get; set; }
    public string MEN_STATUS { get; set; }
    public string MEN_RECEIVE { get; set; }
    public string MEN_TYPE { get; set; }
    public Decimal? MEN_QTD_TRY_SEND { get; set; }
    public DateTime? MEN_DATE_TRY_SEND { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal MensagemEntity(string men_id, string men_send, DateTime? men_emission, string men_status, string men_receive, string men_type, Decimal? men_qtd_try_send, DateTime? men_date_try_send ){
 MEN_ID = men_id; 
 MEN_SEND = men_send; 
 MEN_EMISSION = (men_emission < (new DateTime(1800, 1, 1))) ? DateTime.Now : men_emission; 
 MEN_STATUS = men_status; 
 MEN_RECEIVE = men_receive; 
 MEN_TYPE = men_type; 
 MEN_QTD_TRY_SEND = men_qtd_try_send; 
 MEN_DATE_TRY_SEND = (men_date_try_send < (new DateTime(1800, 1, 1))) ? DateTime.Now : men_date_try_send; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(MEN_ID))
   this._erroMensagem.Add("MEN ID deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration