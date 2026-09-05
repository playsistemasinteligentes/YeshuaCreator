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
                    public partial class OrcamentoEntity : IOrcamentoEntity
{
    public int? Id { get; set; }
    public int ORC_ID { get; set; }
    public string REP_ID { get; set; }
    public string CON_ID { get; set; }
    public string ORC_TIPO_FRETE { get; set; }
    public DateTime? ORC_EMISSAO { get; set; }
    public string CLI_ID { get; set; }
    public int VER_ID { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal OrcamentoEntity(int? id, int orc_id, string rep_id, string con_id, string orc_tipo_frete, DateTime? orc_emissao, string cli_id, int ver_id ){
 Id = id; 
 ORC_ID = orc_id; 
 REP_ID = rep_id; 
 CON_ID = con_id; 
 ORC_TIPO_FRETE = orc_tipo_frete; 
 ORC_EMISSAO = (orc_emissao < (new DateTime(1800, 1, 1))) ? DateTime.Now : orc_emissao; 
 CLI_ID = cli_id; 
 VER_ID = ver_id; 
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