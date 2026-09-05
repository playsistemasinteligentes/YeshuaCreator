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
                    public partial class TurmaEntity : ITurmaEntity
{
    public string Id { get; set; }
    public string Descricao { get; set; }
    public DateTime? TURM_HORA_INI_DIA1 { get; set; }
    public DateTime? TURM_HORA_FIM_DIA1 { get; set; }
    public DateTime? TURM_HORA_INI_DIA2 { get; set; }
    public DateTime? TURM_HORA_FIM_DIA2 { get; set; }
    public DateTime? TURM_HORA_INI_DIA3 { get; set; }
    public DateTime? TURM_HORA_FIM_DIA3 { get; set; }
    public DateTime? TURM_HORA_INI_DIA4 { get; set; }
    public DateTime? TURM_HORA_FIM_DIA4 { get; set; }
    public DateTime? TURM_HORA_INI_DIA5 { get; set; }
    public DateTime? TURM_HORA_FIM_DIA5 { get; set; }
    public DateTime? TURM_HORA_INI_DIA6 { get; set; }
    public DateTime? TURM_HORA_FIM_DIA6 { get; set; }
    public DateTime? TURM_HORA_INI_DIA7 { get; set; }
    public DateTime? TURM_HORA_FIM_DIA7 { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal TurmaEntity(string id, string descricao, DateTime? turm_hora_ini_dia1, DateTime? turm_hora_fim_dia1, DateTime? turm_hora_ini_dia2, DateTime? turm_hora_fim_dia2, DateTime? turm_hora_ini_dia3, DateTime? turm_hora_fim_dia3, DateTime? turm_hora_ini_dia4, DateTime? turm_hora_fim_dia4, DateTime? turm_hora_ini_dia5, DateTime? turm_hora_fim_dia5, DateTime? turm_hora_ini_dia6, DateTime? turm_hora_fim_dia6, DateTime? turm_hora_ini_dia7, DateTime? turm_hora_fim_dia7 ){
 Id = id; 
 Descricao = descricao; 
 TURM_HORA_INI_DIA1 = (turm_hora_ini_dia1 < (new DateTime(1800, 1, 1))) ? DateTime.Now : turm_hora_ini_dia1; 
 TURM_HORA_FIM_DIA1 = (turm_hora_fim_dia1 < (new DateTime(1800, 1, 1))) ? DateTime.Now : turm_hora_fim_dia1; 
 TURM_HORA_INI_DIA2 = (turm_hora_ini_dia2 < (new DateTime(1800, 1, 1))) ? DateTime.Now : turm_hora_ini_dia2; 
 TURM_HORA_FIM_DIA2 = (turm_hora_fim_dia2 < (new DateTime(1800, 1, 1))) ? DateTime.Now : turm_hora_fim_dia2; 
 TURM_HORA_INI_DIA3 = (turm_hora_ini_dia3 < (new DateTime(1800, 1, 1))) ? DateTime.Now : turm_hora_ini_dia3; 
 TURM_HORA_FIM_DIA3 = (turm_hora_fim_dia3 < (new DateTime(1800, 1, 1))) ? DateTime.Now : turm_hora_fim_dia3; 
 TURM_HORA_INI_DIA4 = (turm_hora_ini_dia4 < (new DateTime(1800, 1, 1))) ? DateTime.Now : turm_hora_ini_dia4; 
 TURM_HORA_FIM_DIA4 = (turm_hora_fim_dia4 < (new DateTime(1800, 1, 1))) ? DateTime.Now : turm_hora_fim_dia4; 
 TURM_HORA_INI_DIA5 = (turm_hora_ini_dia5 < (new DateTime(1800, 1, 1))) ? DateTime.Now : turm_hora_ini_dia5; 
 TURM_HORA_FIM_DIA5 = (turm_hora_fim_dia5 < (new DateTime(1800, 1, 1))) ? DateTime.Now : turm_hora_fim_dia5; 
 TURM_HORA_INI_DIA6 = (turm_hora_ini_dia6 < (new DateTime(1800, 1, 1))) ? DateTime.Now : turm_hora_ini_dia6; 
 TURM_HORA_FIM_DIA6 = (turm_hora_fim_dia6 < (new DateTime(1800, 1, 1))) ? DateTime.Now : turm_hora_fim_dia6; 
 TURM_HORA_INI_DIA7 = (turm_hora_ini_dia7 < (new DateTime(1800, 1, 1))) ? DateTime.Now : turm_hora_ini_dia7; 
 TURM_HORA_FIM_DIA7 = (turm_hora_fim_dia7 < (new DateTime(1800, 1, 1))) ? DateTime.Now : turm_hora_fim_dia7; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(Id))
   this._erroMensagem.Add("Id deve ser informado.");
   if(string.IsNullOrEmpty(Descricao))
   this._erroMensagem.Add("Descricao deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration