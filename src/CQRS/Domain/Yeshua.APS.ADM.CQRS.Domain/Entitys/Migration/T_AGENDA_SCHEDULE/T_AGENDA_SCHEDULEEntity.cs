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
                    public partial class T_AGENDA_SCHEDULEEntity : IT_AGENDA_SCHEDULEEntity
{
    public int? Id { get; set; }
    public int AGE_ID { get; set; }
    public DateTime? AGE_DATA_ESPECIFICA { get; set; }
    public string AGE_HORARIO_INICIO { get; set; }
    public string AGE_HORARIO_FIM { get; set; }
    public string AGE_SEGUNDA { get; set; }
    public string AGE_TERCA { get; set; }
    public string AGE_QUARTA { get; set; }
    public string AGE_QUINTA { get; set; }
    public string AGE_SEXTA { get; set; }
    public string AGE_SABADO { get; set; }
    public string AGE_DOMINGO { get; set; }
    public Decimal? AGE_INTERVALO { get; set; }
    public string AGE_ORDEM_EXECUCAO { get; set; }
    public string AGE_PARAMETROS { get; set; }
    public string AGE_EXCECAO { get; set; }
    public string AGE_DESCRICAO { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal T_AGENDA_SCHEDULEEntity(int? id, int age_id, DateTime? age_data_especifica, string age_horario_inicio, string age_horario_fim, string age_segunda, string age_terca, string age_quarta, string age_quinta, string age_sexta, string age_sabado, string age_domingo, Decimal? age_intervalo, string age_ordem_execucao, string age_parametros, string age_excecao, string age_descricao ){
 Id = id; 
 AGE_ID = age_id; 
 AGE_DATA_ESPECIFICA = (age_data_especifica < (new DateTime(1800, 1, 1))) ? DateTime.Now : age_data_especifica; 
 AGE_HORARIO_INICIO = age_horario_inicio; 
 AGE_HORARIO_FIM = age_horario_fim; 
 AGE_SEGUNDA = age_segunda; 
 AGE_TERCA = age_terca; 
 AGE_QUARTA = age_quarta; 
 AGE_QUINTA = age_quinta; 
 AGE_SEXTA = age_sexta; 
 AGE_SABADO = age_sabado; 
 AGE_DOMINGO = age_domingo; 
 AGE_INTERVALO = age_intervalo; 
 AGE_ORDEM_EXECUCAO = age_ordem_execucao; 
 AGE_PARAMETROS = age_parametros; 
 AGE_EXCECAO = age_excecao; 
 AGE_DESCRICAO = age_descricao; 
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