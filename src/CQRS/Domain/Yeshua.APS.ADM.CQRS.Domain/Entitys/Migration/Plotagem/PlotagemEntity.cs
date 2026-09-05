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
                    public partial class PlotagemEntity : IPlotagemEntity
{
    public int? Id { get; set; }
    public int PLO_ID { get; set; }
    public string PLO_NOME { get; set; }
    public string PLO_DIMENSAO { get; set; }
    public string PLO_X { get; set; }
    public string PLO_Y { get; set; }
    public string PLO_Z { get; set; }
    public string PLO_GRAFICO { get; set; }
    public int? CON_ID { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal PlotagemEntity(int? id, int plo_id, string plo_nome, string plo_dimensao, string plo_x, string plo_y, string plo_z, string plo_grafico, int? con_id ){
 Id = id; 
 PLO_ID = plo_id; 
 PLO_NOME = plo_nome; 
 PLO_DIMENSAO = plo_dimensao; 
 PLO_X = plo_x; 
 PLO_Y = plo_y; 
 PLO_Z = plo_z; 
 PLO_GRAFICO = plo_grafico; 
 CON_ID = con_id; 
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