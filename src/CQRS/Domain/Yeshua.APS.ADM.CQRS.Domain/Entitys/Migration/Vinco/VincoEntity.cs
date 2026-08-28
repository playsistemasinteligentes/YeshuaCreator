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
                    public partial class VincoEntity : IVincoEntity
{
    public int VIN_ID { get; set; }
    public string VIN_DESCRICAO { get; set; }
    public string VIN_ID_DESLOCAMENTO { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal VincoEntity(int vin_id, string vin_descricao, string vin_id_deslocamento ){
 VIN_ID = vin_id; 
 VIN_DESCRICAO = vin_descricao; 
 VIN_ID_DESLOCAMENTO = vin_id_deslocamento; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (VIN_ID == null)
   this._erroMensagem.Add("VIN ID deve ser informado.");
   if(string.IsNullOrEmpty(VIN_DESCRICAO))
   this._erroMensagem.Add("VIN DESCRICAO deve ser informado.");
   if(string.IsNullOrEmpty(VIN_ID_DESLOCAMENTO))
   this._erroMensagem.Add("VIN ID DESLOCAMENTO deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration