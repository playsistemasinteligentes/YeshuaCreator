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
                    public partial class VerssaoCustoEntity : IVerssaoCustoEntity
{
    public int? Id { get; set; }
    public int VER_ID { get; set; }
    public string VER_STATUS { get; set; }
    public DateTime? VER_DATA_VERSSAO_CUSTO { get; set; }
    public string VER_OBS { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal VerssaoCustoEntity(int? id, int ver_id, string ver_status, DateTime? ver_data_verssao_custo, string ver_obs ){
 Id = id; 
 VER_ID = ver_id; 
 VER_STATUS = ver_status; 
 VER_DATA_VERSSAO_CUSTO = (ver_data_verssao_custo < (new DateTime(1800, 1, 1))) ? DateTime.Now : ver_data_verssao_custo; 
 VER_OBS = ver_obs; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (VER_ID == null)
   this._erroMensagem.Add("VER ID deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration