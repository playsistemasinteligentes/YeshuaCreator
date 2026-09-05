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
                    public partial class CanhotosEntity : ICanhotosEntity
{
    public int? Id { get; set; }
    public string CAR_ID { get; set; }
    public string ORD_ID { get; set; }
    public string NOT_ID { get; set; }
    public DateTime? CAN_DATA_ENTREGA { get; set; }
    public string CAN_IMG { get; set; }
    public Decimal? CAN_LAT_ENTREGA { get; set; }
    public Decimal? CAN_LONG_ENTREGA { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal CanhotosEntity(int? id, string car_id, string ord_id, string not_id, DateTime? can_data_entrega, string can_img, Decimal? can_lat_entrega, Decimal? can_long_entrega ){
 Id = id; 
 CAR_ID = car_id; 
 ORD_ID = ord_id; 
 NOT_ID = not_id; 
 CAN_DATA_ENTREGA = (can_data_entrega < (new DateTime(1800, 1, 1))) ? DateTime.Now : can_data_entrega; 
 CAN_IMG = can_img; 
 CAN_LAT_ENTREGA = can_lat_entrega; 
 CAN_LONG_ENTREGA = can_long_entrega; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(CAR_ID))
   this._erroMensagem.Add("CAR ID deve ser informado.");
   if(string.IsNullOrEmpty(ORD_ID))
   this._erroMensagem.Add("ORD ID deve ser informado.");
   if(string.IsNullOrEmpty(NOT_ID))
   this._erroMensagem.Add("NOT ID deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration