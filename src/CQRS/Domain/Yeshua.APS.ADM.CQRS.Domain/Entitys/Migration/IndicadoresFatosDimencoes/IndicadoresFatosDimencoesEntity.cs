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
                    public partial class IndicadoresFatosDimencoesEntity : IIndicadoresFatosDimencoesEntity
{
    public int? Id { get; set; }
    public string FAT_ID { get; set; }
    public int IND_ID { get; set; }
    public int DIM_ID { get; set; }
    public string FAT_DESCRICAO { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal IndicadoresFatosDimencoesEntity(int? id, string fat_id, int ind_id, int dim_id, string fat_descricao ){
 Id = id; 
 FAT_ID = fat_id; 
 IND_ID = ind_id; 
 DIM_ID = dim_id; 
 FAT_DESCRICAO = fat_descricao; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(FAT_ID))
   this._erroMensagem.Add("FAT ID deve ser informado.");
   if (IND_ID == null)
   this._erroMensagem.Add("IND ID deve ser informado.");
   if (DIM_ID == null)
   this._erroMensagem.Add("DIM ID deve ser informado.");
   if(string.IsNullOrEmpty(FAT_DESCRICAO))
   this._erroMensagem.Add("FAT DESCRICAO deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration