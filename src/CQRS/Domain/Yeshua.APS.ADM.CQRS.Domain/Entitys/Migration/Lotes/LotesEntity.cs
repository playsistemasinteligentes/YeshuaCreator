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
                    public partial class LotesEntity : ILotesEntity
{
    public int? Id { get; set; }
    public string MOV_LOTE { get; set; }
    public string MOV_SUB_LOTE { get; set; }
    public Decimal? LOT_LARGURA { get; set; }
    public Decimal? LOT_COMPRIMENTO { get; set; }
    public Decimal? LOT_DIAMETRO { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal LotesEntity(int? id, string mov_lote, string mov_sub_lote, Decimal? lot_largura, Decimal? lot_comprimento, Decimal? lot_diametro ){
 Id = id; 
 MOV_LOTE = mov_lote; 
 MOV_SUB_LOTE = mov_sub_lote; 
 LOT_LARGURA = lot_largura; 
 LOT_COMPRIMENTO = lot_comprimento; 
 LOT_DIAMETRO = lot_diametro; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(MOV_LOTE))
   this._erroMensagem.Add("MOV LOTE deve ser informado.");
   if(string.IsNullOrEmpty(MOV_SUB_LOTE))
   this._erroMensagem.Add("MOV SUB LOTE deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration