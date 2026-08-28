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
                    public partial class RotaPontosMapaEntity : IRotaPontosMapaEntity
{
    public int? Id { get; set; }
    public string ROT_ID { get; set; }
    public string PON_ID_DESTINO { get; set; }
    public string PON_ID_ORIGEM { get; set; }
    public Decimal? ROT_CUSTO_TOTAL { get; set; }
    public string PON_ID_ROTEIRO { get; set; }
    public int? ROT_ORDEM_ROTEIRO { get; set; }
    public string ROT_TIPO { get; set; }
    public Decimal? ROT_DISTANCIA { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal RotaPontosMapaEntity(int? id, string rot_id, string pon_id_destino, string pon_id_origem, Decimal? rot_custo_total, string pon_id_roteiro, int? rot_ordem_roteiro, string rot_tipo, Decimal? rot_distancia ){
 Id = id; 
 ROT_ID = rot_id; 
 PON_ID_DESTINO = pon_id_destino; 
 PON_ID_ORIGEM = pon_id_origem; 
 ROT_CUSTO_TOTAL = rot_custo_total; 
 PON_ID_ROTEIRO = pon_id_roteiro; 
 ROT_ORDEM_ROTEIRO = rot_ordem_roteiro; 
 ROT_TIPO = rot_tipo; 
 ROT_DISTANCIA = rot_distancia; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(ROT_ID))
   this._erroMensagem.Add("ROT ID deve ser informado.");
   if(string.IsNullOrEmpty(PON_ID_DESTINO))
   this._erroMensagem.Add("PON ID DESTINO deve ser informado.");
   if(string.IsNullOrEmpty(PON_ID_ORIGEM))
   this._erroMensagem.Add("PON ID ORIGEM deve ser informado.");
   if(string.IsNullOrEmpty(PON_ID_ROTEIRO))
   this._erroMensagem.Add("PON ID ROTEIRO deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration