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
                    public partial class CalendarioDisponibilidadeVeiculosEntity : ICalendarioDisponibilidadeVeiculosEntity
{
    public int? Id { get; set; }
    public int CDV_ID { get; set; }
    public DateTime? CDV_DATA_DE { get; set; }
    public DateTime? CDV_DATA_ATE { get; set; }
    public int? CDV_SEGUNDA { get; set; }
    public int? CDV_TERCA { get; set; }
    public int? CDV_QUARTA { get; set; }
    public int? CDV_QUINTA { get; set; }
    public int? CDV_SEXTA { get; set; }
    public int? CDV_SABADO { get; set; }
    public int? CDV_DOMINGO { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal CalendarioDisponibilidadeVeiculosEntity(int? id, int cdv_id, DateTime? cdv_data_de, DateTime? cdv_data_ate, int? cdv_segunda, int? cdv_terca, int? cdv_quarta, int? cdv_quinta, int? cdv_sexta, int? cdv_sabado, int? cdv_domingo ){
 Id = id; 
 CDV_ID = cdv_id; 
 CDV_DATA_DE = (cdv_data_de < (new DateTime(1800, 1, 1))) ? DateTime.Now : cdv_data_de; 
 CDV_DATA_ATE = (cdv_data_ate < (new DateTime(1800, 1, 1))) ? DateTime.Now : cdv_data_ate; 
 CDV_SEGUNDA = cdv_segunda; 
 CDV_TERCA = cdv_terca; 
 CDV_QUARTA = cdv_quarta; 
 CDV_QUINTA = cdv_quinta; 
 CDV_SEXTA = cdv_sexta; 
 CDV_SABADO = cdv_sabado; 
 CDV_DOMINGO = cdv_domingo; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (CDV_ID == null)
   this._erroMensagem.Add("CDV ID deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration