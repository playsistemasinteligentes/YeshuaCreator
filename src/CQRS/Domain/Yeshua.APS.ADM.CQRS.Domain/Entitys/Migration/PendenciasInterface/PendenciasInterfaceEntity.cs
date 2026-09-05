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
                    public partial class PendenciasInterfaceEntity : IPendenciasInterfaceEntity
{
    public string PEN_STATUS_OUT { get; set; }
    public string PEN_PROTOCOLO_OUT { get; set; }
    public string PEN_ID_PROTOCOLO_OUT { get; set; }
    public string PEN_STATUS_IN { get; set; }
    public string PEN_PROTOCOLO_IN { get; set; }
    public string PEN_ID_PROTOCOLO_IN { get; set; }
    public DateTime DATA_ENTRADA { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    public int PEN_ID { get; set; }
    private List<string> _erroMensagem = null;
 internal PendenciasInterfaceEntity(string pen_status_out, string pen_protocolo_out, string pen_id_protocolo_out, string pen_status_in, string pen_protocolo_in, string pen_id_protocolo_in, DateTime data_entrada, int pen_id ){
 PEN_STATUS_OUT = pen_status_out; 
 PEN_PROTOCOLO_OUT = pen_protocolo_out; 
 PEN_ID_PROTOCOLO_OUT = pen_id_protocolo_out; 
 PEN_STATUS_IN = pen_status_in; 
 PEN_PROTOCOLO_IN = pen_protocolo_in; 
 PEN_ID_PROTOCOLO_IN = pen_id_protocolo_in; 
 DATA_ENTRADA = (data_entrada < (new DateTime(1800, 1, 1))) ? DateTime.Now : data_entrada; 
 PEN_ID = pen_id; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(DATA_ENTRADA == null || DATA_ENTRADA < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("DATA ENTRADA deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration