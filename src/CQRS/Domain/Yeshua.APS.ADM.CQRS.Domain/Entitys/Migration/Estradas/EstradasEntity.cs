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
                    public partial class EstradasEntity : IEstradasEntity
{
    public int? Id { get; set; }
    public int EST_ID { get; set; }
    public string EST_DESCRICAO { get; set; }
    public int? EST_ID_LIGACAO_PONTO_A { get; set; }
    public int? EST_ID_LIGACAO_PONTO_B { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal EstradasEntity(int? id, int est_id, string est_descricao, int? est_id_ligacao_ponto_a, int? est_id_ligacao_ponto_b ){
 Id = id; 
 EST_ID = est_id; 
 EST_DESCRICAO = est_descricao; 
 EST_ID_LIGACAO_PONTO_A = est_id_ligacao_ponto_a; 
 EST_ID_LIGACAO_PONTO_B = est_id_ligacao_ponto_b; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (EST_ID == null)
   this._erroMensagem.Add("EST ID deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration