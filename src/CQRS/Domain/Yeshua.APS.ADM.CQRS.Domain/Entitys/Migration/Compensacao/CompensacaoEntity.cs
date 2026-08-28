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
                    public partial class CompensacaoEntity : ICompensacaoEntity
{
    public int? Id { get; set; }
    public int COM_ID { get; set; }
    public string GRP_ID { get; set; }
    public string OND_ID { get; set; }
    public int? COM_VINCO1_OND { get; set; }
    public int? COM_VINCO2_OND { get; set; }
    public int? COM_VINCO3_OND { get; set; }
    public int? COM_VINCO4_OND { get; set; }
    public int? COM_VINCO5_OND { get; set; }
    public int? COM_VINCO6_OND { get; set; }
    public int? COM_VINCO7_OND { get; set; }
    public int? COM_VINCO8_OND { get; set; }
    public int? COM_VINCO9_OND { get; set; }
    public int? COM_VINCO10_OND { get; set; }
    public int? COM_VINCO1_CONVERSAO { get; set; }
    public int? COM_VINCO2_CONVERSAO { get; set; }
    public int? COM_VINCO3_CONVERSAO { get; set; }
    public int? COM_VINCO4_CONVERSAO { get; set; }
    public int? COM_VINCO5_CONVERSAO { get; set; }
    public int? COM_VINCO6_CONVERSAO { get; set; }
    public int? COM_VINCO7_CONVERSAO { get; set; }
    public int? COM_VINCO8_CONVERSAO { get; set; }
    public int? COM_VINCO9_CONVERSAO { get; set; }
    public int? COM_VINCO10_CONVERSAO { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal CompensacaoEntity(int? id, int com_id, string grp_id, string ond_id, int? com_vinco1_ond, int? com_vinco2_ond, int? com_vinco3_ond, int? com_vinco4_ond, int? com_vinco5_ond, int? com_vinco6_ond, int? com_vinco7_ond, int? com_vinco8_ond, int? com_vinco9_ond, int? com_vinco10_ond, int? com_vinco1_conversao, int? com_vinco2_conversao, int? com_vinco3_conversao, int? com_vinco4_conversao, int? com_vinco5_conversao, int? com_vinco6_conversao, int? com_vinco7_conversao, int? com_vinco8_conversao, int? com_vinco9_conversao, int? com_vinco10_conversao ){
 Id = id; 
 COM_ID = com_id; 
 GRP_ID = grp_id; 
 OND_ID = ond_id; 
 COM_VINCO1_OND = com_vinco1_ond; 
 COM_VINCO2_OND = com_vinco2_ond; 
 COM_VINCO3_OND = com_vinco3_ond; 
 COM_VINCO4_OND = com_vinco4_ond; 
 COM_VINCO5_OND = com_vinco5_ond; 
 COM_VINCO6_OND = com_vinco6_ond; 
 COM_VINCO7_OND = com_vinco7_ond; 
 COM_VINCO8_OND = com_vinco8_ond; 
 COM_VINCO9_OND = com_vinco9_ond; 
 COM_VINCO10_OND = com_vinco10_ond; 
 COM_VINCO1_CONVERSAO = com_vinco1_conversao; 
 COM_VINCO2_CONVERSAO = com_vinco2_conversao; 
 COM_VINCO3_CONVERSAO = com_vinco3_conversao; 
 COM_VINCO4_CONVERSAO = com_vinco4_conversao; 
 COM_VINCO5_CONVERSAO = com_vinco5_conversao; 
 COM_VINCO6_CONVERSAO = com_vinco6_conversao; 
 COM_VINCO7_CONVERSAO = com_vinco7_conversao; 
 COM_VINCO8_CONVERSAO = com_vinco8_conversao; 
 COM_VINCO9_CONVERSAO = com_vinco9_conversao; 
 COM_VINCO10_CONVERSAO = com_vinco10_conversao; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (COM_ID == null)
   this._erroMensagem.Add("COM ID deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration