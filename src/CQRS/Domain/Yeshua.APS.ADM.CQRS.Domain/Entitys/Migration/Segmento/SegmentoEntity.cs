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
                    public partial class SegmentoEntity : ISegmentoEntity
{
    public int? Id { get; set; }
    public string SEG_ID { get; set; }
    public string SEG_DESCRICAO { get; set; }
    public string SEG_ID_SEGUIMENTO_PAI { get; set; }
    public string GRS_ID { get; set; }
    public string SEG_INTEGRACAO_ERP { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal SegmentoEntity(int? id, string seg_id, string seg_descricao, string seg_id_seguimento_pai, string grs_id, string seg_integracao_erp ){
 Id = id; 
 SEG_ID = seg_id; 
 SEG_DESCRICAO = seg_descricao; 
 SEG_ID_SEGUIMENTO_PAI = seg_id_seguimento_pai; 
 GRS_ID = grs_id; 
 SEG_INTEGRACAO_ERP = seg_integracao_erp; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(SEG_ID))
   this._erroMensagem.Add("SEG ID deve ser informado.");
   if(string.IsNullOrEmpty(SEG_DESCRICAO))
   this._erroMensagem.Add("SEG DESCRICAO deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration