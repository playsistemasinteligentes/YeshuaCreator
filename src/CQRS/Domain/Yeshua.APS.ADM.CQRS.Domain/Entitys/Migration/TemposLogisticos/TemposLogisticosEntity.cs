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
                    public partial class TemposLogisticosEntity : ITemposLogisticosEntity
{
    public int? Id { get; set; }
    public string TMP_TIPO_TEMPO { get; set; }
    public string TMP_TIPO_CARGA { get; set; }
    public Decimal TMP_TEMPO_MEDIO_UNITARIO { get; set; }
    public string CLI_ID { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal TemposLogisticosEntity(int? id, string tmp_tipo_tempo, string tmp_tipo_carga, Decimal tmp_tempo_medio_unitario, string cli_id ){
 Id = id; 
 TMP_TIPO_TEMPO = tmp_tipo_tempo; 
 TMP_TIPO_CARGA = tmp_tipo_carga; 
 TMP_TEMPO_MEDIO_UNITARIO = tmp_tempo_medio_unitario; 
 CLI_ID = cli_id; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(TMP_TIPO_TEMPO))
   this._erroMensagem.Add("TMP TIPO TEMPO deve ser informado.");
   if(string.IsNullOrEmpty(TMP_TIPO_CARGA))
   this._erroMensagem.Add("TMP TIPO CARGA deve ser informado.");
   if(string.IsNullOrEmpty(CLI_ID))
   this._erroMensagem.Add("CLI ID deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration