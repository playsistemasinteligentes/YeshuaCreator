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
                    public partial class OndaEntity : IOndaEntity
{
    public string OND_ID { get; set; }
    public Decimal OND_ESPESSURA { get; set; }
    public Decimal? OND_PESO_COLA { get; set; }
    public Decimal? OND_RENDIMENTO_ONDA_1 { get; set; }
    public Decimal? OND_RENDIMENTO_ONDA_2 { get; set; }
    public int? OND_PROFUNDIDADE_VINCO { get; set; }
    public string OND_ID_INTEGRACAO { get; set; }
    public int VIN_ID { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal OndaEntity(string ond_id, Decimal ond_espessura, Decimal? ond_peso_cola, Decimal? ond_rendimento_onda_1, Decimal? ond_rendimento_onda_2, int? ond_profundidade_vinco, string ond_id_integracao, int vin_id ){
 OND_ID = ond_id; 
 OND_ESPESSURA = ond_espessura; 
 OND_PESO_COLA = ond_peso_cola; 
 OND_RENDIMENTO_ONDA_1 = ond_rendimento_onda_1; 
 OND_RENDIMENTO_ONDA_2 = ond_rendimento_onda_2; 
 OND_PROFUNDIDADE_VINCO = ond_profundidade_vinco; 
 OND_ID_INTEGRACAO = ond_id_integracao; 
 VIN_ID = vin_id; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(OND_ID))
   this._erroMensagem.Add("OND ID deve ser informado.");
   if(string.IsNullOrEmpty(OND_ID_INTEGRACAO))
   this._erroMensagem.Add("OND ID INTEGRACAO deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration