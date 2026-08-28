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
                    public partial class RotaRealizadaEntity : IRotaRealizadaEntity
{
    public int ROT_ID { get; set; }
    public string CAR_ID { get; set; }
    public DateTime? ROT_DATA_HORA { get; set; }
    public Decimal? ROT_LAT { get; set; }
    public Decimal? ROT_LONG { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal RotaRealizadaEntity(int rot_id, string car_id, DateTime? rot_data_hora, Decimal? rot_lat, Decimal? rot_long ){
 ROT_ID = rot_id; 
 CAR_ID = car_id; 
 ROT_DATA_HORA = (rot_data_hora < (new DateTime(1800, 1, 1))) ? DateTime.Now : rot_data_hora; 
 ROT_LAT = rot_lat; 
 ROT_LONG = rot_long; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (ROT_ID == null)
   this._erroMensagem.Add("ROT ID deve ser informado.");
   if(string.IsNullOrEmpty(CAR_ID))
   this._erroMensagem.Add("CAR ID deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration