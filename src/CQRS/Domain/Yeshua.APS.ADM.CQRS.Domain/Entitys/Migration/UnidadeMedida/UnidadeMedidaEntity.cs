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
                    public partial class UnidadeMedidaEntity : IUnidadeMedidaEntity
{
    public string UNI_ID { get; set; }
    public string UNI_DESCRICAO { get; set; }
    public string UNI_ESCALA_TEMPO { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal UnidadeMedidaEntity(string uni_id, string uni_descricao, string uni_escala_tempo ){
 UNI_ID = uni_id; 
 UNI_DESCRICAO = uni_descricao; 
 UNI_ESCALA_TEMPO = uni_escala_tempo; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(UNI_ID))
   this._erroMensagem.Add("UNI ID deve ser informado.");
   if(string.IsNullOrEmpty(UNI_DESCRICAO))
   this._erroMensagem.Add("UNI DESCRICAO deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration