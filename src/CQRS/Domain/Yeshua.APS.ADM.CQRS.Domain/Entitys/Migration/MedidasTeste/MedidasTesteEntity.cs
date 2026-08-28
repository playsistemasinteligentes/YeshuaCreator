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
                    public partial class MedidasTesteEntity : IMedidasTesteEntity
{
    public int? Id { get; set; }
    public int MDT_ID { get; set; }
    public string MDT_DESC { get; set; }
    public Decimal? MDT_VALOR_ESPERADO { get; set; }
    public Decimal? MDT_ENCONTRADO { get; set; }
    public string UNI_ID { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal MedidasTesteEntity(int? id, int mdt_id, string mdt_desc, Decimal? mdt_valor_esperado, Decimal? mdt_encontrado, string uni_id ){
 Id = id; 
 MDT_ID = mdt_id; 
 MDT_DESC = mdt_desc; 
 MDT_VALOR_ESPERADO = mdt_valor_esperado; 
 MDT_ENCONTRADO = mdt_encontrado; 
 UNI_ID = uni_id; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (MDT_ID == null)
   this._erroMensagem.Add("MDT ID deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration