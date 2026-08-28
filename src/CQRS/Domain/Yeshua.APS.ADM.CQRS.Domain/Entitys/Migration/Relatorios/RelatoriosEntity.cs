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
                    public partial class RelatoriosEntity : IRelatoriosEntity
{
    public int REL_ID { get; set; }
    public string REL_NOME_RELATORIO { get; set; }
    public string REL_NOME_CAMPO { get; set; }
    public string REL_TIPO_CAMPO { get; set; }
    public int? REL_POS_X { get; set; }
    public int? REL_POS_Y { get; set; }
    public int? REL_TAMANHO_FONTE { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal RelatoriosEntity(int rel_id, string rel_nome_relatorio, string rel_nome_campo, string rel_tipo_campo, int? rel_pos_x, int? rel_pos_y, int? rel_tamanho_fonte ){
 REL_ID = rel_id; 
 REL_NOME_RELATORIO = rel_nome_relatorio; 
 REL_NOME_CAMPO = rel_nome_campo; 
 REL_TIPO_CAMPO = rel_tipo_campo; 
 REL_POS_X = rel_pos_x; 
 REL_POS_Y = rel_pos_y; 
 REL_TAMANHO_FONTE = rel_tamanho_fonte; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (REL_ID == null)
   this._erroMensagem.Add("REL ID deve ser informado.");
   if(string.IsNullOrEmpty(REL_NOME_CAMPO))
   this._erroMensagem.Add("REL NOME CAMPO deve ser informado.");
   if(string.IsNullOrEmpty(REL_TIPO_CAMPO))
   this._erroMensagem.Add("REL TIPO CAMPO deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration