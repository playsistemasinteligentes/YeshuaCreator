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
                    public partial class MapaEntity : IMapaEntity
{
    public int? Id { get; set; }
    public int MAP_ID { get; set; }
    public string PON_ID { get; set; }
    public string PON_ID_VIZINHO { get; set; }
    public Decimal MAP_DISTANCIA { get; set; }
    public Decimal? MAP_CUSTO_PEDAGIO_POR_EIXO { get; set; }
    public int? ROD_ID { get; set; }
    public Decimal? MAP_ALTURA_ROD { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal MapaEntity(int? id, int map_id, string pon_id, string pon_id_vizinho, Decimal map_distancia, Decimal? map_custo_pedagio_por_eixo, int? rod_id, Decimal? map_altura_rod ){
 Id = id; 
 MAP_ID = map_id; 
 PON_ID = pon_id; 
 PON_ID_VIZINHO = pon_id_vizinho; 
 MAP_DISTANCIA = map_distancia; 
 MAP_CUSTO_PEDAGIO_POR_EIXO = map_custo_pedagio_por_eixo; 
 ROD_ID = rod_id; 
 MAP_ALTURA_ROD = map_altura_rod; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (MAP_ID == null)
   this._erroMensagem.Add("MAP ID deve ser informado.");
   if(string.IsNullOrEmpty(PON_ID))
   this._erroMensagem.Add("PON ID deve ser informado.");
   if(string.IsNullOrEmpty(PON_ID_VIZINHO))
   this._erroMensagem.Add("PON ID VIZINHO deve ser informado.");
   if (MAP_DISTANCIA == null)
   this._erroMensagem.Add("MAP DISTANCIA deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration