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
                    public partial class PoliticaOnduladeiraEntity : IPoliticaOnduladeiraEntity
{
    public int? Id { get; set; }
    public int POL_ID { get; set; }
    public int? POL_NIVEL { get; set; }
    public int? POL_PROMOCAO { get; set; }
    public int? POL_DIAS_ANTECIPACAO { get; set; }
    public int? POL_METROS_LINEARES { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal PoliticaOnduladeiraEntity(int? id, int pol_id, int? pol_nivel, int? pol_promocao, int? pol_dias_antecipacao, int? pol_metros_lineares ){
 Id = id; 
 POL_ID = pol_id; 
 POL_NIVEL = pol_nivel; 
 POL_PROMOCAO = pol_promocao; 
 POL_DIAS_ANTECIPACAO = pol_dias_antecipacao; 
 POL_METROS_LINEARES = pol_metros_lineares; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (POL_ID == null)
   this._erroMensagem.Add("POL ID deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration