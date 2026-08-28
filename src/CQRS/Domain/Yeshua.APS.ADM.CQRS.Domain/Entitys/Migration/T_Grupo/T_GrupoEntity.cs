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
                    public partial class T_GrupoEntity : IT_GrupoEntity
{
    public int GRU_ID { get; set; }
    public string NOME { get; set; }
    public int EXIBELISTA { get; set; }
    public string GRU_DESCRICAO { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal T_GrupoEntity(int gru_id, string nome, int exibelista, string gru_descricao ){
 GRU_ID = gru_id; 
 NOME = nome; 
 EXIBELISTA = exibelista; 
 GRU_DESCRICAO = gru_descricao; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (GRU_ID == null)
   this._erroMensagem.Add("GRU ID deve ser informado.");
   if(string.IsNullOrEmpty(NOME))
   this._erroMensagem.Add("NOME deve ser informado.");
   if (EXIBELISTA == null)
   this._erroMensagem.Add("EXIBELISTA deve ser informado.");
   if(string.IsNullOrEmpty(GRU_DESCRICAO))
   this._erroMensagem.Add("GRU DESCRICAO deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration