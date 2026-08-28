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
                    public partial class T_HORARIO_RECEBIMENTOEntity : IT_HORARIO_RECEBIMENTOEntity
{
    public int HRE_DIA_DA_SEMANA { get; set; }
    public DateTime HRE_HORA_INICIAL { get; set; }
    public DateTime HRE_HORA_FINAL { get; set; }
    public string CLI_ID { get; set; }
    public int HRE_ID { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal T_HORARIO_RECEBIMENTOEntity(int hre_dia_da_semana, DateTime hre_hora_inicial, DateTime hre_hora_final, string cli_id, int hre_id ){
 HRE_DIA_DA_SEMANA = hre_dia_da_semana; 
 HRE_HORA_INICIAL = (hre_hora_inicial < (new DateTime(1800, 1, 1))) ? DateTime.Now : hre_hora_inicial; 
 HRE_HORA_FINAL = (hre_hora_final < (new DateTime(1800, 1, 1))) ? DateTime.Now : hre_hora_final; 
 CLI_ID = cli_id; 
 HRE_ID = hre_id; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (HRE_DIA_DA_SEMANA == null)
   this._erroMensagem.Add("HRE DIA DA SEMANA deve ser informado.");
   if (HRE_HORA_INICIAL == null || HRE_HORA_INICIAL < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("HRE HORA INICIAL deve ser informado.");
   if (HRE_HORA_FINAL == null || HRE_HORA_FINAL < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("HRE HORA FINAL deve ser informado.");
   if(string.IsNullOrEmpty(CLI_ID))
   this._erroMensagem.Add("CLI ID deve ser informado.");
   if (HRE_ID == null)
   this._erroMensagem.Add("HRE ID deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration