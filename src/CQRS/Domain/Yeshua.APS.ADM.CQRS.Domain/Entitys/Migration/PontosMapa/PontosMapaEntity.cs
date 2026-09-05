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
                    public partial class PontosMapaEntity : IPontosMapaEntity
{
    public string PON_ID { get; set; }
    public string PON_DESCRICAO { get; set; }
    public string PON_TIPO { get; set; }
    public Decimal? PON_LATITUDE { get; set; }
    public Decimal? PON_LONGITUDE { get; set; }
    public Decimal? PON_DISTANCIA_KM { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal PontosMapaEntity(string pon_id, string pon_descricao, string pon_tipo, Decimal? pon_latitude, Decimal? pon_longitude, Decimal? pon_distancia_km ){
 PON_ID = pon_id; 
 PON_DESCRICAO = pon_descricao; 
 PON_TIPO = pon_tipo; 
 PON_LATITUDE = pon_latitude; 
 PON_LONGITUDE = pon_longitude; 
 PON_DISTANCIA_KM = pon_distancia_km; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(PON_ID))
   this._erroMensagem.Add("PON ID deve ser informado.");
   if(string.IsNullOrEmpty(PON_DESCRICAO))
   this._erroMensagem.Add("PON DESCRICAO deve ser informado.");
   if(string.IsNullOrEmpty(PON_TIPO))
   this._erroMensagem.Add("PON TIPO deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration